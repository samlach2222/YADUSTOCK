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

            ChangerResolutionFenetre();
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new
EventHandler(SystemEvents_DisplaySettingsChanged);  //Détecte un changement de résolution d'écran
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

        //Change dynamiquement la résolution si l'écran a changé
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            ChangerResolutionFenetre();
        }

        private void ChangerResolutionFenetre()
        {
            double width = System.Windows.SystemParameters.PrimaryScreenWidth / 2;
            double height = width / 5 * 4;

            if (width < 500 || height < 400)
            {
                width = 500;
                height = 400;
            }

            this.Height = height;
            this.Width = width;
        }

    }
}
