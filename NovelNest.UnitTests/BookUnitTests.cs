using Microsoft.EntityFrameworkCore;
using NovelNest.Core.Contracts;
using NovelNest.Core.Enums;
using NovelNest.Core.Services;
using NovelNest.Infrastructure.Common;
using NovelNest.Infrastructure.Data;
using NovelNest.Infrastructure.Data.Models.Books;

namespace NovelNest.UnitTests
{
    [TestFixture]
    public class BookUnitTests
    {
        private NovelNestDbContext dbContext;
        private IEnumerable<Book> books;
        private IEnumerable<Genre> genres;
        private IEnumerable<CoverType> coverTypes;

        private Book AnnaKarenina = new Book();
        private Book Hannibal = new Book();
        private Book MenWhoHateWomen = new Book();
        private Book MeBeforeYou = new Book();
        private Book TheDiaryOfAYoungGirl = new Book();

        private CoverType SoftCover = new CoverType();
        private CoverType HardCover = new CoverType();

        private Genre Romance = new Genre();
        private Genre ClassicLiterature = new Genre();
        private Genre Autobiography = new Genre();
        private Genre Crime = new Genre();

        IRepository repository;
        IBookService service;

        [SetUp]
        public void Setup()
        {
            //Books
            AnnaKarenina = new Book()
            {
                Id = 1,
                Title = "Ana Karenina",
                Author = "Leo Tolstoy",
                GenreId = 2,
                Description = "The description of Ana Karenina book",
                Pages = 832,
                YearPublished = 1877,
                CoverTypeId = 2,
                Price = 24.95m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529.jpg",
                PublishingHouse = "Hermes"
            };
            Hannibal = new Book()
            {
                Id = 2,
                Title = "Hannibal",
                Author = "Thomas Harris",
                GenreId = 4,
                Description = "The description of Hannibal book",
                Pages = 488,
                YearPublished = 1999,
                CoverTypeId = 1,
                Price = 19.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/_/-/_-_-_-_9789542838296_-_ciela.jpg",
                PublishingHouse = "Ciela"
            };
            MenWhoHateWomen = new Book()
            {
                Id = 3,
                Title = "Men who hate women",
                Author = "Stieg Larsson",
                GenreId = 4,
                Description = "The description of Men who hate women book",
                Pages = 464,
                YearPublished = 2005,
                CoverTypeId = 1,
                Price = 16.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/m/i/millenium_1.jpg",
                PublishingHouse = "Colibri"
            };
            MeBeforeYou = new Book()
            {
                Id = 4,
                Title = "Me before you",
                Author = "Jojo Moyes",
                GenreId = 1,
                Description = "The description of Me before you book",
                Pages = 408,
                YearPublished = 2012,
                CoverTypeId = 1,
                Price = 17.95m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/a/z/6d3e59789317f6a5d3c5e6dffb38e9db/az-predi-teb-30.jpg",
                PublishingHouse = "Hermes"
            };
            TheDiaryOfAYoungGirl = new Book()
            {
                Id = 5,
                Title = "The diary of a young lady",
                Author = "Anne Frrank",
                GenreId = 3,
                Description = "The description of The diary of a young lady book",
                Pages = 312,
                YearPublished = 1947,
                CoverTypeId = 2,
                Price = 19.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ane-frank-zadnata-kyshta-ciela-9789542827214.jpg",
                PublishingHouse = "Ciela"
            };

            //Genres
            Romance = new Genre()
            {
                Id = 1,
                Name = "Romance"
            };
            ClassicLiterature = new Genre()
            {
                Id = 2,
                Name = "ClassicLiterature"
            };
            Autobiography = new Genre()
            {
                Id = 3,
                Name = "Autobiography"
            };
            Crime = new Genre()
            {
                Id = 4,
                Name = "Crime"
            };

            //Cover Types
            SoftCover = new CoverType()
            {
                Id = 1,
                Name = "Soft"
            };
            HardCover = new CoverType()
            {
                Id = 2,
                Name = "Hard"
            };

            books = new List<Book>()
            {
                AnnaKarenina, Hannibal, MenWhoHateWomen, MeBeforeYou, TheDiaryOfAYoungGirl
            };
            genres = new List<Genre>()
            {
               Romance, ClassicLiterature, Autobiography, Crime
            };
            coverTypes = new List<CoverType>()
            {
                SoftCover, HardCover
            };

            var options = new DbContextOptionsBuilder<NovelNestDbContext>()
                .UseInMemoryDatabase(databaseName: "NovelNestInMemoryDb")
                .Options;

            dbContext = new NovelNestDbContext(options);

            dbContext.AddRangeAsync(books);
            dbContext.AddRangeAsync(coverTypes);
            dbContext.AddRangeAsync(genres);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new BookService(repository);
        }

        [Test]
        public async Task Test_AllAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllAsync("ClassicLiterature");
            var resultTwo = await service.AllAsync("NotAnExistingBook");

