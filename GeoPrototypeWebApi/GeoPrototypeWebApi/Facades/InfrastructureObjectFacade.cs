using GeoPrototypeWebApi.Models;
using System;
using System.Collections.Generic;

namespace GeoPrototypeWebApi.Facades
{
    public class InfrastructureObjectFacade : DbBaseFacade
    {
        public IEnumerable<InfrastructureObjectMapInfo> GetObjectsByYear(int year, decimal startLon, decimal startLat, decimal endLon, decimal endLat) 
        {
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection()) 
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectsByYear;

                var dateFrom = new DateTime(year, 1, 1);
                var dateTo = new DateTime(year, 12, 31);

                cmd.AddParameter("@DateFrom", dateFrom);
                cmd.AddParameter("@DateTo", dateTo);
                cmd.AddParameter("@LongitudeFrom", startLon);
                cmd.AddParameter("@LatitudeFrom", startLat);
                cmd.AddParameter("@LongitudeTo", endLon);
                cmd.AddParameter("@LatitudeTo", endLat);


                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var databaseObject = new InfrastructureObjectDatabaseInfo
                    {
                        Id = (long)dataReader["id"],
                        Address = dataReader.GetNullableString("address"),
                        ObjectType = dataReader.GetNullableString("object_type"),
                        Latitude = dataReader.GetNullable<decimal>("latitude"),
                        Longitude = dataReader.GetNullable<decimal>("longitude"),

                        ContractNumber = (string)(dataReader["contract_number"] == DBNull.Value ? "" : dataReader["contract_number"]),
                        TempAddress = (string)(dataReader["temp_address"] == DBNull.Value ? "" : dataReader["temp_address"]),
                        TempObjectType = (string)(dataReader["temp_object_type"] == DBNull.Value ? "" : dataReader["temp_object_type"]),
                        WorkType = (string)(dataReader["work_type"] == DBNull.Value ? "" : dataReader["work_type"]),
                        StartDate = (DateTime)(dataReader["start_date"] == DBNull.Value ? null : dataReader["start_date"]),
                        FinishDate = (DateTime)(dataReader["finish_date"] == DBNull.Value ? null : dataReader["finish_date"]),
                        CustomerName = (string)(dataReader["customer_name"] == DBNull.Value ? "" : dataReader["customer_name"]),
                        CustomerPhone = (string)(dataReader["customer_phone"] == DBNull.Value ? "" : dataReader["customer_phone"]),
                        ContractorName = (string)(dataReader["contractor_name"] == DBNull.Value ? "" : dataReader["contractor_name"]),
                        ContractorPhone = (string)(dataReader["contractor_phone"] == DBNull.Value ? "" : dataReader["contractor_phone"]),
                        Url = (string)(dataReader["contract_url"] == DBNull.Value ? "" : dataReader["contract_url"]),
                        Description = (string)(dataReader["description"] == DBNull.Value ? "" : dataReader["description"])
                    };


