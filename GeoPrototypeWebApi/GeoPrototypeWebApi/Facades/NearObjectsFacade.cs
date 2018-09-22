using GeoPrototypeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace GeoPrototypeWebApi.Facades
{
    public class NearObjectsFacade : DbBaseFacade
    {
        // перевод градусов в радианы
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        // прямоугольник поиска в километрах
        const double delta = 111000;//0.3;

        // получить список объектов рядом с определенной точкой
        public IEnumerable<InfrastructureObjectsMobileInfo> GetNearObjects(double latitude, double longitude)
        {
            var retVal = new List<InfrastructureObjectsMobileInfo>();

            // найдем дельту долготы
            var deltaLatitude = 111.3 * delta;
            var deltaLongtitude = Math.Cos(DegreeToRadian(latitude)) / 111.3 * delta;

            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.GetNearObjects;
                cmd.AddParameter("@LatitudeFrom", latitude - deltaLatitude);
                cmd.AddParameter("@LatitudeTo", latitude + deltaLatitude);
                cmd.AddParameter("@LongitudeFrom", longitude - deltaLongtitude);
                cmd.AddParameter("@LongitudeTo", longitude + deltaLongtitude);

                var dataReader = cmd.ExecuteReader();

                while(dataReader.Read())
                    retVal.Add(new InfrastructureObjectsMobileInfo
                    {
                        Id = (long)dataReader["id"],
                        Description = (string)(dataReader["description"] == DBNull.Value ? "" : dataReader["description"]),
                        Latitude = (decimal)dataReader["latitude"],
                        Longitude = (decimal)dataReader["longitude"]
                    });
            }

            return retVal;
        }

        public void AddNearObjectReview(long id, string review)
        {

        }
    }
}
