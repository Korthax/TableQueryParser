using System.Collections.Generic;

namespace TableQueryParser.Core.Expressions
{
    internal class GoTo : IExpression
    {
        private readonly int _index;

        public GoTo(int index)
        {
            _index = index;
        }

        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            return expressions[_index].Resolve(testObject, expressions);
        }

        public override string ToString()
        {
            return string.Format("GOTO {0}", _index);
        }
    }
}