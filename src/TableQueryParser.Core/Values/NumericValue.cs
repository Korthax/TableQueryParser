using System;
using System.Globalization;

namespace TableQueryParser.Core.Values
{
    internal class NumericValue : IValue
    {
        private readonly double _value;

        public NumericValue(double value)
        {
            _value = value;
        }

        public bool LessThan(object value)
        {
            if (!IsNumeric(value, out double numeric))
                return false;

            return _value < numeric;
        }

        public bool GreaterThan(object value)
        {
            if (!IsNumeric(value, out double numeric))
                return false;

            return _value > numeric;
        }

        public bool EqualTo(object value)
        {
            if (!IsNumeric(value, out double numeric))
                return false;

            return Math.Abs(_value - numeric) < double.Epsilon;
        }

        private static bool IsNumeric(object expression, out double result)
        {
            result = 0;

            return expression != null && double.TryParse(Convert.ToString(expression, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out result);
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}