namespace NovelNest.Core.Models.QueryModels.Admin
{
    public class UserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }
        public IEnumerable<UserServiceModel> Users { get; set; } = new HashSet<UserServiceModel>();
    }
}