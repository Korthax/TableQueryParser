using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenADateTime
{
    [TestFixture]
    public class WhenCheckingGreaterThan
    {
        [TestCase("1991-01-24T14:32:00", "1990-01-24T14:32:00")]
        [TestCase("1991-01-24T14:32:00", "1991-01-23T14:32:00")]
        [TestCase("1991-01-24T14:32:00", "1991-01-24T13:32:00")]
        [TestCase("1991-01-24T14:32:00", "1991-01-24T14:31:00")]
        public void ThenDateTimesAfterMatchCorrectly(string value, string input)
        {
            var subject = new DateTimeValue(DateTimeOffset.Parse(value));
            Assert.That(subject.GreaterThan(DateTimeOffset.Parse(input)), Is.True);
        }

        [TestCase("1991-01-24T14:32:00", "1992-01-24T14:32:00")]
        [TestCase("1991-01-24T14:32:00", "1991-02-24T14:32:00")]
        [TestCase("1991-01-24T14:32:00", "1991-01-24T15:32:00")]
        [TestCase("1991-01-24T14:32:00", "1991-01-24T14:32:10")]
        public void ThenDateTimesBeforeDoNotMatch(string value, string input)
        {
            var subject = new DateTimeValue(DateTimeOffset.Parse(value));
            Assert.That(subject.GreaterThan(DateTimeOffset.Parse(input)), Is.False);
        }

        [TestCase("1991-01-24T14:32:00", "1991-01-24T14:32:00")]
        public void ThenEqualStringsAreNotGreater(string value, string input)
        {
            var subject = new DateTimeValue(DateTimeOffset.Parse(value));
            Assert.That(subject.GreaterThan(DateTimeOffset.Parse(input)), Is.False);
        }
    }
}