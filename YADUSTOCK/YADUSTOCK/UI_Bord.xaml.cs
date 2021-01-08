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
            this.LB_ResultsLastRound.Items.Add("Benefit  :  " + (0) + "€");
            this.LB_ResultsLastRound.Items.Add("Pokemon Cards sold  :  " + (0));
            this.LB_DecisionsCurrentTurn.Items.Add("Pokemon Cards buying  :  " + (0));

            /*
            this.LV_Money.Items.Clear();
            this.LV_Money.Items.Add("Money :" + a.Own);
            this.LV_Money.Items.Add("Debt : ?");
            foreach (Boost b in Memory.Account.BoostList)
            {
                this.LB_Boost.Items.Add(b.Name + "   " + b.Price + "  €");

            }

            foreach (Boost b in Memory.Account.BoostList)
            {
                if (b.Etat == true)
                {
                    this.LB_OurBoost.Items.Add(b.Name);
                }

            }
            */
        }
    }
}
