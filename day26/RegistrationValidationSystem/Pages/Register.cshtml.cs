using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistrationValidationSystem.Models;

namespace RegistrationValidationSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration User { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Simulate user registration logic
            TempData["Success"] = "Registration successful!";
            return RedirectToPage("Register");
        }
    }
}
