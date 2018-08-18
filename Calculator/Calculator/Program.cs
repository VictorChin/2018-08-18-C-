using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // whole numbers
            byte a = byte.MaxValue;
            short b = short.MaxValue;
            int c = int.MaxValue;
            long d = long.MaxValue;
            //approximated fractions
            float e = 0.1785484578514f;
            
            Console.WriteLine(e);
            double f = e;
            //
            decimal g = 0.1785484578514M;
            //g = (decimal)e;
            Console.WriteLine(g);
            //show me the size:
            Console.WriteLine($"bool is : {sizeof(bool)} byte(s)");
            Console.WriteLine($"byte is : {sizeof(byte)} byte(s)");
            Console.WriteLine($"short is : {sizeof(short)} byte(s)");
            Console.WriteLine($"int is : {sizeof(int)} byte(s)");
            Console.WriteLine($"long is : {sizeof(long)} byte(s)");
            Console.WriteLine($"float is : {sizeof(float)} byte(s)");
            Console.WriteLine($"double is : {sizeof(double)} byte(s)");
            Console.WriteLine($"decimal is : {sizeof(decimal)} byte(s)");

            DateTime dob = new DateTime(1975, 8, 15);
            CultureInfo ci= CultureInfo.CreateSpecificCulture("zh-TW");
            Calendar jCalendar = new JapaneseCalendar();

            Console.WriteLine($" Year in Japan: {jCalendar.GetYear(dob)}");

            Console.WriteLine(dob);
            Console.WriteLine(dob.ToLongDateString());
            Console.WriteLine(dob.ToShortDateString());

            string j = "Hello World";
            char k;
            for (int counter = 0; counter < j.Length; counter++)
            {
                 k=j[counter];
                Console.WriteLine(k);
            }

            
     

            for (int counter = 0; counter < 255; counter++)
            {
                k = Convert.ToChar(counter);
                Console.Write(counter + " : "+ k + ",");
            }

       
            






            Console.WriteLine("Enter a whole number!");
            string answer = Console.ReadLine();
            int x;
            if (int.TryParse(answer, out x))
            {
                Console.WriteLine("Thank you.");
                // hey bob the line below is cool huh?
                string result = (x > 100) ? "Big Number" : "Small Number";
                Console.WriteLine(result);
                int i = 0;

                //do
                //{
                //    Console.WriteLine(i);
                //    i++;
                //} while (i < x);
                //if (x>100)
                //{
                //    Console.WriteLine("Big Number");
                //}
                //else
                //{
                //    Console.WriteLine("Small Number");
                //}
            }
            else
            {
                Console.WriteLine("A NUMBER!! I SAID!");
            }


            Console.ReadLine();
        }
    }
}
