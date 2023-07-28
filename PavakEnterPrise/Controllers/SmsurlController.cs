using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.SmsUrl;
using PVK.Interfaces.Services.SmsUrl;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsurlController : ControllerBase
    {
        private ISmsurlServices _Services;

        public SmsurlController(ISmsurlServices smsurlServices)
        {
            this._Services = smsurlServices;
        }
        [HttpPost("addnewsmsurl")]
        public async Task<SmsurlResponse> addnewsmsurl(Addsmsurldata addsmsurldata)
        {
            return await _Services.AddnewSmsurl(addsmsurldata);
        }
        [HttpGet("GetAllSmsurl")]
        public async Task<SmsurlResponse> GetAllSmsurl()
        {
            return await _Services.GelAllSmsurl();
        }
        [HttpPost("DeleteSmsurl")]
        public async Task<SmsurlResponse> DeleteSmsurl(deleteSmsurl smsurl)
        {
            return await _Services.RemoveSmsurl(smsurl);
        }
        [HttpPost("UpdateSmsurl")]
        public async Task<SmsurlResponse> UpdateSmsurl(updateSmsurl smsurl)
        {
            return await _Services.UpdateSmsurl(smsurl);
        }

    }
}
