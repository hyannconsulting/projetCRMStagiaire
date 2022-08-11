using projetCRMStagiaire.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projetCRMStagiaire.ViewModels
{

    public class InscriptionViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Activité sportive")]
        public int IdActiviteSportive { get; set; }

        // public string ActiviteSportive { get; set; }
        public IEnumerable<ActiviteSportive> ActiviteSportives { get; set; }

        [Display(Name = "Stagiaire")]
        public string IdUser { get; set; }
        public IEnumerable<ApplicationUser> Stagiaires { get; set; }
        public DateTime DateInscription { get; set; }

    }
}