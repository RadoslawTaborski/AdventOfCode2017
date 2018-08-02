using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Task2 : Task1
    {
        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            int result = 0;
            foreach (var list in _sequences)
            {
                var tuple = GetDivisorAndDividend(list);
                result += (tuple.Item1 / tuple.Item2);
            }
            return result;
        }

        protected Tuple<int, int> GetDivisorAndDividend(List<int> list)
        {
            int a=0, b = 0;
            for(var i=0; i < list.Count; ++i)
            {
                for (var j = 0; j < list.Count; ++j)
                {
                    if (list.ElementAt(i) % list.ElementAt(j) == 0 && i!=j)
                    {
                        a = list.ElementAt(i);
                        b = list.ElementAt(j);
                    }
                }
            }
            return new Tuple<int, int>(a, b);
        }
    }
}
