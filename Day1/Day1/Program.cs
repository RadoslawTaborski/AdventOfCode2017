using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = File.ReadAllText("data.txt");
            var task1Result = new Task1(sequence).Result();
            var task2Result = new Task2(sequence).Result();
            Console.WriteLine(task2Result);
            Console.Read();
        }
    }
}
