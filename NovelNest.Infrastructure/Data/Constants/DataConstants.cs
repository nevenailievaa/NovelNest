namespace NovelNest.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
        public const string DateTimeDefaultFormat = "dd/MM/yyyy";
        public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";

        public static class ApplicationUserConstants
        {
            public const int ApplicationUserFirstNameMinLength = 1;
            public const int ApplicationUserFirstNameMaxLength = 30;

            public const int ApplicationUserLastNameMinLength = 1;
            public const int ApplicationUserLastNameMaxLength = 30;
        }

        public static class BookConstants
        {
            //Title
            public const int BookTitleMinLength = 1;
            public const int BookTitleMaxLength = 100;

            //Author
            public const int BookAuthorMinLength = 4;
            public const int BookAuthorMaxLength = 70;

            //Description
            public const int BookDescriptionMinLength = 200;
            public const int BookDescriptionMaxLength = 5000;

            //Price
            public const string BookPriceMinValue = "1";
            public const string BookPriceMaxValue = "10000";

            //Page
            public const double BookPageMinValue = 1;
            public const double BookPageMaxValue = 10000;

            //PublishingHouse
            public const int BookPublishingHouseMinLength = 1;
            public const int BookPublishingHouseMaxLength = 70;

            //YearPublished
            public const int BookYearPublishedMinRange = 1;
            public const int BookYearPublishedMaxRange = 2024;

            //ImageUrl
            public const int BookImageUrlMinLength = 5;
            public const int BookImageUrlMaxLength = 200;
        }

        public static class GenreConstants
        {
            //Name
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 40;
        }

        public static class CoverConstants
        {
            //Name
            public const string CoverNameRegex = @"^(?i)(hard|soft)$";
        }

        public static class BookReviewConstants
        {
            //Title
            public const int BookReviewTitleMinLength = 1;
            public const int BookReviewTitleMaxLength = 50;

            //Description
            public const int BookReviewDescriptionMinLength = 15;
            public const int BookReviewDescriptionMaxLength = 8000;

            //Description
            public const int BookReviewRateMinRange = 1;
            public const int BookReviewRateMaxRange = 10;
        }

        public static class BookCurrentlyReadingConstants
        {
            //Current Page
            public const int BookCurrentPageMinRange = 1;
        }

        public static class BookStoreConstants
        {
            public const string DateTimeBookStoreFormat = "HH:mm";

            //Name
            public const int BookStoreNameMinLength = 1;
            public const int BookStoreNameMaxLength = 100;

            //Location
            public const int BookStoreLocationMinLength = 10;
            public const int BookStoreLocationMaxLength = 100;

            //Contact
            public const int BookStoreContactMinLength = 8;
            public const int BookStoreContactMaxLength = 20;

            //ImageUrl
            public const int BookStoreImageUrlMinLength = 5;
            public const int BookStoreImageUrlMaxLength = 500;
        }

        public static class EventConstants
        {
            public const string DateTimeEventFormat = "dd/MM/yyyy HH:mm";

            //Topic
            public const int EventTopicMinLength = 10;
            public const int EventTopicMaxLength = 100;

            //Description
            public const int EventDescriptionMinLength = 50;
            public const int EventDescriptionMaxLength = 1000;

            //Location
            public const int EventLocationMinLength = 10;
            public const int EventLocationMaxLength = 100;

            //ImageUrl
            public const int EventImageUrlMinLength = 5;
            public const int EventImageUrlMaxLength = 500;

            //Seats
            public const int EventSeatsMinRange = 1;
            public const uint EventSeatsMaxRange = uint.MaxValue;

            //Ticket Price
            public const int EventTicketPriceMinRange = 1;
            public const uint EventTicketPriceMaxRange = uint.MaxValue;
        }

        public static class ArticleConstants
        {
            public const string DateTimeArticleFormat = "dd/MM/yyyy HH:mm";

            //Title
            public const int ArticleTitleMinLength = 5;
            public const int ArticleTitleMaxLength = 100;

            //Content
            public const int ArticleContentMinLength = 100;
            public const int ArticleContentMaxLength = 10000;

            //ImageUrl
            public const int ArticleImageUrlMinLength = 5;
            public const int ArticleImageUrlMaxLength = 500;

            //ViewsCount
            public const int ArticleViewsCountMinRange = 0;
            public const int ArticleViewsCountMaxLength = int.MaxValue;
        }
        public static class ArticleCommentConstants
        {
            //Title
            public const int ArticleCommentTitleMinLength = 1;
            public const int ArticleCommentTitleMaxLength = 50;

            //Description
            public const int ArticleCommentDescriptionMinLength = 15;
            public const int ArticleCommentDescriptionMaxLength = 2000;
        }
    }
}