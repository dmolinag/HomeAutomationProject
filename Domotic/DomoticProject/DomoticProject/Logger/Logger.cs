using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomoticProject.Logger
{
    class Logger
    {
        #region "Variables"
        //'The following class is has a singleton pattern
        private static Logger _UniqueInstance;
        //'We must have a logging element inside the class
        private static log4net.ILog Log = log4net.LogManager.GetLogger("BaseLogger");
        #endregion

        #region "Methods"
        private Logger()
        {
        }


        public static Logger GetInstance()
        {
            if (_UniqueInstance == null)
            {
                _UniqueInstance = new Logger();
            }
            return _UniqueInstance;
        }

        public static void Debug(string profile, string _message)
        {
            Log.Debug(profile + " : " + _message);
        }

        public static void Info(string profile, string _message)
        {
            Log.Info(profile + " : " + _message);
        }

        public static void Warn(string profile, string _message)
        {
            Log.Warn(profile + " : " + _message);
        }

        public static void ErrorL(string profile, string _message)
        {
            Log.Error(profile + " : " + _message);
        }

        public static void ErrorL(string profile, string _message, Exception ex)
        {
            Log.Error(profile + " : " + _message, ex);
        }

        #endregion
    }
}
