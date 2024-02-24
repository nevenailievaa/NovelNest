using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NovelNest.Infrastructure.Data
{
    public class NovelNestDbContext : IdentityDbContext
    {
        public NovelNestDbContext(DbContextOptions<NovelNestDbContext> options)
            : base(options)
        {
        }
    }
}