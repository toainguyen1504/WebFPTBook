using System.ComponentModel.DataAnnotations;

namespace BookFPTStore.Models.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Username!")]
        public string Username { get; set; } = null!;

        [DataType(DataType.Password), Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }

      
    }
}
