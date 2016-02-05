using System.Collections.Generic;
using System.Linq;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Core
{
    internal class Statement
    {
        private readonly string _queryString;
        private readonly int _id;

        public Statement(string queryString, int id)
        {
            _id = id;
            _queryString = queryString;
        }

        public IExpression Substitute(List<Statement> statements)
        {
            return ExpressionFactory.From(statements.Aggregate(_queryString, (current, statement) => current.Replace(statement._queryString, statement._id.ToString())));
        }

        public override string ToString()
        {
            return _queryString;
        }
    }
}