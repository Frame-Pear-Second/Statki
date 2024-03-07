using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Ship
    {
        public string ship_class;
        public int ship_lenght;
        public bool ship_direction;
        public int ship_x;
        public int ship_y;
        public int ship_lives;

        public Ship(string ship_class, int ship_lenght, bool ship_direction, int ship_x, int ship_y)
        {
            this.ship_class = ship_class;
            this.ship_lenght = ship_lenght;
            this.ship_direction = ship_direction;
            this.ship_x = ship_x;
            this.ship_y = ship_y;
            this.ship_lives = ship_lenght;
        }

        public void ship_describe()
        {
            Console.WriteLine();
            Console.WriteLine($"HP: {ship_lives}");
            Console.WriteLine($"Lenght of ship: {ship_lenght}");
            Console.WriteLine($"X: {ship_x}");
            Console.WriteLine($"Y: {ship_y}");
        }
    }
}
