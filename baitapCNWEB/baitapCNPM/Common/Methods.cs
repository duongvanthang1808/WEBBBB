using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using baitapCNPM.Models;
using System.Web.Mvc;
namespace baitapCNPM.Common
{
    public class Methods
    {
        private shopDBModel data = new shopDBModel();
        public product GetProductByID(int id)
        {
            return data.products.Where(p => p.productID == id).FirstOrDefault();
        }
        public product GetProductByCat(int id, int cat)
        {
            return data.products.Where(p => p.productID == id && p.categoryID == cat).FirstOrDefault();
        }
        public List<product> GetProductByCat(int cat)
        {
            return data.products.Where(p => p.categoryID == cat).ToList<product>();
        }
        public order GetOrderByID(int id)
        {
            return data.orders.Where(o => o.orderID == id).FirstOrDefault();
        }
        //Product modification
        public void addProduct(product product)
        {
            if((product!=null)&&!(data.products.Contains(product)))
            { 
                data.products.Add(product);
                data.SaveChanges();
            }
        }
        public void deleteProduct(int id)
        {
            if (data.products.Any(p=>p.productID==id))
            {
                data.products.Remove(this.GetProductByID(id));
                data.SaveChanges();
            }
        }
        //order modification
        public void addOrderSource(order order)
        {
            if((order!=null)&&!(data.orders.Contains(order)))
            { 
                data.orders.Add(order);
                data.SaveChanges();
            }
        }
        public void deleteOrderSource(int id)
        {
            if (data.orders.Any(p => p.orderID == id))
            {
                data.orders.Remove(this.GetOrderByID(id));
                data.SaveChanges();
            }
        }
        public List<List<product>> GetProductsToShow(List<product> products,int range,int quanity)
        {
            List<List<product>> list = new List<List<product>>();
            for (int i = 0; i < products.Count; i = i + quanity)
            {
                int j = i;
                List<product> tmp = new List<product>();
                while (((j - i) <= (quanity-1)) && (j < products.Count))
                {
                    tmp.Add(products[j]);
                    j++;
                }
                list.Add(tmp);
            }
            return list;
        }
        //shop cart
        public bool IsOrderExsist(product_odered product)
        {
            if (HttpContext.Current.Session["product_ordered"] == null) return false;
            else
            {
                List<Models.product_odered> products = (List<Models.product_odered>)HttpContext.Current.Session["product_ordered"];
                return (products.Any(p => p.productID == product.productID && p.Size == product.Size && p.Color == product.Color));
            }
        }
        public void addtoViewLater(int productID)
        {
            var product = data.products.Find(productID);
            if (product != null)
            {
                if (HttpContext.Current.Session["product_viewlater"] == null)
                {
                    var newlist = new List<product>();
                    newlist.Add(product);
                    HttpContext.Current.Session["product_viewlater"] = newlist;
                }
                else
                {
                    List<Models.product> products = (List<Models.product>)HttpContext.Current.Session["product_viewlater"];
                    if (!products.Any(p => p.productID == productID))
                    {
                        products.Add(product);
                        HttpContext.Current.Session["product_viewlater"] = products;
                    }
                }
            }
        }
        public void addtoCart(product_odered producttoAdd)
        {
            if(producttoAdd!=null)
            {
                if(HttpContext.Current.Session["product_ordered"] == null)
                {
                   var newlist = new List<product_odered>();
                   newlist.Add(producttoAdd);
                   HttpContext.Current.Session["product_ordered"] = newlist;
                }
                else
                {
                    List<Models.product_odered> products = (List<Models.product_odered>)HttpContext.Current.Session["product_ordered"];
                    if(this.IsOrderExsist(producttoAdd))
                    {
                        var oldproduct=products.Where(p=>p.productID==producttoAdd.productID).FirstOrDefault();
                        producttoAdd.Quanity += oldproduct.Quanity;
                        products.Remove(oldproduct);
                        products.Add(producttoAdd);
                    }
                    else
                    {     
                    products.Add(producttoAdd);
                    HttpContext.Current.Session["product_ordered"] = products;
                    }
                }
            }
        }
        public void removefromCart(product_odered producttoRemove)
        {
            List<Models.product_odered> products = (List<Models.product_odered>)HttpContext.Current.Session["product_ordered"];
            try
            {
                products.Remove(producttoRemove);
                HttpContext.Current.Session["product_ordered"] = products;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
        public int getPages(int quanity, int number)
        {
            if(quanity%number==0)
            {
                return quanity / number;
            }
            else
            {
                return quanity / number + 1;
            }
        }
    }
}