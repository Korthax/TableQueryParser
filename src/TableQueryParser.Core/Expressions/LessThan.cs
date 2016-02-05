using System.Collections.Generic;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Core.Expressions
{
    internal class LessThan : IExpression
    {
        private readonly IValue _right;
        private readonly string _left;

        public LessThan(string left, IValue right)
        {
            _left = left;
            _right = right;
        }

        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            var t = typeof(T).GetProperty(_left);
            if (t == null)
                return false;

            return _right.GreaterThan(t.GetValue(testObject));
        }

        public override string ToString()
        {
            return string.Format("{0} < {1}", _left, _right);
        }
    }
}