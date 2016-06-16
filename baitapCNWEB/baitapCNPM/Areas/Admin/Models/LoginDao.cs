
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using baitapCNPM.Models;

namespace baitapCNPM.Areas.Admin.Models
{
    public class LoginDao
    {
        shopDBModel context = null;

        public LoginDao()
        {
            context = new shopDBModel();
        }

        public bool CheckLogin(string username, string password)
        {
            var user = context.users.Where(m => (m.username == username) && (m.password == password)).FirstOrDefault();
            if (user != null)
                return true;
            else return false;
        }
        public List<user> getUsers()
        {
            return context.users.ToList();
        }
        public user getUser(int id)
        {
            return context.users.Where(m => m.userID == id).FirstOrDefault();
        }
        public int Create(user user)
        {
            var temp = context.users.Find(user.userID);
            if (temp == null)
            {
                context.users.Add(user);
                context.SaveChanges();

                return user.userID;
            }
            return 0;
        }
        public int Edit(user user)
        {
            var temp = context.users.Find(user.userID);
            if (temp != null)
            {
                temp.userID = user.userID;
                temp.username = user.username;
                temp.password = user.password;
                temp.role_id = user.role_id;
                temp.lineAddress = user.lineAddress;
                temp.phonenumber = user.phonenumber;
                temp.name = user.name;

                context.SaveChanges();
            }
            return temp.userID;
        }
        public int Delete(int id)
        {
            var user = context.users.Find(id);
            if (user != null)
            {
                context.users.Remove(user);
                context.SaveChanges();

                return user.userID;
            }
            return 0;

        }
    }
}