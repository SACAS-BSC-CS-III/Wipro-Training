using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAuthDemo.Models
{
    public class User
    {
        public int Id { get; set; }                          // Identity PK (internal)
        [Required, MaxLength(20)]
        public string UserId { get; set; } = default!;       // e.g., UNO00001

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = default!;        // unique

        [Required]
        public string PasswordHash { get; set; } = default!; // hashed password

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }
    }
}
