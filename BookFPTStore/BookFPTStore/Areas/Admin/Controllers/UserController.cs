using BookFPTStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookFPTStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class UserController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;

        public UserController(UserManager<AppUserModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Lấy danh sách người dùng từ Identity hoặc từ database của bạn
            var users = await _userManager.Users.ToListAsync();

            // Truyền danh sách người dùng vào view
            return View(users);
        }

        public IActionResult Create(AppUserModel user)
        {
        
            return View(user);
        }

		[HttpPost]
		public async Task<IActionResult> Create(TbUser user)
		{
			if (ModelState.IsValid)
			{
				AppUserModel newUser = new AppUserModel { UserName = user.Username, Email = user.Email };
				IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
				if (result.Succeeded)
				{
					TempData["success"] = "Create user successfully!";
					return RedirectToAction("Index", "User");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(user);
		}

		public async Task<IActionResult> Delete(int Id)
		{

			return RedirectToAction("Index");
		}

	}
}
