using NovelNest.Core.Contracts;

namespace NovelNest.Core.Models.ViewModels.BookStore
{
    public class BookStoreDetailsViewModel : IBookStoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string OpeningTime { get; set; } = null!;
        public string ClosingTime { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}