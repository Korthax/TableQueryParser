using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Core.Values;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenALessThanOrEqualToExpression
{
    [TestFixture]
    public class WhenTheLeftHandSideIsLessThanTheRight
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var rightHandSide = new Mock<IValue>();
            rightHandSide.Setup(x => x.GreaterThan("smaller")).Returns(true);
            rightHandSide.Setup(x => x.EqualTo("smaller")).Returns(false);

            var subject = new LessThanOrEqualTo("Value", rightHandSide.Object);
            var result = subject.Resolve(new TestObject { Value = "smaller" }, new List<IExpression>());

            Assert.That(result, Is.True);
        }
    }
}