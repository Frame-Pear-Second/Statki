using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Strategist
    {
        public void adding_ship_to_BattleField(int[,] array, Ship ship)
        {
            int x = ship.ship_x;
            int y = ship.ship_y;

            //horizontal
            if (ship.ship_direction == false)
            {
                int prow = x - 1;
                int stern = ship.ship_lenght + x;

                for (int i = prow; i < stern - 1; i++)
                {
                    array[y - 1, i] = 1;

                    if (y != 1) { array[y - 2, i] = 2; }
                    if (y != 10) { array[y, i] = 2; }
                    if (prow != 0) { array[y - 1, prow - 1] = 2; }
                    if (stern <= 10) { array[y - 1, stern - 1] = 2; }
                    // corners
                    if (prow != 0 && y != 1) { array[y - 2, prow - 1] = 2; }        //left_up
                    if (prow != 0 && y != 10) { array[y, prow - 1] = 2; }           //left_down
                    if (stern <= 10 && y != 1) { array[y - 2, stern - 1] = 2; }     //right_up
                    if (stern <= 10 && y != 10) { array[y, stern - 1] = 2; }        //right_down
                }
            }//vertical
            else if(ship.ship_direction == true)
            {
                int prow = y - 1;
                int stern = ship.ship_lenght + prow;

                for (int j = prow; j < stern; j++)
                {
                    array[j, x - 1] = 1;

                    if (x != 1) { array[j, x - 2] = 2; }                            //left
                    if (x != 10) { array[j, x] = 2; }                               //right
                    if (prow != 0) { array[prow - 1, x - 1] = 2; }                  //top
                    if (stern < 10) { array[stern, x - 1] = 2; }                    //down
                    // corners
                    
                    if (prow != 0 && x != 1) { array[prow - 1, x - 2] = 2; }        //left_up
                    if (prow != 0 && x != 10) { array[prow - 1, x] = 2; }           //right_up
                    if (stern + 1 < 10 && x - 2 != 1) { array[stern, x - 2] = 2; }  //left_down
                    if (stern < 10 && x != 10) { array[stern, x] = 2; }             //right_down
                    
                }
            }
        }

        public void creating_ships(int q, Player player)
        {
            int size = Math.Abs(q - 5);
            int position_x;
            int position_y;
            bool rotation;
            string name = " ";

            switch (q)
            {
                case 1:
                    name = "four";
                    break;
                case 2:
                    name = "three";
                    break;
                case 3:
                    name = "two";
                    break;
                case 4:
                    name = "one";
                    break;
            }

            for (int i = 1; i <= q; i++)
            {
                do
                {
                    Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                    Console.WriteLine("rotation [h/v]: ");
                    string rot_entry = Console.ReadLine();
                    if (rot_entry == "h")
                    {
                        rotation = false;
                        break;
                    }
                    else if (rot_entry == "v")
                    {
                        rotation = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("(Wrong value! Only 'h' or 'v'!)");
                    }
                }
                while (true);

                Console.Clear();
                do
                {
                    Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                    Console.WriteLine("position y [a-j]: ");
                    string y_string = Console.ReadLine().Trim();
                    if (y_string.Length != 1)
                    {
                        Console.Clear();
                        continue;
                    }
                    int y_int = char.Parse(y_string) - char.Parse("a") + 1;
                    if (!rotation)
                    {
                        if (y_int >= 1 && y_int <= 10)
                        {
                            position_y = y_int;
                            break;
                        }
                    }
                    else
                    {
                        if (y_int >= 1 && y_int <= 10 - (size - 1))
                        {
                            position_y = y_int;
                            break;
                        }
                        
                    }
                    Console.Clear();
                    Console.WriteLine("(Wrong value! Only one letter from the a-j range!)");
                }
                while (true);

                Console.Clear();
                do
                {
                    Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                    Console.WriteLine("position x [1-10]: ");
                    string x_string = Console.ReadLine().Trim();
                    if (x_string.Length != 1)
                    {
                        Console.Clear();
                        continue;
                    }
                    int x_int = int.Parse(x_string);
                    if (rotation)
                    {
                        if (x_int >= 1 && x_int <= 10)
                        {
                            position_x = x_int;
                            break;
                        }
                    }
                    else
                    {
                        if (x_int >= 1 && x_int <= 10 - (size - 1))
                        {
                            position_x = x_int;
                            break;
                        }

                    }
                    Console.Clear();
                    Console.WriteLine("(Wrong value!)");
                }
                while (true);

                player.alive_ships[q - 1] += 1;
                player.list_of_ships.Add(new Ship(name, size, rotation, position_x, position_y));


            }
        
    }   }

        

    
}
