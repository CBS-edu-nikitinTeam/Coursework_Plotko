using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Procrastinator.Models
{
    public class ProcrastinatorContext : IdentityDbContext<User>
    {
        public DbSet<GymVisitor> GymVisitors { get; set; }
        public DbSet<GymCoach> GymCoaches { get; set; }
        public ProcrastinatorContext(DbContextOptions<ProcrastinatorContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

            
    
    }
}
