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

        public static int p1Wins;
        public static int p2Wins;

        public void phase_1()
        {
            waiting(player1.name);
            player1Board.board_update();
            adding_ships(player1Board, player1);
            waiting(player2.name);
            player2Board.board_update();
            adding_ships(player2Board, player2);
            Console.Clear();
        }
        public void phase_2()
        {
           BattleField player1Radar = new BattleField();
           player1Radar.creating_radar(player1Board);
           BattleField player2Radar = new BattleField();
            player2Radar.creating_radar(player2Board);

            do
            {
                waiting(player1.name);
                while (strategist.shooting(player1, player1Board, player2Board, player2)) ;
                if(player2.list_of_ships.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Player 1 won!");
                    p1Wins++;
                    Console.WriteLine($"Overall score [P1:{p1Wins}-P2:{p2Wins}]");
                    break;
                }
                waiting(player2.name);
                while (strategist.shooting(player2, player2Board, player1Board, player1)) ;
                if (player1.list_of_ships.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Player 2 won!");
                    p2Wins++;
                    Console.WriteLine($"Overall score [P1:{p2Wins}-P2:{p1Wins}]");
                    break;
                }

            } while (true);

            

            Console.ReadLine();
        }

        private void adding_ships(BattleField board, Player player)
        {
            for (int i = 1; i <= 2; i++)
            {
                strategist.creating_ships(i, board, strategist, player);
            }
        }

        private void waiting(int player)
        {
            
            while (true)
            {
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Thread.Sleep(500);
                if (Console.KeyAvailable) { break; }
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Console.Write(".");
                Thread.Sleep(500);
                if (Console.KeyAvailable) { break; }
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Console.Write("..");
                Thread.Sleep(500);
                if (Console.KeyAvailable) { break; }
                Console.Clear();
                Console.Write($"Waiting for player {player}");
                Console.Write("...");
                Thread.Sleep(500);
            }
            Console.ReadLine();
        }
    }
}
