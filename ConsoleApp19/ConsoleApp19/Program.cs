using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "mykey";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);
           var cipher =  rsa.Encrypt(Encoding.UTF8.GetBytes("Hello World"), true);
            Console.WriteLine(Encoding.UTF8.GetString(cipher));
            Console.WriteLine(Encoding.UTF8.GetString(rsa.Decrypt(cipher, true)));
            var stream = File.Open(@"C:\hello.txt", FileMode.Open, FileAccess.Read);
            var signature =rsa.SignData(stream,
                SHA256.Create());
            stream.Close();
            byte[] fileContent = new byte[1024];
            File.Open(@"c:\hello.txt", FileMode.Open, FileAccess.Read).Read(fileContent,0,1024);
            byte[] hash = SHA256.Create().ComputeHash(fileContent);
            bool result= rsa.VerifyData(hash,
                SHA256.Create(), signature
                );
            Console.WriteLine(result);


        }
    }
}
