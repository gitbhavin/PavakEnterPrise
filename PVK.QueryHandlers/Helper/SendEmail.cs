using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Text;
using PVK.EFCore.Data.EmailTemplateScope;
using System.Linq;
using SendGrid.Helpers.Mail.Model;

namespace PVK.QueryHandlers.Helper
{
    public class SendEmail
    {
        private readonly EmailTemplateContext _emailTemplateContext;      

        public SendEmail(EmailTemplateContext emailTemplateContext)
        {
            this._emailTemplateContext = emailTemplateContext;
        }
        public void sendemail(string email,string fname, string lname)
        {
            string apiKey = "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";

            // Initialize the SendGrid client
            var client = new SendGridClient(apiKey);


            var emailtmp = _emailTemplateContext.TblEmailTemplates.Where(e => e.Code == "REGI").FirstOrDefault();
            if (emailtmp != null)
            {
                emailtmp.Body.Replace("User Name", fname +' '+ lname);
                emailtmp.Body.Replace("Name", fname + ' ' + lname);
                emailtmp.Body.Replace("Email", email);
                emailtmp.Body.Replace("CompanyName","Pavak EnterPrise");
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
