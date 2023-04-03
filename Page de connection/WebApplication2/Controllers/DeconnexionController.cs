using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class DeconnexionController : Controller
    {
        // GET: Deconnexion
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}