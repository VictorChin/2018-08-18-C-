using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {

            //var files = Directory.GetFiles(@"C:\Share\imagesout");
            //Parallel.ForEach(files, (s) => WaterMark(s, DateTime.Today.ToLongDateString()));
            ////WaterMark(@"C:\Test\20180727_220536.jpg",DateTime.Today.ToLongDateString());

            //Task t = WaterMark("dsadsaa", "dsdasdsa");
            //Timer timer = new Timer(M, null, 1000, 5000);
            var tokenSource2 = new CancellationTokenSource();
            CancellationToken cts = tokenSource2.Token;

            tokenSource2.Cancel();
            Task<string>.Run(() => "hello").
                ContinueWith((t) => {
                    if (!cts.IsCancellationRequested)
                    { Console.WriteLine(t.Result + ":task2"); }
                    }
                ,cts);
                
            HttpClient client = new HttpClient();

            var c = new WebClient();
            c.DownloadDataCompleted += (o, e) => Console.WriteLine(Encoding.UTF8.GetString(e.Result));
            c.DownloadDataAsync(new Uri("http://www.google.com"));
            Console.ReadLine();

            var req =WebRequest.Create("http://www.google.com");
            var x = req.BeginGetResponse(null, null);
            while (!x.IsCompleted)
            {
                Console.WriteLine("waiting");
            }
            var response = req.EndGetResponse(x);
            Console.WriteLine(new StreamReader(response.GetResponseStream()).ReadToEnd());
        }
        static void  M(object state)
        {
            Console.WriteLine("M");
        }

        static async Task WaterMark(string _filePath, string toDraw)
        {
            var dtstamp=File.GetCreationTime(_filePath);
            Bitmap bitmap = new Bitmap(_filePath);
            var g = Graphics.FromImage(bitmap);
           
            g.DrawString(dtstamp.ToLongDateString(), new Font(FontFamily.GenericMonospace, 15),
                new SolidBrush(Color.FromArgb(128,255,0,0)),
                0,bitmap.Height-35);
            string newName = _filePath.Replace(".jpg", "watermark.jpg")
                .Replace("imagesout", "watermarked");
            bitmap.Save(newName);
            bitmap.Dispose();
            g.Dispose();
        }
    }
}
