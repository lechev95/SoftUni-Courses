﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibraryManagementSystem_FinalWebProject.Areas.Admin.Constants.AdminConstants;

namespace LibraryManagementSystem_FinalWebProject.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
