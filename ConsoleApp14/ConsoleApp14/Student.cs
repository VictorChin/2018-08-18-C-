using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Student : TableEntity
    {
        public string LastName
        {
            get => this.PartitionKey;
            set => this.PartitionKey = value;
        }
        public string FirstName
        {
            get => this.RowKey;
            set => this.RowKey= value;
        }
        public DateTime Enrolled { get; set; }
        public int Grade { get; set; }
        public string ClassRoom { get; set; }
    }
}
