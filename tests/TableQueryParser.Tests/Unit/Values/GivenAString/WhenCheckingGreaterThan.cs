using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAString
{
    [TestFixture]
    public class WhenCheckingGreaterThan
    {
        [TestCase("hi", "zzz")]
        [TestCase("hi", "Hi")]
        public void ThenStringAfterMatchCorrectly(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.GreaterThan(input), Is.True);
        }

        [TestCase("hi", "aaa")]
        [TestCase("Hi", "hi")]
        public void ThenStringsBeforeDoNotMatch(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.GreaterThan(input), Is.False);
        }

        [TestCase("hi", "hi")]
        public void ThenEqualStringsAreNotGreater(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.GreaterThan(input), Is.False);
        }
    }
}