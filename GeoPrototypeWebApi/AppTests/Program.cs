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

        protected static void PostImage()
        {
            var data = new ReviewImage
            {
                MimeType = "image/bmp",
                Image = new byte[]
                {
                    (byte)0x42, (byte)0x4D, (byte)0x3A, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x36, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x28, (byte)0x00,
                    (byte)0x00, (byte)0x00, (byte)0x01, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x01, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x01, (byte)0x00, (byte)0x18, (byte)0x00, (byte)0x00, (byte)0x00,
                    (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0xC4, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0xC4, (byte)0x0E, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00,
                    (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF
                }
            };

            var facade = new InfrastructureObjectReviewImagesFacade();
            facade.InsertImage(8, data);
        }

        static void Main(string[] args)
        {
            //GetNearObjects();
            //PostReview();
            PostImage();
        }
    }
}
