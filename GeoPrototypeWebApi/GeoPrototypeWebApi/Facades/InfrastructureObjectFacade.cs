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
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection()) 
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectsByYear;
                cmd.Parameters.Add(year);
            }

            return retVal;
        }

        public IEnumerable<InfrastructureObjectMapInfo> GetObjectById(int id) 
        {
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection()) 
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectById;
                cmd.Parameters.Add(id);
            }

            return retVal;
        }
    }
}
