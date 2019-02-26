﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window, ILevel, IEasy
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        List<string> words = new List<string>();
        string playerInput = "";
        public MainWindow()
        {
            InitializeComponent();
            words.Add("not");
            words.Add("nut");
            words.Add("unto");
            words.Add("out");
            words.Add("ton");
            
            timer();
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

        public void removeWord()
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i] == playerInput.ToLower())
                {
                    words.RemoveAt(i);
                    clearAll();
                }
                
            }
                    
                

        }

        public void timer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0,0,1);
            dispatcherTimer.Start();
        }

         public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timerLabel.Content = DateTime.Now.Second;
            CommandManager.InvalidateRequerySuggested();
                
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

        public void clearAll()
        {
            inputLable.Content = "";
            playerInput = "";
        }

        public void gameOver()
        {
            dispatcherTimer.Stop();
            System.Windows.MessageBox.Show("Game Over " + "\n" + "");
        }
    }
}
