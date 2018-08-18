using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();
            SalesDB ctx = new SalesDB();
            ctx.Database.Log = (s) => Console.WriteLine(s);
            var q = from c in ctx.Customers
                    where c.CompanyName.StartsWith("A") & 
                    c.CustomerAddresses.FirstOrDefault().Address.StateProvince=="California"
                    select new { Cname= c.CompanyName,Email=c.EmailAddress,
                        State = c.CustomerAddresses.FirstOrDefault().Address.StateProvince }
                    ;

          

            foreach (var item in q)
            {
                Console.WriteLine($"{item.Cname} - {item.Email} - {item.State}");
            }
            ctx.ProductDescriptions.Add(
                new ProductDescription { Description = "Good Guy Doll",
                    ModifiedDate = DateTime.Now
                }
                );
            ctx.SaveChanges();

        }

        private static void NewMethod()
        {
            string connStr = "Server=tcp:vcdb2.database.windows.net,1433;Initial Catalog=ClassDB;Persist Security Info=False;User ID=Chinjila;Password=Chinzilla!!!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from SalesLT.Customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]},{reader["FirstName"]}");
            }
            reader.Close();
            SqlCommand cmd2 = new SqlCommand("Create Table Victor(ColA int);", conn);
            cmd2.ExecuteNonQuery();
        }
    }
}
