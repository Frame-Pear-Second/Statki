using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Statki
{
    internal class Strategist
    {
        static int z = 0;

        public void creating_ships(int q, BattleField board, Strategist menager, Player player)
        {
            int size = Math.Abs(q - 5);
            int position_x;
            int position_y;
            bool rotation;
            string name = " ";
            bool valid_ship;

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
                    
                    if (q != 4)
                    {
                        do
                        {
                            Console.Clear();
                            board.board_display();
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
                                Console.WriteLine("(Wrong value! Only 'h' or 'v'!)");
                                Console.ReadKey();
                            }
                        }
                        while (true);
                    }
                    else { rotation = false; }

                    
                    do
                    {
                        Console.Clear();
                        board.board_display();
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
                        board.board_display();
                        Console.WriteLine("(Wrong value! Only one letter from the a-j range!)");
                        Console.ReadKey();
                    }
                    while (true);

                    
                    do
                    {
                        Console.Clear();
                        board.board_aiming_display(position_y - 1);
                        Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                        Console.WriteLine("position x [1-10]: ");
                        string x_string = Console.ReadLine().Trim();
                        int x_int;
                        if (x_string.Length <= 2 && int.TryParse(x_string, out x_int))
                        {
                            Console.Clear();
                            board.board_display();
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
                        }
                        else
                        {
                            Console.Clear();
                            board.board_display();
                            Console.WriteLine("(Wrong value!)");
                            Console.ReadKey();
                        }
                    }
                    while (true);

                    
                    if(checking_for_space(board.fields, position_x, position_y, size, rotation) == true)
                    {
                        valid_ship = true;
                        Console.WriteLine("Ships are collyding! Try again. Press anything");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        valid_ship = false;
                    }

                } while(valid_ship);
                
                {
                    player.alive_ships[q - 1] += 1;
                    player.list_of_ships.Add(new Ship(name, size, rotation, position_x, position_y));
                    menager.adding_ship_to_BattleField(board.fields, player.list_of_ships[z].ship_x, player.list_of_ships[z].ship_y, player.list_of_ships[z].ship_lenght, player.list_of_ships[z].ship_direction);
                    z++;
                    Console.Clear();
                    board.board_display();
                }
            
            }



        }

        public bool checking_for_space(int[,] array, int x, int y, int size, bool rotation)
        {
            int[,] ships_fields = new int[11, 11];

            adding_ship_to_BattleField(ships_fields, x, y, size, rotation);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    if (array[i, j] == 1 && ships_fields[i, j] == 1)
                    {
                        Console.WriteLine("Colision ship to ship");

                        return true;
                    }
                    if (array[i, j] == 2 && ships_fields[i, j] == 1)
                    {
                        Console.WriteLine("Colision side to ship");
                        return true;
                    }
                    if (array[i, j] == 1 && ships_fields[i, j] == 3)
                    {
                        Console.WriteLine("Colision ship to corner");
                        return true;
                    }

                }
            }
            return false;
        }

        public void adding_ship_to_BattleField(int[,] array, int ship_x, int ship_y, int ship_lenght, bool ship_direction)
        {
            int x = ship_x;
            int y = ship_y;

            //horizontal
            if (ship_direction == false)
            {
                int prow = x - 1;
                int stern = ship_lenght + x;

                for (int i = prow; i < stern - 1; i++)
                {
                    array[y - 1, i] = 1;

                    if (y != 1) { array[y - 2, i] = 2; }
                    if (y != 10) { array[y, i] = 2; }
                    if (prow != 0) { array[y - 1, prow - 1] = 2; }
                    if (stern <= 10) { array[y - 1, stern - 1] = 2; }
                    // corners
                    if (prow != 0 && y != 1) { array[y - 2, prow - 1] = 3; }        //left_up
                    if (prow != 0 && y != 10) { array[y, prow - 1] = 3; }           //left_down
                    if (stern <= 10 && y != 1) { array[y - 2, stern - 1] = 3; }     //right_up
                    if (stern <= 10 && y != 10) { array[y, stern - 1] = 3; }        //right_down
                }
            }//vertical
            else if (ship_direction == true)
            {
                int prow = y - 1;
                int stern = ship_lenght + prow;

                for (int j = prow; j < stern; j++)
                {
                    array[j, x - 1] = 1;

                    if (x != 1) { array[j, x - 2] = 2; }                            //left
                    if (x != 10) { array[j, x] = 2; }                               //right
                    if (prow != 0) { array[prow - 1, x - 1] = 2; }                  //top
                    if (stern < 10) { array[stern, x - 1] = 2; }                    //down
                                                                                    // corners

                    if (prow != 0 && x != 1) { array[prow - 1, x - 2] = 3; }        //left_up
                    if (prow != 0 && x != 10) { array[prow - 1, x] = 3; }           //right_up
                    if (stern < 10 && x != 1) { array[stern, x - 2] = 3; }          //left_down
                    if (stern < 10 && x != 10) { array[stern, x] = 3; }             //right_down

                }
            }
        }

    }






}
