using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Game
    {
        private BattleField playersOneBoard = new BattleField();
        Player player1 = new Player();
        Strategist strategist = new Strategist();
        public void phase_1()
        {
            
            playersOneBoard.board_update();
            //playersOneBoard.board_display();

            adding_ships();
            

            

        }

        private void adding_ships()
        {
            for (int i = 1; i <= 4; i++)
            {
                strategist.creating_ships(i, playersOneBoard, strategist, player1);
            }
        }
    }
}
