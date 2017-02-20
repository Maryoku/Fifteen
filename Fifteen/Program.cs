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
            Game fifteen = new Game(1, 2, 3, 0, 4, 5, 6, 7, 8);

            //int x, y;
            //fifteen.GetLocation(2, out x, out y);

            fifteen.Shift(4);
            Console.Write("\n");
            fifteen.Shift(2);
            Console.Write("\n");
            fifteen.Shift(3);
            Console.Write("\n");
            fifteen.Shift(5);
            Console.Write("\n");
            fifteen.Shift(4);
        }
    }
}
