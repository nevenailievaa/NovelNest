namespace NovelNest.Controllers
{
    using NovelNest.Core.Contracts;

    public class PublisherController : BaseController
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }
    }
}