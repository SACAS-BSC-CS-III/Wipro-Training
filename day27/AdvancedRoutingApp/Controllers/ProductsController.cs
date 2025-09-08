using Microsoft.AspNetCore.Mvc;
using AdvancedRoutingApp.Models;

namespace AdvancedRoutingApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /Products
        public IActionResult Index()
        {
            // Example: return a static list of products (you can connect DB later)
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Category = "electronics" },
                new Product { Id = 2, Name = "Book", Category = "books" },
                new Product { Id = 3, Name = "Phone", Category = "electronics" }
            };

            return View(products); // This will look for Views/Products/Index.cshtml
        }

        // GET: /Products/{category}/{id}
        [Route("Products/{category}/{id:int}")]
        public IActionResult Details(string category, int id)
        {
            var product = new Product
            {
                Id = id,
                Name = "Sample Product",
                Category = category
            };

            return View(product); // This will look for Views/Products/Details.cshtml
        }
    }
}
