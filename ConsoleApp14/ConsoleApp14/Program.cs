using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=chindsjkada;AccountKey=emTgDRpJTnlT7b2TTCsnA4ROuKgU4IoDEwG2cnZYxva7H7o8BJ6ASCUENPaDVzSWePjKd1ieml4p6gywMC4p5g==;TableEndpoint=https://chindsjkada.table.cosmosdb.azure.com:443/;");
            var tableClient =account.CreateCloudTableClient();
            var table = tableClient.GetTableReference("victor");
            table.CreateIfNotExists();
            for (int i = 0; i < 10; i++)
            {
                var op = TableOperation.InsertOrMerge(new Student
                {
                    FirstName = $"Victor{i}",
                    LastName = $"Chin2",
                    Enrolled = DateTime.Now - new TimeSpan(i, 0, 0, 0),
                    Grade = i + 80,
                    ClassRoom="Hendrix"
                });
                table.Execute(op);
            }
            
        }
    }
}
