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

namespace YADUSTOCK
{
    /// <summary>
    /// Logique d'interaction pour UI_Home.xaml
    /// </summary>
    public partial class UI_Home : Page
    {
        private MediaPlayer playerSave;

        public UI_Home()
        {
            InitializeComponent();

            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;  //height = width / 16 * 9 ne fonctionne pas pour les ratios autres que 16/9
            this.Height = height;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new
EventHandler(SystemEvents_DisplaySettingsChanged);  //Détecte un changement de résolution d'écran
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            UI_Introduction ui = new UI_Introduction();
            ui.ShowDialog();

            window.Ui_bord.reload();
            window.Content = window.Ui_bord;
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            Environment.Exit(0);
        }

        private void Parameters(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            UI_Parameters popup = new UI_Parameters();
            popup.ShowDialog();
        }

        private void Button_HoverIn(object sender, MouseEventArgs e)
        {

            string uri;
            String canvasName = ((Canvas)sender).Name;  //Nom du Canvas

            if (e.LeftButton == MouseButtonState.Released)  //Sans le if, le bouton arrête de surbriller au clic
            {
                switch (canvasName)
                {
                    case "canvasPlay":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonPlayClicked.png";
                        ButtonPlay.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasParameters":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonParametersClicked.png";
                        ButtonParameters.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        
                        break;
                    case "canvasQuit":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonQuitClicked.png";
                        ButtonQuit.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                }
            }
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonHoverSound();
        }

        private void Button_HoverOut(object sender, MouseEventArgs e)
        {
            string uri;
            String canvasName = ((Canvas)sender).Name; //Nom du Canvas

            if (e.LeftButton == MouseButtonState.Released)  //Sans le if, le bouton arrête de surbriller au clic
            {
                switch (canvasName)
                {
                    case "canvasPlay":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonPlay.png";
                        ButtonPlay.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasParameters":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonParameters.png";
                        ButtonParameters.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasQuit":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonQuit.png";
                        ButtonQuit.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                }
            }
        }

        private void MuteMusic(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            string uri;

            if (window.Memory.BgSoundNotRunning == false) // Si la musique est présente
            {
                window.Memory.Player.Stop();
                window.Memory.BgSoundNotRunning = true; // elle ne l'es plus

                uri = @"pack://application:,,,/Ressources/Buttons/ButtonExitClicked.png";
                ButtonMuteMusic.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
            }
            else // si la musique est absente
            {
                window.Memory.Player.PlayLooping();
                window.Memory.BgSoundNotRunning = false; // elle devient présente

                uri = @"pack://application:,,,/Ressources/Buttons/ButtonExit.png";
                ButtonMuteMusic.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
            }
            

        }

        private void MuteEffects(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();

            string uri;

            if (window.Memory.Uri != null)
            {
                window.Memory.UriSave = window.Memory.Uri;
                window.Memory.Uri = null;
            }
            else
            {
                window.Memory.Uri = window.Memory.UriSave;
            }


            if (window.Memory.UriHover != null)
            {
                window.Memory.UriHoverSave = window.Memory.UriHover;
                window.Memory.UriHover = null;

                uri = @"pack://application:,,,/Ressources/Buttons/ButtonExitClicked.png";
                ButtonMuteEffects.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
            }
            else
            {
                window.Memory.UriHover = window.Memory.UriHoverSave;

                uri = @"pack://application:,,,/Ressources/Buttons/ButtonExit.png";
                ButtonMuteEffects.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
            }

            window.ButtonClickSound();
        }

        //Change dynamiquement la résolution si l'écran a changé
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = width;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;  //height = width / 16 * 9 ne fonctionne pas pour les ratios autres que 16/9
            this.Height = height;
        }
    }
}
