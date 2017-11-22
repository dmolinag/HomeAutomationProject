using System.Collections.Generic;
using System.Runtime.Serialization;
using DomoticProject.DTO;

namespace HomeAutomation.Response
{
    [DataContract(Name = "UserResponse")]
    public class UserResponse
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public List<UserDto> ReturnValue { get; set; }
    }
}


namespace DomoticProject.Controllers.LogicBusiness.Global
{
    [DataContract(Name = "HomeAutomationResponse")]
    public class HomeAutomationResponse<T>
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public List<T> ReturnValue { get; set; }
    }

    public enum ResponseCode
    {
        Successful = 0,
        Invalid_pass_key = -1,
        No_access_permission = -2,
        Exception = -3,
        Entity_not_found = -4,
        Already_exists = -5,
        Device_Setup_Not_Found_For_SmartBox = -6,
        No_Changes_To_Make_In_Setup = -7,
        Setup_Variable_Is_Read_Only = -8,
        Device_Setup_Does_Not_Exist = -9,
        SmartBox_Not_Found = -10,
        Meter_Setup_Does_Not_Exist = -11,
        Meter_Not_Found = -12,
        Meter_Setup_Not_Found_For_SmartBox = -14,
        Meter_Is_Not_In_SmartBox = -15,
        Incorrect_password = -16,
        Not_exist = -17,
        More_than_one = -18,
        User_is_deactivated = -19,
        User_is_deleted = -20,
        Password_expiration_date_reached = -21,
        Incorrect_password_or_username = -22,
        Not_permission_associated = -23,
        Utility_do_not_exist = -24,
        Response_exceeds_the_maximum_registers = -25
    }
}


