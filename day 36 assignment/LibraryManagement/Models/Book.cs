using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        // Foreign key to Author
        public int AuthorID { get; set; }

        // Navigation property
        public Author Author { get; set; }

        // Many-to-many: Book can have many genres
        public ICollection<Genre> Genres { get; set; }
    }
}
