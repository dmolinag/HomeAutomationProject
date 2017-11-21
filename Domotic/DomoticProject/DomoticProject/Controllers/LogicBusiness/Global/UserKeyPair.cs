using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomoticProject.Controllers.LogicBusiness.Global
{
    public class UserKeyPair
    {
        public string Salt { get; set; }
        public string HashedPassword { get; set; }

        public UserKeyPair(string salt, string hashedPassword)
        {
            this.HashedPassword = hashedPassword;
            this.Salt = salt;
        }
    }
}
