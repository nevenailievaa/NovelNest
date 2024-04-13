namespace NovelNest.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static NovelNest.Core.Constants.AdminConstants;

    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}