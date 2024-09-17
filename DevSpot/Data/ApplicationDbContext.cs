using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevSpot.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContextDbC(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
            
        }
    }
}
