using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Task1
    {
        protected String _sequence;

        public Task1(string sequence)
        {
            _sequence = sequence;
        }

        public int Result()
        {
            int result = 0;

            for(var i=0; i < _sequence.Length; ++i)
            {
                if (GetDigit(i) == GetNextDigit(i))
                {
                    result += GetDigit(i);
                }
            }
            return result;
        }

        protected int GetNextDigit(int index)
        {
            if(index<_sequence.Length-1)
                return Int32.Parse(_sequence.ElementAt(index+1).ToString());
            else
                return Int32.Parse(_sequence.ElementAt(0).ToString());
        }

        protected int GetDigit(int index)
        {
            return Int32.Parse(_sequence.ElementAt(index).ToString());
        }
    }
}
