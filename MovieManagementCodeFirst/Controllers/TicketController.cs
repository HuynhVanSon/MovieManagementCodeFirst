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
    public class TicketController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: /Ticket/
        public async Task<ActionResult> Index()
        {
            var tickets = db.Tickets.Include(t => t.Film).Include(t => t.TicketType);
            return View(await tickets.ToListAsync());
        }

        // GET: /Ticket/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: /Ticket/Create
        public ActionResult Create()
        {
            ViewBag.FilmID = new SelectList(db.Films, "ID", "Name");
            ViewBag.TicketTypeID = new SelectList(db.TicketTypes, "ID", "Name");
            return View();
        }

        // POST: /Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,FilmID,TicketTypeID,Price,Quantity,StartHours,EndHours")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FilmID = new SelectList(db.Films, "ID", "Name", ticket.FilmID);
            ViewBag.TicketTypeID = new SelectList(db.TicketTypes, "ID", "Name", ticket.TicketTypeID);
            return View(ticket);
        }

        // GET: /Ticket/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmID = new SelectList(db.Films, "ID", "Name", ticket.FilmID);
            ViewBag.TicketTypeID = new SelectList(db.TicketTypes, "ID", "Name", ticket.TicketTypeID);
            return View(ticket);
        }

        // POST: /Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,FilmID,TicketTypeID,Price,Quantity,StartHours,EndHours")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FilmID = new SelectList(db.Films, "ID", "Name", ticket.FilmID);
            ViewBag.TicketTypeID = new SelectList(db.TicketTypes, "ID", "Name", ticket.TicketTypeID);
            return View(ticket);
        }

        // GET: /Ticket/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: /Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ticket ticket = await db.Tickets.FindAsync(id);
            db.Tickets.Remove(ticket);
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
