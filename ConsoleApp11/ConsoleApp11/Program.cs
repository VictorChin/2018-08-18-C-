using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassDBEntities ctx = new ClassDBEntities();
            var q = from c in ctx.Customers
                    where c.CompanyName.StartsWith("A")
                    select c;
        }
    }
}
