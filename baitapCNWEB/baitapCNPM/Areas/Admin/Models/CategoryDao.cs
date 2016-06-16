using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using baitapCNPM.Models;

namespace baitapCNPM.Areas.Admin.Models
{
    public class CategoryDao
    {
        shopDBModel context = null;
        public CategoryDao()
        {
            context = new shopDBModel();
        }
        public IEnumerable<category> getAllCategory()
        {
            return context.categories;
        }
        public category getCategory(int id)
        {
            return context.categories.Where(m => m.categoryID == id).FirstOrDefault();
        }
        public int Creat(category cate)
        {
            var temp = context.categories.Find(cate.categoryID);
            if (temp == null)
            {
                context.categories.Add(cate);
                context.SaveChanges();

                return cate.categoryID;
            }
            return 0;
        }
        public int Delete(int id)
        {
            var cate = context.categories.Find(id);
            if (cate != null)
            {
                context.categories.Remove(cate);
                context.SaveChanges();

                return cate.categoryID;
            }
            return 0;

        }
        public int Edit(category cate)
        {
            var temp = context.categories.Find(cate.categoryID);
            if (temp != null)
            {
                temp.categoryID = cate.categoryID;
                temp.categoryName = cate.categoryName;

                context.SaveChanges();
            }
            return temp.categoryID;
        }
    }
}