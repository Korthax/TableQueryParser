using System.Collections.Generic;

namespace TableQueryParser.Core.Expressions
{
    internal class Or : IExpression
    {
        private readonly int _left;
        private readonly int _right;

        public Or(int left, int right)
        {
            _left = left;
            _right = right;
        }

        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            return expressions[_left].Resolve(testObject, expressions) || expressions[_right].Resolve(testObject, expressions);
        }

        public override string ToString()
        {
            return string.Format("{0} OR {1}", _left, _right);
        }
    }
}