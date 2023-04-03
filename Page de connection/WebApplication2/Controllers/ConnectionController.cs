using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class ConnectionController : Controller
    {
        // GET: /Connection/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        { 
            if(ModelState.IsValid)
			{
                //if(model.Utilisateur == "Jeremy" && model.Motdepasse == "P@ssw0rd") // Simule la collecte de données de utilisateur et mot de passe
                if(DataAccess.DAL.Utilisateur_Valide(model.Utilisateur, model.Motdepasse))
				{
                    FormsAuthentication.SetAuthCookie(model.Utilisateur, true);
                    return RedirectToAction("index", "Accueil");
				}
                else
				{
                    ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe invalide");
				}
			}

            return View();
        }

    }
}