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

        public Memory Memory { get => memory; set => memory = value; }
        public UI_Home Ui_home { get => ui_home; set => ui_home = value; }
        public UI_Bord Ui_bord { get => ui_bord; set => ui_bord = value; }
        public UI_Market Ui_market { get => ui_market; set => ui_market = value; }
        public UI_Stock Ui_stock { get => ui_stock; set => ui_stock = value; }
        public UI_Accountant Ui_accountant { get => ui_accountant; set => ui_accountant = value; }
		public IStorage Save { get => save; set => save = value; }

        public MainWindow()
        {
            memory = new Memory();

            //Musique de fond
            memory.Player = new System.Media.SoundPlayer("../../Ressources/Sounds/BG_Sound.wav");
            memory.Player.PlayLooping();
            //Fin musique de fond
			Save = new JsonStorage("save.sav");

            Ui_home = new UI_Home();
            Ui_bord = new UI_Bord();
            Ui_market = new UI_Market(Memory.Market);
            Ui_stock = new UI_Stock(Memory.Stock);
            ui_accountant = new UI_Accountant(Memory.Account);
            memory.Uri = new Uri(@"../../Ressources/Sounds/button1.wav", UriKind.Relative);
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            this.Content = Ui_home;
        }

        public void NextTurn()
        {
            memory.NextTurn();
            ui_stock.reload();
            ui_market.reload();
            ui_accountant.reload();
            ui_bord.reload();
        }

        public void ButtonClickSound()
        {
            MediaPlayer player = new MediaPlayer(); // création du player 
            player.Open(memory.Uri); // chargement de l'audio
            player.Play(); // on joue l'audio

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
        }
    }
}
