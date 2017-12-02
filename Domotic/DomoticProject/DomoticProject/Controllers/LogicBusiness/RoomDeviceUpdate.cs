using DomoticProject.Controllers.Queries;
using HomeAutomation.Response;
using System;
using System.Collections.Generic;
using DomoticProject.Model;
using DomoticProject.Controllers.DTO;
using DomoticProject.Controllers.LogicBusiness.Global;

namespace DomoticProject.Controllers.LogicBusiness
{
    class RoomDeviceUpdate
    {
        static String profileName = "(RoomDeviceUpdate)";

        /// <summary>
        /// Updates the device status.
        /// </summary>
        /// <param name="roomId">The room identifier.</param>
        /// <param name="selectedDeviceID">The selected device identifier.</param>
        /// <param name="buttonState">if set to <c>true</c> [button state].</param>
        /// <returns></returns>
        /// <Author> Daniel Molina </Author>
        /// <LastModification>  29/11/2017 - 16:20 </LastModification>
        /// <LastModificationBy> Daniel Molina </LastModificationBy>
        public static RoomDeviceResponse UpdateDeviceStatus(int roomId, int selectedDeviceID, bool buttonState)
        {
            try
            {
                //Validate the Device Status
                List<GetDeviceByRoomIdAndDeviceID_Result> lstDeviceByRoomIdAndDeviceId = DeviceController.GetDeviceByRoomIdAndDeviceId(roomId, selectedDeviceID);
                List<DevicesDTOPartial> retVal = new List<DevicesDTOPartial>();
                foreach (GetDeviceByRoomIdAndDeviceID_Result reg in lstDeviceByRoomIdAndDeviceId)
                {
                    retVal.Add(new DevicesDTOPartial(reg));
                }

                //Validate that the device State
                if (retVal[0].State == buttonState)
                {
                    Logger.Logger.Info(profileName, "Method Response: The device has the same status. Username:" + GlobalManager.Instance.Username);
                    return new RoomDeviceResponse { Code = (int)ResponseCode.Device_at_the_same_state, Message = ResponseCode.Device_at_the_same_state.ToString() };
                }

                int stateID;
                RoomDevice deviceByRoomIdAndDeviceId = DeviceController.GetRoomDeviceByRoomIdAndDeviceId(roomId, selectedDeviceID);
                DeviceOnTime deviceOnTimeDTO = new DeviceOnTime();

                //Change the device State and add a OnTimeDuration record with the actual On Time 
                if (retVal[0].StateId == 1)
                {
                    stateID = 2;
                    List<GetDeviceOnTimeByRoomIdAndDeviceID_Result> deviceOnTime = DeviceController.GetDeviceOnTimeByRoomIdAndDeviceId(roomId, selectedDeviceID);
                    deviceOnTimeDTO.DeviceOnTimeID = deviceOnTime[0].DeviceOnTimeID;
                    deviceOnTimeDTO.RoomID = deviceOnTime[0].RoomID;
                    deviceOnTimeDTO.DeviceID = deviceOnTime[0].DeviceID;
                    deviceOnTimeDTO.OnTime = deviceOnTime[0].OnTime;
                    deviceOnTimeDTO.OffTime = DateTime.Now;
                    System.TimeSpan? onDuration = deviceOnTimeDTO.OffTime - deviceOnTimeDTO.OnTime;
                    deviceOnTimeDTO.OnTimeDuration = Convert.ToDecimal(onDuration.Value.TotalMinutes);
                    deviceOnTimeDTO.OnUserID = deviceOnTime[0].OnUserID;
                    deviceOnTimeDTO.OffUserID = GlobalManager.Instance.UserId;
                    DeviceController.UpdateRoomDeviceTimeOn(deviceOnTimeDTO);
                }
                //Update OnTimeDuration table to add the off time and calculate the on duration
                else
                {
                    stateID = 1;
                    deviceOnTimeDTO.RoomID = deviceByRoomIdAndDeviceId.RoomID;
                    deviceOnTimeDTO.DeviceID = deviceByRoomIdAndDeviceId.DeviceID;
                    deviceOnTimeDTO.OnTime = DateTime.Now;
                    deviceOnTimeDTO.OffTime = null;
                    deviceOnTimeDTO.OnUserID = GlobalManager.Instance.UserId;
                    deviceOnTimeDTO.OffUserID = null;

                    DeviceController.AddRoomDeviceTimeOn(deviceOnTimeDTO);
                }

                //Change Device State
                RoomDevice roomDevice = new RoomDevice();
                roomDevice.RoomDeviceID = deviceByRoomIdAndDeviceId.RoomDeviceID;
                roomDevice.RoomID = deviceByRoomIdAndDeviceId.RoomID;
                roomDevice.DeviceID = selectedDeviceID;
                roomDevice.StateID = stateID;
                roomDevice.Value = deviceByRoomIdAndDeviceId.Value;
                roomDevice.UnitID = deviceByRoomIdAndDeviceId.UnitID;

                DeviceController.UpdateRoomDevice(roomDevice);

                return new RoomDeviceResponse { Code = (int)ResponseCode.Successful, Message = ResponseCode.Successful.ToString() };
            }

            catch (Exception ex)
            {
                Logger.Logger.ErrorL("PasswordRetriesListByUtilityID", "Endpoint not found exception", ex);
                return new RoomDeviceResponse { Code = (int)ResponseCode.Exception, Message = ResponseCode.Exception.ToString() + ": " + ex.Message };
            }
        }
    }
}
