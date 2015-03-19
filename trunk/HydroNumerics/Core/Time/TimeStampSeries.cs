﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using HydroNumerics.Core;

namespace HydroNumerics.Core.Time
{
  [DataContract]
  public class TimeStampSeries:BaseTimeSeries<TimeStampValue>
  {

    #region Constructors

    public TimeStampSeries():base(new Func<TimeStampValue, double>(T => T.Value))
    {
    }

    public TimeStampSeries(IEnumerable<TimeStampValue> Values)
      : base(Values, new Func<TimeStampValue, double>(T => T.Value))
    {
      if (Items.Count > 1)
        TimeStepSize = TSTools.GetTimeStep(Items[0].Time, Items[1].Time);
      else
        TimeStepSize = TimeStepUnit.None;
    }

    #endregion

    public void GapFill(InterpolationMethods Method)
    {
      if (this.TimeStepSize == TimeStepUnit.None)
        throw new Exception("Cannot GapFill when the timestep unit is not set");

      List<int> Xvalues = new List<int>();
      List<double> Yvalues = new List<double>();
      Xvalues.Add(0);
      Yvalues.Add(Items.First().Value);
      int counter = 0;

      for (int i = 1; i < Items.Count; i++)
      {
        DateTime next =Items[i - 1].Time;
        while ( (next= TSTools.GetNextTime(next, this.TimeStepSize)) <= Items[i].Time)
        {
          counter++;
        }


        Yvalues.Add(Items[i].Value);
        Xvalues.Add(counter);

      }

      if (Method == InterpolationMethods.DeleteValue)
      {
        for (int i = 1; i < Yvalues.Count; i++)
        {
          for (int j = Xvalues[i - 1]+1; j < Xvalues[i]; j++)
            Items.Insert(j, new TimeStampValue(TSTools.GetNextTime(Items[j - 1].Time, this.TimeStepSize), DeleteValue));
        }
      }
      else
        throw new Exception("Not implemented yet");
    }


    /// <summary>
    /// Gets the value at a specified time
    /// Currently only returns the first value at a given date
    /// </summary>
    /// <param name="Time"></param>
    /// <param name="interpolate"></param>
    /// <returns></returns>
    public double GetValue(DateTime Time, InterpolationMethods interpolate)
    {
      double value= DeleteValue;
      int index;
      if (DateIndex.TryGetValue(Time.Date, out index))
      {
        while (index < Count-2 && Items[index + 1].Time <= Time )
          index++;
      }
        switch (interpolate)
        {
          case InterpolationMethods.Linear:
            break;
          case InterpolationMethods.CubicSpline:
            break;
          case InterpolationMethods.DeleteValue:
            if (index < Count)
              if (Items[index].Time == Time) //Time has to be correct
                value = Items[index].Value;
            break;
          case InterpolationMethods.Nearest:
            break;
          default:
            break;
        }
      return value;
    }



    /// <summary>
    /// Gets the time of the first entry
    /// </summary>
    public DateTime StartTime
    {
      get
      {
        if (Items.Count == 0)
          return DateTime.MinValue;
        return Items.First().Time;
      }
    }

    /// <summary>
    /// Gets the time of the last entry
    /// </summary>
    public DateTime EndTime
    {
      get
      {
        if (Items.Count == 0)
          return DateTime.MinValue;
        return Items.Last().Time;
      }
    }


    private Dictionary<DateTime, int> dateIndex;

    private Dictionary<DateTime, int> DateIndex
    {
      get
      {
        if (dateIndex == null)
        {
          dateIndex = new Dictionary<DateTime, int>();
          for (int i = 0; i < Items.Count; i++)
          {
            if (!dateIndex.ContainsKey(Items[i].Time.Date))
              dateIndex.Add(Items[i].Time.Date, i);
          }
        }
        return dateIndex;
      }
    }

  }
}
