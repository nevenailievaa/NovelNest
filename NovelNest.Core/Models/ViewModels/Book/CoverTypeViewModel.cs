namespace NovelNest.Core.Models.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;

    public class CoverTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}