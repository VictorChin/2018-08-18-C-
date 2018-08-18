using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Garage g = new Garage();
            var bob = new Driver { Name = "Bob" };
            var tom = new Driver { Name = "Tom" };
            g.Park(bob, new Car { VIN = "123" });
            g.Park(tom, new Car { VIN = "345" });
            Console.WriteLine(g[tom].VIN);
            string test = "Mary had a little lamb and it was delicious.";
            test.Split().Where(input => input.Length > 3)
                .AsQueryable()
                .OrderBy((input)=>input[0])
                .ForEach(thing => Console.WriteLine(thing));
            Console.ReadLine();
        }
    }
    static class MyExtensions
    {
        public static IQueryable<T> ForEach<T>(this IQueryable<T> i, Action<T> todo)
        {
            foreach (var item in i)
            {
                todo(item);
            }
            return i;
        }
    }
    class Garage
    {
        private Dictionary<Driver, Car> _cars = new Dictionary<Driver, Car>();
        public void Park(Driver d, Car c) => _cars.Add(d, c);
        public Car Fetch(Driver d) => _cars[d];
        public int CarCount => _cars.Count;
        public Car this[Driver d] {
            get { return Fetch(d); }
            set { _cars.Add(d, value); }
        }
    }

    internal class Car
    {
        public string VIN { get; set; }
    }

    internal class Driver
    {
        public string Name { get; set; }
    }
}
