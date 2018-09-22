using System;
namespace GeoPrototypeWebApi.Models
{
    public class InfrastructureObjectDatabaseInfo
    {
        public long Id { get; set; }

        public string ContractNumber { get; set; }

        public string TempAddress { get; set; }

        public string Address { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

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

        public string Description { get; set; }

        public InfrastructureObjectDatabaseInfo() { }
    }
}
