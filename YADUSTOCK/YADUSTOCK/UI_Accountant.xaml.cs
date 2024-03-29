﻿using Logic;
using System;
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
using System.Windows.Shapes;

namespace YADUSTOCK
{
    /// <summary>
    /// Logique d'interaction pour UI_Accountant.xaml
    /// </summary>
    public partial class UI_Accountant : Page
    {
        private Account a;

        public Account A { get => a; set => a = value; }

        public UI_Accountant(Account a)
        {
            this.a = a;
            InitializeComponent();

            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;  //height = width / 16 * 9 ne fonctionne pas pour les ratios autres que 16/9
            this.Height = height;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new
EventHandler(SystemEvents_DisplaySettingsChanged);  //Détecte un changement de résolution d'écran

            this.Reload();
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

        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Ui_bord.Reload();
            window.Content = window.Ui_bord;
        }

        private void PurchaseBoost(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            TypeBoost word = (TypeBoost) Enum.Parse(typeof(TypeBoost), LB_Boost.SelectedItems[0].ToString().Split(' ')[0], true);
            window.ButtonClickSound();
            if (word is TypeBoost b)
            {

                window.Memory.PurchaceBoost(b);
                
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            UI_ClosingWarning closingWarning = new UI_ClosingWarning();
            closingWarning.ShowDialog();
            //Environment.Exit(0);
        }

        public void Reload()
        {
            string BuyBoostBox = "{0, -47}{1, 0}";
            string MoneyBox = "{0, -27}{1, 0}";
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Memory Memory = w.Memory;
            this.nbTour.Text = "Round : " + Memory.NbTour;
            this.nbMoney.Text = ""+(int)a.Own;
            this.LV_Money.Items.Clear();
            this.LB_OurBoost.Items.Clear();
            this.LB_Boost.Items.Clear();

            this.LV_Money.Items.Add(string.Format(MoneyBox, "Money :", a.Own + " €"));
            foreach(Boost b in Memory.Account.BoostList)
            {
                this.LB_Boost.Items.Add(string.Format(BuyBoostBox, b.Name, b.Price + "€"));
                if (b.Etat == true)
                {
                    this.LB_OurBoost.Items.Add(b.Name);
                }
            }
        }

        private void Button_HoverIn(object sender, MouseEventArgs e)
        {

            string uri;
            String canvasName = ((Canvas)sender).Name;  //Nom du Canvas

            if (e.LeftButton == MouseButtonState.Released)  //Sans le if, le bouton arrête de surbriller au clic
            {
                switch (canvasName)
                {
                    case "canvasValidate":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonValidateClicked.png";
                        ButtonValidate.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasHome":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonHomeClicked.png";
                        HomeButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasStock":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonStockClicked.png";
                        StockButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasMarket":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonMarketClicked.png";
                        MarketButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasAccount":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonAccountClicked.png";
                        AccountButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasExit":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonExitClicked.png";
                        ExitButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                }
            }

            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonHoverSound();

        }

        private void Button_HoverOut(object sender, MouseEventArgs e)
        {
            string uri;
            String canvasName = ((Canvas)sender).Name; //Nom du Canvas

            if (e.LeftButton == MouseButtonState.Released)  //Sans le if, le bouton arrête de surbriller au clic
            {
                switch (canvasName)
                {
                    case "canvasValidate":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonValidate.png";
                        ButtonValidate.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasHome":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonHome.png";
                        HomeButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasStock":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonStock.png";
                        StockButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasMarket":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonMarket.png";
                        MarketButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasAccount":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonAccount.png";
                        AccountButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasExit":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonExit.png";
                        ExitButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                }
            }
        }

        //Change dynamiquement la résolution si l'écran a changé
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;  //height = width / 16 * 9 ne fonctionne pas pour les ratios autres que 16/9
            this.Height = height;
        }
    }
}
