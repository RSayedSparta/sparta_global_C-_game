using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Threading;
using System.IO;

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class EasyLvl : Window, ILevel, IEasy
    {
        List<string> words = new List<string>();
        string playerInput = "";
        string[] usersIndex;
        int seconds = -1;
        DispatcherTimer dispatcherTimer;
        MediaPlayer Sound1;
        MediaPlayer Sound2;
        public EasyLvl(int indexUser)
        {
            InitializeComponent();
            words.Add("not");
            words.Add("nut");
            words.Add("unto");
            words.Add("out");
            words.Add("ton");
            

            string[] sr = File.ReadAllLines("PlayerData.txt");
            usersIndex = sr[indexUser].Split(',');
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Start();
            
            
        }

        public void selectLetter(RoutedEventArgs e)
        {
            
            if (playerInput.Length < 5)
            {
                System.Windows.Controls.Button letter = (System.Windows.Controls.Button)e.Source;
                inputLable.Content += letter.Content.ToString();
                playerInput += letter.Content.ToString();
                checkWord();
            }
            else
            {
                clearAll();
            }
        }

        private void BtnT_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
 
        }

        private void BtnO_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);

        }

        private void BtnU_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);

        }

        private void BtnN_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
        }

        public void checkWord()
        {
            switch (playerInput.ToLower())
            {
                case "not":
                    removeWord();
                    displayNot();
                    break;
                case "nut":
                    removeWord();
                    displayNut();
                    break;
                case "ton":
                    removeWord();
                    displayTon();
                    break;
                case "unto":
                    removeWord();
                    displayUnto();
                    break;
                case "out":
                    removeWord();
                    displayOut();
                    break;
                default:
                    break;

            }
            if (words.Count == 0)
            {
                gameOver();
            }
        }

        int points;
        public void removeWord()
        {
            Sound1 = new MediaPlayer();
            Sound1.Open(new Uri(@"C:\Users\Tech-W70a\Engineering26\week7\sparta_global_C-_game\LinkLettersGame\LinkLettersGame\bin\Debug\check.wav"));
            Sound1.Play();
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i] == playerInput.ToLower())
                {
                    words.RemoveAt(i);
                    points++;
                    displayPoints.Content = points;
                    clearAll();
                }
                
            }
                    
        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
            timerLabel.Content = seconds;

        }



        public void displayNot()
        {
            notO.Foreground = new SolidColorBrush(Colors.Black);
            not_nutN.Foreground = new SolidColorBrush(Colors.Black);
            ton_notT.Foreground = new SolidColorBrush(Colors.Black);
        }
        
        public void displayNut()
        {
            not_nutN.Foreground = new SolidColorBrush(Colors.Black);
            nutU.Foreground = new SolidColorBrush(Colors.Black);
            nutT.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayOut()
        {
            outU.Foreground = new SolidColorBrush(Colors.Black);
            ton_outO.Foreground = new SolidColorBrush(Colors.Black);
            unto_outT.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayTon()
        {
            ton_notT.Foreground = new SolidColorBrush(Colors.Black);
            ton_outO.Foreground = new SolidColorBrush(Colors.Black);
            tonN.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayUnto()
        {
            unto_outT.Foreground = new SolidColorBrush(Colors.Black);
            untoU.Foreground = new SolidColorBrush(Colors.Black);
            untoN.Foreground = new SolidColorBrush(Colors.Black);
            untoO.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void setPlayerScore()
        {
            usersIndex[3] = "Easy";
            usersIndex[4] = displayPoints.Content.ToString();
            usersIndex[5] = timerLabel.Content.ToString();
            usersIndex[6] += 1;
            Player pl = new Player(usersIndex[0], usersIndex[1], usersIndex[2], usersIndex[3], int.Parse(usersIndex[4]) , int.Parse(usersIndex[5]), int.Parse(usersIndex[6]));
            pl.saveData();
        }


        public void clearAll()
        {
            inputLable.Content = "";
            playerInput = "";
        }

        public void gameOver()
        {
            dispatcherTimer.Stop();
            setPlayerScore();
            Sound2 = new MediaPlayer();
            Sound2.Open(new Uri(@"C:\Users\Tech-W70a\Engineering26\week7\sparta_global_C-_game\LinkLettersGame\LinkLettersGame\bin\Debug\clap.wav"));
            Sound2.Play();
            System.Windows.MessageBox.Show("Game Over " + "\n" + "Points: " + displayPoints.Content.ToString() + " Time: " + timerLabel.Content.ToString());
            this.Close();
        }
    }
}
