﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class BattleField
    {
        public int[,] fields = new int[10,10];
        private char waterIcon = Convert.ToChar(126);
        private char takenWaterIcon = Convert.ToChar(58);
        private char shipIcon = Convert.ToChar(9632);
        private char missIcon = '@';
        private char hitIcon = '#'; 


        
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
                        case 1:
                            Console.Write(shipIcon);
                            break;
                        case 0:
                        case 2:
                        case 3:
                        case 4:
                        case 6:
                            Console.Write(waterIcon);
                            break;
                        case 5:
                            Console.Write(hitIcon);
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
                Console.ResetColor();
                Console.Write((char)('a' + i));
                if (i == target)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                for (int j = 0; j < fields.GetLength(1); j++)
                {

                    switch (fields[i, j])
                    {
                        case 0:
                            Console.Write(waterIcon);
                            break;
                        case 1:
                            Console.Write(shipIcon);
                            break;
                        case 2:
                        case 3:
                            Console.Write(waterIcon);
                            break;
                    }
                }
            Console.Write('\n');
            }
            Console.Write('\n');
            Console.ResetColor();
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

        public void creating_radar(BattleField realBoard)
        {
            this.fields = (int[,])realBoard.fields.Clone();
        }

        public void radar_display()
        {
            Console.WriteLine(" 12345678910");
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                Console.Write((char)('a' + i));

                for (int j = 0; j < fields.GetLength(1); j++)
                {

                    switch (fields[i, j])
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            Console.Write(waterIcon);
                            break;
                        case 4:
                            Console.Write(missIcon);
                            break;
                        case 5:
                            Console.Write(hitIcon);
                            break;
                        case 6:
                            Console.Write(missIcon);
                            break;

                    }

                }

                Console.Write('\n');
            }
            Console.WriteLine();
        }

    }
}
