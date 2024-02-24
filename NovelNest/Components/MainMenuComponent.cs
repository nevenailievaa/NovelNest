using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace NovelNest.Components
{
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}