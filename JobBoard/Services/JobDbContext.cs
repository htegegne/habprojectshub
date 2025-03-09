using JobBoard.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Services
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions options) : base(options)
        {

        }
        public required DbSet<JobListing> JobListings { get; set; }
    }
    
    
}
