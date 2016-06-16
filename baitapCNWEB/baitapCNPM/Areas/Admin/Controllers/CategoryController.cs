using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapCNPM.Areas.Admin.Models;
using baitapCNPM.Models;

namespace baitapCNPM.Areas.Admin.Controllers
{
    [Common.CustomAuthorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        //
        // GET: /Admin/Category/

        public ActionResult Index()
        {
            var model = new shopDBModel().categories;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(category cate)
        {
            if (ModelState.IsValid)
            {
                var temp = new CategoryDao().Creat(cate);
                if (temp != 0)
                    return RedirectToAction("Index");
            }
            return View(cate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new CategoryDao().getCategory(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(category cate)
        {
            int temp = 0;
            if (ModelState.IsValid)
            {
                temp = new CategoryDao().Edit(cate);

            }
            if (temp != 0)
                return RedirectToAction("Index");
            else return RedirectToAction("Edit");

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new CategoryDao().getCategory(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Details()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new CategoryDao().getCategory(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(category cate)
        {

            var x = new CategoryDao().Delete(cate.categoryID);
            if (x != 0)
            {
                return RedirectToAction("Index");
            }
            else

                return RedirectToAction("Delete");
        }

    }
}
