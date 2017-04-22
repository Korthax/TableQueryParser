namespace TableQueryParser.Core.Values
{
    internal class StringValue : IValue
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public bool LessThan(object value)
        {
            if (value is string)
                return _value.CompareTo(value) > 0;
            return false;
        }

        public bool GreaterThan(object value)
        {
            if(value is string)
                return _value.CompareTo(value) < 0;
            return false;
        }

        public bool EqualTo(object value)
        {
            if (value is string)
                return _value.Equals(value);
            return false;
        }

        public override string ToString()
        {
            return $"\"{_value}\"";
        }
    }
}