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
    /// Interaction logic for LeaderPage.xaml
    /// </summary>
    public partial class LeaderPage : Window
    {
        string[] sr;
        public LeaderPage()
        {
            InitializeComponent();
            sr = File.ReadAllLines("PlayerData.txt");
            displayLeaderBoared();
        }

        public void displayLeaderBoared()
        {
            for (int i = 0; i < sr.Length; i++)
            {
                string[] str = sr[i].Split(',');
                if(str[5] != "0")
                {
                    displayInfo.Content +=  str[0] + "\n";

                    displayInfoLvl.Content += str[3] + "\n";

                    displayInfoPoints.Content += str[4] + "\n";

                    displayInfoTime.Content += str[5] + "\n";

                }
                
            }
        }
    }
}
