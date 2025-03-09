

using EventManagement.Models.Entities;

namespace EventManagement.Services
{
    public interface IEventRepository
    {

        Task<Event> CreateAsync(Event createEvent);
        Task<Event> ReadAsync(int id);
        Task<ICollection<Event>> GetAllAsync();
        Task UpdateAsync(int id, Event updateEvent);
        Task DeleteAsync(int id);


    }
}
