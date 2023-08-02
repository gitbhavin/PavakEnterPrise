using PVK.DTO.SmsUrl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.SmsUrl
{
   public interface ISmsurlProcessor
    {
        Task<SmsurlResponse> GelAllSmsurl();
        Task<SmsurlResponse> AddnewSmsurl(Addsmsurldata addsmsurldata);
        Task<SmsurlResponse> UpdateSmsurl(updateSmsurl tblSmsurl);
        Task<SmsurlResponse> RemoveSmsurl(deleteSmsurl tblSmsurl);

    }
}
