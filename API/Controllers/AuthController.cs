using BusinessObjects.Dto.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        string? userRole = model.Email != null ? await _authService.Login(model.Email, model.Password) : null;
        if (userRole == null)
        {
            ViewBag.ErrorMessage = "Invalid email or password!";
            return View(model);
        }
        HttpContext.Session.SetString("UserRole", userRole);
        return userRole switch
        {
            "Lecturer" => RedirectToAction("NewsArticle", "NewsArticle"),
            "Admin" => RedirectToAction("Dashboard", "Admin"), 
            "Student" => RedirectToAction("StudentHome", "Student"), 
            _ => RedirectToAction("Index", "Home")
        };
    }


}