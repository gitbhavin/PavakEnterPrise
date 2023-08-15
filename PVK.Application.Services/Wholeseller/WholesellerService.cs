using PVK.DTO.Wholeseller;
using PVK.Interfaces.Services.Wholeseller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Wholeseller
{
    public class WholesellerService : IWholesellerService
    {
        private IWholesellerProcessor _wholesellerProcessor;
        public WholesellerService(IWholesellerProcessor wholeseller)
        {
            this._wholesellerProcessor = wholeseller;
        }
        public async Task<WholesellerResponse> Addwholeseller(Addwholeseller addwholeseller)
        {
            return await _wholesellerProcessor.Addwholeseller(addwholeseller);
        }

        public async Task<WholesellerResponse> Deletewholeseller(Deletewholeseller deletewholeseller)
        {
            return await _wholesellerProcessor.Deletewholeseller(deletewholeseller);
        }

        public async Task<WholesellerResponse> Getallwholeseller()
        {
            return await _wholesellerProcessor.Getallwholeseller();
        }

        public async Task<WholesellerResponse> GetWholesellerbyId(string GuidWholesellerid)
        {
            return await _wholesellerProcessor.GetWholesellerbyId(GuidWholesellerid);
        }

        public async Task<WholesellerResponse> UpdateWholeseller(UpdateWholeseller updateWholeseller)
        {
            return await _wholesellerProcessor.UpdateWholeseller(updateWholeseller);
        }
    }
}
