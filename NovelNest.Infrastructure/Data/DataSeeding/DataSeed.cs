namespace NovelNest.Infrastructure.Data.DataSeeding
{
    using Microsoft.AspNetCore.Identity;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using NovelNest.Infrastructure.Data.Models.Events;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Globalization;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.ArticleConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookStoreConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.EventConstants;
    using static NovelNest.Infrastructure.Data.Constants.CustomClaims;
    using NovelNest.Infrastructure.Data.Models.Mappings;

    internal class DataSeed
    {
        //Constructor
        public DataSeed()
        {
            SeedUsers();
            SeedPublisher();
            SeedGenres();
            SeedCoverTypes();
            SeedBooks();
            SeedBookReviews();
            SeedBookStores();
            SeedArticles();
            SeedEvents();
        }

        //Users
        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser PublisherUser { get; set; }
        public ApplicationUser GuestUser { get; set; }
        public ApplicationUser RandomUserOne { get; set; }
        public ApplicationUser RandomUserTwo { get; set; }

        //Roles
        public Publisher Publisher { get; set; }
        public Publisher PublisherAdmin { get; set; }

        //Claims
        public IdentityUserClaim<string> AdminUserClaim { get; set; }
        public IdentityUserClaim<string> PublisherUserClaim { get; set; }
        public IdentityUserClaim<string> GuestUserClaim { get; set; }
        public IdentityUserClaim<string> RandomUserOneClaim { get; set; }
        public IdentityUserClaim<string> RandomUserTwoClaim { get; set; }

        //Genres
        public Genre Poetry { get; set; }
        public Genre Mystery { get; set; }
        public Genre Fantasy { get; set; }
        public Genre Thriller { get; set; }
        public Genre Romance { get; set; }
        public Genre ClassicLiterature { get; set; }
        public Genre Horror { get; set; }
        public Genre Adventure { get; set; }
        public Genre Biography { get; set; }
        public Genre Autobiography { get; set; }
        public Genre Crime { get; set; }
        public Genre Humor { get; set; }
        public Genre Fiction { get; set; }
        public Genre Drama { get; set; }
        public Genre Military { get; set; }
        public Genre History { get; set; }
        public Genre Philosophy { get; set; }
        public Genre Business { get; set; }
        public Genre Science { get; set; }
        public Genre Health { get; set; }
        public Genre Cooking { get; set; }
        public Genre Travel { get; set; }

        //CoverTypes
        public CoverType HardCover { get; set; }
        public CoverType SoftCover { get; set; }

        //Books
        public Book BookOne { get; set; }
        public Book BookTwo { get; set; }
        public Book BookThree { get; set; }
        public Book BookFour { get; set; }
        public Book BookFive { get; set; }
        public Book BookSix { get; set; }
        public Book BookSeven { get; set; }
        public Book BookEight { get; set; }
        public Book BookNine { get; set; }
        public Book BookTen { get; set; }
        public Book BookEleven { get; set; }
        public Book BookTwelve { get; set; }
        public Book BookThirteen { get; set; }
        public Book BookFourteen { get; set; }
        public Book BookFiveteen { get; set; }
        public Book BookSixteen { get; set; }
        public Book BookSeventeen { get; set; }

        //BookReviews
        public BookReview ReviewOne { get; set; }
        public BookReview ReviewTwo { get; set; }
        public BookReview ReviewThree { get; set; }
        public BookReview ReviewFour { get; set; }

        //Book Stores
        public BookStore BookStoreOne { get; set; }
        public BookStore BookStoreTwo { get; set; }
        public BookStore BookStoreThree { get; set; }
        public BookStore BookStoreFour { get; set; }
        public BookStore BookStoreFive { get; set; }
        public BookStore BookStoreSix { get; set; }
        public BookStore BookStoreSeven { get; set; }
        public BookStore BookStoreEight { get; set; }
        public BookStore BookStoreNine { get; set; }

        //Articles
        public Article ArticleOne { get; set; }
        public Article ArticleTwo { get; set; }
        public Article ArticleThree { get; set; }
        public Article ArticleFour { get; set; }
        public Article ArticleFive { get; set; }
        public Article ArticleSix { get; set; }
        public Article ArticleSeven { get; set; }
        public Article ArticleEight { get; set; }
        public Article ArticleNine { get; set; }

        //Events
        public Event EventOne { get; set; }
        public Event EventTwo { get; set; }
        public Event EventThree { get; set; }
        public Event EventFour { get; set; }
        public Event EventFive { get; set; }
        public Event EventSix { get; set; }
        public Event EventSeven { get; set; }
        public Event EventEight { get; set; }
        public Event EventNine { get; set; }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };
            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Admin Adminov",
                UserId = "c2f14bf7-ffdd-47a4-90b3-f2309486fae9"
            };
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin420");


            PublisherUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "publisher@gmail.com",
                NormalizedUserName = "PUBLISHER@GMAIL.COM",
                Email = "publisher@gmail.com",
                NormalizedEmail = "PUBLISHER@GMAIL.COM",
                FirstName = "Publisher",
                LastName = "Publishov"
            };
            PublisherUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Publisher Publishov",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            };
            PublisherUser.PasswordHash = hasher.HashPassword(PublisherUser, "publisher420");


            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@gmail.com",
                NormalizedUserName = "GUEST@GMAIL.COM",
                Email = "guest@gmail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                FirstName = "Guest",
                LastName = "Guestov"
            };
            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Guest Guestov",
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };
            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest420");

            RandomUserOne = new ApplicationUser()
            {
                Id = "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                UserName = "nevena@gmail.com",
                NormalizedUserName = "NEVENA@GMAIL.COM",
                Email = "nevena@gmail.com",
                NormalizedEmail = "NEVENA@GMAIL.COM",
                FirstName = "Nevena",
                LastName = "Ilieva"
            };
            RandomUserOneClaim = new IdentityUserClaim<string>()
            {
                Id = 4,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Nevena Ilieva",
                UserId = "64ce3106-ec7d-44cb-b167-bf946b88bb1b"
            };
            RandomUserOne.PasswordHash = hasher.HashPassword(GuestUser, "nevena420");

            RandomUserTwo = new ApplicationUser()
            {
                Id = "cabfd9b8-4411-47f6-9639-df70d753c275",
                UserName = "boris@gmail.com",
                NormalizedUserName = "BORIS@GMAIL.COM",
                Email = "boris@gmail.com",
                NormalizedEmail = "BORIS@GMAIL.COM",
                FirstName = "Boris",
                LastName = "Vladov"
            };
            RandomUserTwoClaim = new IdentityUserClaim<string>()
            {
                Id = 5,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Boris Vladov",
                UserId = "cabfd9b8-4411-47f6-9639-df70d753c275"
            };
            RandomUserTwo.PasswordHash = hasher.HashPassword(GuestUser, "boris420");
        }

        private void SeedPublisher()
        {
            Publisher = new Publisher()
            {
                Id = 1,
                UserId = PublisherUser.Id
            };
            PublisherAdmin = new Publisher()
            {
                Id = 2,
                UserId = AdminUser.Id
            };
        }

        private void SeedGenres()
        {
            Poetry = new Genre()
            {
                Id = 1,
                Name = "Поезия"
            };
            Mystery = new Genre()
            {
                Id = 2,
                Name = "Мистерия"
            };
            Fantasy = new Genre()
            {
                Id = 3,
                Name = "Фентъзи"
            };
            Thriller = new Genre()
            {
                Id = 4,
                Name = "Трилър"
            };
            Romance = new Genre()
            {
                Id = 5,
                Name = "Любов"
            };
            ClassicLiterature = new Genre()
            {
                Id = 6,
                Name = "Класика"
            };
            Horror = new Genre()
            {
                Id = 7,
                Name = "Хорър"
            };
            Adventure = new Genre()
            {
                Id = 8,
                Name = "Приключенски"
            };
            Biography = new Genre()
            {
                Id = 9,
                Name = "Биография"
            };
            Autobiography = new Genre()
            {
                Id = 10,
                Name = "Автобиография"
            };
            Crime = new Genre()
            {
                Id = 11,
                Name = "Криминален"
            };
            Humor = new Genre()
            {
                Id = 12,
                Name = "Хумористичен"
            };
            Fiction = new Genre()
            {
                Id = 13,
                Name = "Художествена Измислица"
            };
            Drama = new Genre()
            {
                Id = 14,
                Name = "Драма"
            };
            Military = new Genre()
            {
                Id = 15,
                Name = "Военни"
            };
            History = new Genre()
            {
                Id = 16,
                Name = "История"
            };
            Philosophy = new Genre()
            {
                Id = 17,
                Name = "Философия"
            };
            Business = new Genre()
            {
                Id = 18,
                Name = "Бизнес"
            };
            Science = new Genre()
            {
                Id = 19,
                Name = "Наука"
            };
            Health = new Genre()
            {
                Id = 20,
                Name = "Здраве"
            };
            Cooking = new Genre()
            {
                Id = 21,
                Name = "Кулинарни"
            };
            Travel = new Genre()
            {
                Id = 22,
                Name = "Пътувания"
            };
        }

        private void SeedCoverTypes()
        {
            SoftCover = new CoverType()
            {
                Id = 1,
                Name = "Мека"
            };
            HardCover = new CoverType()
            {
                Id = 2,
                Name = "Твърда"
            };
        }

        private void SeedBooks()
        {
            BookOne = new Book()
            {
                Id = 1,
                Title = "Ана Каренина",
                Author = "Лев Толстой",
                GenreId = 6,
                Description = "Ана Каренина, изглежда, има всичко: красива е, богата, омъжена е за влиятелен политик и обожава сина си. Но тя усеща, че животът й е пуст – до момента, в който среща елегантния офицер граф Вронски. В отчаян опит да открие смисъла в живота си, тя се противопоставя на традициите на обществото. И напуска съпруга и сина си, за да живее със своя любим. Заклеймена и изолирана, Ана все по-често се поддава на пристъпите си на ревност към Вронски. А това го отчуждава. Скоро младата жена се оказва неспособна да избяга от все по-безнадеждната ситуация.",
                Pages = 832,
                YearPublished = 1877,
                CoverTypeId = 2,
                Price = 24.95m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529.jpg",
                PublishingHouse = "Hermes"
            };

            BookTwo = new Book()
            {
                Id = 2,
                Title = "Ханибал",
                Author = "Томас Харис",
                GenreId = 11,
                Description = "Вече познавате добре д-р Ханибал Лектър – изискан джентълмен, проницателен психолог и... да, изтънчен канибал. Седем години той е на свобода след бягството си от затвора, седем години под чужда самоличност разточително се наслаждава на живота в люлката на Ренесанса – Флоренция, и не убива почти никого. Звярът в него като че ли е заспал.Но има хора, които не са забравили за него, и това далеч не са само ФБР, които жадуват да го заловят отново. Извратен богаташ, осакатен жестоко от д-р Лектър, дава мило и драго да го залови жив, за да нахрани с него специална порода чудовищни прасета, селектирани за целта. Последният лов е започнал и този път самият ловец е плячката.На помощ ще му се притече не някой друг, а красивата агентка Кларис Старлинг, която от служител на закона се е превърнала в изкупителна жертва на системата. Агнетата в нея са замълчали, но думите на Лектър все така я вълнуват. И тя е готова да отговори на повика на гениалния психопат.След като в „Червения дракон“ и „Мълчанието на агнетата“ най-известният сериен убиец в световната литература показа на какво е способен, в „Ханибал“ историята му достига до своя епичен завършек, в който всички сметки ще бъдат разчистени.И ще остане само още една история за разказване – тази в „Ханибал Лектър: Зараждането на злото“, която описва създаването на едно обаятелно чудовище.",
                Pages = 488,
                YearPublished = 1999,
                CoverTypeId = 1,
                Price = 19.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/_/-/_-_-_-_9789542838296_-_ciela.jpg",
                PublishingHouse = "Ciela"
            };

            BookThree = new Book()
            {
                Id = 3,
                Title = "Мъжете, които мразеха жените",
                Author = "Стиг Ларшон",
                GenreId = 11,
                Description = "Богатият индустриалец Хенрик Вангер предлага на Микаел Блумквист едногодишен договор срещу огромен хонорар, ако успее да разгадае мистерията с изчезването на любимата му племенница Хариет. Микаел Блумквист е разследващ журналист, разкрил ред скандални случаи и несправедливо осъден за клевета заради написана от него изобличителна статия срещу могъщ шведски финансов магнат. Заедно със суперхакера Лисбет Саландер – млада, кльощава, татуирана и регистрирана като психопатка, сега работеща в детективска агенция, попадат в кръговрат от динамични събития и драматични изпитания, в свят на семейна омраза и финансови скандали, в който бродят убийци-психопати.Трилогията с над 80 милиона читатели в света разказва за един действителен свят на аморални финансови сфери, на екстремистки заговори и на изкривено правосъдие. Асоциация „Българска книга“ и журналистическото жури присъждат специално отличие „Бронзов лъв“ 2010 за издание с най-широк обществен отзвук на издателство „Колибри“ за трилогията „МИЛЕНИУМ“ от Стиг Ларшон.",
                Pages = 464,
                YearPublished = 2005,
                CoverTypeId = 1,
                Price = 16.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/m/i/millenium_1.jpg",
                PublishingHouse = "Colibri"
            };

            BookFour = new Book()
            {
                Id = 4,
                Title = "Аз преди теб",
                Author = "Джоджо Мойс",
                GenreId = 5,
                Description = "Двадесет и шест годишната Луиза Кларк е обикновено момиче, което харесва обикновения си живот. Лу живее със семейството си в малка къща в провинциално английско градче. Младата жена обожава работата си в местното кафене и ексцентричните дрехи. Тя е доволна от спокойния си живот, възнамерява да се омъжи за дългогодишния си приятел Патрик и да му роди куп деца.Светът ѝ се преобръща, когато неочаквано загубва работата си. Наред с безпаричието, безработицата я кара да се чувства безполезна. Лу полага неимоверни усилия да си намери нова работа, но няколко седмици във фабрика за обработка на пилета и верига за бързо хранене я довеждат до ръба на отчаянието. Затова, когато й предлагат да стане личен асистент на мъж с увреждания срещу добро заплащане, тя решава да опита. Тридесет и три годишният Уил Трейнър граби с пълни шепи от живота. Той обожава работата си, предизвикателствата и пътуванията, които непрекъснато му напомнят колко необятен е светът. Произшествие с мотор го приковава към инвалидна количка и превръща дните му в безрадостно съществуване.Две години по-късно Уил няма представа, че Лу ще стане част от живота му и ще го разтърси из основи. И двамата не подозират, че запознанството им ще ги промени завинаги...",
                Pages = 408,
                YearPublished = 2012,
                CoverTypeId = 1,
                Price = 17.95m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/a/z/6d3e59789317f6a5d3c5e6dffb38e9db/az-predi-teb-30.jpg",
                PublishingHouse = "Hermes"
            };

            BookFive = new Book()
            {
                Id = 5,
                Title = "Дневникът на Ане Франк",
                Author = "Ане Франк",
                GenreId = 10,
                Description = "Необикновеният дневник, написан на тавана на една „задна къща“ в Амстердам, където 13-годишното момиче и нейното семейство прекарват две години, укриващи се от нацистите, получава своето заслужено място сред класиките на XX век. С „Дневникът на Ане Франк“ споменът за една от най-мрачните епохи в човешката история оживява отново в луксозно издание с твърди корици и в пълния си, нецензуриран вид. В най-мрачните времена на миналия век едно на пръв поглед обикновено момиче ден след ден създава своето любовно писмо към живота, младостта и надеждата, своето свидетелство за силата на човешкия дух. Ане Франк води дневник от 12 юни 1942 г. до 1 август 1944 г. Пише писмата единствено за себе си, докато през про­летта на 1944 г. не чува по радио „Оранж“ речта на образова­телния министър в изгнание Болкестейн. Той призовава след войната да се съберат и публикуват всички документи, свиде­телстващи за страданията на нидерландския народ по време на германската окупация.",
                Pages = 312,
                YearPublished = 1947,
                CoverTypeId = 2,
                Price = 19.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ane-frank-zadnata-kyshta-ciela-9789542827214.jpg",
                PublishingHouse = "Ciela"
            };
            
            BookSix = new Book()
            {
                Id = 6,
                Title = "Търси се",
                Author = "Стивън Кинг",
                GenreId = 4,
                Description = "Който го намери, за него си е! „Събуди се, гений!“ – още с първото изречение в новия си роман Стивън Кинг ни стиска в хватката си и не ни пуска до самия край. Геният е Джон Ротстийн (авторът, създал трилогията с култовия герой Джими Голд), който от десетилетия не е публикувал нова книга и живее като отшелник. А грубото подмятане е отправено от Морис Белами, младеж, обсебен от Джими Голд. Морис кипи от гняв – не стига че любимият му писател е престанал да твори, ами преди това е превърнал бунтаря Джими Голд в конформист, който загърбва идеалите си в името на кариера в рекламата и на еснафското благополучие. Ротстийн трябва да си плати. С живота си! Морис го застрелва и взема парите от скрития в дрешника сейф. Само че истинското съкровище не са хилядите долари, а тетрадки, изписани на ръка от Ротстийн, и съдържащи най-малко още един роман за Джими Голд. Морис заравя плячката си, предвкусвайки как скоро ще чете продължението на трилогията за Беглецът, но – каква ирония на съдбата! – е арестуван и изпратен в затвора за друго престъпление. След дълги години момче на име Питър Саубърс случайно се натъква на заровения сандък със съкровището и сега Бил Ходжис, Холи Гибни и Джером Робинсън – незабравимото трио от „Мистър Мерцедес“ – трябва да защитят Пит и семейството му от коварния, жадуващ за отмъщение Морис, излязъл на свобода след трийсет и пет години зад решетките. За първи път след „Мизъри“ Стивън Кинг се връща към темата за тънката граница между пристрастеността към измислен герой и фанатизма. „Търси се“ е грабващ трилър, но и размисъл за начина, по който литературата формира живота ни – за добро или за зло, - ала винаги необратимо.",
                Pages = 480,
                YearPublished = 2015,
                CoverTypeId = 1,
                Price = 24.00m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/t/a/93afd46bc6f480cdee09e8c4ced2d74a/tarsi-se-31.jpg",
                PublishingHouse = "Pleiad"
            };

            BookSeven = new Book()
            {
                Id = 7,
                Title = "Quo Vadis",
                Author = "Хенрик Сенкевич",
                GenreId = 6,
                Description = "Пълно луксозно издание на един от най-четените романи за XX век\r\n\r\nРим по време на управлението на Нерон е привидно бляскаво място. Организират се богати пирове и поетични състезания, а забавленията в Циркус Максимус сякаш нямат край. От другата страна на монетата обаче са развратът и липсата на морал, бедността на народа и лудостта на императора, който подпалва собствения си град.\r\n\r\nВ тези мрачни дни на упадъка на Римската империя младият войник Марк Виниций се влюбва в Лигия – пленената дъщеря на варварски цар. Но той не подозира, че любимата му изповядва християнската вяра, заради която мнозина вече са загубили живота си.\r\n\r\nСъдбите на Виниций и Лигия се преплитат и двамата гледат света, който познават, да се променя пред очите им. А докато апостолите Петър и Павел се опитват да спасят аморалния град от разруха, християните са подложени на жестоки гонения.",
                Pages = 560,
                YearPublished = 2020,
                CoverTypeId = 2,
                Price = 24.95m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/q/u/fb2e33e9edf08ab8b8e46d9237e5ab06/quo-vadis-hermes-30.jpg",
                PublishingHouse = "Hermes"
            };
            
            BookEight = new Book()
            {
                Id = 8,
                Title = "Тютюн (Комплект - 1 и 2 том)",
                Author = "Димитър Димов",
                GenreId = 6,
                Description = "Навярно целият нов подход на Димов към романа, новата постройка и неочаквани акценти в „Тютюн“ бяха една от причините той да не бъде разбран още при появата си. Мнозина причисляваха автора към екзотичните цветя, израснали и култивирани не на наша плодотворна културна нива. Но днес е ясно, че с опита си Димитър Димов завеща, а с примера си подкрепи една нова тенденция в националния роман, разшири неговите хоризонти, обогати неговите традиции. В „Тютюн“ зрялата мисъл, вкусът и интелектът на моралиста преодоляват плашещото разстояние между неговите блуждения по чужди светове и нашия собствен национален исторически опит, те са намерили свой език за новия ни национален опит. Преодоляването на това огромно разстояние, необичайната парабола на това пътешествие бяха и преодоляване на смъртта на романа в интелектуалната сухота и умозрителност, откриха нови, не само чисто пластически пътища за развитието на бъдещия български роман и за нашето ново повествователно изкуство.",
                Pages = 864,
                YearPublished = 2019,
                CoverTypeId = 2,
                Price = 45.00m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/t/j/1940371da707cb6bf1a3b777c9b3f9f1/tyutyun-komplekt---1-i-2-tom-30.jpg",
                PublishingHouse = "Ciela"
            };
            
            BookNine = new Book()
            {
                Id = 9,
                Title = "Бритни Спиърс: Жената в мен - Автобиография",
                Author = "Бритни Спиърс",
                GenreId = 10,
                Description = "„Жената в мен“ е смела и удивително трогателна история за свободата и славата, майчинството и оцеляването, вярата и надеждата! През юни 2021 г. целият свят слушаше със затаен дъх, докато Бритни Спиърс говореше на открито съдебно заседание. Възможността да бъде чута – и да сподели своята истина – имаше неоспоримо въздействие, което промени посоката на нейния живот, както и живота на още много хора. „Жената в мен“ за първи път разкрива нейното невероятно житейско пътешествие – и вътрешната сила на една от най-великите изпълнителки в историята на поп музиката. Написани със забележителна откровеност и хумор, разтърсващите мемоари на Бритни Спиърс осветяват несекващата сила на музиката и любовта и показват колко е важно една жена да разкаже историята си със свои думи, така както тя я вижда. Това се случва сега. Носителката на няколко платинени награди „Грами“, поп-иконата Бритни Спиърс е една от най-успешните и прочути изпълнителки в музикалната история с над 100 милиона продадени плочи. През 2021 г. тя беше обявена от списание „Тайм“ за една от 100-те най-влиятелни хора. През 2012 г. албумът на Спиърс „Затъмнение“ беше прибавен в библиотеката и архивите за рокендрол в Залата на славата. Тя живее в Лос Анджелис, Калифорния.",
                Pages = 240,
                YearPublished = 2023,
                CoverTypeId = 2,
                Price = 19.99m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/b/r/219d4cce0a619d1122bab9cd24e91c5e/britni-spiars--zhenata-v-men---avtobiografiya-30.jpg",
                PublishingHouse = "Ciela"
            };

            BookTen = new Book()
            {
                Id = 10,
                Title = "У майкини",
                Author = "Иво Сиромахов",
                GenreId = 12,
                Description = "„Жената в мен“ е смела и удивително трогателна история за свободата и славата, майчинството и оцеляването, вярата и надеждата! През юни 2021 г. целият свят слушаше със затаен дъх, докато Бритни Спиърс говореше на открито съдебно заседание. Възможността да бъде чута – и да сподели своята истина – имаше неоспоримо въздействие, което промени посоката на нейния живот, както и живота на още много хора. „Жената в мен“ за първи път разкрива нейното невероятно житейско пътешествие – и вътрешната сила на една от най-великите изпълнителки в историята на поп музиката. Написани със забележителна откровеност и хумор, разтърсващите мемоари на Бритни Спиърс осветяват несекващата сила на музиката и любовта и показват колко е важно една жена да разкаже историята си със свои думи, така както тя я вижда. Това се случва сега. Носителката на няколко платинени награди „Грами“, поп-иконата Бритни Спиърс е една от най-успешните и прочути изпълнителки в музикалната история с над 100 милиона продадени плочи. През 2021 г. тя беше обявена от списание „Тайм“ за една от 100-те най-влиятелни хора. През 2012 г. албумът на Спиърс „Затъмнение“ беше прибавен в библиотеката и архивите за рокендрол в Залата на славата. Тя живее в Лос Анджелис, Калифорния.",
                Pages = 352,
                YearPublished = 2020,
                CoverTypeId = 2,
                Price = 15.90m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/y/-/d93901634b9ba810eb05ed61dc67608a/u-maykini-30.jpg",
                PublishingHouse = "Ciela"
            };

            BookEleven = new Book()
            {
                Id = 11,
                Title = "Вещерът 1: Последното желание",
                Author = "Анджей Сапковски",
                GenreId = 3,
                Description = "Гералт от Ривия, Белия вълк, се завръща в книжарниците! 23 години след излизането на „Последното желание” на полски издателство „Сиела“ пуска на пазара книгата, която промени завинаги представите на хората за съвременно фентъзи, умело преплитайки мотиви от класическите приказки, източноевропейската митология и криминалните истории на Реймънд Чандлър. Книгата, която даде началото на поредица, вдъхновила култовата серия от ролеви игри The Witcher, дала ни един от най-иконичните персонажи на развлекателната индустрия – Гералт от Ривия. Той не е герой. Не е рицарят на бял кон, който спасява девойката в последния момент. Той е професионалист, който убива чудовища срещу заплащане. Вещер – един от последните представители на легендарна каста от мутанти, създадени, за да се изправят с меч в ръка срещу всичко, което дебне в мрака, отвъд огньовете на човешките селища. Той е легенда. И това е началото на неговата история!",
                Pages = 316,
                YearPublished = 2016,
                CoverTypeId = 1,
                Price = 25.00m,
                ImageUrl = "https://ciela.bg/wp-content/uploads/2020/07/61078ba28b743deaed799f19905cf6c4.jpg",
                PublishingHouse = "Ciela"
            };

            BookTwelve = new Book()
            {
                Id = 12,
                Title = "Аз още броя дните",
                Author = "Георги Бърдаров",
                GenreId = 15,
                Description = "Историята ни отвежда в един от най-кървавите периоди в историята на Балканите – обсадата на Сараево. Книгата на Бърдаров е история за война и любов, преди всичко за любов, която преминава отвъд времето. Топла майска нощ през 1993 г. Обсадата на Сараево е започнала преди година и краят не се вижда, също както на братоубийствената война между довчерашните съюзни югославски народи. Двойка млади сърби стоят в кухнята си, потънали в мълчание. Давор, християнин, и Айда, мюсюлманка, са съхранили любовта си сред разрухата и безумието, които царят в обсадения град. Знаят, че наближава поредното кратко, едва половинчасово затишие, когато снайперистите почиват. Загледани в стрелките на часовника, те са взели решението да избягат – да достигнат свободата... или да посрещнат смъртта. Двадесет години по-късно българин пътува към Сараево, за да се срещне със сръбския преводач на книгата си. Скоро се озовават в кръчма и неусетно заговарят за войната. С напредването на часовете празните бутилки на масата се увеличават, а отдавна погребани тайни излизат на повърхността. Две нощи. Четири съдби. Всички водещи до най-важните въпроси. Кой запали тази война? И кой спечели от нея?",
                Pages = 182,
                YearPublished = 2016,
                CoverTypeId = 1,
                Price = 14.00m,
                ImageUrl = "https://ciela.bg/wp-content/uploads/2020/07/330956df410727967d0c2b77316a204b.jpg",
                PublishingHouse = "Ciela"
            };

            BookThirteen = new Book()
            {
                Id = 13,
                Title = "Войната на буквите",
                Author = "Людмила Филипова",
                GenreId = 3,
                Description = "В романа „Войната на буквите“ неповторимата Людмила Филипова съсредоточава творческия си талант върху един от най-важните моменти в българската история и разкрива житейските битки и предизвикателствата на цар Симеон, синовете му и техните най-големи противници. Създаването, налагането и опазването на българската азбука е дело, с което не просто се гордеем – то ни определя като силен и непоклатим народ. В него обаче има намесена мистика, която остава неразбулена и до днес – кой е Черноризец Храбър и каква е скритата сила на буквите? Това е тайна, която преобръща съдбата на хиляди, предрешава битки и дарява неземни сили. Власт, любов, манипулацияи епични битки се преплитат в историческия роман, разкриващ тайнствените събития зад един от най-емблематичните периоди в българската история. И едно от най-великите дела на българския народ и неговите апостоли на буквите.",
                Pages = 552,
                YearPublished = 2019,
                CoverTypeId = 1,
                Price = 22.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/e/n/enthusiast_voynata-na-bukvite_otkas-01.jpg",
                PublishingHouse = "Enthusiast"
            };

            BookFourteen = new Book()
            {
                Id = 14,
                Title = "Игрите на глада",
                Author = "Сюзан Колинс",
                GenreId = 13,
                Description = "В руините на някогашната Северна Америка се намира държавата Панем с блестящата си столица Капитол и дванайсетте ѝ окръга. Капитолът е безмилостен и държи окръзите в подчинение, като ги принуждава да изпращат по едно момче и едно момиче на възраст между дванайсет и осемнайсет за ежегодните Игри на глада - риалити шоу, предавано на живо по телевизията. Катнис Евърдийн знае, че подписва смъртната си присъда, когато доброволно заема мястото на по-малката си сестра в Игрите. Катнис неведнъж е била близо до смъртта - и оцеляването се е превърнало в нейна втора природа. Но ако иска да победи, ще се наложи да избира между оцеляването и човечността, между живота и любовта. Сюзан Колинс поднася равни части съспенс и философия, приключения и любов в този изпепеляващ роман, чието действие се развива в едно бъдеще, обезпокоително напомнящо нашето настояще. Победата означава богатство и слава. Загубата означава сигурна смърт. Игрите на глада започват...",
                Pages = 376,
                YearPublished = 2015,
                CoverTypeId = 1,
                Price = 14.90m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/i/g/21c0fb1dee462cdb569e1abe136df330/igrite-na-glada-30.jpg",
                PublishingHouse = "Екслибрис"
            };

            BookFiveteen = new Book()
            {
                Id = 15,
                Title = "Възпламеняване (Игрите на глада 2)",
                Author = "Сюзан Колинс",
                GenreId = 13,
                Description = "В руините на някогашната Северна Америка се намира държавата Панем с блестящата си столица Капитол и дванайсетте й окръга. Капитолът е безмилостен и държи окръзите в подчинение, като ги принуждава да изпращат по едно момче и едно момиче на възраст между дванайсет и осемнайсет на ежегодните Игри на глада - риалити шоу, предавано на живо по телевизията. В Игрите може да победи само един. И гледането е задължително! Колкото и да е невероятно, Катнис Евърдийн е победител в Игрите на глада. А победата означава богатство и слава. Сега Катнис би трябвало да е щастлива - в края на краищата пак е при семейството си и стария си приятел Гейл. Но нищо не е точно така, как тя иска. И се носят слухове за бунт срещу Капитола - бунт, за който Катнис може би е допринесла. Във втората част от трилогията \"Игрите на глада\" Сюзан Колинс продължава разказа за Катнис, като я подлага на още повече изпитания и поднася изненади на всяка страница.",
                Pages = 384,
                YearPublished = 2015,
                CoverTypeId = 1,
                Price = 14.90m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/i/g/a25f88a9f0259f66c7f210909fbba17f/vazplamenyavane-igrite-na-glada-2-31.jpg",
                PublishingHouse = "Екслибрис"
            };

            BookSixteen = new Book()
            {
                Id = 16,
                Title = "Сойка-присмехулка (Игрите на глада 3)",
                Author = "Сюзан Колинс",
                GenreId = 13,
                Description = "Окръг 12, родното място на Катнис Евърдийн, огненото момиче, е унищожен, но тя е жива. Гейл е избягал. Семейството на Катнис е в безопасност. Пийта е в ръцете на Капитола. Окръг 13 наистина съществува, има бунтовници, има нови лидери. Революцията се разгаря. Сега успехът на въстанието зависи от готовността на Катнис да се подчини, да поеме отговорност за живота на безброй хора и да промени бъдещето на Панем. За да го направи, тя трябва да преодолее гнева и недоверието си и да стане Сойка-присмехулка - символ на въстанието - каквато и да е цената лично за нея. Зашеметяващият завършек на трилогията „Игрите на глада“.",
                Pages = 384,
                YearPublished = 2015,
                CoverTypeId = 1,
                Price = 14.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/1/1/112444.jpeg",
                PublishingHouse = "Екслибрис"
            };

            BookSeventeen = new Book()
            {
                Id = 17,
                Title = "Балада за пойни птици и змии (Игрите на глада) - филмова корица",
                Author = "Сюзан Колинс",
                GenreId = 13,
                Description = "Сутринта на Жътвата, с която започват десетите „Игри на глада\". В Капитола осемнайсетгодишният Кориолан Сноу се подготвя за този единствен шанс да спечели слава като ментор в Игрите. За някога могъщата фамилия Сноу са настъпили трудни времена и съдбата й зависи от нищожния шанс Кориолан да успее да бъде по-чаровен, по-умен и по-изобретателен от съучениците си, за да стане ментор на трибута победител. Вероятността да спечели е малка. Пада му се унизителната задача да бъде ментор на момичето трибут от Окръг 12, най-незначителния от всички. Съдбите на двамата сега са напълно преплетени - всяко решение на Кориолан може да доведе до победа или провал, триумф или поражение. На арената битката ще бъде на живот и на смърт. Извън арената Кориолан започва да съчувства на обречения си трибут... и трябва да балансира между потребността си да следва правилата и желанието да оцелее на всяка цена.",
                Pages = 492,
                YearPublished = 2019,
                CoverTypeId = 1,
                Price = 20.00m,
                ImageUrl = "https://img.cms.bweb.bg/media/images/640x/Nov2023/2113171734.webp",
                PublishingHouse = "Екслибрис"
            };
        }

        private void SeedBookReviews()
        {
            ReviewOne = new BookReview()
            {
                Id = 1,
                Title = "Много ми хареса!",
                Description = "Книгата ме остави без думи! Изключително добре написана. Разбира се любим персонаж за мен е Лисбет Саландер. Препоръчвам!",
                Rate = 9,
                BookId = 3,
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            };
            ReviewTwo = new BookReview()
            {
                Id = 2,
                Title = "Не мога да кажа, че е нещо особено.",
                Description = "Фен съм на кримитата, но тази книга не ме грабна. Стори ми се прекалено повърхностна и не толкова добре описателна. Все пак не е зле.",
                Rate = 6,
                BookId = 3,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };
            ReviewThree = new BookReview()
            {
                Id = 3,
                Title = "Превърна се в любимата ми!",
                Description = "Току-що приключих с “Мъжете, които мразеха жените” на Стиг Ларшон. Слушах книгата в Storytel, тъй като заглавието ми звучеше изключително тривиално и ненужно драматично, пък и честно казано в последно време ми писна да слушам за мъже, които мразят жените. Болна тема. При това и оригиналното заглавие повече ми харесва - “The girl with the dragon tattoo”.\r\n\r\nКниги, които не ми звучат чак толкова интересно, a и какво значи книга да ти “звучи интересно”, но пък са високо оценени от читателите, оставям да изслушам в Storytel. Впрочем така направих и с книгите за детектива Робърт Хънтър на Крис Картър - нещо, за което съжалявам, но това не ми попречи да се вманиача по поредицата и да тъгувам, че няма още двеста книги от нея, които да изслушам.\r\n\r\nСъщото се случи и с “Мъжете, които мразеха жените” - първоначално гледах на нея със скептицизъм, но си казах: “Какво пък толкова, все пак ще я слушам докато се занимавам с нещо друго, нали затова се абонирах за Storytel в крайна сметка”. Е, отново сгреших в преценката си и тази книга се оказа заслужено високо оценена.\r\n\r\nАз съм фен на трилъра, особено на криминалетата. Първоначално даже не знаех и какъв е жанрът на четивото ми, просто започнах да го слушам без никакви очаквания. Оказа се, че съм попаднала на един особен и увлекателен криминален роман. Образите бяха изградени старателно, а най-много ми хареса този на Лизбет Саландер. Тя изненадващо се превърна в любимия ми такъв. Странно момиче, част от “Емо” културата, разбира се с татуировки и пиърсинги по тялото си. Изключително нетипична и интелигентна. Не очаквах, че точно такъв образ толкова много ще ме завладее.\r\n\r\nИсторията около семейство Вангер е ужасяваща, но няма да казвам повече, за да не разкривам от сюжета на тези, които все още не са се спрели на този заслужен безспорен бестселър.\r\n\r\nРазбрах, че има и филм от 2011-та година. Разбира се - ще го гледам, макар и да съм сигурна, че няма да е същото. В книгата имаше доста части, отделени на това да те вкарат в ума на героя и да ти опишат в детайли как се чувства той. Макар че не бива да се съди толкова бързо - филма по “Червеният дракон” от прочутата поредица на Томас Харис, се оказа също толкова хубав, колкото и книгата.\r\n\r\nНе искам да вдигам очакванията. Може би останах толкова приятно изненадана от тази книга именно защото нямах никакви очаквания и изисквания към нея. Може би за някои хора това ще е просто поредната криминална боза, през която предстои да преминат и скоро след това ще забравят. Аз обаче я оценявам високо и се надявам този отзив да накара някой да я включи в “To do” листа си, а аз продължавам със следващата, а именно - “Момичето, което си играеше с огъня”.",
                Rate = 10,
                BookId = 3,
                UserId = "64ce3106-ec7d-44cb-b167-bf946b88bb1b"
            };
            ReviewFour = new BookReview()
            {
                Id = 4,
                Title = "Грам не ми хареса",
                Description = "Изобщо не е написана добре. Сюжета е плосък и безинтересен.",
                Rate = 3,
                BookId = 3,
                UserId = "cabfd9b8-4411-47f6-9639-df70d753c275"
            };
        }

        private void SeedBookStores()
        {
            BookStoreOne = new BookStore()
            {
                Id = 1,
                Name = "Ciela - Витоша",
                Location = "София център, бул. „Витоша“ 60, 1463 София",
                ImageUrl = "https://adandcity.files.wordpress.com/2015/05/926.jpg",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("21:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0876536843",
            };
            BookStoreTwo = new BookStore()
            {
                Id = 2,
                Name = "Helikon - Пазарджик",
                Location = "Пазарджик Център, ул. „Професор Асен Златаров“ 23, 4400 Пазарджик",
                ImageUrl = "https://i.helikon.bg/content/601/202304270903201726.jpg",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0896236457",
            };
            BookStoreThree = new BookStore()
            {
                Id = 3,
                Name = "Orange - The Mall",
                Location = "м. Къро, бул. „Цариградско шосе“ 115, 1000 София",
                ImageUrl = "https://www.orangecenter.bg/media/extensa_shop/image/grand-mall-varna_1.jpg",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0892414935",
            };
            BookStoreFour = new BookStore()
            {
                Id = 4,
                Name = "Helikon - Пловдив Център",
                Location = "ул. „Княз Александър I-ви“ 29, Пловдив",
                ImageUrl = "https://cdn.oink.bg/gallery/23010/05adf581-0397-4f92-a9fa-65a087cd918f_large.webp",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "032 207 621",
            };
            BookStoreFive = new BookStore()
            {
                Id = 5,
                Name = "Hermes - Стамболийски",
                Location = "София център, бул. „Александър Стамболийски“ № 27А, 1000 София",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipM6sAeCcik9kS-GHs0pAigNGtXReSFIrBZmMVdy=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("09:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0899997719",
            };
            BookStoreFive = new BookStore()
            {
                Id = 5,
                Name = "От А до Я - София Център",
                Location = "ж.к. Лозенец, ул. „Драгалевска“ 1, 1407 София",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPgXofDl2u9d6h6aNNQ6Phs0i7mzeVYEwU5ssQX=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0878929358",
            };
            BookStoreSix = new BookStore()
            {
                Id = 6,
                Name = "Ciela Books & Music - Пловдив",
                Location = "Казарми Източен, ул. „Д-р Георги Странски“ №3, етаж 2, 4019 Пловдив",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNKR7OEDjOL8kyn96Fz8P-EFTLP5VQvpi0i1CSi=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("21:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0876211144",
            };
            BookStoreSeven = new BookStore()
            {
                Id = 7,
                Name = "Bookpoint - Варна",
                Location = "Варна Център Одесос, ул. „Цар Симеон I“ 1, 9000 Варна",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOoQHzIG3B8LxmxLjyoCSlDD93L6ftaFLVYFWzX=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0879228009",
            };
            BookStoreEight = new BookStore()
            {
                Id = 8,
                Name = "Ciela - Русе",
                Location = "бул. Липник 121 Д, 7000 Русе",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPbLF_2y5KAuPxHse21tPodoOooVGlsa1R5gJ4p=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0882560013",
            };
            BookStoreNine = new BookStore()
            {
                Id = 9,
                Name = "Ciela - Бургас",
                Location = "Северна промишлена зона, бул. „Янко Комитов“, 8001 Бургас",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipONKzh539ObWS-NI_g3XohjjChkUr2khxVk7bP6=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("21:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0877257199",
            };
        }

        private void SeedArticles()
        {
            ArticleOne = new Article()
            {
                Id = 1,
                Title = "„Мъжете, които мразеха жените“ на Стиг Ларшон с ново издание",
                Content = "Излезе ново издание на „Мъжете, които мразеха жените“ (превод: Неда Димова-Бренстрьом, 464 стр., цена: 18 лв., издателство Колибри), най-зашеметяващия трилър от началото на XXI век. Зрелищната корица е дело на Живко Петров. МИЛЕНИУМ е името на вестника, чийто съсобственик и отговорен редактор Микаел Блумквист е главен герой в едноименната трилър трилогия. Още с излизането си през 2005 г. трилогията постига феноменален световен успех. „Мъжeтe, които мразеха жените“, първата книга от поредицата, получава наградата „Стъклен ключ“ за най-добър скандинавски роман за 2005 г., а вторият, „Момичето, което си играеше с огъня“ – наградата за най-добър шведски криминален роман за 2006 г. До момента от трите книги са продадени над 86 милиона екземпляра. Богатият индустриалец Хенрик Вангер предлага на Микаел Блумквист едногодишен договор срещу огромен хонорар, ако успее да разгадае мистерията с изчезването на любимата му племенница Хариет. Блумквист е разследващ журналист, разкрил ред скандални случаи и несправедливо осъден за клевета заради написана от него изобличителна статия срещу могъщ шведски финансов магнат. Заедно със суперхакера Лисбет Саландер – млада, кльощава, татуирана жена, регистрирана като психопат, работеща в детективска агенция, попадат във водовъртеж от драматични изпитания, семейна омраза и финансови скандали.Трилогията МИЛЕНИУМ разказва за един свят на аморални финансови сделки, на екстремистки заговори и на изкривено правосъдие. Свят, в който ще разпознаете и недъзи на българския политически и обществен живот. Стиг Ларшон (1954-2004) е известен шведски журналист и писател, чиито разследвания изобличават антидемократичните, дясноекстремистките и расистките практики в обществото и медиите. Трилогията Милениум му носи изключителна популярност още с публикуването на Мъжете, които мразеха жените, който има две успешни екранизации – шведска и американска. Ларшон умира от сърдечна криза на петдесетгодишна възраст наскоро след като е предал на издателя криминалната си поредица „Милениум“ и не доживява нейното отпечатване. Носят се слухове, че смъртта му не е случайна и е свързана с дейността му на разследващ журналист. През декември 2013 г. шведското издателство „Норстед“ обяви, че Давид Лагеркранс ще продължи поредицата на Стиг Ларшон. Последва цяла трилогия, преплитаща политически скандали и властови игри на високо ниво с ДНК изследвания, хималайски експедиции, киберпрестъпления и организирана омраза в интернет.",
                ImageUrl = "https://i0.wp.com/vevesti.bg/wp-content/uploads/2021/11/9089304680924850968250498290457.jpg?resize=678%2C509&ssl=1",
                DatePublished = DateTime.ParseExact("24/04/2023 10:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleTwo = new Article()
            {
                Id = 2,
                Title = "Продадоха за 55 000 паунда книга за Хари Потър, трупала прах 26 години",
                Content = "Във Великобритания копие от първото издание на „Хари Потър и магьосническият камък“ на Дж. К. Роулинг, лежало 26 години в шкаф под стълбите, беше продадено на търг, съобщава Derbyshire Times. Книгата беше продадена на 11 декември в Hansons Auctioneers в Дербишър за 55 100 паунда. В продължение на много години тя се пазила от 58-годишна жителка, която я купила през 1997 г. по време на пътуване със семейството си. В магазина детската книга се намирала в кошницата с намаления и се продавала само за 10 паунда. „Купих си книга за Хари Потър, когато никой не знаеше за него или неговия автор. Пътувахме с кола в Шотландските планини. Имаше кафе-книжарница на един далечен полуостров в края на пътя”, разказва жената. Тя също така отбеляза, че е успяла да договори книгата за осем паунда, тъй като нямала външна обложка. По време на пътуването всяка вечер британката четяла приказка на децата си. По-късно книгата била прибрана в килер, където се съхранявала доскоро. Книгата се съхранила в отлично състояние. Специалист от Hansons Auctioneers разкри, че това е много рядко първо издание с твърди корици на първия роман на Джоан Роулинг за Хари Потър. Бяха отпечатани общо 500 книги, 300 от тях бяха разпространени в библиотеките, а само 200 бяха пуснати в продажба. В момента само 19 книги от тази серия са известни на колекционерите. Те бяха продадени на търгове за суми от 17 500 до 69 000 британски лири. По-рано беше съобщено, че библиотекарката Джанет Такуел решила да продаде първите издания на книги за Хари Потър с автографи на авторката. Жената получава подписите на Джоан Роулинг през 1999 г., когато работи като учителка и водила децата си на среща с писателката.",
                ImageUrl = "https://www.tialoto.bg/media/files/resized/article/615x348/7e2/ad7a2b33b135c4662c374a7a37a8d7e2-5580840.jpg",
                DatePublished = DateTime.ParseExact("02/02/2024 14:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleThree = new Article()
            {
                Id = 3,
                Title = "Иво Сиромахов представя романа си „Бай Тошо“ днес в Бургас",
                Content = "От 17,30 часа в зала „Ахело“ на Гранд хотел и СПА Приморец – организатор на културния форум, своята нова книга „Бай Тошо“ ще представи писателят, сценарист, драматург и телевизионен водещ Иво Сиромахов. Четивото е с логото на Сиела и е забавна безмилостна сатира на абсурдните времена, в които живеем. „България в наши дни. След провала на всички марионетни партии, създадени от невидимите политически инженери, се е стигнало до тежка безизходица. Време е да бъде изваден последният коз. С помощта на модерните технологии един олигарх възкресява образа на Бай Тошо и го поставя начело на държавата. За да „оправи“ всичко… „ – гласи анотацията на книгата. Повече, заповядайте да научите лично от нейния автор Иво Сиромахов. Ще има разговори, книги, автографи.",
                ImageUrl = "https://www.burgasnews.com/wp-content/uploads/2023/10/ivo-siromahov.jpg",
                DatePublished = DateTime.ParseExact("18/02/2024 19:30", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };
            
            ArticleFour = new Article()
            {
                Id = 4,
                Title = "Салман Рушди отговаря на насилието с изкуство",
                Content = "Британският писател от индийски произход Салман Рушди, човек с неподкупна съвест, непримирим към всяка форма на диктатура и ограничаване на свободата на словото, беше удостоен с Наградата за мир на Германската асоциация на книгоиздателите и книгоразпространителите по време на Панаира на книгата във Франкфурт. Това е едно от най-значимите германски отличия, присъдено за пръв път през 1950 година. С него Рушди се присъединява към писатели като Маргарет Атууд, Орхан Памук, Сюзън Зонтаг, Амос Оз, Вацлав Хавел.\r\n\r\nЖурито обяви, че писателят е бил избран заради несломимия си дух, последователното утвърждаване на живота и обогатяването на света с любов към разказването на истории: „В своите романи и в мемоарната си литература той съчетава прозорливост на разказа с непогрешимо новаторство, хумор и мъдрост“. Възхвалявайки Рушди в речта си, неговият приятел и колега, писателят Даниел Келман, го определи като „вероятно най-важния бранител на свободата на изкуството и словото на нашето време“.\r\n\r\nРушди, който безсъмнено е един от най-изкусните и омагьосващи разказвачи днес, благодари за наградата, но отбеляза, че „мирът в момента изглежда като фантазия, родена от употребата на наркотик\" В речта си в църквата „Свети Павел\" 76-годишният автор на „Сатанински строфи“ и „Кишот“ осъди войната на Русия срещу Украйна като следствие от „ненаситната жажда за власт и завоевания на един тиранин“ и изрази надежда, че терорът в Близкия изток ще бъде прекратен възможно най-скоро.\r\n\r\n„Не съм допускал, че ще доживея такова време. Време, в което свободата - по-специално свободата на словото, без която светът на литературата не би могъл да съществува - навсякъде е атакувана от реакционни, авторитарни, популистки, демагогски, полуобразовани, нарцистични, безразсъдни гласове.\"\r\n\r\nРушди не спести критиките си и по отношение на американската политическа действителност. Пред журналисти той изрази разочарованието си от Републиканската партия, която според него е обърнала гръб на демократичните стойности за сметка на култа към една личност. Също толкова тревожна според него е ситуацията и в Индия, където е роден. „Всеки журналист или писател, който изгуби симпатиите или се възпротиви на властите – казва Рушди – се озовава под заплаха.”\r\n\r\nАвтор на тринайсет романа, Салман Рушди добива световна известност с алегоричния шедьовър Midnight Children (1981), за който получава няколко отличия, в т.ч. награда „Букър“. Книгата два пъти печели и т.нар. Букър на всички Букъри, през 1993 г. и 2008 г., по случай 25-ата и 40-ата годишнина на наградата, а през 2012 г. е адаптирана за голям екран като колаборация между Канада, Великобритания, САЩ и Индия под режисурата на Дийпа Мехта. Посветен на годините, в които Индия се освобождава от британския колониализъм, романът е издаден у нас за пръв път през 2003 г. от „Постскриптум“ със заглавие „Среднощни деца“. На 3 ноември 2023 г. „Колибри“ пуска ново издание, озаглавено „Родените в полунощ“, в превод на Надежда Розова. Промяната на заглавието не е случайна, както става ясно от предговора на книгата, подписан от писателя.\r\n\r\nПрез 1988 г. романът „Сатанински строфи“ на Рушди предизвиква бурни реакции в ислямския свят, книгата е забранена в много страни, а иранският аятолах обявява автора за вероотстъпник и определя голяма парична награда за убийството му. През август 2022 г. срещу писателя е извършено покушение – той е намушкан с нож, докато изнася лекция на сцената на литературен фестивал в щата Ню Йорк. След тази брутална атака, която го оставя сляп с дясното око и с осакатена лява ръка, писателят написва есето „Нож: Размисли след опит за убийство“, чиято премиера се очаква на 16 април 2024 г. За Рушди тази мемоарна книга е начин „да се отговори на насилието с изкуство“.\r\n\r\nИздателство „Колибри“ ще предложи на българските читатели и най-новата му художествена творба,  Victory City („Град на победата“). Разказвайки история за възхода и падението на една феминистка утопия, романът смесва политически интриги и религиозен фанатизъм и завършва със знаковата фраза: „Думите са победителят“.",
                ImageUrl = "https://www.colibri.bg/news_img/20231027_1.jpg",
                DatePublished = DateTime.ParseExact("10/04/2024 19:34", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleFive = new Article()
            {
                Id = 5,
                Title = "Силвия Вагенщайн със специална награда от Съюза на преводачите",
                Content = "Навръх Международния ден на преводача, 30 септември, на специална церемония в Аудитория 65 на Ректората на СУ „Св. Климент Охридски“ Съюзът на преводачите в България връчи Годишните награди за превод в различни категории.\r\n\r\nИмаме удоволствието да съобщим, че жури в състав Галина Меламед, Людмил Димитров и Дарин Тенев присъди тазгодишната Специална награда за изключително високи постижения в областта на превода на художествена литература (поезия) на Силвия Вагенщайн – за превода ѝ от френски език на концептуално подбраните от нея стихове на Пол Елюар в „Поезия“, предадени с пълната авторова гама от образи, мелодика, поетични послания на също толкова богат и образен български език.\r\n\r\nОсвен че е автор на конгениалния превод, Силвия Вагенщайн стои зад съставителството, предговора и бележките към това изящно издание, което предлага екстракт от 14 поетически книги на големия френски творец.\r\n\r\nЕто ги и мотивите на журито: „Преводачката Силвия Вагенщайн ни поднася концептуално томче с избрана поезия от Пол Елюар, необременена от идеологически напластявания, каквито се натрупват през живота му и които са били най-честото оправдание за редките му и не особено запомнени появи на български език. Издържан и великолепно изтълкуван, настоящият Елюар е избор и лична антология на Вагенщайн, която тя иска да сподели с читателите си. В своето време нещо подобно прави и самият френски поет, поднасяйки на сънародниците си стихотворенията на Христо Ботев. А Ботев винаги е достатъчно основание тук, в България, да забележим неговия чуждестранен популяризатор. В случая обаче това е по-незначителна и периферна подробност. Далеч по-важни са езиковите и образни енергийни конвулсии, трептения и трусове, оцелели в превода, мелодиката и особено личното, интимно послание, успоредено с компетентния предговор от преданата преводачка. Не е маловажен и фактът, че една откровено мъжка поезия е интерпретирана от дама, придала особена рафинираност на стиха, без да го изравнява, манипулира или „феминизира“. Елюар звучи убедително, възприемателят не го чете, а събеседва с него, слуша го и съпреживява довереното му като свое.“\r\n\r\nПо традиция бяха присъдени и награди за ярки постижения в областта на превода на художествена литература. Сред отличените заслужено се нареди Илияна Чалъкова за превода на антиутопичния роман „Пещерата“ от Жозе Сарамаго, един покъртително човеколюбив и ярък прочит на Платоновия мит за пещерата и сенките.\r\n\r\nОбосновката на журито гласи: „Преводачката се е справила превъзходно с пресъздаването на български на плътния стил на големия португалски писател. В превода си е успяла да съхрани почерка, като намери най-хубава форма за предаване на особения синтактичен ритъм на Жозе Сарамаго, който е известен с дългите си изречения, с вплитането на диалози в потока на едно изречение, с реторичните натрупвания (синатроезми) и обратите на изказа. И това е постигнато на един четивен и красив български език, образец за преводаческо майсторство.“\r\n\r\nМариана Неделчева беше удостоена с награда за ярки постижения в областта на превода на хуманитаристика за съставителството и превода от английски език на книгата „Изящното изкуство на критиката“ от Хенри Джеймс. Според журито преводът предава майсторски всички черти на авторовия стил, в който фразите се открояват със своята точност и красота.\r\n\r\nВасил Самоковлиев беше отличен с награда за цялостна дейност в областта на превода за неговите майсторски преводи на значими романи от съвременната чешка литература и за дългогодишната му преподавателска дейност по теория и практика на превода на български и чуждестранни студенти. Напомняме, че Самоковлиев е сред българските преводачи на двамата колоси на европейската литература Бохумил Храбал и Милан Кундера. В негов превод наскоро излязоха „Сватби в къщата“ и „Vita Nuova” от автобиографичната трилогия на Храбал, предстои да излезе романът „Пролуки“.\r\n\r\nЧестито на всички наградени преводачи!",
                ImageUrl = "https://www.colibri.bg/news_img/202301002_1.jpg",
                DatePublished = DateTime.ParseExact("11/04/2024 13:14", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleSix = new Article()
            {
                Id = 6,
                Title = "Анжел Вагенщайн пое към вечността",
                Content = "На стогодишна възраст ни напусна Анжел Вагенщайн, един от най-ярките интелектуалци на нашето съвремие.\r\n\r\nЧовек епоха. Личност с пословичен интегритет, дух и мъдрост, дала живот на десетки киносценарии, неотехтели речи, прозорливи „драскулки“ и на признатия в цял свят белетристичен триптих „Петокнижие Исааково“, „Далеч от Толедо“ и „Сбогом, Шанхай“, посветен на съдбата на европейските евреи през Втората световна война…\r\n\r\nОбгрижвайки думите, подреждайки ги с топлота и отговорност като бисери в огърлицата на паметта, Вагенщайн ни завеща пленителен разказ за мътния въртоп на една преломна епоха, за пъстротата на човешките характери и за краха на илюзиите, за сложния възел на живота, който е безсърдечно кратък, а човешката надежда – неутолима.\r\n\r\nИзпитанията, които не успяха да съкрушат вярата му в един по-справедлив световен ред, нито разколебаха непримиримостта му към тиранията, днес напомнят за прочутата еврейска поговорка „Пепелта е по-достолепна от пясъка – защото е горяла.“\r\n\r\nИ ако вземем назаем частица от гениалното му красноречие, ще кажем, че творчеството му е „едно ситно написано любовно писмо - закодирано признание в привързаност и дори обич – към теб, читателю, към всички хора с добра воля и към онзи непоносим, но скъп на сърцето ни нахалник, живота, който ни досажда непрекъснато, докато милостивата случайност един ден не го изрита... “\r\n\r\nОт нас се очаква само да се научим да четем.\r\n\r\nПоклонението ще се състои в Софийската синагога на трийсетия ден от смъртта, както повелява еврейската традиция.\r\n\r\nПоклон пред паметта на човека и твореца Анжел Вагенщайн, оставил трайна диря в българската култура!",
                ImageUrl = "https://www.colibri.bg/news_img/20230629_1.jpg",
                DatePublished = DateTime.ParseExact("12/04/2024 09:46", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleSeven = new Article()
            {
                Id = 7,
                Title = "Нова книга от серията на Робърт Галбрейт се очаква през септември",
                Content = "Седмият роман от хитовата поредица за Корморан Страйк ще има своята световна премиера на 26 септември 2023 г., т.е. в годината, в която се навършва точно едно десетилетие от излизането на първия бестселър – „Зовът на кукувицата“.\r\n\r\nТази есен Sphere, импринт на Little, Brown Book Group, ще издаде The Running Grave (буквално „Бягащият гроб“) от Робърт Галбрейт, псевдоним на Дж. К. Роулинг. По традиция са предвидени печатно, електронно и аудио издание.\r\n\r\n„Бягащият гроб“ ще бъде седмо поред заглавие в планирана серия от десет книги, при това и шестте предходни заглавия се превърнаха в международни бестселъри. Поредицата за Корморан Страйк и Робин Елакот е определяна като „изключително увлекателна“ (Дейли Експрес), „дело на майстор разказвач“ (Дейли Телеграф) и „изумително криминално творчество“ (Санди Таймс), а протагонистите Страйк и Робин са „един от най-ангажиращите дуети в криминалната литература“ (Гардиан).\r\n\r\n„Зовът на кукувицата“ получи наградата Nielsen Platinum, защото надхвърли 1 000 000 продадени копия. „Копринената буба“ и „В служба на злото“, съответно втори и трети роман от поредицата, вече достигнаха рекорда за бестселъри Nielsen Gold с над 500 000 продадени екземпляра от всяко заглавие.\r\n\r\n„Беше прекрасно преживяване да сме свидетели на неимоверния успех на книгите на Робърт Галбрейт през последните десет години. За нас е чест да ги издаваме. С над 11 милиона продадени копия на английски език до момента, историята на Страйк и Робин продължава да владее въображението на читателите и аз, също като тях, нямам търпение да видя какво ще се случи в последните четири книги от поредицата“, признава Дейвид Шели, главен изпълнителен директор на Hachette UK.\r\n\r\n„Такова удоволствие е да знаеш, че предстои нов трилър от Робърт Галбрейт! Със седем романа зад гърба си Дж. К. Роулинг вече е усъвършенствала до блясък умението да създава драма, емоция, нaпрежение. Тя показа на читателите, че е в състояние да улови безкрайната сложност на човешкия дух, неговите тъмни и светли страни“, споделя Майкъл Пийч, главен изпълнителен директор на Hachette Book Group.\r\n\r\nНа български език са издадени шестте книги от поредицата дотук, предстои да излезе и седмият роман. С огромен успех се ползва и телевизионният сериал с главни герои Страйк и Робин, продуциран от Brontë Film and Television.",
                ImageUrl = "https://www.colibri.bg/news_img/20230505_1.jpg",
                DatePublished = DateTime.ParseExact("13/04/2024 11:20", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleEight = new Article()
            {
                Id = 8,
                Title = "Първата книжарница с 360-градусова виртуална реалност",
                Content = "Вече е факт единствената българска книжарница с имплементирана 360-градусова виртуална реалност - Либрария, https://www.colibri.bg/libraria/. Тя е интегрална част от уебстраницата на издателство „Колибри“. До виртуалната книжарница се стига чрез посочения линк или от менюто на colibri.bg. Освен че ще предлага изключителна възможност за подбор и закупуване на книги във виртуална среда за първи път в България, а може би и в света, тази интегрирана функционалност към уебсайта на издателството ще предоставя бонус под формата 10% допълнителна отстъпка  върху абсолютно всички текущи намаления на основния сайт!\r\n\r\n360-градусовата разходка представлява уникално, почти сюрреалистично приключение в компанията на заглавия от най-различни жанрове, дело на всепризнати творци и мислители. Пресъздавайки интериора на физическа книжарница, триизмерната визуализация осигурява опит, който е максимално близък до сетивния. Благодарение на технологията VR интерактивното преживяване позволява 360-градусова разходка в отлично построено виртуално пространство, фактически достъп до всеки продукт, реален избор на книги и оптимизиран процес на покупка. А тази възможност е неоценима при дефицит на време и в периоди, в които спокойната разходка в градска среда е възпрепятствана по една или друга причина.\r\n\r\nЛибрария е първата по рода си виртуална книжарница - същинска литературна вселена, в която всеки обект е своеобразен микрокосмос. Покана за смислено развлечение, адресирана към всеки буден ум, но и към всички онези подрастващи читатели, инстинктивно устремени към голямата литература. На разположение ще бъдат всички налични заглавия на издателство „Колибри“ - шедьоври на световната белетристика, класическа поезия, отбрана съвременна европейска и българска проза, изобретателни трилъри, неустоими предложения за деца, научни трудове, есета и документалистика, езикови системи и учебни помагала… Специално внимание заслужават изданията от емблематичната поредица „Амаркорд“, побрала разтърсващи изповеди на най-влиятелните фигури в световното киноизкуство.\r\n\r\nНа една от „стените“ в тази удивителна книжарница неслучайно се мъдрят думите на визионера Федерико Фелини: „Няма нищо по-честно от една мечта.“ Защото единствените граници на човешкото същество са границите на неговата фантазия, а тя може да бъде отключена от съприкосновението с хубави книги.\r\n\r\nНа добър час из виртуалните селения на литературата, която произвежда мечти!",
                ImageUrl = "https://www.colibri.bg/news_img/20220715_1.jpg",
                DatePublished = DateTime.ParseExact("14/04/2024 17:03", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleNine = new Article()
            {
                Id = 9,
                Title = "Две награди „Христо Г. Данов“ за издания на „Колибри“",
                Content = "На тържествена церемония в Стария град на Пловдив бяха обявени тазгодишните лауреати на националната награда „Христо Г. Данов“, която се връчва за принос в българската книжовна култура. \r\n\r\nСтатуетката за преводач на художествена литература отиде при Васил Самоковлиев, който беше отличен за блестящия превод на новелата „Сватби в къщата“ от Бохумил Храбал.\r\n\r\n„Сватби в къщата“ е ироничен портрет на артистичния живот в следвоенна Източна Европа и красноречиво свидетелство за това как личната история на един артист може да бъде преработена и излята в бляскава форма със средствата на литературата. Наративът сдвоява мъжката и женската визия за света - те се преливат една в друга виртуозно и се раздалечават също толкова естествено като илюстрация на неповторимата творческа индивидуалност на автора.\r\n\r\nВ категорията „Художник или дизайн и оформление на книга“ наградата отиде при Ясен Гюзелев заради възхитителното издание „Орфей и Евридика“.\r\n\r\nИсторията за Орфей и Евридика е един от най-тъжните митове в цялата гръцка митология. В изданието на „Колибри“ тя е вълнуващо онагледена с авторските илюстрации на Ясен Гюзелев. Художественото оформление е дело на Кирил Златков. За високото качество на изданието роля има и безупречният текст на Иван Б. Генов.\r\n\r\nС наградата за цялостен принос в българската книжовна култура посмъртно бе удостоен Марин Бодаков.\r\n\r\nТазгодишното жури беше представено от: Юрий Вълковски – зам.-министър на културата, Пламен Панов, зам.-кмет на Община Пловдив, Антон Баев, д-р Силва Хачерян, началник отдел \"Регионални дейности\" в МК, Димитър Минев, директор на НБ \"Иван Вазов\" – Пловдив, Бойко Ламбовски, проф. Магдалена Костова-Панайотова, Иван Есенски, Тоня Горанова. \r\n\r\nНаградите \"Христо Г. Данов\" се организират от Министерството на културата и Община Пловдив. Лауреатите на престижното отличие получават диплом, малка пластика и парична награда. Наградите се връчват ежегодно по случай 24 май - Ден на светите братя Кирил и Методий, на българската азбука, просвета и култура и на славянската книжовност.",
                ImageUrl = "https://www.colibri.bg/news_img/20220616_1.jpg",
                DatePublished = DateTime.ParseExact("12/03/2024 16:20", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };
        }

        private void SeedEvents()
        {
            EventOne = new Event()
            {
                Id = 1,
                Topic = "ИЗЛОЖБА | Етюд-и-те на София: 24 часа в града",
                Description = "Успоредно с излизането на книгата „Етюд-и-те на София: 24 часа в града“ Иван Шишиев ще представи и изложба на площад „Славейков“. Тя може да бъде видяна между 5-и и 30-и септември, а на деня на София, 17-и септември любителите на фотографията, литературата и техните проявления през обектива на Иван ще могат да се срещнат с автора на място в 11 ч. ЗА КНИГАТА: В рамките на 200 страници читателят е едновременно наблюдател и главен участник в един софийски ден. Какво са 24 часа в големия град? Как времето и пространството се пречупват под звуците на трамваите и тишината на спрелите часовници? Защо нишките на вековете са се оплели в малките улици на столицата и къде има опасност да пропаднеш хилядолетия назад? Този път фотографът на „Етюд-и-те на София“ се насочва към тези въпроси и към това да покаже как се изживява едно денонощие в града. А времето в София тече по свои собствени правила. И за да го уловиш истински във фотография, трябва да ги познаваш. Тик-так...",
                Location = "Площад Славейков, София",
                StartDate = DateTime.ParseExact("05/09/2023 12:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("30/09/2023 23:59", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/09/shishiev_event3.jpg",
                Seats = 5,
                TicketPrice = 20
            };
            EventTwo = new Event()
            { 
                Id = 2,
                Topic = "Представяне на книгата на Алберт Бенбасат „Когато големите станат малки“",
                Description = "Очакваме Ви на представяне на книгата на Алберт Бенбасат „Когато големите станат малки“ на 12 декември, вторник, от 18:30 ч. в Каза Либри (Casa Libri) на ул. Цар Асен 64. Със специалното участие на Тони Николов и Георги Цанков! Алберт Бенбасат (р. 1950 г.) e литературен историк, критик, публицист и издател; професор, преподавател във Факултета по журналистика и масова комуникация в Софийския университет „Св. Климент Охридски”. Автор е на 13 книги, сред които „Българската еротиада”, „Европеецът” Бай Ганю и светлият мит за Щастливеца”, „Печатни пространства и бели полета”, „Банкноти и мечти между кориците. Масова книга и масово книгоиздаване”, „Алиса в дигиталния свят. По въпроса за книгата през ХХІ век”. Редактор и издател на сп. „Критика” и Библиотека „Критика”, съставител и редактор на множество книги.",
                Location = "Каза Либри (Casa Libri), ул. Цар Асен",
                StartDate = DateTime.ParseExact("12/12/2023 18:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("12/12/2023 21:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/12/benbasat_event.jpg",
                Seats = 200,
                TicketPrice = 5
            };
            EventThree = new Event()
            {
                Id = 3,
                Topic = "Хана Арент - Произходът на тоталитаризма | Премиера",
                Description = "На 6 юни в 19:00 ч. Ви каним на премиера на „Произходът на тоталитаризма“ от Хана Арент. Очакваме Ви в Топлоцентрала, Сцена бар. Книгата „Произходът на тоталитаризма“ се издава за първи път на български език в нейната цялост и включва трите й основни части: Антисемитизмът, Империализмът, Тоталитаризмът. Това е най-ранният мащабен труд на Хана Арент, донесъл й международна известност. Още с публикуването му през 1951 г. той предизвиква широка дискусия в научните среди с интерпретациите, които са извън доминиращите парадигми.",
                Location = "Топлоцентрала, Сцена бар, София",
                StartDate = DateTime.ParseExact("06/06/2024 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("06/06/2024 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/05/arendt_event.jpg",
                Seats = 10,
                TicketPrice = 15
            };
            EventFour = new Event()
            {
                Id = 4,
                Topic = "ПРЕМИЕРА | Смъртта на Бялата лисица",
                Description = "На 17 април от 19:00 ч. в \"Червената къща\" (ул. Любен Каравелов 15) ще представим \"Смъртта на Бялата лисица\". Повече ще разкаже самата Анна Заркова. Модератор на събитието: Светлозар Желев Какво да очаквате от книгата? На 2 октомври 1996 г. пред дома му е застрелян Андрей Луканов – знаков политик на българския преход, министър-председател в две правителства, депутат. От кого и защо? И до днес нито една от версиите не е отречена или потвърдена. Делото „Луканов” е прекратено.",
                Location = "\"Червената къща\" (ул. Любен Каравелов 15)",
                StartDate = DateTime.ParseExact("17/04/2025 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("17/04/2025 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2024/04/zarkova_event.jpg",
                Seats = 100,
                TicketPrice = 10
            };
            EventFive = new Event()
            {
                Id = 5,
                Topic = "Премиера: „Минало несвършено“",
                Description = "На 21 март в 19:00 ч. ще отбележим появата на „Минало несвършено“ - криминален психологически роман по култовия сериал на NOVA „Отдел „Издирване“. Майсторски замислена, динамична и завладяваща история, която разширява света на героите от екрана и позволява на читателя да надникне в най-съкровените им мисли! С нас ще бъдат Александър Чобанов, Владимир Полеганов, Юлиан Вергов и Ана Пападопулу. Специално участие ще вземе и криминалният психолог Росен Йорданов.",
                Location = "Сцена Дерида",
                StartDate = DateTime.ParseExact("21/03/2024 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("21/03/2024 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2024/03/minalonesvarsheno_event.jpg",
                Seats = 7,
                TicketPrice = 10
            };
            EventSix = new Event()
            {
                Id = 6,
                Topic = "Среща с автограф с авторите на „Колибри“",
                Description = "На 8 декември от 18:00 ч. ви очакваме на щанд 315 в НДК за среща с авторите, които ни зарадваха с творбите си през 2023 г. Ще ви очакват Светлозар Желев, Божидар Манов, Селя Ахава, Милена Кирова, Искрен Красимиров, Мария Касимова-Моасе, Иван Шишиев, Алберт Бенбасат! Вземете книгите им с отстъпка и получете автограф! Проектът е реализиран с финансовата подкрепа на Национален фонд „Култура“ по програма „Програма за възстановяване и развитие на частни културни организации“.",
                Location = "Щанд 315, НДК",
                StartDate = DateTime.ParseExact("08/12/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("08/12/2024 21:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/12/sreshta-s-avtograf.jpg",
                Seats = 200,
                TicketPrice = 0
            };
            EventSeven = new Event()
            {
                Id = 7,
                Topic = "Среща с автограф с авторите на „Колибри“",
                Description = "Софийски международен литературен фестивал и издателство „Колибри“ ви канят на среща със Селя Ахава в разговор с Егил Бяртнасон на 8 декември, петък, от 14:00 ч. в НДК, етаж 2, мраморно фоайе. Модератор на събитието ще бъде Силвия Недкова. Финландската писателка Селя Ахава (1974 г.) придобива известност с романа „Неща, които падат от небето“, който печели наградата за литература на ЕС и наградата за разпространение на финландска литература „Факлоносци“. С логото на „Колибри“ в България е издадена и шокиращата автофикция „Преди да изчезне мъжът ми“. „Жената, която обичаше насекоми“ (превод: Росица Цветанова ) е четвъртият роман на Ахава, в който тя изследва връзката между човека и природата. Това е завладяваща творба за съвършенството на мирозданието, написана с изключително майсторство и оригинален подход към необичайното. Книгите ѝ могат да бъдат намерени и на щанд 315 в рамките на Коледния панаир на книгата с отстъпка! Очакваме ви!",
                Location = "НДК, етаж 2, мраморно фоайе",
                StartDate = DateTime.ParseExact("08/12/2023 14:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("08/12/2023 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/12/ahava_event.jpg",
                Seats = 44,
                TicketPrice = 5
            };
            EventEight = new Event()
            {
                Id = 8,
                Topic = "Премиера: От авторите и читателите ЗА КНИГИТЕ И ЧЕТЕНЕТО",
                Description = "Имаме удоволствието да ви поканим на премиерата на „От авторите и читателите ЗА КНИГИТЕ И ЧЕТЕНЕТО“ със съставители Анна Лазарова и Светлозар Желев. Събитието ще се състои на 29 ноември (сряда) от 19:00 ч. в Литературния клуб на Столична библиотека (етаж -1). Носете си доброто настроение и любовта към книгите! Вход свободен! ЗА КНИГАТА: Още през 1978 година в „Пътеводител на галактическия стопаджия“ Дъглъс Адамс дава отговор на „Великия въпрос за Живота, Вселената и Всичко останало“. Четиридесет и две. Това число обикаля света, бива разнищвано и изследвано, анализирано и свръхинтерпретирано. То се превръща в разпознавам белег на книгата, а чрез него единствено литературата измежду изкуствата и науките дръзва да застане зад отговор на неотговоримото.",
                Location = "Литературen клуб на Столична библиотека (етаж -1)",
                StartDate = DateTime.ParseExact("29/11/2023 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("29/11/2023 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/11/za-knigite-i-cheteneto-sofia.jpg",
                Seats = 27,
                TicketPrice = 2
            };
            EventNine = new Event()
            {
                Id = 9,
                Topic = "Премиера в София | „Приказки от Горната и Долната земя“",
                Description = "След лепкавата жега на Буенос Айрес тук всичко е чисто, свежо и хрупкаво като прясно изпрани чаршафи, уютно като планинско селце, пролетно като лютиче, цветно като шепа бонбони, усмихнато като слънчев лъч, синенебо като детски сън. Добродушно и смайващо самотно. Далече, далече от глъчката и шумотевицата, от тълпите и цивилизацията, от бързането и стреса, чак най-отдолу, най-на юг, най-накрая на земята. Fin del Mundo. Краят на света. Така Изабела Шопова описва Ушуая, градчето в най-южната част на Земята, краят на света, който със сигурност няма да сложи край на пътешествията ѝ.След „На изток – в рая“, „На запад от рая“, „На юг от разума“, „Подир сянката на кондора“ и съвсем между другото, „Самоучител за преднамерено убийство на скуката“, Изабела ни предлага поредната си завладяваща сага – „Приказки от Горната и Долната земя“.",
                Location = "Casa Libri",
                StartDate = DateTime.ParseExact("05/07/2024 09:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("05/07/2024 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/06/shopova_event_sofia.jpg",
                Seats = 200,
                TicketPrice = 3
            };
        }
    }
}