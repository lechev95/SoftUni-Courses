using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class LibrarianController : Controller
    {
        private readonly ILibrarianService librarianService;

        public LibrarianController(ILibrarianService _librarianService)
        {
            librarianService = _librarianService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            LibrarianQueryModel model = await librarianService.GetLibrarians();

            return View(model);
        }


    }
}
