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
        }

        private void SetSalePrice(object sender, RoutedEventArgs e, double price)
        {
            // A CODER, ACTION DU BOUTON A AJOUTER
        }

    }
}
