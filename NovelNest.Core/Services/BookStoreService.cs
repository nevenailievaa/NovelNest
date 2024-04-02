namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.BookStore;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using System;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookStoreConstants;

    public class BookStoreService : IBookStoreService
    {
        private readonly IRepository repository;

        public BookStoreService(IRepository repository)
        {
            this.repository = repository;
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

        public async Task<bool> BookStoreExistsAsync(int bookStoreId)
        {
            return await repository.AllAsReadOnly<BookStore>()
                .AnyAsync(bs => bs.Id == bookStoreId);
        }

        public async Task<BookStore> FindBookStoreByIdAsync(int bookStoreId)
        {
            return await repository.GetByIdAsync<BookStore>(bookStoreId);
        }

        public async Task<BookStoreDetailsViewModel> DetailsAsync(int bookStoreId)
        {
            BookStore? currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var currentBookStoreDetails = new BookStoreDetailsViewModel()
            {
                Id = currentBookStore.Id,
                Name = currentBookStore.Name,
                Location = currentBookStore.Location,
                OpeningTime = currentBookStore.OpeningTime.ToString(DateTimeBookStoreFormat),
                ClosingTime = currentBookStore.ClosingTime.ToString(DateTimeBookStoreFormat),
                Contact = currentBookStore.Contact,
                Status = await IsBookstoreOpen(currentBookStore.OpeningTime, currentBookStore.ClosingTime) ? "Отворено" : "Затворено",
                ImageUrl = currentBookStore.ImageUrl
            };

            return currentBookStoreDetails;
        }

        public async Task<int> AddAsync(BookStoreAddViewModel bookStoreForm)
        {
            BookStore bookStore = new BookStore()
            {
                Name = bookStoreForm.Name,
                Location = bookStoreForm.Location,
                OpeningTime = new DateTime(bookStoreForm.OpeningTime.Year, bookStoreForm.OpeningTime.Month, bookStoreForm.OpeningTime.Day, bookStoreForm.OpeningTime.Hour, bookStoreForm.OpeningTime.Minute, 0),
                ClosingTime = new DateTime(bookStoreForm.ClosingTime.Year, bookStoreForm.ClosingTime.Month, bookStoreForm.ClosingTime.Day, bookStoreForm.ClosingTime.Hour, bookStoreForm.ClosingTime.Minute, 0),
                Contact = bookStoreForm.Contact,
                ImageUrl = bookStoreForm.ImageUrl
            };

            await repository.AddAsync(bookStore);
            await repository.SaveChangesAsync();

            return bookStore.Id;
        }

        public async Task<BookStoreEditViewModel> EditGetAsync(int bookStoreId)
        {
            var currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var articleForm = new BookStoreEditViewModel()
            {
                Id = bookStoreId,
                Name = currentBookStore.Name,
                Location = currentBookStore.Location,
                OpeningTime = currentBookStore.OpeningTime,
                ClosingTime = currentBookStore.ClosingTime,
                Contact = currentBookStore.Contact,
                ImageUrl = currentBookStore.ImageUrl
            };

            return articleForm;
        }

        public async Task<int> EditPostAsync(BookStoreEditViewModel bookStoreForm)
        {
            var currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreForm.Id);

            currentBookStore.Name = bookStoreForm.Name;
            currentBookStore.Location = bookStoreForm.Location;

            currentBookStore.OpeningTime = new DateTime(bookStoreForm.OpeningTime.Year, bookStoreForm.OpeningTime.Month, bookStoreForm.OpeningTime.Day, bookStoreForm.OpeningTime.Hour, bookStoreForm.OpeningTime.Minute, 0);

            currentBookStore.ClosingTime = new DateTime(bookStoreForm.ClosingTime.Year, bookStoreForm.ClosingTime.Month, bookStoreForm.ClosingTime.Day, bookStoreForm.ClosingTime.Hour, bookStoreForm.ClosingTime.Minute, 0);

            currentBookStore.Contact = bookStoreForm.Contact;
            currentBookStore.ImageUrl = bookStoreForm.ImageUrl;

            await repository.SaveChangesAsync();

            return currentBookStore.Id;
        }
    }
}