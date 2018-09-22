using GeoPrototypeWebApi.Controllers;
using GeoPrototypeWebApi.Facades;
using System;

namespace AppTests
{
    class Program
    {
        protected static void GetNearObjects()
        {
            var facade = new NearObjectsFacade();
            facade.GetNearObjects(54.882600, 20.514400);
        }

        protected static void PostReview()
        {
            var data = new InfrastructureObjectReview
            {
                InfrastructureObjectId = 1,
                ReviewText = "awdasdasd",
                UserName = "sada"
            };

            var facade = new InfrastructureObjectReviewsFacade();
            var retVal = facade.InsertReview(data);
        }

        protected static void ReadReview()
        {
            var facade = new InfrastructureObjectReviewsFacade();
            var retVal = facade.ReadReviewById(1);
        }

        protected static void PostImage()
        {
            var data = new ReviewImage
            {
                MimeType = "image/bmp",
                Image = new byte[]
                {
                    0x42, 0x4D, 0x3A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00, 0x28, 0x00,
                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC4, 0x00, 0x00, 0x00, 0xC4, 0x0E, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF
                }
            };

            var facade = new InfrastructureObjectReviewImagesFacade();
            facade.InsertImage(8, data);
        }

        static void Main(string[] args)
        {
            //GetNearObjects();
            //PostReview();
            //ReadReview();
            PostImage();
        }
    }
}
