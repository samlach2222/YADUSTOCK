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
    /// Logique d'interaction pour UI_Introduction.xaml
    /// </summary>
    public partial class UI_Introduction : Window
    {
        public UI_Introduction()
        {
            InitializeComponent();
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
