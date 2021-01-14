using System;
using System.Collections.Generic;
using System.IO;
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
using Logic;
using Storage;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace YADUSTOCK
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Memory memory;
        private UI_Home ui_home;
        private UI_Bord ui_bord;
        private UI_Market ui_market;
        private UI_Stock ui_stock;
        private UI_Accountant ui_accountant;
		private IStorage save;
        private MediaPlayer player = new MediaPlayer();

        public Memory Memory { get => memory; set => memory = value; }
        public UI_Home Ui_home { get => ui_home; set => ui_home = value; }
        public UI_Bord Ui_bord { get => ui_bord; set => ui_bord = value; }
        public UI_Market Ui_market { get => ui_market; set => ui_market = value; }
        public UI_Stock Ui_stock { get => ui_stock; set => ui_stock = value; }
        public UI_Accountant Ui_accountant { get => ui_accountant; set => ui_accountant = value; }
		public IStorage Save { get => save; set => save = value; }
        public MediaPlayer Player { get => player; set => player = value; }

        public MainWindow()
        {
            string directory = System.IO.Path.Combine(Environment.CurrentDirectory, "DiscordRichPresence"); // en attendant de trouver comment l'inclure dans un build
            string filePath = System.IO.Path.Combine(directory, "DiscordSdk.exe");

            Process.Start(filePath);

            memory = new Memory();
            Player = new MediaPlayer();

            //Musique de fond
            if(memory.BgSoundNotRunning == false)
            {
                memory.Player = new System.Media.SoundPlayer("../../Ressources/Sounds/BG_Sound.wav");
                memory.Player.PlayLooping();
            }
            //Fin musique de fond
			Save = new JsonStorage("save.sav");

            Ui_home = new UI_Home();
            Ui_bord = new UI_Bord();
            Ui_market = new UI_Market(Memory.Market);
            Ui_stock = new UI_Stock(Memory.Stock);
            ui_accountant = new UI_Accountant(Memory.Account);
            memory.Uri = new Uri(@"../../Ressources/Sounds/button1.wav", UriKind.Relative);
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            this.Content = Ui_home;
        }

        public void NextTurn()
        {
            memory.NextTurn();
            ui_stock.Reload();
            ui_market.Reload();
            ui_accountant.Reload();
            ui_bord.Reload();
        }

        public void ButtonClickSound()
        { 
            Player.Open(memory.Uri); // chargement de l'audio
            Player.Play(); // on joue l'audio

            System.Threading.Thread.Sleep(236); // longueur de l'audio en ms
        }

        //Détecte une tentative de fermeture de la fenêtre avec ALT+F4
        private void EVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System && e.SystemKey == Key.F4 && Content != this.Ui_home)
            {
                e.Handled = true;  //Bloque l'action native de ALT+F4

                UI_ClosingWarning closingWarning = new UI_ClosingWarning();
                closingWarning.ShowDialog();
            }
            else if (e.Key == Key.System && e.SystemKey == Key.F4 && Content == this.ui_home)
            {
                // FIN DE PROCESS DISCORD SDK
                Process[] workers = Process.GetProcessesByName("DiscordSdk");
                foreach (Process worker in workers)
                {
                    worker.Kill();
                    worker.WaitForExit();
                    worker.Dispose();
                }

                Environment.Exit(0);
            }
        }

        public void ButtonHoverSound()
        {  
            Player.Open(memory.UriHover); // chargement de l'audio
            Player.Play(); // on joue l'audio
        }
    }
}
