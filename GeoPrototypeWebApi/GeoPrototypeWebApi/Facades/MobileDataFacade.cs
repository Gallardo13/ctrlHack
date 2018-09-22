using GeoPrototypeWebApi.Models;
using System.Collections.Generic;
using System.Data.Common;

namespace GeoPrototypeWebApi.Facades
{
    public class MobileDataFacade : DbBaseFacade
    {
        // получить список объектов рядом с определенной точкой
        IEnumerable<InfrastructureObjectsMobileInfo> GetNearObjects(double latitude, double longitude)
        {
            var retVal = new List<InfrastructureObjectsMobileInfo>();

            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.GetNearObjects;
            }

            return retVal;
        }
    }
}
