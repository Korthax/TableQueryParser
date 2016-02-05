using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenALongNumber
{
    [TestFixture]
    public class WhenTheValueIsNotANumber
    {
        [Test]
        public void ThenTheValueIsNotEqual()
        {
            var subject = new LongNumericValue(234L);
            Assert.That(subject.EqualTo("segseg"), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotLessThan()
        {
            var subject = new LongNumericValue(234L);
            Assert.That(subject.LessThan("segseg"), Is.False);
        }

        [Test]
        public void ThenTheValueIsNotGreaterThan()
        {
            var subject = new LongNumericValue(234L);
            Assert.That(subject.GreaterThan("segseg"), Is.False);
        }
    }
}