using System;
namespace GeoPrototypeWebApi.Models
{
    public class InfrastructureObjectMapInfo
    {

        public int Id { get; set; }

        public string TempAddress { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public string TempObjectType { get; set; }

        public string ObjectType { get; set; }

        public string WorkType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string ContractorName { get; set; }

        public string ContractorPhone { get; set; }

        public string Url { get; set; }



        public ObjectMapInfo()
        {
        }
    }
}
