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
        [HttpGet("{year}/{id}")]
        public IEnumerable<InfrastructureObjectMapInfo> Get(int? year, int? id)
        {

            var objectsFacade = new InfrastructureObjectFacade();

			if (year != null) 
			{
                return objectsFacade.GetObjectsByYear(year);      
			}
            if (id != null) 
            {
                return objectsFacade.GetObjectById(id);
            }

            return null;
        }

    
    }
}
