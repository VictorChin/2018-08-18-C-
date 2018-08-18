using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new WebTester();
            tester.TestWebReqRes();
        }
    }

    class WebTester
    {
        internal void TestWebReqRes() {
            WebRequest req = WebRequest.CreateHttp(@"http://www.google.com");
            req.Headers.Add("Hi:Yes");
            req.Method = "get";
            var resp = req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());
            Console.WriteLine(sr.ReadToEnd());


        }
    }
}
