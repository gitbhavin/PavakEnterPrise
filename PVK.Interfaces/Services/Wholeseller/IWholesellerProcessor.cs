using PVK.DTO.Wholeseller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Wholeseller
{
    public interface IWholesellerProcessor
    {
        Task<WholesellerResponse> Getallwholeseller();

        Task<WholesellerResponse> Addwholeseller(Addwholeseller addwholeseller);

        Task<WholesellerResponse> Deletewholeseller(Deletewholeseller deletewholeseller);

        Task<WholesellerResponse> UpdateWholeseller(UpdateWholeseller updateWholeseller);

        Task<WholesellerResponse> GetWholesellerbyId(string GuidWholesellerid);
    }
}
