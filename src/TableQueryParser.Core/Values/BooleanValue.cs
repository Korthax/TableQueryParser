using System;

namespace TableQueryParser.Core.Values
{
    internal class BooleanValue : IValue
    {
        private readonly bool _value;

        public BooleanValue(bool value)
        {
            _value = value;
        }

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
            if(value is bool)
                return _value == (bool)value;
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}", _value);
        }
    }
}