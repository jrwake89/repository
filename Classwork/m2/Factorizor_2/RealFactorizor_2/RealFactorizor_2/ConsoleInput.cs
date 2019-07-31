using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealFactorizor_2
{
    class ConsoleInput
    {
        public static int GetNum()
        {
            int num;
            Console.Clear();
            
            string input;

            while (true)
            {
                Console.Write("Enter a number: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("That was not a valid number! Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
