using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RoleAuthApp.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }
    }
}
