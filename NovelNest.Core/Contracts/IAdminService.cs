namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Models.QueryModels.Admin;
    using NovelNest.Core.Models.ViewModels.Admin;

    public interface IAdminService
    {
        Task<int> AddPublisherAsync(string userId);
        Task<UserServiceModel> RemovePublisherAsync(string userId);
        Task<int> RemovePublisherConfirmedAsync(string userId);


        Task<string> AddAdminAsync(string userId);
        Task<UserServiceModel> RemoveAdminAsync(string userId);
        Task<string> RemoveAdminConfirmedAsync(string userId);
    }
}