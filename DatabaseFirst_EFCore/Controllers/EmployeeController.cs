using Microsoft.AspNetCore.Mvc;
using DatabaseFirst_EFCore.Models;

public class EmployeeController : Controller
{
    private readonly CompanyContext _context;

    public EmployeeController(CompanyContext context)
    {
        _context = context;
    }

    // READ
    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return View(employees);
    }

    // CREATE
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // UPDATE
    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // DELETE
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
