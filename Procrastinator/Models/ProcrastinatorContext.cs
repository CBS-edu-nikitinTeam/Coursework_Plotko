using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Procrastinator.Models
{
    public class ProcrastinatorContext : IdentityDbContext<User>
    {
        public ProcrastinatorContext(DbContextOptions<ProcrastinatorContext> options) : base(options)
        {

        }
    }
}
