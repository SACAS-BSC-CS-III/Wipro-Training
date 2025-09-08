import os
import zipfile

project_structure = {
    "LibraryManagementSystem/Controllers/BooksController.cs": """using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _bookRepo;

        public BooksController(IRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepo.GetAll()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();

            return View(books);
        }
    }
}""",

    "LibraryManagementSystem/Models/Book.cs": """namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}""",

    "LibraryManagementSystem/Models/Author.cs": """namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}""",

    "LibraryManagementSystem/Models/Genre.cs": """namespace LibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}""",

    "LibraryManagementSystem/Repositories/IRepository.cs": """using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}""",

    "LibraryManagementSystem/Repositories/Repository.cs": """using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryContext _context;

        public Repository(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll() => _context.Set<T>();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}""",

    "LibraryManagementSystem/Data/LibraryContext.cs": """using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}""",

    "LibraryManagementSystem/Views/Books/Index.cshtml": """@model IEnumerable<LibraryManagementSystem.Models.Book>

<h2>Books List</h2>

<table class="table">
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Genre</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var book in Model)
        {
            <tr>
                <td>@book.Title</td>
                <td>@book.Author?.Name</td>
                <td>@book.Genre?.Name</td>
            </tr>
        }
    </tbody>
</table>"""
}

with zipfile.ZipFile("LibraryManagementSystem.zip", "w") as zipf:
    for path, content in project_structure.items():
        zipf.writestr(path, content)

print("✅ Project zipped as 'LibraryManagementSystem.zip'")
