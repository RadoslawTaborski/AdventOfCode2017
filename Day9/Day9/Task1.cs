using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Task1
    {
        protected String _sequence;
        public Task1(String text)
        {
            _sequence = text;
        }

        public int Result()
        {
            int result = 0;
            int groupStart = 0;

            for(var i=0; i < _sequence.Length; ++i)
            {
                if (_sequence[i] == '{')
                {
                    groupStart++;
                }
                if (_sequence[i] == '}')
                {
                    groupStart--;
                    result += groupStart + 1;
                }
                if (_sequence[i] == '<')
                {
                    for(var j=1; ; ++j)
                    {
                        if(_sequence[i+j] == '!')
                        {
                            ++j;
                            continue;
                        }
                        if (_sequence[i + j] == '>')
                        {
                            i += j;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
