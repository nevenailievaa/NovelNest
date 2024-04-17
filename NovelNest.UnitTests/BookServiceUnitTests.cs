namespace NovelNest.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Core.Services;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookUserActions;

    [TestFixture]
    public class BookServiceUnitTests
    {
        private NovelNestDbContext dbContext;
        private IEnumerable<Book> books;
        private IEnumerable<Genre> genres;
        private IEnumerable<CoverType> coverTypes;

        private IRepository repository;
        private IBookService service;

        //Books
        private Book AnnaKarenina;
        private Book Hannibal;
        private Book MenWhoHateWomen;
        private Book MeBeforeYou;
        private Book TheDiaryOfAYoungGirl;

        //Covers
        private CoverType SoftCover;
        private CoverType HardCover;

        //Genres
        private Genre Romance;
        private Genre ClassicLiterature;
        private Genre Autobiography;
        private Genre Crime;

        //Book Collections
        private BookUserWantToRead bookUserWantToRead;
        private BookUserCurrentlyReading bookUserCurrentlyReading;
        private BookUserRead bookUserRead;

        //Book Reviews
        private BookReview bookReview;


        [SetUp]
        public async Task Setup()
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

            //Book Collections
            bookUserWantToRead = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 1,
                TimeAdded = DateTime.Now
            };
            bookUserCurrentlyReading = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 2,
                TimeAdded = DateTime.Now
            };
            bookUserRead = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 3,
                TimeAdded = DateTime.Now
            };

            //Book Reviews
            bookReview = new BookReview()
            {
                Id = 1,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title",
                Description = "Review Description",
                Rate = 10
            };

            //Databases
            var options = new DbContextOptionsBuilder<NovelNestDbContext>()
                .UseInMemoryDatabase(databaseName: "NovelNestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new NovelNestDbContext(options);

            dbContext.AddRangeAsync(books);
            dbContext.AddRangeAsync(coverTypes);
            dbContext.AddRangeAsync(genres);
            dbContext.AddAsync(bookUserWantToRead);
            dbContext.AddAsync(bookUserCurrentlyReading);
            dbContext.AddAsync(bookUserRead);
            dbContext.AddAsync(bookReview);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new BookService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_AllAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllAsync("ClassicLiterature");
            var resultTwo = await service.AllAsync("NotAnExistingBook");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllAsync_FiltersByCoverType()
        {
            // Act
            var result = await service.AllAsync(null, "Hard");
            var resultTwo = await service.AllAsync(null, "NotAnExistingCoverType");

            // Assert
            Assert.AreEqual(2, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 5);
            Assert.IsTrue(result.Books.Skip(1).First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllAsync(null, null, "Ana");
            var resultTwo = await service.AllAsync(null, null, "NotAValidSearchTerm");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllAsync_SortsByNewest()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 3, 2, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByOldest()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 2, 3, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByTitleAscending()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 2, 4, 3, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByTitleDescending()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 3, 4, 2, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByAuthorAscending()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 1, 3, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByAuthorDescending()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 3, 1, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByPriceAscending()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 3, 4, 5, 2, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllAsync_SortsByPriceDescending()
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
            Assert.AreEqual(5, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 5, 2, 4, 3 }, booksIds);
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
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual("Romance", result.First().Name);
            Assert.AreEqual("ClassicLiterature", result.Skip(1).First().Name);
            Assert.AreEqual("Autobiography", result.Skip(2).First().Name);
            Assert.AreEqual("Crime", result.Skip(3).First().Name);
        }

        [Test]
        public async Task Test_AllGenresNamesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllGenresNamesAsync();
            var expectedResult = new List<string>() { "Romance", "ClassicLiterature", "Autobiography", "Crime" };

            // Assert
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(expectedResult, result);
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
        public async Task Test_DetailsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var currentBookDetails = new BookViewModel()
            {
                Id = AnnaKarenina.Id,
                Title = AnnaKarenina.Title,
                Author = AnnaKarenina.Author,
                Genre = AnnaKarenina.Genre.Name,
                Description = AnnaKarenina.Description,
                Pages = AnnaKarenina.Pages,
                PublishingHouse = AnnaKarenina.PublishingHouse,
                YearPublished = AnnaKarenina.YearPublished,
                CoverType = AnnaKarenina.CoverType.Name,
                Price = AnnaKarenina.Price,
                ImageUrl = AnnaKarenina.ImageUrl,
                Reviews = new List<BookReview>() { bookReview }
            };

            // Act
            var result = await service.DetailsAsync(AnnaKarenina.Id);

            // Assert
            Assert.AreEqual(currentBookDetails.Id, result.Id);
            Assert.AreEqual(currentBookDetails.Title, result.Title);
            Assert.AreEqual(currentBookDetails.Author, result.Author);
            Assert.AreEqual(currentBookDetails.Genre, result.Genre);
            Assert.AreEqual(currentBookDetails.Description, result.Description);
            Assert.AreEqual(currentBookDetails.Pages, result.Pages);
            Assert.AreEqual(currentBookDetails.PublishingHouse, result.PublishingHouse);
            Assert.AreEqual(currentBookDetails.YearPublished, result.YearPublished);
            Assert.AreEqual(currentBookDetails.CoverType, result.CoverType);
            Assert.AreEqual(currentBookDetails.Price, result.Price);
            Assert.AreEqual(currentBookDetails.ImageUrl, result.ImageUrl);
            Assert.AreEqual(currentBookDetails.Reviews.Count, result.Reviews.Count);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", "ClassicLiterature");
            var resultTwo = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", "NotAnExistingBook");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_FiltersByCoverType()
        {
            // Act
            var result = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, "Hard");
            var resultTwo = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, "Soft");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, "Ana");
            var resultTwo = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, "NotAValidSearchTerm");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByNewest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksNewestSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser");
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(3, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByOldest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksOldestSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksOldestSorting.Books.First().Id,
                booksOldestSorting.Books.Skip(1).First().Id,
                booksOldestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksOldestSorting.Books);
            Assert.AreEqual(3, booksOldestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByTitleAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleAscendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksTitleAscendingSorting.Books.First().Id,
                booksTitleAscendingSorting.Books.Skip(1).First().Id,
                booksTitleAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksTitleAscendingSorting.Books);
            Assert.AreEqual(3, booksTitleAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByTitleDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleDescendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksTitleDescendingSorting.Books.First().Id,
                booksTitleDescendingSorting.Books.Skip(1).First().Id,
                booksTitleDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksTitleDescendingSorting.Books);
            Assert.AreEqual(3, booksTitleDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByAuthorAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorAscendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksAuthorAscendingSorting.Books.First().Id,
                booksAuthorAscendingSorting.Books.Skip(1).First().Id,
                booksAuthorAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksAuthorAscendingSorting.Books);
            Assert.AreEqual(3, booksAuthorAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByAuthorDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorDescendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksAuthorDescendingSorting.Books.First().Id,
                booksAuthorDescendingSorting.Books.Skip(1).First().Id,
                booksAuthorDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksAuthorDescendingSorting.Books);
            Assert.AreEqual(3, booksAuthorDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByPriceAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceAscendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksPriceAscendingSorting.Books.First().Id,
                booksPriceAscendingSorting.Books.Skip(1).First().Id,
                booksPriceAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksPriceAscendingSorting.Books);
            Assert.AreEqual(3, booksPriceAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 4, 5, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByPriceDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceDescendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksPriceDescendingSorting.Books.First().Id,
                booksPriceDescendingSorting.Books.Skip(1).First().Id,
                booksPriceDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksPriceDescendingSorting.Books);
            Assert.AreEqual(3, booksPriceDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 1, 5, 4 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", "Crime");
            var resultTwo = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", "NotAnExistingBook");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 2);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_FiltersByCoverType()
        {
            // Act
            var result = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, "Soft");
            var resultTwo = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, "Hard");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 2);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, "Hann");
            var resultTwo = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, "NotAValidSearchTerm");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 2);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByNewest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksNewestSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser");
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(3, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByOldest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksOldestSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksOldestSorting.Books.First().Id,
                booksOldestSorting.Books.Skip(1).First().Id,
                booksOldestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksOldestSorting.Books);
            Assert.AreEqual(3, booksOldestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByTitleAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleAscendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksTitleAscendingSorting.Books.First().Id,
                booksTitleAscendingSorting.Books.Skip(1).First().Id,
                booksTitleAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksTitleAscendingSorting.Books);
            Assert.AreEqual(3, booksTitleAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByTitleDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleDescendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksTitleDescendingSorting.Books.First().Id,
                booksTitleDescendingSorting.Books.Skip(1).First().Id,
                booksTitleDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksTitleDescendingSorting.Books);
            Assert.AreEqual(3, booksTitleDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByAuthorAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorAscendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksAuthorAscendingSorting.Books.First().Id,
                booksAuthorAscendingSorting.Books.Skip(1).First().Id,
                booksAuthorAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksAuthorAscendingSorting.Books);
            Assert.AreEqual(3, booksAuthorAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByAuthorDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorDescendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksAuthorDescendingSorting.Books.First().Id,
                booksAuthorDescendingSorting.Books.Skip(1).First().Id,
                booksAuthorDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksAuthorDescendingSorting.Books);
            Assert.AreEqual(3, booksAuthorDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByPriceAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceAscendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksPriceAscendingSorting.Books.First().Id,
                booksPriceAscendingSorting.Books.Skip(1).First().Id,
                booksPriceAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksPriceAscendingSorting.Books);
            Assert.AreEqual(3, booksPriceAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 4, 5, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByPriceDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceDescendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksPriceDescendingSorting.Books.First().Id,
                booksPriceDescendingSorting.Books.Skip(1).First().Id,
                booksPriceDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksPriceDescendingSorting.Books);
            Assert.AreEqual(3, booksPriceDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 2, 4 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllReadBooksIdsByUserIdAsync("testUser", "Crime");
            var resultTwo = await service.AllReadBooksIdsByUserIdAsync("testUser", "NotAnExistingBook");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 3);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_FiltersByCoverType()
        {
            // Act
            var result = await service.AllReadBooksIdsByUserIdAsync("testUser", null, "Soft");
            var resultTwo = await service.AllReadBooksIdsByUserIdAsync("testUser", null, "Hard");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 3);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, "Men Who");
            var resultTwo = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, "NotAValidSearchTerm");

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 3);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByNewest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksNewestSorting = await service.AllReadBooksIdsByUserIdAsync("testUser");
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(3, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 3 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByOldest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksOldestSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksOldestSorting.Books.First().Id,
                booksOldestSorting.Books.Skip(1).First().Id,
                booksOldestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksOldestSorting.Books);
            Assert.AreEqual(3, booksOldestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 3, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByTitleAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleAscendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksTitleAscendingSorting.Books.First().Id,
                booksTitleAscendingSorting.Books.Skip(1).First().Id,
                booksTitleAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksTitleAscendingSorting.Books);
            Assert.AreEqual(3, booksTitleAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 4, 3, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByTitleDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleDescendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksTitleDescendingSorting.Books.First().Id,
                booksTitleDescendingSorting.Books.Skip(1).First().Id,
                booksTitleDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksTitleDescendingSorting.Books);
            Assert.AreEqual(3, booksTitleDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 3, 4 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByAuthorAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorAscendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksAuthorAscendingSorting.Books.First().Id,
                booksAuthorAscendingSorting.Books.Skip(1).First().Id,
                booksAuthorAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksAuthorAscendingSorting.Books);
            Assert.AreEqual(3, booksAuthorAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 3 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByAuthorDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorDescendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksAuthorDescendingSorting.Books.First().Id,
                booksAuthorDescendingSorting.Books.Skip(1).First().Id,
                booksAuthorDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksAuthorDescendingSorting.Books);
            Assert.AreEqual(3, booksAuthorDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 3, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByPriceAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceAscendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksPriceAscendingSorting.Books.First().Id,
                booksPriceAscendingSorting.Books.Skip(1).First().Id,
                booksPriceAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksPriceAscendingSorting.Books);
            Assert.AreEqual(3, booksPriceAscendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 3, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByPriceDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceDescendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksPriceDescendingSorting.Books.First().Id,
                booksPriceDescendingSorting.Books.Skip(1).First().Id,
                booksPriceDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(booksPriceDescendingSorting.Books);
            Assert.AreEqual(3, booksPriceDescendingSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 3 }, booksIds);
        }

        [Test]
        public async Task Test_AllCoverTypesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllCoverTypesAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Soft", result.First().Name);
            Assert.AreEqual("Hard", result.Skip(1).First().Name);
        }

        [Test]
        public async Task Test_BookIsInAnotherCollectionAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultWantToRead = await service.BookIsInAnotherCollectionAsync(1, "testUser");
            var resultCurrentlyReading = await service.BookIsInAnotherCollectionAsync(2, "testUser");
            var resultRead = await service.BookIsInAnotherCollectionAsync(3, "testUser");
            var resultNotInCollection = await service.BookIsInAnotherCollectionAsync(4, "testUser");

            // Assert
            Assert.IsTrue(resultWantToRead);
            Assert.IsTrue(resultCurrentlyReading);
            Assert.IsTrue(resultRead);
            Assert.IsFalse(resultNotInCollection);
        }

        [Test]
        public async Task Test_RemoveBookFromAllCollectionsAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultWantToRead = service.RemoveBookFromAllCollectionsAsync(1, "testUser").Result;
            var resultCurrentlyReading = service.RemoveBookFromAllCollectionsAsync(2, "testUser").Result;
            var resultRead = service.RemoveBookFromAllCollectionsAsync(3, "testUser").Result;

            // Assert
            Assert.AreEqual(1, resultWantToRead);
            Assert.AreEqual(1, resultCurrentlyReading);
            Assert.AreEqual(1, resultRead);
        }

        [Test]
        public async Task Test_BookIsWantToReadAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultWantToRead = await service.BookIsWantToReadAsync(1, "testUser");
            var resultNotWantToRead = await service.BookIsWantToReadAsync(2, "testUser");

            // Assert
            Assert.IsTrue(resultWantToRead);
            Assert.IsFalse(resultNotWantToRead);
        }

        [Test]
        public async Task Test_BookIsCurrentlyReadingAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultCurrentlyReading = await service.BookIsCurrentlyReadingAsync(2, "testUser");
            var resultNotCurrentlyReading = await service.BookIsCurrentlyReadingAsync(1, "testUser");

            // Assert
            Assert.IsTrue(resultCurrentlyReading);
            Assert.IsFalse(resultNotCurrentlyReading);
        }

        [Test]
        public async Task Test_BookIsReadAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultRead = await service.BookIsReadAsync(3, "testUser");
            var resultNotRead = await service.BookIsReadAsync(1, "testUser");

            // Assert
            Assert.IsTrue(resultRead);
            Assert.IsFalse(resultNotRead);
        }

        [Test]
        public async Task Test_AddWantToReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testSecondUser";

            // Act
            var result = await service.AddWantToReadBookAsync(1, userId);
            var expectedResult = await service.BookIsWantToReadAsync(1, userId);

            // Assert
            Assert.AreEqual(1, result);
            Assert.IsTrue(expectedResult);
        }

        [Test]
        public async Task Test_AddCurrentlyReadingBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testSecondUser";

            // Act
            var result = await service.AddCurrentlyReadingBookAsync(2, userId);
            var expectedResult = await service.BookIsCurrentlyReadingAsync(2, userId);
            var book = await service.FindBookCurrentlyReadingAsync(2, userId);

            // Assert
            Assert.AreEqual(2, result);
            Assert.IsTrue(expectedResult);
            Assert.AreEqual(1, book.CurrentPage);
        }

        [Test]
        public async Task Test_AddReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testSecondUser";

            // Act
            var result = await service.AddReadBookAsync(3, userId);
            var expectedResult = await service.BookIsReadAsync(3, userId);

            // Assert
            Assert.AreEqual(3, result);
            Assert.IsTrue(expectedResult);
        }

        [Test]
        public async Task Test_RemoveWantToReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testUser";

            // Act
            var result = await service.RemoveWantToReadBookAsync(1, userId);
            var expectedResult = await service.BookIsWantToReadAsync(1, userId);

            // Assert
            Assert.AreEqual(1, result);
            Assert.IsFalse(expectedResult);
        }

        [Test]
        public async Task Test_RemoveCurrentlyReadingBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testUser";

            // Act
            var result = await service.RemoveCurrentlyReadingBookAsync(2, userId);
            var expectedResult = await service.BookIsCurrentlyReadingAsync(2, userId);

            // Assert
            Assert.AreEqual(2, result);
            Assert.IsFalse(expectedResult);
        }

        [Test]
        public async Task Test_RemoveReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testUser";

            // Act
            var result = await service.RemoveReadBookAsync(3, userId);
            var expectedResult = await service.BookIsReadAsync(3, userId);

            // Assert
            Assert.AreEqual(3, result);
            Assert.IsFalse(expectedResult);
        }
        
        [Test]
        public async Task Test_AllBookReviewsAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllBookReviewsAsync(AnnaKarenina.Id, AnnaKarenina.Title, "Review Title");
            var resultTwo = await service.AllBookReviewsAsync(AnnaKarenina.Id, AnnaKarenina.Title, "Not a valid search");

            // Assert
            Assert.AreEqual(1, result.TotalReviewsCount);
            Assert.IsTrue(result.BookReviews.First().Id == 1);

            Assert.AreEqual(0, resultTwo.TotalReviewsCount);
            Assert.IsEmpty(resultTwo.BookReviews);
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByNewest()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 10
            };
            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 10
            };
            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsNewestSorting = await service.AllBookReviewsAsync(AnnaKarenina.Id, AnnaKarenina.Title);
            var booksIds = new List<int>()
            {
                bookReviewsNewestSorting.BookReviews.First().Id,
                bookReviewsNewestSorting.BookReviews.Skip(1).First().Id,
                bookReviewsNewestSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(bookReviewsNewestSorting.BookReviews);
            Assert.AreEqual(3, bookReviewsNewestSorting.BookReviews.Count());
            Assert.AreEqual(new List<int>() { 3, 2, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByOldest()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 10
            };
            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 10
            };
            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsOldestSorting = await service.AllBookReviewsAsync(AnnaKarenina.Id, AnnaKarenina.Title, null, BookReviewSorting.Oldest);
            var booksIds = new List<int>()
            {
                bookReviewsOldestSorting.BookReviews.First().Id,
                bookReviewsOldestSorting.BookReviews.Skip(1).First().Id,
                bookReviewsOldestSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(bookReviewsOldestSorting.BookReviews);
            Assert.AreEqual(3, bookReviewsOldestSorting.BookReviews.Count());
            Assert.AreEqual(new List<int>() { 1, 2, 3 }, booksIds);
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByRateAscending()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 9
            };
            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 8
            };
            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsRateAscendingSorting = await service.AllBookReviewsAsync(AnnaKarenina.Id, AnnaKarenina.Title, null, BookReviewSorting.RateAscending);
            var booksIds = new List<int>()
            {
                bookReviewsRateAscendingSorting.BookReviews.First().Id,
                bookReviewsRateAscendingSorting.BookReviews.Skip(1).First().Id,
                bookReviewsRateAscendingSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(bookReviewsRateAscendingSorting.BookReviews);
            Assert.AreEqual(3, bookReviewsRateAscendingSorting.BookReviews.Count());
            Assert.AreEqual(new List<int>() { 3, 2, 1 }, booksIds);
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByRateDescending()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 9
            };
            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 8
            };
            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsRateDescendingSorting = await service.AllBookReviewsAsync(AnnaKarenina.Id, AnnaKarenina.Title, null, BookReviewSorting.RateDescending);
            var booksIds = new List<int>()
            {
                bookReviewsRateDescendingSorting.BookReviews.First().Id,
                bookReviewsRateDescendingSorting.BookReviews.Skip(1).First().Id,
                bookReviewsRateDescendingSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.IsNotNull(bookReviewsRateDescendingSorting.BookReviews);
            Assert.AreEqual(3, bookReviewsRateDescendingSorting.BookReviews.Count());
            Assert.AreEqual(new List<int>() { 1, 2, 3 }, booksIds);
        }

        [Test]
        public async Task Test_AddBookReviewAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new BookReviewAddViewModel()
            {
                UserId = "testUser",
                BookId = 2,
                Title = "Review Title",
                Description = "Review Description",
                Rate = 10
            };

            // Act
            var result = await service.AddBookReviewAsync(addForm, "testUser", 2);
            var expectedResult = await service.FindBookReviewByIdAsync(result);

            // Assert
            Assert.AreEqual(2, result);
            Assert.IsNotNull(expectedResult);
        }

        [Test]
        public async Task Test_FindBookReviewAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExistingReview = await service.FindBookReviewByIdAsync(1);

            // Assert
            Assert.IsNotNull(resultExistingReview);
            Assert.AreEqual(bookReview.Id, resultExistingReview.Id);
        }

        [Test]
        public async Task Test_DeleteBookReviewAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var deleteModel = new BookReviewDeleteViewModel()
            {
                ReviewId = bookReview.Id,
                BookId = bookReview.BookId,
                BookTitle = AnnaKarenina.Title
            };

            // Act
            var result = await service.DeleteBookReviewAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(deleteModel.ReviewId, result.ReviewId);
            Assert.AreEqual(deleteModel.BookId, result.BookId);
            Assert.AreEqual(deleteModel.BookTitle, result.BookTitle);
        }

        [Test]
        public async Task Test_DeleteBookReviewConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.DeleteBookReviewConfirmedAsync(1);

            // Assert
            Assert.AreEqual(1, result);
            Assert.IsNull(await service.FindBookReviewByIdAsync(1));
        }

        [Test]
        public async Task Test_BookReviewDetailsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewDetails = new BookReviewDetailsViewModel()
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Title = bookReview.Title,
                Description = bookReview.Description,
                Rate = bookReview.Rate,
                AuthorId = bookReview.UserId
            };

            // Act
            var result = await service.BookReviewDetailsAsync(1);

            // Assert
            Assert.AreEqual(bookReviewDetails.Id, result.Id);
            Assert.AreEqual(bookReviewDetails.BookId, result.BookId);
            Assert.AreEqual(bookReviewDetails.Title, result.Title);
            Assert.AreEqual(bookReviewDetails.Description, result.Description);
            Assert.AreEqual(bookReviewDetails.Rate, result.Rate);
            Assert.AreEqual(bookReviewDetails.AuthorId, result.AuthorId);
        }

        [Test]
        public async Task Test_EditBookReviewGetAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewDetails = new BookReviewEditViewModel()
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Title = bookReview.Title,
                Description = bookReview.Description,
                Rate = bookReview.Rate,
                UserId = bookReview.UserId
            };

            // Act
            var result = await service.EditBookReviewGetAsync(1);

            // Assert
            Assert.AreEqual(bookReviewDetails.Id, result.Id);
            Assert.AreEqual(bookReviewDetails.BookId, result.BookId);
            Assert.AreEqual(bookReviewDetails.Title, result.Title);
            Assert.AreEqual(bookReviewDetails.Description, result.Description);
            Assert.AreEqual(bookReviewDetails.Rate, result.Rate);
            Assert.AreEqual(bookReviewDetails.UserId, result.UserId);
        }

        [Test]
        public async Task Test_EditBookReviewPostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewDetails = new BookReviewEditViewModel()
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Title = bookReview.Title + " Changed",
                Description = bookReview.Description + " Changed",
                Rate = bookReview.Rate - 1,
                UserId = bookReview.UserId
            };

            // Act
            var result = await service.EditBookReviewPostAsync(bookReviewDetails);
            var editedReview = await service.FindBookReviewByIdAsync(bookReview.Id);

            // Assert
            Assert.AreEqual(bookReview.Id, result);

            Assert.AreEqual(bookReviewDetails.Id, editedReview.Id);
            Assert.AreEqual(bookReviewDetails.BookId, editedReview.BookId);
            Assert.AreEqual(bookReviewDetails.Title, editedReview.Title);
            Assert.AreEqual(bookReviewDetails.Description, editedReview.Description);
            Assert.AreEqual(bookReviewDetails.Rate, editedReview.Rate);
            Assert.AreEqual(bookReviewDetails.UserId, editedReview.UserId);
        }

        [Test]
        public async Task Test_BookReviewQuestionAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewQuestion = new BookReviewQuestionViewModel()
            {
                Title = MenWhoHateWomen.Title,
                Id = MenWhoHateWomen.Id
            };

            // Act
            var result = await service.BookReviewQuestionAsync(3);

            // Assert
            Assert.AreEqual(bookReviewQuestion.Title, result.Title);
            Assert.AreEqual(bookReviewQuestion.Id, result.Id);
        }

        [Test]
        public async Task Test_ChangePageGetAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var changePageForm = new ChangePageViewModel()
            {
                BookId = Hannibal.Id,
                UserId = "testUser",
                BookPages = Hannibal.Pages,
                CurrentPage = 0
            };

            // Act
            var result = await service.ChangePageGetAsync(Hannibal.Id, "testUser");

            // Assert
            Assert.AreEqual(changePageForm.BookId, result.BookId);
            Assert.AreEqual(changePageForm.UserId, result.UserId);
            Assert.AreEqual(changePageForm.BookPages, result.BookPages);
            Assert.AreEqual(changePageForm.CurrentPage, result.CurrentPage);
        }

        [Test]
        public async Task Test_ChangePagePostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var changePageForm = new ChangePageViewModel()
            {
                BookId = Hannibal.Id,
                UserId = "testUser",
                BookPages = Hannibal.Pages,
                CurrentPage = 30
            };

            // Act
            var result = await service.ChangePagePostAsync(changePageForm);
            var book = await service.FindBookCurrentlyReadingAsync(Hannibal.Id, "testUser");

            // Assert
            Assert.AreEqual(changePageForm.BookId, result);
            Assert.AreEqual(book.CurrentPage, changePageForm.CurrentPage);
        }

        [Test]
        public async Task Test_FindBookCurrentlyReadingAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int currentlyReadingBookId = 2;
            int nonExistingCurrentlyReadingBookId = -2;

            // Act
            var resultOne = await service.FindBookCurrentlyReadingAsync(currentlyReadingBookId, "testUser");
            var resultTwo = await service.FindBookCurrentlyReadingAsync(nonExistingCurrentlyReadingBookId, "testUser");

            // Assert
            Assert.IsNotNull(resultOne);
            Assert.AreEqual(currentlyReadingBookId, resultOne.BookId);
            Assert.AreEqual("testUser", resultOne.UserId);

            Assert.IsNull(resultTwo);
        }
    }
}