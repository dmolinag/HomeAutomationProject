using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomoticProject.Model;

namespace DomoticProject.Controllers.DTO
{
    public class UserDto
    {
        public UserDto(User register)
        {
            this.UserID = register.UserID;
            this.Username = register.Username;
            this.Password = register.Password;
            this.Name = register.Name;
            this.Lastname = register.Lastname;
            this.Email = register.Email;
            this.PasswordRetries = register.PasswordRetries;
            this.IsActive = register.IsActive;
            this.IsDeleted = register.IsDeleted;
            this.Salt = register.Salt;
            this.LastLoginDate = register.LastLoginDate;
        }

        public Int32 UserID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public Int32 PasswordRetries { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public String Salt { get; set; }
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// Convert the DTO to the entity. First obtain the register from db, then pass it as argumment, if is a new register, registerFromDB must be null
        /// </summary>
        /// <param name="registerFromDB">The register from database.</param>
        /// <returns></returns>
        /// Version: SPI V5G
        /// Author: Felipe Botero
        public User ToEntity(User registerFromDB)
        {
            User retVal;

            if (registerFromDB == null)
            {
                retVal = new User();
            }
            else
            {
                retVal = registerFromDB;
            }


            retVal.UserID = this.UserID;
            retVal.Username = this.Username;
            retVal.Password = this.Password;
            retVal.Name = this.Name;
            retVal.Lastname = this.Lastname;
            retVal.PasswordRetries = this.PasswordRetries;
            retVal.IsActive = this.IsActive;
            retVal.IsDeleted = this.IsDeleted;
            retVal.Salt = this.Salt;
            retVal.LastLoginDate = this.LastLoginDate;

            return retVal;
        }
    }
}

