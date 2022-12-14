using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Genre;
using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;
        private readonly ILibrarianService librarianService;

        public GenreController(
            IGenreService _genreService,
            ILibrarianService _librarianService)
        {
            genreService = _genreService;
            librarianService = _librarianService;
        }

        public async Task<IActionResult> All()
        {
            GenreQueryModel model = await genreService.GetGenres();

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

            var model = new GenreModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GenreModel model)
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            if (await genreService.GenreExists(model.GenreName))
            {
                ModelState.AddModelError(nameof(model.GenreName), "Жанрът вече съществува");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int librarianId = await librarianService.GetLibrarianId(User.Id());

            int id = await genreService.Create(model);

            TempData[MessageConstant.SuccessMessage] = "Успешно добавен жанр";

            return RedirectToAction(nameof(All), new { id });
        }
    }
}
