using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Game
    {
        public int[,] field;

        public Game(params int[] values)
        {
            int size = (int)Math.Sqrt(values.Length);

            this.field = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = values[i*size+j];
                }
            }
            
        }

        int this[int i, int j]
        {
            get
            {
                return field[i, j];
            }
        }

        public void GetLocation(int value, out int x, out int y)
        {
            int size = (int)Math.Sqrt(field.Length);
            x = 0;
            y = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j] == value)
                    {
                        x = i;
                        y = j;

                        Console.WriteLine("{0} {1}", i, j);
                    }
                }
            }

        }

        public int Shift
        {
            get
            {
                return 0;
            }
        }
    }
}
