using JobBoard.Models.Entities;

namespace JobBoard.Services
{
    public interface IJobRepository
    {
        Task<IEnumerable<JobListing>> GetAllJobsAsync();
        Task<JobListing?> GetJobByIdAsync(int id);
        Task AddJobAsync(JobListing job);
        Task UpdateJobAsync(JobListing job);
        Task DeleteJobAsync(int id);
    }
}
