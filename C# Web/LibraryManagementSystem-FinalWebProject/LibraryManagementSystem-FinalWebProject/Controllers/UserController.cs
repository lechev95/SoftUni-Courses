using LibraryManagementSystem_FinalWebProject.Data.Models;
using LibraryManagementSystem_FinalWebProject.GlobalConstants;
using LibraryManagementSystem_FinalWebProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(
            SignInManager<User> _signInManager, 
            UserManager<User> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), nameof(HomeController).Replace("Controller", string.Empty));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if(User?.Identity?.IsAuthenticated ?? false)
            {
                //TO-DO: Redirect to home page for logged users
                return RedirectToAction(nameof(Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            var model = new LoginViewModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if(user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    //TO-DO: Redirect to home page for logged users
                    return RedirectToAction(nameof(Index), nameof(HomeController).Replace("Controller", string.Empty));
                }
            }

            ModelState.AddModelError("", ErrorMessages.InvalidLoginError);
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                //TO-DO: Redirect to home page for logged users
                return RedirectToAction(nameof(Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            var model = new RegisterViewModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login), nameof(UserController).Replace("Controller", string.Empty));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }
    }
}
