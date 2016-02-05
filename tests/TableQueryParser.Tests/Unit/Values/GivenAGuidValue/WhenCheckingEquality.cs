using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAGuidValue
{
    [TestFixture]
    public class WhenCheckingEquality
    {
        [TestCase("f5401c8a-d8a5-44bb-8718-d8799f75c16e", "f5401c8a-d8a5-44bb-8718-d8799f75c16e")]
        [TestCase("0949b6ea-4015-44ce-926d-3baa97e3b45d", "0949b6ea-4015-44ce-926d-3baa97e3b45d")]
        public void ThenEqualGuidsMatchCorrectly(string value, string input)
        {
            var subject = new GuidValue(new Guid(value));
            Assert.That(subject.EqualTo(new Guid(input)), Is.True);
        }

        [TestCase("0949b6ea-4015-44ce-926d-3baa97e3b45d", "7518ca7a-8393-4882-b65a-1029ea8b067d")]
        [TestCase("fe7d8c61-d1d5-46f7-9a5b-3793df2dfa12", "0949b6ea-4015-44ce-926d-3baa97e3b45d")]
        public void ThenDifferentGuidsDoNotMatch(string value, string input)
        {
            var subject = new GuidValue(new Guid(value));
            Assert.That(subject.EqualTo(new Guid(input)), Is.False);
        }
    }
}