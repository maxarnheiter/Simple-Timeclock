﻿#pragma checksum "..\..\PTOWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5B72B04692A31046B2B7618361CDDD9C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace SimpleTimeClock {
    
    
    /// <summary>
    /// PTOWindow
    /// </summary>
    public partial class PTOWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SimpleTimeClock.PTOWindow pto_window;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox employee_listbox;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox year_combobox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_button;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button remove_button;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close_button;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox month_combobox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\PTOWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pto_label;
        
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
            System.Uri resourceLocater = new System.Uri("/SimpleTimeClock;component/ptowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PTOWindow.xaml"
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
            this.pto_window = ((SimpleTimeClock.PTOWindow)(target));
            
            #line 4 "..\..\PTOWindow.xaml"
            this.pto_window.Loaded += new System.Windows.RoutedEventHandler(this.pto_window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.employee_listbox = ((System.Windows.Controls.ListBox)(target));
            
            #line 6 "..\..\PTOWindow.xaml"
            this.employee_listbox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.employee_listbox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.year_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 7 "..\..\PTOWindow.xaml"
            this.year_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.year_combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.add_button = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\PTOWindow.xaml"
            this.add_button.Click += new System.Windows.RoutedEventHandler(this.add_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.remove_button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\PTOWindow.xaml"
            this.remove_button.Click += new System.Windows.RoutedEventHandler(this.remove_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.close_button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\PTOWindow.xaml"
            this.close_button.Click += new System.Windows.RoutedEventHandler(this.close_button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.month_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\PTOWindow.xaml"
            this.month_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.month_combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.pto_label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
