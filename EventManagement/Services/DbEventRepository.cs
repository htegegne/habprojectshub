using EventManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
//using UserManager.Data;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Services
{
    public class DbEventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        // Constructor now accepts EventDbContext
        public DbEventRepository(EventDbContext context)
        {
            _context = context;
        }

        // Create a new event
        public async Task<Event> CreateAsync(Event createEvent)
        {
            _context.Events.Add(createEvent);
            await _context.SaveChangesAsync();
            return createEvent;
        }

        // Read an event by its ID
        public async Task<Event> ReadAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        // Get all events
        public async Task<ICollection<Event>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        // Update an existing event
        public async Task UpdateAsync(int id, Event updateEvent)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEvent != null)
            {
                existingEvent.EventTitle = updateEvent.EventTitle;
                existingEvent.EventDescription = updateEvent.EventDescription;
                existingEvent.EventOrganizer = updateEvent.EventOrganizer;
                existingEvent.EventDate = updateEvent.EventDate;
                existingEvent.EventTime = updateEvent.EventTime;
                existingEvent.EndDate = updateEvent.EndDate;
                existingEvent.EventPlace = updateEvent.EventPlace;
                existingEvent.Category = updateEvent.Category;
                existingEvent.Attendees = updateEvent.Attendees;
                existingEvent.RegistrationDeadline = updateEvent.RegistrationDeadline;
                existingEvent.RegistrationFee = updateEvent.RegistrationFee;
                existingEvent.Capacity = updateEvent.Capacity;
                existingEvent.ImageUrl = updateEvent.ImageUrl;

                await _context.SaveChangesAsync();
            }
        }

        // Delete an event by its ID
        public async Task DeleteAsync(int id)
        {
            var eventToDelete = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
/* public class DbEventRepository : IEventRepository
 {
     private readonly IEventApiClient _eventApiClient;

     public DbEventRepository(IEventApiClient eventApiClient)
     {
         _eventApiClient = eventApiClient;
     }

     public async Task<Event> CreateAsync(Event createEvent)
     {
         return await _eventApiClient.CreateEventAsync(createEvent);
     }

     public async Task<Event> ReadAsync(int id)
     {
         return await _eventApiClient.GetEventAsync(id);
     }

     public async Task<ICollection<Event>> GetAllAsync()
     {
         return await _eventApiClient.GetAllEventsAsync();
     }
     public async Task UpdateAsync(int id, Event updateEvent)
     {
         // Call the API to update the event
         await _eventApiClient.UpdateEventAsync(id, updateEvent);
     }

     public async Task DeleteAsync(int id)
     {
         // Call the API to delete the event
         await _eventApiClient.DeleteEventAsync(id);
     }
     *//* private readonly EventDbContext _context;

      public DbEventRepository(EventDbContext context)
      {
          _context = context;
      }

      public async Task<Event> CreateAsync(Event createEvent)
      {
          _context.Events.Add(createEvent);
          await _context.SaveChangesAsync();
          return createEvent;
      }

      public async Task<Event> ReadAsync(int id)
      {
          return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
      }

      public async Task<ICollection<Event>> GetAllAsync()
      {
          return await _context.Events.ToListAsync();
      }

      public async Task UpdateAsync(int id, Event updateEvent)
      {
          var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
          if (existingEvent != null)
          {
              existingEvent.EventTitle = updateEvent.EventTitle;
              existingEvent.EventDescription = updateEvent.EventDescription;
              existingEvent.EventOrganizer = updateEvent.EventOrganizer;
              existingEvent.EventDate = updateEvent.EventDate;
              existingEvent.EventTime = updateEvent.EventTime;
              existingEvent.EndDate = updateEvent.EndDate;
              existingEvent.EventPlace = updateEvent.EventPlace;
              existingEvent.Category = updateEvent.Category;
              existingEvent.Attendees = updateEvent.Attendees;
              existingEvent.RegistrationDeadline = updateEvent.RegistrationDeadline;
              existingEvent.RegistrationFee = updateEvent.RegistrationFee;
              existingEvent.Capacity = updateEvent.Capacity;
              existingEvent.ImageUrl = updateEvent.ImageUrl;

              await _context.SaveChangesAsync();
          }
      }

      public async Task DeleteAsync(int id)
      {
          var eventToDelete = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
          if (eventToDelete != null)
          {
              _context.Events.Remove(eventToDelete);
              await _context.SaveChangesAsync();
          }
      }*//*
 }
}
*/