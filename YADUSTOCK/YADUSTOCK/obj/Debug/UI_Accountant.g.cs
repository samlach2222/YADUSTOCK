﻿#pragma checksum "..\..\UI_Accountant.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8DB9BF25CA0DDDE2B46BC7170AD6F97660F8FDE042818DBFC06D836C3D61F06E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using YADUSTOCK;


namespace YADUSTOCK {
    
    
    /// <summary>
    /// UI_Accountant
    /// </summary>
    public partial class UI_Accountant : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StockButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MarketButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton_Copy;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nbMoney;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nbTour;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LB_Boost;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LV_Money;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\UI_Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LB_OurBoost;
        
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
            System.Uri resourceLocater = new System.Uri("/YADUSTOCK;component/ui_accountant.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UI_Accountant.xaml"
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
            this.HomeButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\UI_Accountant.xaml"
            this.HomeButton.Click += new System.Windows.RoutedEventHandler(this.GoHome);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StockButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\UI_Accountant.xaml"
            this.StockButton.Click += new System.Windows.RoutedEventHandler(this.GoStock);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MarketButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\UI_Accountant.xaml"
            this.MarketButton.Click += new System.Windows.RoutedEventHandler(this.GoMarket);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AccountButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\UI_Accountant.xaml"
            this.AccountButton.Click += new System.Windows.RoutedEventHandler(this.GoAccount);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\UI_Accountant.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HomeButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\UI_Accountant.xaml"
            this.HomeButton_Copy.Click += new System.Windows.RoutedEventHandler(this.GoHome);
            
            #line default
            #line hidden
            return;
            case 7:
            this.nbMoney = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.nbTour = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.LB_Boost = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.LV_Money = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            this.LB_OurBoost = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

