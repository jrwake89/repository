using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the BATTLESHIP!\n\n");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
        }
    }
}
