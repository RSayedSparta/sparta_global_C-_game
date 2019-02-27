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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        int indexUser = 0;
        public LogIn()
        {
            InitializeComponent();
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            checkLoginDetails();
            if (indexUser != -1)
            {
                Home hm = new Home(indexUser);
                hm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password");
            }
            
        }

        private void UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void checkLoginDetails()
        {
            string user = userLogin.Text;
            string[] sr = File.ReadAllLines("PlayerData.txt");
            for (int i = 0; i < sr.Length; i++)
            {
                string[] str = sr[i].Split(',');
                if (user == str[0])
                {
                    indexUser = i;
                }
            }

            string[] usersIndex = sr[indexUser].Split(',');
            if (usersIndex[1] == null)
            {
                indexUser = -1;
            }
            
        }
    }
}
