using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableQueryParser.Core
{
    public static class TableQueryExtensions
    {
        public static bool Validate<T>(this TableQuery<T> query, T data) where T : TableEntity
        {
            return QueryParser.Validate(query.FilterString, data);
        }

        public static IEnumerable<T> Filter<T>(this TableQuery<T> query, IEnumerable<T> data) where T : TableEntity
        {
            return QueryParser.Filter(query.FilterString, data);
        }
    }
}