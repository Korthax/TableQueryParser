using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenALongNumber
{
    [TestFixture]
    public class WhenCheckingGreaterThan
    {
        [TestCase(1034L, 104L)]
        public void ThenLargeNumbersMatchCorrectly(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.GreaterThan(input), Is.True);
        }

        [TestCase(0L, 0L)]
        [TestCase(-1L, 1L)]
        [TestCase(100L, 1000L)]
        public void ThenSmallerNumbersDoNotMatch(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.GreaterThan(input), Is.False);
        }

        [TestCase(0L, 0L)]
        public void ThenEqualNumbersDoNotMatch(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.GreaterThan(input), Is.False);
        }
    }
}