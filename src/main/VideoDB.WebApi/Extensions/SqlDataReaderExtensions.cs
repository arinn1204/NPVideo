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
            int index = 0;
            foreach (var property in returnObject.GetType().GetProperties())
            {
                (object value, int returnedIndex) = GetProperValue(reader, property.PropertyType, index);
                index = returnedIndex;
                property.SetValue(returnObject, value);
            }

            return returnObject;
        }

        private static (object value, int index) GetProperValue(SqlDataReader reader, Type propertyType, int index)
        {
            object value;
            switch(propertyType.Name)
            {
                case "String":
                    value = reader.GetString(index++);
                    break;
                case "DateTime":
                    value = reader.GetDateTime(index++);
                    break;
                case "Decimal":
                    value = reader.GetDecimal(index++);
                    break;
                default:
                    throw new EvoException("Unsupoorted type attempting to be converted");
            }

            return (value, index);
        }
    }
}
