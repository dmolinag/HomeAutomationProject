﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HomeAutomationEntities : DbContext
    {
        public HomeAutomationEntities()
            : base("name=HomeAutomationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceState> DeviceState { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<RoomDevice> RoomDevice { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<DeviceOnTime> DeviceOnTime { get; set; }
    
        public virtual ObjectResult<GetDevicesByRoomId_Result> GetDevicesByRoomId(Nullable<int> roomID)
        {
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDevicesByRoomId_Result>("GetDevicesByRoomId", roomIDParameter);
        }
    
        public virtual ObjectResult<GetDeviceByRoomIdAndDeviceID_Result> GetDeviceByRoomIdAndDeviceID(Nullable<int> roomID, Nullable<int> deviceID)
        {
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(int));
    
            var deviceIDParameter = deviceID.HasValue ?
                new ObjectParameter("DeviceID", deviceID) :
                new ObjectParameter("DeviceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDeviceByRoomIdAndDeviceID_Result>("GetDeviceByRoomIdAndDeviceID", roomIDParameter, deviceIDParameter);
        }
    
        public virtual ObjectResult<GetDeviceOnTimeByRoomIdAndDeviceID_Result> GetDeviceOnTimeByRoomIdAndDeviceID(Nullable<int> roomID, Nullable<int> deviceID)
        {
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(int));
    
            var deviceIDParameter = deviceID.HasValue ?
                new ObjectParameter("DeviceID", deviceID) :
                new ObjectParameter("DeviceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDeviceOnTimeByRoomIdAndDeviceID_Result>("GetDeviceOnTimeByRoomIdAndDeviceID", roomIDParameter, deviceIDParameter);
        }
    }
}
