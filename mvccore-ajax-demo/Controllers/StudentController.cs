using Microsoft.AspNetCore.Mvc;
using mvccore_ajax_demo.Models;

namespace mvccore_ajax_demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateStudent(Student std)
        {
            _context.Students.Add(std);
            _context.SaveChanges();
            return Json(new { message = "SUCCESS" });
        }

        [HttpGet]
        public JsonResult GetStudent()
        {
            var students = _context.Students.ToList();
            return Json(students);
        }
    }
}
