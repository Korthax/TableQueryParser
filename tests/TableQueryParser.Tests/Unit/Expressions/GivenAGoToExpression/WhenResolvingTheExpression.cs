using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAGoToExpression
{
    [TestFixture]
    public class WhenResolvingTheExpression
    {
        [Test]
        public void ThenTheCorrectExpressionIsUsed()
        {
            var testObject = new object();
            var expression = new Mock<IExpression>();
            var expressions = new List<IExpression> { new Mock<IExpression>().Object, new Mock<IExpression>().Object, expression.Object };

            var subject = new GoTo(2);
            subject.Resolve(testObject, expressions);

            expression.Verify(x => x.Resolve(testObject, expressions), Times.Once);
        }
    }
}