using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Task2 : Task1
    {

        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            int result = 0;

            for (var i = 0; i < _array.Count();)
            {
                var tmp = i;
                i += _array[i];
                if(_array[tmp]>=3)
                    IncrementItem(tmp, -1);
                else
                    IncrementItem(tmp, 1);
                ++result;
            }

            return result;
        }
    }
}
