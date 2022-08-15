using Microsoft.AspNetCore.Identity;

namespace ProjetCRMStagiaire.Core.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Section { get; set; }
    }
}
