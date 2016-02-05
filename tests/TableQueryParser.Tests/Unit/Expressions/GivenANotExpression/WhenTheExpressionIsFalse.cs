using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Tests.Unit.Expressions.GivenANotExpression
{
    [TestFixture]
    public class WhenTheExpressionIsFalse
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var testObject = new object();
            var expression = new Mock<IExpression>();
            var expressions = new List<IExpression> { new Mock<IExpression>().Object, expression.Object };
            expression.Setup(x => x.Resolve(testObject, expressions)).Returns(false);

            var subject = new Not(1);
            var result = subject.Resolve(testObject, expressions);

            Assert.That(result, Is.True);
        }
    }
}