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

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private int indexUser;

        public Home()
        {
            InitializeComponent();
        }

        string[] sr = File.ReadAllLines("PlayerData.txt");
        string[] usersIndex;
        public Home(int indexUser) : this()
        {
           
            this.indexUser = indexUser;
            usersIndex = sr[indexUser].Split(',');
            avatarPic.Source = new BitmapImage(new Uri(usersIndex[2]));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Medium med = new Medium(indexUser);
            med.Show();
        }

        private void EasyBtn_Click(object sender, RoutedEventArgs e)
        {
            EasyLvl win = new EasyLvl(indexUser);
            win.Show();
        }

        private void HardBtn_Click(object sender, RoutedEventArgs e)
        {
            Hard hr = new Hard(indexUser);
            hr.Show();
        }
    }
}
