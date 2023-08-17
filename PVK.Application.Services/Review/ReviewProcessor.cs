using Microsoft.EntityFrameworkCore;
using PVK.DTO.Review;
using PVK.EFCore.Data.ReviewScope;
using PVK.Interfaces.Services.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Review
{
    public class ReviewProcessor : IReviewProcessor
    {

        private readonly ReviewContext _reviewContext;

        public ReviewProcessor(ReviewContext reviewContext)
        {
            this._reviewContext = reviewContext;
        }
        public async Task<ReviewResponse> Addreview(Addreview addreview)
        {
            ReviewResponse response = new ReviewResponse();
            try
            {

               
                    var review = new TblReview()
                    {
                        Guid_ReviewId = Guid.NewGuid().ToString(),
                        Guid_ProductId = addreview.Guid_ProductId,
                        Guid_UserId=addreview.Guid_UserId,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addreview.Guid_UserId


                    };

                    await _reviewContext.TblReviews.AddAsync(review);
                    var result = await _reviewContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "data save successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                return response;
            }
               
                
            
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ReviewResponse> DeleteReview(Deletereview deletereview)
        {
            ReviewResponse response = new ReviewResponse();
            try
            {

                var review = _reviewContext.TblReviews.Where(x => x.Guid_ReviewId == deletereview.Guid_ReviewId).FirstOrDefault();

                if (review != null)
                {




                    review.Date_Inactive = DateTime.Now;
                    review.Uid_Modified = deletereview.UserId;


                    _reviewContext.TblReviews.Update(review);
                    var result = await _reviewContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "review deleted successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ReviewResponse> GetReviewbyProducguidId(string GuidproductId)
        {
            ReviewResponse response = new ReviewResponse();

            try
            {
                var result = await _reviewContext.TblReviews.Where(x => x.Date_Inactive == null && x.Guid_ProductId == GuidproductId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Reviewdata data = new Reviewdata();
                        data.Guid_ReviewId = item.Guid_ReviewId;
                        data.Guid_ProductId = item.Guid_ProductId;
                        data.Guid_UserId = item.Guid_UserId;
                        data.Rating_Count = item.Rating_Count;
                        response.reviewdatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ReviewResponse> UpdateReview(Updatereview updatereview)
        {
            ReviewResponse response = new ReviewResponse();
            try
            {

                var review = new TblReview()
                {
                    Guid_ReviewId = updatereview.Guid_ReviewId,
                    Guid_ProductId = updatereview.Guid_ProductId,
                    Guid_UserId = updatereview.Guid_UserId,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = updatereview.Guid_UserId


                };

                _reviewContext.TblReviews.Update(review);
                var result = await _reviewContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "data updated successfully";


                }
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
