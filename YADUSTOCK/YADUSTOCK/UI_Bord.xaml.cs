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
        private List<Boost> previousBoosts = new List<Boost>();
        private double previousMoney = 5000;
        private int previousRound = -1;
        private List<Product> currentProducts = new List<Product>();
        private List<Boost> currentBoosts = new List<Boost>();

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

            //Ajoute les données du début du round actuel aux variables "current"
            if (previousRound + 2 < memory.NbTour)
            {
                //Pas besoin d'incrémenter previousRound car il est incrémenter pour les variables "previous"

                currentProducts.Clear();
                foreach (Product p in memory.Stock.Stock1)
                {
                    currentProducts.Add(p);
                }

                currentBoosts.Clear();
                foreach (Boost b in memory.Account.BoostList)
                {
                    currentBoosts.Add(b);
                }
            }

            //Results of the last round
            this.LB_ResultsLastRound.Items.Add("Benefit  :  " + (memory.Account.Own - previousMoney) + "€");
            foreach (Product p in memory.Stock.Stock1)
            {
                foreach (Product pp in previousProducts)
                {
                    if (p.Name == pp.Name && p.Quantity != pp.Quantity)
                    {
                        this.LB_ResultsLastRound.Items.Add(p.Name + "  :  " + (p.Quantity - pp.Quantity));
                    }
                }
            }
            foreach (Boost b in memory.Account.BoostList)
            {
                foreach (Boost pb in previousBoosts)
                {
                    if (b.Name == pb.Name && b.Etat != pb.Etat)
                    {
                        if (b.Etat == true)  //Si le boost a été acheté entre le round précédent et ce round
                        {
                            this.LB_ResultsLastRound.Items.Add(b.Name + " bought");
                        } else  //Si le boost a expiré
                        {
                            this.LB_ResultsLastRound.Items.Add(b.Name + " expired");
                        }
                    }
                }
            }

            //Decisions of the current turn
            foreach (Product p in memory.Stock.Stock1)
            {
                foreach (Product cp in currentProducts)
                {
                    if (p.Name == cp.Name && p.Quantity != cp.Quantity)
                    {
                        this.LB_DecisionsCurrentTurn.Items.Add(p.Name + "  :  " + (p.Quantity - cp.Quantity));
                    }
                }

            }
            foreach (Boost b in memory.Account.BoostList)
            {
                foreach (Boost cb in currentBoosts)
                {
                    if (b.Name == cb.Name && b.Etat != cb.Etat)
                    {
                        if (b.Etat == true)  //Si le boost a été acheté entre le round précédent et ce round
                        {
                            this.LB_DecisionsCurrentTurn.Items.Add(b.Name + " is active");
                        }
                        else  //Si le boost a expiré
                        {
                            this.LB_DecisionsCurrentTurn.Items.Add(b.Name + " expired");
                        }
                    }
                }
            }

            //Ajoute les données du round précédent aux variables "previous"
            if (previousRound + 1 < memory.NbTour)
            {
                previousRound++;
                previousMoney = memory.Account.Own;

                previousProducts.Clear();
                foreach (Product p in memory.Stock.Stock1)
                {
                    previousProducts.Add(p);
                }

                previousBoosts.Clear();
                foreach (Boost b in memory.Account.BoostList)
                {
                    previousBoosts.Add(b);
                }
            }
        }
    }
}
