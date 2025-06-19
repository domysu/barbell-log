using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using razorJqueryProject.Data;
using razorJqueryProject.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using razorJqueryProject.Controllers;

namespace razorJqueryProject.Controllers
{


    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }
        // GET: Register

        public IActionResult Register()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
                if (user != null)
                {

                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                    return RedirectToAction("Index", "Exercises");
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(login);
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password,ConfirmPassword")] Register register)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _context.Users.FirstOrDefaultAsync(c => c.Username == register.Username);
                if (userExists != null)
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return View(register);
                }
                var user = new User
                {
                    Username = register.Username,
                    Password = register.Password // In a real application, you should hash the password
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Exercises");
            }
            return View(register);
        }

        // GET: Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

    }
}
