using System;

namespace TableQueryParser.Core.Values
{
    internal class UnknownValue : IValue
    {
        public bool LessThan(object value)
        {
            throw new InvalidOperationException();
        }

        public bool GreaterThan(object value)
        {
            throw new InvalidOperationException();
        }

        public bool EqualTo(object value)
        {
            throw new InvalidOperationException();
        }
    }
}