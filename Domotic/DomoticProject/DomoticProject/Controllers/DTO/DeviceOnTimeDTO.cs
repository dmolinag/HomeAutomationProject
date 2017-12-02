using DomoticProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomoticProject.Controllers.DTO
{
    public class DeviceOnTimeDTO
    {
        public DeviceOnTimeDTO(DeviceOnTime register)
        {
            this.RoomDeviceID = register.RoomID;
            this.RoomID = register.RoomID;
            this.OnTime = register.OnTime;
            this.OffTime = register.OffTime;
            this.OnTimeDuration = register.OnTimeDuration;
            this.OnUserID = register.OnUserID;
            this.OffUserID = register.OffUserID;

        }

        public int RoomDeviceID { get; set; }
        public int RoomID { get; set; }
        public DateTime OnTime { get; set; }
        public DateTime? OffTime { get; set; }
        public decimal? OnTimeDuration { get; set; }
        public int? OnUserID { get; set; }
        public int? OffUserID { get; set; }
    }
}
