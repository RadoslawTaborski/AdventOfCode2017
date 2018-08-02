using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Task2 : Task1
    {
        
        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            int result = 0;
            while (true)
            {
                var index = FindIndexOfMaxFromArray(_banks);
                var value = _banks[index];
                _banks[index] = 0;
                for (var i = 1; i <= value; ++i)
                {
                    _banks[GetIndexInCircleArray(index + i)]++;
                }
                if (IsBanksInHistory(_banks))
                {
                    result = _history.Count-IndexOfTheSameArray(_banks);
                    return result;
                }
                var tmp = new int[size];
                _banks.CopyTo(tmp, 0);
                _history.Add(tmp);
            }
        }

        protected int IndexOfTheSameArray(int[] A)
        {
            for (var i = 0; i < _history.Count; ++i)
            {
                if (TheSameArrays(A, _history[i]))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
