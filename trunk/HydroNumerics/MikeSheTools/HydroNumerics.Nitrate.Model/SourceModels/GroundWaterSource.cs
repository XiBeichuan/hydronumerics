﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

using HydroNumerics.Core;
using HydroNumerics.Geometry;
using HydroNumerics.Geometry.Shapes;
using HydroNumerics.Time2;

namespace HydroNumerics.Nitrate.Model
{
  public class GroundWaterSource : BaseModel, ISource
  {
    public List<Particle> Particles { get; set; }
    private SoilCodesGrid DaisyCodes;
    private Dictionary<int, float[]> GWInput;


    public GroundWaterSource()
    {
    }

    private SafeFile _SoilCodes;
    public SafeFile SoilCodes
    {
      get { return _SoilCodes; }
      set
      {
        if (_SoilCodes != value)
        {
          _SoilCodes = value;
          NotifyPropertyChanged("SoilCodes");
        }
      }
    }

    private List<SafeFile> _ParticleFiles = new List<SafeFile>();
    public List<SafeFile> ParticleFiles
    {
      get { return _ParticleFiles; }
      set
      {
        if (_ParticleFiles != value)
        {
          _ParticleFiles = value;
          NotifyPropertyChanged("ParticleFiles");
        }
      }
    }

    private List<SafeFile> _DaisyFiles= new List<SafeFile>();
    public List<SafeFile> DaisyFiles
    {
      get { return _DaisyFiles; }
      set
      {
        if (_DaisyFiles != value)
        {
          _DaisyFiles = value;
          NotifyPropertyChanged("DaisyFiles");
        }
      }
    }
    
    
    

    public override void ReadConfiguration(XElement Configuration)
    {
      base.ReadConfiguration(Configuration);
      if (Update)
      {
        foreach (var parfile in Configuration.Element("DaisyFiles").Elements("DaisyFile"))
        {
          DaisyFiles.Add(new SafeFile() { FileName = parfile.SafeParseString("FileName") });
        }
        foreach (var parfile in Configuration.Element("ParticleFiles").Elements("ParticleFile"))
        {
          ParticleFiles.Add(new SafeFile() { FileName = parfile.SafeParseString("ShapeFileName") });
          ParticleFiles.Last().Parameters.Add(parfile.SafeParseInt("NumberOfParticlesInGridBlock")??100);

        }
        SoilCodes = new SafeFile() { FileName = Configuration.Element("SoilCodes").SafeParseString("ShapeFileName") };
      }
    }


    public override void Initialize(DateTime Start, DateTime End, IEnumerable<Catchment> Catchments)
    {
      LoadSoilCodesGrid(SoilCodes.FileName);

      foreach (var parfile in DaisyFiles)
      {
        LoadDaisyData(parfile.FileName);
      }

      foreach (var parfile in ParticleFiles)
      {
        LoadParticles(parfile.FileName);
        CombineParticlesAndCatchments(Catchments);
        int NumberOfParticles = (int) parfile.Parameters.First();
        BuildInputConcentration(Start, End, Catchments, NumberOfParticles);
      }
      this.Start = Start;
    }





    /// <summary>
    /// Returns the source rate to the catchment in kg/s at the current time
    /// </summary>
    /// <param name="c"></param>
    /// <param name="CurrentTime"></param>
    /// <returns></returns>
    public double GetValue(Catchment c, DateTime CurrentTime)
    {
      if (GWInput.ContainsKey(c.ID))
        return GWInput[c.ID][(CurrentTime.Year - Start.Year) * 12 + CurrentTime.Month - Start.Month];
      else
        return 0;
    }

    public DistributedLeaching leachdata;


    public void LoadDaisyData(string DaisyResultsFileName)
    {
      NewMessage("Loading daisy data from: " + DaisyResultsFileName);
      if (leachdata == null)
        leachdata = new DistributedLeaching();
      leachdata.LoadFile(DaisyResultsFileName);
    }


    public void LoadSoilCodesGrid(string ShapeFileName)
    {
      DaisyCodes = new SoilCodesGrid();
      DaisyCodes.BuildGrid(ShapeFileName);
    }


