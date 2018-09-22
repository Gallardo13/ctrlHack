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

        string GetObjectByIds { get; }

        string ReadReviewById { get; }

        string ReadReviewByInfrastructureObjectId { get; }

        string ReadReviewImagesById { get; }

        string ReadReviewImagesByReviewId { get; }
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

        public string InsertReview => "insert into reviews (contract_id, name, comment) values (@InfrastructureObjectId, @UserName, @ReviewText); select last_insert_id();";

        public string InsertReviewImage => "insert into images2reviews (review_id, image_type, image, preview_type, preview) values (@ReviewId, @ImageMimeType, @Image, @ThumbnailMimeType, @ThumbnailImage)";

        public string GetObjectByIds =>
           @"SELECT *
            FROM contracts
            WHERE(`id` in @ids)";

        public string ReadReviewById => "select id, contract_id, name, comment from reviews where id = @Id";

        public string ReadReviewByInfrastructureObjectId => "select id, contract_id, name, comment from reviews where contract_id = @InfrastructureObjectId";

        public string ReadReviewImagesById => "select id, review_id, preview_type, preview, image_type, image from images2reviews where id = @Id";

        public string ReadReviewImagesByReviewId => "select id, review_id, preview_type, preview, image_type, image from images2reviews where review_id = @ReviewId";
    }
}
