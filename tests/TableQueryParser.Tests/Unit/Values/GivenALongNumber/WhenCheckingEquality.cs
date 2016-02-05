using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenALongNumber
{
    [TestFixture]
    public class WhenCheckingEquality
    {
        [TestCase(0L, 0L)]
        [TestCase(-1L, -1L)]
        [TestCase(922337203685477580L, 922337203685477580L)]
        public void ThenEqualNumbersMatchCorrectly(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.EqualTo(input), Is.True);
        }

        [TestCase(-1L, 10L)]
        [TestCase(1034L, 104L)]
        [TestCase(922337203685477580L, -922337203685477580L)]
        public void ThenNotEqualNumbersDoNotMatch(long value, long input)
        {
            var subject = new LongNumericValue(value);
            Assert.That(subject.EqualTo(input), Is.False);
        }
    }
}