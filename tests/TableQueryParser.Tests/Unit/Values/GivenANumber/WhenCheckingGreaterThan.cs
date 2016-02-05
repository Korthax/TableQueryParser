using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenANumber
{
    [TestFixture]
    public class WhenCheckingGreaterThan
    {
        [TestCase(0.254648564, 0)]
        [TestCase(10, -1)]
        [TestCase(1034, 10.34)]
        [TestCase(1.125, -1.125)]
        public void ThenLargeNumbersMatchCorrectly(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.GreaterThan(input), Is.True);
        }

        [TestCase(0, 0)]
        [TestCase(-1, 1)]
        [TestCase(1.125, 1.126)]
        [TestCase(100, 1000)]
        public void ThenSmallerNumbersDoNotMatch(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.GreaterThan(input), Is.False);
        }

        [TestCase(0, 0)]
        public void ThenEqualNumbersDoNotMatch(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.GreaterThan(input), Is.False);
        }
    }
}