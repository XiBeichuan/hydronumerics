﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HydroNumerics.MikeSheTools.DFS;


namespace HydroNumerics.MikeSheTools.Core
{
  public class ProcessedData:IDisposable 
  {
    private DFS3 _PreProcessed_3DSZ = null;
    private DFS2 _prePro2D;

    private DataSetsFromDFS3 _initialHeads;
    private DataSetsFromDFS3 _horizontalConductivity;
    private DataSetsFromDFS3 _verticalConductivity;
    private DataSetsFromDFS3 _transmissivity;
    private DataSetsFromDFS3 _specificYield;
    private DataSetsFromDFS3 _specificStorage;


    private DataSetsFromDFS2 _netRainFallFraction;
    private DataSetsFromDFS2 _infiltrationFraction;
    private MikeSheGridInfo _grid;

    #region Constructors

    public ProcessedData(string SheFileName)
    {
      FileNames files = new FileNames(SheFileName);
      Initialize(files.PreProcessedSZ3D, files.PreProcessed2D);
    }

    public ProcessedData(string PreProcessed3dSzFile, string PreProcessed2dSzFile)
    {
      Initialize(PreProcessed3dSzFile, PreProcessed2dSzFile);
    }

    internal ProcessedData(FileNames files)
    {
      Initialize(files.PreProcessedSZ3D, files.PreProcessed2D);
    }

    #endregion



    private void Initialize(string PreProcessed3dSzFile, string PreProcessed2dSzFile)
    {
      //Open File with 3D data
      if (System.IO.File.Exists(PreProcessed3dSzFile))
      {
        _PreProcessed_3DSZ = new DFS3(PreProcessed3dSzFile);

        //Generate 3D properties
        for (int i = 0; i < _PreProcessed_3DSZ.Items.Length; i++)
        {
          switch (_PreProcessed_3DSZ.Items[i].Name)
          {
            case "Horizontal conductivity in the saturated zone":
              _horizontalConductivity = new DataSetsFromDFS3(_PreProcessed_3DSZ, i + 1);
              break;
            case "Vertical conductivity in the saturated zone":
              _verticalConductivity = new DataSetsFromDFS3(_PreProcessed_3DSZ, i + 1);
              break;
            case "Transmissivity in the saturated zone":
              _transmissivity = new DataSetsFromDFS3(_PreProcessed_3DSZ, i + 1);
              break;
            case "Specific yield in the saturated zone":
              _specificYield = new DataSetsFromDFS3(_PreProcessed_3DSZ, i + 1);
              break;
            case "Specific storage in the saturated zone":
              _specificStorage = new DataSetsFromDFS3(_PreProcessed_3DSZ, i + 1);
              break;
            case "Initial potential heads in the saturated zone":
              _initialHeads = new DataSetsFromDFS3(_PreProcessed_3DSZ, i + 1);
              break;
            default: //Unknown item
              break;
          }
        }
      }

      //Open File with 2D data
      _prePro2D = new DFS2(PreProcessed2dSzFile);

      //Generate 2D properties by looping the items
      for (int i = 0; i < _prePro2D.Items.Length; i++)
      {
        switch (_prePro2D.Items[i].Name)
        {
          case "Net Rainfall Fraction":
            _netRainFallFraction = new DataSetsFromDFS2(_prePro2D, i +1);
            break;
          case "Infiltration Fraction":
            _infiltrationFraction = new DataSetsFromDFS2(_prePro2D, i +1);
            break;
          default: //Unknown item
            break;
        }
      }

      //Now construct the grid from the open files
      _grid = new MikeSheGridInfo(_PreProcessed_3DSZ, _prePro2D);
    }


    public MikeSheGridInfo Grid
    {
      get { return _grid; }
    }


    public IXYDataSet NetRainFallFraction
    {
      get { return _netRainFallFraction; }
    }

    public IXYDataSet InfiltrationFraction
    {
      get { return _infiltrationFraction; }
    }

    public IXYZDataSet InitialHeads
    {
      get { return _initialHeads; }
    }

    public IXYZDataSet SpecificStorage
    {
      get { return _specificStorage; }
    }

    public IXYZDataSet SpecificYield
    {
      get { return _specificYield; }
    }

    public IXYZDataSet Transmissivity
    {
      get { return _transmissivity; }
    }

    public IXYZDataSet VerticalConductivity
    {
      get { return _verticalConductivity; }
    }

    public IXYZDataSet HorizontalConductivity
    {
      get { return _horizontalConductivity; }
    }

    #region IDisposable Members

    /// <summary>
    /// Disposes the underlying dfs files
    /// </summary>
    public void Dispose()
    {
      if (_prePro2D != null)
        _prePro2D.Dispose();
      if (_PreProcessed_3DSZ != null)
        _PreProcessed_3DSZ.Dispose();
    }

    #endregion
  }
}
