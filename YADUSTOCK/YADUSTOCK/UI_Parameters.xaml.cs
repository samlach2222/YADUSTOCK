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
            if(window.Memory.BgSoundNotRunning == false)
            {
                window.Memory.Player.PlayLooping();
            }
            
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

        private void Button_HoverIn(object sender, MouseEventArgs e)
        {

            string uri;
            String canvasName = ((Canvas)sender).Name;  //Nom du Canvas

            if (e.LeftButton == MouseButtonState.Released)  //Sans le if, le bouton arrête de surbriller au clic
            {
                switch (canvasName)
                {
                    case "canvasValidate":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonValidateClicked.png";
                        ButtonValidate.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasMusic1":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonMusic1Clicked.png";
                        ButtonMusic1.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasMusic2":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonMusic2Clicked.png";
                        ButtonMusic2.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasClic1":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonClic1Clicked.png";
                        ButtonClic1.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasClic2":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonClic2Clicked.png";
                        ButtonClic2.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasSave":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonSaveClicked.png";
                        ButtonSave.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasLoad":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonLoadClicked.png";
                        ButtonLoad.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
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
                    case "canvasValidate":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonValidate.png";
                        ButtonValidate.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasMusic1":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonMusic1.png";
                        ButtonMusic1.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasMusic2":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonMusic2.png";
                        ButtonMusic2.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasClic1":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonClic1.png";
                        ButtonClic1.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasClic2":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonClic2.png";
                        ButtonClic2.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasSave":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonSave.png";
                        ButtonSave.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasLoad":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonLoad.png";
                        ButtonLoad.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                }
            }
        }
    }
}
