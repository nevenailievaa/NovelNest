namespace NovelNest.Infrastructure.Common
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(NovelNestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}