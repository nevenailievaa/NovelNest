using Microsoft.AspNetCore.Mvc;

namespace NovelNest.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Actions()
        {
            return View();
        }
    }
}
