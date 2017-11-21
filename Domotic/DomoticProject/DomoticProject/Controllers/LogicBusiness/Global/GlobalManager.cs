using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomoticProject.Controllers.LogicBusiness.Global
{
    public class GlobalManager
    {
        private static GlobalManager instance;

        private GlobalManager() { }

        /// <summary>
        /// Singleton global manager stores all of the common variables and methods located along 
        /// the application.
        /// </summary>
        /// Author: Felipe Botero
        public static GlobalManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalManager();
                }
                return instance;
            }
        }

        // User data
        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Culture { get; set; }
        public DateTime LoginDate { get; set; }
        //Minimum and maximun db version that works with the app.
        public Version MinDatabaseVersion { get; set; }
        public Version MaxDatabaseVersion { get; set; }
        //List of permissions that are available for the user 
        public List<String> UserPermissions { get; set; }

    }
}
