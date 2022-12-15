using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApi.Controllers
{
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService service;

        public StatisticsApiController(IStatisticsService _service)
        {
            service = _service;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        public async Task<IActionResult> GetStatistics()
        {
            var model = await service.Total();
            return Ok(model);
        }
    }
}
