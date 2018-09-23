using GeoPrototypeWebApi.Facades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Controllers
{
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