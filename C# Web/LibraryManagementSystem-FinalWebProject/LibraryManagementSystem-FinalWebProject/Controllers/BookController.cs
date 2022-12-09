using LibraryManagementSystem_FinalWebProject.Core.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
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
        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(BookModel model)
        {
            int id = 1;

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
