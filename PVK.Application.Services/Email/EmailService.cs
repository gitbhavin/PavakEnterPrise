using PVK.DTO.Email;
using PVK.Interfaces.Services.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Email
{
    public class EmailService : IEmailService
    {
        private IEmailProcessor _emailProcessor;
        public EmailService(IEmailProcessor emailProcessor)
        {
            this._emailProcessor = emailProcessor;
        }
        public async Task<EmailResponse> AddEmail(AddEmail addEmail)
        {
            return await _emailProcessor.AddEmail(addEmail);
        }

        public async Task<EmailResponse> Deleteemail(Deleteemail deleteemail)
        {
            return await _emailProcessor.Deleteemail(deleteemail);
        }

        public async Task<EmailResponse> GetAllEmail()
        {
            return await _emailProcessor.GetAllEmail();
        }

        public async Task<EmailResponse> GetEmailbyId(string guidemailid)
        {
            return await _emailProcessor.GetEmailbyId(guidemailid);
        }

        public async Task<EmailResponse> UpdateEmail(UpdateEmail updateEmail)
        {
            return await _emailProcessor.UpdateEmail(updateEmail);
        }
    }
}
