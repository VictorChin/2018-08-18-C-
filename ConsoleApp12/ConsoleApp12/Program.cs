using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Action<int, int>> e = 
                (int x, int y) => Console.WriteLine($"{x+y}");
            e.Compile().Invoke(10, 20);
            Console.WriteLine("Stop");
        }
    }
}
