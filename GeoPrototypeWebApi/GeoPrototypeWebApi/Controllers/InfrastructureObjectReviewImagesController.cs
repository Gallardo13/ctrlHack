using GeoPrototypeWebApi.Facades;
using Microsoft.AspNetCore.Mvc;

namespace GeoPrototypeWebApi.Controllers
{
    [Route("api/[controller]")]
    public class InfrastructureObjectReviewImagesController : Controller
    {
        public class ReviewImage
        {
            public string MimeType { get; set; }

            public byte[] Image { get; set; }
        }

        [HttpPost("{id}")]
        public void Post(long reviewId, [FromBody]ReviewImage reviewImage)
        {
            var facade = new InfrastructureObjectReviewImagesFacade();

            facade.InsertImage(reviewId, reviewImage);
        }
    }
}