﻿#pragma checksum "..\..\UI_Stock.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "26D5AA4A0656D90659051FE4112BCCDED31CEDD270B0530EC30A90CE1F8CA384"
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
    /// UI_Stock
    /// </summary>
    public partial class UI_Stock : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StockButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MarketButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LB_Stock;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\UI_Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/YADUSTOCK;component/ui_stock.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UI_Stock.xaml"
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
            
            #line 29 "..\..\UI_Stock.xaml"
            this.HomeButton.Click += new System.Windows.RoutedEventHandler(this.GoHome);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StockButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\UI_Stock.xaml"
            this.StockButton.Click += new System.Windows.RoutedEventHandler(this.GoStock);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MarketButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\UI_Stock.xaml"
            this.MarketButton.Click += new System.Windows.RoutedEventHandler(this.GoMarket);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AccountButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\UI_Stock.xaml"
            this.AccountButton.Click += new System.Windows.RoutedEventHandler(this.GoAccount);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\UI_Stock.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LB_Stock = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.HomeButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\UI_Stock.xaml"
            this.HomeButton_Copy.Click += new System.Windows.RoutedEventHandler(this.GoHome);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

