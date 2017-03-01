using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fifteen
{
    class Game
    {
        public int[,] Field;
        private int zeroX;
        private int zeroY;

        public Dictionary<int, Coordinate> Dictionary = new Dictionary<int, Coordinate>();

        public Game(params int[] values)
        {
            bool zero = false;
            int count = 0;

            int size = (int)Math.Sqrt(values.Length);

            if (values.Length != Math.Pow(size, 2) || (values.Length % 2 == 0))
            {
                throw new ArgumentException("Поле не соответстует правилам");
            }

            if (!CheckUnique(values))
            {
                throw new ArgumentException("Значения не уникальны");
            }

            if (CheckNegative(values))
            {
                throw new ArgumentException("Отрицательное число");
            }

            this.Field = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (values[count] == 0)
                    {
                        zero = true;
                        zeroX = i;
                        zeroY = j;
                        Field[i, j] = values[count];
                        Dictionary.Add(count, new Coordinate(i, j));
                        count++;
                    }
                    else
                    {
                        Field[i, j] = values[count];
                        Dictionary.Add(count, new Coordinate(i, j));
                        count++;
                    }

                }
            }

            if (!zero) throw new ArgumentException("Отсутствует пустое  поле");
        }

        public int this[int i, int j]
        {
            get
            {
                return Field[i, j];
            }
            set
            {
                Field[i, j] = value;
            }
        }

        private Coordinate GetLocation(int value)
        {
            if ((value < Math.Pow(value, 2) - 1) && (value > 0))
            {
                return Dictionary[value];
            }
            else throw new ArgumentException("Числа " + value + " не существует");
        }

        public void Shift(int value)
        {
            if (Dictionary[value] - Dictionary[0] == 1)
            {
                Coordinate positionZero = Dictionary[0];
                this[Dictionary[0].X, Dictionary[0].Y] = value;
                this[Dictionary[value].X, Dictionary[value].Y] = 0;
                Dictionary[0] = Dictionary[value];
                Dictionary[value] = positionZero;
            }
            else
            {
                throw new ArgumentException("Невозможно передвинуть фишку");
            }
        }

        private bool CheckUnique(int[] mass)
        {
            int temp;
            for (int i = 0; i < mass.Length; i++)
            {
                temp = mass[i];
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[j] == temp)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckNegative(int[] values)
        {
            foreach (int i in values)
            {
                return values[i] < 0;
            }
            return true;
        }

        public static Game ReadCSV(string file)
        {
            string[] Lines = File.ReadAllLines(file);
            int[] elem = new int[Lines.Length];

            for (int i = 0; i < Lines.Length; i++)
            {
                string s = Lines[i];
                string[] substring = s.Split(';');
                elem[i] = Convert.ToInt32(substring[i]);
            }
            return new Game(elem);
        }
    }

}