                    var mapObject = new InfrastructureObjectMapInfo();
                    mapObject.ConvertToMapObject(databaseObject);
                    retVal.Add(mapObject);
                }
            }

            return retVal;
        }

        public IEnumerable<InfrastructureObjectMapInfo> GetObjectById(int id) 
        {
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectById;

                cmd.AddParameter("@id", id);

                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var databaseObject = new InfrastructureObjectDatabaseInfo
                    {
                        Id = (long)dataReader["id"],
                        ContractNumber = (string)(dataReader["contract_number"] == DBNull.Value ? "" : dataReader["contract_number"]),
                        Address = (string)(dataReader["address"] == DBNull.Value ? "" : dataReader["address"]),
                        TempAddress = (string)(dataReader["temp_address"] == DBNull.Value ? "" : dataReader["temp_address"]),
                        Latitude = (decimal)(dataReader["latitude"] == DBNull.Value ? new decimal() : dataReader["latitude"]),
                        Longitude = (decimal)(dataReader["longitude"] == DBNull.Value ? new decimal() : dataReader["longitude"]),
                        TempObjectType = (string)(dataReader["temp_object_type"] == DBNull.Value ? "" : dataReader["temp_object_type"]),
                        ObjectType = (string)(dataReader["object_type"] == DBNull.Value ? "" : dataReader["object_type"]),
                        WorkType = (string)(dataReader["work_type"] == DBNull.Value ? "" : dataReader["work_type"]),
                        StartDate = (DateTime)(dataReader["start_date"] == DBNull.Value ? null : dataReader["start_date"]),
                        FinishDate = (DateTime)(dataReader["finish_date"] == DBNull.Value ? null : dataReader["finish_date"]),
                        CustomerName = (string)(dataReader["customer_name"] == DBNull.Value ? "" : dataReader["customer_name"]),
                        CustomerPhone = (string)(dataReader["customer_phone"] == DBNull.Value ? "" : dataReader["customer_phone"]),
                        ContractorName = (string)(dataReader["contractor_name"] == DBNull.Value ? "" : dataReader["contractor_name"]),
                        ContractorPhone = (string)(dataReader["contractor_phone"] == DBNull.Value ? "" : dataReader["contractor_phone"]),
                        Url = (string)(dataReader["contract_url"] == DBNull.Value ? "" : dataReader["contract_url"]),
                        Description = (string)(dataReader["description"] == DBNull.Value ? "" : dataReader["description"])
                    };

                    var mapObject = new InfrastructureObjectMapInfo();
                    mapObject.ConvertToMapObject(databaseObject);
                    retVal.Add(mapObject);
                }
            }

            return retVal;
        }

        public IEnumerable<InfrastructureObjectMapInfo> GetObjectByIds(int[] ids)
        {
            var retVal = new List<InfrastructureObjectMapInfo>();

            using (var connection = GetDbConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = SqlStrings.GetObjectByIds;
                cmd.CommandText = cmd.CommandText.Replace("@ids", String.Format("({0})", String.Join(",", ids)));

                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var databaseObject = new InfrastructureObjectDatabaseInfo
                    {
                        Id = (long)dataReader["id"],
                        ContractNumber = (string)(dataReader["contract_number"] == DBNull.Value ? "" : dataReader["contract_number"]),
                        Address = (string)(dataReader["address"] == DBNull.Value ? "" : dataReader["address"]),
                        TempAddress = (string)(dataReader["temp_address"] == DBNull.Value ? "" : dataReader["temp_address"]),
                        Latitude = (decimal)(dataReader["latitude"] == DBNull.Value ? new decimal() : dataReader["latitude"]),
                        Longitude = (decimal)(dataReader["longitude"] == DBNull.Value ? new decimal() : dataReader["longitude"]),
                        TempObjectType = (string)(dataReader["temp_object_type"] == DBNull.Value ? "" : dataReader["temp_object_type"]),
                        ObjectType = (string)(dataReader["object_type"] == DBNull.Value ? "" : dataReader["object_type"]),
                        WorkType = (string)(dataReader["work_type"] == DBNull.Value ? "" : dataReader["work_type"]),
                        StartDate = (DateTime)(dataReader["start_date"] == DBNull.Value ? null : dataReader["start_date"]),
                        FinishDate = (DateTime)(dataReader["finish_date"] == DBNull.Value ? null : dataReader["finish_date"]),
                        CustomerName = (string)(dataReader["customer_name"] == DBNull.Value ? "" : dataReader["customer_name"]),
                        CustomerPhone = (string)(dataReader["customer_phone"] == DBNull.Value ? "" : dataReader["customer_phone"]),
                        ContractorName = (string)(dataReader["contractor_name"] == DBNull.Value ? "" : dataReader["contractor_name"]),
                        ContractorPhone = (string)(dataReader["contractor_phone"] == DBNull.Value ? "" : dataReader["contractor_phone"]),
                        Url = (string)(dataReader["contract_url"] == DBNull.Value ? "" : dataReader["contract_url"]),
                        Description = (string)(dataReader["description"] == DBNull.Value ? "" : dataReader["description"])
                    };

                    var mapObject = new InfrastructureObjectMapInfo();
                    mapObject.ConvertToMapObject(databaseObject);
                    retVal.Add(mapObject);
                }
            }

            return retVal;
        }
    }
}
