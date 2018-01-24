﻿#pragma checksum "..\..\..\GUI\CaptureWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8EA6FD3B3901145C79A13B0AFB0741D1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Imagio.Converter;
using Imagio.GUI.Controls;
using MahApps.Metro.Controls;
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
using System.Windows.Shell;


namespace Imagio.GUI {
    
    
    /// <summary>
    /// CaptureWindow
    /// </summary>
    public partial class CaptureWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas MapCanvas;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform MapCanvasScaleTransform;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Imagio.GUI.Controls.GridCanvas GridCanvas;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform GridCanvasScaleTransform;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtDistance;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtDegrees;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtStatus;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar prog;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSmartFilter;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdStartup;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Status;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\GUI\CaptureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAccept;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Imagio;component/gui/capturewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\CaptureWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.MapCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.MapCanvasScaleTransform = ((System.Windows.Media.ScaleTransform)(target));
            return;
            case 4:
            this.GridCanvas = ((Imagio.GUI.Controls.GridCanvas)(target));
            return;
            case 5:
            this.GridCanvasScaleTransform = ((System.Windows.Media.ScaleTransform)(target));
            return;
            case 6:
            this.txtDistance = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtDegrees = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txtStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.prog = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 10:
            this.btnSmartFilter = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\GUI\CaptureWindow.xaml"
            this.btnSmartFilter.Click += new System.Windows.RoutedEventHandler(this.btnSmartFilter_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.GrdStartup = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.Status = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.btnAccept = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\GUI\CaptureWindow.xaml"
            this.btnAccept.Click += new System.Windows.RoutedEventHandler(this.btnAccept_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

