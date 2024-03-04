namespace NovelNest.Core.Contracts
{
    public interface IPublisherService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<int?> GetPublisherIdAsync(string UserId);

        //Task CreateBookAsync(int userId);
        //Task CreateBookStoreAsync(int userId);
        //Task CreateEventAsync(int userId);
        //Task CreateArticleAsync(int userId);
    }
}