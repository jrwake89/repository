using System;
using System.Collections.Generic;
using System.Text;

namespace Factorizor.BLL
{
    public class Factor
    {

        public int[] GetFactors(int num)
        {
            int j = 0;
            
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {                    
                    j++;
                }
            }

            int[] numbers = new int[j];
            j = 0;

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    numbers[j] = i;
                    j++;
                }
            }

            string number = string.Join("", numbers);

            return numbers;
           
        }
    }
}
