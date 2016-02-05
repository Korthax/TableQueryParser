using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenAString
{
    [TestFixture]
    public class WhenCheckingLessThan
    {
        [TestCase("hi", "aaa")]
        [TestCase("Hi", "hi")]
        public void ThenStringsBeforeMatchCorrectly(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.LessThan(input), Is.True);
        }

        [TestCase("hi", "zzz")]
        [TestCase("hi", "Hi")]
        public void ThenStringsAfterDoNotMatch(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.LessThan(input), Is.False);
        }

        [TestCase("hi", "hi")]
        public void ThenEqualStringsAreNotLess(string value, string input)
        {
            var subject = new StringValue(value);
            Assert.That(subject.LessThan(input), Is.False);
        }
    }
}