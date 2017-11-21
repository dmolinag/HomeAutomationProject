using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomoticProject.Model;
using System.Data.Entity;

namespace DomoticProject.Controllers
{
    class UserController
    {
        public static List<User> ListByUsername(String username)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                List<User> resultList = new List<User>();
                resultList = context.User.Where(c => c.Username == username).ToList();
                return resultList;
            }
        }

        public static List<User> ListByEmail(String email)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                List<User> resultList = new List<User>();
                resultList = context.User.Where(c => c.Email == email).ToList();
                return resultList;
            }
        }


        public static User GetByUsername(String username)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                User resultList = new User();
                resultList = context.User.FirstOrDefault(c => c.Username == username);
                return resultList;
            }
        }

        public static User GetByEmail(String email)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                User resultList = new User();
                resultList = context.User.FirstOrDefault(c => c.Email == email);
                return resultList;
            }
        }


        /// <summary>
        /// Adds a User  register.
        /// </summary>
        /// <returns></returns>
        /// Version: SPI V5G
        /// Author: Felipe Botero
        public static int Add(User reg)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                context.User.Add(reg);
                int result = context.SaveChanges();
                return result;
            }
        }

        public static int Update(User reg)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                context.User.Attach(reg);
                context.Entry(reg).State = EntityState.Modified;
                int result = context.SaveChanges();
                return result;
            }
        }

        public static User PasswordRetries(string username)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                User resultsList = new User();
                resultsList = context.User.FirstOrDefault(c => c.Username == username);
                return resultsList;
            }
        }
    }
}
