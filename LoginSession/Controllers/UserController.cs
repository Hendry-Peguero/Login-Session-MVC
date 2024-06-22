using LoginSession.Core.Application.Interfaces.IServices;
using LoginSession.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginSession.Core.Application.Helpes;
using LoginSession.Core.Domain.Entities;

namespace LoginSession.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService; 
        }
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult>  Index(LoginViewModel loginVm)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVm);
            }

            UserViewModel userVm = await _userService.Login(loginVm);

            if (userVm != null)
            {
                HttpContext.Session.Set<UserViewModel>("User", userVm);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso Incorreto");
            }


             return View(loginVm);
        }

        public ActionResult Register()
        {
            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Register(SaveUserViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                return View(userVm);
            }

            await _userService.Add(userVm);
            return RedirectToRoute(new { controller = "User", action = "Index"});
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
