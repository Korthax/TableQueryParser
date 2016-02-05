using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAString
{
    [TestFixture]
    public class WhenCheckingEquality
    {
        [TestCase("0", "0")]
        [TestCase("hi", "hi")]
        public void ThenEqualStringsMatchCorrectly(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.EqualTo(input), Is.True);
        }

        [TestCase("0", "-1")]
        [TestCase("hi", "HI")]
        public void ThenDifferentDoNotMatch(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.EqualTo(input), Is.False);
        }
    }
}