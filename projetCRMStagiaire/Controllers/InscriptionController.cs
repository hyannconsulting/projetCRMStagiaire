using Microsoft.AspNet.Identity;
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

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new InscriptionViewModel
            {

                ActiviteSportives = _dbContext.ActiviteSportives.ToList(),
                Stagiaires = _dbContext.Users.ToList()
            };


            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(InscriptionViewModel viewModel)
        {
            var userid = User.Identity.GetUserId();
            var user = _dbContext.Users.SingleOrDefault(a => a.Id == userid);
            var inscpt = new Inscription
            {
                IdActiviteSportive = viewModel.IdActiviteSportive,
                DateInscription = System.DateTime.Now,
                //  Stagiaire = user,
                StagiaireId = userid,

            };

            _dbContext.Inscriptions.Add(inscpt);
            _dbContext.SaveChanges();


            return RedirectToAction("index", "home");

        }
    }
}