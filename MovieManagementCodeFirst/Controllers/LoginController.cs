using MovieManagementCodeFirst.DAL;
using MovieManagementCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieManagementCodeFirst.Controllers
{
    public class LoginController : Controller
    {
        private MovieDBContext db = new MovieDBContext();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(Customer cus)
        {
            var user = db.Accounts.Where(ac => ac.UserName == cus.Account.UserName && ac.Password == cus.Account.Password).FirstOrDefault();
            if (user != null)
            {
                Session["UserID"] = user.ID;
                Session["UserName"] = user.UserName;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "User or Password is not correct");
            }
            return View("Index");
        }
	}
}