using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjetCRMStagiaire.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>().
            //    Property(e => e.Nom).IsRequired();   
        }

        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<ActiviteSportive> ActiviteSportives { get; set; }
    }
}