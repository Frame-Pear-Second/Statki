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
        private char water_icon = Convert.ToChar(126);
        private char taken_water_icon = Convert.ToChar(58);
        private char ship_icon = Convert.ToChar(9632);

        public void board_display()
        {
            Console.WriteLine(" 12345678910");
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                Console.Write((char)('a'+i));
                
                for (int j = 0; j < fields.GetLength(1); j++)
                {

                    switch (fields[i, j])
                    {
                        case 0:
                            Console.Write(water_icon);
                            break;
                        case 1:
                            Console.Write(ship_icon);
                            break;
                        case 2:
                            Console.Write(taken_water_icon);
                            break;
                        case 3:
                            Console.Write(taken_water_icon);
                            break;
                    }

                }

                Console.Write('\n');
            }
            Console.WriteLine();
        }

        public void board_aiming_display(int target)
        {
            Console.WriteLine(" 12345678910");
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                Console.Write((char)('a' + i));
                if (i == target)
                {
                    Console.WriteLine("++++++++++");
                    continue;
                }

                for (int j = 0; j < fields.GetLength(1); j++)
                {

                    switch (fields[i, j])
                    {
                        case 0:
                            Console.Write(water_icon);
                            break;
                        case 1:
                            Console.Write(ship_icon);
                            break;
                        case 2:
                            Console.Write(taken_water_icon);
                            break;
                        case 3:
                            Console.Write(taken_water_icon);
                            break;
                    }
                }

                Console.Write('\n');
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
