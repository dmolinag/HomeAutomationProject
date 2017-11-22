using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DomoticProject.Controllers;
using DomoticProject.Model;
using DomoticProject.DTO;
using System.Runtime.Serialization;
using HomeAutomation.Response;
using DomoticProject.Logger;

namespace DomoticProject.Controllers.LogicBusiness.Global
{
    class Security
    {
        static String profileName = "(Security)";

        /// <summary>
        /// Get password retries from the System Variables table by the utilityID, if the utilityID does not exist in the System Variables table, it will take the UtilityID = null.
        /// </summary>
        /// Version: SPI V5G
        /// Author: Daniel Molina
        public static UserResponse PasswordValidation(string username, string password)
        {
            try
            {
                //Verify the password
                //Get user password data base by the username
                User user = UserController.GetByUsername(username);

                //Get user by username or email
                if (user == null)
                {
                    user = UserController.GetByEmail(username);
                    if (user == null)
                    {
                        Logger.Logger.Info(profileName, "Method Response: User not found. Username:" + username);
                        return new UserResponse { Code = (int)ResponseCode.Incorrect_password_or_username, Message = ResponseCode.Incorrect_password_or_username.ToString() };
                    }
                }

                //Verify if the user is Deleted 
                if (user.IsDeleted == true)
                {
                    Logger.Logger.Info(profileName, "Method Response: User is Deleted. Username:" + username);
                    return new UserResponse { Code = (int)ResponseCode.User_is_deleted, Message = ResponseCode.User_is_deleted.ToString() };
                }

                //Verify if the user is Active
                if (user.IsActive == false)
                {
                    Logger.Logger.Info(profileName, "Method Response: User is not Active. Username:" + username);
                    return new UserResponse { Code = (int)ResponseCode.User_is_deactivated, Message = ResponseCode.User_is_deactivated.ToString() };
                }

                //Validate password
                UserKeyPair passwordToValidate = new UserKeyPair(user.Salt, user.Password);

                if (!PasswordSecurity.ValidateUserHash(password, passwordToValidate))
                {
                    User newUserInfo = new User();
                    newUserInfo.UserID = user.UserID;
                    newUserInfo.Username = user.Username;
                    newUserInfo.Password = user.Password;
                    newUserInfo.Name = user.Name;
                    newUserInfo.Lastname = user.Lastname;
                    newUserInfo.Email = user.Email;
                    newUserInfo.Salt = user.Salt;
                    newUserInfo.PasswordRetries = user.PasswordRetries + 1;
                    newUserInfo.MaxRetries = user.MaxRetries;
                    newUserInfo.IsActive = user.IsActive;
                    newUserInfo.IsDeleted = user.IsDeleted;

                    UserController.Update(newUserInfo);

                    List<UserDto> newUserPasswordRetriesDto = new List<UserDto>();
                    newUserPasswordRetriesDto.Add(new UserDto(newUserInfo));

                    //Desactivate the user account if the userPasswordRetries surpass the systemVariablesPasswordRetries
                    if (newUserInfo.MaxRetries <= newUserInfo.PasswordRetries)
                    {
                        User newUserInfoToDesactivate = new User();
                        newUserInfoToDesactivate.UserID = user.UserID;
                        newUserInfoToDesactivate.Username = user.Username;
                        newUserInfoToDesactivate.Password = user.Password;
                        newUserInfoToDesactivate.Name = user.Name;
                        newUserInfoToDesactivate.Lastname = user.Lastname;
                        newUserInfoToDesactivate.Email = user.Email;
                        newUserInfoToDesactivate.Salt = user.Salt;
                        newUserInfoToDesactivate.PasswordRetries = user.PasswordRetries + 1;
                        newUserInfoToDesactivate.MaxRetries = user.MaxRetries;
                        newUserInfoToDesactivate.IsActive = user.IsActive = false;
                        newUserInfoToDesactivate.IsDeleted = user.IsDeleted;
                        newUserInfo.LastLoginDate = user.LastLoginDate;

                        UserController.Update(newUserInfoToDesactivate);

                        List<UserDto> newUserDisactiveDto = new List<UserDto>();
                        newUserDisactiveDto.Add(new UserDto(newUserInfoToDesactivate));

                        Logger.Logger.Warn(profileName, "Method Response: User is Disactive. Userlogin:" + username);
                        return new UserResponse { Code = (int)ResponseCode.User_is_deactivated, Message = ResponseCode.User_is_deactivated.ToString() };
                    }
                    Logger.Logger.Info(profileName, "Method Response: Incorrect password." + username);
                    return new UserResponse { Code = (int)ResponseCode.Incorrect_password_or_username, Message = ResponseCode.Incorrect_password_or_username.ToString() };
                }

                //Correct password, reset the User password retries
                User updateUserInfoAfterLogin = new User();
                updateUserInfoAfterLogin.UserID = user.UserID;
                updateUserInfoAfterLogin.Username = user.Username;
                updateUserInfoAfterLogin.Password = user.Password;
                updateUserInfoAfterLogin.Name = user.Name;
                updateUserInfoAfterLogin.Lastname = user.Lastname;
                updateUserInfoAfterLogin.Email = user.Email;
                updateUserInfoAfterLogin.Salt = user.Salt;
                updateUserInfoAfterLogin.PasswordRetries = 0;
                updateUserInfoAfterLogin.MaxRetries = user.MaxRetries;
                updateUserInfoAfterLogin.IsActive = user.IsActive;
                updateUserInfoAfterLogin.IsDeleted = user.IsDeleted;
                updateUserInfoAfterLogin.LastLoginDate = DateTime.Now;

                UserController.Update(updateUserInfoAfterLogin);

                List<UserDto> newRegisterDto = new List<UserDto>();
                newRegisterDto.Add(new UserDto(updateUserInfoAfterLogin));

                //Store global information that is going to be used along the application.
                GlobalManager.Instance.Name = updateUserInfoAfterLogin.Name;
                GlobalManager.Instance.Lastname = updateUserInfoAfterLogin.Lastname;
                GlobalManager.Instance.LoginDate = DateTime.Now;
                GlobalManager.Instance.Username = updateUserInfoAfterLogin.Username;
                GlobalManager.Instance.Password = updateUserInfoAfterLogin.Password;
                GlobalManager.Instance.Email = updateUserInfoAfterLogin.Email;
                GlobalManager.Instance.Culture = updateUserInfoAfterLogin.Culture;

                return new UserResponse { Code = (int)ResponseCode.Successful, Message = ResponseCode.Successful.ToString() };
            }

            catch (Exception ex)
            {
                Logger.Logger.ErrorL("PasswordRetriesListByUtilityID", "Endpoint not found exception", ex);
                return new UserResponse { Code = (int)ResponseCode.Exception, Message = ResponseCode.Exception.ToString() + ": " + ex.Message };
            }
        }


 



