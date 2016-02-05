using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenALongNumber
{
    [TestFixture]
    public class WhenCheckingLessThan
    {
        [TestCase(100L, 1000L)]
        public void ThenSmallerNumbersMatchCorrectly(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.LessThan(input), Is.True);
        }

        [TestCase(1034L, 104L)]
        public void ThenLargeNumbersDoNotMatch(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.LessThan(input), Is.False);
        }

        [TestCase(0L, 0L)]
        public void ThenEqualNumbersDoNotMatch(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.LessThan(input), Is.False);
        }
    }
}