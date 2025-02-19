using BusinessObjects.Dto.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.Threading.Tasks;

namespace API.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    // GET: /Auth/Login
    public IActionResult Login() => View(new LoginDto());

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            if (model.Email == null)
            {
                ViewBag.ErrorMessage = "Email is required!";
                return View(model);
            }

            string? userRole = await _authService.Login(model.Email, model.Password);
            if (string.IsNullOrEmpty(userRole))
            {
                ViewBag.ErrorMessage = "Invalid email or password!";
                return View(model);
            }

            // HttpContext.Session.SetString("UserRole", userRole);
            return userRole switch
            {
                "Lecturer" => RedirectToAction("Index", "NewsArticle"), 
                "Admin" => RedirectToAction("Dashboard", "Admin"),
                "Student" => RedirectToAction("StudentHome", "Student"),
                _ => RedirectToAction("Index", "Home")
            };

        }
        catch (Exception)
        {
            ViewBag.ErrorMessage = "An error occurred during login. Please try again.";
            return View(model);
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Login));
    }
}