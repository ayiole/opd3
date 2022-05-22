using NUnit.Framework;
using Bubbles;

namespace BubbleTest
{
    public class Tests
    {

        [Test]
        public void SumElemRowAsc()
        {
            int[,] arr = { { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            Bubble mtrx = new Bubble(arr);

            mtrx.SetStrategy(new SumElementsRows());
            mtrx.SetAscending(true);
            mtrx.ShowResult();

            int[,] expected = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i,j], mtrx[i,j]);
                }
            } 
        }

        [Test]
        public void SumElemRowDesc()
        {
            int[,] arr = { { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            Bubble mtrx = new Bubble(arr);

            mtrx.SetStrategy(new SumElementsRows());
            mtrx.SetAscending(false);
            mtrx.ShowResult();

            int[,] expected = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], mtrx[i, j]);
                }
            }
        }

        [Test]
        public void MaxElemRowAsc()
        {
            int[,] arr = { { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            Bubble mtrx = new Bubble(arr);

            mtrx.SetStrategy(new MaxElementRow());
            mtrx.SetAscending(true);
            mtrx.ShowResult();

            int[,] expected = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 },  };

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], mtrx[i, j]);
                }
            }
        }

        [Test]
        public void MaxElemRowDesc()
        {
            int[,] arr = { { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            Bubble mtrx = new Bubble(arr);

            mtrx.SetStrategy(new MaxElementRow());
            mtrx.SetAscending(false);
            mtrx.ShowResult();

            int[,] expected = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], mtrx[i, j]);
                }
            }
        }

        [Test]
        public void MinElemRowAsc()
        {
            int[,] arr = { { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            Bubble mtrx = new Bubble(arr);

            mtrx.SetStrategy(new MinElementRow());
            mtrx.SetAscending(true);
            mtrx.ShowResult();

            int[,] expected = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], mtrx[i, j]);
                }
            }
        }

        [Test]
        public void MinElemRowDesc()
        {
            int[,] arr = { { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            Bubble mtrx = new Bubble(arr);

            mtrx.SetStrategy(new MinElementRow());
            mtrx.SetAscending(false);
            mtrx.ShowResult();

            int[,] expected = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], mtrx[i, j]);
                }
            }
        }
    }
}
