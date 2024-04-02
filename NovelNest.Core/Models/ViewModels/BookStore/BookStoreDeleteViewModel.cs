using NovelNest.Core.Contracts;

namespace NovelNest.Core.Models.ViewModels.BookStore
{
    public class BookStoreDeleteViewModel : IBookStoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}