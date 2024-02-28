namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Articles;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Article[] { data.ArticleMenWhoHateWomen, data.ArticleHarryPotter, data.ArticleBaiTosho });
        }
    }
}