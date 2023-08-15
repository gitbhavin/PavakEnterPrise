using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Review;
using PVK.Interfaces.Services.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService reviewServices)
        {
            this._service = reviewServices;
        }
        [HttpGet("GetAllReviewbyProductId")]
        public async Task<ReviewResponse> GetReviewbyProducguidId(string guidProductId)
        {
            return await _service.GetReviewbyProducguidId(guidProductId);
        }

        [HttpPost("Addreview")]
        public async Task<ReviewResponse> Addreview(Addreview addreview)
        {
            return await _service.Addreview(addreview);
        }
        [HttpPost("Deletereview")]
        public async Task<ReviewResponse> Deletereview(Deletereview deletereview)
        {
            return await _service.DeleteReview(deletereview);
        }
        [HttpPost("Updatereview")]
        public async Task<ReviewResponse> Updatereview(Updatereview updatereview)
        {
            return await _service.UpdateReview(updatereview);
        }

       
    }
}
