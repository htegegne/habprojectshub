using JobBoard.Models.Entities;
using JobBoard.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class JobListingsController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobListingsController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        // GET: /JobBoard
        public async Task<IActionResult> Index(string searchTerm)
        {
            var jobs = await _jobRepository.GetAllJobsAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                jobs = jobs.Where(j =>
                    j.Title.ToLower().Contains(searchTerm) ||
                    j.CompanyName.ToLower().Contains(searchTerm) ||
                    j.Location.ToLower().Contains(searchTerm))
                .ToList();
            }
            return View(jobs);
        }

        // GET: /JobBoard/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // GET: /JobBoard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /JobBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobListing job)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }

            await _jobRepository.AddJobAsync(job);
            return RedirectToAction(nameof(Index));
        }

        // GET: /JobBoard/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: /JobBoard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobListing job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(job);
            }

            await _jobRepository.UpdateJobAsync(job);
            return RedirectToAction(nameof(Index));
        }

        // GET: /JobBoard/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: /JobBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobRepository.DeleteJobAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
