using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Genre
    {
        public int GenreID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Many-to-many: Genre can have many books
        public ICollection<Book> Books { get; set; }
    }
}
