namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Roles;

    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ApplicationUser[] { data.GuestUser, data.PublisherUser, data.AdminUser, data.RandomUserOne, data.RandomUserTwo });
        }
    }
}