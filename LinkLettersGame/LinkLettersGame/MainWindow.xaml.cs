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

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ILevel, IEasy
    {
        List<string> words = new List<string>();
        string playerInput = "";
        public MainWindow()
        {
            InitializeComponent();
            words.Add("not");
            words.Add("nut");
            words.Add("unto");
            words.Add("ton");
            words.Add("out");
        }

        public void selectLetter(RoutedEventArgs e)
        {
            if (playerInput.Length < 5)
            {
                Button letter = (Button)e.Source;
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
            if (playerInput.ToLower() == "t")
            {
                btnT.IsEnabled = false;
            }
            else
            {
                btnT.IsEnabled = true;
            }
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

            if (words[0] == "")
            {

            }

        }

        public void removeWord()
        {
            foreach (var item in words)
            {
                if (item == playerInput.ToLower())
                {
                    words.Remove(item);
                    clearAll();
                }
                break;
            }
        }

        public void timer()
        {

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
    }
}
