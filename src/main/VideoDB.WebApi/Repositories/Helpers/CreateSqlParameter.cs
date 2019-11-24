using Evo.WebApi.Models.Requests;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Repositories.Helpers
{
    public static class CreateSqlParameter
    {
        public static void AddTableParameter(string paramName, DataTable tableToAdd, SqlCommand command)
        {
            var param = command.Parameters.AddWithValue(paramName, tableToAdd);
            param.SqlDbType = SqlDbType.Structured;
        }

        public static SqlParameter CreateParameter(string name, string value)
        {
            var param = new SqlParameter(name, value)
            {
                SqlDbType = SqlDbType.VarChar
            };

            return param;
        }

        public static SqlParameter CreateParameter(string name, decimal value)
        {
            var param = new SqlParameter(name, value)
            {
                SqlDbType = SqlDbType.Decimal
            };

            return param;
        }

        public static SqlParameter CreateParameter(string name, DateTime value)
        {
            var param = new SqlParameter(name, value)
            {
                SqlDbType = SqlDbType.DateTime
            };

            return param;
        }

        public static DataTable CreateDataTable(IEnumerable<GenreRequest> requests)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));

            foreach (var request in requests)
            {
                dataTable.Rows.Add(request.Name);
            }

            return dataTable;
        }

        public static DataTable CreateDataTable(IEnumerable<StarRequest> requests)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("first_name", typeof(string));
            dataTable.Columns.Add("middle_name", typeof(string));
            dataTable.Columns.Add("last_name", typeof(string));
            dataTable.Columns.Add("suffix", typeof(string));
            dataTable.Columns.Add("role_name", typeof(string));

            foreach (var request in requests)
            {
                dataTable.Rows.Add(
                    request.FirstName,
                    request.MiddleName,
                    request.LastName,
                    request.Suffix,
                    request.Role.ToString());
            }

            return dataTable;
        }

        public static DataTable CreateDataTable(IEnumerable<RatingRequest> requests)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("source", typeof(string));
            dataTable.Columns.Add("value", typeof(string));

            foreach (var request in requests)
            {
                dataTable.Rows.Add(request.Source, request.RatingValue);
            }

            return dataTable;
        }
    }
}
