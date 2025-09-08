using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public string Bio { get; set; }
        
        // One-to-many: Author can have many books
        public ICollection<Book> Books { get; set; }
    }
}
