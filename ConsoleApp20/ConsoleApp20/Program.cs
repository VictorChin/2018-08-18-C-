using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Parent : IParent
    {
        public string Add(int x, int y)
        { return (x + y).ToString(); }
       string IParent.Sub(int x, int y)
        { return (x - y).ToString(); }

    }
    class Child : Parent { }

    class Program
    {
        static void Main(string[] args)
        {

            Parent obj = new Parent();
            Console.WriteLine(obj.ToString);
            Type t = obj.GetType();
            MethodInfo m = t.GetMethod("Add");
            var result = m.Invoke(obj, new Object[] { 10, 20 });
            Console.WriteLine((string)result);


            string ConnStr = "";
            var k = new List<string>();
            if (k.GetType() is Type)
            {

            }
#if DEBUG
            Console.WriteLine("Here");
            Console.ReadLine();
#endif

#if Production
            ConnStr = "The RealDB";
            Console.WriteLine(ConnStr);
#else
            ConnStr = "The DemoDB";
            Console.WriteLine(ConnStr);
#endif


            int p = int.MaxValue;
                int q = ++p;
                Console.WriteLine(q);
         
            var hasher = new SHA256Managed();
            hasher.ComputeHash(File.Open(@"C:\Users\Administrator\Downloads\vlc-3.0.3-win64.exe", FileMode.Open));
            string hash = BitConverter.ToString(hasher.Hash).Replace("-", String.Empty);
            Rectangle avar= new Rectangle { Width = 10, Height = 10 };
            avar.SomeEvent += (x, y) => Console.WriteLine("First");
            avar.SomeEvent += (x, y) => Console.WriteLine("Second");
            avar.SomeEvent += (x, y) => Console.WriteLine("Third");
            avar.SomeEvent += (x, y) => Console.WriteLine("Third");
            avar.Execute();
            LinkedList<string> l = new LinkedList<string>();
            var a = l.AddFirst("Apple");
            var b = l.AddAfter(a, "Bob");
            


            switch (avar)
            {
                case Rectangle s when (s.Height == s.Width):
                    Console.WriteLine("Is Square");
                break;
                case Rectangle r when (r.Height != r.Width):
                    Console.WriteLine("Is Rectangle");
                    break;
                case null:
                    { Console.WriteLine("nothing there"); }
                    break;
                default:
                    Console.WriteLine("Unknown");
                    break;
             
            }
            Console.ReadLine();
            
            //TestLog();
        }

        private static void TestLog()
        {
            var source = "App1";
            var logname = "Application";
            var desc = "Blahblah";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logname);
            }
            EventLog.WriteEntry(source, desc, EventLogEntryType.Error
                , 100);
        }
    }
}
class Shape
{ }
class Rectangle : Shape
{
    public event EventHandler SomeEvent;
    public void Execute()
    {
        SomeEvent(this, null);
    }
    public int Width { get; set; }
    public int Height { get; set; }
}
        internal class Demo
            {
                internal async Task<string> Hello()
        {
                    string s  = await World();

                    return s;
        }

                private async Task<string> World()
                {
                   return "Hello World";
                }
}


