using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GeoPrototypeWebApi.Facades;
using GeoPrototypeWebApi.Models;

namespace GeoPrototypeWebApi.Controllers
{
    [Route("api/[controller]")]
    public class InfrastructureObjectsController : Controller
    {
        // GET api/values/5
        [HttpGet("{year}/{startLon}/{startLat}/{endLon}/{endLat}")]
        public IEnumerable<InfrastructureObjectMapInfo> Get(int year, decimal startLon, decimal startLat, decimal endLon, decimal endLat)
        {
            var objectsFacade = new InfrastructureObjectFacade();
            return objectsFacade.GetObjectsByYear(year, startLon, startLat, endLon, endLat);      
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<InfrastructureObjectMapInfo> Get(int id)
        {
            var objectsFacade = new InfrastructureObjectFacade();
            return objectsFacade.GetObjectById(id);
        }
    }


}
