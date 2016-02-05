namespace TableQueryParser.Core.Values
{
    internal interface IValue
    {
        bool LessThan(object value);
        bool GreaterThan(object value);
        bool EqualTo(object value);
    }
}