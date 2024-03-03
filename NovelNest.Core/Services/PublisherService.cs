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

        public async Task<bool> ExistsByIdAsync(int userId)
        {
            return await repository
                .AllAsReadOnly<Publisher>()
                .AnyAsync(p => p.Id == userId);
        }

        public Task CreateArticleAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateBookAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateBookStoreAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateEventAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}