using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL.Verify
{
    public class BlankCheck
    {
        public string GetInput(string message)
        {
            bool keepGoing = false;
            string input = "";

            while (keepGoing == false)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.WriteLine("Don't just enter blanks");
                }
                else
                {
                    break;
                }
            }
            
            return input;
        }

        public int GetInputNum(string message)
        {
            bool keepGoing = false;
            string input = "";
            int output = 0;

            while (keepGoing == false)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.WriteLine("Don't just enter blanks");
                }
                else
                {
                    bool success = Int32.TryParse(input, out output);

                    if(success == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number");
                    }
                }
            }
            return output;
        }

    }
}
