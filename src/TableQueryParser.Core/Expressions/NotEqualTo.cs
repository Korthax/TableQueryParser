using System.Collections.Generic;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Core.Expressions
{
    internal class NotEqualTo : IExpression
    {
        private readonly string _left;
        private readonly IValue _right;

        public NotEqualTo(string left, IValue right)
        {
            _left = left;
            _right = right;
        }

        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            var t = typeof(T).GetProperty(_left);
            if (t == null)
                return false;

            return !_right.EqualTo(t.GetValue(testObject));
        }

        public override string ToString()
        {
            return string.Format("{0} != {1}", _left, _right);
        }
    }
}