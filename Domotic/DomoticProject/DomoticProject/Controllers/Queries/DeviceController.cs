using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomoticProject.Model;
using System.Data.Entity;

namespace DomoticProject.Controllers.Queries
{
    class DeviceController
    {
        public static List<GetDevicesByRoomId_Result> GetDevicesByRoomId(int roomId)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                List<GetDevicesByRoomId_Result> resultList = new List<GetDevicesByRoomId_Result>();
                resultList = context.GetDevicesByRoomId(roomId).ToList();
                return resultList;
            }
        }
    }
}
