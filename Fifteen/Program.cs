using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Game fifteen = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);

            int x, y;
            fifteen.GetLocation(2, out x, out y);
        }
    }
}
