﻿using System.ComponentModel.DataAnnotations;

namespace ProjetCRMStagiaire.Core.Data
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdActiviteSportive { get; set; }

        [Required]
     //   public ApplicationUser Stagiaire { get; set; }
        public DateTime DateInscription { get; set; }


        [Required]
        public string StagiaireId { get; set; }
    }
}