using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Task1
    {
        protected List<Password>_passwords;
        public Task1(String text)
        {
            _passwords = new List<Password>();
            var sr = new StringReader(text);

            while (true)
            {
                var line = sr.ReadLine();
                if (line != null)
                {
                    _passwords.Add(new Password(line));
                }
                else
                {
                    break;
                }
            }
        }

        public int Result()
        {
            int result = 0;

            foreach(var item in _passwords)
            {
                if (item.IsTrue())
                {
                    ++result;
                }
            }

            return result;
        }
    }
}
