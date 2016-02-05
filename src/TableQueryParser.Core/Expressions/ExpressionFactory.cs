using System;
using System.Reflection;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Core.Expressions
{
    internal static class ExpressionFactory
    {
        public static IExpression From(string queryString)
        {
            var query = queryString.Replace("(", "").Replace(")", "").TrimStart(' ').TrimEnd(' ');
            var strings = query.Split(' ');

            if (strings.Length == 1)
                return new GoTo(Int32.Parse(strings[0]));

            if (strings.Length == 2 && strings[0] == "not")
                return new Not(Int32.Parse(strings[1]));

            if (strings.Length != 3)
                throw new InvalidFilterCriteriaException();

            if(strings[1] == "or")
                return new Or(Int32.Parse(strings[0]), Int32.Parse(strings[2]));

            if(strings[1] == "and")
                return new And(Int32.Parse(strings[0]), Int32.Parse(strings[2]));

            if(strings[1] == "eq")
                return new EqualTo(strings[0], ValueFactory.From(strings[2]));

            if(strings[1] == "ne")
                return new NotEqualTo(strings[0], ValueFactory.From(strings[2]));

            if (strings[1] == "lt")
                return new LessThan(strings[0], ValueFactory.From(strings[2]));

            if (strings[1] == "le")
                return new LessThanOrEqualTo(strings[0], ValueFactory.From(strings[2]));

            if (strings[1] == "gt")
                return new GreaterThan(strings[0], ValueFactory.From(strings[2]));

            if (strings[1] == "ge")
                return new GreaterThanOrEqualTo(strings[0], ValueFactory.From(strings[2]));

            throw new InvalidFilterCriteriaException();
        }
    }
}