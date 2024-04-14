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
        public Book AnnaKarenina { get; set; }
        public Book Hannibal { get; set; }
        public Book MenWhoHateWomen { get; set; }
        public Book MeBeforeYou { get; set; }
        public Book TheDiaryOfAYoungGirl { get; set; }
        public Book Searched { get; set; }
        public Book QuoVadis { get; set; }
        public Book Tobacco { get; set; }
        public Book WomanInMe { get; set; }
        public Book AtMothers { get; set; }
        public Book TheWitcherOne { get; set; }
        public Book ImStillCountingTheDays { get; set; }
        public Book TheLettersWar { get; set; }
        public Book TheHungerGamesOne { get; set; }
        public Book TheHungerGamesTwo { get; set; }
        public Book TheHungerGamesThree { get; set; }
        public Book TheHungerGamesBalad { get; set; }

        //Book Stores
        public BookStore Ciela { get; set; }
        public BookStore Helikon { get; set; }
        public BookStore Orange { get; set; }

        //Articles
        public Article ArticleMenWhoHateWomen { get; set; }
        public Article ArticleHarryPotter { get; set; }
        public Article ArticleBaiTosho { get; set; }

        //Events
        public Event EventSofiasEtudes { get; set; }
        public Event EventAlbertBenbasat { get; set; }
        public Event EventTotalitarism { get; set; }


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
                FirstName = "Nevena",
                LastName = "Ilieva"
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
            AnnaKarenina = new Book()
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

            Hannibal = new Book()
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

            MenWhoHateWomen = new Book()
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

            MeBeforeYou = new Book()
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

            TheDiaryOfAYoungGirl = new Book()
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
            
            Searched = new Book()
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

            QuoVadis = new Book()
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
            
            Tobacco = new Book()
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
            
            WomanInMe = new Book()
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

            AtMothers = new Book()
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

            TheWitcherOne = new Book()
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

            ImStillCountingTheDays = new Book()
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

            TheLettersWar = new Book()
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

            TheHungerGamesOne = new Book()
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

            TheHungerGamesTwo = new Book()
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

            TheHungerGamesThree = new Book()
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

            TheHungerGamesBalad = new Book()
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

        private void SeedBookStores()
        {
            Ciela = new BookStore()
            {
                Id = 1,
                Name = "Ciela - Витоша",
                Location = "София център, бул. „Витоша“ 60, 1463 София",
                ImageUrl = "https://adandcity.files.wordpress.com/2015/05/926.jpg",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("21:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0876536843",
            };
            Helikon = new BookStore()
            {
                Id = 2,
                Name = "Helikon - Пазарджик",
                Location = "Пазарджик Център, ул. „Професор Асен Златаров“ 23, 4400 Пазарджик",
                ImageUrl = "https://i.helikon.bg/content/601/202304270903201726.jpg",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0896236457",
            };
            Orange = new BookStore()
            {
                Id = 3,
                Name = "Orange - The Mall",
                Location = "м. Къро, бул. „Цариградско шосе“ 115, 1000 София",
                ImageUrl = "https://www.orangecenter.bg/media/extensa_shop/image/grand-mall-varna_1.jpg",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "0892414935",
            };
        }

        private void SeedArticles()
        {
            ArticleMenWhoHateWomen = new Article()
            {
                Id = 1,
                Title = "„Мъжете, които мразеха жените“ на Стиг Ларшон с ново издание",
                Content = "Излезе ново издание на „Мъжете, които мразеха жените“ (превод: Неда Димова-Бренстрьом, 464 стр., цена: 18 лв., издателство Колибри), най-зашеметяващия трилър от началото на XXI век. Зрелищната корица е дело на Живко Петров. МИЛЕНИУМ е името на вестника, чийто съсобственик и отговорен редактор Микаел Блумквист е главен герой в едноименната трилър трилогия. Още с излизането си през 2005 г. трилогията постига феноменален световен успех. „Мъжeтe, които мразеха жените“, първата книга от поредицата, получава наградата „Стъклен ключ“ за най-добър скандинавски роман за 2005 г., а вторият, „Момичето, което си играеше с огъня“ – наградата за най-добър шведски криминален роман за 2006 г. До момента от трите книги са продадени над 86 милиона екземпляра. Богатият индустриалец Хенрик Вангер предлага на Микаел Блумквист едногодишен договор срещу огромен хонорар, ако успее да разгадае мистерията с изчезването на любимата му племенница Хариет. Блумквист е разследващ журналист, разкрил ред скандални случаи и несправедливо осъден за клевета заради написана от него изобличителна статия срещу могъщ шведски финансов магнат. Заедно със суперхакера Лисбет Саландер – млада, кльощава, татуирана жена, регистрирана като психопат, работеща в детективска агенция, попадат във водовъртеж от драматични изпитания, семейна омраза и финансови скандали.Трилогията МИЛЕНИУМ разказва за един свят на аморални финансови сделки, на екстремистки заговори и на изкривено правосъдие. Свят, в който ще разпознаете и недъзи на българския политически и обществен живот. Стиг Ларшон (1954-2004) е известен шведски журналист и писател, чиито разследвания изобличават антидемократичните, дясноекстремистките и расистките практики в обществото и медиите. Трилогията Милениум му носи изключителна популярност още с публикуването на Мъжете, които мразеха жените, който има две успешни екранизации – шведска и американска. Ларшон умира от сърдечна криза на петдесетгодишна възраст наскоро след като е предал на издателя криминалната си поредица „Милениум“ и не доживява нейното отпечатване. Носят се слухове, че смъртта му не е случайна и е свързана с дейността му на разследващ журналист. През декември 2013 г. шведското издателство „Норстед“ обяви, че Давид Лагеркранс ще продължи поредицата на Стиг Ларшон. Последва цяла трилогия, преплитаща политически скандали и властови игри на високо ниво с ДНК изследвания, хималайски експедиции, киберпрестъпления и организирана омраза в интернет.",
                ImageUrl = "https://i0.wp.com/vevesti.bg/wp-content/uploads/2021/11/9089304680924850968250498290457.jpg?resize=678%2C509&ssl=1",
                DatePublished = DateTime.ParseExact("24/04/2023 10:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleHarryPotter = new Article()
            {
                Id = 2,
                Title = "Продадоха за 55 000 паунда книга за Хари Потър, трупала прах 26 години",
                Content = "Във Великобритания копие от първото издание на „Хари Потър и магьосническият камък“ на Дж. К. Роулинг, лежало 26 години в шкаф под стълбите, беше продадено на търг, съобщава Derbyshire Times. Книгата беше продадена на 11 декември в Hansons Auctioneers в Дербишър за 55 100 паунда. В продължение на много години тя се пазила от 58-годишна жителка, която я купила през 1997 г. по време на пътуване със семейството си. В магазина детската книга се намирала в кошницата с намаления и се продавала само за 10 паунда. „Купих си книга за Хари Потър, когато никой не знаеше за него или неговия автор. Пътувахме с кола в Шотландските планини. Имаше кафе-книжарница на един далечен полуостров в края на пътя”, разказва жената. Тя също така отбеляза, че е успяла да договори книгата за осем паунда, тъй като нямала външна обложка. По време на пътуването всяка вечер британката четяла приказка на децата си. По-късно книгата била прибрана в килер, където се съхранявала доскоро. Книгата се съхранила в отлично състояние. Специалист от Hansons Auctioneers разкри, че това е много рядко първо издание с твърди корици на първия роман на Джоан Роулинг за Хари Потър. Бяха отпечатани общо 500 книги, 300 от тях бяха разпространени в библиотеките, а само 200 бяха пуснати в продажба. В момента само 19 книги от тази серия са известни на колекционерите. Те бяха продадени на търгове за суми от 17 500 до 69 000 британски лири. По-рано беше съобщено, че библиотекарката Джанет Такуел решила да продаде първите издания на книги за Хари Потър с автографи на авторката. Жената получава подписите на Джоан Роулинг през 1999 г., когато работи като учителка и водила децата си на среща с писателката.",
                ImageUrl = "https://www.tialoto.bg/media/files/resized/article/615x348/7e2/ad7a2b33b135c4662c374a7a37a8d7e2-5580840.jpg",
                DatePublished = DateTime.ParseExact("02/02/2024 14:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            ArticleBaiTosho = new Article()
            {
                Id = 3,
                Title = "Иво Сиромахов представя романа си „Бай Тошо“ днес в Бургас",
                Content = "От 17,30 часа в зала „Ахело“ на Гранд хотел и СПА Приморец – организатор на културния форум, своята нова книга „Бай Тошо“ ще представи писателят, сценарист, драматург и телевизионен водещ Иво Сиромахов. Четивото е с логото на Сиела и е забавна безмилостна сатира на абсурдните времена, в които живеем. „България в наши дни. След провала на всички марионетни партии, създадени от невидимите политически инженери, се е стигнало до тежка безизходица. Време е да бъде изваден последният коз. С помощта на модерните технологии един олигарх възкресява образа на Бай Тошо и го поставя начело на държавата. За да „оправи“ всичко… „ – гласи анотацията на книгата. Повече, заповядайте да научите лично от нейния автор Иво Сиромахов. Ще има разговори, книги, автографи.",
                ImageUrl = "https://www.burgasnews.com/wp-content/uploads/2023/10/ivo-siromahov.jpg",
                DatePublished = DateTime.ParseExact("18/02/2024 19:30", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };
        }

        private void SeedEvents()
        {
            EventSofiasEtudes = new Event()
            {
                Id = 1,
                Topic = "ИЗЛОЖБА | Етюд-и-те на София: 24 часа в града",
                Description = "Успоредно с излизането на книгата „Етюд-и-те на София: 24 часа в града“ Иван Шишиев ще представи и изложба на площад „Славейков“. Тя може да бъде видяна между 5-и и 30-и септември, а на деня на София, 17-и септември любителите на фотографията, литературата и техните проявления през обектива на Иван ще могат да се срещнат с автора на място в 11 ч. ЗА КНИГАТА: В рамките на 200 страници читателят е едновременно наблюдател и главен участник в един софийски ден. Какво са 24 часа в големия град? Как времето и пространството се пречупват под звуците на трамваите и тишината на спрелите часовници? Защо нишките на вековете са се оплели в малките улици на столицата и къде има опасност да пропаднеш хилядолетия назад? Този път фотографът на „Етюд-и-те на София“ се насочва към тези въпроси и към това да покаже как се изживява едно денонощие в града. А времето в София тече по свои собствени правила. И за да го уловиш истински във фотография, трябва да ги познаваш. Тик-так...",
                Location = "Площад Славейков, София",
                StartDate = DateTime.ParseExact("05/09/2023 12:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("30/09/2023 23:59", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/09/shishiev_event3.jpg"
            };
            EventAlbertBenbasat = new Event()
            { 
                Id = 2,
                Topic = "Представяне на книгата на Алберт Бенбасат „Когато големите станат малки“",
                Description = "Очакваме Ви на представяне на книгата на Алберт Бенбасат „Когато големите станат малки“ на 12 декември, вторник, от 18:30 ч. в Каза Либри (Casa Libri) на ул. Цар Асен 64. Със специалното участие на Тони Николов и Георги Цанков! Алберт Бенбасат (р. 1950 г.) e литературен историк, критик, публицист и издател; професор, преподавател във Факултета по журналистика и масова комуникация в Софийския университет „Св. Климент Охридски”. Автор е на 13 книги, сред които „Българската еротиада”, „Европеецът” Бай Ганю и светлият мит за Щастливеца”, „Печатни пространства и бели полета”, „Банкноти и мечти между кориците. Масова книга и масово книгоиздаване”, „Алиса в дигиталния свят. По въпроса за книгата през ХХІ век”. Редактор и издател на сп. „Критика” и Библиотека „Критика”, съставител и редактор на множество книги.",
                Location = "Каза Либри (Casa Libri), ул. Цар Асен",
                StartDate = DateTime.ParseExact("12/12/2023 18:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("12/12/2023 21:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/12/benbasat_event.jpg"
            };
            EventTotalitarism = new Event()
            {
                Id = 3,
                Topic = "Хана Арент - Произходът на тоталитаризма | Премиера",
                Description = "На 6 юни в 19:00 ч. Ви каним на премиера на „Произходът на тоталитаризма“ от Хана Арент. Очакваме Ви в Топлоцентрала, Сцена бар. Книгата „Произходът на тоталитаризма“ се издава за първи път на български език в нейната цялост и включва трите й основни части: Антисемитизмът, Империализмът, Тоталитаризмът. Това е най-ранният мащабен труд на Хана Арент, донесъл й международна известност. Още с публикуването му през 1951 г. той предизвиква широка дискусия в научните среди с интерпретациите, които са извън доминиращите парадигми.",
                Location = "Топлоцентрала, Сцена бар, София",
                StartDate = DateTime.ParseExact("06/06/2024 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("06/06/2024 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2023/05/arendt_event.jpg"
            };
        }
    }
}