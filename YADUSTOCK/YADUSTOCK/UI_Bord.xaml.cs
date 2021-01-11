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
        private List<Product> previousProductsStored = new List<Product>();
        private List<Product> previousProductsStoredTemp = new List<Product>();
        private List<Boost> previousBoosts = new List<Boost>();
        private List<Boost> previousBoostsTemp = new List<Boost>();
        private double previousMoney;
        private double previousMoneyTemp = 5000;
        private int previousRound = -1;
        private List<Product> previousBuyList = new List<Product>();
        private List<Product> previousBuyListTemp = new List<Product>();
        private List<Product> currentProductsStored = new List<Product>();

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

        private void EndTurn(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.NextTurn();  //La fenêtre est reload dans la fonction NextTurn de MainWindow
            previousTempUpdate(window.Memory);
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

            if (previousRound + 1 == memory.NbTour)  //S'il n'y a pas eu de passage au round suivant
            {
                previousTempUpdate(memory);
            }
            else  //S'il s'agit du round suivant
            {
                newRound(memory);
            }

            //Results of the last round
            this.LB_ResultsLastRound.Items.Add("Benefit  :  " + (memory.Account.Own - previousMoney) + "€");
            foreach (Product p in memory.Stock.Stock1)
            {
                foreach (Product pp in previousProductsStored)
                {
                    if (p.Name == pp.Name)
                    {
                        float vendus = p.Quantity - pp.Quantity;

                        if (p.Quantity != pp.Quantity)  //Produits vendus
                        {
                            this.LB_ResultsLastRound.Items.Add(p.Name + " vendus :  " + vendus);
                        }

                        foreach (Product pb in previousBuyList)
                        {
                            if (p.Name == pb.Name && p.Quantity != vendus + pb.Quantity)
                            {
                                this.LB_ResultsLastRound.Items.Add(p.Name + " en stock :  " + (vendus + pb.Quantity));
                            }
                        }
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
                            this.LB_ResultsLastRound.Items.Add(b.Name + " is active");
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
                foreach (Product cb in memory.BuyList)
                {
                    if (p.Name == cb.Name && p.Quantity != cb.Quantity)
                    {
                        this.LB_DecisionsCurrentTurn.Items.Add(p.Name + " en stock :  " + (p.Quantity + cb.Quantity));
                    }
                }
            }
            foreach (Boost b in memory.Account.BoostList)
            {
                foreach (Boost cbb in memory.BuyBoostList)
                {
                    if (b.Name == cbb.Name)
                    {
                        if (cbb.Etat == true && b.Etat != cbb.Etat)  //Si le boost a été acheté dans le round actuel
                        {
                            this.LB_DecisionsCurrentTurn.Items.Add(b.Name + " will become active");
                        }
                        else //Le boost a potentiellement expiré
                        {
                            foreach (Boost pb in previousBoosts)
                            {
                                if (b.Name == pb.Name && b.Etat != pb.Etat)
                                {
                                    if (b.Etat == false)  //Le boost a expiré
                                    {
                                        this.LB_DecisionsCurrentTurn.Items.Add(b.Name + " expire");
                                    }
                                    /*
                                    else  //Le boost a été acheté avant mais est encore actif
                                    {
                                        this.LB_DecisionsCurrentTurn.Items.Add(b.Name + " stay active");
                                    }
                                    */
                                }
                            }
                        }
                    }
                }
            }

        }

        private void previousTempUpdate(Memory memory)
        {
            previousMoneyTemp = memory.Account.Own;
            previousBuyListTemp = new List<Product>(memory.BuyList);
            previousProductsStoredTemp = new List<Product>(memory.Stock.Stock1);
            previousBoostsTemp = new List<Boost>(memory.Account.BoostList);
        }

        private void newRound(Memory memory)
        {
            //Ajoute les données du round précédent aux variables "previous"
            previousRound++;
            previousMoney = previousMoneyTemp;
            previousBuyList = new List<Product>(previousBuyListTemp);
            previousProductsStored = new List<Product>(previousProductsStoredTemp);
            previousBoosts = new List<Boost>(previousBoostsTemp);

            //Ajoute les données du début du round actuel aux variables "current"
            currentProductsStored.Clear();
            currentProductsStored = new List<Product>(memory.Stock.Stock1);
        }

        private void Button_HoverIn(object sender, MouseEventArgs e)
        {

            string uri;
            String canvasName = ((Canvas)sender).Name;  //Nom du Canvas

            if (e.LeftButton == MouseButtonState.Released)  //Sans le if, le bouton arrête de surbriller au clic
            {
                switch (canvasName)
                {
                    case "canvasEndTurn":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonEndTurnClicked.png";
                        EndTurnButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
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
                    case "canvasEndTurn":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonEndTurn.png";
                        EndTurnButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
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
    }
}
