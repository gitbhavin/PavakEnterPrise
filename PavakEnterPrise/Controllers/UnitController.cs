using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Brand;
using PVK.DTO.Unit;
using PVK.Interfaces.Services.Brand;
using PVK.Interfaces.Services.Unit;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _service;
        public UnitController(IUnitService unitService)
        {
            this._service = unitService;
        }
        [HttpGet("GetAllUnits")]
        public async Task<unitresponse> GetAllUnits()
        {
            return await _service.GetAllUnit();
        }

        [HttpPost("Addnewunit")]
        public async Task<unitresponse> Addnewunit(addunit tblunit)
        {
            return await _service.Addnewunit(tblunit);
        }
        [HttpPost("Deleteunit")]
        public async Task<unitresponse> Deleteunit(addunit removeunit)
        {
            return await _service.Removeunit(removeunit);
        }
        [HttpPost("Updateunit")]
        public async Task<unitresponse> Updateunit(addunit updateunit)
        {
            return await _service.UpdateUnit(updateunit);
        }

        [HttpPost("GetunitbyId")]
        public async Task<unitresponse> GetunitbyId(string guidunitId)
        {
            return await _service.GetUnitbyId(guidunitId);
        }
    }
}
