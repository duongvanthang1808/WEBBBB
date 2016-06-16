using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using baitapCNPM.Models;
using System.Web.Mvc;
namespace baitapCNPM.Models
{
    public class product_odered
    {
        private int productid;
        public int productID
        {
            get { return this.productid; }
            set { productid = value; }
        }
        private string color;
        public string Color 
        {
            get { return this.color; }
            set { color = value; }
        }
        private string size;
        public string Size
        {
            get { return this.size; }
            set { size = value; }
        }
        private int quanity;
        public int Quanity
        {
            get { return this.quanity; }
            set { quanity = value; }
        }
    }
}