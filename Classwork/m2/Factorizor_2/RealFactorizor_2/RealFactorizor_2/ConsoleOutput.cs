using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace RealFactorizor_2
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

        public static void ProcessNumber()
        {
            int num = ConsoleInput.GetNum();
            Prime Prime = new Prime();
            Factor Factor = new Factor();
            Perfect Perfect = new Perfect();

            bool ifPrime = Prime.GetPrime(num);
            bool ifPerfect = Perfect.IsPerfectNumber(num);
            int[] numbers = Factor.GetFactors(num);

            if (ifPrime == true)
            {
                Console.Write("{0} is a prime number\n\n", num);
            }
            else
            {
                Console.Write("{0} is not a prime number\n\n", num);
            }

            if (ifPerfect == true)
            {
                Console.Write("{0} is a perfect number\n\n", num);
            }
            else
            {
                Console.Write("{0} is not a perfect number\n\n", num);
            }
            int j = numbers.Length;

            for (int i = 0; i < j; i++)
            {
                Console.Write("{0},", numbers[i]);
            }
                Console.Write(" are the factors of {0}\n\n", num);
        }
    }
}
