using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Better, Testable, Guessing Game!\n\n");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
        }

        public static void Results()
        {
            IsPerfectNumber(int num);


        }
    }
}
