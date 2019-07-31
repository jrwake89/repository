using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class WorkFlow
    {
        private int _start { get; set; }
        private string _p1 { get; set; }
        private string _p2 { get; set; }
        private Board _p1board { get; set; }
        private Board _p2board { get; set; }    

        public void Start()
        {
            Manager mng = new Manager();
            Random rng = new Random();
            _start = rng.Next(1, 3);
            mng.PlayGame(_p1board, _p2board, _p1, _p2);
        }

        public void StartFire()
        {
            int x = 0;
            int y = 0;
            while (true)
            {
                string strCoordinate = "";

                if (_start == 1)
                {
                    Coordinate Coordinate = new Coordinate(x, y);

                    Console.Clear();

                    DisplayBoard(_p1board);

                    Console.WriteLine("\n {0},", _p1);


                    //Asks player 1 where to fire

                    Console.WriteLine("Where would you like to fire?");

                    strCoordinate = ConsoleInput.GetCoor(Coordinate);

                    ConsoleInput.ProcessCoor(Coordinate, x, y, strCoordinate);
                    var shotResponse = _p1board.FireShot(Coordinate);

                    ResponseToShot(shotResponse);

                    if (shotResponse.ShotStatus == ShotStatus.Victory)
                    {
                        Console.WriteLine("{0}, you won!", _p1);
                        _start = -1;
                    }
                    else
                    {
                        Console.WriteLine("Press any key for {0}'s turn", _p2);

                        Console.ReadKey();
                    }
                    _start++;
                }

                else if (_start == 2)
                {
                    Coordinate Coordinate = new Coordinate(x, y);

                    Console.Clear();

                    DisplayBoard(_p2board);

                    Console.WriteLine("\n {0},", _p2);


                    //Asks player 2 where to fire

                    Console.WriteLine("Where would you like to fire?");

                    strCoordinate = ConsoleInput.GetCoor(Coordinate);

                    ConsoleInput.ProcessCoor(Coordinate, x, y, strCoordinate);

                    var shotResponse = _p2board.FireShot(Coordinate);

                    ResponseToShot(shotResponse);

                    if (shotResponse.ShotStatus == ShotStatus.Victory)
                    {
                        Console.WriteLine("{0}, you won!", _p2);
                        _start = 1;
                    }
                    else
                    {
                        Console.WriteLine("Press any key for {0}'s turn", _p1);

                        Console.ReadKey();
                    }

                    _start--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Do you want to play again (Y/N)?");

            string again = Console.ReadLine();
            if (again == "Y" || again == "y")
            {
                Start();
            }
        }

        private void DisplayBoard(Board board)
        {
            Console.WriteLine("  1  2  3  4  5  6  7  8  9  10 ");
            string[] letters = new string[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            for (int i = 1; i <= 10; i++)
            {
                Console.Write("{0} ", letters[i]);
                for (int j = 1; j <= 10; j++)
                {
                    Coordinate coordinate = new Coordinate(i, j);
                    ShotHistory history = board.CheckCoordinate(coordinate);

                    if (history == ShotHistory.Unknown)
                    {
                        Console.Write("   ");
                    }
                    else if (history == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("H  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (history == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("M  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine("");
            }
        }

        //Gives responses to the player informing them of what their shot did
        private void ResponseToShot(FireShotResponse shotResponse)
        {
            if (shotResponse.ShotStatus == ShotStatus.Miss)
            {
                Console.WriteLine("That shot did not hit a ship.");
            }
            else if (shotResponse.ShotStatus == ShotStatus.Duplicate)
            {
                Console.WriteLine("You've already tried this coordinate. Press any key to go again");

                Console.ReadLine();

                StartFire();
            }
            else if (shotResponse.ShotStatus == ShotStatus.Hit)
            {
                Console.WriteLine("You hit a ship!");
            }
            else if (shotResponse.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.WriteLine("You hit and sunk the {0}", shotResponse.ShipImpacted);
            }
            else if (shotResponse.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine("That shot was invalid");

                StartFire();
            }
        }

    }
}
