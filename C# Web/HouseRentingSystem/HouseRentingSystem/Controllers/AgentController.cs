using HouseRentingSystem.Core.Constants;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if(await agentService.ExistsByIdAsync(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "Вие вече сте агент";

                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeAgentModel();

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(await agentService.ExistsByIdAsync(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Вие вече сте агент";

                return RedirectToAction(actionName: "Index", "Home");
            }

            if(await agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "Телефона вече съществува";

                return RedirectToAction(actionName: "Index", "Home");
            }

            if (await agentService.UserHasRentsAsync(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Не трябва да имате наеми, за да станете агент";

                return RedirectToAction(actionName: "Index", "Home");
            }

            await agentService.Create(userId, model.PhoneNumber);

            TempData[MessageConstant.SuccessMessage] = "Успешно станахте агент";

            return RedirectToAction("All", "House");//nameof(HouseController).Replace("Controller", string.Empty));
        }
    }
}
