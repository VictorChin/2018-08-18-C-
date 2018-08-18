using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1() { Z=100 };
            Class1 obj2 = new Class1() { Z = 200 };
            Type cls = typeof(Class1);
            Type[] cinput = new Type[] { typeof(int) };
             var constructor = cls.GetConstructor(cinput);
            object obj3 = constructor.Invoke(new Object[] { 10 });
            var z = cls.GetProperty("Z");
            var val = z.GetValue(obj2);
            Console.WriteLine(val);
            var attributes = Attribute.GetCustomAttributes(typeof(Class1));
            Type class1 = typeof(Class1);
            //var cool = (CoolAttribute)class1.GetCustomAttribute(typeof(CoolAttribute));
            //Console.WriteLine(cool.Y);

            //foreach (var attr in attributes)
            //{
            //    if (attr is CoolAttribute)
            //    { Console.WriteLine("I saw CoolAttribute"); }
            //}

            //foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    Console.WriteLine(asm.CodeBase);
            //}

            Type a = typeof(String);
            foreach (var item in a.GetMethods())
            {
                Console.WriteLine(item.Name);
                foreach (var param in item.GetParameters())
                {
                    Console.WriteLine($"\t {param.ParameterType} : {param.Name}");
                }
            }
        }
    }
}
