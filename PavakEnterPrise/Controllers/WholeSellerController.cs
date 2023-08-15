using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Wholeseller;
using PVK.Interfaces.Services.Wholeseller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholeSellerController : ControllerBase
    {
        private readonly IWholesellerService _service;
        public WholeSellerController(IWholesellerService wholesellerService)
        {
            this._service = wholesellerService;
        }
        [HttpGet("GetAllWholeseller")]
        public async Task<WholesellerResponse> Getallwholeseller()
        {
            return await _service.Getallwholeseller();
        }

        [HttpPost("Addwholeseller")]
        public async Task<WholesellerResponse> Addwholeseller(Addwholeseller addwholeseller)
        {
            return await _service.Addwholeseller(addwholeseller);
        }
        [HttpPost("Deletewholeseller")]
        public async Task<WholesellerResponse> Deletewholeseller(Deletewholeseller deletewholeseller)
        {
            return await _service.Deletewholeseller(deletewholeseller);
        }
        [HttpPost("UpdateWholeseller")]
        public async Task<WholesellerResponse> UpdateWholeseller(UpdateWholeseller updateWholeseller)
        {
            return await _service.UpdateWholeseller(updateWholeseller);
        }

        [HttpPost("GetWholesellerbyId")]
        public async Task<WholesellerResponse> GetWholesellerbyId(string guidwholesellerId)
        {
            return await _service.GetWholesellerbyId(guidwholesellerId);
        }
    }
}
