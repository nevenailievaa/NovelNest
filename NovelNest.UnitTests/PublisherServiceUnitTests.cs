namespace NovelNest.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Core.Models.ViewModels.Event;
    using NovelNest.Core.Services;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using NovelNest.Infrastructure.Data.Models.BookUserActions;
    using NovelNest.Infrastructure.Data.Models.Events;
    using NovelNest.Infrastructure.Data.Models.Mappings;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Globalization;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.ArticleConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookStoreConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.EventConstants;

    [TestFixture]
    public class PublisherServiceUnitTests
    {
        //Database and Services
        private NovelNestDbContext dbContext;

        private IRepository repository;
        private IPublisherService publisherService;
        private IBookService bookService;
        private IBookStoreService bookStoreService;
        private IEventService eventService;
        private IArticleService articleService;

        //Collections
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Book> books;
        private IEnumerable<Genre> genres;
        private IEnumerable<CoverType> coverTypes;

        //Books
        private Book bookOne;
        private Book bookTwo;
        private Book bookThree;
        private Book bookFour;
        private Book bookFive;

        private BookStore bookStore;
        private BookReview bookReview;
        private BookBookStore bookBookStore;
        private BookUserWantToRead bookUserWantToRead;
        private BookUserCurrentlyReading bookUserCurrentlyReading;
        private BookUserRead bookUserRead;

        //Genres
        private Genre Romance;
        private Genre ClassicLiterature;
        private Genre Autobiography;
        private Genre Crime;

        //Cover Types
        private CoverType SoftCover;
        private CoverType HardCover;

        //Articles
        private Article article;

        //Events
        private Event testEvent;
        private EventParticipant eventParticipant;

        //Users and Publishers
        private ApplicationUser userOne;
        private ApplicationUser userTwo;
        private Publisher publisher;


        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            //Books
            bookOne = new Book()
            {
                Id = 1,
                Title = "Ana Karenina",
                Author = "Leo Tolstoy",
                Genre = ClassicLiterature,
                GenreId = 2,
                Description = "The description of Ana Karenina book",
                Pages = 832,
                YearPublished = 1877,
                CoverTypeId = 2,
                Price = 24.95m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529.jpg",
                PublishingHouse = "Hermes"
            };
            bookTwo = new Book()
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
            bookThree = new Book()
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
            bookFour = new Book()
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
            bookFive = new Book()
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

            bookStore = new BookStore()
            {
                Id = 1,
                Name = "Test Name",
                Location = "Test Location",
                ImageUrl = "https://adandcity.files.wordpress.com/2015/05/926.jpg",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("21:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0876536843",
            };
            bookReview = new BookReview()
            {
                Id = 1,
                BookId = 1,
                Title = "Test Title",
                Description = "Test Description",
                UserId = "TestIdOne",
                Rate = 10
            };
            bookBookStore = new BookBookStore()
            {
                BookId = 1,
                BookStoreId = 1
            };
            bookUserWantToRead = new BookUserWantToRead()
            {
                BookId = 1,
                UserId = "TestIdOne"
            };
            bookUserCurrentlyReading = new BookUserCurrentlyReading()
            {
                BookId = 1,
                UserId = "TestIdOne"
            };
            bookUserRead = new BookUserRead()
            {
                BookId = 1,
                UserId = "TestIdOne"
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

            //Articles
            article = new Article()
            {
                Id = 1,
                Title = "Test Title",
                Content = "Test Content",
                ImageUrl = "Test URL",
                DatePublished = DateTime.ParseExact("14/02/2024 09:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            //Events
            testEvent = new Event()
            {
                Id = 1,
                Topic = "Test Topic",
                Description = "Test Description",
                Location = "Test Location",
                StartDate = DateTime.ParseExact("14/02/2024 06:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("30/09/2023 09:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "Test URL",
                Seats = 10,
                TicketPrice = 10
            };
            eventParticipant = new EventParticipant()
            {
                ParticipantId = "TestIdOne",
                EventId = 1
            };

            //Users and Publishers
            userOne = new ApplicationUser()
            {
                Id = "TestIdOne",
                UserName = "nevena@gmail.com",
                NormalizedUserName = "NEVENA@GMAIL.COM",
                Email = "nevena@gmail.com",
                NormalizedEmail = "NEVENA@GMAIL.COM",
                FirstName = "Nevena",
                LastName = "Ilieva"
            };
            userTwo = new ApplicationUser()
            {
                Id = "TestIdTwo",
                UserName = "boris@gmail.com",
                NormalizedUserName = "BORIS@GMAIL.COM",
                Email = "boris@gmail.com",
                NormalizedEmail = "BORIS@GMAIL.COM",
                FirstName = "Boris",
                LastName = "Vladov"
            };
            publisher = new Publisher()
            {
                Id = 1,
                UserId = userOne.Id
            };

            //Collections
            users = new List<ApplicationUser>()
            {
                userOne, userTwo
            };
            books = new List<Book>()
            {
                bookOne, bookTwo, bookThree, bookFour, bookFive
            };
            genres = new List<Genre>()
            {
                Romance, ClassicLiterature, Autobiography, Crime
            };
            coverTypes = new List<CoverType>()
            {
                SoftCover, HardCover
            };

            //Database
            var options = new DbContextOptionsBuilder<NovelNestDbContext>()
                .UseInMemoryDatabase(databaseName: "NovelNestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new NovelNestDbContext(options);
            SeedDatabase();

            //Services
            repository = new Repository(dbContext);
            bookService = new BookService(repository);
            bookStoreService = new BookStoreService(repository);
            eventService = new EventService(repository);
            articleService = new ArticleService(repository);
            publisherService = new PublisherService(repository, bookService);
        }

        private async Task SeedDatabase()
        {
            dbContext.AddRangeAsync(books);
            dbContext.AddRangeAsync(genres);
            dbContext.AddRangeAsync(coverTypes);

            dbContext.AddAsync(bookStore);
            dbContext.AddAsync(bookReview);
            dbContext.AddAsync(bookBookStore);
            dbContext.AddAsync(bookUserWantToRead);
            dbContext.AddAsync(bookUserCurrentlyReading);
            dbContext.AddAsync(bookUserRead);

            dbContext.AddRangeAsync(users);
            dbContext.AddAsync(publisher);
            dbContext.AddAsync(article);
            dbContext.AddAsync(testEvent);
            dbContext.AddAsync(eventParticipant);
            dbContext.SaveChangesAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_ExistsByPublisherIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.ExistsByPublisherIdAsync(1);
            var resultTwo = await publisherService.ExistsByPublisherIdAsync(2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(resultTwo);
        }

        [Test]
        public async Task Test_ExistsByUserIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.ExistsByUserIdAsync("TestIdOne");
            var resultTwo = await publisherService.ExistsByUserIdAsync("TestIdTwo");

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(resultTwo);
        }

        [Test]
        public async Task Test_ExistsByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.ExistsByEmailAsync("nevena@gmail.com");
            var resultTwo = await publisherService.ExistsByEmailAsync("boris@gmail.com");

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(resultTwo);
        }

        [Test]
        public async Task Test_GetPublisherByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.GetPublisherByEmailAsync("nevena@gmail.com");

            // Assert
            Assert.That(publisher, Is.EqualTo(result));
        }

        [Test]
        public async Task Test_GetPublisherIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.GetPublisherIdAsync("TestIdOne");

            // Assert
            Assert.AreEqual(1, result);
        }


        //Books
        [Test]
        public async Task Test_AddBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new BookAddViewModel()
            {
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

            // Act
            await publisherService.AddBookAsync(addForm);
            var currentBook = await bookService.FindBookByIdAsync(6);


            // Assert
            Assert.AreEqual("Hannibal", currentBook.Title);
            Assert.AreEqual("Thomas Harris", currentBook.Author);
            Assert.AreEqual(4, currentBook.GenreId);
            Assert.AreEqual("The description of Hannibal book", currentBook.Description);
            Assert.AreEqual(488, currentBook.Pages);
            Assert.AreEqual(1999, currentBook.YearPublished);
            Assert.AreEqual(1, currentBook.CoverTypeId);
            Assert.AreEqual(19.90m, currentBook.Price);
            Assert.AreEqual("https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/_/-/_-_-_-_9789542838296_-_ciela.jpg", currentBook.ImageUrl);
            Assert.AreEqual("Ciela", currentBook.PublishingHouse);

            await publisherService.DeleteBookConfirmedAsync(currentBook.Id);
        }

        [Test]
        public async Task Test_EditBookGetAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var form = new BookEditViewModel()
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

            // Act
            var result = await publisherService.EditBookGetAsync(1);

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Ana Karenina", result.Title);
            Assert.AreEqual("Leo Tolstoy", result.Author);
            Assert.AreEqual(2, result.GenreId);
            Assert.AreEqual("The description of Ana Karenina book", result.Description);
            Assert.AreEqual(832, result.Pages);
            Assert.AreEqual(1877, result.YearPublished);
            Assert.AreEqual(2, result.CoverTypeId);
            Assert.AreEqual(24.95m, result.Price);
            Assert.AreEqual("https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529.jpg", result.ImageUrl);
            Assert.AreEqual("Hermes", result.PublishingHouse);
        }

        [Test]
        public async Task Test_EditBookPostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var form = new BookEditViewModel()
            {
                Id = 1,
                Title = "Ana Karenina Edited",
                Author = "Leo Tolstoy Edited",
                GenreId = 3,
                Description = "The description of Ana Karenina book Edited",
                Pages = 900,
                YearPublished = 1900,
                CoverTypeId = 1,
                Price = 25.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529Edited.jpg",
                PublishingHouse = "Hermes Edited"
            };

            // Act
            var result = await publisherService.EditBookPostAsync(form);
            var currentBook = await bookService.FindBookByIdAsync(result);

            // Assert
            Assert.AreEqual("Ana Karenina Edited", currentBook.Title);
            Assert.AreEqual("Leo Tolstoy Edited", currentBook.Author);
            Assert.AreEqual(3, currentBook.GenreId);
            Assert.AreEqual("The description of Ana Karenina book Edited", currentBook.Description);
            Assert.AreEqual(900, currentBook.Pages);
            Assert.AreEqual(1900, currentBook.YearPublished);
            Assert.AreEqual(1, currentBook.CoverTypeId);
            Assert.AreEqual(25.00m, currentBook.Price);
            Assert.AreEqual("https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529Edited.jpg", currentBook.ImageUrl);
            Assert.AreEqual("Hermes Edited", currentBook.PublishingHouse);
        }

        [Test]
        public async Task Test_DeleteBookAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.DeleteBookAsync(1);

            // Assert
            Assert.AreEqual(bookOne.Id, result.Id);
            Assert.AreEqual(bookOne.Title, result.Title);
            Assert.AreEqual(bookOne.Author, result.Author);
            Assert.AreEqual(bookOne.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task Test_DeleteBookConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.DeleteBookConfirmedAsync(1);

            // Assert
            Assert.AreEqual(0, dbContext.BooksBookStores.Count());
            Assert.AreEqual(0, dbContext.BookReviews.Count());
            Assert.AreEqual(0, dbContext.BooksUsersWantToRead.Count());
            Assert.AreEqual(0, dbContext.BooksUsersCurrentlyReading.Count());
            Assert.AreEqual(0, dbContext.BooksUsersRead.Count());
            Assert.AreEqual(4, dbContext.Books.Count());
            Assert.AreEqual(1, result);
        }


        //Articles
        [Test]
        public async Task Test_AddArticleAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new ArticleAddViewModel()
            {
                Title = "Test Title",
                Content = "Test Content",
                ImageUrl = "Test URL"
            };

            // Act
            var result = publisherService.AddArticleAsync(addForm).Result;
            var article = articleService.FindArticleByIdAsync(result).Result;

            // Assert
            Assert.AreEqual(2, result);
            Assert.AreEqual("Test Title", article.Title);
            Assert.AreEqual("Test Content", article.Content);
            Assert.AreEqual("Test URL", article.ImageUrl);
            Assert.AreEqual(DateTime.Now.Year, article.DatePublished.Year);
            Assert.AreEqual(DateTime.Now.Month, article.DatePublished.Month);
            Assert.AreEqual(DateTime.Now.Date, article.DatePublished.Date);
            Assert.AreEqual(DateTime.Now.Hour, article.DatePublished.Hour);
            Assert.AreEqual(DateTime.Now.Minute, article.DatePublished.Minute);
            Assert.AreEqual(0, article.ViewsCount);
        }

        [Test]
        public async Task Test_EditArticleGetAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.EditArticleGetAsync(1).Result;

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test Title", result.Title);
            Assert.AreEqual("Test Content", result.Content);
            Assert.AreEqual("Test URL", result.ImageUrl);
        }

        [Test]
        public async Task Test_EditArticlePostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var editForm = new ArticleEditViewModel()
            {
                Id = 1,
                Title = "Test Title Edited",
                Content = "Test Content Edited",
                ImageUrl = "Test URL Edited"
            };

            // Act
            var result = publisherService.EditArticlePostAsync(editForm).Result;
            var article = articleService.FindArticleByIdAsync(result).Result;

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual("Test Title Edited", article.Title);
            Assert.AreEqual("Test Content Edited", article.Content);
            Assert.AreEqual("Test URL Edited", article.ImageUrl);
        }

        [Test]
        public async Task Test_DeleteArticleAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteArticleAsync(1).Result;
            var article = articleService.FindArticleByIdAsync(result.Id).Result;

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test Title", article.Title);
            Assert.AreEqual("Test Content", article.Content);
            Assert.AreEqual("Test URL", article.ImageUrl);
        }

        [Test]
        public async Task Test_DeleteArticleConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteArticleConfirmedAsync(1).Result;

            // Assert
            Assert.AreEqual(0, dbContext.Articles.Count());
            Assert.AreEqual(0, dbContext.ArticleComments.Count());
            Assert.AreEqual(1, result);
        }


        //Events
        [Test]
        public async Task Test_AddEventAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new EventAddViewModel()
            {
                Topic = "Test Topic",
                Description = "Test Description",
                Location = "Test Location",
                StartDate = DateTime.ParseExact("14/02/2024 09:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("14/02/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "Test ImageUrl",
                Seats = 10,
                TicketPrice = 10.55m
            };

            // Act
            var result = publisherService.AddEventAsync(addForm).Result;
            var currentEvent = eventService.FindEventByIdAsync(result).Result;

            // Assert
            Assert.AreEqual(2, result);
            Assert.AreEqual(2, dbContext.Events.Count());
            Assert.AreEqual("Test Topic", currentEvent.Topic);
            Assert.AreEqual("Test Description", currentEvent.Description);
            Assert.AreEqual("Test Location", currentEvent.Location);
            Assert.AreEqual(DateTime.ParseExact("14/02/2024 09:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None), currentEvent.StartDate);
            Assert.AreEqual(DateTime.ParseExact("14/02/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None), currentEvent.EndDate);
            Assert.AreEqual("Test ImageUrl", currentEvent.ImageUrl);
            Assert.AreEqual(10, currentEvent.Seats);
            Assert.AreEqual(10.55m, currentEvent.TicketPrice);
        }

        [Test]
        public async Task Test_EditEventGetAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.EditEventGetAsync(1).Result;

            // Assert
            Assert.AreEqual(testEvent.Id, result.Id);
            Assert.AreEqual(testEvent.Topic, result.Topic);
            Assert.AreEqual(testEvent.Description, result.Description);
            Assert.AreEqual(testEvent.Location, result.Location);
            Assert.AreEqual(testEvent.StartDate, result.StartDate);
            Assert.AreEqual(testEvent.EndDate, result.EndDate);
            Assert.AreEqual(testEvent.ImageUrl, result.ImageUrl);
            Assert.AreEqual(testEvent.Seats, result.Seats);
            Assert.AreEqual(testEvent.TicketPrice, result.TicketPrice);
        }

        [Test]
        public async Task Test_EditEventPostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var editForm = new EventEditViewModel()
            {
                Id = 1,
                Topic = "Test Topic Edited",
                Description = "Test Description Edited",
                Location = "Test Location Edited",
                StartDate = DateTime.ParseExact("14/02/2025 09:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("14/02/2025 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "Test ImageUrl Edited",
                Seats = 20,
                TicketPrice = 20.55m
            };

            // Act
            var result = publisherService.EditEventPostAsync(editForm).Result;
            var editedEvent = eventService.FindEventByIdAsync(result).Result;

            // Assert
            Assert.AreEqual(editForm.Id, editedEvent.Id);
            Assert.AreEqual(editForm.Topic, editedEvent.Topic);
            Assert.AreEqual(editForm.Description, editedEvent.Description);
            Assert.AreEqual(editForm.Location, editedEvent.Location);
            Assert.AreEqual(editForm.StartDate, editedEvent.StartDate);
            Assert.AreEqual(editForm.EndDate, editedEvent.EndDate);
            Assert.AreEqual(editForm.ImageUrl, editedEvent.ImageUrl);
            Assert.AreEqual(editForm.Seats, editedEvent.Seats);
            Assert.AreEqual(editForm.TicketPrice, editedEvent.TicketPrice);
        }

        [Test]
        public async Task Test_DeleteEventAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteEventAsync(1).Result;

            // Assert
            Assert.AreEqual(testEvent.Id, result.Id);
            Assert.AreEqual(testEvent.Topic, result.Topic);
            Assert.AreEqual(testEvent.Location, result.Location);
            Assert.AreEqual(testEvent.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task Test_DeleteEventConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteEventConfirmedAsync(1).Result;

            // Assert
            Assert.AreEqual(0, dbContext.Events.Count());
            Assert.AreEqual(0, dbContext.EventsParticipants.Count());
            Assert.AreEqual(1, result);
        }


        //BookStores
        [Test]
        public async Task Test_AddBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new BookStoreAddViewModel()
            {
                Name = "Test Name",
                Location = "Test Location",
                OpeningTime = new DateTime(this.bookStore.OpeningTime.Year, this.bookStore.OpeningTime.Month, this.bookStore.OpeningTime.Day, this.bookStore.OpeningTime.Hour, this.bookStore.OpeningTime.Minute, 0),
                ClosingTime = new DateTime(this.bookStore.ClosingTime.Year, this.bookStore.ClosingTime.Month, this.bookStore.ClosingTime.Day, this.bookStore.ClosingTime.Hour, this.bookStore.ClosingTime.Minute, 0),
                Contact = "Test Contact",
                ImageUrl = "Test ImageUrl"
            };

            // Act
            var result = publisherService.AddBookStoreAsync(addForm).Result;
            var bookStore = bookStoreService.FindBookStoreByIdAsync(result).Result;

            // Assert
            Assert.AreEqual(2, result);
            Assert.AreEqual(2, dbContext.BookStores.Count());
            Assert.AreEqual(addForm.Name, bookStore.Name);
            Assert.AreEqual(addForm.Location, bookStore.Location);
            Assert.AreEqual(addForm.OpeningTime.Hour, bookStore.OpeningTime.Hour);
            Assert.AreEqual(addForm.OpeningTime.Minute, bookStore.OpeningTime.Minute);
            Assert.AreEqual(addForm.ClosingTime.Hour, bookStore.ClosingTime.Hour);
            Assert.AreEqual(addForm.ClosingTime.Minute, bookStore.ClosingTime.Minute);
            Assert.AreEqual(addForm.Contact, bookStore.Contact);
            Assert.AreEqual(addForm.ImageUrl, bookStore.ImageUrl);
        }

        [Test]
        public async Task Test_EditBookStoreGetAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.EditBookStoreGetAsync(1).Result;

            // Assert
            Assert.AreEqual(bookStore.Id, result.Id);
            Assert.AreEqual(bookStore.Name, result.Name);
            Assert.AreEqual(bookStore.Location, result.Location);
            Assert.AreEqual(bookStore.OpeningTime.Hour, result.OpeningTime.Hour);
            Assert.AreEqual(bookStore.OpeningTime.Minute, result.OpeningTime.Minute);
            Assert.AreEqual(bookStore.ClosingTime.Hour, result.ClosingTime.Hour);
            Assert.AreEqual(bookStore.ClosingTime.Minute, result.ClosingTime.Minute);
            Assert.AreEqual(bookStore.Contact, result.Contact);
            Assert.AreEqual(bookStore.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task Test_EditBookStorePostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var editForm = new BookStoreEditViewModel()
            {
                Id = 1,
                Name = "Test Name Edited",
                Location = "Test Location Edited",
                OpeningTime = new DateTime(this.bookStore.OpeningTime.Year, this.bookStore.OpeningTime.Month, this.bookStore.OpeningTime.Day, this.bookStore.OpeningTime.Hour + 1, this.bookStore.OpeningTime.Minute + 1, 0),
                ClosingTime = new DateTime(this.bookStore.ClosingTime.Year, this.bookStore.ClosingTime.Month, this.bookStore.ClosingTime.Day, this.bookStore.ClosingTime.Hour + 1, this.bookStore.ClosingTime.Minute + 1, 0),
                Contact = "Test Contact Edited",
                ImageUrl = "Test ImageUrl Edited"
            };

            // Act
            var result = publisherService.EditBookStorePostAsync(editForm).Result;
            var editedBookStore = bookStoreService.FindBookStoreByIdAsync(result).Result;

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(editForm.Name, editedBookStore.Name);
            Assert.AreEqual(editForm.Location, editedBookStore.Location);
            Assert.AreEqual(editForm.OpeningTime.Hour, editedBookStore.OpeningTime.Hour);
            Assert.AreEqual(editForm.OpeningTime.Minute, editedBookStore.OpeningTime.Minute);
            Assert.AreEqual(editForm.ClosingTime.Hour, editedBookStore.ClosingTime.Hour);
            Assert.AreEqual(editForm.ClosingTime.Minute, editedBookStore.ClosingTime.Minute);
            Assert.AreEqual(editForm.Contact, editedBookStore.Contact);
            Assert.AreEqual(editForm.ImageUrl, editedBookStore.ImageUrl);
        }

        [Test]
        public async Task Test_DeleteBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteBookStoreAsync(1).Result;

            // Assert
            Assert.AreEqual(bookStore.Name, result.Name);
            Assert.AreEqual(bookStore.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task Test_DeleteBookStoreConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteBookStoreConfirmedAsync(1).Result;

            // Assert
            Assert.AreEqual(0, dbContext.BookStores.Count());
            Assert.AreEqual(0, dbContext.BooksBookStores.Count());
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task Test_BookExistsInBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultTrue = publisherService.BookExistsInBookStoreAsync(1, 1).Result;
            var resultFalse = publisherService.BookExistsInBookStoreAsync(2, 1).Result;

            // Assert
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public async Task Test_AddBookToBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultOne = publisherService.AddBookToBookStoreAsync(1, 1).Result;
            var resultTwo = publisherService.AddBookToBookStoreAsync(2, 1).Result;

            // Assert
            Assert.AreEqual(2, dbContext.BooksBookStores.Count());
            Assert.That(bookBookStore, Is.EqualTo(resultOne));
            Assert.AreEqual(2, resultTwo.BookId);
            Assert.AreEqual(1, resultTwo.BookStoreId);
        }

        [Test]
        public async Task Test_RemoveBookFromBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.RemoveBookFromBookStoreAsync(bookOne.Id, bookStore.Id).Result;

            // Assert
            Assert.AreEqual(bookOne.Id, result.BookId);
            Assert.AreEqual(bookStore.Id, result.BookStoreId);
            Assert.AreEqual(bookOne.Title, result.BookTitle);
            Assert.AreEqual(bookOne.ImageUrl, result.BookImageUrl);
            Assert.AreEqual(bookStore.Name, result.BookStoreName);
        }

        [Test]
        public async Task Test_RemoveBookFromBookStoreConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.RemoveBookFromBookStoreConfirmedAsync(bookOne.Id, bookStore.Id);

            // Assert
            Assert.AreEqual(0, dbContext.BooksBookStores.Count());
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_FiltersByGenre()
        {
            // Act
            var result = publisherService.AllBooksToChooseAsync(1, "Romance").Result;
            var resultTwo = publisherService.AllBooksToChooseAsync(1, "ClassicLiterature").Result;

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 4);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_FiltersByCoverType()
        {
            // Act
            var result = publisherService.AllBooksToChooseAsync(1, null, "Soft").Result;
            var resultTwo = publisherService.AllBooksToChooseAsync(1, null, "NotAnExistingCoverType").Result;

            // Assert
            Assert.AreEqual(3, result.TotalBooksCount);
            Assert.AreEqual(4, result.Books.First().Id);
            Assert.AreEqual(3, result.Books.Skip(1).First().Id);
            Assert.AreEqual(2, result.Books.Skip(2).First().Id);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_FiltersBySearchTerm()
        {
            // Act
            var result = publisherService.AllBooksToChooseAsync(1, null, null, "Hannibal").Result;
            var resultTwo = publisherService.AllBooksToChooseAsync(1, null, null, "NotAValidSearchTerm").Result;

            // Assert
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.IsTrue(result.Books.First().Id == 2);

            Assert.AreEqual(0, resultTwo.TotalBooksCount);
            Assert.IsEmpty(resultTwo.Books);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByNewest()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 3, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByOldest()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.Oldest).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 3, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByTitleAscending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.TitleAscending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 4, 3, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByTitleDescending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.TitleDescending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 3, 4, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByAuthorAscending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.AuthorAscending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 4, 3, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByAuthorDescending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.AuthorDescending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 2, 3, 4, 5 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByPriceAscending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.PriceAscending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 3, 4, 5, 2 }, booksIds);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByPriceDescending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, null, BookSorting.PriceDescending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.IsNotNull(booksNewestSorting.Books);
            Assert.AreEqual(4, booksNewestSorting.Books.Count());
            Assert.AreEqual(new List<int>() { 5, 2, 4, 3 }, booksIds);
        }
    }
}