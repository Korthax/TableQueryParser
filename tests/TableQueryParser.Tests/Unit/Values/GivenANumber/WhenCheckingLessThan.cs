using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenANumber
{
    [TestFixture]
    public class WhenCheckingLessThan
    {
        [TestCase(-1d, 1d)]
        [TestCase(1.125d, 1.126d)]
        [TestCase(100d, 1000d)]
        public void ThenSmallerNumbersMatchCorrectly(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.LessThan(input), Is.True);
        }

        [TestCase(0.254648564d, 0d)]
        [TestCase(10d, -1d)]
        [TestCase(1034d, 10.34d)]
        [TestCase(1.125d, -1.125d)]
        public void ThenLargeNumbersDoNotMatch(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.LessThan(input), Is.False);
        }

        [TestCase(0d, 0d)]
        public void ThenEqualNumbersDoNotMatch(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.LessThan(input), Is.False);
        }
    }
}