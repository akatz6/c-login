using System;
using System.ComponentModel.DataAnnotations;

namespace craigslist.Models
{
    public class Auto
    {
        public int Id { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage ="Please enter your make")]
        public string Make { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage ="Please enter your model")]
        public string Model { get; set; }
        public string Part { get; set; }

        [Required(ErrorMessage ="Please enter your price")]
        public int Price { get; set; }
        public int UserId {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}