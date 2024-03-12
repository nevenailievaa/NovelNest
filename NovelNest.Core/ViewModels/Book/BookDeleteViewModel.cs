namespace NovelNest.Core.ViewModels.Book
{
    public class BookDeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}