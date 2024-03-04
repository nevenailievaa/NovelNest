namespace NovelNest.Core.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.GenreConstants;

    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}