using projetCRMStagiaire.Models;
using projetCRMStagiaire.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace projetCRMStagiaire.Controllers
{
    public class InscriptionController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public InscriptionController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Inscription
        public ActionResult Create()
        {
            var viewModel = new InscriptionViewModel
            {

                ActiviteSportives = _dbContext.ActiviteSportives.ToList(),
                Stagiaires = _dbContext.Users.ToList()
            };


            return View(viewModel);
        }
    }
}