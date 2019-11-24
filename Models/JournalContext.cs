using Microsoft.EntityFrameworkCore;

namespace Dentistry_therapy_department.Models
{
    public class JournalContext : DbContext
    {
        public DbSet<Journal> Journal { get; set; }
        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}