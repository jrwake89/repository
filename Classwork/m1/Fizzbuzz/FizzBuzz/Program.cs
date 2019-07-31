using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            //TODO:  Implement FizzBuzz

            for (int i = 1; i <= 100; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    Console.WriteLine("{0} Fizzbuzz", i);

                    continue;
                }

                if(i % 3 == 0){
                    Console.WriteLine("{0} Fizz", i);

                    continue;
                }


                if (i % 5 == 0)
                {
                    Console.WriteLine("{0} Buzz", i);

                }
                else
                    Console.WriteLine("{0}", i);
            }
        }

    }
}
