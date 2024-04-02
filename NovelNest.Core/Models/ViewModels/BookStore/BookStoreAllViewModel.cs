namespace NovelNest.Core.Models.ViewModels.BookStore
{
    public class BookStoreAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}