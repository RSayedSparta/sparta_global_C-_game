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
    public partial class MainWindow : Window
    {
        string[] words = {"not", "nut", "unto", "ton", "out"};
        public MainWindow()
        {
            InitializeComponent();
        }

        public void selectLetter(RoutedEventArgs e)
        {
                String letter = e.Source.ToString();
                inputLable.Content = letter;
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
            inputLable.Content = "";
        }
    }
}
