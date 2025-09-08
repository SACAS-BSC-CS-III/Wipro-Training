using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MvcAuthDemo.Data;
using MvcAuthDemo.Models;
using MvcAuthDemo.ViewModels;

namespace MvcAuthDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _hasher = new();

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == vm.Email);
            if (user == null)
            {
                // OPTION A (safer): ask to register instead of auto-creating
                TempData["Msg"] = "Email not registered. Please create an account.";
                return RedirectToAction(nameof(Register), new { email = vm.Email });

                // OPTION B (your original idea - auto create):
                // return await AutoCreateAndSignin(vm.Email, vm.Password);
            }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, vm.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(vm);
            }

            await SignInAsync(user);
            user.LastLoginDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return RedirectToLocal(returnUrl, "/Home/Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string? email = null)
            => View(new RegisterViewModel { Email = email ?? string.Empty });

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var exists = await _context.Users.AnyAsync(u => u.Email == vm.Email);
            if (exists)
            {
                ModelState.AddModelError(nameof(vm.Email), "Email already registered.");
                return View(vm);
            }

            var newUser = new User
            {
                UserId = await GenerateNextUnoAsync(),
                Email = vm.Email,
                PasswordHash = _hasher.HashPassword(null!, vm.Password),
                CreatedDate = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            TempData["Msg"] = $"Account created! Your User ID is {newUser.UserId}. Please login.";
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // ===== Helpers =====
        private async Task<string> GenerateNextUnoAsync()
        {
            var last = await _context.Users
                .OrderByDescending(u => u.Id)
                .FirstOrDefaultAsync();

            if (last == null) return "UNO00001";

            var lastNum = int.Parse(last.UserId.Substring(3));
            return $"UNO{(lastNum + 1).ToString("D5")}";
        }

        private async Task SignInAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("UserId", user.UserId)  // custom claim
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10) // mirrors cookie timeout
                });

            HttpContext.Session.SetString("UserId", user.UserId);
        }

        private IActionResult RedirectToLocal(string? returnUrl, string fallback)
            => (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? Redirect(returnUrl) : Redirect(fallback);

        // If you want to auto-create on unknown email (OPTION B), uncomment and call from Login:
        /*
        private async Task<IActionResult> AutoCreateAndSignin(string email, string password)
        {
            var newUser = new User
            {
                UserId = await GenerateNextUnoAsync(),
                Email = email,
                PasswordHash = _hasher.HashPassword(null!, password),
                CreatedDate = DateTime.UtcNow,
                LastLoginDate = DateTime.UtcNow
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            await SignInAsync(newUser);
            return Redirect("/Home/Index");
        }
        */
    }
}
