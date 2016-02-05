﻿using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAString
{
    [TestFixture]
    public class WhenTheValueIsNotAString
    {
        [Test]
        public void ThenTheValueIsNotEqual()
        {
            var subject = new StringValue("segseg");
            Assert.That(subject.EqualTo(234), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotLessThan()
        {
            var subject = new StringValue("segseg");
            Assert.That(subject.LessThan(234), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotGreaterThan()
        {
            var subject = new StringValue("segseg");
            Assert.That(subject.GreaterThan(32), Is.False);
        }
    }
}