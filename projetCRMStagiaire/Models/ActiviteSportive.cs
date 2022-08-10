using System.ComponentModel.DataAnnotations;

namespace projetCRMStagiaire.Models
{
    public class ActiviteSportive
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }

        [StringLength(225)]
        public string Description { get; set; }

    }
}