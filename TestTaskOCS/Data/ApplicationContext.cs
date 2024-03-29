using Microsoft.EntityFrameworkCore;
using TestTaskOCS.Entities;

namespace TestTaskOCS.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<MeetingRequest> Requests { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        { Database.EnsureCreated(); }
    }
}