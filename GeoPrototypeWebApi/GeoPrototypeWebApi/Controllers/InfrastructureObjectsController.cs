using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GeoPrototypeWebApi.Facades;
using GeoPrototypeWebApi.Models;
using System.Web.Http;

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

        // GET api/values/5
        [HttpGet]
        public IEnumerable<InfrastructureObjectMapInfo> Get([FromQuery] int[] ids)
        {            
            var objectsFacade = new InfrastructureObjectFacade();
            return objectsFacade.GetObjectByIds(ids);
        }


    }


}
