using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenADateTime
{
    [TestFixture]
    public class WhenTheValueIsNotADateTime
    {
        [Test]
        public void ThenTheValueIsNotEqual()
        {
            var subject = new DateTimeValue(DateTimeOffset.Now);
            Assert.That(subject.EqualTo(234), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotLessThan()
        {
            var subject = new DateTimeValue(DateTimeOffset.Now);
            Assert.That(subject.LessThan(234), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotGreaterThan()
        {
            var subject = new DateTimeValue(DateTimeOffset.Now);
            Assert.That(subject.GreaterThan(32), Is.False);
        }
    }
}