using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Security;
using Cybersécu.Models;
using NLog;

namespace Cybersécu.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateAccount(LoginModel model)
        {
            var hashedPassword = Hash.HashPassword(model.Password);

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // Valider les données d'entrée (e.g. longueur minimale pour le mot de passe)
                if (!IsInputValid(model))
                {
                    ModelState.AddModelError("", "Les informations saisies sont incorrectes");
                    return View(model);
                }

                using (var db = new LoginContext())
                {
                    var user = new LoginModel
                    {
                        Username = model.Username,
                        Password = hashedPassword,
                        ConfirmPassword = hashedPassword,
                        Email = model.Email,
                        TermsAndConditions = model.TermsAndConditions
                    };

                    db.Login.Add(user);
                    db.SaveChanges();
                }

                WriteLog(model.Username);
                WriteLog(model.Email);
                WriteLog(hashedPassword);
                WriteLog(" ");
                

                return View(model);
            }

            catch (Exception ex)
            {
                // Logger l'exception
                // LogError(ex, model);

                // Afficher un message d'erreur générique
                ModelState.AddModelError("", "Une erreur est survenue");
                return View(model);
            }
        }

        private bool IsInputValid(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username))
            {
                ModelState.AddModelError("Username", "Le nom d'utilisateur est requis");
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("Email", "L'email est requis");
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("Password", "Le mot de passe est requis");
                return false;
            }

            if (model.Password.Length < 8)
            {
                ModelState.AddModelError("Password", "Le mot de passe doit avoir au moins 8 caractères");
                return false;
            }

            if (model.TermsAndConditions == false)
            {
                ModelState.AddModelError("TermsAndConditions", "Accepter les CD");
                return false;
            }
            
                return true;

        }

        private readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", DateTime.Now.ToString("yyyy-MM-dd") + ".log");



        private void WriteLog(string message)
        {
            using (var streamWriter = new StreamWriter(LogFilePath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}");
            }
        }


        public ActionResult CreateAccount()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

    }
}
