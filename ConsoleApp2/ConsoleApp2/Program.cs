using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 300;
            int balance = 1000;
            int amount = 500;
            int oldBalance;
            Deposit(ref balance, amount,out oldBalance);
            Console.WriteLine($"balance is now {balance}, it was {oldBalance}");

            int result=0;
            try {  result= Add(y: input); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.TargetSite.Name);
            }
            
            Console.WriteLine(input);
            Console.WriteLine(result);
            result = Add(100, 200,300);
            Console.WriteLine(result);
            string result2 = Add(5, "hello");
            Console.WriteLine(result2);
            Console.ReadLine();
        }

        private static void Deposit(ref int balance, int amount,out int prevBalance)
        {
            prevBalance = balance;
            balance+=amount;
        }

        static int Add(int x=200, int y=100)
        {
            try
            {
                ChildAdd(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("this is out of range");
                throw new ExecutionEngineException("yo",ex);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("bad argument");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown exception has occurred, press any key....lolz");
            }
            y = y + y;
            return x + y;
            
        }

        private static void ChildAdd(int x)
        {
            switch (x)
            {
                case 1:
                    throw new Exception();
                case 2:
                    throw new ArgumentException();
                case 3:
                    throw new ArgumentOutOfRangeException();
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        static string Add(int x, string y)
        {
            return x.ToString() + y;
        }
        static int Add(int x, int y,int z)
        {
            return x + y+ z;
        }

    }
}
