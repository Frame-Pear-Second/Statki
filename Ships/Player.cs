using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Player
    {
        public int name;
        public int wins;
        public List<Ship> list_of_ships = new List<Ship>();
        public Player(int name) { this.name = name; }
    }
}
