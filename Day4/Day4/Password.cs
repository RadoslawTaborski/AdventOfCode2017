using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Password
    {
        List<String> _password;

        public Password(String str)
        {
            _password = str.Split(' ').ToList();
        }

        public Boolean IsTrue()
        {
            for (var i = 0; i < _password.Count; ++i)
            {
                for (var j = 0; j < _password.Count; ++j)
                {
                    if (i != j)
                    {
                        if (IsDuplicete(_password.ElementAt(i), _password.ElementAt(j)))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public Boolean IsTrue2()
        {
            for (var i = 0; i < _password.Count; ++i)
            {
                for (var j = 0; j < _password.Count; ++j)
                {
                    if (i != j)
                    {
                        if (IsAnyAnagrams(_password.ElementAt(i), _password.ElementAt(j)))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        protected Boolean IsDuplicete(String A, String B)
        {
            if (A.Equals(B))
            {
                return true;
            }

            return false;
        }

        protected Boolean IsAnyAnagrams(String A, String B)
        {
            var A1=String.Concat(A.OrderBy(c => c));
            var B1 = String.Concat(B.OrderBy(c => c));
            if (A1.Equals(B1))
            {
                return true;
            }

            return false;
        }
    }
}
