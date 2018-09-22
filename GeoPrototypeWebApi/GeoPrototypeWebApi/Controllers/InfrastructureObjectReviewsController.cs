using GeoPrototypeWebApi.Facades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Controllers
{
    public class InfrastructureObjectReview
    {
        public long Id { get; set; }

        public long InfrastructureObjectId { get; set; }

        public string UserName { get; set; }

        public string ReviewText { get; set; }
    }


    [Route("api/[controller]")]
    public class InfrastructureObjectReviewsController : Controller
    {
        [HttpGet("{reviewId}")]
        public InfrastructureObjectReview Get(long reviewId)
        {
            var facade = new InfrastructureObjectReviewsFacade();

            return facade.ReadReviewById(reviewId);
        }

        [HttpPost]
        public long Post([FromBody]InfrastructureObjectReview review)
        {
            var facade = new InfrastructureObjectReviewsFacade();

            return facade.InsertReview(review);
        }

        [HttpGet("{id}/images/{preview}")]
        public IEnumerable<ReviewImage> Get(long id, bool preview)
        {
            var facade = new InfrastructureObjectReviewImagesFacade();

            return facade.GetImagesByReviewId(id, preview);
        }

    }
}