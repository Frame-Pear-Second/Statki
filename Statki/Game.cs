using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Statki
{
    internal class Game
    {
        private BattleField player1Board = new BattleField();
        private BattleField player2Board = new BattleField();
        Player player1 = new Player(1);
        Player player2 = new Player(2);
        Strategist strategist = new Strategist();
        public void phase_1()
        {
            player1Board.board_update();
            adding_ships(player1Board, player1);
            waiting(player2.name);
            player2Board.board_update();
            adding_ships(player2Board, player2);
            waiting(player1.name);
        }
        public void phase_2()
        {
           BattleField player1Radar = new BattleField();
           player1Radar = (BattleField)player1Board.CreatingRadar();
           BattleField player2Radar = new BattleField();
           player2Radar = (BattleField)player2Board.CreatingRadar();

           player1Radar.radarDisplay();
           player1Board.board_display();
        }

        private void adding_ships(BattleField board, Player player)
        {
            for (int i = 1; i <= 4; i++)
            {
                strategist.creating_ships(i, board, strategist, player);
            }
        }

        private void waiting(int player)
        {
            
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Thread.Sleep(500);
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Console.Write(".");
                Thread.Sleep(500);
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Console.Write("..");
                Thread.Sleep(500);
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Console.Write("...");
                Thread.Sleep(500);
            }
        }
    }
}