        ///// <summary>
        ///// Validates if an specific user has access permision to the system database on an specific module
        ///// </summary>
        ///// Version: SPI V5G
        ///// Author: Daniel Molina
        //public static Boolean HasDataAccessPermission(string username, string password, int? utilityID, string permissionName, int allowToIncrementPasswordRetries = 0)
        //{

        //    SpiWebResponseUser passwordValidation;
        //    if (allowToIncrementPasswordRetries == 0)
        //    {
        //        //Check password number retries
        //        passwordValidation = Security.PasswordValidation(username, password, utilityID, 1);
        //    }
        //    else
        //    {
        //        //Check password number retries
        //        passwordValidation = Security.PasswordValidation(username, password, utilityID, 0);
        //    }

        //    if (passwordValidation.Code < 0)
        //    {
        //        Logger.Logger.Info(profileName, "Method Response: Incorrect Password. Username:" + username);
        //        return false;
        //    }

        //    //Permissions
        //    int counterUserRole = 0;

        //    if (utilityID != null)
        //    {
        //        //Check if the utility exist
        //        VTPL_Utility utilityExist = UtilityController.GetById(utilityID);
        //        //Create the DTO prior to send information
        //        List<UtilityDto> retValUtility = new List<UtilityDto>();
        //        if (utilityExist != null)
        //        {
        //            retValUtility.Add(new UtilityDto(utilityExist));
        //        }
        //        else
        //        {
        //            Logger.Logger.Info(profileName, "Method Response: Register not found. Username:" + username);
        //            return false;
        //        }
        //    }


