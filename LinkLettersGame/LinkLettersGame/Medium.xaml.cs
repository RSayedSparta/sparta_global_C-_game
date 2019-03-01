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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for Medium.xaml
    /// </summary>
    public partial class Medium : Window, ILevel, IMedium
    {
        List<string> words = new List<string>();
        string playerInput = "";
        string[] usersIndex;
        int seconds = -1;
        DispatcherTimer dispatcherTimer;
        MediaPlayer Sound1;
        MediaPlayer Sound2;
        public Medium(int indexUser)
        {
            InitializeComponent();
            words.Add("thee");
            words.Add("there");
            words.Add("here");
            words.Add("tree");
            words.Add("her");
            words.Add("three");
            words.Add("the");

            string[] sr = File.ReadAllLines("PlayerData.txt");
            usersIndex = sr[indexUser].Split(',');
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Start();
        }

        public void checkWord()
        {
            switch (playerInput.ToLower())
            {
                case "the":
                    removeWord();
                    displayThe();
                    break;
                case "thee":
                    removeWord();
                    displayThee();
                    break;
                case "there":
                    removeWord();
                    displayThere();
                    break;
                case "three":
                    removeWord();
                    displayThree();
                    break;
                case "her":
                    removeWord();
                    displayHer();
                    break;
                case "here":
                    removeWord();
                    displayHere();
                    break;
                case "tree":
                    removeWord();
                    displayTree();
                    break;
                default:
                    break;

            }
            if (words.Count == 0)
            {
                gameOver();
            }
        }

        public void clearAll()
        {
            inputLable.Content = "";
            playerInput = "";
        }

        public void displayHer()
        {
            herE.Foreground = new SolidColorBrush(Colors.Black);
            her_treeR.Foreground = new SolidColorBrush(Colors.Black);
            the_herH.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayHere()
        {
            hereH.Foreground = new SolidColorBrush(Colors.Black);
            hereR.Foreground = new SolidColorBrush(Colors.Black);
            here_threeE.Foreground = new SolidColorBrush(Colors.Black);
            thee_hereE.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayThe()
        {
            theE.Foreground = new SolidColorBrush(Colors.Black);
            theT.Foreground = new SolidColorBrush(Colors.Black);
            the_herH.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayThee()
        {
            theeE.Foreground = new SolidColorBrush(Colors.Black);
            theeT.Foreground = new SolidColorBrush(Colors.Black);
            thee_hereE.Foreground = new SolidColorBrush(Colors.Black);
            there_theeH.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayThere()
        {
            there_theeH.Foreground = new SolidColorBrush(Colors.Black);
            three_thereR.Foreground = new SolidColorBrush(Colors.Black);
            thereT.Foreground = new SolidColorBrush(Colors.Black);
            thereEE.Foreground = new SolidColorBrush(Colors.Black);
            thereE.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayThree()
        {
            three_thereR.Foreground = new SolidColorBrush(Colors.Black);
            tree_threeT.Foreground = new SolidColorBrush(Colors.Black);
            threeH.Foreground = new SolidColorBrush(Colors.Black);
            threeE.Foreground = new SolidColorBrush(Colors.Black);
            here_threeE.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayTree()
        {
            tree_threeT.Foreground = new SolidColorBrush(Colors.Black);
            her_treeR.Foreground = new SolidColorBrush(Colors.Black);
            treeEE.Foreground = new SolidColorBrush(Colors.Black);
            treeE.Foreground = new SolidColorBrush(Colors.Black);
        }

        int points;
        public void removeWord()
        {
            
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i] == playerInput.ToLower())
                {
                    words.RemoveAt(i);
                    points++;
                    displayPoints.Content = points;
                    Sound1 = new MediaPlayer();
                    Sound1.Open(new Uri(@"C:\Users\Tech-W70a\Engineering26\week7\sparta_global_C-_game\LinkLettersGame\LinkLettersGame\bin\Debug\check.wav"));
                    Sound1.Play();
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

        public void selectLetter(RoutedEventArgs e)
        {
            if (playerInput.Length < 6)
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

        public void setPlayerScore()
        {
            usersIndex[3] = "Medium";
            usersIndex[4] = displayPoints.Content.ToString();
            usersIndex[5] = timerLabel.Content.ToString();
            usersIndex[6] += 1;
            Player pl = new Player(usersIndex[0], usersIndex[1], usersIndex[2], usersIndex[3], int.Parse(usersIndex[4]), int.Parse(usersIndex[5]), int.Parse(usersIndex[6]));
            pl.saveData();
        }

        public void gameOver()
        {
            dispatcherTimer.Stop();
            setPlayerScore();
            Sound2 = new MediaPlayer();
            Sound2.Open(new Uri(@"C:\Users\Tech-W70a\Engineering26\week7\sparta_global_C-_game\LinkLettersGame\LinkLettersGame\bin\Debug\clap.wav"));
            Sound2.Play();
            MessageBox.Show("Game Over " + "\n" + "Points: " + displayPoints.Content.ToString() + " Time: " + timerLabel.Content.ToString());
            this.Close();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
        }
    }
}
