using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Data
{
    public class ActiviteSportive
    {
        public int ActiviteSportiveId { get; set; }

        [Required]
        [StringLength(128)]
        public string Nom { get; set; }

        [StringLength(225)]
        public string Description { get; set; }

        [Display(Name = "Nb de place")]
        public int NombreDePlace { get; set; }

        public string Lieu { get; set; }
    }
}