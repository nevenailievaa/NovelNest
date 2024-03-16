namespace NovelNest.Core.Models.ViewModels.Book
{
    public class BookAllViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public string PublishingHouse { get; set; } = null!;
        public int YearPublished { get; set; }
    }
}