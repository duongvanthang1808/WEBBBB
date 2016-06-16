using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapCNPM.Models;

namespace baitapCNPM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private shopDBModel data = new shopDBModel();
        private Common.Methods method = new Common.Methods();
        public ActionResult Index()
        {
            ViewBag.accessories = data.products.Where(p => p.categoryID == 3).OrderByDescending(p => p.productID).Take(4);
            ViewBag.pants = data.products.Where(p => p.categoryID == 2).OrderByDescending(p => p.productID).Take(4);
            ViewBag.shirts = data.products.Where(p => p.categoryID == 1).OrderByDescending(p => p.productID).Take(4);
            return View();
        }
        public ActionResult ViewProduct(int cat, int page, int order, int price)
        {
            var products = new List<product>();
            if (data.categories.Any(c => c.categoryID == cat))
            {
                products = data.products.Where(p => p.categoryID == cat).ToList<product>();
            }
            else if (cat == 0) products = data.products.ToList<product>();
            else products = null;
            if (products != null)
            {
                var quanity = 0;
                if (order == 1)
                {
                    quanity = products.Where(p => p.price < price).OrderByDescending(p => p.price).Count();
                    ViewBag.Pages = method.getPages(quanity, 9);
                    return View(products.Where(p => p.price < price).OrderByDescending(p => p.price).Skip(Math.Max(0, (9 * page - 9))).Take(9));
                }
                else if (order == 2)
                {
                    quanity = products.Where(p => p.price < price).OrderBy(p => p.price).Count();
                    ViewBag.Pages = method.getPages(quanity, 9);
                    return View(products.Where(p => p.price < price).OrderBy(p => p.price).Skip(Math.Max(0, (9 * page - 9))).Take(9));
                }
                else
                {
                    quanity = products.Where(p => p.price < price).OrderByDescending(p => p.productID).Count();
                    ViewBag.Pages = method.getPages(quanity, 9);
                    return View(products.Where(p => p.price < price).OrderByDescending(p => p.productID).Skip(Math.Max(0, (9 * page - 9))).Take(9));
                }
            }
            else return View("Error");

        }
        public ActionResult Detail(int id)
        {
            if (data.products.Any(p => p.productID == id))
            {
                var productSelected = data.products.Find(id);
                return View(productSelected);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public void addOrder(int productID, string size, string colour, int quanity)
        {
            var productSelected = new product_odered();
            productSelected.productID = productID;
            productSelected.Size = size;
            productSelected.Color = colour;
            productSelected.Quanity = quanity;
            method.addtoCart(productSelected);
        }
        public ActionResult order()
        {
            if (Session["product_ordered"] != null)
            {
                var lists = (List<Models.product_odered>)Session["product_ordered"];
                return View(lists);
            }
            else { return View(new List<product_odered>()); }
        }
        [HttpPost]
        public ActionResult deleteOrder(int productID)
        {
            string messeage = "";
            var lists = (List<Models.product_odered>)Session["product_ordered"];
            try
            {
                if (lists.Any(p => p.productID == productID))
                {
                    var producttoRemove = lists.Where(p => p.productID == productID).FirstOrDefault();
                    method.removefromCart(producttoRemove);
                    messeage = "succeed";
                }
                else
                {
                    messeage = "This product is not in your cart!";
                }
                return Json(messeage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                messeage = "Error occurs";
                return Json(messeage, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult IsproductExsist(int id)
        {
            var lists = (List<Models.product_odered>)Session["product_ordered"];
            return (Json(lists.Any(p => p.productID == id), JsonRequestBehavior.AllowGet));
        }
    }
}