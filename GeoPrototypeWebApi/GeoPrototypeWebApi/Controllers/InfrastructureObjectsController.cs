using GeoPrototypeWebApi.Facades;
using GeoPrototypeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Controllers
{
    [Route("api/[controller]")]
    public class InfrastructureObjectsController : Controller
    {
        [HttpGet("{year}/{startLon}/{startLat}/{endLon}/{endLat}")]
        public IEnumerable<InfrastructureObjectMapInfo> Get(int year, decimal startLon, decimal startLat, decimal endLon, decimal endLat)
        {
            var objectsFacade = new InfrastructureObjectFacade();
            return objectsFacade.GetObjectsByYear(year, startLon, startLat, endLon, endLat);
        }

        [HttpGet("{id}")]
        public IEnumerable<InfrastructureObjectMapInfo> Get(int id)
        {
            var objectsFacade = new InfrastructureObjectFacade();
            return objectsFacade.GetObjectById(id);
        }

        [HttpGet]
        public IEnumerable<InfrastructureObjectMapInfo> Get([FromQuery] int[] ids)
        {
            var objectsFacade = new InfrastructureObjectFacade();
            return objectsFacade.GetObjectByIds(ids);
        }

        [HttpGet("{id}/reviews")]
        public IEnumerable<InfrastructureObjectReview> Get(long id)
        {
            var facade = new InfrastructureObjectReviewsFacade();

            return facade.ReadReviewsByInfrastructureObjectId(id);
        }
    }
}
