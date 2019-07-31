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
    class Manager
    {

        //Starts the game
        public void PlayGame(Board _p1board, Board _p2board, string _p1, string _p2)
        {

            ConsoleOutput.DisplayTitle();

            //Gets the name of each player

            Console.WriteLine("Player 1, please type your name:");

            _p1 = ConsoleInput.GetName();
            Console.Clear();

            Console.WriteLine("Player 2, please type your name:");

            _p2 = ConsoleInput.GetName();

            Console.Clear();

            //Asks player one to populate his/her board
            WorkSet workSet = new WorkSet();

            Console.WriteLine("{0},", _p2);
            workSet.PlayerData(_p1board);

            //Asks player two to populate his/her board

            Console.WriteLine("{0},", _p2);
            workSet.PlayerData(_p2board);

            //Begins asking players to fire at their opponent
            WorkFlow.StartFire();
        }
    }
}
