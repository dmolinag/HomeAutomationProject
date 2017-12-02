using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomoticProject.Model;

namespace DomoticProject.Controllers.DTO
{
    public class DevicesDTO
    {
        public DevicesDTO(GetDevicesByRoomId_Result register)
        {
            this.RoomName = register.RoomName;
            this.RoomDescription = register.RoomDescription;
            this.DeviceId = register.DeviceID;
            this.Device = register.Device;
            this.State = register.State;
            this.Value = register.Value;
            this.Unit = register.Unit;
            this.OnTime = register.OnTime;
        }

        public DevicesDTO(GetDeviceByRoomIdAndDeviceID_Result register)
        {
            this.RoomName = register.RoomName;
            this.RoomDescription = register.RoomDescription;
            this.DeviceId = register.DeviceID;
            this.Device = register.Device;
            this.State = register.State;
            this.Value = register.Value;
            this.Unit = register.Unit;
            this.OnTime = register.OnTime;
        }

        public String RoomName { get; set; }
        public String RoomDescription { get; set; }
        public String Device { get; set; }
        public int? DeviceId { get; set; }
        public Boolean State { get; set; }
        public int? Value { get; set; }
        public String Unit { get; set; }
        public DateTime? OnTime { get; set; }


        ///// <summary>
        ///// Convert the DTO to the entity. First obtain the register from db, then pass it as argumment, if is a new register, registerFromDB must be null
        ///// </summary>
        ///// <param name="registerFromDB">The register from database.</param>
        ///// <returns></returns>
        ///// Version: SPI V5G
        ///// Author: Felipe Botero
        //public User ToEntity(User registerFromDB)
        //{
        //    User retVal;

        //    if (registerFromDB == null)
        //    {
        //        retVal = new User();
        //    }
        //    else
        //    {
        //        retVal = registerFromDB;
        //    }


        //    retVal.UserID = this.UserID;
        //    retVal.Username = this.Username;
        //    retVal.Password = this.Password;
        //    retVal.Name = this.Name;
        //    retVal.Lastname = this.Lastname;
        //    retVal.PasswordRetries = this.PasswordRetries;
        //    retVal.IsActive = this.IsActive;
        //    retVal.IsDeleted = this.IsDeleted;
        //    retVal.Salt = this.Salt;
        //    retVal.LastLoginDate = this.LastLoginDate;

        //    return retVal;
        //}
    }
}
