using Logic;
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
    /// Logique d'interaction pour UI_Stock.xaml
    /// </summary>
    public partial class UI_Stock : Page
    {
        private Stock s;

        public Stock S { get => s; set => s = value; }

        public UI_Stock(Stock s)
        {
            // A CODER
            InitializeComponent();
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;  //Requis pour le fullscreen sans problème de bordures
            ListBox stockList = new ListBox();
            stockList.Items.Add("GeeksForGeeks");
            this.reload();
        }

        private void SetSalePrice(object sender, MouseButtonEventArgs e)
        {
            TypeProduct word = (TypeProduct)Enum.Parse(typeof(TypeProduct), LB_Stock.SelectedItems[0].ToString().Split(' ')[0], true);
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Memory Memory = w.Memory;

            foreach (Product p in Memory.Stock.StockPlay)
            {
                if (p.Name == word)
                {
                    SetPriceProduct sp = new SetPriceProduct(p);
                    if (sp.ShowDialog() == true)
                    {
                        this.reload();
                    }
                }
            }
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Ui_bord.reload();
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
            UI_ClosingWarning closingWarning = new UI_ClosingWarning();
            closingWarning.ShowDialog();
            //Environment.Exit(0);
        }

        public void reload()
        {
            string MarketBox = "{0, -50}{1, -35}{2, 0}";
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Memory Memory = w.Memory;
            this.nbTour.Text = "Round : " + Memory.NbTour;
            this.nbMoney.Text = "" + (int)Memory.Account.Own;
            this.LB_Stock.Items.Clear();
            foreach (Product p in Memory.Stock.StockPlay)
            {
                this.LB_Stock.Items.Add(string.Format(MarketBox, p.Name.ToString(), p.Quantity, p.ResalePrice + " €"));
            }
        }
    }
}
