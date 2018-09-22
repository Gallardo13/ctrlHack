using System;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Models
{
    public class InfrastructureObjectMapInfo
    {
        public long Id { get; set; }

        public MapPoint Coordinates { get; set; }

        public Dictionary<string, string> Data { get; set; }

        public InfrastructureObjectMapInfo() { }

        public void ConvertToMapObject(InfrastructureObjectDatabaseInfo databaseObjectInfo) 
        {
            Id = databaseObjectInfo.Id;
            Coordinates = new MapPoint(databaseObjectInfo.Latitude, databaseObjectInfo.Longitude);

            Data = new Dictionary<string, string>
            {
                { "ContractNumber", databaseObjectInfo.ContractNumber },
                { "Address", databaseObjectInfo.Address },
                { "TempAddress", databaseObjectInfo.TempAddress },
                { "ObjectType", databaseObjectInfo.ObjectType },
                { "TempObjectType", databaseObjectInfo.TempObjectType },
                { "WorkType", databaseObjectInfo.WorkType },
                { "StartDate", databaseObjectInfo.StartDate.ToString() },
                { "FinishDate", databaseObjectInfo.FinishDate.ToString() },
                { "CustomerName", databaseObjectInfo.CustomerName },
                { "CustomerPhone", databaseObjectInfo.CustomerPhone },
                { "ContractorName", databaseObjectInfo.ContractorName },
                { "ContractorPhone", databaseObjectInfo.ContractorPhone },
                { "Url", databaseObjectInfo.Url }
            };
        }
    }

    public class MapPoint 
    {
        public decimal X { get; set; }

        public decimal Y { get; set; }

        public MapPoint(decimal x, decimal y) 
        {
            X = x;
            Y = y;
        }
    }
}
