﻿#pragma checksum "..\..\MainWindow - Copy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "42BC61D0CDE372C4FD93519193A0CA5D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Imagio;
using Imagio.GUI.Controls;
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


namespace Imagio {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Imagio.GUI.Controls.DraggableCanvas MapCanvas;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button s_Copy;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton mtog;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button s_Copy1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton mSpace;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button s_Copy2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button douglasPeucker;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConnect;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button douglasPeucker_Copy;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button douglasPeucker_Copy1;
        
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
            System.Uri resourceLocater = new System.Uri("/Imagio;component/mainwindow%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow - Copy.xaml"
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
            this.MapCanvas = ((Imagio.GUI.Controls.DraggableCanvas)(target));
            return;
            case 2:
            this.s_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\MainWindow - Copy.xaml"
            this.s_Copy.Click += new System.Windows.RoutedEventHandler(this.buttons_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mtog = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 4:
            this.s_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MainWindow - Copy.xaml"
            this.s_Copy1.Click += new System.Windows.RoutedEventHandler(this.buttons_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mSpace = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 6:
            this.s_Copy2 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MainWindow - Copy.xaml"
            this.s_Copy2.Click += new System.Windows.RoutedEventHandler(this.Space);
            
            #line default
            #line hidden
            return;
            case 7:
            this.douglasPeucker = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainWindow - Copy.xaml"
            this.douglasPeucker.Click += new System.Windows.RoutedEventHandler(this.douglasPeucker_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnConnect = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\MainWindow - Copy.xaml"
            this.btnConnect.Click += new System.Windows.RoutedEventHandler(this.btnConnect_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.douglasPeucker_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\MainWindow - Copy.xaml"
            this.douglasPeucker_Copy.Click += new System.Windows.RoutedEventHandler(this.douglasPeuckerbox_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.douglasPeucker_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MainWindow - Copy.xaml"
            this.douglasPeucker_Copy1.Click += new System.Windows.RoutedEventHandler(this.BtnGraph);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

