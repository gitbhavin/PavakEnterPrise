using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Newslattersetup;
using PVK.Interfaces.Services.Newslatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewslatterController : ControllerBase
    {
        private readonly INewslatterService _service;
        public NewslatterController(INewslatterService newslatterService)
        {
            this._service = newslatterService;
        }
        [HttpGet("GetAllNewslatterEmaillist")]
        public async Task<NewslatterResponse> GetAllBrands()
        {
            return await _service.GetAllNewslatterEmail();
        }

        [HttpPost("Addnewslatter")]
        public async Task<NewslatterResponse> Addnewslatter(Addnewslatter addnewslatter)
        {
            return await _service.Addnewslatter(addnewslatter);
        }
        [HttpPost("Updatenewslatter")]
        public async Task<NewslatterResponse> Updatenewslatter(Updatenewslatter updatenewslatter)
        {
            return await _service.Updatenewslatter(updatenewslatter);
        }
    }
}
