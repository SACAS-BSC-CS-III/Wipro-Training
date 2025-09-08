using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureTaskApp.Models;

namespace SecureTaskApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        // Show form
        [Authorize(Policy = "CanEditPolicy")]
        public IActionResult Edit(int id)
        {
            // Fetch task from DB by id, for now return dummy
            var task = new TaskModel
            {
                Id = id,
                Title = "Sample Task",
                Description = "Editable only by users with CanEditTask claim"
            };

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CanEditPolicy")]
        public IActionResult Edit(TaskModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Update task logic here
            return RedirectToAction("TaskList", "User");
        }
    }
}
