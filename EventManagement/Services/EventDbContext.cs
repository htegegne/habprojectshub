using EventManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Services
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions options) : base(options)
        {

        }
        public required DbSet<Event> Events { get; set; }
    }
    
}
