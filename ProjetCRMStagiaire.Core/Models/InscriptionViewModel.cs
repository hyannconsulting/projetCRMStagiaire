using ProjetCRMStagiaire.Core.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Models
{
    public class InscriptionViewModel
    {
       
        public int EvenementId { get; set; }

        [Required]
        public int ActiviteSportiveId { get; set; }




        [Required]
        public DateTime DateEvenement { get; set; }


        //public ActiviteSportive ActiviteSportives { get; set; }

    }
}
