namespace NovelNest.Core.Models.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.ArticleConstants;

    public class ArticleAddViewModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength, ErrorMessage = LengthErrorMessage)]
        public string Content { get; set; } = null!;

        [Required]
        [StringLength(ArticleImageUrlMaxLength, MinimumLength = ArticleImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}