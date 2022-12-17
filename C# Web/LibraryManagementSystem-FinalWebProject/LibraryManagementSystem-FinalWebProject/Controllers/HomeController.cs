using LibraryManagementSystem.Models;
using LibraryManagementSystem_FinalWebProject.Areas.Admin.Controllers;
using LibraryManagementSystem_FinalWebProject.Areas.Admin.Constants;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index), nameof(AdminController).Replace("Controller", string.Empty), new { area = "Admin" });
            }

            var model = await bookService.LastFiveBooks();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}