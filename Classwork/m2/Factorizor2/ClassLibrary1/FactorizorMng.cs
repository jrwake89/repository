using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    class FactorFinder
    {

        public int[] GetFactors(int num)
        {
            int j = 0;
            int[] numbers = new int[j];

            for (int i = 1; i <= num; i++)
            {

                if (i % num == 0)
                {
                    j++;
                    numbers[j] = i;
                }
            }

            return numbers;
        }

    }
}

