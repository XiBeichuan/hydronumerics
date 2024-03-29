﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HydroNumerics.Wells;
using HydroNumerics.MikeSheTools.DFS;
using HydroNumerics.MikeSheTools.PFS.SheFile;
using MathNet.Numerics.LinearAlgebra;

namespace HydroNumerics.MikeSheTools.Core
{
  public class Results:IDisposable 
  {
    private DFS3 SZ3D;

    /// <summary>
    /// The name of the item containing head elevation data.  
    /// </summary>
    public string HeadElevationString = "head elevation in saturated zone";

    private DataSetsFromDFS3 _heads;
    private DataSetsFromDFS3 _xflow;
    private DataSetsFromDFS3 _yflow;
    private DataSetsFromDFS3 _zflow;
    private DataSetsFromDFS3 _groundWaterExtraction;
    private DataSetsFromDFS3 _sZExchangeFlowWithRiver;
    private DataSetsFromDFS3 _sZDrainageFlow;
    private PhreaticPotential _phreaticHead;

    public List<DetailedMike11> mike11Observations;
    public List<DetailedMike11> Mike11Observations
    {
      get
      {
        if (mike11Observations == null & mshe!=null)
        {
          InitializeDetailedM11();
        }
        return mike11Observations;
      }
    }

    private void InitializeDetailedM11()
    {
      mike11Observations = new List<DetailedMike11>();

      DFS0 simdata = new DFS0(mshe.Files.DetailedTimeSeriesM11);
      Dictionary<string, DFS0> ObsCache= new Dictionary<string,DFS0>();


      foreach (var obs in mshe.Input.MIKESHE_FLOWMODEL.StoringOfResults.DetailedM11TimeseriesOutput.Item_1s)
      {
        var m = new DetailedMike11() { Chainage = obs.Chainage, Name = obs.Name };

        m.Branch = mshe.River.network.GetBranch(obs.BranchName, obs.Chainage);

        if (m.Branch != null)
        {
          m.Location = m.Branch.GetPointAtChainage(obs.Chainage);
          var item = simdata.Items.FirstOrDefault(i => i.Name == m.Name);

          if (item != null)
            m.Simulation = simdata.GetTimeSpanSeries(item.ItemNumber);


          if (obs.InclObserved == 1)
          {
            DFS0 obsdata;
            if (!ObsCache.TryGetValue(obs.TIME_SERIES_FILE.FILE_NAME, out obsdata))
            {
              obsdata = new DFS0(obs.TIME_SERIES_FILE.FILE_NAME);
              ObsCache.Add(obs.TIME_SERIES_FILE.FILE_NAME, obsdata);
            }
              m.Observation = obsdata.GetTimeSpanSeries(obs.TIME_SERIES_FILE.ITEM_NUMBERS);
          }
          mike11Observations.Add(m);
        }
      }
      simdata.Dispose();
      foreach (var obsdata in ObsCache.Values)
        obsdata.Dispose();
    }


    private Model mshe;
    private MikeSheGridInfo _grid;    


    #region Constructors

    /// <summary>
    /// Constructs results from .dfs3 file with head data and a GridInfo object. 
    /// This constructor is only to be used by LayerStatistics.
    /// </summary>
    /// <param name="SZ3DFileName"></param>
    /// <param name="Grid"></param>
    public Results(string SZ3DFileName, MikeSheGridInfo Grid)
    {
      _grid = Grid;
      Initialize3DSZ(SZ3DFileName);
    }

    /// <summary>
    /// Constructs results from .dfs3 file with head data and a GridInfo object. 
    /// This constructor is only to be used by LayerStatistics.
    /// </summary>
    /// <param name="SZ3DFileName"></param>
    /// <param name="Grid"></param>
    public Results(string SZ3DFileName, MikeSheGridInfo Grid, string HeadElevationString)
    {
      this.HeadElevationString = HeadElevationString;
      _grid = Grid;
      Initialize3DSZ(SZ3DFileName);
    }



    /// <summary>
    /// Use this when the filenames object and the GridInfo object have already been constructed
    /// </summary>
    /// <param name="fileNames"></param>
    /// <param name="Grid"></param>
    internal Results(Model Mshe)
    {
      mshe = Mshe;
      _grid = mshe.GridInfo;
      if (System.IO.File.Exists(Mshe.Files.SZ3DFileName))
      {
        Initialize3DSZ(mshe.Files.SZ3DFileName);
        Initialize3DSZFlow(mshe.Files.SZ3DFlowFileName);
      }
    }

    #endregion

    /// <summary>
    /// Gets the delete value
    /// </summary>
    public double DeleteValue { get; private set; }


    public IXYZTDataSet Heads
    {
      get { return _heads; }
    }

    public IXYZTDataSet PhreaticHead
    {
      get { return _phreaticHead; }
    }

    public IXYZTDataSet Xflow
    {
      get { return _xflow; }
    }
    public IXYZTDataSet Yflow
    {
      get { return _yflow; }
    }
    public IXYZTDataSet ZFlow
    {
      get { return _zflow; }
    }
    public IXYZTDataSet GroundWaterExtraction
    {
      get { return _groundWaterExtraction; }
    }
    public IXYZTDataSet SZExchangeFlowWithRiver
    {
      get { return _sZExchangeFlowWithRiver; }
    }
    public IXYZTDataSet SZDrainageFlow
    {
      get { return _sZDrainageFlow; }
    }


    /// <summary>
    /// Opens the necessary dfs-files and sets up the references to the properties
    /// </summary>
    /// <param name="fileNames"></param>
    private void Initialize3DSZ(string sz3dFile)
    {
        SZ3D = new DFS3(sz3dFile);
        if (SZ3D != null)
        {
          DeleteValue = SZ3D.DeleteValue;
          for (int i = 0; i < SZ3D.Items.Length; i++)
          {
            if (SZ3D.Items[i].Name.Equals(HeadElevationString, StringComparison.OrdinalIgnoreCase))
            {
              _heads = new DataSetsFromDFS3(SZ3D, i + 1);
              //Also create the phreatic heads;
              _phreaticHead = new PhreaticPotential(_heads, _grid, SZ3D.DeleteValue);
            }
          }
        }
    }

    private void Initialize3DSZFlow(string sz3dFlowFile)
    {

      DFS3 SZ3DFlow = new DFS3(sz3dFlowFile);

      if (SZ3DFlow != null)
      {
        for (int i = 0; i < SZ3DFlow.Items.Length; i++)
        {
          switch (SZ3DFlow.Items[i].Name)
          {
            case "groundwater flow in x-direction":
              _xflow = new DataSetsFromDFS3(SZ3DFlow, i + 1);
              break;
            case "groundwater flow in y-direction":
              _yflow = new DataSetsFromDFS3(SZ3DFlow, i + 1);
              break;
            case "groundwater flow in z-direction":
              _zflow = new DataSetsFromDFS3(SZ3DFlow, i + 1);
              break;
            case "groundwater extraction":
              _groundWaterExtraction = new DataSetsFromDFS3(SZ3DFlow, i + 1);
              break;
            case "SZ exchange flow with river":
              _sZExchangeFlowWithRiver = new DataSetsFromDFS3(SZ3DFlow, i + 1);
              break;
            case "SZ drainage flow from point":
              _sZDrainageFlow = new DataSetsFromDFS3(SZ3DFlow, i + 1);
              break;
            default:
              break;
          }
        }
      }
    }



    #region IDisposable Members

    public void Dispose()
    {
      if (SZ3D != null)
        SZ3D.Dispose();
    }

    #endregion
  }
}
