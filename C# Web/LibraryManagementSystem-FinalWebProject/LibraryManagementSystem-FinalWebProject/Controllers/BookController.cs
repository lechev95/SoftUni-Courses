using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ILibrarianService librarianService;

        public BookController(
            IBookService _bookService,
            ILibrarianService _librarianService)
        {
            bookService = _bookService;
            librarianService = _librarianService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            BookQueryModel? model = new BookQueryModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            BookQueryModel? model = new BookQueryModel();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new BookDetailsModel();

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

            var model = new BookModel()
            {
                Genres = await bookService.AllGenres(),
                Authors = await bookService.AllAuthors(),
                Publishers = await bookService.AllPublishers()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookModel model)
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            if ((await bookService.GenreExists(model.GenreId)) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Жанрът не съществува");
            }

            if ((await bookService.AuthorExists(model.AuthorId)) == false)
            {
                ModelState.AddModelError(nameof(model.AuthorId), "Авторът не съществува");
            }

            if ((await bookService.PublisherExists(model.PublisherId)) == false)
            {
                ModelState.AddModelError(nameof(model.PublisherId), "Издателят не съществува");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers();

                return View(model);
            }

            int librarianId = await librarianService.GetLibrarianId(User.Id());

            int id = await bookService.Create(model, librarianId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new BookModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookModel model)
        {
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
