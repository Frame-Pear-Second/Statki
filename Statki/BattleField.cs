using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class BattleField
    {
        public int[,] fields = new int[10,10];
        private char water_icon = '░';
        private char taken_water_icon = '▒';
        private char ship_icon = '■';

        public void board_display()
        {
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                Console.Write('\n');

                for (int j = 0; j < fields.GetLength(1); j++)
                {
                    if (fields[i, j] == 0)
                    {
                        Console.Write(water_icon);
                    }
                    else if (fields[i, j] == 1)
                    {
                        Console.Write(ship_icon);
                    }
                    else if (fields[i, j] == 2)
                    {
                        Console.Write(taken_water_icon);
                    }
                }
            }
        }

        public void board_update()
        {
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                for (int j = 0; j < fields.GetLength(1); j++)
                {
                    fields[i, j] = 0;
                }
            }
        }

    }
}
