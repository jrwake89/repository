using System;

namespace Factorizor.BLL
{
    public class PrimeFinder
    {
        public bool GetPrime(int num)
        {
            int f = 0;

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    f++;
                }
            }

            if (f == 2)
            {
                return true;
            }
            else
                return false;
        }
}
