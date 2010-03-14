using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;

namespace HydroNumerics.MikeSheTools.PFS.SheFile
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class Source1: PFSMapper
  {

    private DFS_2D_DATA_FILE _tIME_SERIES_FILE;

    internal Source1(PFSSection Section)
    {
      _pfsHandle = Section;

      for (int i = 1; i <= Section.GetSectionsNo(); i++)
      {
        PFSSection sub = Section.GetSection(i);
        switch (sub.Name)
        {
        case "TIME_SERIES_FILE":
          _tIME_SERIES_FILE = new DFS_2D_DATA_FILE(sub);
          break;
          default:
            _unMappedSections.Add(sub.Name);
          break;
        }
      }
    }

    public DFS_2D_DATA_FILE TIME_SERIES_FILE
    {
     get { return _tIME_SERIES_FILE; }
    }

    public int Touched
    {
      get
      {
        return _pfsHandle.GetKeyword("Touched", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("Touched", 1).GetParameter(1).Value = value;
      }
    }

    public int IsDataUsedInSetup
    {
      get
      {
        return _pfsHandle.GetKeyword("IsDataUsedInSetup", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("IsDataUsedInSetup", 1).GetParameter(1).Value = value;
      }
    }

    public int SourceTypeCode
    {
      get
      {
        return _pfsHandle.GetKeyword("SourceTypeCode", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("SourceTypeCode", 1).GetParameter(1).Value = value;
      }
    }

    public int WaterApplication
    {
      get
      {
        return _pfsHandle.GetKeyword("WaterApplication", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("WaterApplication", 1).GetParameter(1).Value = value;
      }
    }

    public int DirectApplication
    {
      get
      {
        return _pfsHandle.GetKeyword("DirectApplication", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("DirectApplication", 1).GetParameter(1).Value = value;
      }
    }

    public string RiverNameRS
    {
      get
      {
        return _pfsHandle.GetKeyword("RiverNameRS", 1).GetParameter(1).ToString();
      }
      set
      {
        _pfsHandle.GetKeyword("RiverNameRS", 1).GetParameter(1).Value = value;
      }
    }

    public int UpstreamChainageRS
    {
      get
      {
        return _pfsHandle.GetKeyword("UpstreamChainageRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UpstreamChainageRS", 1).GetParameter(1).Value = value;
      }
    }

    public int DownstreamChainageRS
    {
      get
      {
        return _pfsHandle.GetKeyword("DownstreamChainageRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("DownstreamChainageRS", 1).GetParameter(1).Value = value;
      }
    }

    public int CapacityRS
    {
      get
      {
        return _pfsHandle.GetKeyword("CapacityRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("CapacityRS", 1).GetParameter(1).Value = value;
      }
    }

    public int UseThresholdDischargeRateRS
    {
      get
      {
        return _pfsHandle.GetKeyword("UseThresholdDischargeRateRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UseThresholdDischargeRateRS", 1).GetParameter(1).Value = value;
      }
    }

    public int ThresholdDischargeRateStopRS
    {
      get
      {
        return _pfsHandle.GetKeyword("ThresholdDischargeRateStopRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ThresholdDischargeRateStopRS", 1).GetParameter(1).Value = value;
      }
    }

    public int ThresholdDischargeRateRestartRS
    {
      get
      {
        return _pfsHandle.GetKeyword("ThresholdDischargeRateRestartRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ThresholdDischargeRateRestartRS", 1).GetParameter(1).Value = value;
      }
    }

    public int UseThresholdStageRS
    {
      get
      {
        return _pfsHandle.GetKeyword("UseThresholdStageRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UseThresholdStageRS", 1).GetParameter(1).Value = value;
      }
    }

    public int ThresholdStageStopRS
    {
      get
      {
        return _pfsHandle.GetKeyword("ThresholdStageStopRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ThresholdStageStopRS", 1).GetParameter(1).Value = value;
      }
    }

    public int ThresholdStageRestartRS
    {
      get
      {
        return _pfsHandle.GetKeyword("ThresholdStageRestartRS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ThresholdStageRestartRS", 1).GetParameter(1).Value = value;
      }
    }

    public double WellXposSIWS
    {
      get
      {
        return _pfsHandle.GetKeyword("WellXposSIWS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("WellXposSIWS", 1).GetParameter(1).Value = value;
      }
    }

    public double WellYposSIWS
    {
      get
      {
        return _pfsHandle.GetKeyword("WellYposSIWS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("WellYposSIWS", 1).GetParameter(1).Value = value;
      }
    }

    public double ScreenTopDepthSIWS
    {
      get
      {
        return _pfsHandle.GetKeyword("ScreenTopDepthSIWS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("ScreenTopDepthSIWS", 1).GetParameter(1).Value = value;
      }
    }

    public double CapacitySIWS
    {
      get
      {
        return _pfsHandle.GetKeyword("CapacitySIWS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("CapacitySIWS", 1).GetParameter(1).Value = value;
      }
    }

    public double ThresholdDepthSIWS
    {
      get
      {
        return _pfsHandle.GetKeyword("ThresholdDepthSIWS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("ThresholdDepthSIWS", 1).GetParameter(1).Value = value;
      }
    }

    public double ScreenBottomDepthSIWS
    {
      get
      {
        return _pfsHandle.GetKeyword("ScreenBottomDepthSIWS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("ScreenBottomDepthSIWS", 1).GetParameter(1).Value = value;
      }
    }

    public int ScreenTopDepthSWS
    {
      get
      {
        return _pfsHandle.GetKeyword("ScreenTopDepthSWS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ScreenTopDepthSWS", 1).GetParameter(1).Value = value;
      }
    }

    public int ThresholdDepthSWS
    {
      get
      {
        return _pfsHandle.GetKeyword("ThresholdDepthSWS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ThresholdDepthSWS", 1).GetParameter(1).Value = value;
      }
    }

    public int CapacitySWS
    {
      get
      {
        return _pfsHandle.GetKeyword("CapacitySWS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("CapacitySWS", 1).GetParameter(1).Value = value;
      }
    }

    public int ScreenBottomDepthSWS
    {
      get
      {
        return _pfsHandle.GetKeyword("ScreenBottomDepthSWS", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ScreenBottomDepthSWS", 1).GetParameter(1).Value = value;
      }
    }

    public int CapacityES
    {
      get
      {
        return _pfsHandle.GetKeyword("CapacityES", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("CapacityES", 1).GetParameter(1).Value = value;
      }
    }

    public int RS_6
    {
      get
      {
        return _pfsHandle.GetKeyword("RS_6", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("RS_6", 1).GetParameter(1).Value = value;
      }
    }

    public int RS_7
    {
      get
      {
        return _pfsHandle.GetKeyword("RS_7", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("RS_7", 1).GetParameter(1).Value = value;
      }
    }

    public int IrrigationLicenseIncluded
    {
      get
      {
        return _pfsHandle.GetKeyword("IrrigationLicenseIncluded", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("IrrigationLicenseIncluded", 1).GetParameter(1).Value = value;
      }
    }

    public int TYPE
    {
      get
      {
        return _pfsHandle.GetKeyword("TYPE", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("TYPE", 1).GetParameter(1).Value = value;
      }
    }

  }
}
