namespace NovelNest.UnitTests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Services;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data;
    using NovelNest.Infrastructure.Data.Models.Roles;

    [TestFixture]
    internal class UserServiceUnitTests
    {
        //Database and Services
        private NovelNestDbContext dbContext;

        private UserManager<ApplicationUser> userManager;
        private IRepository repository;
        private IPublisherService publisherService;
        private IUserService userService;
        private IBookService bookService;

        //Collections
        private IEnumerable<ApplicationUser> users;

        //Users
        private ApplicationUser userOne;
        private ApplicationUser userTwo;
        private ApplicationUser userThree;
        private ApplicationUser userFour;

        //Roles
        private Publisher publisher;

        [SetUp]
        public async Task Setup()
        {
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
            userThree = new ApplicationUser()
            {
                Id = "TestIdThree",
                UserName = "jessica@gmail.com",
                NormalizedUserName = "JESSICA@GMAIL.COM",
                Email = "jessica@gmail.com",
                NormalizedEmail = "JESSICA@GMAIL.COM",
                FirstName = "Jessica",
                LastName = "Alba"
            };
            userFour = new ApplicationUser()
            {
                Id = "TestIdFour",
                UserName = "irina@gmail.com",
                NormalizedUserName = "IRINA@GMAIL.COM",
                Email = "irina@gmail.com",
                NormalizedEmail = "IRINA@GMAIL.COM",
                FirstName = "Irina",
                LastName = "Shayk"
            };
            publisher = new Publisher()
            {
                Id = 1,
                UserId = userTwo.Id
            };

            //Collections
            users = new List<ApplicationUser>() { userOne, userTwo, userThree, userFour };

            //Database
            var options = new DbContextOptionsBuilder<NovelNestDbContext>()
                .UseInMemoryDatabase(databaseName: "NovelNestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new NovelNestDbContext(options);

            dbContext.AddRangeAsync(users);
            dbContext.AddAsync(publisher);
            dbContext.SaveChanges();

            //UserStore
            var userStore = new UserStore<ApplicationUser>(dbContext);
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var optionsUserManager = Options.Create<IdentityOptions>(new IdentityOptions());
            userManager = new UserManager<ApplicationUser>(userStore, optionsUserManager, passwordHasher, null, null, null, null, null, null);

            //Services
            repository = new Repository(dbContext);
            bookService = new BookService(repository);
            publisherService = new PublisherService(repository, bookService);
            userService = new UserService(userManager, repository, publisherService);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_UserFullNameAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = userService.UserFullNameAsync(userOne.Id).Result;

            //Assert
            Assert.AreEqual("Nevena Ilieva", result);
        }

        [Test]
        public async Task Test_ExistsByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.ExistsByEmailAsync(userOne.Email);
            var resultNonExisting = await userService.ExistsByEmailAsync("invalid@gmail.com");

            //Assert
            Assert.IsTrue(resultExisting);
            Assert.IsFalse(resultNonExisting);
        }

        [Test]
        public async Task Test_ExistsByIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.ExistsByIdAsync(userOne.Id);
            var resultNonExisting = await userService.ExistsByIdAsync("InvalidId");

            //Assert
            Assert.IsTrue(resultExisting);
            Assert.IsFalse(resultNonExisting);
        }

        [Test]
        public async Task Test_GetUserByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.GetUserByEmailAsync(userOne.Email);
            var resultNonExisting = await userService.GetUserByEmailAsync("invalid@gmail.com");

            //Assert
            Assert.That(userOne, Is.EqualTo(resultExisting));
            Assert.IsNull(resultNonExisting);
        }

        [Test]
        public async Task Test_GetUserByIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.GetUserByIdAsync(userOne.Id);
            var resultNonExisting = await userService.GetUserByIdAsync("invalidId");

            //Assert
            Assert.That(userOne, Is.EqualTo(resultExisting));
            Assert.IsNull(resultNonExisting);
        }

        [Test]
        public async Task Test_DetailsAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await userService.DetailsAsync(userOne.Id);

            //Assert
            Assert.AreEqual(userOne.Id, result.Id);
            Assert.AreEqual(userOne.FirstName + " " + userOne.LastName, result.FullName);
            Assert.AreEqual(userOne.Email, result.Email);
            Assert.AreEqual(false, result.IsPublisher);
            Assert.AreEqual(false, result.IsAdmin);
        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await userService.AllAsync(userOne.Id, "Boris");
            var resultTwo = await userService.AllAsync(userOne.Id, "Invalid");


            // Assert
            Assert.AreEqual(1, result.TotalUsersCount);
            Assert.AreEqual(userTwo.Id, result.Users.First().Id);

            Assert.AreEqual(0, resultTwo.TotalUsersCount);
            Assert.IsEmpty(resultTwo.Users);
        }

        [Test]
        public async Task Test_AllAsync_FiltersByRoleStatus()
        {
            // Act
            var result = await userService.AllAsync(userOne.Id, null, UserRoleStatus.Publisher);
            var resultTwo = await userService.AllAsync(userOne.Id, null, UserRoleStatus.Admin);

            // Assert
            Assert.AreEqual(1, result.TotalUsersCount);
            Assert.AreEqual(userTwo.Id, result.Users.First().Id);

            Assert.AreEqual(0, resultTwo.TotalUsersCount);
            Assert.IsEmpty(resultTwo.Users);
        }
    }
}