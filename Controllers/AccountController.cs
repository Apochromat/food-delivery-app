using food_delivery_app.Models.ViewModels;
using food_delivery_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_delivery_app.Controllers;

public class AccountController : Controller {
    private readonly IUserService _userService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(IUserService userService, ILogger<AccountController> logger) {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Register() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model) {
        if (ModelState.IsValid) {
            try {
                await _userService.Register(model);
                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex) {
                _logger.LogError(ex.Message, ex);
                ModelState.AddModelError("RegistrationErrors", ex.Message);
            }
        }

        return View(model);
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _userService.Login(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Errors", ex.Message);
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return RedirectToAction("Index", "Home");
    }

}