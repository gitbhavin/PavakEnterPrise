using PVK.DTO.Review;
using PVK.Interfaces.Services.Review;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewProcessor _reviewProcessor;

        public ReviewService(IReviewProcessor reviewProcessor)
        {
            this._reviewProcessor = reviewProcessor;
        }
        public async Task<ReviewResponse> Addreview(Addreview addreview)
        {
            return await _reviewProcessor.Addreview(addreview);
        }

        public Task<ReviewResponse> DeleteReview(Deletereview deletereview)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewResponse> GetReviewbyProducguidId(string GuidproductId)
        {
            return await _reviewProcessor.GetReviewbyProducguidId(GuidproductId);
        }

        public async Task<ReviewResponse> UpdateReview(Updatereview updatereview)
        {
            return await _reviewProcessor.UpdateReview(updatereview);
        }
    }
}
