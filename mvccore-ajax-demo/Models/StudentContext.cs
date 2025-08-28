using Microsoft.EntityFrameworkCore;

namespace mvccore_ajax_demo.Models
{
    public class StudentContext : DbContext
    {
        // Constructor to receive DbContextOptions
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        // DbSet for Students table
        public DbSet<Student> Students { get; set; }
    }
}
