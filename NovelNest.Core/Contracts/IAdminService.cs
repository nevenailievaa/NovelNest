namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Models.ViewModels.Admin;

    public interface  IAdminService
    {
        Task<int> AddPublisherAsync(UserViewModel form);
        Task<UserRemoveViewModel> RemovePublisherAsync(int publisherId);
        Task<int> RemovePublisherConfirmedAsync(int publisherId);

        Task<int> AddAdminAsync(UserViewModel form);
        Task<UserViewModel> RemoveAdminAsync(int userId);
        Task<int> RemoveAdminConfirmedAsync(int userId);
    }
}