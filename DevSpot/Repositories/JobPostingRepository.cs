
using DevSpot.Data;
using DevSpot.Models;

namespace DevSpot.Repositories
{
    public class JobPostingRepository : IRepository<JobPosting>
    {
        private readonly ApplicationDbContext _context;
        public JobPostingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(JobPosting entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobPosting>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JobPosting> GetByIdAsinc(int id)
        {
            throw new NotImplementedException();
        }

        public Task Updateasync(JobPosting entity)
        {
            throw new NotImplementedException();
        }
    }
}
