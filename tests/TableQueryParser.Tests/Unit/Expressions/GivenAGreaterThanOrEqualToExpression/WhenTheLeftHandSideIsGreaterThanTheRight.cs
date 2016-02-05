using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Core.Values;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAGreaterThanOrEqualToExpression
{
    [TestFixture]
    public class WhenTheLeftHandSideIsGreaterThanTheRight
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var rightHandSide = new Mock<IValue>();
            rightHandSide.Setup(x => x.LessThan("larger")).Returns(true);
            rightHandSide.Setup(x => x.EqualTo("larger")).Returns(false);

            var subject = new GreaterThanOrEqualTo("Value", rightHandSide.Object);
            var result = subject.Resolve(new TestObject { Value = "larger" }, new List<IExpression>());

            Assert.That(result, Is.True);
        }
    }
}