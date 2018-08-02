using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Task2 : Task1
    {

        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            int result = 0;
            int maxDistance = 0;
            foreach (var item in _steps)
            {
                Check(item);
                int x = 0, y = 0;
                y += _n;
                y += _ne;
                x += _ne;
                x += _se;

                x = Math.Abs(x);
                y = Math.Abs(y);

                var min = x >= y ? y : x;
                x -= min;
                y -= min;

                var tmp = min + (x >= y ? x : y);
                if (tmp > maxDistance)
                    maxDistance = tmp;
            }

            result = maxDistance;
            return result;
        }
    }
}
