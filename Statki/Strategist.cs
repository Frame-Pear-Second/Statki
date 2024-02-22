using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Strategist
    {
        public void ship_deploy(int[,] array, Ship ship)
        {
            int x = ship.ship_x;
            int y = ship.ship_y;

            //horizontal
            if(ship.ship_direction == false )
            {
                int prow = x--;
                int stern = ship.ship_lenght + x;

                for (int i = prow; i <= stern ; i++)
                {
                    array[y-1, i] = 1;
                }
            }//vertical
            else if (ship.ship_direction == true )
            {
                int prow = y--;
                int stern = ship.ship_lenght + y;

                for (int j = y; j < stern; j++)
                {
                    array[j, x-1] = 1;
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

            for(int i = 1; i <= q; i++)
            {
                do
                {
                    Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                    Console.WriteLine("rotation [h/v]: ");
                    rotation = bool.Parse(Console.ReadLine());
                    if (rotation == true || rotation == false) { break; }
                    Console.Clear();
                } 
                while (true);

                Console.Clear();
                do
                {
                    Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                    Console.WriteLine("position y [a-j]: ");
                    position_y = char.Parse(Console.ReadLine()) - char.Parse("a") + 1;
                    if (position_y >= 1 && position_y <= 10) { break; }
                    Console.Clear();
                } 
                while (true);

                Console.Clear();
                do
                {
                    Console.WriteLine($"{name}-masetd ship [{i}/{q}]");
                    Console.WriteLine("position x [1-10]: ");
                    position_x = int.Parse(Console.ReadLine());
                    if (position_x >= 1 && position_x <= 10) { break; }
                    Console.Clear();
                }
                while (true);

                player.alive_ships[q - 1] += 1;
                player.list_of_ships.Add(new Ship(name, size, rotation, position_x, position_y)); 

                

                
                

                }
            }
        }

        

    
}
