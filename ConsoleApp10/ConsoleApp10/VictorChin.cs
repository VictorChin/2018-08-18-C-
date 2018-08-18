using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp10
{
    public class VictorChin
    {
        [Key]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [Range(0,100)]
        public int? Grade { get; set; }

    }
}