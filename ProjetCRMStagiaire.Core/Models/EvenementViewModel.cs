using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Models
{
    public class EvenementViewModel
    {
        public int EvenementId { get; set; }

        [Required]
        public int ActiviteSportiveId { get; set; }


        [Required]
        public DateTime DateEvenement { get; set; }
    }
}
