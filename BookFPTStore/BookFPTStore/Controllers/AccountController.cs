using BookFPTStore.Models;
using BookFPTStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookFPTStore.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<AppUserModel> _userManager;
		private SignInManager<AppUserModel> _signInManager;

		public AccountController(SignInManager<AppUserModel> signInManager,
									UserManager<AppUserModel> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;

		}
		public IActionResult Login(string returnUrl)
		{

			return View(new LoginViewModel { ReturnUrl = returnUrl });
		}

		[HttpPost]

		/*	public async Task<IActionResult> Login(LoginViewModel loginVM)
			{
				var user = await _userManager.FindByNameAsync(loginVM.Username);
				loginVM.UserRoleId = user?.GetRole();
				if (loginVM.UserRoleId.HasValue)
				{
					if (loginVM.UserRoleId == 0)
					{
						if (ModelState.IsValid)
						{

							Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);

							if (result.Succeeded)
							{
								return Redirect("amin");
							}
							ModelState.AddModelError("", "Invalid Username or Password");
						}

						// Nếu UserRoleId là 0, đây có thể là admin
						ViewBag.RoleDescription = "Admin";
					}
					else
					{
						if (ModelState.IsValid)
						{

							Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);

							if (result.Succeeded)
							{
								return Redirect(loginVM.ReturnUrl ?? "/");
							}
							ModelState.AddModelError("", "Invalid Username or Password");
						}
						// Xử lý cho các giá trị khác của UserRoleId
						ViewBag.RoleDescription = "Other Role";
					}
				}


				return View(loginVM);
			}*/

		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{


			if (ModelState.IsValid)
			{

				Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);

				if (result.Succeeded)
				{
					return Redirect(loginVM.ReturnUrl ?? "/");
				}
				ModelState.AddModelError("", "Invalid Username or Password");
			}

			return View(loginVM);

		}

		public IActionResult Create()
		{
			return View();
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
					return RedirectToAction("Login", "Account");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(user);
		}

		public async Task<IActionResult> Logout(string returnUrl = "/")
		{
			await _signInManager.SignOutAsync();
			return Redirect(returnUrl);
		}
	}
}
