namespace NovelNest.Areas.Admin.Components
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}