using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Task1
    {
        protected List<int> _array;
        public Task1(String text)
        {
            _array = new List<int>();
            StringReader sr = new StringReader(text);
            while (true)
            {
                var line = sr.ReadLine();
                if (line != null)
                {
                    _array.Add(Int32.Parse(line));
                }
                else
                {
                    break;
                }
            }
        }

        public int Result()
        {
            int result = 0;

            for(var i=0; i < _array.Count();)
            {
                var tmp = i;
                i += _array[i];
                IncrementItem(tmp, 1);
                ++result;
            }

            return result;
        }

        protected void IncrementItem(int index, int value)
        {
            _array[index]+=value;
        }
    }
}
