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
    /// Logique d'interaction pour UI_ClosingWarning.xaml
    /// </summary>
    public partial class UI_ClosingWarning : Window
    {
        public UI_ClosingWarning()
        {
            InitializeComponent();

            ChangerResolutionFenetre();
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new
EventHandler(SystemEvents_DisplaySettingsChanged);  //Détecte un changement de résolution d'écran
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Save.Save(window.Memory);  //Sauvegarde automatiquement en quittant
            Environment.Exit(0);
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            window.Content = window.Ui_home;
            window.Save.Save(window.Memory);  //Sauvegarde automatiquement en quittant
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
                    case "canvasExit":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonExitClicked.png";
                        ExitButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasHome":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonHomeClicked.png";
                        HomeButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
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
                    case "canvasExit":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonExit.png";
                        ExitButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                    case "canvasHome":
                        uri = @"pack://application:,,,/Ressources/Buttons/ButtonHome.png";
                        HomeButton.ImageSource = new ImageSourceConverter().ConvertFromString(uri) as ImageSource;
                        break;
                }
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.ButtonClickSound();
            Close();
        }

        //Change dynamiquement la résolution si l'écran a changé
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            ChangerResolutionFenetre();
        }

        private void ChangerResolutionFenetre()
        {
            double width = System.Windows.SystemParameters.PrimaryScreenWidth / 2;
            double height = width / 16 * 9;

            if (width < 560 || height < 315)
            {
                width = 560;
                height = 315;
            }

            this.Height = height;
            this.Width = width;
        }
    }
    
}
