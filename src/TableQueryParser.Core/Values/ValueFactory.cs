using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TableQueryParser.Core.Values
{
    internal static class ValueFactory
    {
        public static IValue From(string data)
        {
            if (data.StartsWith("datetime"))
                return new DateTimeValue(DateTimeOffset.Parse(GetValue(data)));

            if (data.StartsWith("guid"))
                return new GuidValue(Guid.Parse(GetValue(data)));

            if (data.StartsWith("'") && data.EndsWith("'"))
                return new StringValue(GetValue(data));

            if (data.Equals("true") || data.Equals("false"))
                return new BooleanValue(bool.Parse(data));

            if (double.TryParse(data, NumberStyles.Number, CultureInfo.CurrentCulture, out double number))
                return new NumericValue(number);

            if (long.TryParse(data.TrimEnd('L', 'l'), NumberStyles.Number, CultureInfo.CurrentCulture, out long longNumber))
                return new LongNumericValue(longNumber);

            return new UnknownValue();
        }

        private static string GetValue(string data)
        {
            var match = Regex.Match(data, @"'([^']*)");
            return match.Success ? match.Groups[1].Value : null;
        }
    }
}