using System;
using System.Collections.Generic;
using System.Text;

namespace Factorizor.BLL
{
    public class Perfect
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
