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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Memory memory;
        private UI_Home ui_home;
        private UI_Bord ui_bord;
        private UI_Market ui_market;
        private UI_Stock ui_stock;
        private UI_Accountant ui_accountant;

        public MainWindow()
        {
<<<<<<< Updated upstream
            memory = new Memory();
            ui_home = new UI_Home();
            ui_bord = new UI_Bord();
            ui_market = new UI_Market(memory.Market);
            ui_stock = new UI_Stock(memory.Stock);
            ui_accountant = new UI_Accountant(memory.Account);
=======
            // A CODER
            UI_Introduction ui_Introduction = new UI_Introduction();
            ui_Introduction.ShowDialog();

>>>>>>> Stashed changes
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            this.Content = ui_home;
        }

        private void NextTurn(object sender, RoutedEventArgs e)
        {
            // A CODER, ACTION DU BOUTON A AJOUTER
        }
    }
}
