using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Task1
    {
        protected List<KeyVal<String, int>> _registers;
        protected List<Operation> _operations;
        public Task1(String text)
        {
            _registers = new List<KeyVal<String, int>>();
            _operations = new List<Operation>();

            var sr = new StringReader(text);
            while (true)
            {               
                var line = sr.ReadLine();
                if (line == null)
                    break;
                var tab=line.Split(' ');
                
                if (_registers.Where(i => (i.Name == tab[0])).Count() == 0)
                {
                    _registers.Add(new KeyVal<String, int>(tab[0], 0));
                }
                var a = _registers.Where(i => (i.Name == tab[0])).ElementAt(0);
                var b = tab[1];
                var c = Int16.Parse(tab[2]);
                
                if (_registers.Where(i => (i.Name == tab[4])).Count() == 0)
                {
                    _registers.Add(new KeyVal<String, int>(tab[4], 0));
                }
                var d = _registers.Where(i => (i.Name == tab[4])).ElementAt(0);
                var e = tab[5];
                var f = Int16.Parse(tab[6]);

                _operations.Add(new Operation(a, b, c, d, e, f));
            }
        }

        public int Result()
        {
            int result = 0;

            foreach(var item in _operations)
            {
                item.Calculate();
            }

            var max = _registers.MaxBy(i => i.Value);
            result = max.Value;

            return result;
        }
    }
}
