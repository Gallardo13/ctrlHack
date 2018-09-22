using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace GeoPrototypeWebApi.Controllers
{
    public class DbConstollerBase : Controller
    {
        public string ConnectionString {get;set;}

        public DbConstollerBase()
        {
            ConnectionString = "Server=sv4.surayfer.com;Database=geoinfo;Uid=geoinfo;Pwd=tOrJNcnryhLTljjX;";
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
