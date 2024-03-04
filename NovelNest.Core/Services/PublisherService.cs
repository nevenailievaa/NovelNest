namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Threading.Tasks;

    public class PublisherService : IPublisherService
    {
        private readonly IRepository repository;

        public PublisherService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<Publisher>()
                .AnyAsync(p => p.UserId == userId);
        }

        public async Task<int?> GetPublisherIdAsync(string userId)
        {
            //Returns the Id or null
            return (await repository
                .AllAsReadOnly<Publisher>()
                .FirstOrDefaultAsync(p => p.UserId == userId))?.Id;
        }
    }
}