﻿using HydroNumerics.Nitrate.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Diagnostics;

namespace HydroNumerics.Nitrate.Model.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for MainViewModelTest and is intended
    ///to contain all MainViewModelTest Unit Tests
    ///</summary>
  [TestClass()]
  public class MainViewModelTest
  {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion


    /// <summary>
    ///A test for CurrentCatchment
    ///</summary>
    [Ignore]
    [TestMethod()]
    public void CurrentCatchmentTest()
    {
      MainViewModel target = new MainViewModel();
      target.LoadCatchments(@"D:\DK_information\TestData\FileStructure\id15_NSTmodel.shp");
      target.CurrentCatchment = target.AllCatchments.Values.First();
      Stopwatch sw = new Stopwatch();
      sw.Start();

      foreach (var c in target.AllCatchments.Values)
      {
        var b = c.Geometry.BoundingBox;
      }

      sw.Stop();

      sw.Reset();

    }

    [Ignore]
    [TestMethod]
    public void BuildGWTest()
    {
      MainViewModel target = new MainViewModel();
      target.LoadCatchments(@"D:\DK_information\TestData\FileStructure\id15_NSTmodel.shp");

      int k = 0;
    }



    /// <summary>
    ///A test for LoadMikeSheData
    ///</summary>
    [TestMethod()]
    [Ignore]
    public void LoadMikeSheDataTest()
    {
      MainViewModel target = new MainViewModel(); // TODO: Initialize to an appropriate value
      target.LoadCatchments(@"D:\DK_information\TestData\FileStructure\id15_NSTmodel.shp");
      target.LoadMikeSheData(@"E:\dhi\data\dkm\dk2\result\DK2_v3_gvf_PT_100p_24hr.she");
    }

    /// <summary>
    ///A test for MainViewModel Constructor
    ///</summary>
    [TestMethod()]
    public void MainViewModelConstructorTest()
    {
      MainViewModel target = new MainViewModel(@"d:\temp\config.xml");

      target.Run();

      target.Print(@"d:\temp\output.csv");
    }
  }
}