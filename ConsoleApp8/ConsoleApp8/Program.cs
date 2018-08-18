using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using Newtonsoft.Json;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Directory.EnumerateDirectories(@"C:\"))
            {
                Console.WriteLine(item);
            }

            Directory.CreateDirectory(@"C:\test2");
            var sw = File.CreateText(@"C:\test2\test.txt");
            sw.WriteLine("Hello World");
            sw.Flush();
            sw.Close();
            /////////////////////////////////////////////////////////////////////
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            foreach (var item in di.EnumerateDirectories())
            {
                Console.WriteLine($"{item.Name}-{item.LastAccessTime}-{item.Root} ");
            }
            DirectoryInfo newdir = new DirectoryInfo(@"C:\test3");
            newdir.Create();
            FileInfo file = new FileInfo(@"C:\test3\test.txt");
            sw = file.CreateText();
            sw.WriteLine("Hello World");
            sw.Flush();
            sw.Close();
            Path.GetDirectoryName(@"C:\test3\test.txt");
            Path.GetFileNameWithoutExtension(@"C:\test3\test.txt");
            Console.WriteLine(Path.GetRandomFileName());
            Console.WriteLine(Path.GetTempFileName());

            Person bob = new Person { Name = "Bob", Age = 40 };
            Person tom = new Person { Name = "Tom", Age = 20 };
            Console.WriteLine(bob);
            Console.WriteLine(tom);
            //BinaryFormatter serializer = new BinaryFormatter();
            //serializer.Serialize(File.Create(@"C:\test\bob.bin"), bob);
            //serializer.Serialize(File.Create(@"C:\test\tom.bin"), tom);
            //Person bob2 = (Person)serializer.Deserialize(File.Open(@"C:\test\bob.bin", FileMode.Open));
            //Console.WriteLine(bob2 + " I am from a file. hehe");
            var fs = File.Create(@"C:\test\bob.xml");
            IFormatter soap = new SoapFormatter();
            soap.Serialize(fs, bob);
            fs.Close();
            Person bob2 = 
                (Person)soap.Deserialize(File.Open(@"C:\test\bob.xml", FileMode.Open, FileAccess.Read));
            Console.WriteLine(bob2);

            string json = JsonConvert.SerializeObject(bob2);
            Console.WriteLine(json);
            Person bob3 = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(bob3);

            StringBuilder sb = new StringBuilder("Hello World, my name is victor \r\n It is a good day.\r\n");
            StringWriter writer2 = new StringWriter(sb);
            writer2.WriteLine("Another Line");
            StringReader reader2 = new StringReader(sb.ToString());
            Console.WriteLine(reader2.ReadLine());
            Console.WriteLine(reader2.ReadLine());
            Console.WriteLine(reader2.ReadLine());

        }
    }
    [Serializable]
    class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Hi My name is {this.Name}. And I am {Age} years old";
        }
        public void ChangeName(string _name)
        {
           this.Name = _name;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Console.WriteLine("I am gonna crash!!!");
            info.AddValue("When", DateTime.Now);
            info.AddValue("Age", this.Age);
            info.AddValue("Name", this.Name);

        }
        public Person(SerializationInfo info, StreamingContext context)
        {
            Console.WriteLine($"I am serialized at {info.GetDateTime("When")}");
            Console.WriteLine("Who is the President now?");
            Console.WriteLine("You don't want to know.");
            this.Name = info.GetString("Name");
            this.Age = info.GetInt32("Age");
        }
        public Person()
        {

        }
    }
}
