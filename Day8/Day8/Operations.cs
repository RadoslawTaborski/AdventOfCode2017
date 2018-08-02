using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    static public class Operations
    {
        public static Boolean LogicOperation(int a, String operation, int b)
        {
            switch (operation)
            {
                case LogicalOperations.Bigger:
                    {
                        if (a > b)
                            return true;
                        else
                            return false;
                    }
                case LogicalOperations.BiggerEqual:
                    {
                        if (a >= b)
                            return true;
                        else
                            return false;
                    }
                case LogicalOperations.Smaller:
                    {
                        if (a < b)
                            return true;
                        else
                            return false;
                    }
                case LogicalOperations.SmallerEgual:
                    {
                        if (a <= b)
                            return true;
                        else
                            return false;
                    }
                case LogicalOperations.Equal:
                    {
                        if (a == b)
                            return true;
                        else
                            return false;
                    }
                case LogicalOperations.NotEqual:
                    {
                        if (a != b)
                            return true;
                        else
                            return false;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public static int MathOperation(int a, String operation, int b)
        {
            switch (operation)
            {
                case MathOperations.Increment:
                    {
                        return a + b;
                    }
                case MathOperations.Decrement:
                    {
                        return a - b;
                    }
                default:
                    {
                        return a;
                    }
            }
        }
    }

    public class Operation
    {
        public KeyVal<String, int> _A { get; }
        String _oper;
        int _B;
        Condition _Con;

        public Operation(KeyVal<String, int> A1, String oper1, int B1, KeyVal<String, int> A2, String oper2, int B2)
        {
            _A = A1;
            _oper = oper1;
            _B = B1;
            _Con = new Condition(A2, oper2, B2);
        }

        public void Calculate()
        {
            if (_Con.IsTrue())
            {
                var result = Operations.MathOperation(_A.Value, _oper, _B);
                _A.Value = result;
            }
        }
    }

    public class Condition
    {
        KeyVal<String, int> _A;
        String _oper;
        int _B;

        public Condition(KeyVal<String, int> A, String oper, int B)
        {
            _A = A;
            _oper = oper;
            _B = B;
        }

        public Boolean IsTrue()
        {
            if (Operations.LogicOperation(_A.Value, _oper, _B))
                return true;
            else
                return false;
        }
    }

    public class KeyVal<Key, Val>
    {
        public Key Name { get; set; }
        public Val Value { get; set; }

        public KeyVal() { }

        public KeyVal(Key key, Val val)
        {
            this.Name = key;
            this.Value = val;
        }
    }

    public static class MathOperations
    {
        public const String Increment = "inc";
        public const String Decrement = "dec";
    }

    public static class LogicalOperations
    {
        public const String Bigger = ">";
        public const String BiggerEqual = ">=";
        public const String Smaller = "<";
        public const String SmallerEgual = "<=";
        public const String Equal = "==";
        public const String NotEqual = "!=";
    }
}
