using Microsoft.EntityFrameworkCore;
using TestTaskOCS.Entities;

namespace TestTaskOCS.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<MeetingRequest> MeetingRequests { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}