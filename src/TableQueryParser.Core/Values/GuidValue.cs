using System;

namespace TableQueryParser.Core.Values
{
    internal class GuidValue : IValue
    {
        private readonly Guid _value;

        public GuidValue(Guid value)
        {
            _value = value;
        }

        public bool LessThan(object value)
        {
            if(!(value is Guid))
                return false;

            return _value.CompareTo(value) > 0;
        }

        public bool GreaterThan(object value)
        {
            if (!(value is Guid))
                return false;

            return _value.CompareTo(value) < 0;
        }

        public bool EqualTo(object value)
        {
            if (!(value is Guid))
                return false;

            return _value.Equals((Guid)value);
        }

        public override string ToString()
        {
            return string.Format("'{0}'", _value);
        }
    }
}