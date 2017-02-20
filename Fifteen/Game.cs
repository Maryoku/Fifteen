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

                        //Console.WriteLine("{0} {1}", i, j);
                    }
                }
            }

        }

        public void Shift(int value)
        {
            int size = (int)Math.Sqrt(field.Length);
            int tmp, i, j;

            GetLocation(value, out i, out j);

            if ((j+1 <= size - 1) && (field[i, j+1] == 0))
            {
                tmp = field[i, j];
                field[i, j] = field[i, j + 1];
                field[i, j + 1] = tmp;

                for (int m = 0; m < size; m++)
                {
                    for (int n = 0; n < size; n++)
                    {
                        Console.Write("{0} ", field[m, n]);
                    }
                    Console.Write("\n");
                }
            }
            else if ((j-1 >= 0) && (field[i, j-1] == 0))
            {
                tmp = field[i, j];
                field[i, j] = field[i, j - 1];
                field[i, j - 1] = tmp;

                for (int m = 0; m < size; m++)
                {
                    for (int n = 0; n < size; n++)
                    {
                        Console.Write("{0} ", field[m, n]);
                    }
                    Console.Write("\n");
                }
            }
            else if ((i+1 <= size-1) && (field[i+1, j] == 0))
            {
                tmp = field[i, j];
                field[i, j] = field[i + 1, j];
                field[i + 1, j] = tmp;

                for (int m = 0; m < size; m++)
                {
                    for (int n = 0; n < size; n++)
                    {
                        Console.Write("{0} ", field[m, n]);
                    }
                    Console.Write("\n");
                }
            }
            else if ((i-1 >= 0) && (field[i-1, j] == 0))
            {
                tmp = field[i, j];
                field[i, j] = field[i-1, j];
                field[i-1, j] = tmp;

                for (int m = 0; m < size; m++)
                {
                    for (int n = 0; n < size; n++)
                    {
                        Console.Write("{0} ", field[m, n]);
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("Can't move!");
            }
        }
    }
}
