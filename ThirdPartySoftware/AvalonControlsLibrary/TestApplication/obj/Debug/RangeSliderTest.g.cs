﻿#pragma checksum "..\..\RangeSliderTest.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2D1C16FE652D9046E1356E43A47974D1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4214
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AC.AvalonControlsLibrary.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplication;


namespace TestApplication {
    
    
    /// <summary>
    /// RangeSliderTest
    /// </summary>
    public partial class RangeSliderTest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\RangeSliderTest.xaml"
        internal System.Windows.Controls.TextBlock rangeSliderSelectedValue1;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\RangeSliderTest.xaml"
        internal System.Windows.Controls.TextBlock rangeSliderSelectedValue2;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\RangeSliderTest.xaml"
        internal AC.AvalonControlsLibrary.Controls.RangeSlider rangeSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestApplication;component/rangeslidertest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RangeSliderTest.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.rangeSliderSelectedValue1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.rangeSliderSelectedValue2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.rangeSlider = ((AC.AvalonControlsLibrary.Controls.RangeSlider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}