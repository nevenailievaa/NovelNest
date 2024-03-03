namespace NovelNest.Infrastructure.Common
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data;

    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(NovelNestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}