namespace NovelNest.Core.Models.QueryModels.Article
{
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.ArticleCommentConstants;
    public class ArticleCommentServiceModel
    {
        public int Id { get; set; }

        [StringLength(ArticleCommentTitleMaxLength, MinimumLength = ArticleCommentTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [StringLength(ArticleCommentDescriptionMaxLength, MinimumLength = ArticleCommentDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}