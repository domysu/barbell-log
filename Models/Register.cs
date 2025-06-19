using System.ComponentModel.DataAnnotations;
namespace razorJqueryProject.Models
{
 public class Register
 {
     [Required(ErrorMessage = "Username is required")]
     [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters")]
     public string Username { get; set; }

     [Required(ErrorMessage = "Password is required")]
     [DataType(DataType.Password)]
     [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters")]
     public string Password { get; set; }

     [DataType(DataType.Password)]
     [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
     public string ConfirmPassword { get; set; }
 }

}