﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using HydroNumerics.Time.Core;
using HydroNumerics.Geometry;
using HydroNumerics.Geometry.Shapes;

namespace HydroNumerics.HydroNet.Core.UnitTest
{
  [TestClass()]
  public class LakeVedsted
  {
      string testDataPath = @"..\..\..\TestData\";
      //c:\Users\Gregersen\Documents\MyDocs\source\HNSVN\Trunk\HydroNumerics\HydroNet\Core\UnitTest\HydroNumerics.HydroNet.Core.UnitTest\bin\Debug\Vedsted.xml
    [TestMethod]
    public void GroundWaterTest()
    {

      Lake Vedsted= LakeFactory.GetLake("Vedsted Sø");
      Vedsted.Depth = 5;
      Vedsted.WaterLevel = 45.7;

      //Create and add precipitation boundary
      TimespanSeries Precipitation = new TimespanSeries();
      double[] values = new double[] { 108, 83, 73, 52, 61, 86, 99, 101, 75, 108, 85, 101 };
      AddMonthlyValues(Precipitation, 2007, values);
      SinkSourceBoundary Precip = new SinkSourceBoundary(Precipitation);
      Precip.ContactGeometry = Vedsted.SurfaceArea;
      Vedsted.Precipitation.Add(Precip);

      //Create and add evaporation boundary
      TimespanSeries Evaporation = new TimespanSeries();
      double[] values2 = new double[] {4,11,34,66,110,118,122,103,61,26,7,1 };
      AddMonthlyValues(Evaporation, 2007, values2);
      EvaporationRateBoundary eva = new EvaporationRateBoundary(Evaporation);
      eva.ContactGeometry = Vedsted.SurfaceArea;
      Vedsted.EvaporationBoundaries.Add(eva);
      
      //Create and add a discharge boundary
      TimestampSeries Discharge = new TimestampSeries();
      Discharge.AddSiValue(new DateTime(2007, 3, 12), 6986 / TimeSpan.FromDays(365).TotalSeconds);
      Discharge.AddSiValue(new DateTime(2007, 4, 3), 5894 / TimeSpan.FromDays(365).TotalSeconds);
      Discharge.AddSiValue(new DateTime(2007, 4, 25), 1205 / TimeSpan.FromDays(365).TotalSeconds);
      Discharge.RelaxationFactor = 1;
      Discharge.AllowExtrapolation = true;
      Assert.AreEqual(Discharge.GetValue(new DateTime(2007, 4, 25)), Discharge.GetValue(new DateTime(2007, 6, 25)),0.0000001);
      SinkSourceBoundary Kilde = new SinkSourceBoundary(Discharge);
      Vedsted.Sources.Add(Kilde);

      DateTime Start = new DateTime(2007, 1, 1);
      DateTime End = new DateTime(2007, 12, 31);

      //Add to an engine
      Model Engine = new Model();
      Engine.Name = "Vedsted-opsætning";
      Engine._waterBodies.Add(Vedsted);

      //Set initial state
      Engine.SetState("Initial", Start, new WaterPacket(1));

      //Increase depth to prevent outflow
      Vedsted.Depth *= 1.5;

      Engine.Save("VedstedNoGroundwater");


      XYPolygon ContactArea = XYPolygon.GetSquare(Vedsted.Area/10);

      #region Groundwater boundaries
      //Add groundwater boundaries
      GroundWaterBoundary B1 = new GroundWaterBoundary(Vedsted, 1.3e-6, 1, 45.47, ContactArea);
      B1.Name = "B1";
      Vedsted.GroundwaterBoundaries.Add(B1);

      GroundWaterBoundary B2 = new GroundWaterBoundary(Vedsted, 1e-6, 1, 44.96, ContactArea);
      B2.Name = "B2";
      Vedsted.GroundwaterBoundaries.Add(B2);

      GroundWaterBoundary B3 = new GroundWaterBoundary(Vedsted, 2e-6, 1, 44.63, ContactArea);
      B3.Name = "B3";
      Vedsted.GroundwaterBoundaries.Add(B3);

      GroundWaterBoundary B4 = new GroundWaterBoundary(Vedsted, 4.9e-7, 1, 44.75, ContactArea);
      B4.Name = "B4";
      Vedsted.GroundwaterBoundaries.Add(B4);

      GroundWaterBoundary B5 = new GroundWaterBoundary(Vedsted, 1.5e-8, 1, 44.27, ContactArea);
      B5.Name = "B5";
      Vedsted.GroundwaterBoundaries.Add(B5);

      GroundWaterBoundary B6 = new GroundWaterBoundary(Vedsted, 1.5e-8, 1, 44.16, ContactArea);
      B6.Name = "B6";
      Vedsted.GroundwaterBoundaries.Add(B6);

      GroundWaterBoundary B7 = new GroundWaterBoundary(Vedsted, 1.1e-6, 1, 45.15, ContactArea);
      B7.Name = "B7";
      Vedsted.GroundwaterBoundaries.Add(B7);

      GroundWaterBoundary B8 = new GroundWaterBoundary(Vedsted, 1.1e-6, 1, 44.54, ContactArea);
      B8.Name = "B8";
      Vedsted.GroundwaterBoundaries.Add(B8);

      GroundWaterBoundary B9 = new GroundWaterBoundary(Vedsted, 2.1e-8, 1, 45.4, ContactArea);
      B9.Name = "B9";
      Vedsted.GroundwaterBoundaries.Add(B9);

      GroundWaterBoundary B10 = new GroundWaterBoundary(Vedsted, 3.5e-6, 1, 45.16, ContactArea);
      B10.Name = "B10";
      Vedsted.GroundwaterBoundaries.Add(B10);

      #endregion
 

      #region ////Add seepage meter boundaries
      //GroundWaterBoundary S1 = new GroundWaterBoundary(Vedsted, 4e-5, 1, 2, 46);
      //Vedsted.SinkSources.Add(S1);
      //GroundWaterBoundary S2 = new GroundWaterBoundary(Vedsted, 4e-5, 1, 2, 46);
      //Vedsted.SinkSources.Add(S2);
      //GroundWaterBoundary S3 = new GroundWaterBoundary(Vedsted, 4e-5, 1, 2, 46);
      //Vedsted.SinkSources.Add(S3);
      //GroundWaterBoundary I1 = new GroundWaterBoundary(Vedsted, 4e-5, 1, 2, 46);
      //Vedsted.SinkSources.Add(I1);
      //GroundWaterBoundary I2 = new GroundWaterBoundary(Vedsted, 4e-5, 1, 2, 46);
      //Vedsted.SinkSources.Add(I2);
      //GroundWaterBoundary I3 = new GroundWaterBoundary(Vedsted, 4e-5, 1, 2, 46);
      //Vedsted.SinkSources.Add(I3);

#endregion


      Assert.AreEqual(Evaporation.EndTime, Engine.MaximumEndTime);

      Engine.MoveInTime(End, TimeSpan.FromDays(30));

      double outflow2 = Vedsted.Output.Outflow.GetValue(Start, End.Subtract(TimeSpan.FromDays(5)));
      double evapo2 = Vedsted.Output.Evaporation.GetValue(Start, End.Subtract(TimeSpan.FromDays(5)));

      Engine.Save(testDataPath + "Vedsted2.xml");

//      Vedsted.Output.Save(@"c:\temp\step2.xts");
      //Assert.AreEqual(outflow- evapo, outflow2 - evapo2, 0.000001);
      Engine.SetState("MyState", new DateTime(2007, 1, 1), new WaterPacket(30)); 
      Engine.Save(testDataPath + "Vedsted.xml");


      IsotopeWater iwlake = new IsotopeWater(1);
      iwlake.SetIsotopeRatio(2.5);

      //Increase the volume to prevent outflow
      Vedsted.Depth /= 1.5;
      Engine.SetState("Isotop", Start, iwlake);
      Vedsted.Depth *= 1.5;

      Vedsted.Precipitation.Clear();
      IsotopeWater precipwater = new IsotopeWater(1);
      precipwater.SetIsotopeRatio(10);
      Precip.WaterSample = precipwater;
      Vedsted.Precipitation.Add(Precip);

      Vedsted.Sources.Clear();
      SinkSourceBoundary fb = new SinkSourceBoundary(50000 / 365 / 86400);
      IsotopeWater gw = new IsotopeWater(1);
      gw.SetIsotopeRatio(8.5);
      fb.WaterSample = gw;
      Vedsted.Sources.Add(fb);

      SinkSourceBoundary fbout = new SinkSourceBoundary(-50000 / 365 / 86400);
      Vedsted.Sinks.Add(fbout);
      Vedsted.Output.LogChemicalConcentration(ChemicalFactory.Instance.GetChemical(ChemicalNames.IsotopeFraction));

      Engine.MoveInTime(End, TimeSpan.FromDays(30));
//      Vedsted.Output.Save(@"c:\temp\isotope.xts");

      Engine.Save(testDataPath + "setup.xml");

      foreach (var v in Vedsted.Output.Items.Last().Values)
        Console.WriteLine(v);
 

      Model m = ModelFactory.GetModel(testDataPath + "setup.xml");
    }

