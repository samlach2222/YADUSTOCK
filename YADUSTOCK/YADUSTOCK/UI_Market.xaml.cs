﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic;

namespace YADUSTOCK
{
    /// <summary>
    /// Logique d'interaction pour UI_Market.xaml
    /// </summary>
    public partial class UI_Market : Page
    {
        private Market m;

        public UI_Market(Market m)
        {
            this.m = m;
            InitializeComponent();
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;  //Requis pour le fullscreen sans problème de bordures
        }

        public Market M { get => m; set => m = value; }

        private void Purchase(object sender, RoutedEventArgs e)
        {
            
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_bord;
        }

        private void GoStock(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_stock;
        }

        private void GoMarket(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_market;
        }

        private void GoAccount(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_accountant;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            Environment.Exit(0);
        }
    }
}
