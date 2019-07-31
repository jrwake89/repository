using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary2
{
    class PerfectFinder
    {
        public class perfectFinder
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
}
