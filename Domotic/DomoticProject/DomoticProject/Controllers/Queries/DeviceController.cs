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

        public static List<GetDeviceByRoomIdAndDeviceID_Result> GetDeviceByRoomIdAndDeviceId(int roomId, int deviceId)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                List<GetDeviceByRoomIdAndDeviceID_Result> resultList = new List<GetDeviceByRoomIdAndDeviceID_Result>();
                resultList = context.GetDeviceByRoomIdAndDeviceID(roomId, deviceId).ToList();
                return resultList;
            }
        }


        public static RoomDevice GetRoomDeviceByRoomIdAndDeviceId(int roomId, int deviceId)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                RoomDevice result = new RoomDevice();
                result = context.RoomDevice.FirstOrDefault(c => c.RoomID == roomId && c.DeviceID == deviceId);
                return result;
            }

        }

        public static int UpdateRoomDevice(RoomDevice reg)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                context.RoomDevice.Attach(reg);
                context.Entry(reg).State = EntityState.Modified;
                int result = context.SaveChanges();
                return result;
            }
        }


        public static List<GetDeviceOnTimeByRoomIdAndDeviceID_Result> GetDeviceOnTimeByRoomIdAndDeviceId(int roomId, int deviceId)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                List<GetDeviceOnTimeByRoomIdAndDeviceID_Result> resultList = new List<GetDeviceOnTimeByRoomIdAndDeviceID_Result>();
                resultList = context.GetDeviceOnTimeByRoomIdAndDeviceID(roomId, deviceId).ToList();
                return resultList;
            }
        }

        public static int AddRoomDeviceTimeOn(DeviceOnTime reg)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                context.DeviceOnTime.Add(reg);
                int result = context.SaveChanges();
                return result;
            }
        }

        public static int UpdateRoomDeviceTimeOn(DeviceOnTime reg)
        {
            using (HomeAutomationEntities context = new HomeAutomationEntities())
            {
                context.DeviceOnTime.Attach(reg);
                context.Entry(reg).State = EntityState.Modified;
                int result = context.SaveChanges();
                return result;
            }
        }
    }
}
