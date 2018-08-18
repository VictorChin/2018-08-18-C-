using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter User Name:");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);
            SHA1Managed SHhash = new SHA1Managed();
            byte[] passwordHash = SHhash.ComputeHash(passwordBytes);

            User newUser = new User { UserName = userName, Password = passwordHash };
            var fs = File.Open(@"c:\Test\user.bin", FileMode.Create);
            var ser = new BinaryFormatter();
            ser.Serialize(fs,newUser);
            fs.Close();
        }
    }
    [Serializable]
    class User
    {
        public string UserName { get; set; }
        public byte[] Password { get; set; }

    }
}
