using MovieManagementCodeFirst.DAL;
using MovieManagementCodeFirst.Models;
using System.Linq;
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
            string url = (string)TempData["url"];
            
            if (checkLogin())
            {
                return Redirect(url);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(Account loginAccount)
        {
            Index();

            string url = (string)TempData["url"];

            var account = db.Accounts.Where(ac => ac.UserName == loginAccount.UserName
            && ac.Password == loginAccount.Password).FirstOrDefault();
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

        //
        // GET: /Register/
        public ActionResult Register()
        {
            if (checkLogin())
            {
                string url = (string)TempData["url"];
                return Redirect(url);
            }
            return View();
        }

        [HttpPost]
        public ActionResult PostRegister(Customer customer)
        {
            var acc = db.Customers.Where(cus => cus.Account.UserName == customer.Account.UserName
            && cus.Account.Password == customer.Account.Password).FirstOrDefault();
            if (acc == null && customer.Account.UserName != null && customer.Account.Password != null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                var account = db.Accounts.Where(ac => ac.UserName == customer.Account.UserName
                && ac.Password == customer.Account.Password).FirstOrDefault();
                    
                Session["UserID"] = account.ID;

                return this.RedirectToAction("Index");
            }
            return View("Register");
        }

        public ActionResult Logout()
        {
            Session.Remove(Session["UserID"].ToString());
            string url = (string)TempData["url"];
            return Redirect(url);
        }

        [NonAction]
        public bool checkLogin()
        {
            if (Session["UserID"] == null)
            {
                return false;
            }
            Account account = db.Accounts.Where(ac => ac.ID == (int)Session["UserID"]).FirstOrDefault();
            if (account != null)
            {
                return true;
            }
            return false;
        }
	}
}