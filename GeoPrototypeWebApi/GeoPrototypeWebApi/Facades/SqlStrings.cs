using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoPrototypeWebApi.Facades
{
    public interface ISqlStrings
    {
        string GetNearObjects { get; }

        string GetObjectsByYear { get; }

        string GetObjectById { get; set; }
    }

    public class SqlStrings : ISqlStrings
    {
        public string GetNearObjects => "";

        public string GetObjectsByYear => "";

        public string GetObjectById => "";
    }
}
