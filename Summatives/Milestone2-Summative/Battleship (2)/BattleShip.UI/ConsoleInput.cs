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
    class ConsoleInput
    {


        //Names for Players
        public static string GetName()
        {
            string p1 = Console.ReadLine();

            if (p1 == "")
            {
                Console.WriteLine("Name cannot be blank");
                p1 = GetName();
            }
            return p1;
        }

        //Convert input for X to an int
        private static int ProcessY(string strCoordinate, int _y, Coordinate Coordinate)
        {
            strCoordinate = strCoordinate.Remove(0, 1);
            int letterLength = strCoordinate.Length;
            bool convert = int.TryParse(strCoordinate, out _y);
            if (convert == false)
            {
                return _y = 11;
            }

            if (letterLength > 1)
            {
                _y = 10;
                return _y;
            }

            return _y;
        }

        //Converts in put for y from letter to number
        private static int ProcessX(string strCoordinate, int _x, Coordinate Coordinate)
        {
            strCoordinate = strCoordinate[0].ToString();
            strCoordinate = strCoordinate.ToUpper();

            switch (strCoordinate)
            {
                case "A":
                    _x = 1;
                    break;
                case "B":
                    _x = 2;
                    break;
                case "C":
                    _x = 3;
                    break;
                case "D":
                    _x = 4;
                    break;
                case "E":
                    _x = 5;
                    break;
                case "F":
                    _x = 6;
                    break;
                case "G":
                    _x = 7;
                    break;
                case "H":
                    _x = 8;
                    break;
                case "I":
                    _x = 9;
                    break;
                case "J":
                    _x = 10;
                    break;
                default:
                    _x = 11;
                    break;
            }

            return _x;
        }
        //Gets coordinates for placing the ship
        public static string GetCoor(Coordinate Coordinate)
        {
            int _x = 0;
            int _y = 0;

            while (true)
            {
                Console.WriteLine("Enter your coordinates (A4):");
                string strCoordinate = Console.ReadLine();

                if (strCoordinate != "")
                {
                    _x = ProcessX(strCoordinate, _x, Coordinate);
                    _y = ProcessY(strCoordinate, _y, Coordinate);

                    if (_x == 11 || _y == 11)
                    {
                        Console.WriteLine("That is not a valid entry");
                    }
                    else if (strCoordinate.Length != 2)
                    {
                        if (strCoordinate.Length == 3 && strCoordinate.Remove(0, 1) != "10")
                        {
                            Console.WriteLine("That is not a valid entry");
                        }
                        else if (strCoordinate.Length < 2)
                        {
                            Console.WriteLine("That is not a valid entry");
                        }
                        else
                        {
                            return strCoordinate;
                        }
                    }
                    else
                    {
                        return strCoordinate;
                    }
                }

                else
                {
                    Console.WriteLine("you must enter a coordinate");
                }
            }
        }

        public static void ProcessCoor(Coordinate Coordinate, int _x, int _y, string strCoordinate)
        {
            Coordinate.XCoordinate = ProcessX(strCoordinate, _x, Coordinate);
            Coordinate.YCoordinate = ProcessY(strCoordinate, _y, Coordinate);
        }


        //Gives the type of ship
        public static ShipType ProcessType(int currentShipIndex)
        {
            ShipType shipType = new ShipType();

            if (currentShipIndex == 0)
            {
                Console.WriteLine("Where do you want to place your Destroyer?");
                shipType = ShipType.Destroyer;
            }
            else if (currentShipIndex == 1)
            {
                Console.WriteLine("Where do you want to place your Submarine?");
                shipType = ShipType.Submarine;
            }
            else if (currentShipIndex == 2)
            {
                Console.WriteLine("Where do you want to place your Cruiser?");
                shipType = ShipType.Cruiser;
            }
            else if (currentShipIndex == 3)
            {
                Console.WriteLine("Where do you want to place your Battleship?");
                shipType = ShipType.Battleship;
            }
            else
            {
                Console.WriteLine("Where do you want to place your Carrier?");
                shipType = ShipType.Carrier;
            }

            return shipType;
        }

        //Gets the input for the direction of the ship
        public static string GetDirection(string direction)
        {

            Console.WriteLine("What direction would your like your ship to go (Up, Down, Left, Right)? ");
            direction = Console.ReadLine();
            direction = direction.ToUpper();

            bool returnDirection = false;



            switch (direction)
            {
                case "UP":
                    returnDirection = true;
                    break;
                case "DOWN":
                    returnDirection = true;
                    break;
                case "LEFT":
                    returnDirection = true;
                    break;
                case "RIGHT":
                    returnDirection = true;
                    break;
                default:
                    Console.WriteLine("That is not a valid entry!");
                    returnDirection = false;
                    break;
            }
            if (returnDirection == false)
            {
                direction = GetDirection(direction);
            }

            return direction;
        }

        public static ShipDirection ProcessDirection(string direction)
        {
            if (direction == "UP")
            {
                return ShipDirection.Up;
            }
            else if (direction == "DOWN")
            {
                return ShipDirection.Down;
            }
            else if (direction == "RIGHT")
            {
                return ShipDirection.Right;
            }
            else
            {
                return ShipDirection.Left;
            }
        }
    }
}

