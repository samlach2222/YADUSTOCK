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
using Logic;

namespace YADUSTOCK
{
    /// <summary>
    /// Logique d'interaction pour BuyProduct.xaml
    /// </summary>
    public partial class BuyProduct : Window
    {
        private Product product;
        public BuyProduct(Product p)
        {
            product = p;
            InitializeComponent();
            TypeProduct.Content = "> " + p.Name ;
            Quantity.Text = p.QuantityToBuy.ToString();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                product.QuantityToBuy = (int)Convert.ToDouble(Quantity.Text);
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

    }
}
