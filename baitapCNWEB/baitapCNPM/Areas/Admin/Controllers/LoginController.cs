using baitapCNPM.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapCNPM.Models;

namespace baitapCNPM.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user user)
        {
            bool check = new LoginDao().CheckLogin(user.username, user.password);

            if (check && ModelState.IsValid)
            {
                Session[Common.SessionName.USER_SESSION] = user.username;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "Ten dang nhap hoac mat khau khong dung");
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session[Common.SessionName.USER_SESSION] = null;

            return RedirectToAction("Index","Login");
        }

    }
}
