using System.Collections.Generic;

namespace TableQueryParser.Core.Expressions
{
    internal interface IExpression
    {
        bool Resolve<T>(T testObject, List<IExpression> expressions);
    }
}