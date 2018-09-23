namespace GeoPrototypeWebApi.Controllers
{
    public class ReviewImage
    {
        public long Id { get; set; }

        public long ReviewId { get; set; }

        public string MimeType { get; set; }

        public string Image { get; set; }
    }
}