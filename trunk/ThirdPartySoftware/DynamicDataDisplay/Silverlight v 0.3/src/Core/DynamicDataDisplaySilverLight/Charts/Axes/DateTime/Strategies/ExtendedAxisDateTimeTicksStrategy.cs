﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Research.DynamicDataDisplay.Charts
{
    public class ExtendedAxisDateTimeTicksStrategy : IDateTimeTicksStrategy
    {
        public virtual DifferenceIn GetDifference(TimeSpan span)
        {
            span = span.Duration();

            DifferenceIn diff;
            if (span.Days /5> 365)
                diff = DifferenceIn.Year;
            else if (span.Days/5 > 30)
                diff = DifferenceIn.Month;
            else if (span.Days/5 > 0)
                diff = DifferenceIn.Day;
            else if (span.Hours/5 > 0)
                diff = DifferenceIn.Hour;
            else if (span.Minutes/5 > 0)
                diff = DifferenceIn.Minute;
            else if (span.Seconds/5 > 0)
                diff = DifferenceIn.Second;
            else
                diff = DifferenceIn.Millisecond;

            return diff;
        }

        public virtual bool TryGetLowerDiff(DifferenceIn diff, out DifferenceIn lowerDiff)
        {
            lowerDiff = diff;

            int code = (int)diff;
            bool res = code > (int)DifferenceIn.Smallest;
            if (res)
            {
                lowerDiff = (DifferenceIn)(code - 1);
            }
            return res;
        }

        public virtual bool TryGetBiggerDiff(DifferenceIn diff, out DifferenceIn biggerDiff)
        {
            biggerDiff = diff;

            int code = (int)diff;
            bool res = code < (int)DifferenceIn.Biggest;
            if (res)
            {
                biggerDiff = (DifferenceIn)(code + 1);
            }
            return res;
        }
    }
}
