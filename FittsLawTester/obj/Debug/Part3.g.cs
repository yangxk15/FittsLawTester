﻿#pragma checksum "..\..\Part3.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8FF944A6F4DA2C7F59CCE604E87ABC24"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FittsLawTester;
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


namespace FittsLawTester {
    
    
    /// <summary>
    /// Part3
    /// </summary>
    public partial class Part3 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Trial;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Time;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Target;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Previous;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Part3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line line;
        
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
            System.Uri resourceLocater = new System.Uri("/FittsLawTester;component/part3.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Part3.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.Trial = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Time = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Start = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Target = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Previous = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Part3.xaml"
            this.Previous.Click += new System.Windows.RoutedEventHandler(this.Previous_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Next = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Part3.xaml"
            this.Next.Click += new System.Windows.RoutedEventHandler(this.Next_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.line = ((System.Windows.Shapes.Line)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

