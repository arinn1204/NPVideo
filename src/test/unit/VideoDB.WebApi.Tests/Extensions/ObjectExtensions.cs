using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VideoDB.WebApi.Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static TObject Modify<TObject, TProp>(
            this TObject objectToModify,
            Expression<Func<TObject, TProp>> propertyToModify,
            TProp setValue)
        {
            var propertyName = (propertyToModify.Body as MemberExpression)
                .Member
                .Name;

            objectToModify.GetType()
                .GetProperty(propertyName)
                .SetValue(objectToModify, setValue);

            return objectToModify;
        }
    }
}
