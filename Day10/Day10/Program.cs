using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("data.txt");
            //var task1Result = new Task1(text).Result();
            var task2Result = new Task2(text).Result();
            Console.WriteLine(task2Result);
            Console.Read();
        }
    }
}