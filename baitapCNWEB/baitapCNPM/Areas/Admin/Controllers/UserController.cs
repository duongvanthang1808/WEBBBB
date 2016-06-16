using baitapCNPM.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapCNPM.Models;
namespace baitapCNPM.Areas.Admin.Controllers
{
    [Common.CustomAuthorize(Roles = "admin")]
    public class UserController : Controller
    {
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
            var model = new LoginDao().getUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                var temp = new LoginDao().Create(user);
                if (temp != 0)
                    return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new LoginDao().getUser(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(user user)
        {
            if (ModelState.IsValid)
            {
                var model = new LoginDao().Edit(user);

                if (model != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Edit");
        }

        public ActionResult Details(int id)
        {
            var model = new LoginDao().getUser(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new LoginDao().getUser(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(user user)
        {
            if (ModelState.IsValid)
            {
                var model = new LoginDao().Delete(user.userID);
                if (model != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Delete");
        }

    }
}
