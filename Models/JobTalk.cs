using System;
using System.ComponentModel.DataAnnotations;

namespace craigslist.Models
{
    public class JobTalk
    {
        public int Id { get; set; }

        [MinLength(10)]
        [Required(ErrorMessage ="Please enter your comment")]
        public string Comment { get; set; }
        public int JobId {get; set;}
        public int UserId {get; set;}

        public Job Job { get; set; }

        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}