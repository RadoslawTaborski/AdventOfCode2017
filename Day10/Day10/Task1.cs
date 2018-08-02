using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Task1
    {
        protected List<int> _chain;
        protected List<int> _sequence;
        protected const int SIZE = 256;
        public Task1(String text)
        {
            _sequence = new List<int>();
            _chain = new List<int>();
            for (var i = 0; i < SIZE; ++i)
            {
                _chain.Add(i);
            }
            var tmp = text.Split(',');
            foreach (var item in tmp)
            {
                _sequence.Add(Int32.Parse(item));
            }
        }

        protected Task1()
        {
            _sequence = new List<int>();
            _chain = new List<int>();
            for (var i = 0; i < SIZE; ++i)
            {
                _chain.Add(i);
            }
        }

        public int Result()
        {
            int result = 0;
            int position = 0;
            int skipSize = 0;

            for(var i=0; i < _sequence.Count; ++i)
            {                
                Reverse(position, _sequence[i]);
                position += _sequence[i];
                position += skipSize;
                skipSize++;
            }

            result = _chain[0] * _chain[1];

            return result;
        }

        protected void Reverse(int position, int count)
        {
            var index = GetIndexOfCircleList(position);

            List<int> sublist;
            if (index + count < _chain.Count)
            {
                sublist = _chain.GetRange(index, count);
            }
            else
            {
                sublist = _chain.GetRange(index, _chain.Count - index);

                sublist.AddRange(_chain.GetRange(0, count - (_chain.Count - index)));
            }

            sublist.Reverse();

            for (var i = 0; i < sublist.Count; ++i)
            {
                _chain[GetIndexOfCircleList(index + i)] = sublist[i];
            }

        }

        protected int GetIndexOfCircleList(int position)
        {
            while (true)
            {
                if (position < _chain.Count)
                    return position;
                position -= _chain.Count;
            }
        }

        protected void Display(List<int> a)
        {
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
