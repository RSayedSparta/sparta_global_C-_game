using Microsoft.Win32;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        Player newPlayer;
        LogIn win = new LogIn();
        StringBuilder sb;
        public SignUp()
        {
            InitializeComponent();
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            win.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string un = checkUsername();
            string pass = checkPassword();
            if (un != "" && pass != "")
            {
                sb = new StringBuilder(displayPic.Source.ToString());
                string path = sb.Remove(0, 8).ToString();
                newPlayer = new Player(un, pass, path);
                newPlayer.saveData();
                MessageBox.Show("You have successfully registered");
                win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter all fields");
            }
            
        }

        public string checkPassword()
        {
            string password = passSignup.Password;
            if(passSignup.Password == repassSignup.Password)
            {
                password = passSignup.Password;
            }
            else
            {
                MessageBox.Show("Please re-enter password correctly");
                password = "";
            }

            return password;
        }

        public string checkUsername()
        {
            string username = userSignup.Text;
            string[] sr = File.ReadAllLines("PlayerData.txt");
            for (int i = 0; i < sr.Length; i++)
            {
                string[] str = sr[i].Split(',');
                if (username == str[0])
                {
                    username = "";
                }
            }
            
            return username;
        }

        private void UserSignup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SelectPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select an image from your computer";
            ofd.Filter = "All Support image image|*.jpeg;*.jpg;*.png";
            if (ofd.ShowDialog() == true)
            {
                displayPic.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
    }
}
