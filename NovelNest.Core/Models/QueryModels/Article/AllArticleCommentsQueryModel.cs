using NovelNest.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace NovelNest.Core.Models.QueryModels.Article
{
    public class AllArticleCommentsQueryModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; } = null!;
        public int CommentsPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public ArticleCommentSorting Sorting { get; set; }

        public int TotalArticleCommentsCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<ArticleCommentServiceModel> ArticleComments { get; set; } = new HashSet<ArticleCommentServiceModel>();
    }
}
