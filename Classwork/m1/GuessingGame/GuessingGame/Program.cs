using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int playerGuess;
            int i = 1;
            string playerInput;
           
             

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter difficulty level (Easy = 1, Med = 2, Hard = 3)");
            string levelNumber = Console.ReadLine();

            int gameLevel = int.Parse(levelNumber);
  

      
            Number p1 = new Number();
            p1.getNumber(ref gameLevel);
            int numbers = gameLevel;

            Difficulty p2 = new Difficulty();
                p2.Level(ref gameLevel);
            int theAnswer = gameLevel;

                Console.WriteLine("Enter your name");
                string playerName = Console.ReadLine();

                Console.WriteLine("Press Q at anytime during the game to quit.");

                do
                {

                    // get player input
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{playerName}, enter your guess (1-{numbers}): ");
                    playerInput = Console.ReadLine();

                    //attempt to convert the string to a number
                    if (int.TryParse(playerInput, out playerGuess))
                    {
                    if (playerGuess == theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (i == 1)
                            {
                                Console.WriteLine($"{playerName}, {theAnswer} was the number.  You got it on your FIRST TRY!");
                                break;
                            }

                            else
                            {
                                Console.WriteLine($"{playerName}, {theAnswer} was the number.  You Win! It took you {i} attempts.");
                                break;
                            }
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (playerGuess > theAnswer)
                            {
                                Console.WriteLine($"{playerName}, your guess was too High!");
                                i++;
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"{playerName}, your guess was too low!");
                                i++;
                                continue;
                            }
                        }

                    }

                    if (playerInput == "Q")
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"{playerName}, that wasn't a number! Please try again.");
                    }

                } while (true);

        }

    }

    class Difficulty
    {
        public int Level(ref int gameLevel)
        {
            Random r = new Random();

            if (gameLevel == 5)
            {
                gameLevel = r.Next(1, 6);
                return gameLevel;
            }

            else if (gameLevel == 20)
            {
                gameLevel = r.Next(1, 21);
                return gameLevel;
            }

            else if (gameLevel == 50)
            {
                gameLevel = r.Next(1, 51);
                return gameLevel;
            }
            else
                Console.WriteLine("That number was invalid.");
            return gameLevel = 0;

        }
    }

    class Number
    {
        public int getNumber(ref int gameLevel)
        {

            if (gameLevel == 1)
            {
                return gameLevel = 5;
            }

            else if (gameLevel == 2)
            {
                return gameLevel = 20;
            }

            else if (gameLevel == 3)
            {
                return gameLevel = 50;
            }

            else
                Console.WriteLine("That number was invalid.");
                return gameLevel = 0;
        }
        
    }
}
