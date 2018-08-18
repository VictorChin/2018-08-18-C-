using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        public static void Main(string[] args)
        {
            GetPage().Wait();
            Console.WriteLine("Main Done");

            Console.Read();
        }

        private static async Task GetPage()
        {
            string url = @"https://www.britishgas.co.uk/";
            List<HttpStatusCode> responseCode = new List<HttpStatusCode>();
            for (int i = 0; i < 5000; i++)
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage page = await client.GetAsync(url);
                    responseCode.Add(page.StatusCode);
                }

            }
            var q = from req in responseCode
                    group req by req into g
                    select new { code = g.Key, count = g.Count() };
            foreach (var item in q)
            {
                Console.WriteLine($"{item.code}:{ item.count}");
            }
        }

        static int x = 0;
        static object o= new object();
        //static Semaphore sem = new Semaphore(5, 10,"MySemophare");
        //static ManualResetEvent mre = new ManualResetEvent(false);
        static public void Test(object state) {
            //  sem.WaitOne();
            //mre.WaitOne();
            //Thread.Sleep(new Random().Next(1000, 5000));

            lock (o)
            {
                for (int i = 0; i < 100000; i++)
                {
                    x++;
                }
            }
            Console.WriteLine($"{state} Am Done : {x}");
            
            //  sem.Release();
            //mre.Set();
        }
    }
}
