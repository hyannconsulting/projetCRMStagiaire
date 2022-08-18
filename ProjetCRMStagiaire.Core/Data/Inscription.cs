using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Data
{
    public class Inscription
    {
        [Key]
        public int InscriptionId { get; set; }

        [Required]
        public int IdActiviteSportive { get; set; }

        public ActiviteSportive ActiviteSportive { get; set; }

        [Required]
        public string StagiaireId { get; set; }


        public ApplicationUser Stagiaire { get; set; }
        public DateTime DateInscription { get; set; }


      
    }
}