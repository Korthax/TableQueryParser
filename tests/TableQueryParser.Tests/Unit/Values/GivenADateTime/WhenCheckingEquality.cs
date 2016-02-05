using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenADateTime
{
    [TestFixture]
    public class WhenCheckingEquality
    {
        [TestCase("1991-01-24T14:32:00", "1991-01-24T14:32:00")]
        public void ThenEqualDateTimesMatchCorrectly(string value, string input)
        {
            Console.WriteLine(new DateTime(1991, 01, 24, 14,32,00));
            var subject = new DateTimeValue(DateTimeOffset.Parse(value));
            Assert.That(subject.EqualTo(DateTimeOffset.Parse(input)), Is.True);
        }

        [TestCase("24/01/1991 14:32:00", "24/01/2015 14:32:00")]
        public void ThenDifferentDateTimesDoNotMatch(string value, string input)
        {
            var subject = new DateTimeValue(DateTimeOffset.Parse(value));
            Assert.That(subject.EqualTo(DateTimeOffset.Parse(input)), Is.False);
        }
    }
}