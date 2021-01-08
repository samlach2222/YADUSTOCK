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
            window.player.Stop();
            window.player = new System.Media.SoundPlayer("../../Ressources/Sounds/BG_Sound.wav");
            window.player.PlayLooping();
        }

        private void ChangeToMusic2(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.player.Stop();
            window.player = new System.Media.SoundPlayer("../../Ressources/Sounds/BG_SoundAlternative.wav");
            window.player.PlayLooping();
        }

        private void ChangeToClic1(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.Uri = new Uri(@"../../Ressources/Sounds/button1.wav", UriKind.Relative);
            window.ButtonClickSound();
        }

        private void ChangeToClic2(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.Uri = new Uri(@"../../Ressources/Sounds/button2.wav", UriKind.Relative);
            window.ButtonClickSound();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            // TODO
        }

        private void load(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            //TODO
        }

        private void validate(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            this.Close();
        }
    }
}
