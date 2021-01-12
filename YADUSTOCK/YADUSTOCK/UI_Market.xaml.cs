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
            this.reload();
        }

        public Market M { get => m; set => m = value; }

        private void Purchase(object sender, RoutedEventArgs e)
        {
            TypeProduct word = (TypeProduct)Enum.Parse(typeof(TypeProduct), Market.SelectedItems[0].ToString().Split(' ')[0], true);
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Memory Memory = w.Memory;

            foreach(Product p in Memory.BuyList)
            {
                if(p.Name == word)
                {
                    BuyProduct bp = new BuyProduct(p);
                    if (bp.ShowDialog() == true)
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
            string MarketBox = "{0, -29}{1, -23}{2, -21}{3, -22}{4, 0}";
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            Memory Memory = w.Memory;
            this.nbTour.Text = "Round : " + Memory.NbTour;
            this.nbMoney.Text = "" + (int)Memory.Account.Own;
            this.Market.Items.Clear();
            for(int i = 0; i < Memory.BuyList.Count(); i++)
            {
                this.Market.Items.Add(string.Format(MarketBox, Memory.BuyList[i].Name.ToString(), Memory.Stock.StockPlay[i].Quantity, Memory.BuyList[i].AtBuyPrice + " €", Memory.BuyList[i].QuantityToBuy, (Memory.BuyList[i].QuantityToBuy * Memory.BuyList[i].AtBuyPrice) + " €"));
            }
        }
    }
}
