using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Movies.Models;

namespace Movies_App.Controleur
{
    public class MoviesController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movie.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesModel moviesModel = db.Movie.Find(id);
            if (moviesModel == null)
            {
                return HttpNotFound();
            }
            return View(moviesModel);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,DateSortieFormat,ImageUrl")] MoviesModel moviesModel)
        {
            if (ModelState.IsValid)
            {
                db.Movie.Add(moviesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviesModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesModel moviesModel = db.Movie.Find(id);
            if (moviesModel == null)
            {
                return HttpNotFound();
            }
            return View(moviesModel);
        }

        // POST: Movies/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,DateSortieFormat,ImageUrl")] MoviesModel moviesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviesModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesModel moviesModel = db.Movie.Find(id);
            if (moviesModel == null)
            {
                return HttpNotFound();
            }
            return View(moviesModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviesModel moviesModel = db.Movie.Find(id);
            db.Movie.Remove(moviesModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult UploadImage(string imageUrl, int filmId)
        {
            // Enregistrer l'URL de l'image dans la base de données
            using (var context = new MoviesContext())
            {
                var film = context.Movie.Find(filmId);
                film.ImageUrl = imageUrl;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }


}

