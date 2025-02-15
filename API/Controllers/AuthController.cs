using BusinessObjects.Dto.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid)  
        {
            return View(model);
        }
        bool isAuthenticated = model.Email != null && await _authService.Login(model.Email, model.Password);
        if (!isAuthenticated)
        {
            ViewBag.ErrorMessage = "Invalid email or password!";
            return View(model);
        }
        return RedirectToAction("Index", "Home"); 
    }
}