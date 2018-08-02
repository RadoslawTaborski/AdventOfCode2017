using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Task2 : Task1
    {

        public Task2(String text) : base()
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            foreach (var item in asciiBytes)
            {
                _sequence.Add(Int16.Parse(item.ToString()));
            }
            _sequence.Add(17);
            _sequence.Add(31);
            _sequence.Add(73);
            _sequence.Add(47);
            _sequence.Add(23);
        }

        public new String Result()
        {
            String result = "";
            int position = 0;
            int skipSize = 0;
            for (var j = 0; j < 64; ++j)
                for (var i = 0; i < _sequence.Count; ++i)
                {
                    Reverse(position, _sequence[i]);
                    position += _sequence[i];
                    position += skipSize;
                    skipSize++;
                }

            var hashes = new List<int>();

            for (var i = 0; i < 16; ++i)
            {
                var tmp = _chain.GetRange(16 * i, 16);
                hashes.Add(Hash(tmp));
            }

            foreach (var item in hashes)
            {
                var tmp = string.Format("{0:x}", item);
                if (tmp.Length == 1)
                {
                    result += "0" + tmp;
                }
                else
                    result += string.Format("{0:x}", item);
                // Console.WriteLine(result);
            }

            return result;
        }

        protected int Hash(List<int> input)
        {
            var result = input[0];
            for (var i = 1; i < input.Count(); ++i)
            {
                result ^= input[i];
            }
            return result;
        }
    }
}
