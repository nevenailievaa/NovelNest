namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.BookStore;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using System;

    public class BookStoreService : IBookStoreService
    {
        private readonly IRepository repository;

        public BookStoreService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<BookStoreQueryServiceModel> AllAsync(
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4)
        {
            var bookStoresToShow = repository.AllAsReadOnly<BookStore>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                bookStoresToShow = bookStoresToShow
                .Where(bs => normalizedSearchTerm.Contains(bs.Name.ToLower())
                || normalizedSearchTerm.Contains(bs.Location.ToLower())
                || normalizedSearchTerm.Contains(bs.OpeningTime.ToString().ToLower())
                || normalizedSearchTerm.Contains(bs.ClosingTime.ToString().ToLower())

                || bs.Name.ToLower().Contains(normalizedSearchTerm)
                || bs.Location.ToLower().Contains(normalizedSearchTerm)
                || bs.OpeningTime.ToString().ToLower().Contains(normalizedSearchTerm)
                || bs.ClosingTime.ToString().ToLower().Contains(normalizedSearchTerm));
            }

            var currentBookStores = await bookStoresToShow.ToListAsync();
            if (status == BookStoreStatus.Open)
            {
                currentBookStores = currentBookStores.Where(bs => IsBookstoreOpen(bs.OpeningTime, bs.ClosingTime).Result == true).ToList();
            }
            else if (status == BookStoreStatus.Closed)
            {
                currentBookStores = currentBookStores.Where(bs => IsBookstoreOpen(bs.OpeningTime, bs.ClosingTime).Result == false).ToList();
            }

            var bookStores = currentBookStores
                .Skip((currentPage - 1) * bookStoresPerPage)
                .Take(bookStoresPerPage)
                .ToList();

            int totalBookStores = currentBookStores.Count();

            var bookStoreServiceModels = bookStores.Select(bs => new BookStoreServiceModel()
            {
                Id = bs.Id,
                Name = bs.Name,
                Location = bs.Location,
                OpeningTime = bs.OpeningTime,
                ClosingTime = bs.ClosingTime,
                ImageUrl = bs.ImageUrl
            }).ToList();

            return new BookStoreQueryServiceModel()
            {
                BookStores = bookStoreServiceModels,
                TotalBookStoresCount = totalBookStores
            };
        }

        public async Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync()
        {
            return await repository
                .AllAsReadOnly<BookStore>()
                .OrderByDescending(b => b.BooksBookStores.Count)
                .Select(bs => new BookStoreIndexViewModel()
                {
                    Id = bs.Id,
                    Name = bs.Name,
                    ImageUrl = bs.ImageUrl
                })
                .Take(10)
                .ToListAsync();
        }

        private async Task<bool> IsBookstoreOpen(DateTime openingTime, DateTime closingTime)
        {
            var now = DateTime.Now;

            if (now.Hour < openingTime.Hour || now.Hour > closingTime.Hour)
            {
                return false;
            }

            if (now.Hour > openingTime.Hour && now.Hour < closingTime.Hour)
            {
                return true;
            }

            if (now.Hour == openingTime.Hour)
            {
                if (now.Minute >= openingTime.Minute)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (now.Minute <= closingTime.Minute)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}