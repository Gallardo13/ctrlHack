using System;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Models
{
    public class InfrastructureObjectMapInfo
    {
        public long Id { get; set; }

        public MapPoint Coordinates { get; set; }

        public Dictionary<string, string> Data { get; set; }

        public InfrastructureObjectMapInfo()
        {
        }

        public void ConvertToMapObject(InfrastructureObjectDatabaseInfo databaseObjectInfo) 
        {
            Id = databaseObjectInfo.Id;
            Coordinates = new MapPoint(databaseObjectInfo.Latitude, databaseObjectInfo.Longitude);

            Data = new Dictionary<string, string>();

            Data.Add("ContractNumber", databaseObjectInfo.ContractNumber);
            Data.Add("Address", databaseObjectInfo.Address);
            Data.Add("TempAddress", databaseObjectInfo.TempAddress);
            Data.Add("ObjectType", databaseObjectInfo.ObjectType);
            Data.Add("TempObjectType", databaseObjectInfo.TempObjectType);
            Data.Add("WorkType", databaseObjectInfo.WorkType);
            Data.Add("StartDate", databaseObjectInfo.StartDate.ToString());
            Data.Add("FinishDate", databaseObjectInfo.FinishDate.ToString());
            Data.Add("CustomerName", databaseObjectInfo.CustomerName);
            Data.Add("CustomerPhone", databaseObjectInfo.CustomerPhone);
            Data.Add("ContractorName", databaseObjectInfo.ContractorName);
            Data.Add("ContractorPhone", databaseObjectInfo.ContractorPhone);
            Data.Add("Url", databaseObjectInfo.Url);

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