    public static void AddMonthlyValues(TimespanSeries TS, int year, double[] values)
    {
      double conversion1 = 1.0 / 1000 / 86400 / 31;
      double conversion2 = 1.0 / 1000 / 86400 / 28;
      double conversion3 = 1.0 / 1000 / 86400 / 30;
      TS.AddSiValue(new DateTime(year, 1, 1),new DateTime(year, 2, 1), values[0] * conversion1);
      TS.AddSiValue(new DateTime(year, 2, 1), new DateTime(year, 3, 1), values[1] * conversion2);
      TS.AddSiValue(new DateTime(year, 3, 1), new DateTime(year, 4, 1), values[2] * conversion1);
      TS.AddSiValue(new DateTime(year, 4, 1), new DateTime(year, 5, 1), values[3] * conversion3);
      TS.AddSiValue(new DateTime(year, 5, 1), new DateTime(year, 6, 1), values[4] * conversion1);
      TS.AddSiValue(new DateTime(year, 6, 1), new DateTime(year, 7, 1), values[5] * conversion3);
      TS.AddSiValue(new DateTime(year, 7, 1), new DateTime(year, 8, 1), values[6] * conversion1);
      TS.AddSiValue(new DateTime(year, 8, 1), new DateTime(year, 9, 1), values[7] * conversion3);
      TS.AddSiValue(new DateTime(year, 9, 1), new DateTime(year, 10, 1), values[8] * conversion1);
      TS.AddSiValue(new DateTime(year, 10, 1), new DateTime(year,11, 1), values[9] * conversion3);
      TS.AddSiValue(new DateTime(year, 11, 1), new DateTime(year, 12, 1), values[10] * conversion1);
      TS.AddSiValue(new DateTime(year, 12, 1), new DateTime(year + 1, 1, 1), values[11] * conversion3);

    }
    [TestMethod]
    public void IsotopeTest()
    {
            DateTime Start = new DateTime(2007, 1, 1);
      DateTime End = new DateTime(2007, 12, 31);

      Model m = ModelFactory.GetModel("VedstedNoGroundwater");
      Lake Vedsted = (Lake)m._waterBodies[0];
      Vedsted.Sources.RemoveAt(0);

      Chemical cl = ChemicalFactory.Instance.GetChemical(ChemicalNames.Cl);
      Vedsted.Output.LogChemicalConcentration(ChemicalFactory.Instance.GetChemical(ChemicalNames.IsotopeFraction));
      Vedsted.Output.LogChemicalConcentration(cl);

      IsotopeWater Iw = new IsotopeWater(1);
      Iw.SetIsotopeRatio(10);
      Iw.AddChemical(cl, 0.1);

      Assert.AreEqual(10,Iw.GetConcentration(ChemicalFactory.Instance.GetChemical(ChemicalNames.IsotopeFraction)));
       m.SetState("Initial", Start, Iw);

       Assert.AreEqual(10, ((WaterPacket)Vedsted.CurrentStoredWater).GetConcentration(ChemicalFactory.Instance.GetChemical(ChemicalNames.IsotopeFraction)));

       IsotopeWater precip = new IsotopeWater(1);
       precip.SetIsotopeRatio(5);

       //((FlowBoundary)m._waterBodies[0].SinkSources[0]).WaterSample = precip;

       //EvaporationRateBoundary er = new EvaporationRateBoundary(0.001);

//       m._waterBodies[0].EvaporationBoundaries.Add(er);

       //FlowBoundary gwb = new FlowBoundary(0.001);
       //IsotopeWater Iw2 = new IsotopeWater(1);
       //Iw2.SetIsotopeRatio(15);
       //Iw2.AddChemical(cl, 0.1);
       //gwb.WaterSample = Iw2;

       //m._waterBodies[0].SinkSources.Add(gwb);

      m.MoveInTime(End, TimeSpan.FromDays(30));

      foreach (var v in Vedsted.Output.Items[6].Values)
        Console.WriteLine(v);
      foreach (var v in Vedsted.Output.Items[5].Values)
        Console.WriteLine(v);

      Console.WriteLine(Vedsted.GetStorageTime(Start.AddDays(40), End.AddDays(-40)));


    }

  }
}
