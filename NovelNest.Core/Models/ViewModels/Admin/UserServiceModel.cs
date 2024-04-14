namespace NovelNest.Core.Models.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;

    public class UserServiceModel
    {
        public string Email { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        public bool IsPublisher { get; set; }

        public bool IsAdmin { get; set; }
    }
}