using MySql.Data.MySqlClient;
using System.Data.Common;

namespace GeoPrototypeWebApi.Facades
{
    public class DbBaseFacade
    {
        public string ConnectionString { get; set; }

        // строки запросов
        public ISqlStrings SqlStrings { get; } = new SqlStrings();

        public DbBaseFacade()
        {
            ConnectionString = "Server=sv4.surayfer.com;Database=geoinfo;Uid=geoinfo;Pwd=tOrJNcnryhLTljjX;SslMode=none;";
        }

        /// <summary>
        /// Получить коннекшн к БД. Использовать через using
        /// </summary>
        /// <returns></returns>
        protected DbConnection GetDbConnection()
        {
            var conn = new MySqlConnection(ConnectionString);
            conn.Open();

            return conn;
        }
    }
}
