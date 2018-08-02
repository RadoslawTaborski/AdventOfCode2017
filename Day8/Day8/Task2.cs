using System;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Task2 : Task1
    {

        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            var maxItem = _registers.MaxBy(i => i.Value);
            var max = maxItem.Value;
            int result = 0;

            foreach (var item in _operations)
            {
                item.Calculate();
                if (item._A.Value > max)
                    max = item._A.Value;
            }
            
            result = max;

            return result;
        }
    }
}
