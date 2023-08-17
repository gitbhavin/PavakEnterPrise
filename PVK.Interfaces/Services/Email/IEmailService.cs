using PVK.DTO.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Email
{
    public interface IEmailService
    {
        Task<EmailResponse> GetAllEmail();

        Task<EmailResponse> AddEmail(AddEmail addEmail);

        Task<EmailResponse> Deleteemail(Deleteemail deleteemail);

        Task<EmailResponse> UpdateEmail(UpdateEmail updateEmail);

        Task<EmailResponse> GetEmailbyId(string guidemailid);
    }
}
