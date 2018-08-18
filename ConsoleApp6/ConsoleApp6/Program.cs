using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library;
namespace ConsoleApp6
{
    class Program
    {
        interface IDemo<in T>
        {
            void method(T x);
            int MyProperty { get; set; }
            int this[int x] { get;set ; }
        }
        class Person : IComparable<Person> {
            public string Name { get; set; }
            public int Age { get; set; }

            public int CompareTo(Person other)
            {
                return this.Age - other.Age;
            }
        }

        class MessWithOnOff<T> where T : class, I38Faucet, new()
        {
            T athing = new T();
            public void Flip(T toBeFlipped)
            {
                toBeFlipped.TurnOn();
                Thread.Sleep(3000);
                toBeFlipped.TurnOff();
            }
        }


        static void Main(string[] args)
        {
            MessWithOnOff<Light> messer = new MessWithOnOff<Light>();
            messer.Flip(new Light());

            List<Person> group = new List<Person> {
                new Person { Name = "Bob", Age = 50 },
                new Person { Name = "Tom", Age = 30 } };
            group.Sort();
            //int[] arr = { 1, 2, 3, 4, 5 };
            //test(ref arr[3]);
            //Console.WriteLine(arr[3]);
            //IEnumerable<string> names = new string[] { "John", "Bob", "Tom" };
            Light a = new Light();
            ISwitchable b = a;
            I38Faucet c = a;
            //a.TurnOn();
            b.TurnOn();
            c.TurnOn();
            IEnumerable<ISwitchable> switchPanel = new List<ISwitchable> { new Light(), new Light() };
            switchPanel = new List<Light> { new Light(), new Light() };
            


            Console.ReadLine();
        }
        static void test(ref int x)
        {
            x = 50;
        }
    }
    class Child2 : Library.PubClass
    {
        void Test()
        {
           
        }
    }
    
}
