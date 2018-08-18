using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    [Cool(10,Y=100)]
    public class Class1
    {
        public int Z { get; set; }
        [Cool(10)]
        public string Test() { return "version2"; }
        public Class1()
        {

        }
        public Class1(int x)
        {
            Z = x;
        }
    }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple =true)]
    public class CoolAttribute : Attribute
    {
       
        public int X { get; set; }
        public int Y { get; set; }
        public CoolAttribute(int input)
        {
            X = input;
        }
    }
}
