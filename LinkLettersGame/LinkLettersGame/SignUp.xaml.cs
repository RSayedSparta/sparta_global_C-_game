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

namespace LinkLettersGame
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
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
            LogIn li = new LogIn();
            this.Close();
        }

        public string checkPassword()
        {
            string password = "";

            return password;
        }

        public string checkUsername()
        {
            string username = "";

            return username;
        }


    }
}
