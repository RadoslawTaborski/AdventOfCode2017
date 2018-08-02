using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Task1
    {
        protected int _sequence;
        protected int _circle;
        protected int[] _directions={1,3,5,7};

        public Task1(String sequence)
        {
            _sequence = Int32.Parse(sequence);
        }

        private void SetCircle()
        {
            var tmp = _sequence - 1;
            for (var i = 1; tmp > 0; ++i)
            {
                tmp -= i * 8;
                _circle = i;
            }
        }

        private int GetNumber()
        {
            var result = 2;
            for (var i = 1; i <_circle; ++i)
            {
                result += i * 8;
            }
            return result;
        }

        private int GetNumberByDirection(int direction)
        {
            var result = direction+1;
            for (var i = 1; i < _circle; ++i)
            {
                result += direction+i * 8;
            }
            return result;
        }

        public int Result()
        {
            int result = 0;
            SetCircle();
            var tmp = GetNumber();
            var tmp2 = _sequence - tmp;
            var tmp3 = 8 * _circle-1;

            var tmp4 = new List<int>();
            foreach (var item in _directions)
            {
                tmp4.Add(Math.Abs(GetNumberByDirection(item)-_sequence));
            }
            result = _circle + tmp4.Min();

            return result;            
        }
    }
}
