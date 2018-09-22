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

        string InsertReview { get; }

        string InsertReviewImage { get; }
    }

    public class SqlStrings : ISqlStrings
    {
        public string GetNearObjects => "select id, description, latitude, longitude from contracts where latitude between @LatitudeFrom and @LatitudeTo and longitude between @LongitudeFrom and @LongitudeTo";

        public string GetObjectsByYear =>
            @"SELECT * 
            FROM contracts 
            WHERE ((`start_date` between @DateFrom AND @DateTo) 
            OR  (`finish_date` between @DateFrom AND @DateTo))
            AND latitude between @LatitudeFrom and @LatitudeTo and longitude between @LongitudeFrom and @LongitudeTo ";

        public string GetObjectById => 
            @"SELECT*
            FROM contracts
            WHERE(`id` = @id)";

        public string InsertReview => throw new NotImplementedException();

        public string InsertReviewImage => throw new NotImplementedException();
    }
}
