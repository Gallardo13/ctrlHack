using GeoPrototypeWebApi.Facades;
using GeoPrototypeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Controllers
{
    [Route("api/[controller]")]
    public class NearObjectsController : Controller
    {
        [HttpGet("{latitude}/{longtitude}")]
        public IEnumerable<InfrastructureObjectsMobileInfo> Get(double latitude, double longitude)
        {
            var facade = new NearObjectsFacade();

            return facade.GetNearObjects(latitude, longitude);
        }
    }
}
