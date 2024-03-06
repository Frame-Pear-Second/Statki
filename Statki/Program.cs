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
            do
            {
                Game round = new Game();
                round.phase_1();
                round.phase_2();

            } while (true);
            
        }
    }
}
