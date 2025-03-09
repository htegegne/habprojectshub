using JobBoard.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Services
{
    public class DbJobRepository : IJobRepository
    {
        private readonly JobDbContext _context;

        public DbJobRepository(JobDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobListing>> GetAllJobsAsync()
        {
            return await _context.JobListings.ToListAsync();
        }

        public async Task<JobListing?> GetJobByIdAsync(int id)
        {
            return await _context.JobListings.FindAsync(id);
        }

        public async Task AddJobAsync(JobListing job)
        {
            _context.JobListings.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(JobListing job)
        {
            _context.JobListings.Update(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(int id)
        {
            var job = await _context.JobListings.FindAsync(id);
            if (job != null)
            {
                _context.JobListings.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
