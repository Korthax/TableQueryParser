using System.Collections.Generic;

namespace TableQueryParser.Core.Expressions
{
    internal class Not : IExpression
    {
        private readonly int _index;

        public Not(int index)
        {
            _index = index;
        }

        public bool Resolve<T>(T testObject, List<IExpression> expressions)
        {
            return expressions[_index].Resolve(testObject, expressions) == false;
        }

        public override string ToString()
        {
            return string.Format("!{0}", _index);
        }
    }
}