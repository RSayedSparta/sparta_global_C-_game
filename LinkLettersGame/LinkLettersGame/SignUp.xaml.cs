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
        public SignUp()
        {
            InitializeComponent();
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            LogIn win = new LogIn();
            win.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string un = checkPassword();
            string pass = checkPassword();
            string path = "";

            if (un != "" && pass != "" && path != "")
            {
                newPlayer = new Player(un, pass, path);
                newPlayer.saveData();
                LogIn li = new LogIn();
                this.Close();
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
            }

            return password;
        }

        public string checkUsername()
        {
            string username = userSignup.Text;
            string[] sr = File.ReadAllLines("UserData.txt");
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
    }
}
