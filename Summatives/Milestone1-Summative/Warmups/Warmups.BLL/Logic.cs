using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool party = false;

            if(isWeekend == true)
            {
                if(cigars >= 40)
                {
                    party = true;
                }
            }

            else if (cigars >= 40 && cigars <= 60)
            {
                party = true;
            }

            return party;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {


            if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            else if (yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }
            else
                return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool play = false;

            if (isSummer == true)
            {
                if (temp >= 60 && temp <= 100)
                {
                    play = true;
                }
            }
            else if (temp >= 60 && temp <= 90)
            {
                play = true;
            }

                return play;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if(isBirthday == true)
            {
                speed = speed - 5;
            }

            if (speed <= 60)
            {
                return 0;
            }
            else if (speed > 60 && speed <= 80)
            {
                return 1;
            }
            else
                return 2;
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;

            if(sum >=  10 && sum <= 19)
            {
                sum = 20;
            }

            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string clock = "7:00";

            if (vacation == true)
            {
                if (day >= 1 && day <= 5)
                {
                    clock = "10:00";
                }
                else
                    clock = "off";
            }

            if (day >= 1 && day <= 5)
            {
                    clock = "7:00";
            }
                else
            {
                clock = "10:00";
            }
                    
            return clock;
        }
        
        public bool LoveSix(int a, int b)
        {
            int sum = a + b;
            bool six = false;

            if (sum == 6 || a == 6 || b == 6)
            {
                six = true;
            }

            return six;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool range = false;

            if(outsideMode == true)
            {
                if (n <= 1 || n >= 10)
                {
                    range = true;
                }
            }

            else if (n >= 1 && n <= 10)
            {
                range = true;
            }

            return range;
        }
        
        public bool SpecialEleven(int n)
        {
            bool special = false;

            if (n % 11 == 0)
            {
                special = true;
            }
            else if ((n-1) % 11 == 0)
            {
                special = true;
            }

            return special;
        }
        
        public bool Mod20(int n)
        {
            bool twentyPlus = false;

            if((n-1) % 20 == 0)
            {
                twentyPlus = true;
            }

            else if ((n-2) % 20 == 0)
            {
                twentyPlus = true;
            }

            return twentyPlus;
        }
        
        public bool Mod35(int n)
        {
            bool threeFive = false;
            
            if(n % 3 == 0 && n % 5 == 0)
            {
                ;
            }
            else if (n % 3 == 0)
            {
                threeFive = true;
            }
            else if (n % 5 == 0)
            {
                threeFive= true;
            }
            return threeFive;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool answer = false;

            if (isAsleep == true)
            {
                ;
            }
            else if (isMorning == true)
            {
                if (isMom == true)
                {
                    answer = true;
                }
            }
            else
                answer = true;
            return answer;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            bool equals = false;

            if (a + b == c)
            {
                equals = true;
            }
            else if(b + c == a)
            {
                equals = true;
            }
            else if(a + c == b)
            {
                equals = true;
            }

            return equals;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool greater = false;

            if (a < b && b < c)
            {
                greater = true;
            }
            else if(bOk == true)
            {
                if( a < c && b < c)
                {
                    greater = true;
                }
            }

            return greater;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool increasing = false;

            if(a < b && b < c)
            {
                increasing = true;
            }
            else if(equalOk == true)
            {
                if (a <= b && b <= c)
                {
                    increasing = true;
                }
            }

            return increasing;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            bool equalDig = false;
            a = a % 10;
            b = b % 10;
            c = c % 10;

            if(a == b || b == c || a == c)
            {
                equalDig = true;
            }

            return equalDig;
            
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;

            if(die1 == die2 && noDoubles == true)
            {
                if (die1 == 6)
                {
                    die1 = 1;
                }

                else
                    die1 = die1 + 1;
            }

            sum = die1 + die2;
            return sum;
        }

    }
}
