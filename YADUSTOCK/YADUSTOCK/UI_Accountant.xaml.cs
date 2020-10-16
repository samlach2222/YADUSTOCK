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
    /// Logique d'interaction pour UI_Accountant.xaml
    /// </summary>
    public partial class UI_Accountant : Window
    {
        private int nbTour;

        public UI_Accountant()
        {
            // A CODER
            InitializeComponent();
        }

        public int NbTour { get => nbTour; set => nbTour = value; }

        public void setAccount()
        {
            // A CODER
        }

        public void addTranslation()
        {
            // A CODER
        }
    }
}
