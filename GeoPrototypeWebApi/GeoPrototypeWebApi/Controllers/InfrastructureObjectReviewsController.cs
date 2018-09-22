using GeoPrototypeWebApi.Facades;
using Microsoft.AspNetCore.Mvc;

namespace GeoPrototypeWebApi.Controllers
{
    [Route("api/[controller]")]
    public class InfrastructureObjectReviewsController : Controller
    {
        public class InfrastructureObjectReview
        {
            public long InfrastructureObjectId { get; set; }

            public string UserName { get; set; }

            public string ReviewText { get; set; }
        }

        [HttpPost]
        public long Post([FromBody]InfrastructureObjectReview review)
        {
            var facade = new InfrastructureObjectReviewsFacade();

            return facade.InsertReview(review);
        }
    }
}