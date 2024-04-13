using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NovelNest.Core.Contracts;
using NovelNest.Core.Models.ViewModels.Admin;
using NovelNest.Infrastructure.Common;
using NovelNest.Infrastructure.Data.Models.Roles;

namespace NovelNest.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repository;
        private readonly IPublisherService publisherService;
        private readonly IUserService userService;

        public AdminService(IRepository repository, IPublisherService publisherService, IUserService userService)
        {
            this.repository = repository;
            this.publisherService = publisherService;
            this.userService = userService;
        }

        public async Task<int> AddPublisherAsync(UserViewModel form)
        {
            IdentityUser user = userService.GetUserByEmailAsync(form.Email).Result;

            Publisher publisher = new Publisher()
            {
                UserId = user.Id
            };

            await repository.AddAsync(publisher);
            await repository.SaveChangesAsync();

            return publisher.Id;
        }

        public async Task<UserRemoveViewModel> RemovePublisherAsync(int publisherId)
        {
            Publisher? publisher = repository.GetByIdAsync<Publisher>(publisherId).Result;

            var deleteForm = new UserRemoveViewModel()
            {
                Id = publisherId,
                FirstName = publisher.User.FirstName,
                LastName = publisher.User.LastName,
                Email = publisher.User.Email
            };

            return deleteForm;
        }

        public async Task<int> RemovePublisherConfirmedAsync(int publisherId)
        {
            Publisher? publisher = repository.GetByIdAsync<Publisher>(publisherId).Result;

            await repository.RemoveAsync<Publisher>(publisher);
            await repository.SaveChangesAsync();

            return publisher.Id;
        }

        public Task<int> AddAdminAsync(UserViewModel form)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> RemoveAdminAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAdminConfirmedAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}