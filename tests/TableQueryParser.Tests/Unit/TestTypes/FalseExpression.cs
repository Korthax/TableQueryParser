using System.Collections.Generic;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Tests.Unit.TestTypes
{
    internal class FalseExpression : IExpression
    {
        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            return false;
        }
    }
}