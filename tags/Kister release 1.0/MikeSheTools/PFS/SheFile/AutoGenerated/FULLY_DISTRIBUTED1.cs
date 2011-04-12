using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;

namespace HydroNumerics.MikeSheTools.PFS.SheFile
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class FULLY_DISTRIBUTED1: PFSMapper
  {

    private List<DFS_2D_DATA_FILE> _dFS_2D_DATA_FILEs = new List<DFS_2D_DATA_FILE>();

    internal FULLY_DISTRIBUTED1(PFSSection Section)
    {
      _pfsHandle = Section;

      for (int i = 1; i <= Section.GetSectionsNo(); i++)
      {
        PFSSection sub = Section.GetSection(i);
        switch (sub.Name)
        {
          default:
            if (sub.Name.Substring(0,6).Equals("DFS_2D"))
            {
              _dFS_2D_DATA_FILEs.Add(new DFS_2D_DATA_FILE(sub));
              break;
            }
            _unMappedSections.Add(sub.Name);
          break;
        }
      }
    }

    public List<DFS_2D_DATA_FILE> DFS_2D_DATA_FILEs
   {
     get { return _dFS_2D_DATA_FILEs; }
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