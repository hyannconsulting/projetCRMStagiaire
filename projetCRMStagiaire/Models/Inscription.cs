using System;
using System.ComponentModel.DataAnnotations;

namespace projetCRMStagiaire.Models
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdActiviteSportive { get; set; }

        [Required]
        public ApplicationUser Stagiaire { get; set; }
        public DateTime DateInscription { get; set; }

    }
}