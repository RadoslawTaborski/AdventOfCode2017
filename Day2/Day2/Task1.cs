using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Task1
    {
        protected List<List<int>> _sequences;

        public Task1(String text)
        {
            _sequences = new List<List<int>>();
            var sr = new StringReader(text);
            while (true)
            {
                var line=sr.ReadLine();
                if (line != null)
                {
                    _sequences.Add(getNumbersList(line));
                }
                else
                {
                    break;
                }
            }
        }

        protected List<int> getNumbersList(String line)
        {
            List<int> result=new List<int>();
            var ints= line.Split();
            foreach(var item in ints)
            {
                result.Add(Int32.Parse(item));
            }
            return result;
        }

        public void Display()
        {
            Console.WriteLine();
            foreach(var list in _sequences)
            {
                foreach(var item in list)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }       
        }

        public int Result()
        {
            int result = 0;
            foreach(var line in _sequences)
            {
                var max = GetMax(line);
                var min = GetMin(line);

                result += (max - min);
            }
            return result;
        }

        protected int GetMax(List<int> list)
        {
            return list.Max();
        }

        protected int GetMin(List<int> list)
        {
            return list.Min();
        }
    }
}
