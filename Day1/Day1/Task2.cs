using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Task2: Task1
    {
        protected int _step;

        public Task2(string sequence): base(sequence)
        {
            _step = _sequence.Length / 2;
        }

        public int GetDigitAfterStep(int actual)
        {
            return Int32.Parse(_sequence.ElementAt(actual+_step).ToString());
        }

        public new int Result()
        {
            int result = 0;

            for (var i = 0; i < _step; ++i)
            {
                if (GetDigit(i) == GetDigitAfterStep(i))
                {
                    result += 2*GetDigit(i);
                }
            }
            return result;
        }
    }
}
