using PVK.DTO.Newslattersetup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Newslatter
{
    public interface INewslatterService
    {
        Task<NewslatterResponse> GetAllNewslatterEmail();

        Task<NewslatterResponse> Addnewslatter(Addnewslatter addnewslatter);

        Task<NewslatterResponse> Updatenewslatter(Updatenewslatter updatenewslatter);
    }
}
