//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomoticProject.Model
{
    using System;
    
    public partial class GetDeviceOnTimeByRoomIdAndDeviceID_Result
    {
        public int DeviceOnTimeID { get; set; }
        public int RoomID { get; set; }
        public int DeviceID { get; set; }
        public System.DateTime OnTime { get; set; }
        public Nullable<System.DateTime> OffTime { get; set; }
        public Nullable<decimal> OnTimeDuration { get; set; }
        public int OnUserID { get; set; }
        public Nullable<int> OffUserID { get; set; }
    }
}
