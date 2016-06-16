using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using baitapCNPM.Models;
using PagedList;

namespace baitapCNPM.Areas.Admin.Models
{
    public class ProductDao
    {
        shopDBModel context = null;

        public ProductDao()
        {
            context = new shopDBModel();
        }
        public IEnumerable<product> getAllProduct(int page, int pagesize)
        {
            return context.products.OrderByDescending(x => x.productID).ToPagedList(page, pagesize);

        }
        public product getDeital(int id)
        {
            return context.products.Where(m => m.productID == id).FirstOrDefault();
        }
        public int Create(product product)
        {
            var temp = context.products.Find(product.productID);

            if (temp == null)
            {
                context.products.Add(product);
                context.SaveChanges();
                return product.productID;
            }
            return 0;
        }
        public int Edit(product product, HttpPostedFileBase Image)
        {
            var temp = context.products.Find(product.productID);
            if (temp != null)
            {
                temp.productID = product.productID;
                temp.productName = product.productName;
                temp.price = product.price;
                temp.colors = product.colors;
                temp.sizes = product.sizes;
                temp.categoryID = product.categoryID;
                temp.dateCreated = product.dateCreated;
                temp.status = product.status;
                temp.quanity = product.quanity;

                if (Image != null)
                {
                    temp.productImage = product.productImage;
                }

                context.SaveChanges();
            }
            return temp.productID;
        }
        public int Delete(int id)
        {
            var pro = context.products.Find(id);
            if (pro != null)
            {
                context.products.Remove(pro);
                context.SaveChanges();

                return pro.productID;
            }
            return 0;
        }
    }
}