    public void LoadParticles(string ShapeFileName)
    {
      NewMessage("Reading particles from: " + ShapeFileName);
      List<int> RedoxedParticles = new List<int>();
      Dictionary<int, Particle> NonRedoxedParticles = new Dictionary<int, Particle>();

      if (Particles == null)
        Particles = new List<Particle>();
  
      using (ShapeReader sr = new ShapeReader(ShapeFileName))
      {
        for (int i = 0; i < sr.Data.NoOfEntries; i++)
        {
          int id = sr.Data.ReadInt(i, "ID");
          double x = sr.Data.ReadDouble(i, "X-Reg");
          double y = sr.Data.ReadDouble(i, "Y-Reg");

          Particle p = new Particle();
          IXYPoint point = (IXYPoint)sr.ReadNext();
          p.XStart = point.X;
          p.YStart = point.Y;
          p.X = x;
          p.Y = y;
          //          p.StartXGrid = sr.Data.ReadInt(i, "IX-Birth");
          //          p.StartYGrid = sr.Data.ReadInt(i, "IY-Birth");
          p.TravelTime = sr.Data.ReadDouble(i, "TravelTime");


          int reg = sr.Data.ReadInt(i, "Registrati");
          if (reg == 1)
            RedoxedParticles.Add(id);
          else
            NonRedoxedParticles.Add(id, p);
        }

        foreach (var pid in RedoxedParticles)
          NonRedoxedParticles.Remove(pid);

        NewMessage(NonRedoxedParticles.Values.Count + " particles read");
        Particles.AddRange(NonRedoxedParticles.Values);
      }
    }

    /// <summary>
    /// Gets the groundwater concentration for each catchment using the particles and the Daisy output
    /// </summary>
    /// <param name="Start"></param>
    /// <param name="End"></param>
    /// <param name="NumberOfParticlesPrGrid"></param>
    public void BuildInputConcentration(DateTime Start, DateTime End, IEnumerable<Catchment> Catchments, int NumberOfParticlesPrGrid)
    {

      NewMessage("Getting input for each catchment from daisy file");
      int numberofmonths = (End.Year - Start.Year) * 12 + End.Month - Start.Month;
     
      if (GWInput==null)
      GWInput = new Dictionary<int, float[]>();

      Parallel.ForEach(Catchments.Where(ca => ca.Particles.Count > 0), new ParallelOptions() { MaxDegreeOfParallelism = 7 }, c =>
        {
          List<float> values = new List<float>();
          for (int i = 0; i < numberofmonths; i++)
            values.Add(0);

          foreach (var p in c.Particles)
          {
            int gridid = DaisyCodes.GetID(p.XStart, p.YStart);
            var newlist = leachdata.Grids[gridid].TimeData.GetValues(Start.AddDays(-p.TravelTime * 365), End.AddDays(-p.TravelTime * 365));
            for (int i = 0; i < numberofmonths; i++)
              values[i] += newlist[i];
          }
          c.Particles.Clear();
          this.GWInput.Add(c.ID, values.Select(v=>v/NumberOfParticlesPrGrid).ToArray());
        });
    }

    private object Lock = new object();

    public void CombineParticlesAndCatchments(IEnumerable<Catchment> Catchments)
    {
      NewMessage("Distributing particles on catchments");
      var bb = HydroNumerics.Geometry.XYGeometryTools.BoundingBox(Particles);

      var selectedCatchments = Catchments.Where(c => c.Geometry.OverLaps(bb)).ToArray();

      Parallel.ForEach(Particles, 
        (p) =>
        {
          foreach (var c in selectedCatchments)
          {
            if (c.Geometry.Contains(p.X, p.Y))
            {
              lock (Lock)
                c.Particles.Add(p);
              break;
            }
          }
        });
    }

    #region Properties

    private DateTime _Start;
    public DateTime Start
    {
      get { return _Start; }
      set
      {
        if (_Start != value)
        {
          _Start = value;
          NotifyPropertyChanged("Start");
        }
      }
    }

    #endregion

  }
}