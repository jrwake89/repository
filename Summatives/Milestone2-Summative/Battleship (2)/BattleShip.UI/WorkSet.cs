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
    public class WorkSet
    {
        private string _direction { get; set; }
        private string _strCoordinate { get; set; }

        public void PlayerData(Board board)
        {
            int x = 0;
            int y = 0;
            PlaceShipRequest request = new PlaceShipRequest();
            Coordinate Coordinate = new Coordinate(x, y);

            for (int currentShipIndex = 0; currentShipIndex < 5;)
            {
                while (true)
                {
                    request.ShipType = ConsoleInput.ProcessType(currentShipIndex);

                    _strCoordinate = ConsoleInput.GetCoor(Coordinate);

                    ConsoleInput.ProcessCoor(Coordinate, x, y, _strCoordinate);

                    request.Coordinate = Coordinate;

                    _direction = ConsoleInput.GetDirection(_direction);

                    request.Direction = ConsoleInput.ProcessDirection(_direction);

                    var shipPlaced = board.PlaceShip(request);

                    if (shipPlaced == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine("There's not enough space for that ship. Try again");
                    }
                    else if (shipPlaced == ShipPlacement.Overlap)
                    {
                        Console.WriteLine("Ships are overlapping. Try again.");
                    }
                    else
                    {
                        break;
                    }
                }
                currentShipIndex++;
                Console.Clear();
            }
        }
    }
}
