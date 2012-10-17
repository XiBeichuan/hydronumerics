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

namespace Microsoft.Research.DynamicDataDisplay.Charts.Axes
{
    public class NumericAxis : AxisBase<double>
    {
        public NumericAxis()
            : base(new NumericAxisControl(),
                d => d,
                d => d)
        {
        }

#if DEBUG
        public string DebugString {
            get {
                return base.AxisControl.DebugString;
            }
        }
#endif
    }
}