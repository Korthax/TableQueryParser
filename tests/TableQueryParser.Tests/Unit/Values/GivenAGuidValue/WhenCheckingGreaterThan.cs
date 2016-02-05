using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAGuidValue
{
    [TestFixture]
    public class WhenCheckingGreaterThan
    {
        [TestCase("0949b6ea-4015-44ce-926d-3baa97e3b45d", "fe7d8c61-d1d5-46f7-9a5b-3793df2dfa12")]
        [TestCase("0949b6ea-4015-44ce-926d-3baa97e3b45d", "7518ca7a-8393-4882-b65a-1029ea8b067d")]
        public void ThenGuidsAfterMatchCorrectly(string value, string input)
        {
            var subject = new GuidValue(new Guid(value));
            Assert.That(subject.GreaterThan(new Guid(input)), Is.True);
        }

        [TestCase("fe7d8c61-d1d5-46f7-9a5b-3793df2dfa12", "f5401c8a-d8a5-44bb-8718-d8799f75c16e")]
        [TestCase("fe7d8c61-d1d5-46f7-9a5b-3793df2dfa12", "7518ca7a-8393-4882-b65a-1029ea8b067d")]
        public void ThenGuidsBeforeDoNotMatch(string value, string input)
        {
            var subject = new GuidValue(new Guid(value));
            Assert.That(subject.GreaterThan(new Guid(input)), Is.False);
        }

        [TestCase("f5401c8a-d8a5-44bb-8718-d8799f75c16e", "f5401c8a-d8a5-44bb-8718-d8799f75c16e")]
        public void ThenEqualGuidsAreNotGreater(string value, string input)
        {
            var subject = new GuidValue(new Guid(value));
            Assert.That(subject.GreaterThan(new Guid(input)), Is.False);
        }
    }
}