using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Task2 : Task1
    {
        protected static int size = 51; //nieparzysta
        int[,] array = new int[size, size];
        int center = size / 2;

        public Task2(String text) : base(text)
        {
            array[center, center] = 1;
            var circle = 0;
            var row = center;
            var col = center;
            var nr = 1;

            for (var i = 1; i < size*size; ++i)
            {
                nr++;
                var tuple = getNext(row, col, circle, center);
                circle = tuple.Item3;
                row = tuple.Item1;
                col = tuple.Item2;
                array[row, col] = SumOfNeighbour(row,col);
            }
            //Display();
        }

        protected int SumOfNeighbour(int row, int col)
        {
            int result = 0;
            for(var i = -1; i <= 1; ++i)
            {
                for (var j = -1; j <= 1; ++j)
                {
                    if((row+i)<size && (row + i) >=0 && (col + j < size) && (col + j) >= 0)
                        result += array[row + i, col + j];
                }
            }
            return result;
        }

        protected Tuple<int, int, int> getNext(int row, int col, int circle, int center)
        {
            if (row == center + circle)
            {
                if (col == center + circle)
                {
                    return new Tuple<int, int, int>(row, ++col, ++circle);
                }
                return new Tuple<int, int, int>(row, ++col, circle);
            }
            if (row == center - circle)
            {
                
                if (col == center - circle)
                {
                    return new Tuple<int, int, int >(++row, col,circle);
                }
                return new Tuple<int, int,int>(row, --col, circle);
            }
            if (col == center - circle)
            {
                if (row == center + circle)
                {
                    return new Tuple<int, int, int>(row, ++col, circle);
                }
                return new Tuple<int, int,int>(++row, col,circle);
            }
            if (col == center + circle)
            {
                if (row == center - circle)
                {
                    return new Tuple<int, int,int>(row, --col,circle);
                }
                return new Tuple<int, int,int>(--row, col,circle);
            }
            return new Tuple<int, int,int>(center, center,circle);
        }

        public new int Result()
        {
            int result = 0;
            var circle = 0;
            var row = center;
            var col = center;

            for (var i = 1; i < size * size; ++i)
            {
                var tuple = getNext(row, col, circle, center);
                circle = tuple.Item3;
                row = tuple.Item1;
                col = tuple.Item2;
                if (array[row, col] > _sequence)
                {
                    result = array[row, col];
                    break;
                }
            }
            return result;
        }

        public void Display()
        {
            Console.Write("\n");
            for (var i = 0; i < size; ++i)
            {
                for (var k = 0; k < size; ++k)
                {
                    Console.Write(array[i, k]);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
        }
    }
}
