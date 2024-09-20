
using DevSpot.Data;
using DevSpot.Models;
using Microsoft.EntityFrameworkCore;

namespace DevSpot.Repositories
{
    public class JobPostingRepository : IRepository<JobPosting>
    {
        private readonly ApplicationDbContext _context;
        public JobPostingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(JobPosting entity)
        {
            await _context.JobPosts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var jobPosting = await _context.JobPosts.FindAsync(id);

            if (jobPosting == null)
            {
                throw new KeyNotFoundException();
            }

            _context.JobPosts.Remove(jobPosting);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobPosting>> GetAllAsync()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<JobPosting> GetByIdAsinc(int id)
        {
            var jobPosting = await _context.JobPosts.FindAsync(id);

            if (jobPosting == null)
            {
                throw new KeyNotFoundException();
            }
            
            return jobPosting;

        }

        public async Task Updateasync(JobPosting entity)
        {
             _context.JobPosts.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
