using Microsoft.AspNetCore.Mvc;
using ECommerceRoutingApp.Models;

namespace ECommerceRoutingApp.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Category = "Electronics", Name = "Laptop", Price = 999 },
            new Product { Id = 2, Category = "Books", Name = "ASP.NET Core Guide", Price = 49 },
            new Product { Id = 3, Category = "Electronics", Name = "Smartphone", Price = 699 }
        };

        [Route("Products/{category}/{id:int}")]
        public IActionResult Details(string category, int id)
        {
         var product = Products.FirstOrDefault(p =>
         p.Category != null &&
         p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
         p.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }

        [Route("Products/Filter/{category}/{priceRange}")]
        public IActionResult Filter(string category, string priceRange)
        {
            var range = priceRange.Split('-');
            if (range.Length != 2 || !int.TryParse(range[0], out int min) || !int.TryParse(range[1], out int max))
            {
                return BadRequest("Invalid price range.");
            }

            var filtered = Products.Where(p =>
                p.Category != null &&

                p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                p.Price >= min && p.Price <= max).ToList();

            return View(filtered);
        }
    }
}
