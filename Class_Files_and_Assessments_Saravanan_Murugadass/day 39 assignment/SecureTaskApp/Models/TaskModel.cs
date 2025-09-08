using System.ComponentModel.DataAnnotations;

namespace SecureTaskApp.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public string? OwnerId { get; set; } // User ID for task ownership
    }
}
