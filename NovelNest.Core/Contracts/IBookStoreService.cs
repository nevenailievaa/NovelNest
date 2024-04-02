﻿namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.BookStore;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Infrastructure.Data.Models.BookStores;

    public interface IBookStoreService
    {
        Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync();
        Task<BookStoreQueryServiceModel> AllAsync(
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4);
        Task<bool> BookStoreExistsAsync(int bookStoreId);
        Task<BookStore> FindBookStoreByIdAsync(int bookStoreId);
        Task<BookStoreDetailsViewModel> DetailsAsync(int bookStoreId);
    }
}