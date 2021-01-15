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
        private List<Product> previousProductsStored;
        private List<Product> previousProductsStoredTemp;
        private List<Boost> previousBoosts;
        private List<Boost> previousBoostsTemp;
        private double previousMoney;
        private double previousMoneyTemp = 5000;
        private int previousRound = -1;
        private List<Product> previousBuyList;
        private List<Product> previousBuyListTemp;

        /// <summary>
        /// Constructeur de la page UI_Bord
        /// </summary>
        public UI_Bord()
        {
            InitializeComponent();

            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;  //height = width / 16 * 9 ne fonctionne pas pour les ratios autres que 16/9
            this.Height = height;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new
EventHandler(SystemEvents_DisplaySettingsChanged);  //Détecte un changement de résolution d'écran

            MainWindow window = (MainWindow)Application.Current.MainWindow;
            this.previousBoostsTemp = window.Memory.CreateListBoost();
            this.previousProductsStoredTemp = window.Memory.CreateListProduct();
            this.previousBuyListTemp = window.Memory.CleanListProduct();

            this.Reload();
        }

        /// <summary>
        /// Recharge la page
        /// </summary>
        /// <param name="sender">Bouton pour aller à Bord</param>
        /// <param name="e"></param>
        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_bord;
            this.Reload();
        }

        /// <summary>
        /// Emmène vers la page des stock (UI_Stock)
        /// </summary>
        /// <param name="sender">Bouton pour aller à Stock</param>
        /// <param name="e"></param>
        private void GoStock(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_stock;
        }

        /// <summary>
        /// Emmène vers la page du market (UI_Market)
        /// </summary>
        /// <param name="sender">Bouton pour aller à Market</param>
        /// <param name="e"></param>
        private void GoMarket(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_market;
        }

        /// <summary>
        /// Emmène vers la page de trésorerie (UI_Accountant)
        /// </summary>
        /// <param name="sender">Bouton pour aller à Account</param>
        /// <param name="e"></param>
        private void GoAccount(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_accountant;
        }

        /// <summary>
        /// Affiche la fenêtre de fermeture (UI_ClosingWarning)
        /// </summary>
        /// <param name="sender">Bouton pour quitter</param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            UI_ClosingWarning closingWarning = new UI_ClosingWarning();
            closingWarning.ShowDialog();
            //Environment.Exit(0);
        }

        /// <summary>
        /// Termine le tour pour passer au tour suivant
        /// </summary>
        /// <param name="sender">Bouton "END TURN"</param>
        /// <param name="e"></param>
        private void EndTurn(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.NextTurn();  //La fenêtre est reload dans la fonction NextTurn de MainWindow
            PreviousTempUpdate(window.Memory);
        }

        /// <summary>
        /// Recharge la page et met à jour les variables
        /// </summary>
        public void Reload()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            Memory memory = window.Memory;
            this.nbTour.Text = "Round : " + memory.NbTour;
            this.nbMoney.Text = "" + (int)memory.Account.Own;
            this.welcome_nbTour.Text = "Welcome on the round " + memory.NbTour;
            this.LB_ResultsLastRound.Items.Clear();
            this.LB_DecisionsCurrentTurn.Items.Clear();

            if (previousRound + 1 == memory.NbTour)  //S'il n'y a pas eu de passage au round suivant
            {
                PreviousTempUpdate(memory);
            }
            else  //S'il s'agit du round suivant
            {
                NewRound(memory);
            }

            //Results of the last round
            this.LB_ResultsLastRound.Items.Add("Benefit  :  " + (memory.Account.Own - previousMoney) + "€");
            foreach (Product p in memory.Stock.StockPlay)
            {
                foreach (Product pp in previousProductsStored)
                {
                    if (p.Name == pp.Name)
                    {
                        int vendus = p.Quantity - pp.Quantity;
                        /*
                        if (p.Quantity != pp.Quantity)  //Produits vendus
                        {
                            this.LB_ResultsLastRound.Items.Add(p.Name + " vendus  :  " + vendus);
                        }
                        */
                        foreach (Product pbl in previousBuyList)
                        {
                            if (pbl.QuantityToBuy > 0 && p.Name == pbl.Name)
                            {
                                string differenceMessage = pbl.Name + " en stock  :  ";
                                int differenceNombre = vendus + pbl.QuantityToBuy;

                                if (differenceNombre >= 0)
                                {
                                    differenceMessage += "+";
                                }
                                differenceMessage += differenceNombre;
                                this.LB_ResultsLastRound.Items.Add(differenceMessage);
                            }
                        }
                    }
                }
            }
            foreach (Boost b in memory.Account.BoostList)
            {
                foreach (Boost pb in previousBoosts)
                {
                    if (b.Name == pb.Name)
                    {
                        if (b.Etat != pb.Etat)
                        {
                            if (b.Etat == true)  //Si le boost a été acheté entre le round précédent et ce round
                            {
                                this.LB_ResultsLastRound.Items.Add(b.Name + " has been activated");
                            }
                        }
                        else if (b.TimeEnd == 0 && pb.Etat)  //Si le boost a expiré
                        {
                            this.LB_ResultsLastRound.Items.Add(b.Name + " expired");
                        }
                    }
                }
            }

            //Decisions of the current turn
            foreach (Product bl in memory.BuyList)
            {
                if (bl.QuantityToBuy > 0)
                {
                    this.LB_DecisionsCurrentTurn.Items.Add(bl.Name + " en stock  :  +" + bl.QuantityToBuy);
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
                        else if ((b.TimeEnd - 1) == 0)  //Le boost va expiré
                        {
                            this.LB_DecisionsCurrentTurn.Items.Add(b.Name + " expire");
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Met à jour les variables previous temporaires contenant les données du round précédent avec les données actuelles
        /// </summary>
        /// <param name="memory"></param>
        private void PreviousTempUpdate(Memory memory)
        {
            previousMoneyTemp = memory.Account.Own;
            previousBuyListTemp = new List<Product>(memory.BuyList);
            previousProductsStoredTemp = new List<Product>(memory.Stock.StockPlay);
            previousBoostsTemp = new List<Boost>(memory.Account.BoostList);
        }

        /// <summary>
        /// Met à jour les variables previous avec les variables previous temporaires
        /// </summary>
        private void NewRound(Memory memory)
        {
            previousRound = memory.NbTour - 1;
            previousMoney = previousMoneyTemp;
            previousBuyList = new List<Product>(previousBuyListTemp);
            previousProductsStored = new List<Product>(previousProductsStoredTemp);
            previousBoosts = new List<Boost>(previousBoostsTemp);
        }

        /// <summary>
        /// Affiche le bouton dont le curseur est dessus en surbrillance
        /// </summary>
        /// <param name="sender">Bouton dont le curseur est dessus</param>
        /// <param name="e">Souris</param>
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

        /// <summary>
        /// Lorsque le curseur sort d'un bouton, réaffiche ce dernier sans surbrillance
        /// </summary>
        /// <param name="sender">Bouton dont le curseur est sorti</param>
        /// <param name="e">Souris</param>
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

        /// <summary>
        /// Change dynamiquement la résolution si l'écran a changé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;  //height = width / 16 * 9 ne fonctionne pas pour les ratios autres que 16/9
            this.Height = height;
        }
    }
}
