namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Extensions;
    using NovelNest.Core.Models.QueryModels.Event;
    using NovelNest.Core.Models.ViewModels.Event;
    using System.Security.Claims;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            var currentEvent = await eventService.DetailsAsync(id);

            if (information != currentEvent.GetInformation())
            {
                return BadRequest();
            }
            return View(currentEvent);
        }
    }
}
