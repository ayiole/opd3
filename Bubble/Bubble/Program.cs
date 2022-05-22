using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Bubbles
{
    public class Bubble
    {
        private int[,] _matrix;
        private IStrategy _strategy;
        private bool _isAscending;


        public Bubble(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;

        }

        public void SetAscending(bool _isAscending)
        {
            this._isAscending = _isAscending;
        }

        public void ShowResult()
        {
            Console.WriteLine("Результат:");

            int[,] result = (int[,])this._strategy.DoneStrategy(_matrix, _isAscending);

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public Bubble()
        {
            _matrix = new int[4, 4];
        }

        public Bubble(int[,] mtrx)
        {
            _matrix = mtrx;
        }

        public Bubble(int size)
        {
            _matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        public Bubble(int row, int column)
        {
            _matrix = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        public int Rows => _matrix.GetLength(0);

        public int Columns => _matrix.GetLength(1);

        public int this[int i, int j]
        {
            get { return _matrix[i, j]; }

            set { _matrix[i, j] = value; }
        }

        public int[,] GetMatrix => _matrix;

    }

    public delegate int CheckStrategy(int temp, int mtrx);

    public interface IStrategy
    {
        public object DoneStrategy(object data, bool _isAscending);

        public static object DoStrategy(object data, bool _isAscending, CheckStrategy CheckStrategy)
        {
            int[,] matrix = data as int[,];
            int[] sum = new int[matrix.GetLength(0)];
            int[] id = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum[i] = matrix[i, 0];
                id[i] = i;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum[i] = CheckStrategy(sum[i], matrix[i, j]);
                }
            }
            for (int i = 0; i + 1 < matrix.GetLength(0); i++)
            {
                for (int j = 0; j + 1 < matrix.GetLength(0) - i; j++)
                {
                    if (((sum[j + 1] < sum[j]) && _isAscending) || ((sum[j + 1] > sum[j]) && !_isAscending))
                    {
      
                        (sum[j], sum[j + 1]) = (sum[j + 1], sum[j]);
                        (id[j], id[j+1]) = (id[j + 1], id[j]);
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (id[i] != i)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[id[i], j], matrix[id[id[i]], j]) = (matrix[id[id[i]], j], matrix[id[i], j]);
                    }

                    (id[i], id[id[i]]) = (id[id[i]], id[i]);

                    i--;
                }
            }
            return matrix;
        }
    }
    public class SumElementsRows : IStrategy
    {
        public object DoneStrategy(object data, bool _isAscending)
        {
            return IStrategy.DoStrategy(data, _isAscending, TempAction);
        }

        public static int TempAction(int temp, int mtrx)
        {
            return temp += mtrx;
        }
    }

    public class MaxElementRow : IStrategy
    {
        public object DoneStrategy(object data, bool _isAscending)
        {
            return IStrategy.DoStrategy(data, _isAscending, TempAction);
        }

        public static int TempAction(int temp, int mtrx)
        {
            if (temp < mtrx)
            {
                return mtrx;
            }
            return temp;
        }
    }

    public class MinElementRow : IStrategy
    {
        public object DoneStrategy(object data, bool _isAscending)
        {
            return IStrategy.DoStrategy(data, _isAscending, TempAction);
        }

        public static int TempAction(int temp, int mtrx)
        {
            if (temp > mtrx)
            {
                return mtrx;
            }
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();

            Bubble mtrx = new Bubble(4, 7);

            for (int i = 0; i < mtrx.Rows; i++)
            {
                for (int j = 0; j < mtrx.Columns; j++)
                {
                    mtrx[i, j] = rnd.Next(20);
                }
            }

            Console.WriteLine("Заданная матрица:");
            for (int i = 0; i < mtrx.Rows; i++)
            {
                for (int j = 0; j < mtrx.Columns; j++)
                {
                    Console.Write(mtrx[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("1. В порядке возрастания сумм элементов строк матрицы\n2. В порядке убывания сумм элементов строк матрицы\n3. По возрастанию максимального элемента в строке матрицы\n4. По убыванию максимального элемента в строке матрицы\n5. В порядке возрастания  минимального элемента в строке матрицы\n6. В порядке убывания минимального элемента в строке матрицы");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    mtrx.SetStrategy(new SumElementsRows());
                    mtrx.SetAscending(true);
                    mtrx.ShowResult();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    mtrx.SetStrategy(new SumElementsRows());
                    mtrx.SetAscending(false);
                    mtrx.ShowResult();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    mtrx.SetStrategy(new MaxElementRow());
                    mtrx.SetAscending(true);
                    mtrx.ShowResult();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    mtrx.SetStrategy(new MaxElementRow());
                    mtrx.SetAscending(false);
                    mtrx.ShowResult();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    mtrx.SetStrategy(new MinElementRow());
                    mtrx.SetAscending(true);
                    mtrx.ShowResult();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    mtrx.SetStrategy(new MinElementRow());
                    mtrx.SetAscending(false);
                    mtrx.ShowResult();
                    break;
                default:
                    Console.WriteLine("Нет выбора");
                    break;
            }
        }
    }
}