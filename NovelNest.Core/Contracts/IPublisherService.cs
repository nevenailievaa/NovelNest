namespace NovelNest.Core.Contracts
{
    public interface IPublisherService
    {
        Task<bool> ExistsByIdAsync(int userId);
        Task CreateBookAsync(int userId);
        Task CreateBookStoreAsync(int userId);
        Task CreateEventAsync(int userId);
        Task CreateArticleAsync(int userId);
    }
}