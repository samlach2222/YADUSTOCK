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
    /// Logique d'interaction pour UI_Parameters.xaml
    /// </summary>
    public partial class UI_Parameters : Window
    {
        public UI_Parameters()
        {
            InitializeComponent();
        }

        private void ChangeToMusic1(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Memory.Player.Stop();
            window.Memory.Player = new System.Media.SoundPlayer("../../Ressources/Sounds/BG_Sound.wav");
            window.Memory.Player.PlayLooping();
        }

        private void ChangeToMusic2(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Memory.Player.Stop();
            window.Memory.Player = new System.Media.SoundPlayer("../../Ressources/Sounds/BG_SoundAlternative.wav");
            window.Memory.Player.PlayLooping();
        }

        private void ChangeToClic1(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.Memory.Uri = new Uri(@"../../Ressources/Sounds/button1.wav", UriKind.Relative);
            window.ButtonClickSound();
        }

        private void ChangeToClic2(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.Memory.Uri = new Uri(@"../../Ressources/Sounds/button2.wav", UriKind.Relative);
            window.ButtonClickSound();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            window.Save.Save(window.Memory);
        }

        private void load(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            window.Memory = window.Save.Load();

            Memory memory = window.Memory;
            window.Ui_accountant.A = memory.Account;
            window.Ui_market.M = memory.Market;
            window.Ui_stock.S = memory.Stock;
            window.Memory.Player.Stop();
            window.Memory.Player.PlayLooping();
        }

        private void validate(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
