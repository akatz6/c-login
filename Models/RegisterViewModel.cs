using System.ComponentModel.DataAnnotations;
namespace login.Models
{
    public abstract class BaseEntity {}
    public class RegisterViewModel : BaseEntity
    {
        [Required(ErrorMessage ="Please enter your first name")]
        [RegularExpression(@"^[A-Z]+[a-z''-'\s]*$", ErrorMessage ="Name must start with capital and be followed by lower case letters" )]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string First_Name {get; set;}

        [Required(ErrorMessage ="Please enter your last name")]
        [RegularExpression(@"^[A-Z]+[a-z''-'\s]*$", ErrorMessage ="Name must start with capital and be followed by lower case letters" )]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Last_Name {get; set;}

        [Required(ErrorMessage ="Please enter your email")]
        [RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage ="Must be valid email" )]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        public string Email {get; set;}

        [Required(ErrorMessage ="Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}

        
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string PasswordConfirmation { get; set; }
    }
}