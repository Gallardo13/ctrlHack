using System;
using System.Collections.Generic;
using System.Linq;
using GeoPrototypeWebApi.Models;

namespace GeoPrototypeWebApi.Facades
{
    public class InfrastructureObjectFacade : DbBaseFacade
    {
        public InfrastructureObjectFacade()
        {
        }


        public IEnumerable<InfrastructureObjectMapInfo> GetObjectsByYear(int year) 
        {
            using (var connection = GetDbConnection()) 
            {
                // TODO чтение из БД
            }
            return null;
        }

        public IEnumerable<InfrastructureObjectMapInfo> GetObjectById(int id) 
        {
            using (var connection = GetDbConnection()) 
            {
                // TODO чтение из БД
            }
            return null;
        }
    }
}
