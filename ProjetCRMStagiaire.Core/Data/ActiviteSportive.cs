using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Data
{
    public class ActiviteSportive
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Nom { get; set; }

        [StringLength(225)]
        public string Description { get; set; }

        public int NombreDePlace { get; set; }
    }
}