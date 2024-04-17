namespace NovelNest.UnitTests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Services;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using static NovelNest.Core.Constants.AdminConstants;

    [TestFixture]
    public class AdminServiceUnitTests
    {
        //Database and Services
        private NovelNestDbContext dbContext;

        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IRepository repository;
        private IAdminService adminService;
        private IPublisherService publisherService;
        private IUserService userService;
        private IBookService bookService;

        //Collections
        private IEnumerable<ApplicationUser> users;

        //Users
        private ApplicationUser userOne;
        private ApplicationUser userTwo;

        //Roles
        private Publisher publisher;
        private IdentityRole administratorRole;


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
            publisher = new Publisher()
            {
                Id = 1,
                UserId = userOne.Id
            };

            //Collections
            users = new List<ApplicationUser>() { userOne, userTwo };

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

            //Admin Role
            var roleStore = new RoleStore<IdentityRole>(dbContext);
            roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);

            administratorRole = new IdentityRole("Administrator");
            await roleManager.CreateAsync(administratorRole);

            //Services
            repository = new Repository(dbContext);
            bookService = new BookService(repository);
            publisherService = new PublisherService(repository, bookService);
            userService = new UserService(userManager, repository, publisherService);
            adminService = new AdminService(userManager, repository, publisherService, userService);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_AddPublisherAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = adminService.AddPublisherAsync(userTwo.Id).Result;
            var publisher = publisherService.GetPublisherByEmailAsync(userTwo.Email).Result;

            //Assert
            Assert.AreEqual(2, result);
            Assert.AreEqual(2, dbContext.Publishers.Count());
            Assert.AreEqual(userTwo.Id, publisher.UserId);
        }

        [Test]
        public async Task Test_RemovePublisherAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = adminService.RemovePublisherAsync(userOne.Id).Result;

            //Assert
            Assert.AreEqual(userOne.Id, result.Id);
            Assert.AreEqual(userOne.FirstName + " " + userOne.LastName, result.FullName);
            Assert.AreEqual(userOne.Email, result.Email);
            Assert.AreEqual(true, result.IsPublisher);
            Assert.AreEqual(false, result.IsAdmin);
        }

        [Test]
        public async Task Test_RemovePublisherConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = adminService.RemovePublisherConfirmedAsync(userOne.Id).Result;
            var publisher = publisherService.GetPublisherByEmailAsync(userOne.Email).Result;

            //Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(0, dbContext.Publishers.Count());
            Assert.IsNull(publisher);
        }

        [Test]
        public async Task Test_AddAdminAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = adminService.AddAdminAsync(userTwo.Id).Result;

            //Assert
            Assert.AreEqual(userTwo.Id, result);
            Assert.IsTrue(userManager.IsInRoleAsync(userTwo, AdminRole).Result);
        }

        [Test]
        public async Task Test_RemoveAdminAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = adminService.RemoveAdminAsync(userOne.Id).Result;

            //Assert
            Assert.AreEqual(userOne.Id, result.Id);
            Assert.AreEqual(userOne.FirstName + " " + userOne.LastName, result.FullName);
            Assert.AreEqual(userOne.Email, result.Email);
            Assert.AreEqual(true, result.IsPublisher);
            Assert.AreEqual(false, result.IsAdmin);
        }

        [Test]
        public async Task Test_RemoveAdminConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            await adminService.AddAdminAsync(userOne.Id);
            var result = adminService.RemoveAdminConfirmedAsync(userOne.Id).Result;

            //Assert
            Assert.AreEqual(userOne.Id, result);
            Assert.IsFalse(userManager.IsInRoleAsync(userOne, AdminRole).Result);
        }
    }
}