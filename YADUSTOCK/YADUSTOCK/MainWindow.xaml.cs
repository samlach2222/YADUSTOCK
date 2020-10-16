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
            // A CODER
            InitializeComponent();
        }

        public void initialize()
        {
            // A CODER
        }

        private void NextTurn(object sender, RoutedEventArgs e)
        {
            // A CODER, ACTION DU BOUTON A AJOUTER
        }
    }
}
