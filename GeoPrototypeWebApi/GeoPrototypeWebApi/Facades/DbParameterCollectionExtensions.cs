using System.Data.Common;

namespace GeoPrototypeWebApi.Facades
{
    public static class DbParameterCollectionExtensions
    {
        public static void Add(this DbParameterCollection collection, string name, object value) =>
            collection[collection.Add(value)].ParameterName = name;
    }
}
