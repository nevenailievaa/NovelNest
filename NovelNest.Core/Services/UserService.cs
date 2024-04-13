namespace NovelNest.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Roles;

    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ExistsByEmailAsync(string userEmail)
        {
            return await repository.AllAsReadOnly<ApplicationUser>().AnyAsync(u => u.Email.ToLower() == userEmail.ToLower());
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllAsReadOnly<ApplicationUser>().AnyAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string userEmail)
        {
            return await repository.All<ApplicationUser>().Where(u => u.Email.ToLower() == userEmail.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await repository.GetByIdAsync<ApplicationUser>(userId);
        }
    }
}