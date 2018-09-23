using GeoPrototypeWebApi.Facades;
using Microsoft.AspNetCore.Mvc;

namespace GeoPrototypeWebApi.Controllers
{

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