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

            Game test_round = new Game();
            test_round.phase_1();
            test_round.phase_2();

            Console.ReadLine();
        }
    }
}
