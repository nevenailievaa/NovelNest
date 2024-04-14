namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new DataSeed();

            builder.HasData(data.AdminUserClaim, data.PublisherUserClaim, data.GuestUserClaim, data.RandomUserOneClaim, data.RandomUserTwoClaim);
        }
    }
}