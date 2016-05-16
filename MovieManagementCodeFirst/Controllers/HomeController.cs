using MovieManagementCodeFirst.DAL;
using MovieManagementCodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MovieManagementCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        MovieDBContext db = new MovieDBContext();

        public ActionResult Index()
        {
            checkLogin();
            List<Film> listFilm = db.Films.ToList();
            listFilm.Reverse();
            return View(listFilm);
        }

        public ActionResult FilmType(int id)
        {
            checkLogin();

            FilmType filmType = db.FilmTypes.Where(ft => ft.ID == id).SingleOrDefault();
            ViewBag.FilmType = filmType.Name;


            List<Film> listFilm = filmType.Films.ToList(); ;
            listFilm.Reverse();
            return View(listFilm);
        }

        public ActionResult Schedule()
        {
            checkLogin();
            List<Film> listFilm = db.Films.ToList();
            listFilm.Reverse();
            listFilm.Take(20).ToList();
            return View(listFilm);
        }
        
        [NonAction]
        public bool checkLogin()
        {
            if (Session["UserID"] == null)
            {
                ViewBag.adminDisplay = "none";
                ViewBag.loginDisplay = "block";
                ViewBag.accountDisplay = "";
                return false;
            }
            Account account = db.Accounts.Where(ac => ac.ID == (int)Session["UserID"]).FirstOrDefault();
            if (account != null)
            {
                ViewBag.loginDisplay = "none";
                ViewBag.accountDisplay = account.Customer.Name;
                if (account.Role == 1)
                {
                    ViewBag.adminDisplay = "block";
                }
                else
                {
                    ViewBag.adminDisplay = "none";
                }
                return true;
            }
            return false;
        }
    }
}