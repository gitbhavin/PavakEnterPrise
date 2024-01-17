using PVK.Application.Services.Brand;
using PVK.DTO.Brand;
using PVK.DTO.Unit;
using PVK.Interfaces.Services.Brand;
using PVK.Interfaces.Services.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Unit
{
    public class UnitService : IUnitService
    {
        private IUnitProcessor _unitProcessor;
        public UnitService(IUnitProcessor unitProcessor)
        {
            this._unitProcessor = unitProcessor;
        }
        public async Task<unitresponse> Addnewunit(addunit addunit)
        {
            return await _unitProcessor.Addnewunit(addunit);
        }

        public async Task<unitresponse> GetAllUnit()
        {
            return await _unitProcessor.GetAllUnit();
        }

        public async Task<unitresponse> GetUnitbyId(string guidunitId)
        {
            return await _unitProcessor.GetUnitbyId(guidunitId);
        }

        public async Task<unitresponse> Removeunit(addunit removeunit)
        {
            return await _unitProcessor.Removeunit(removeunit);
        }

        public async Task<unitresponse> UpdateUnit(addunit updateunit)
        {
            return await _unitProcessor.UpdateUnit(updateunit);
        }
    }
}
