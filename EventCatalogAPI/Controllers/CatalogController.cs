using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _configuration;

        public CatalogController(CatalogContext catalogContext,
            IConfiguration Configuration)
        {
            _catalogContext = catalogContext;
            _configuration = Configuration;
        }

        //Get for Catagories

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> catagories()
        {
            var Events = await _catalogContext.Catagories.ToListAsync();
            return Ok(Events);
        }

        // Get for subcatagories
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> subcatagories()
        {
            var Events = await _catalogContext.SubCatagories.ToListAsync();
            return Ok(Events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events(
             [FromQuery] int pagesize = 5,
             [FromQuery]int pageIndex = 0
            )
        {
            var totalEvents = await
                _catalogContext.Events.LongCountAsync();

            var eventsOnPage = await _catalogContext.Events
                 .OrderBy(c => c.EventName)
                 .Skip(pageIndex * pagesize)
                 .Take(pagesize)
                 .ToListAsync();

            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
            return Ok(eventsOnPage);
        }

        // get Event by location

        [HttpGet]
        [Route("[action]/Location/{Location:minlength(1)}")]
        public async Task<IActionResult> GetEventByLocation(
            string location,
             [FromQuery] int pagesize = 5,
             [FromQuery]int pageIndex = 0
            )
        {
            var totalEvents = await
                _catalogContext.Events.LongCountAsync();

            var eventsOnPage = await _catalogContext.Events
                .Where(c => c.Location.StartsWith(location))
                 .OrderBy(c => c.Location)
                 .Skip(pageIndex * pagesize)
                 .Take(pagesize)
                 .ToListAsync();

            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
            return Ok(eventsOnPage);
        }


        //Get event by EventName

        [HttpGet]
        [Route("[action]/EventName/{EventName:minlength(1)}")]
        public async Task<IActionResult> Events(
            string EventName,
             [FromQuery] int pagesize = 5,
             [FromQuery]int pageIndex = 0
            )
        {
            var totalEvents = await
                _catalogContext.Events.LongCountAsync();

            var eventsOnPage = await _catalogContext.Events
                .Where(c => c.EventName.StartsWith(EventName))
                 .OrderBy(c => c.EventName)
                 .Skip(pageIndex * pagesize)
                 .Take(pagesize)
                 .ToListAsync();

            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
            return Ok(eventsOnPage);
        }

        // Search By type / brand

        //[HttpGet]
        ////items/type/1/brand/3 --- example EventCategoryId=1, EventSubCatagoryId=2
        //[Route("[action]/Category/{EventCategoryId}/SubCatagory/{EventSubCatagoryId}")]
        //public async Task<IActionResult> Items(
        //    // ? nullable type-- allowing null value
        //    //Example -- items/type//brand/3
        //    int? eventCategoryId,
        //    int? eventSubCatagoryId,
        //    [FromQuery] int pagesize = 5,
        //    [FromQuery]int pageIndex = 0
        //  )
        //{
        //    //Iqueryable is just converting to Query
        //    var root = (IQueryable<Event>)_catalogContext.Events;
        //    if (eventCategoryId.HasValue)
        //    {
        //        root = root.Where(c => c.EventCategoryId == eventCategoryId);
        //    }
        //    if (eventSubCatagoryId.HasValue)
        //    {
        //        root = root.Where(c => c.EventSubCatagoryId == eventSubCatagoryId);
        //    }

        //    // root is a query
        //    var totalEvents = await
        //        _catalogContext.Events.LongCountAsync();

        //    var eventsOnPage = await _catalogContext.Events
        //        .Where(c => c.EventName.StartsWith())
        //         .OrderBy(c => c.EventName)
        //         .Skip(pageIndex * pagesize)
        //         .Take(pagesize)
        //         .ToListAsync();

        //    eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
        //    return Ok(eventsOnPage);
        //}

        //post
        [HttpPost]
        [Route("events")]

        public async Task<IActionResult> CreateEvent(
            [FromBody] Event product)
        {
            var eventss = new Event
            {
                EventCategoryId = product.EventCategoryId,
                EventSubCatagoryId = product.EventSubCatagoryId,
                Description = product.Description,
                EventName = product.EventName,
                EventStartDate = product.EventStartDate,
                EventEndDate = product.EventEndDate,
                EventStartTime =product.EventStartTime,
                EventEndTime = product.EventEndTime,
                EventImageUrl=product.EventImageUrl,
                Fee =product.Fee,
                Address=product.Address,
                Location=product.Location,
                Created =product.Created

            };
            _catalogContext.Events.Add(eventss);
           await _catalogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventById), new { id = eventss.EventID});
        }   
  // Get event by event Id
        [HttpGet]
        [Route("Events/{EventID:int}")]

     public async Task<IActionResult> GetEventById(int EventID)
        {
            if (EventID <= 0)
            {
                return BadRequest();
            }
            // this method return one item
            var Events = await _catalogContext.Events
                  .SingleOrDefaultAsync(c => c.EventID == EventID);
            if (Events != null)
            {
                Events.EventImageUrl = Events.EventImageUrl
                    .Replace("http://externalcatalogbaseurltobereplaced",
                _configuration["ExternalCatalogBaseurl"]);
                return Ok(Events);
            }
            return NotFound();
        }

        private List<Event> ChangeUrlPlaceholder(
            List<Event> Events)
        {
            Events.ForEach(
                x => x.EventImageUrl =
                x.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced",
                _configuration["ExternalCatalogBaseurl"]));
               return Events;
        }

    }
}