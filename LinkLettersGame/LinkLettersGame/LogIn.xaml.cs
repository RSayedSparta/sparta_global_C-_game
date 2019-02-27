﻿using System;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        Player pl;
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

            Home hm = new Home(this);
            hm.Show();
            this.Close();
        }

        private void UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void checkLoginDetails()
        {

        }
    }
}
