using System.Data.Common;

namespace GeoPrototypeWebApi
{
    public static class DbParameterCollectionExtensions
    {
        public static void AddParameter(this DbCommand command, string name, object value)
        {
            var param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = value;

            command.Parameters.Add(param);
        }
    }
}
