using PVK.DTO.Review;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Review
{
   public interface IReviewProcessor
    {
        Task<ReviewResponse> Addreview(Addreview addreview);

        Task<ReviewResponse> DeleteReview(Deletereview deletereview);

        Task<ReviewResponse> UpdateReview(Updatereview updatereview);

        Task<ReviewResponse> GetReviewbyProducguidId(string GuidproductId);
    }
}
