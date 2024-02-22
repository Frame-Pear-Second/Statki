using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BattleField test = new BattleField();
            test.board_update();

            Player player1 = new Player();
            Strategist strategist = new Strategist();

            strategist.creating_ships(4, player1);
            strategist.ship_deploy(test.fields, player1.list_of_ships<1>);

            test.board_display();

            Console.ReadLine();
        }
    }
}
