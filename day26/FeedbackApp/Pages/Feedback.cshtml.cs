using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FeedbackApp.Models;

namespace FeedbackApp.Pages
{
    public class FeedbackModel : PageModel
    {
        [BindProperty]
        public Feedback Feedback { get; set; }

        public void OnGet() {}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Process feedback (e.g. save to DB)
            return RedirectToPage("ThankYou");
        }
    }
}
