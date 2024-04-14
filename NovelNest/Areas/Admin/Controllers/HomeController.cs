namespace NovelNest.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminBaseController
    {
        public IActionResult Actions()
        {
            return View();
        }
    }
}