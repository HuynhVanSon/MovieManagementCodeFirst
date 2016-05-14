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
        public ActionResult Index(string? url)
        {
            string action = url.GetValueOrDefault();
            if (checkLogin() && action != null)
            {
                return Redirect(action);
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove(Session["UserID"].ToString());
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(Customer cus, string url)
        {
            var account = db.Accounts.Where(ac => ac.UserName == cus.Account.UserName && ac.Password == cus.Account.Password).FirstOrDefault();
            if (account != null)
            {
                Session["UserID"] = account.ID;
                return Redirect(url);
            }
            else
            {
                ModelState.AddModelError("", "User or Password is not correct");
            }
            return View("Index");
        }

        [NonAction]
        public bool checkLogin()
        {
            Account account = db.Accounts.Where(ac => ac.ID == (int)Session["UserID"]).FirstOrDefault();
            if (account != null)
            {
                return true;
            }
            return false;
        }
	}
}