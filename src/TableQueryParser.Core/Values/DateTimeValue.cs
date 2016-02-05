using System;
using System.Globalization;

namespace TableQueryParser.Core.Values
{
    internal class DateTimeValue : IValue
    {
        private readonly DateTimeOffset _value;

        public DateTimeValue(DateTimeOffset value)
        {
            _value = value;
        }

        public bool LessThan(object value)
        {
            if (value is DateTime || value is DateTimeOffset)
                return _value < (DateTimeOffset)value;
            return false;
        }

        public bool GreaterThan(object value)
        {
            if (value is DateTime || value is DateTimeOffset)
                return _value > (DateTimeOffset)value;
            return false;
        }

        public bool EqualTo(object value)
        {
            if (value is DateTime || value is DateTimeOffset)
                return _value.Equals((DateTimeOffset)value);
            return false;
        }

        public override string ToString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }
    }
}