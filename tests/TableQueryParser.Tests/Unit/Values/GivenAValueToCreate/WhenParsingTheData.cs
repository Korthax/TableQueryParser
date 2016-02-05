using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAValueToCreate
{
    [TestFixture]
    public class WhenParsingTheData
    {
        [TestCase("datetime'2015-01-03T00:00:00.0000000Z'", typeof(DateTimeValue))]
        [TestCase("guid'FCFA4232-CAD2-11E5-ABD4-D5A2901F17A3'", typeof(GuidValue))]
        [TestCase("'this is a string'", typeof(StringValue))]
        [TestCase("true", typeof(BooleanValue))]
        [TestCase("false", typeof(BooleanValue))]
        [TestCase("88", typeof(NumericValue))]
        [TestCase("UNKNOWN TYPE", typeof(UnknownValue))]
        public void ThenTheCorrectValueTypeIsCreated(string data, Type expectedType)
        {
            var result = ValueFactory.From(data);
            Assert.That(result, Is.TypeOf(expectedType));
        }
    }
}