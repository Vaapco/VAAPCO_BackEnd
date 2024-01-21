using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaapcoBE.DL.Entities;

namespace VaapcoBE.DL
{
    public class AppDbContext : IdentityDbContext<VaapcoUser>
    {
        public DbSet<NewsHeadline> NewsHeadlines { get; set; }
        public DbSet<UpcomingEvent> UpcomingEvents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsHeadline>()
                .HasKey("HId");
            base.OnModelCreating(modelBuilder);
        }
    }
}
