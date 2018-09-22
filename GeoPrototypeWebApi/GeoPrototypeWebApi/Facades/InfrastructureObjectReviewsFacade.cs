using System;
using System.Collections.Generic;
using GeoPrototypeWebApi.Controllers;

namespace GeoPrototypeWebApi.Facades
{
    public class InfrastructureObjectReviewsFacade : DbBaseFacade
    {
        public InfrastructureObjectReview ReadReviewById(long id)
        {
            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.ReadReviewById;
                cmd.AddParameter("@Id", id);

                var dataReader = cmd.ExecuteReader();
                if (!dataReader.Read())
                    return null;

                return new InfrastructureObjectReview
                {
                    Id = (long)dataReader["id"],
                    InfrastructureObjectId = (long)dataReader["contract_id"],
                    UserName = dataReader.GetNullableString("name"),
                    ReviewText = dataReader.GetNullableString("comment")
                };
            }
        }

        public IEnumerable<InfrastructureObjectReview> ReadReviewsByInfrastructureObjectId(long infrastructureObjectId)
        {
            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.ReadReviewByInfrastructureObjectId;
                cmd.AddParameter("@InfrastructureObjectId", infrastructureObjectId);

                var dataReader = cmd.ExecuteReader();

                var retVal = new List<InfrastructureObjectReview>();
                while (dataReader.Read())
                    retVal.Add(new InfrastructureObjectReview
                    {
                        Id = (long)dataReader["id"],
                        InfrastructureObjectId = (long)dataReader["contract_id"],
                        UserName = dataReader.GetNullableString("name"),
                        ReviewText = dataReader.GetNullableString("comment")
                    });

                return retVal;
            }
        }

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