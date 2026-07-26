using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity.Models;
using Identity.Services;


namespace Identity.Controllers
{
    public class UserRegister: Controller 

    {
        private readonly IAuthService _authService;

    public UserRegister(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Register(RegisterInputModel input)
    // {
    //     if (!ModelState.IsValid)
    //         return View(input);

    //     var (success, error) = await _authService.RegisterAsync(input);

    //     if (!success)
    //     {
    //         ModelState.AddModelError("", error!);
    //         return View(input);
    //     }

    //     return RedirectToAction("RegisterSuccess");
    // }

    public IActionResult RegisterSuccess()
    {
        return View();
    }
    }
}
