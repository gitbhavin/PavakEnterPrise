using PVK.DTO.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Unit
{
    public interface IUnitProcessor
    {
        Task<unitresponse> GetAllUnit();

        Task<unitresponse> Addnewunit(addunit addunit);

        Task<unitresponse> Removeunit(addunit removeunit);

        Task<unitresponse> UpdateUnit(addunit updateunit);

        Task<unitresponse> GetUnitbyId(string guidunitId);
    }
}
