using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string stri = "";

            for(int i = 0; i < n; i++)
            {
                stri = stri + str;
            }

            return stri;
        }

        public string FrontTimes(string str, int n)
        {
            int length = str.Length;
            string newString = "";
            if (length > 2)
            {
                str = str.Substring(0, 3);
            }

            for(int i = 0; i < n; i++)
            {
                newString = newString + str;
            }

            return newString;
            
        }

        public int CountXX(string str)
        {
            int xCount = 0;
            int length = str.Length-1;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x' )
                {
                    xCount++;
                }
            }
            return xCount;
        }

        public bool DoubleX(string str)
        {
            int length = str.Length - 1;
            bool twoX = false;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x')
                {
                    twoX = true;
                }
                else if (str[i] == 'x')
                {
                    break;
                }
            }

            return twoX;
        }

        public string EveryOther(string str)
        {
            int length = str.Length;
            string newStr = "";

            for(int i = 0; i<length; i ++)
            {
                if((i+2) % 2 == 0)
                {
                    newStr = newStr + str[i];
                }
            }

            return newStr;
        }

        public string StringSplosion(string str)
        {
            int length = str.Length;
            string newStr = "";

            for (int i = 0; i < length; i++)
            {
                    newStr = newStr + str.Substring(0, i);
            }

            newStr = newStr + str;

            return newStr;
        }

        public int CountLast2(string str)
        {
            int length = str.Length;
            int amountCount = 0;
            char secondLast = str[length-2];
            char last = str[length - 1];

            for (int i = 0; i < length-2; i++)
            {
                if (str[i] == secondLast && str[i + 1] == last)
                {
                    amountCount++;
                }
            }

            return amountCount;
        }

        public int Count9(int[] numbers)
        {
            int length = numbers.Length;
            int nine = 0;

            for (int i = 0; i < length; i++)
            {
                if (numbers[i] == 9)
                {
                    nine++;
                }
            }

            return nine;
        }

        public bool ArrayFront9(int[] numbers)
        {
            int length = numbers.Length;
            bool nine = false;

            for (int i = 0; i < length; i++)
            {
                if (i < 4)
                {
                    if (numbers[i] == 9)
                    {
                        nine = true;
                    }
                }
            }

            return nine;
        }

        public bool Array123(int[] numbers)
        {
            bool onetwoThree = false;
            bool one = false;
            bool two = false;
            bool three = false;
            int length = numbers.Length;

            for (int i = 0; i < length; i++)
            {
                    if (numbers[i] == 1)
                    {
                        one = true;
                    }
                    else if(numbers[i] == 2)
                    {
                        two = true;
                    }
                    else if(numbers[i] == 3)
                        {
                        three = true;
                        }
            }

            if (one == true && two == true && three == true)
            {
                onetwoThree = true;
            }

            return onetwoThree;
        }

        public int SubStringMatch(string a, string b)
        {
        
                int xCount = 0;
                int length = (b.Length - 1);

                for (int i = 0; i <= length-1; i++)
                {
                    if (a.Substring(i, 2) == b.Substring(i, 2))
                    {
                        xCount++;
                    }
                }
                return xCount;
        }

        public string StringX(string str)
        {
            int length = str.Length-1;
            string newString = str.Remove(0, 1);
            string returnString = newString.Remove(length-1, 1);
            int newLength = (returnString.Length);

            for(int i = 0; i <= newLength-1; i++)
            {
                if (returnString[i] == 'x')
                {
                    returnString = returnString.Remove(i, 1);
                    newLength = newLength - 1;
                    i = i - 1;
                }
            }
           
            return str.Substring(0, 1) + returnString + str.Substring(length, 1);
        }

        public string AltPairs(string str)
        {
            int length = str.Length - 1;
            string newStr = "";

            for(int i = 0; i <= length; i++)
            {
                newStr = newStr + str[i];

                    if ((i + 1) <= length)
                    {
                        newStr = newStr + str[i + 1];
                    }
                i = i + 3;
            }

            return newStr;
        }

        public string DoNotYak(string str)
        {
            int length = str.Length-3;

            for(int i = 0; i <= length; i++)
            {
                if(str[i] == 'y' && str[i+2] == 'k')
                {
                    str = str.Remove(i, 3);
                    break;
                }
            }

            return str;
        }

        public int Array667(int[] numbers)
        {
            int length = numbers.Length - 1;
            int counter = 0;

            for (int i = 0; i < length; i++)
            {
                if (numbers[i] == 6 && (numbers[i+1] == 6 || numbers[i + 1] == 7))
                {
                    counter++;
                }
            }

            return counter;
        }

        public bool NoTriples(int[] numbers)
        {
            int length = numbers.Length - 1;
            bool triple = true;

            for(int i = 0; i <length-2; i++)
            {
                if(numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                {
                    triple = false;
                }
            }

            return triple;
        }

        public bool Pattern51(int[] numbers)
        {
            int length = numbers.Length - 1;
            bool pattern = false;

            for (int i = 0; i < length-1; i++)
            {
                if(numbers[i]+5 == (numbers[i+1]) && numbers[i]-1 == (numbers[i+2]))
                {
                    pattern = true;
                    break;
                }
            }

            return pattern;
        }

    }
}
