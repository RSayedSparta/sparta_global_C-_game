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
using System.Windows.Forms;
using System.Windows.Threading;
using System.IO;

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for Hard.xaml
    /// </summary>
    public partial class Hard : Window, ILevel, IHard
    {
        
        List<string> words = new List<string>();
        string playerInput = "";
        int seconds = -1;
        string[] usersIndex;
        DispatcherTimer dispatcherTimer;
        MediaPlayer Sound1;
        MediaPlayer Sound2;
        public Hard(int indexUser)
        {
            InitializeComponent();
            words.Add("secure");
            words.Add("see");
            words.Add("reuse");
            words.Add("cure");
            words.Add("seer");
            words.Add("cue");
            words.Add("use");
            words.Add("sure");
            words.Add("rue");
            words.Add("rescue");
            words.Add("user");
            words.Add("curse");
            string[] sr = File.ReadAllLines("PlayerData.txt");
            usersIndex = sr[indexUser].Split(',');
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Start();
        }

        public void selectLetter(RoutedEventArgs e)
        {
            if (playerInput.Length < 7)
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

        public void checkWord()
        {
            switch (playerInput.ToLower())
            {
                case "cue":
                    removeWord();
                    displayCue();
                    break;
                case "cure":
                    removeWord();
                    displayCure();
                    break;
                case "curse":
                    removeWord();
                    displayCurse();
                    break;
                case "rescue":
                    removeWord();
                    displayRescue();
                    break;
                case "reuse":
                    removeWord();
                    displayReuse();
                    break;
                case "rue":
                    removeWord();
                    displayRue();
                    break;
                case "secure":
                    removeWord();
                    displaySecure();
                    break;
                case "see":
                    removeWord();
                    displaySee();
                    break;
                case "seer":
                    removeWord();
                    displaySeer();
                    break;
                case "sure":
                    removeWord();
                    displaySure();
                    break;
                case "use":
                    removeWord();
                    displayUse();
                    break;
                case "user":
                    removeWord();
                    displayUser();
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

        public void displayCue()
        {
            cueC.Foreground = new SolidColorBrush(Colors.Black);
            cueU.Foreground = new SolidColorBrush(Colors.Black);
            rescue_cueE.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayCure()
        {
            cureC.Foreground = new SolidColorBrush(Colors.Black);
            cureR.Foreground = new SolidColorBrush(Colors.Black);
            cure_seeE.Foreground = new SolidColorBrush(Colors.Black);
            curse_cureU.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayCurse()
        {
            curseC.Foreground = new SolidColorBrush(Colors.Black);
            curseE.Foreground = new SolidColorBrush(Colors.Black);
            curseR.Foreground = new SolidColorBrush(Colors.Black);
            curse_cureU.Foreground = new SolidColorBrush(Colors.Black);
            curse_userS.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayRescue()
        {
            rescue_cueE.Foreground = new SolidColorBrush(Colors.Black);
            rescueU.Foreground = new SolidColorBrush(Colors.Black);
            rescueC.Foreground = new SolidColorBrush(Colors.Black);
            rescueE.Foreground = new SolidColorBrush(Colors.Black);
            sure_rescueR.Foreground = new SolidColorBrush(Colors.Black);
            reuse_rescueS.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayReuse()
        {
            seer_reuseE.Foreground = new SolidColorBrush(Colors.Black);
            reuse_rescueS.Foreground = new SolidColorBrush(Colors.Black);
            reuseU.Foreground = new SolidColorBrush(Colors.Black);
            reuseR.Foreground = new SolidColorBrush(Colors.Black);
            reuseE.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayRue()
        {
            rueE.Foreground = new SolidColorBrush(Colors.Black);
            rue_useU.Foreground = new SolidColorBrush(Colors.Black);
            user_rueR.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displaySecure()
        {
            secureC.Foreground = new SolidColorBrush(Colors.Black);
            secureE.Foreground = new SolidColorBrush(Colors.Black);
            secureEE.Foreground = new SolidColorBrush(Colors.Black);
            secureR.Foreground = new SolidColorBrush(Colors.Black);
            secureS.Foreground = new SolidColorBrush(Colors.Black);
            secureU.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displaySee()
        {
            seeE.Foreground = new SolidColorBrush(Colors.Black);
            seeS.Foreground = new SolidColorBrush(Colors.Black);
            cure_seeE.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displaySeer()
        {
            seerE.Foreground = new SolidColorBrush(Colors.Black);
            seerR.Foreground = new SolidColorBrush(Colors.Black);
            seer_reuseE.Foreground = new SolidColorBrush(Colors.Black);
            sure_seerS.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displaySure()
        {
            use_sureE.Foreground = new SolidColorBrush(Colors.Black);
            sure_seerS.Foreground = new SolidColorBrush(Colors.Black);
            sure_rescueR.Foreground = new SolidColorBrush(Colors.Black);
            sureU.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayUse()
        {
            use_sureE.Foreground = new SolidColorBrush(Colors.Black);
            useS.Foreground = new SolidColorBrush(Colors.Black);
            rue_useU.Foreground = new SolidColorBrush(Colors.Black);
        }

        public void displayUser()
        {
            user_rueR.Foreground = new SolidColorBrush(Colors.Black);
            userU.Foreground = new SolidColorBrush(Colors.Black);
            userE.Foreground = new SolidColorBrush(Colors.Black);
            curse_userS.Foreground = new SolidColorBrush(Colors.Black);
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
                    Sound1.Open(new Uri(@"C:\Users\rahib\Documents\Sparta\sparta_global_C-_game\LinkLettersGame\LinkLettersGame\bin\Debug\check.wav"));
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
            timerLabel1.Content = seconds;
        }

        private void BtnN_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        private void BtnR_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        private void BtnS_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        private void BtnU_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        private void BtnE_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            selectLetter(e);
        }

        public void setPlayerScore()
        {
            usersIndex[3] = "Hard";
            usersIndex[4] = displayPoints.Content.ToString();
            usersIndex[5] = timerLabel1.Content.ToString();
            usersIndex[6] += 1;
            Player pl = new Player(usersIndex[0], usersIndex[1], usersIndex[2], usersIndex[3], int.Parse(usersIndex[4]), int.Parse(usersIndex[5]), int.Parse(usersIndex[6]));
            pl.saveData();
        }

        public void gameOver()
        {
            dispatcherTimer.Stop();
            setPlayerScore();
            Sound2 = new MediaPlayer();
            Sound2.Open(new Uri(@"C:\Users\rahib\Documents\Sparta\sparta_global_C-_game\LinkLettersGame\LinkLettersGame\bin\Debug\clap.wav"));
            Sound2.Play();
            System.Windows.MessageBox.Show("Game Over " + "\n" + "Points: " + displayPoints.Content.ToString() + " Time: " + timerLabel1.Content.ToString());
            this.Close();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
        }
    }
}
