
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    static class MyExtension
    {
       public static string RandomizeString(this string s)
        {

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            byte[] b = new byte[s.Length];
            new Random((int)DateTime.Now.Ticks).NextBytes(b);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append((b[i] % 2 == 0) ? Char.ToLower(s[i]) : Char.ToUpper(s[i]));
            }
#if DEBUG
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
#endif
            return sb.ToString();
        }
    }
    class Program
    {
        [Conditional("DEBUG")]
        static void Test() { Console.WriteLine("test"); }

        static void Main(string[] args)
        {
            //Car aCar = new SportsCar();
            //Car bCar = new SportsCar();
            //String s2= "a";
            //String s3 = "a";
            //Console.WriteLine(s3==s2);

            //Test();
            string s = "mary had a little lamb mary had a little lamb mary had a little lamb mary had a little lamb mary had a little lamb";
            string result = s.RandomizeString();
            Console.WriteLine(result);
            result = s.RandomizeString();
            Console.WriteLine(result);
            result = s.RandomizeString();
            Console.WriteLine(result);
            Console.ReadLine();
            Car car;// = new Car();
            //car.Drive();
            //car.Stop();
            car = new SportsCar();
            car.Drive();
            car.Stop();
            ExoticSportsCar eCar = new ExoticSportsCar();
            eCar.Drive();
            eCar.Stop();
        }
    }
    abstract class Car {
        public Car()
        {
            int x = 5;
        }
        public virtual void Drive() {
            Console.WriteLine("Car Driving");
        }
        public void Stop() { Console.WriteLine("Car Stop"); }
        protected abstract void Method();
    }
    class SportsCar : Car {
        public SportsCar():base()
        {
            int y =15;
        }
        protected override void Method()
        {
            throw new NotImplementedException();
        }
        public override void Drive()
        {
            base.Drive();
           Console.WriteLine("Car Driving");
        }
        public void Stop() {
            Console.WriteLine("Sports Car Stop");
        }
    }
    sealed class ExoticSportsCar : SportsCar
    {
        public override void Drive()
        {
            base.Drive();
            Console.WriteLine("Exotics Car Driving");
        }
    }
   
}
