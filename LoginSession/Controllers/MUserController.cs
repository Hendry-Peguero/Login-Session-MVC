using LoginSession.Core.Application.Interfaces.IServices;
using LoginSession.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginSession.Controllers
{
    public class MUserController : Controller
    {
        private readonly IUserService _userService;

        public MUserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllViewModel());
        }

        public ActionResult Create()
        {
            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(SaveUserViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                return View(userVm);
            }

            await _userService.Add(userVm);
            return RedirectToRoute(new { controller = "MUser", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _userService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
