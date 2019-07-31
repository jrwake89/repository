using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    class PerfectFinder
    {
        public bool IsPerfectNumber(int num)
        {
            int sum = 0;

            for (int i = 1; i < num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                }
            }

            if (sum == num)
            {
                return true;
            }
            else
                return false;
        }
    }
}
