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
    /// Logique d'interaction pour UI_Bord.xaml
    /// </summary>
    public partial class UI_Bord : Page
    {
        private List<Product> previousProducts = new List<Product>();
        private double previousMoney = 5000;
        private int previousRound = -1;

        public UI_Bord()
        {
            // A CODER
            InitializeComponent();
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;  //Requis pour le fullscreen sans problème de bordures
            this.reload();
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_bord;
            this.reload();
        }

        private void GoStock(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_stock;
            this.reload();
        }

        private void GoMarket(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_market;
            this.reload();
        }

        private void GoAccount(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_accountant;
            this.reload();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            Environment.Exit(0);
        }

        private void EndTurn(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.NextTurn();
            this.reload();
        }

        public void reload()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            Memory memory = window.Memory;
            this.nbTour.Text = "Round : " + memory.NbTour;
            this.nbMoney.Text = "" + memory.Account.Own;
            this.welcome_nbTour.Text = "Welcome on the round " + memory.NbTour;

            this.LB_ResultsLastRound.Items.Clear();
            this.LB_DecisionsCurrentTurn.Items.Clear();


            //À COMPLETER
            this.LB_ResultsLastRound.Items.Add("Benefit  :  " + (memory.Account.Own - previousMoney) + "€");
            foreach (Product p in memory.Stock.getStock)
            {
                foreach (Product pp in previousProducts)
                {
                    if (p.Name == pp.Name  && p.Quantity != pp.Quantity)
                    {
                        this.LB_ResultsLastRound.Items.Add(p.Name + "  :  " + (p.Quantity - pp.Quantity));
                    }
                }

            }

            /*
            foreach (Boost b in Memory.Account.BoostList)
            {
                if (b.Etat == true)
                {
                    this.LB_OurBoost.Items.Add(b.Name);
                }

            }
            */

            if (previousRound + 1 < memory.NbTour)
            {
                previousRound++;
                previousMoney = memory.Account.Own;

                previousProducts.Clear();
                foreach (Product p in memory.Stock.getStock)
                {
                    previousProducts.Add(p);
                }
            }
        }
    }
}