        //    //Consult the UserId by userLogin
        //    VURL_User register = UserControllerPartial.GetByUsername(username);
        //    //Create the DTO prior to send information
        //    if (register == null)
        //    {
        //        register = UserControllerPartial.GetByEmail(username);
        //    }

        //    //Split the name permission in two by the dot and add an * to give this permission all the permissions associated to it like add, update, etc
        //    string[] words = permissionName.Split('.');
        //    string permissionToVerify = words[0] + ".*";

        //    List<string> permissions = new List<string>();
        //    permissions.Add(permissionToVerify);
        //    permissions.Add(permissionName);

        //    List<VSP_ListUserPermissions_Result> userPermissions = UserRolePermissionControllerPartial.ListUserPermissionsAndRolesByUserIDAndUtilityID(register.UserID, utilityID);
        //    //Create the DTO prior to send information
        //    List<UserRolePermissionDtoPartial> retValPermissions = new List<UserRolePermissionDtoPartial>();
        //    foreach (VSP_ListUserPermissions_Result reg in userPermissions)
        //    {
        //        retValPermissions.Add(new UserRolePermissionDtoPartial(reg));
        //    }

        //    //Compare permission to which access is required with which the user has access
        //    for (int init = 0; init < permissions.Count; init++)
        //    {
        //        int count = 0;
        //        for (int init2 = 0; init2 < userPermissions.Count; init2++)
        //        {
        //            if (userPermissions[count].Name == permissions[counterUserRole])
        //            {
        //                return true;
        //            }
        //            count = count + 1;
        //        }
        //        counterUserRole = counterUserRole + 1;
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// Validates if an specific user has access permision to the system database on an specific module JUST FOR THE UserLoginSmartUtility
        ///// </summary>
        ///// Version: SPI V5G
        ///// Author: Daniel Molina
        //public static SpiWebResponseUser HasDataAccessPermissionExtended(string username, string password, int? utilityID, string permissionName, int allowToIncrementPasswordRetries = 0)
        //{
        //    SpiWebResponseUser passwordValidation;

        //    if (allowToIncrementPasswordRetries == 0)
        //    {
        //        //Check password number retries by the Username
        //        passwordValidation = Security.PasswordValidation(username, password, utilityID, 1);
        //    }
        //    else
        //    {
        //        //Check password number retries by the email
        //        passwordValidation = Security.PasswordValidation(username, password, utilityID, 0);
        //    }

        //    if (passwordValidation.Code < 0)
        //    {
        //        Logger.Logger.Info(profileName, "Method Response: Incorrect Password. Username:" + username);
        //        return new SpiWebResponseUser { Code = passwordValidation.Code, Message = passwordValidation.Message };
        //    }

        //    if (passwordValidation.Code == 0)
        //    {


        //        //Permissions
        //        int counterUserRole = 0;

        //        //Check if the utility exist
        //        VTPL_Utility utilityExist = UtilityController.GetById(utilityID);
        //        //Create the DTO prior to send information
        //        List<UtilityDto> retValUtility = new List<UtilityDto>();
        //        if (utilityExist != null)
        //        {
        //            retValUtility.Add(new UtilityDto(utilityExist));
        //        }
        //        else
        //        {
        //            Logger.Logger.Info(profileName, "Method Response: Register not found. Username:" + username);
        //            return new SpiWebResponseUser { Code = (int)ResponseCode.Utility_do_not_exist, Message = ResponseCode.Not_exist.ToString() };
        //        }

