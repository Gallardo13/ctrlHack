using GeoPrototypeWebApi.Controllers;
using System.Collections.Generic;


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
                    ReviewText = dataReader.GetNullableString("comment"),
                    Phone = dataReader.GetNullableString("phone"),
                    IsGoodReview = (bool)dataReader["type"]
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
                        ReviewText = dataReader.GetNullableString("comment"),
                        Phone = dataReader.GetNullableString("phone"),
                        IsGoodReview = (bool)dataReader["type"]
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
                cmd.AddParameter("@Phone", infrastructureObjectReview.Phone);
                cmd.AddParameter("@Type", infrastructureObjectReview.IsGoodReview);

                return (long)(ulong)cmd.ExecuteScalar();
            }
        }
    }
}