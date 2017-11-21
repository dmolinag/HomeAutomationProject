using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeAutomation.Response;
using DomoticProject.Model;
using DomoticProject.DTO;
using DomoticProject.Controllers.LogicBusiness.Global;
using DomoticProject.Controllers.Queries;

namespace DomoticProject.Controllers.LogicBusiness
{
    public class LibiasRoom
    {
        static String profileName = "(LibiasRoom)";
        static int roomId = 1;

        //public static UserResponse PasswordValidation(string username, string password)
        //{
        //    try
        //    {
        //        //Verify the password
        //        //Get user password data base by the username
        //        GetDevicesByRoomId_Result user = DeviceController.GetDevicesByRoomId(username);

        //        //Get user by username or email
        //        if (user == null)
        //        {
        //            user = UserController.GetByEmail(username);
        //            if (user == null)
        //            {
        //                Logger.Logger.Info(profileName, "Method Response: User not found. Username:" + username);
        //                return new UserResponse { Code = (int)ResponseCode.Incorrect_password_or_username, Message = ResponseCode.Incorrect_password_or_username.ToString() };
        //            }
        //        }

        //        //Verify if the user is Deleted 
        //        if (user.IsDeleted == true)
        //        {
        //            Logger.Logger.Info(profileName, "Method Response: User is Deleted. Username:" + username);
        //            return new UserResponse { Code = (int)ResponseCode.User_is_deleted, Message = ResponseCode.User_is_deleted.ToString() };
        //        }

        //        //Verify if the user is Active
        //        if (user.IsActive == false)
        //        {
        //            Logger.Logger.Info(profileName, "Method Response: User is not Active. Username:" + username);
        //            return new UserResponse { Code = (int)ResponseCode.User_is_deactivated, Message = ResponseCode.User_is_deactivated.ToString() };
        //        }


        //        //Validate password
        //        UserKeyPair passwordToValidate = new UserKeyPair(user.Salt, user.Password);

        //        if (!PasswordSecurity.ValidateUserHash(password, passwordToValidate))
        //        {
        //            User newUserInfo = new User();
        //            newUserInfo.UserID = user.UserID;
        //            newUserInfo.Username = user.Username;
        //            newUserInfo.Password = user.Password;
        //            newUserInfo.Name = user.Name;
        //            newUserInfo.Lastname = user.Lastname;
        //            newUserInfo.Email = user.Email;
        //            newUserInfo.Salt = user.Salt;
        //            newUserInfo.PasswordRetries = user.PasswordRetries + 1;
        //            newUserInfo.MaxRetries = user.MaxRetries;
        //            newUserInfo.IsActive = user.IsActive;
        //            newUserInfo.IsDeleted = user.IsDeleted;

        //            UserController.Update(newUserInfo);

        //            List<UserDto> newUserPasswordRetriesDto = new List<UserDto>();
        //            newUserPasswordRetriesDto.Add(new UserDto(newUserInfo));

        //            //Desactivate the user account if the userPasswordRetries surpass the systemVariablesPasswordRetries
        //            if (newUserInfo.MaxRetries <= newUserInfo.PasswordRetries)
        //            {
        //                User newUserInfoToDesactivate = new User();
        //                newUserInfoToDesactivate.UserID = user.UserID;
        //                newUserInfoToDesactivate.Username = user.Username;
        //                newUserInfoToDesactivate.Password = user.Password;
        //                newUserInfoToDesactivate.Name = user.Name;
        //                newUserInfoToDesactivate.Lastname = user.Lastname;
        //                newUserInfoToDesactivate.Email = user.Email;
        //                newUserInfoToDesactivate.Salt = user.Salt;
        //                newUserInfoToDesactivate.PasswordRetries = user.PasswordRetries + 1;
        //                newUserInfoToDesactivate.MaxRetries = user.MaxRetries;
        //                newUserInfoToDesactivate.IsActive = user.IsActive = false;
        //                newUserInfoToDesactivate.IsDeleted = user.IsDeleted;
        //                newUserInfo.LastLoginDate = user.LastLoginDate;

        //                UserController.Update(newUserInfoToDesactivate);

        //                List<UserDto> newUserDisactiveDto = new List<UserDto>();
        //                newUserDisactiveDto.Add(new UserDto(newUserInfoToDesactivate));

        //                Logger.Logger.Warn(profileName, "Method Response: User is Disactive. Userlogin:" + username);
        //                return new UserResponse { Code = (int)ResponseCode.User_is_deactivated, Message = ResponseCode.User_is_deactivated.ToString() };
        //            }
        //            Logger.Logger.Info(profileName, "Method Response: Incorrect password." + username);
        //            return new UserResponse { Code = (int)ResponseCode.Incorrect_password_or_username, Message = ResponseCode.Incorrect_password_or_username.ToString() };
        //        }

        //        //Correct password, reset the User password retries
        //        User updateUserInfoAfterLogin = new User();
        //        updateUserInfoAfterLogin.UserID = user.UserID;
        //        updateUserInfoAfterLogin.Username = user.Username;
        //        updateUserInfoAfterLogin.Password = user.Password;
        //        updateUserInfoAfterLogin.Name = user.Name;
        //        updateUserInfoAfterLogin.Lastname = user.Lastname;
        //        updateUserInfoAfterLogin.Email = user.Email;
        //        updateUserInfoAfterLogin.Salt = user.Salt;
        //        updateUserInfoAfterLogin.PasswordRetries = 0;
        //        updateUserInfoAfterLogin.MaxRetries = user.MaxRetries;
        //        updateUserInfoAfterLogin.IsActive = user.IsActive;
        //        updateUserInfoAfterLogin.IsDeleted = user.IsDeleted;
        //        updateUserInfoAfterLogin.LastLoginDate = DateTime.Now;

        //        UserController.Update(updateUserInfoAfterLogin);

        //        List<UserDto> newRegisterDto = new List<UserDto>();
        //        newRegisterDto.Add(new UserDto(updateUserInfoAfterLogin));

        //        //Store global information that is going to be used along the application.
        //        GlobalManager.Instance.Name = updateUserInfoAfterLogin.Name;
        //        GlobalManager.Instance.Lastname = updateUserInfoAfterLogin.Lastname;
        //        GlobalManager.Instance.LoginDate = DateTime.Now;
        //        GlobalManager.Instance.Username = updateUserInfoAfterLogin.Username;
        //        GlobalManager.Instance.Password = updateUserInfoAfterLogin.Password;
        //        GlobalManager.Instance.Email = updateUserInfoAfterLogin.Email;
        //        GlobalManager.Instance.Culture = updateUserInfoAfterLogin.Culture;
        //        //LoadPermissionsList();
        //        //btnLogin.Enabled = false;

        //        return new UserResponse { Code = (int)ResponseCode.Successful, Message = ResponseCode.Successful.ToString() };
        //    }

        //    catch (Exception ex)
        //    {
        //        Logger.Logger.ErrorL("PasswordRetriesListByUtilityID", "Endpoint not found exception", ex);
        //        return new UserResponse { Code = (int)ResponseCode.Exception, Message = ResponseCode.Exception.ToString() + ": " + ex.Message };
        //    }
        //}
    }
}
