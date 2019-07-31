using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word)
        {
            int length = container.Length - 1;
            string firstHalf = container.Substring(0, 2);
            string secondHalf = container.Remove(0, 2);

            return firstHalf + word + secondHalf;
        }

        public string MultipleEndings(string str)
        {
            int length = (str.Length) - 1;
            string print = str.Substring(length - 1);
            return print + print + print;
        }

        public string FirstHalf(string str)
        {
            int length = str.Length / 2;
            return str.Substring(0, length);
        }

        public string TrimOne(string str)
        {
            int length = str.Length - 1;
            return str.Substring(1, length - 1);
        }

        public string LongInMiddle(string a, string b)
        {
            int length1 = a.Length - 1;
            int length2 = b.Length - 1;

            if (length1 < length2)
            {
                return a + b + a;
            }
            else
                return b + a + b;
        }

        public string RotateLeft2(string str)
        {
            int length = str.Length - 1;
            if (length <= 2)
            {
                return str;
            }
            else
                return str.Substring(2) + str.Substring(0, 2);
        }

        public string RotateRight2(string str)
        {
            int length = str.Length - 1;
            if (length <= 2)
            {
                return str;
            }
            else
                return str.Substring(length - 1) + str.Substring(0, length - 1);
        }

        public string TakeOne(string str, bool fromFront)
        {
            int length = str.Length - 1;

            if (fromFront == true)
            {
                return str.Substring(0, 1);
            }
            else
                return str.Substring(length);
        }

        public string MiddleTwo(string str)
        {
            int length = (str.Length / 2) - 1;
            str = str.Remove(0, length);
            str = str.Remove(str.Length - length);
            return str;
        }

        public bool EndsWithLy(string str)
        {

            int length = str.Length - 1;

            if (length < 1)
            {
                return false;
            }

            else if (str.Substring(length - 1) == "ly")
            {
                return true;
            }

            else
                return false;
        }

        public string FrontAndBack(string str, int n)
        {
            int length = str.Length - 1;
            string front = str.Substring(0, n);
            string back = str.Substring(length - (n - 1));
            return front + back;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            int length = str.Length - 1;
            if (length <= 2 || length < n + 1)
            {
                return str.Substring(0, 2);
            }
            else if (length > n + 1)
            {
                return str.Substring(n, n + 2);
            }
            else
                return str.Remove(0, n);
        }

        public bool HasBad(string str)
        {
            int length = str.Length;

            if (str == "" || length < 3)
            {
                return false;
            }

            else if (length >= 3)
            {
                if (str.Substring(0, 2) == "xb" || str.Substring(0, 2) == "ba")
                {
                    if (str.Substring(0, 4) == "xbad" || str.Substring(0, 3) == "bad")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }

        public string AtFirst(string str)
        {
            int length = str.Length;
            if (length == 0)
            {
                return "@@";
            }
            else if (length == 1)
            {
                return str.Substring(0) + "@";
            }
            else
                return str.Substring(0, 2);
        }

        public string LastChars(string a, string b)
        {
            int lengtha = a.Length;
            int lengthb = b.Length;

            if (lengtha < 1 && lengthb < 1)
            {
                a = "@";
                b = "@";
                return a + b;
            }

            else if (lengtha < 1)
            {
                a = "@";
                b = b.Remove(0, lengthb - 1);
                return a + b;
            }

            else if (lengthb < 1)
            {
                a = a.Substring(0, 1);
                b = "@";
                return a + b;
            }
            else
            {
                a = a.Substring(0, 1);
                b = b.Remove(0, lengthb - 1);
                return a + b;
            }
        }

        public string ConCat(string a, string b)
        {
            int lengtha = a.Length;
            int lengthb = b.Length;

            if (a == "" || b == "")
            {
                string final = a + b;
                return final.Trim();
            }

            else if (lengtha == 1 && a == b.Substring(0, 1))
            {
                return b;
            }

            else if (lengthb == 1 && a.Substring(lengtha - 1) == b)
            {
                return a;
            }

            else if (a.Substring(2) == b.Substring(0, 1))
            {
                return a.Substring(0, 2) + b;
            }
            else
                return a + b;
        }

        public string SwapLast(string str)
        {
            int length = str.Length - 1;

            if (length < 1)
            {
                return str;
            }
            else if (length >= 1)
            {
                string main = str.Substring(0, length - 1);
                string secondLast = str.Remove(0, length - 1);
                string secondLastL = secondLast.Substring(0, 1);
                string lastL = secondLast.Remove(0, 1);
                return main + lastL + secondLastL;
            }

            return str;
        }

        public bool FrontAgain(string str)
        {
            int length = str.Length - 1;
            string front = str.Substring(0, 2);
            string frontFirst = front.Substring(0, 1);
            string frontSecond = front.Remove(0, 1);
            string end = str.Remove(0, length - 1);
            string secondEnd = end.Substring(0, 1);
            string lastEnd = end.Remove(0, 1);

            if (frontFirst + frontSecond == secondEnd + lastEnd)
            {
                return true;
            }
            else if (frontFirst + frontSecond == lastEnd + secondEnd)
            {
                return true;
            }
            else
                return false;
        }

        public string MinCat(string a, string b)
        {
            int lengtha = a.Length;
            int lengthb = b.Length;

            if (lengtha > lengthb)
            {
                string conA = a.Remove(0, lengtha - lengthb);
                return conA + b;
            }
            else if (lengtha < lengthb)
            {
                string conB = b.Remove(0, lengthb - lengtha);
                return a + conB;
            }
            else
                return a + b;
        }

        public string TweakFront(string str)
        {
            string restWord = str;

            if (restWord != "")
            {
                restWord = str.Remove(0, 2);

                for (int i = 0; i < 2; i++)
                {
                    if (str[i] == 'a' && str[i + 1] == 'b')
                    {
                        return str;
                    }
                    else if (str[i] == 'a' || str[i + 1] == 'a')
                    {
                        return 'a' + restWord;
                    }
                    else if (str[i] == 'b' || str[i + 1] == 'b')
                    {
                        return 'b' + restWord;
                    }
                    else
                    {
                        return restWord;
                    }
                }
            }
            else
            {
                return restWord;
            }

            return restWord;
        }

        public string StripX(string str)
        {
            if (str != "" && str != "x")
            {
                int length = str.Length - 1;
                string firstLetter = str.Substring(0, 1);
                string lastLetter = str.Remove(0, length);
                string word = str.Substring(1, length - 1);

                if (firstLetter == "x" && lastLetter == "x")
                    return word;
                else if (firstLetter == "x")
                {
                    return word + lastLetter;
                }
                else if (lastLetter == "x")
                {
                    return firstLetter + word;
                }
                else
                    return str;
            }
            else
                return "";
        }
    }
}