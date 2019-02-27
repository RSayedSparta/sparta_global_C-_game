using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinkLettersGame
{
    interface ILevel
    {
        void selectLetter(RoutedEventArgs e);

        void checkWord();

        void removeWord();

        void clearAll();

        void setPlayerScore();
    }
}
