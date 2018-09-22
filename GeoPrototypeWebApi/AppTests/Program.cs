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

        static void Main(string[] args)
        {
            GetNearObjects();
        }
    }
}
