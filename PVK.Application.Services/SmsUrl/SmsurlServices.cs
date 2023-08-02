using PVK.DTO.SmsUrl;
using PVK.Interfaces.Services.SmsUrl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.SmsUrl
{
    public class SmsurlServices : ISmsurlServices
    {
        private ISmsurlProcessor _smsurlProcessor;

        public SmsurlServices(ISmsurlProcessor smsurlProcessor)
        {
            this._smsurlProcessor = smsurlProcessor;
        }
        public async Task<SmsurlResponse> AddnewSmsurl(Addsmsurldata addsmsurldata)
        {
            return await _smsurlProcessor.AddnewSmsurl(addsmsurldata);
        }

        public async Task<SmsurlResponse> GelAllSmsurl()
        {
            return await _smsurlProcessor.GelAllSmsurl();
        }

        public async Task<SmsurlResponse> RemoveSmsurl(deleteSmsurl tblSmsurl)
        {
            return await _smsurlProcessor.RemoveSmsurl(tblSmsurl);
        }

        public async Task<SmsurlResponse> UpdateSmsurl(updateSmsurl tblSmsurl)
        {
            return await _smsurlProcessor.UpdateSmsurl(tblSmsurl);
        }
    }
}
