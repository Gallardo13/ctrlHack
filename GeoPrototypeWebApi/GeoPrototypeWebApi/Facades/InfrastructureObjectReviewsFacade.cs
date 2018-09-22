using System;
using GeoPrototypeWebApi.Controllers;

namespace GeoPrototypeWebApi.Facades
{
    public class InfrastructureObjectReviewsFacade : DbBaseFacade
    {
        public long InsertReview(InfrastructureObjectReview infrastructureObjectReview)
        {
            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.InsertReview;
                cmd.AddParameter("@InfrastructureObjectId", infrastructureObjectReview.InfrastructureObjectId);
                cmd.AddParameter("@UserName", infrastructureObjectReview.UserName);
                cmd.AddParameter("@ReviewText", infrastructureObjectReview.ReviewText);

                return (long)(ulong)cmd.ExecuteScalar();
            }
        }
    }
}