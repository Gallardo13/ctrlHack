using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoPrototypeWebApi.Facades
{
    public interface ISqlStrings
    {
        string GetNearObjects { get; }
    }

    public class SqlStrings : ISqlStrings
    {
        public string GetNearObjects => "";
    }
}
