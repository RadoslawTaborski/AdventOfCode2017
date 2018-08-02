using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Task1
    {
        protected readonly int size = 16;
        protected int[] _banks;
        protected List<int[]> _history;
        public Task1(String text)
        {
            _banks = new int[size];
            _history = new List<int[]>();
            var tmp = text.Split('\t');
            for(var i=0; i<size; ++i)
            {
                _banks[i] = Int32.Parse(tmp[i]);
            }
        }

        public int Result()
        {
            int result = 0;
            while (true)
            {
                result++;
                var index = FindIndexOfMaxFromArray(_banks);
                var value = _banks[index];
                _banks[index] = 0;
                for (var i=1; i <= value; ++i)
                {
                    _banks[GetIndexInCircleArray(index+i)]++;
                }
                if (IsBanksInHistory(_banks))
                {
                    break;
                }
                var tmp= new int[size];
                _banks.CopyTo(tmp, 0);
                _history.Add(tmp);
            }

            return result;
        }

        protected Boolean TheSameArrays(int[] A, int[] B)
        {
            for(var i=0; i<size; ++i)
            {
                if (A[i] != B[i])
                    return false;
            }
            return true;
        }

        protected Boolean IsBanksInHistory(int[] A)
        {
            for(var i=0; i<_history.Count; ++i)
            {
                if (TheSameArrays(A, _history[i]))
                {
                    return true;
                }
            }

            return false;
        }

        protected int FindIndexOfMaxFromArray(int[] A)
        {
            var max = A.Max();
            var index = Array.IndexOf(A,max);
            return index;
        }

        protected int GetIndexInCircleArray(int value)
        {
            while (value >= size)
            {
                value -= size;
            }

            return value;
        }
    }
}
