using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Models
{
    public class InscriptionViewModel
    {

        public int InscriptionId { get; set; }

        [Required]
        [Display(Name = "Activité sportive")]
        public int ActiviteSportiveId { get; set; }



        [Required]
        [Display(Name = "Stagiaire")]
        public string StagiaireId { get; set; }


        public DateTime DateInscription
        {
            get; set;
        }

    }
}
