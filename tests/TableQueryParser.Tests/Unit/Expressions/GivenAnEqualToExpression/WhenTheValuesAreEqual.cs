using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Core.Values;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnEqualToExpression
{
    [TestFixture]
    public class WhenTheValuesAreEqual
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var rightHandSide = new Mock<IValue>();
            rightHandSide.Setup(x => x.EqualTo("value")).Returns(true);

            var subject = new EqualTo("Value", rightHandSide.Object);
            var result = subject.Resolve(new TestObject { Value = "value" }, new List<IExpression>());

            Assert.That(result, Is.True);
        } 
    }
}