using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Task2 : Task1
    {

        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            int result = 0;
            int groupStart = 0;

            for (var i = 0; i < _sequence.Length; ++i)
            {
                if (_sequence[i] == '{')
                {
                    groupStart++;
                }
                if (_sequence[i] == '}')
                {
                    groupStart--;
                }
                if (_sequence[i] == '<')
                {
                    for (var j = 1; ; ++j)
                    {
                        if (_sequence[i + j] == '!')
                        {
                            ++j;
                            continue;
                        }
                        if (_sequence[i + j] == '>')
                        {
                            i += j;
                            break;
                        }
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
