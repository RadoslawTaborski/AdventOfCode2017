using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Task1
    {
        protected int _ne;
        protected int _n;
        protected int _se;
        protected List<String> _steps;

        public Task1(String text)
        {
            _steps = new List<String>();
            var tmp=text.Split(',');
            foreach(var item in tmp)
            {
                _steps.Add(item);
            }
        }

        public int Result()
        {
            foreach (var item in _steps)
            {
                Check(item);
            }

            int result = 0;
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

            result = min + (x >= y ? x : y);

            return result;
        }

        protected void Check(String A)
        {
            switch (A)
            {
                case "ne":
                    {
                        _ne++;
                        break;
                    }
                case "n":
                    {
                        _n++;
                        break;
                    }
                case "nw":
                    {
                        --_se;
                        break;
                    }
                case "se":
                    {
                        ++_se;
                        break;
                    }
                case "s":
                    {
                        --_n;
                        break;
                    }
                case "sw":
                    {
                        --_ne;
                        break;
                    }
            }
        }
    }
}
