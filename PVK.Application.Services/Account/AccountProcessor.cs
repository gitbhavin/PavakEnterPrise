using Microsoft.EntityFrameworkCore;
using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.EmailTemplateScope;
using PVK.EFCore.Data.RoleScope;
using PVK.EFCore.Data.UserRoleScope;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Account;
using PVK.QueryHandlers.Helper;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Account
{
    public class AccountProcessor : IAccountProcessor
    {
        private UserContext _usercontext;
        private UserRoleContext _userroleContext;
        private RoleContext _roleContext;
        private  EmailTemplateContext _emailTemplateContext;
       
        public AccountProcessor(UserContext userContext, RoleContext roleContext, UserRoleContext userRoleContext,EmailTemplateContext emailTemplateContext)
        {
            this._usercontext = userContext;
            this._roleContext = roleContext;
            this._userroleContext = userRoleContext;
            this._emailTemplateContext = emailTemplateContext;
           
            
        }
       
        public async Task<userresponse> getallusers()
        {
            userresponse response = new userresponse();
            try
            {
                var user = await _usercontext.TblUsers.ToListAsync();
                if (user != null)
                {


                    foreach (var item in user)
                    {
                        UserData userData = new UserData();
                        userData.UserName = item.UserName;
                        userData.FirstName = item.FirstName;
                        userData.LastName = item.LastName;
                        userData.Email = item.Email;
                        userData.Phone = item.Phone;
                        userData.Guid_Userid = item.Guid_Userid;
                        userData.guid = item.Guid_Userid;
                        userData.Source = item.Source;
                        userData.IMG_URL = item.IMG_URL;
                        userData.Gender = item.Gender;
                        response.userDatas.Add(userData);
                    }

                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<TblUser> GetUserByEmailOrMobile(LoginRequest loginRequest)
        {
            return await _usercontext.TblUsers.FirstOrDefaultAsync(x => x.UserName == loginRequest.UserName);

        }

        public async Task<TblUser> GetUserInfo(string userid)
        {
            return await _usercontext.TblUsers.FirstOrDefaultAsync(x => x.Guid_Userid == userid);

        }

        public async Task<BaseResponsedata> UserResgistration(UserRequest userRequest)
        {
            BaseResponsedata response = new BaseResponsedata();
            try
            {
                string userguid = string.Empty;
                var user = await _usercontext.TblUsers.FindAsync(userRequest.Email);
                if (user == null)
                {
                    userguid = Guid.NewGuid().ToString();
                    var newuser = new TblUser()
                    {
                        Guid_Userid = userguid,
                        FirstName = userRequest.FirstName,
                        LastName = userRequest.LastName,
                        Email = userRequest.Email,
                        Phone = userRequest.MobileNumber,
                        UserName = userRequest.Email,
                        Source = userRequest.Source,
                        Password = PwdCryptography.HashPassword(userRequest.Password)

                    };

                    await _usercontext.TblUsers.AddAsync(newuser);
                    var result = await _usercontext.SaveChangesAsync();
                    if (result > 0)
                    {
                        var role = await _roleContext.TblRoles.FirstOrDefaultAsync(x => x.RoleName == "User");
                        if (role != null)
                        {
                            var userrole = new TblUserRole()
                            {
                                Guid_UserRoleId = Guid.NewGuid().ToString(),
                                Guid_RoleId = role.Guid_RoleId,
                                Guid_UserId = userguid,
                                Uid_Created = userguid,
                                Date_Created = DateTime.Now,
                                Date_Inactive = null
                            };
                            await _userroleContext.TblUserRoles.AddAsync(userrole);
                            await _userroleContext.SaveChangesAsync();
                        }
                        sendemail(userRequest.Email,userRequest.FirstName,userRequest.LastName);
                        response.Status = true;
                        response.Message = "registration Successfully";
                    }

                }
                else
                {
                    response.Status = false;
                    response.Message = "Email already exists.";

                }
                return response;

            }
            catch (Exception ex)
            {

                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }


        public void sendemail(string email, string fname, string lname)
        {
            string apiKey = "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";

            // Initialize the SendGrid client
            var client = new SendGridClient(apiKey);


            var emailtmp = _emailTemplateContext.TblEmailTemplates.Where(e => e.Code == "REGI").FirstOrDefault();
            if (emailtmp != null)
            {
                emailtmp.Body.Replace("User Name", fname + ' ' + lname);
                emailtmp.Body.Replace("Name", fname + ' ' + lname);
                emailtmp.Body.Replace("Email", email);
                emailtmp.Body.Replace("CompanyName", "Pavak EnterPrise");
                // Create a SendGridMessage object
                var message = new SendGridMessage
                {
                    From = new EmailAddress("nileshpatel2533@gmail.com", "Nilesh Patel"),
                    Subject = emailtmp.Subject,

                    HtmlContent = emailtmp.Body,
                };

                // Add recipients
                message.AddTo("nileshptl2519@gmail.com", "nilesh Patel");

                // Send the email
                var response = client.SendEmailAsync(message);
            }


        }
    }
}
