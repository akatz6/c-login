using System.ComponentModel.DataAnnotations;
namespace craigslist.Models
{
    public abstract class BaseEntity {}
    public class RegisterViewModel : BaseEntity
    {
        [Required(ErrorMessage ="Please enter your first name")]
        [RegularExpression(@"^[A-Z]+[a-z''-'\s]*$", ErrorMessage ="Name must start with capital and be followed by lower case letters" )]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 20 characters")]
        public string First_Name {get; set;}

        [Required(ErrorMessage ="Please enter your last name")]
        [RegularExpression(@"^[A-Z]+[a-z''-'\s]*$", ErrorMessage ="Name must start with capital and be followed by lower case letters" )]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 20 characters")]
        public string Last_Name {get; set;}

        [EmailAddress]
        [Required(ErrorMessage ="Please enter your email")]
        public string Email {get; set;}

        [Required(ErrorMessage ="Please enter your password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$?", ErrorMessage ="Password by have one number, one special character, and be between 8 and 20 chars" )]
        [MinLength(8)]
        public string Password {get; set;}

        
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
    }
}