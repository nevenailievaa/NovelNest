namespace NovelNest.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.ViewModels.Admin;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Security.Claims;
    using static NovelNest.Core.Constants.AdminConstants;
    using static System.Security.Claims.ClaimsPrincipalExtensions;

    public class HomeController : AdminBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly IPublisherService publisherService;
        private readonly IAdminService adminService;

        public HomeController(IPublisherService publisherService, IUserService userService, IAdminService adminService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.publisherService = publisherService;
            this.adminService = adminService;
            this.userManager = userManager;
        }

        public IActionResult Actions()
        {
            return View();
        }

        //Publisher
        [HttpGet]
        public async Task<IActionResult> AddPublisher()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var publisherForm = new UserViewModel();

            return View(publisherForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher(UserViewModel form)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByEmailAsync(form.Email))
            {
                ModelState.AddModelError("Email", "User with this email doesn't exist!");
            }
            else if (await publisherService.ExistsByEmailAsync(form.Email))
            {
                ModelState.AddModelError("Email", "User is already a Publisher.");
            }

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            int newPublisherId = await adminService.AddPublisherAsync(form);
            return RedirectToAction(nameof(Actions));
        }

        [HttpGet]
        public async Task<IActionResult> RemovePublisher(UserViewModel? model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var publisherForm = new UserViewModel();
            if (model != null)
            {
                publisherForm.Email = model.Email;
            }

            return View(publisherForm);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePublisherConfirmed(string email)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            //User doesn't exist
            var user = await userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "User with this email doesn't exist!");
            }
            if (!ModelState.IsValid)
            {
                var publisherForm = new UserViewModel();
                publisherForm.Email = email;
                return View(nameof(RemovePublisher), publisherForm);
            }

            //Publisher doesn't exist
            if (!publisherService.ExistsByEmailAsync(email).Result)
            {
                ModelState.AddModelError("Email", "Publisher with this email doesn't exist!");
            }
            if (!ModelState.IsValid)
            {
                var publisherForm = new UserViewModel();
                publisherForm.Email = email;
                return View(nameof(RemovePublisher), publisherForm);
            }

            //Removing
            var publisher = await publisherService.GetPublisherByEmailAsync(email);
            var model = await adminService.RemovePublisherConfirmedAsync(publisher.Id);

            return RedirectToAction(nameof(Actions));
        }

        //Admin
        [HttpGet]
        public async Task<IActionResult> AddAdmin()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var adminForm = new UserViewModel();

            return View(adminForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(UserViewModel form)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var user = await userService.GetUserByEmailAsync(form.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "User with this email doesn't exist!");
            }
            else if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                ModelState.AddModelError("Email", "User is already an Admin.");
            }
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var result = await userManager.AddToRoleAsync(user, AdminRole);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Email", "Failed to add user to the Admin role!");
            }
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            await AddPublisher(form);
            return RedirectToAction(nameof(Actions));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAdmin(UserViewModel? model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var adminForm = new UserViewModel();
            if (model != null)
            {
                adminForm.Email = model.Email;
            }

            return View(adminForm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdminConfirmed(string email)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            //User doesn't exist
            var user = await userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "User with this email doesn't exist!");
            }
            if (!ModelState.IsValid)
            {
                var publisherForm = new UserViewModel();
                publisherForm.Email = email;
                return View(nameof(RemoveAdmin), publisherForm);
            }

            //Already an Admin
            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                ModelState.AddModelError("Email", "Admin with this email doesn't exist!");
            }
            if (!ModelState.IsValid)
            {
                var publisherForm = new UserViewModel();
                publisherForm.Email = email;
                return View(nameof(RemoveAdmin), publisherForm);
            }

            //Removing
            var result = await userManager.RemoveFromRoleAsync(user, AdminRole);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Email", "Failed to remove user from the Admin role!");
            }
            if (!ModelState.IsValid)
            {
                var publisherForm = new UserViewModel();
                publisherForm.Email = email;
                return View(nameof(RemoveAdmin), publisherForm);
            }

            await RemovePublisherConfirmed(email);
            return RedirectToAction(nameof(Actions));
        }
    }
}