using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Data
{
    public class Evenements
    {
        [Key]
        public int EvenementId { get; set; }

        [Required]
        public int ActiviteSportiveId { get; set; }

        public ActiviteSportive ActiviteSportives { get; set; }

        [Required]
        public string DateEvenement { get; set; }
    }
}
