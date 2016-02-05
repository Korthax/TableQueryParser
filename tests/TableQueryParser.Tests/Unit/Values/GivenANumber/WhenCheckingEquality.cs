using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenANumber
{
    [TestFixture]
    public class WhenCheckingEquality
    {
        [TestCase(0d, 0d)]
        [TestCase(-1d, -1d)]
        [TestCase(1.125d, 1.125d)]
        public void ThenEqualNumbersMatchCorrectly(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.EqualTo(input), Is.True);
        }

        [TestCase(0d, 0.254648564d)]
        [TestCase(-1d, 10d)]
        [TestCase(1034d, 10.34d)]
        [TestCase(1.125d, -1.125d)]
        public void ThenNotEqualNumbersDoNotMatch(double value, double input)
        {
            var subject = new NumericValue(value);
            Assert.That(subject.EqualTo(input), Is.False);
        }
    }
}