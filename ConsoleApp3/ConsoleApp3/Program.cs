using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [Flags]
    enum Permission
    {
        Read,
        Write,
        Execute
    }

    enum EUCountries {
        UK,
        Ireland,
        Denmark,
        Netherland
    }
    struct Point
    {
       internal int X;
        internal int Y;
    }
    struct Line
    {
        Point Begin;
        Point End;
    }
    struct Triangles
    {
        Line[] Sides;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point { X = 100, Y = 100 };
            Point B = A;
            B.X = 50;
            Console.WriteLine($"A: {A.X}, B:{B.X}");
            Console.WriteLine("Please Enter a country name");

            var input = Console.ReadLine();
            EUCountries country;
            if (Enum.TryParse<EUCountries>(input,out country))
            { RateCountry(country); }
            
            for (int i = 0; i < 4; i++)
            {
                var athing = (EUCountries)i;
                Console.WriteLine(athing);
            }
            var perms = Permission.Read | Permission.Write;
            CheckPermission(perms);
            Console.ReadLine();
        }
        static void CheckPermission(Permission p)
        {
            if (p.HasFlag(Permission.Read))
            { Console.WriteLine("Has Read"); }
            if (p.HasFlag(Permission.Write))
            { Console.WriteLine("Has Write"); }
            if (p.HasFlag(Permission.Execute))
            { Console.WriteLine("Has Execute"); }
        
        }

        static void RateCountry(EUCountries country)
        {
            switch (country)
            {
                case EUCountries.UK:
                case EUCountries.Ireland:
                    Console.WriteLine("Not anymore");
                    break;
                case EUCountries.Denmark:
                    Console.WriteLine("The happiest country in the world...");
                    break;
                case EUCountries.Netherland:
                    Console.WriteLine("Makes you happier than a Dane :) ");
                    break;
                default:
                    break;
            }
        }
    }
}
