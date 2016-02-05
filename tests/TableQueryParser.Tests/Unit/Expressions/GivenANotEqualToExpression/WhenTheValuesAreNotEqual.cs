using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Core.Values;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenANotEqualToExpression
{
    [TestFixture]
    public class WhenTheValuesAreNotEqual
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var rightHandSide = new Mock<IValue>();
            rightHandSide.Setup(x => x.EqualTo("value")).Returns(false);

            var subject = new NotEqualTo("Value", rightHandSide.Object);
            var result = subject.Resolve(new TestObject { Value = "value" }, new List<IExpression>());

            Assert.That(result, Is.True);
        } 
    }
}