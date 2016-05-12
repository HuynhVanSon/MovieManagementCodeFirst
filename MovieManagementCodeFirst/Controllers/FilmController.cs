using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieManagementCodeFirst.Models;
using MovieManagementCodeFirst.DAL;

namespace MovieManagementCodeFirst.Controllers
{
    public class FilmController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: /Film/
        public async Task<ActionResult> Index()
        {
            var films = db.Films.Include(f => f.FilmType);
            return View(await films.ToListAsync());
        }

        // GET: /Film/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: /Film/Create
        public ActionResult Create()
        {
            ViewBag.FilmTypeID = new SelectList(db.FilmTypes, "ID", "Name");
            return View();
        }

        // POST: /Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,FilmTypeID,Name,Director,Description")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FilmTypeID = new SelectList(db.FilmTypes, "ID", "Name", film.FilmTypeID);
            return View(film);
        }

        // GET: /Film/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmTypeID = new SelectList(db.FilmTypes, "ID", "Name", film.FilmTypeID);
            return View(film);
        }

        // POST: /Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,FilmTypeID,Name,Director,Description")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FilmTypeID = new SelectList(db.FilmTypes, "ID", "Name", film.FilmTypeID);
            return View(film);
        }

        // GET: /Film/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: /Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Film film = await db.Films.FindAsync(id);
            db.Films.Remove(film);
            await db.SaveChangesAsync();
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
    }
}
