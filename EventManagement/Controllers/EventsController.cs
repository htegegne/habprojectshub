using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManagement.Models.Entities;
using EventManagement.Services;
using Microsoft.AspNetCore.Identity;

//using UserManager.Models;
using Microsoft.AspNetCore.Authorization;


namespace EventManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using Microsoft.AspNetCore.Identity;

    //using UserManager.Models;
    using Microsoft.AspNetCore.Authorization;


    namespace EventManagement.Controllers
    {
        public class EventsController : Controller  // Change ControllerBase to Controller
        {
            private readonly IEventRepository _eventService;

            public EventsController(IEventRepository eventService)
            {
                _eventService = eventService;
            }

            // GET: /Events
            public async Task<IActionResult> Index()
            {
                var events = await _eventService.GetAllAsync();
                return View(events); // Return the view with all events
            }

            // GET: /Events/Details/5
            public async Task<IActionResult> Details(int id)
            {
                var eventDetails = await _eventService.ReadAsync(id);
                if (eventDetails == null)
                {
                    return NotFound();
                }
                return View(eventDetails); // Render the Details view with event data
            }

            // GET: /Events/Create
            public IActionResult Create()
            {
                return View(); // Render the Create view
            }

            // POST: /Events/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Event createEvent)
            {
                if (!ModelState.IsValid)
                {
                    return View(createEvent); // Return the Create view with validation errors
                }

                await _eventService.CreateAsync(createEvent);
                return RedirectToAction(nameof(Index)); // Redirect to Index view after successful creation
            }

            // GET: /Events/Edit/5
            public async Task<IActionResult> Edit(int id)
            {
                var eventToEdit = await _eventService.ReadAsync(id);
                if (eventToEdit == null)
                {
                    return NotFound();
                }
                return View(eventToEdit); // Render the Edit view with event data
            }

            // POST: /Events/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Event updatedEvent)
            {
                if (id != updatedEvent.Id)
                {
                    return BadRequest(); // Ensure the route ID matches the model ID
                }

                if (!ModelState.IsValid)
                {
                    return View(updatedEvent); // Return the Edit view with validation errors
                }

                await _eventService.UpdateAsync(id, updatedEvent);
                return RedirectToAction(nameof(Index)); // Redirect to Index view after successful update
            }

            // GET: /Events/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                var eventToDelete = await _eventService.ReadAsync(id);
                if (eventToDelete == null)
                {
                    return NotFound();
                }
                return View(eventToDelete); // Render the Delete confirmation view with event data
            }

            // POST: /Events/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _eventService.DeleteAsync(id);
                return RedirectToAction(nameof(Index)); // Redirect to Index view after successful deletion
            }
        }
    }
}
       /* [Route("api/[controller]")]
        [ApiController]
        public class EventsController : ControllerBase
        {
            private readonly IEventRepository _eventService;

            public EventsController(IEventRepository eventService)
            {
                _eventService = eventService;
            }
            // This method can be used for testing or returning a specific view
            public async Task<IActionResult> Index()
            {
                var events = await _eventService.GetAllAsync(); // Fetch all events
                return Ok(events); // Return events as JSON (not typical in an API)
            }

            // GET: api/Events
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Event>>> GetAll()
            {
                var events = await _eventService.GetAllAsync();
                return Ok(events);  // Return events as JSON
            }

            // GET: api/Events/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Event>> GetById(int id)
            {
                var eventDetails = await _eventService.ReadAsync(id);

                if (eventDetails == null)
                {
                    return NotFound();  // Return 404 if event is not found
                }

                return Ok(eventDetails);  // Return event details as JSON
            }

            // POST: api/Events
            [HttpPost]
            public async Task<ActionResult<Event>> Create([FromBody] Event createEvent)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);  // Return validation error
                }

                var newEvent = await _eventService.CreateAsync(createEvent);
                return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);  // Return 201 Created
            }

            // PUT: api/Events/5
            *//*     [HttpPut("{id}")]
                 public async Task<IActionResult> Update(int id, [FromBody] Event updateEvent)
                 {
                     if (id != updateEvent.Id)
                     {
                         return BadRequest("Event ID mismatch.");  // Return 400 Bad Request if IDs don't match
                     }
                     if (!ModelState.IsValid)
                     {
                         return BadRequest(ModelState);  // Return validation error
                     }

                     var existingEvent = await _eventService.ReadAsync(id);
                     if (existingEvent == null)
                     {
                         return NotFound();  // Return 404 if event not found
                     }

                     // Assuming Event has other properties to update
                     existingEvent.SomeProperty = updateEvent.SomeProperty; // Replace with actual property names
                     existingEvent.AnotherProperty = updateEvent.AnotherProperty; // Replace with actual property names
                                                                                  // Repeat for other properties you want to update

                     await _eventService.UpdateAsync(id, existingEvent);
                     return NoContent();  // Return 204 No Content after successful update

                     // DELETE: api/Events/5
                     [HttpDelete("{id}")]
                 public async Task<IActionResult> Delete(int id)
                 {
                     var existingEvent = await _eventService.ReadAsync(id);
                     if (existingEvent == null)
                     {
                         return NotFound();  // Return 404 if event not found
                     }

                     await _eventService.DeleteAsync(id);
                     return NoContent();  // Return 204 No Content after successful deletion
                 }
     *//*
        }
    }
}*/