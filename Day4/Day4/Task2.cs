using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Task2 : Task1
    {

        public Task2(String str) : base(str)
        {

        }

        public new int Result()
        {
            int result = 0;

            foreach (var item in _passwords)
            {
                if (item.IsTrue2())
                {
                    ++result;
                }
            }
            return result;
        }
    }
}
