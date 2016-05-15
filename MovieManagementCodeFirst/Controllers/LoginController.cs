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
            if (checkLogin())
            {
                return RedirectToAction("Register", "Login", new { area = ""});
            }
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(Account loginAccount, string url)
        {
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
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult PostRegister(Customer customer)
        {
            var acc = db.Customers.Where(cus => cus.Account.UserName == customer.Account.UserName
            && cus.Account.Password == customer.Account.Password).FirstOrDefault();
            if (acc == null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("CheckLogin", new { loginAccount = customer.Account});
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove(Session["UserID"].ToString());
            return View();
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