        //        //Consult the UserId by userLogin
        //        VURL_User register = UserControllerPartial.GetByUsername(username);
        //        //Create the DTO prior to send information
        //        if (register == null)
        //        {
        //            register = UserControllerPartial.GetByEmail(username);
        //        }

        //        //Split the name permission in two by the dot and add an * to give this permission all the permissions associated to it like add, update, etc
        //        string[] words = permissionName.Split('.');
        //        string permissionToVerify = words[0] + ".*";

        //        List<string> permissions = new List<string>();
        //        permissions.Add(permissionToVerify);
        //        permissions.Add(permissionName);

        //        List<VSP_ListUserPermissions_Result> userPermissions = UserRolePermissionControllerPartial.ListUserPermissionsAndRolesByUserIDAndUtilityID(register.UserID, utilityID);
        //        //Create the DTO prior to send information
        //        List<UserRolePermissionDtoPartial> retValPermissions = new List<UserRolePermissionDtoPartial>();
        //        foreach (VSP_ListUserPermissions_Result reg in userPermissions)
        //        {
        //            retValPermissions.Add(new UserRolePermissionDtoPartial(reg));
        //        }


        //        //Compare permission to which access is required with which the user has access
        //        for (int init = 0; init < permissions.Count; init++)
        //        {
        //            int count = 0;
        //            for (int init2 = 0; init2 < userPermissions.Count; init2++)
        //            {
        //                if (userPermissions[count].Name == permissions[counterUserRole])
        //                {
        //                    return new SpiWebResponseUser { Code = (int)ResponseCode.Successful, Message = ResponseCode.Successful.ToString() };
        //                }
        //                count = count + 1;
        //            }
        //            counterUserRole = counterUserRole + 1;

        //        }
        //        return new SpiWebResponseUser { Code = (int)ResponseCode.Not_permission_associated, Message = ResponseCode.Not_permission_associated.ToString() };
        //    }
        //return passwordValidation;
        //}





        ////Verify if the user is Deleted 
        //if (user.IsDeleted == true)
        //{
        //    Logger.Logger.Info(profileName, "Method Response: User is Deleted. Username:" + userLogin);
        //    return new SpiWebResponseUser { Code = (int)ResponseCode.User_is_deleted, Message = ResponseCode.User_is_deleted.ToString() };
        //}

        ////Verify if the user is Active
        //if (user.IsActive == false)
        //{
        //    Logger.Logger.Info(profileName, "Method Response: User is not active. userLogin:" + userLogin);
        //    return new SpiWebResponseUser { Code = (int)ResponseCode.User_is_deactivated, Message = ResponseCode.User_is_deactivated.ToString() };
        //}

        //////Verify password expiration date
        //if (user.PasswordExpirationDate < DateTime.Now)
        //{
        //    VURL_User newUserInfo = new VURL_User();
        //    newUserInfo.UserID = user.UserID;
        //    newUserInfo.Username = user.Username;
        //    newUserInfo.Password = user.Password;
        //    newUserInfo.Name = user.Name;
        //    newUserInfo.Lastname = user.Lastname;
        //    newUserInfo.Email = user.Email;
        //    newUserInfo.PasswordRetries = user.PasswordRetries;
        //    newUserInfo.IsActive = false;
        //    newUserInfo.IsDeleted = user.IsDeleted;
        //    newUserInfo.PasswordExpirationDate = user.PasswordExpirationDate;
        //    newUserInfo.Salt = user.Salt;
        //    newUserInfo.Culture = user.Culture;
        //    newUserInfo.LastLoginDate = user.LastLoginDate;

        //    UserController.Update(newUserInfo);

        //    List<UserDto> newUserPasswordRetriesDto = new List<UserDto>();
        //    newUserPasswordRetriesDto.Add(new UserDto(newUserInfo));


        //    Logger.Logger.Warn(profileName, "Method Response: Password expiration date is reached. Userlogin:" + userLogin);
        //    return new SpiWebResponseUser { Code = (int)ResponseCode.Password_expiration_date_reached, Message = ResponseCode.Password_expiration_date_reached.ToString() };
        //}

    }
}






