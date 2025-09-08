using Microsoft.AspNetCore.Mvc;
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
}