            // Assert
            Assert.AreEqual(result.TotalBooksCount, 1);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(resultTwo.TotalBooksCount, 0);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllAsync_FiltersByCoverType()
        {
            // Act
            var result = await service.AllAsync(null, "Hard");
            var resultTwo = await service.AllAsync(null, "NotAnExistingCoverType");

            // Assert
            Assert.AreEqual(result.TotalBooksCount, 2);
            Assert.IsTrue(result.Books.First().Id == 5);
            Assert.IsTrue(result.Books.Skip(1).First().Id == 1);

            Assert.AreEqual(resultTwo.TotalBooksCount, 0);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllAsync(null, null, "Ana");
            var resultTwo = await service.AllAsync(null, null, "NotAValidSearchTerm");

            // Assert
            Assert.AreEqual(result.TotalBooksCount, 1);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(resultTwo.TotalBooksCount, 0);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllAsync_SortingByNewest()
        {
            // Act
            var booksNewestSorting = await service.AllAsync();
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 5, 4, 3, 2, 1});
        }

        [Test]
        public async Task Test_AllAsync_SortingByOldest()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 1, 2, 3, 4, 5 });
        }

        [Test]
        public async Task Test_AllAsync_SortingByTitleAscending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 1, 2, 4, 3, 5 });
        }

        [Test]
        public async Task Test_AllAsync_SortingByTitleDescending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 5, 3, 4, 2, 1 });
        }

        [Test]
        public async Task Test_AllAsync_SortingByAuthorAscending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 5, 4, 1, 3, 2 });
        }

        [Test]
        public async Task Test_AllAsync_SortingByAuthorDescending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 2, 3, 1, 4, 5 });
        }

        [Test]
        public async Task Test_AllAsync_SortingByPriceAscending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 3, 4, 5, 2, 1 });
        }

        [Test]
        public async Task Test_AllAsync_SortingByPriceDescending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(booksNewestSorting.Books.Count(), 5);
            Assert.AreEqual(booksIds, new List<int>() { 1, 5, 2, 4, 3 });
        }

        [Test]
        public async Task Test_BookExistsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int bookId = 1;
            int nonExistingBookId = -1;

            // Act
            var resultOne = await service.BookExistsAsync(bookId);
            var resultTwo = await service.BookExistsAsync(nonExistingBookId);

            // Assert
            Assert.AreEqual(true, resultOne);
            Assert.AreEqual(false, resultTwo);
        }

        [Test]
        public async Task Test_FindBookByIdAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int bookId = 1;
            int nonExistingBookId = -1;

            // Act
            var resultOne = await service.FindBookByIdAsync(bookId);
            var resultTwo = await service.FindBookByIdAsync(nonExistingBookId);

            // Assert
            Assert.IsNotNull(resultOne);
            Assert.AreEqual(bookId, resultOne.Id);

            Assert.IsNull(resultTwo);
        }

        [Test]
        public async Task Test_GenreExistsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int genreId = 1;
            int nonExistingGenreId = -1;

            // Act
            var resultOne = await service.GenreExistsAsync(genreId);
            var resultTwo = await service.GenreExistsAsync(nonExistingGenreId);

            // Assert
            Assert.AreEqual(true, resultOne);
            Assert.AreEqual(false, resultTwo);
        }

        [Test]
        public async Task Test_AllGenresAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllGenresAsync();

            // Assert
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result.First().Name, "Romance");
            Assert.AreEqual(result.Skip(1).First().Name, "ClassicLiterature");
            Assert.AreEqual(result.Skip(2).First().Name, "Autobiography");
            Assert.AreEqual(result.Skip(3).First().Name, "Crime");
        }

        [Test]
        public async Task Test_AllGenresNamesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllGenresNamesAsync();
            var expectedResult = new List<string>() { "Romance", "ClassicLiterature", "Autobiography", "Crime" };

            // Assert
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public async Task Test_CoverTypeExistsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int coverTypeId = 1;
            int nonExistingCoverTypeId = -1;

            // Act
            var resultOne = await service.CoverTypeExistsAsync(coverTypeId);
            var resultTwo = await service.CoverTypeExistsAsync(nonExistingCoverTypeId);

            // Assert
            Assert.AreEqual(true, resultOne);
            Assert.AreEqual(false, resultTwo);
        }

        [Test]
        public async Task Test_AllCoverTypesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllCoverTypesAsync();

            // Assert
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.First().Name, "Soft");
            Assert.AreEqual(result.Skip(1).First().Name, "Hard");
        }

        [Test]
        public async Task Test_AllCoverTypesNamesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllCoverTypesNamesAsync();
            var expectedResult = new List<string>() { "Soft", "Hard" };

            // Assert
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result, expectedResult);
        }

        [TearDown]
        public void Teardown()
        {
            dbContext.Dispose();
        }

    }
}