using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoPrototypeWebApi.Facades
{
    public interface ISqlStrings
    {
        string GetNearObjects { get; }

        string GetObjectsByYear { get; }

        string GetObjectById { get; }
    }

    public class SqlStrings : ISqlStrings
    {
        public string GetNearObjects => "select id, description, latitude, longitude from contracts where latitude between @LatitudeFrom and @LatitudeTo and longitude between @LongitudeFrom and @LongitudeTo";

        public string GetObjectsByYear => 
            @"SELECT * 
            FROM contracts 
            WHERE (`start_date` between @dateFrom AND @dateTo) 
            OR  (`finish_date` between @dateFrom AND @dateTo)";

        public string GetObjectById => 
            @"SELECT*
            FROM contracts
            WHERE(`id` = @id)";
    }
}
