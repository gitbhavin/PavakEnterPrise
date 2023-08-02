using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PVK.DTO.SmsUrl;

namespace PVK.Interfaces.Services.SmsUrl
{
   public interface ISmsurlServices
    {
        Task<SmsurlResponse> GelAllSmsurl();
        Task<SmsurlResponse> AddnewSmsurl(Addsmsurldata addsmsurldata);
        Task<SmsurlResponse> UpdateSmsurl(updateSmsurl tblSmsurl);
        Task<SmsurlResponse> RemoveSmsurl(deleteSmsurl tblSmsurl);
    }
}
