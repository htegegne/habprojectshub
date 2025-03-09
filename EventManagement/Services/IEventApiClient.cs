using EventManagement.Models.Entities;

namespace EventManagement.Services
{
    public interface IEventApiClient
    {
        Task<Event> CreateEventAsync(Event createEvent);
        Task<Event> GetEventAsync(int id);
        Task<ICollection<Event>> GetAllEventsAsync();
            Task UpdateEventAsync(int id, Event updateEvent);
        Task DeleteEventAsync(int id);
    }
}
