using BugSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BugSystem.Data
{
    public class BugsContext : DbContext
    {
        public DbSet<BugModel> Bugs { get; set; }

        public BugsContext(DbContextOptions
            <BugsContext> options) : base(options)
        {

        }
    }
}
