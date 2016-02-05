using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableQueryParser.Core
{
    public static class QueryParser
    {
        public static bool Validate<T>(string query, T data) where T : TableEntity
        {
            return ExpressionList
                .From(new Statement(query, 0))
                .Resolve(data);
        }

        public static IEnumerable<T> Filter<T>(string query, IEnumerable<T> data) where T : TableEntity
        {
            var expressionList = ExpressionList.From(new Statement(query, 0));
            return data.Where(expressionList.Resolve);
        }
    }
}