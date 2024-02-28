namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new IdentityUser[] { data.GuestUser, data.PublisherUser });
        }
    }
}