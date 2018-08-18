using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "hello world";
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }

            string[] names =new string[5];
            names[0] = "victor";
            names[1] = "glen";
            names[2] = "luke";
            names[3] = "nayia";
            names[4] = "richard";

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

            List<string> names2 = new List<string>();
            names2.Add("victor");
            names2.Add("glen");



            DateTime dob = new DateTime(2009, 8, 23);
            DateTime now = DateTime.Now;
            TimeSpan age = now - dob;
            Console.WriteLine($"{age.TotalDays/365} years old, {age.Hours} hours");
            Console.WriteLine(String.Format("{0} years old, {1} hours", age.TotalDays / 365, age.Hours));
            Console.WriteLine(age.TotalDays / 365+" years old, " + age.Hours + " hours");
            Console.WriteLine(dob.DayOfWeek);
            switch (dob.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("Weekday baby");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Saturday baby");
                    break;
                default:
                    Console.WriteLine("Sunday baby");
                    break;
            }
            Console.ReadLine();
        }
    }
}
