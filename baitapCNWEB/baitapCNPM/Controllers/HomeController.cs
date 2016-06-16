using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using baitapCNPM.Models;
using PagedList;
namespace baitapCNPM.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Shop/
        private shopDBModel data = new shopDBModel();
        private Common.Methods method = new Common.Methods();
        public ActionResult Index()
        {
           
            return View();
        }
       
        public ActionResult GetCart()
        {
            var lists = (List<Models.product_odered>)Session["product_ordered"];
            if (lists != null)
            {
                return PartialView("PartialShoppingCart", lists);
            }
            else
                return PartialView("PartialShoppingCart", new List<Models.product_odered>());
        }
    }
}
