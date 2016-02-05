using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Core
{
    internal class ExpressionList
    {
        private readonly List<IExpression> _expressions;

        public static ExpressionList From(Statement statement)
        {
            var id = 0;
            return new ExpressionList(BreakDown(statement, ref id));
        }
        
        private static List<IExpression> BreakDown(Statement query, ref int id)
        {
            var results = new List<IExpression>();

            var statements = FindNested(query, ref id);
            results.Add(query.Substitute(statements));

            foreach (var variable in statements)
                results.AddRange(BreakDown(variable, ref id));

            return results;
        }

        private static List<Statement> FindNested(Statement statement, ref int id)
        {
            var query = statement.ToString();
            var results = new List<Statement>();
            while (query != null)
            {
                var currentExpression = GetValue(ref query);
                if (currentExpression == null)
                    return results;

                results.Add(new Statement(currentExpression, ++id));
            }

            return results;
        }

        private static string GetValue(ref string query)
        {
            var start = -1;
            var indentation = 0;
            for (var i = 0; i < query.Length; i++)
            {
                if (query[i] == '(')
                {
                    if (start == -1)
                        start = i + 1;
                    indentation++;
                }
                else if (query[i] == ')')
                {
                    indentation--;

                    if (indentation != 0)
                        continue;

                    var value = string.Join("", query.Skip(start).Take(i - start));
                    query = query.Remove(start - 1, i - (start - 1) + 1);
                    return value;
                }
            }

            return null;
        }

        public ExpressionList(List<IExpression> expressions)
        {
            _expressions = expressions;
        }

        public bool Resolve<T>(T data)
        {
            return _expressions[0].Resolve(data, _expressions);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for(var i = 0; i < _expressions.Count; i++)
                stringBuilder.AppendLine(string.Format("{0}| {1}", i, _expressions[i]));

            return stringBuilder.ToString();
        }
    }
}