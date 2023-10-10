using PVK.DTO.Newslattersetup;
using PVK.Interfaces.Services.Newslatter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.NewsLatter
{
    public class NewslatterService : INewslatterService
    {
        public readonly INewslatterProcessor _newslatterProcessor;

        public NewslatterService(INewslatterProcessor newslatterProcessor)
        {
            this._newslatterProcessor = newslatterProcessor;
        }
        public async Task<NewslatterResponse> Addnewslatter(Addnewslatter addnewslatter)
        {
            return await _newslatterProcessor.Addnewslatter(addnewslatter);

        }

        public async Task<NewslatterResponse> GetAllNewslatterEmail()
        {
            return await _newslatterProcessor.GetAllNewslatterEmail();
        }

        public async Task<NewslatterResponse> Updatenewslatter(Updatenewslatter updatenewslatter)
        {
            return await _newslatterProcessor.Updatenewslatter(updatenewslatter);
        }
    }
}
