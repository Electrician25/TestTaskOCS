using Microsoft.EntityFrameworkCore;
using TestTaskOCS.Entities;

namespace TestTaskOCS.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<MeetingRequest> MeetingRequests { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        { Database.EnsureCreated(); AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}