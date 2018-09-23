namespace GeoPrototypeWebApi.Controllers
{
    public class InfrastructureObjectReview
    {
        public long Id { get; set; }

        public long InfrastructureObjectId { get; set; }

        public string UserName { get; set; }

        public string ReviewText { get; set; }

        public bool IsGoodReview { get; set; }

        public string Phone { get; set; }
    }
}