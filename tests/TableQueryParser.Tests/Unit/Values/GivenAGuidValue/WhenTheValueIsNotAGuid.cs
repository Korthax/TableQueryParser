using System;
using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAGuidValue
{
    [TestFixture]
    public class WhenTheValueIsNotAGuid
    {
        [Test]
        public void ThenTheValueIsNotEqual()
        {
            var subject = new GuidValue(Guid.NewGuid());
            Assert.That(subject.EqualTo(234), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotLessThan()
        {
            var subject = new GuidValue(Guid.NewGuid());
            Assert.That(subject.LessThan(234), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotGreaterThan()
        {
            var subject = new GuidValue(Guid.NewGuid());
            Assert.That(subject.GreaterThan(32), Is.False);
        }
    }
}