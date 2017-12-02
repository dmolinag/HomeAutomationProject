using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomoticProject.Model;

namespace DomoticProject.Controllers.DTO
{
    public class DeviceDTO
    {
        public DeviceDTO(RoomDevice register)
        {
            this.RoomDeviceID = register.RoomID;
            this.RoomID = register.RoomID;
            this.DeviceID = register.DeviceID;
            this.StateID = register.StateID;
            this.Value = register.Value;
            this.UnitID = register.UnitID;
        }

        public int RoomDeviceID { get; set; }
        public int RoomID { get; set; }
        public int DeviceID { get; set; }
        public int StateID { get; set; }
        public int? Value { get; set; }
        public int? UnitID { get; set; }
    }
}
