using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Author;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly ILibrarianService librarianService;

        public AuthorController(
            IAuthorService _authorService,
            ILibrarianService _librarianService)
        {
            authorService = _authorService;
            librarianService = _librarianService;
        }

        public async Task<IActionResult> All()
        {
            AuthorQueryModel model = await authorService.GetAuthors();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            var model = new AuthorModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorModel model)
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            if (await authorService.AuthorNameExists(model.Name))
            {
                ModelState.AddModelError("", "Авторът вече съществува");
                TempData[MessageConstant.ErrorMessage] = "Авторът вече съществува";
                return RedirectToAction(nameof(Add), nameof(AuthorController).Replace("Controller", string.Empty));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int librarianId = await librarianService.GetLibrarianId(User.Id());

            int id = await authorService.Create(model);

            TempData[MessageConstant.SuccessMessage] = "Успешно добавен автор";

            return RedirectToAction(nameof(All), new { id });
        }
    }
}
