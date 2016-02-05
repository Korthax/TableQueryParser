using NUnit.Framework;
using TableQueryParser.Core.Values;

namespace TableQueryParser.Tests.Unit.Values.GivenABoolean
{
    [TestFixture]
    public class WhenTheValueIsNotABoolean
    {
        [Test]
        public void ThenTheValueIsNotEqual()
        {
            var subject = new BooleanValue(true);
            Assert.That(subject.EqualTo("fsdfsdf"), Is.False);
        }
    }
}