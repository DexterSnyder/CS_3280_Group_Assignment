﻿#pragma checksum "..\..\..\Items\wndItems.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AA92128504DE211ED15276BA0C6C04B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CS_3280_Group_Assignment.Items;
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


namespace CS_3280_Group_Assignment.Items {
    
    
    /// <summary>
    /// wndItems
    /// </summary>
    public partial class wndItems : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ItemsHeader;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditItemButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteItemButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddItemButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemCodeTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemCostTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemDescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ItemCodeLabel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ItemCostLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ItemDescriptionLabel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ItemDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/CS_3280_Group_Assignment;component/items/wnditems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Items\wndItems.xaml"
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
            this.ItemsHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.EditItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Items\wndItems.xaml"
            this.EditItemButton.Click += new System.Windows.RoutedEventHandler(this.EditItemButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Items\wndItems.xaml"
            this.DeleteItemButton.Click += new System.Windows.RoutedEventHandler(this.DeleteItemButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Items\wndItems.xaml"
            this.AddItemButton.Click += new System.Windows.RoutedEventHandler(this.AddNewItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ItemCodeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ItemCostTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ItemDescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ItemCodeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.ItemCostLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ItemDescriptionLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Items\wndItems.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ItemDataGrid = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

