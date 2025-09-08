// models/loginViewModel.cs

using System.ComponentModel.DataAnnotations;

namespace MvcLogin9.Models
{
    public class LoginViewModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}