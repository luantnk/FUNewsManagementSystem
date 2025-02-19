using BusinessObjects.Dto.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service) => _service = service;
   
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var role = await _service.Login(model.Email, model.Password);
        return RedirectToAction("Index", "Home");
        ViewBag.ErrorMessage = "Invalid email or password.";
        return View(model);
    }
}