using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Car aCar = new Car();
            aCar.LowOnGas += OpFactory(1);
            aCar.LowOnGas += OpFactory(2);
            aCar.LowOnGas += OpFactory(3);
            aCar.LowOnGas += OpFactory(4);
            aCar.DoSomething();
            Console.ReadLine();
        }

        static Op OpFactory(int x)
        {
            switch (x)
            {
                case 1:
                    return (a, b) =>
                    {
                        Console.WriteLine("Case 1:"+x);
                        return a + b + x; };
                case 2:
                    return (a, b) =>
                    {
                        Console.WriteLine("Case 2:" + x); return a - b - x;
                    };
                default:
                    return (a, b) =>
                    {
                        Console.WriteLine("Case 3:" + x); return a * b * x;
                    };
            }
        }

        static void TestBob(Op d)
        {
            Console.WriteLine(d(10, 20));
        }
  
    }
    delegate int Op(int x, int y);

    class Car
    {
        public event Op LowOnGas;

        internal void DoSomething()
        {
            Thread.Sleep(500);
          
                int? result = LowOnGas?.Invoke(5,10);
                Console.WriteLine(result);
            
        }
    }
    
}
