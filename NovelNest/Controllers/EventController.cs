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
        private readonly IPublisherService publisherService;

        public EventController(IEventService eventService, IPublisherService publisherService)
        {
            this.eventService = eventService;
            this.publisherService = publisherService;
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

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Add()
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
            {
                return Unauthorized();
            }

            var eventForm = new EventAddViewModel();

            return View(eventForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Add(EventAddViewModel eventForm)
        {
            if (eventForm.StartDate >= eventForm.EndDate)
            {
                ModelState.AddModelError("StartDate", "Invalid timespan!");
                ModelState.AddModelError("EndDate", "Invalid timespan!");
            }

            if (!ModelState.IsValid)
            {
                return View(eventForm);
            }

            await eventService.AddAsync(eventForm);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            var eventForm = await eventService.EditGetAsync(id);
            return View(eventForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Edit(EventEditViewModel eventForm)
        {
            if (eventForm == null)
            {
                return BadRequest();
            }
            if (eventForm.StartDate >= eventForm.EndDate)
            {
                ModelState.AddModelError("StartDate", "Invalid timespan!");
                ModelState.AddModelError("EndDate", "Invalid timespan!");
            }
            if (!ModelState.IsValid)
            {
                return View(eventForm);
            }

            int id = eventForm.Id;
            await eventService.EditPostAsync(eventForm);
            return RedirectToAction(nameof(Details), new { id, information = eventForm.GetInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedEvent = await eventService.DeleteAsync(id);

            return View(searchedEvent);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            await eventService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
