using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int i, int j)
        {
            this.X = i;
            this.Y = j;
        }

        public static double operator -(Coordinate a, Coordinate b)
        {
            return Math.Sqrt(Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.X - b.X, 2));
        }
    }
}
