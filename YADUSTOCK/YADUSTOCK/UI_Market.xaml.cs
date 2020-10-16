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
    /// Logique d'interaction pour UI_Market.xaml
    /// </summary>
    public partial class UI_Market : Window
    {
        private Market m;

        public UI_Market()
        {
            // A CODER
            InitializeComponent();
        }

        public Market M { get => m; set => m = value; }

        private void Purchace(object sender, RoutedEventArgs e)
        {
            // A CODER, ACTION DU BOUTON A AJOUTER
        }
    }
}
