using Evo.WebApi.Exceptions;
using Microsoft.Data.SqlClient;
using System;

namespace VideoDB.WebApi.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static T CreateObject<T>(this SqlDataReader reader)
            where T : class, new()
        {
            var returnObject = new T();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                var schema = reader.GetColumnSchema();
                var columnName = schema[i].ColumnName;
                returnObject.GetType()
                    .GetProperty(columnName)
                    .SetValue(returnObject, GetProperValue(reader, schema[i].DataType, i));
            }

            return returnObject;
        }

        private static object GetProperValue(SqlDataReader reader, Type propertyType, int index)
        {
            object value;
            switch(propertyType.Name)
            {
                case "String":
                    value = reader.GetString(index);
                    break;
                case "DateTime":
                    value = reader.GetDateTime(index);
                    break;
                case "Decimal":
                    value = reader.GetDecimal(index);
                    break;
                case "Int32":
                    value = reader.GetInt32(index);
                    break;
                default:
                    throw new EvoException("Unsupoorted type attempting to be converted");
            }

            return value;
        }
    }
}
