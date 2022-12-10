using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class LibrarianController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            LibrarianQueryModel? model = new LibrarianQueryModel();

            return View(model);
        }
    }
}
