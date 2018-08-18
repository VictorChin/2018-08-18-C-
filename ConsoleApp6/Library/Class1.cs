using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface ISwitchable
    {
        void TurnOn();
        void TurnOff();
    }
    public interface I38Faucet
    {
        void TurnOn();
        void TurnOff();
    }
    public class Light : ISwitchable, I38Faucet
    {
        void ISwitchable.TurnOff()
        {
            Console.WriteLine("Turn off via Interface method");
        }

        void ISwitchable.TurnOn()
        {
            Console.WriteLine("Turn on via Interface method");
        }
       
        void I38Faucet.TurnOn()
        {
            Console.WriteLine("Ahhhh.....");
        }
        void I38Faucet.TurnOff()
        {
            Console.WriteLine("NOOOOOOOOOOOO.. is this wyboston??!!");
        }
    }
    public class PubClass
    {
        private class PrivateClass { }
        internal class PubInternal { }
        protected class PubProtect { }
        public void PubMethod()
        {
            InternalClass i = new InternalClass();
            PrivateClass p = new PrivateClass();
            PubChild c = new PubChild();

        }
    }
    public class Factory
        {
        public class Phone
        {
            
        }
        private static Phone _singleton= new Phone();
        static Phone GetPhone()
            {
            return _singleton;
            }
        }

    public class PubChild : PubClass
    {
        public static void StaticMethod()
        { }
        public void ChildMethod()
        {
            PubProtect pubProtect = new PubProtect();
        }
    }
    internal class InternalClass
    {
        internal void InternalMethod() {
            PubClass p = new PubClass();
            PubClass.PubInternal pi = new PubClass.PubInternal();
            
        }
    }
}
