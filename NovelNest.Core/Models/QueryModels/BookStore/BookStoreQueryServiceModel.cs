namespace NovelNest.Core.Models.QueryModels.BookStore
{
    public class BookStoreQueryServiceModel
    {
        public int TotalBookStoresCount { get; set; }
        public IEnumerable<BookStoreServiceModel> BookStores { get; set; } = new HashSet<BookStoreServiceModel>();
    }
}