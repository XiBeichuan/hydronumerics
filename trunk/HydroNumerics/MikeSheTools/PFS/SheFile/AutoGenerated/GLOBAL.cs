using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;

namespace HydroNumerics.MikeSheTools.PFS.SheFile
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class GLOBAL: PFSMapper
  {

    private DFS_2D_DATA_FILE _tIME_SERIES_FILE;

    internal GLOBAL(PFSSection Section)
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

    public int FIXED_VALUE
    {
      get
      {
        return _pfsHandle.GetKeyword("FIXED_VALUE", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("FIXED_VALUE", 1).GetParameter(1).Value = value;
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