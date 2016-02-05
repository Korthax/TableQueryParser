using System.Collections.Generic;

namespace TableQueryParser.Core.Expressions
{
    internal class And : IExpression
    {
        private readonly int _right;
        private readonly int _left;

        public And(int left, int right)
        {
            _left = left;
            _right = right;
        }

        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            return expressions[_left].Resolve(testObject, expressions) && expressions[_right].Resolve(testObject, expressions);
        }

        public override string ToString()
        {
            return string.Format("{0} AND {1}", _left, _right);
        }
    }
}