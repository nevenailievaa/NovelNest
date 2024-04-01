namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.QueryModels.Event;

    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllEventsQueryModel model)
        {
            var allEvents = await eventService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.Status,
                model.CurrentPage,
                model.EventsPerPage);

            model.TotalEventsCount = allEvents.TotalEventsCount;
            model.Events = allEvents.Events;

            return View(model);
        }
    }
}
