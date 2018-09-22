using GeoPrototypeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace GeoPrototypeWebApi.Facades
{
    public class MobileDataFacade : DbBaseFacade
    {
        // перевод градусов в радианы
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        // прямоугольник поиска в километрах
        const double delta = 0.3;

        // получить список объектов рядом с определенной точкой
        IEnumerable<InfrastructureObjectsMobileInfo> GetNearObjects(double latitude, double longitude)
        {
            var retVal = new List<InfrastructureObjectsMobileInfo>();

            // найдем дельту долготы
            var deltaLatitude = 111.3 * delta;
            var deltaLongtitude = Math.Cos(DegreeToRadian(latitude)) / 111.3 * delta;

            using (var db = GetDbConnection())
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = SqlStrings.GetNearObjects;
                cmd.Parameters.Add("@LatitudeFrom", latitude - deltaLatitude);
                cmd.Parameters.Add("@LatitudeTo", latitude + deltaLatitude);
                cmd.Parameters.Add("@LongitudeFrom", longitude - deltaLongtitude);
                cmd.Parameters.Add("@LongitudeTo", longitude + deltaLongtitude);

                var dataReader = cmd.ExecuteReader();

                while(dataReader.Read())
                    retVal.Add(new InfrastructureObjectsMobileInfo
                    {
                        Id = (int)dataReader["id"],
                        Description = (string)dataReader["description"],
                        Latitude = (double)dataReader["latitude"],
                        Longitude = (double)dataReader["longitude"]
                    });
            }

            return retVal;
        }
    }
}
