using System;
using System.Globalization;

namespace TableQueryParser.Core.Values
{
    internal class LongNumericValue : IValue
    {
        private readonly long _value;

        public LongNumericValue(long value)
        {
            _value = value;
        }

        public bool LessThan(object value)
        {
            if (!IsNumeric(value, out long numeric))
                return false;

            return _value < numeric;
        }

        public bool GreaterThan(object value)
        {
            if (!IsNumeric(value, out long numeric))
                return false;

            return _value > numeric;
        }

        public bool EqualTo(object value)
        {
            if (!IsNumeric(value, out long numeric))
                return false;

            return _value == numeric;
        }

        private static bool IsNumeric(object expression, out long result)
        {
            result = 0;
            return expression != null && long.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out result);
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}