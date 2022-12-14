using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService publisherService;
        private readonly ILibrarianService librarianService;

        public PublisherController(
            IPublisherService _publisherService,
            ILibrarianService _librarianService)
        {
            publisherService = _publisherService;
            librarianService = _librarianService;
        }

        public async Task<IActionResult> All()
        {
            PublisherQueryModel model = await publisherService.GetPublishers();

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

            var model = new PublisherModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PublisherModel model)
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            if (await publisherService.PublisherExists(model.PublisherName))
            {
                ModelState.AddModelError(nameof(model.PublisherName), "Издателят вече съществува");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int librarianId = await librarianService.GetLibrarianId(User.Id());

            int id = await publisherService.Create(model);

            TempData[MessageConstant.SuccessMessage] = "Успешно добавен издател";

            return RedirectToAction(nameof(All), new { id });
        }
    }
}
