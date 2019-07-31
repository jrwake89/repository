using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            int length = numbers.Length;
            int firstNum = numbers[0];
            int secondNum = numbers[length-1];
            if (firstNum == 6 || secondNum == 6)
            {
                return true;
            }
            else
                return false;

        }

        public bool SameFirstLast(int[] numbers)
        {
            int length = numbers.Length;
            int firstNum = numbers[0];
            int secondNum = numbers[length - 1];
            if (firstNum == secondNum)
            {
                return true;
            }
            else
                return false;
        }
        public int[] MakePi(int n)
        {
            double pi = Math.PI;
            string str = pi.ToString().Remove(1, 1);
            char[] array = str.ToCharArray();
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {

                numbers[i] = int.Parse(array[i].ToString());
            }
            return numbers;
        }

    
        
        public bool CommonEnd(int[] a, int[] b)
        {
            int lengtha = a.Length;
            int firstNuma = a[0];
            int secondNuma = a[lengtha - 1];
            int lengthb = b.Length;
            int firstNumb = b[0];
            int secondNumb = b[lengthb - 1];

            if (firstNuma == firstNumb)
            {
                return true;
            }
            else if (secondNuma == secondNumb)
            {
                return true;
            }
            else
                return false;
        }
        
        public int Sum(int[] numbers)
        {
            int length = numbers.Length;
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int length = numbers.Length;
            int[] newNumbers = new int[length];
            for(int i = 0; i < length - 1; i++)
            {
                newNumbers[i] = numbers[i+1];
            }

            newNumbers[length-1] = numbers[0];
            return newNumbers;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int length = numbers.Length;
            int[] newArray = new int[length];

            for(int i = 0; i < length-1; i++)
            {
                newArray[(length-1) - i] = numbers[i];
               
            }
            newArray[0] = numbers[length-1];
            return newArray;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int length = numbers.Length;
            int[] newArray = new int[length];

            if (numbers[0] > numbers[length - 1])
            {
                for (int i = 0; i < length; i++)
                {
                    newArray[i] = numbers[0];
                }
                return newArray;
            }
            else if (numbers[0] < numbers[length - 1])
            {
                for (int i = 0; i < length; i++)
                {
                    newArray[i] = numbers[length - 1];
                }
                return newArray;
            }
            else
                return newArray;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int lengtha = (a.Length-1) / 2;
            int lengthb = (b.Length-1) / 2;
            int[] newArray = new int[2];

            newArray[0] = a[lengtha];
            newArray[1] = b[lengthb];
            return newArray;
        }
        
        public bool HasEven(int[] numbers)
        {
            int length = numbers.Length;
            bool num = false;

            for(int i = 0; i < length; i ++)
            {
                if (numbers[i] % 2 == 0)
                {
                    num = true;
                    break;
                }
                else
                    num = false;
            }

            return num;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int length = numbers.Length;
            int[] doubleArray = new int[length * 2];
            doubleArray[(length * 2) - 1] = numbers[length - 1];
            return doubleArray;
        }
        
        public bool Double23(int[] numbers)
        {
            int length = numbers.Length;
            int j;
            int howMany2 = 0;
            int howMany3 = 0;
            bool two = false;

            for(j = 0; j < length; j++)
            {
                        if (numbers[j] == 2)
                        {
                            howMany2++;
                        }
                        else if (numbers[j] == 3)
                        {
                            howMany3++;
                        }
                        
                        else
                            continue;
            }

             if (howMany2 == 2 || howMany3 == 2)
            {
                two = true;
            }
            return two;
        }
            
       
        
        public int[] Fix23(int[] numbers)
        {
            int length = numbers.Length;
            int[] newArray = new int[length];

            for(int i = 0; i < length; i++)
            {
                newArray[i] = numbers[i];

                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    newArray[i + 1] = 0;
                    i++;
                }
                else
                    continue;
            }
            return newArray;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            int length = numbers.Length;
            bool unlucky = false;

            for (int i = 0; i < length-1; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    unlucky = true;  
                }
                else
                    continue;
            }
            return unlucky;
        }

        public int[] Make2(int[] a, int[] b)
        {
            int lengtha = a.Length;
            int lengthb = b.Length;
            int[] newArray = new int[2];

            for(int i = 0; i < 2; i++)
            {
                if (lengtha == 0)
                {
                    newArray[i] = b[i];
                }
                else if (lengtha == 1)
                {
                    newArray[i] = a[i];
                    newArray[i+1] = b[i];
                    i++;
                }
                else
                    newArray[i] = a[i];
            }
            return newArray;
        }

    }
}
