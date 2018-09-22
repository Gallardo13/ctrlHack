using GeoPrototypeWebApi.Facades;
using Microsoft.AspNetCore.Mvc;

namespace GeoPrototypeWebApi.Controllers
{
    public class ReviewImage
    {
        public long Id { get; set; }

        public long ReviewId { get; set; }

        public string MimeType { get; set; }

        public byte[] Image { get; set; }
    }

    [Route("api/[controller]")]
    public class InfrastructureObjectReviewImagesController : Controller
    {
        [HttpGet("{id}/{preview}")]
        public ReviewImage Get(long id, bool preview)
        {
            var facade = new InfrastructureObjectReviewImagesFacade();

            return facade.GetImageById(id, preview);
        }

        [HttpPost("{id}")]
        public void Post(long reviewId, [FromBody]ReviewImage reviewImage)
        {
            var facade = new InfrastructureObjectReviewImagesFacade();

            facade.InsertImage(reviewId, reviewImage);
        }
    }
}