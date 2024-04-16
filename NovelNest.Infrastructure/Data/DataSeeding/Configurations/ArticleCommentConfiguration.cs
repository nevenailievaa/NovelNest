namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Articles;

    internal class ArticleCommentConfiguration : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ArticleComment[] { data.CommentOne, data.CommentTwo, data.CommentThree, data.CommentFour });
        }
    }
}