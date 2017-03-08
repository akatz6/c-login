using System;
using System.ComponentModel.DataAnnotations;

namespace craigslist.Models
{
    public class Job
    {
        public int Id { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage ="Please enter the title")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please enter the salary")]
        public int Salary { get; set; }
        public int UserId {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}