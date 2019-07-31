using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == true && bSmile == true)
            {
                return true;
            }
            else if (aSmile == false && bSmile == false)
            {
                return true;
            }
            else
                return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool sleepIn = false;

            if (isVacation == true)
            {
                sleepIn = true;
            }
            else if (isWeekday == false)
            {
                sleepIn = true;
            }

            return sleepIn;
        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;

            if(a == b)
            {
                sum = (a + b) * 2;
            }

            return sum;
        }
        
        public int Diff21(int n)
        {
            int dif = Math.Abs(21 - n);

            if (n > 21)
            {
                dif = Math.Abs(n - 21) * 2;
            }

            return dif;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool trouble = false;

            if(isTalking == true)
            {
                if(hour < 7 || hour > 20)
                {
                    trouble = true;
                }
            }

            return trouble;
        }
        
        public bool Makes10(int a, int b)
        {
            bool ifTen = false;
            int sum = a + b;

            if (a == 10 || b == 10 || sum == 10)
                ifTen = true;

            return ifTen;
        }
        
        public bool NearHundred(int n)
        {
            bool closeHundo = false;

            if (100 - n <= 10 || 100 + n <= 110)
                closeHundo = true;

            return closeHundo;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool test = false;

            if (negative == false)
            {
                if (a < 0 && b > 0)
                {
                    test = true;
                }
                else if (a > 0 && b < 0)
                {
                    test = true;
                }
            }
            else if (negative == true)
            {
                if (a < 0 && b < 0)
                    test = true;
            }

            return test;
        }
        
        public string NotString(string s)
        {
            bool not = false;
            int length = s.Length - 1;

            if (length < 2)
            {
                return "not " + s;
            }
            else if (s.Substring(0, 2) == "not")
            {
                ;
            }
            else
                return "not " + s;

            return s;
        }
        
        public string MissingChar(string str, int n)
        {

            str = str.Remove(n, 1);

            return str;
        }
        
        public string FrontBack(string str)
        {
            
            int length = str.Length-1;

            if (length > 0)
            {
                string firstLetter = str.Remove(1, length);
                string lastLetter = str.Remove(0, length);
                string middle = str.Substring(1, length - 1);

                if (length == 2)
                {
                    str = lastLetter + firstLetter;
                }
                else
                {
                    str = lastLetter + middle + firstLetter;
                }

            }

            return str;
        }
        
        public string Front3(string str)
        {
            int length = str.Length;
            string repeat;

            if (length < 3)
            {
                repeat = str;
            }
            else
                repeat = str.Remove(3);

            return repeat + repeat + repeat;
        }
        
        public string BackAround(string str)
        {
            int length = str.Length;

            string letter = str.Remove(0, length-1);

            return letter + str + letter;
        }
        
        public bool Multiple3or5(int number)
        {
            bool multiple = false;

            if(number % 3 == 0 || number % 5 == 0)
            {
                multiple = true;
            }

            return multiple;
        }
        
        public bool StartHi(string str)
        {
            bool ifHi = false;
            int length = str.Length;

            if(length <= 2 && str == "hi")
            {
                ifHi = true;
            }
            else if(length > 2 && str.Remove(2, length-2) == "hi")
            {
                if (str.Substring(1,2) == "i " || str.Substring(1,2) == "i,")
                {
                    ifHi = true;
                }
            }

            return ifHi;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            bool dif = false;

            if(temp1 > 100)
            {
                if(temp2 < 0)
                {
                    dif = true;
                }
            }
            else if(temp1 < 0)
            {
                if(temp2 > 100)
                {
                    dif = true;
                }
            }

            return dif;
        }
        
        public bool Between10and20(int a, int b)
        {
            bool bet = false;

            if(a >= 10 && a <= 20)
            {
                bet = true;
            }
            else if( b >= 10 && b <= 20)
            {
                bet = true;
            }

            return bet;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            bool teen = false;

            if(a >= 13 && a <= 19)
            {
                teen = true;
                
            }
            else if (b >= 13 && b <= 19)
            {
                teen = true;
                
            }
            else if (c >= 13 && c <= 19)
            {
                teen = true;
            }

            return teen;
        }
        
        public bool SoAlone(int a, int b)
        {
            bool teen = false;

            if (a >= 13 && a <= 19)
            {
                teen = true;
                if (b >= 13 && b <= 19)
                {
                    teen = false;
                }
            }
            else if (b >= 13 && b <= 19)
            {
                teen = true;
                
            }

            return teen;
        }
        
        public string RemoveDel(string str)
        {
            int length = str.Length;
            bool del = str.Contains("del");

            if (del == true)
                for (int i = 0; i < length - 1; i++)
                    if (str[i] == 'd' && str[i + 1] == 'e' && str[i + 2] == 'l')
                    {
                        str = str.Remove(i, 3);
                        break;
                    }

            return str;
        }
        
        public bool IxStart(string str)
        {
            int length = str.Length;
            bool ix = false;
            string three = str.Remove(3);

            if(three.Remove(0,1) == "ix")
            {
                return ix = true;
            }

            return ix;

        }
        
        public string StartOz(string str)
        {
            int length = str.Length;

            if( length > 2)
            {
                string two = str.Remove(2);

                if (two.Contains("oz") == true)
                {
                    str = "oz";
                }
                else if (two.Contains("o") == true)
                {
                    str = "o";
                }
                else if (two.Contains("z") == true)
                {
                    str = "z";
                }
            }
            else
            {
                str = "";
            }

            return str;
        }
        
        public int Max(int a, int b, int c)
        {
            int largest = c;

            if (a > b)
            {
                if (a > c)
                {
                    largest = a;
                }
            }
            else if (b > a)
            {
                if (b > c)
                {
                    largest = b;
                }
            }

            return largest;
            }
        
        public int Closer(int a, int b)
        {
            int closer = a;
            int aAbs = Math.Abs(10 - a);
            int bAbs = Math.Abs(10 - b);

            if(aAbs > bAbs)
            {
                closer = b;
            }
            else if(aAbs == bAbs)
            {
                closer = 0;
            }

            return closer;
        }
        
        public bool GotE(string str)
        {
            int length = str.Length;
            bool EEE = false;
            int ecount = 0;

            for (int i = 0; i < length; i++)
                {
                    if (str[i] == 'e')
                    {
                        ecount++;

                        if (ecount > 3)
                        {
                            EEE = false;
                        }
                        else
                            EEE = true;
                    }
                }

            return EEE;   
        }
        
        public string EndUp(string str)
        {
            int length = str.Length-1;
            

            if(length <= 2)
            {
                str = str.ToUpper();
            }
            else if(length >2)
            {
                string lastThree = str.Remove(0, length - 2);
                string restOf = str.Remove(length - 2);
                lastThree = lastThree.ToUpper();
                str = restOf + lastThree;
            }

            return str;
        }
        
        public string EveryNth(string str, int n)
        {
            int length = str.Length;
            string total = "";
            
             
            for(int i = 0; i < length;)
            {

                    total = total + str.Substring(i, 1);
             
                i = i + n;
            }

            return total;
        }
    }
}