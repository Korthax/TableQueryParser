using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenABoolean
{
    [TestFixture]
    public class WhenCheckingEquality
    {
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void ThenEqualBooleansMatchCorrectly(bool value, bool input)
        {
            var subject = new BooleanValue(value);
            Assert.That(subject.EqualTo(input), Is.True);
        }

        [TestCase(true, false)]
        [TestCase(false, true)]
        public void ThenDifferentBooleansDoNotMatch(bool value, bool input)
        {
            var subject = new BooleanValue(value);
            Assert.That(subject.EqualTo(input), Is.False);
        }
    }
}