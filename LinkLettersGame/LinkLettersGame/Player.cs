using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkLettersGame
{
    class Player
    {
        public Player()
        {

        }

        public Player(string n, string p, string pp)
        {
            name = n;
            password = p;
            picturePath = pp;
        }

        private string name;
        private string password;
        private string picturePath;
        private string level;
        private int score;
        private int time;
        private int attempt;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string PicturePath { get => picturePath; set => picturePath = value; }
        public string Level { get => level; set => level = value; }
        public int Score { get => score; set => score = value; }
        public int Time { get => time; set => time = value; }
        public int Attempt { get => attempt; set => attempt = value; }

        public void saveData()
        {
            using (StreamWriter sw = File.AppendText("PlayerData.txt"))
            {
                sw.WriteLine(name + "," + password + "," + picturePath + "," + level + "," + score + "," + time + "," + attempt);
            }
        }
    }
}
