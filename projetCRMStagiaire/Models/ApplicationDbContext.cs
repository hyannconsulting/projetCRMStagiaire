using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace projetCRMStagiaire.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<ActiviteSportive> ActiviteSportives { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}