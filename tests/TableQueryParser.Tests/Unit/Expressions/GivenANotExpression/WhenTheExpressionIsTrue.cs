using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Tests.Unit.Expressions.GivenANotExpression
{
    [TestFixture]
    public class WhenTheExpressionIsTrue
    {
        [Test]
        public void ThenResolveReturnsFalse()
        {
            var testObject = new object();
            var expression = new Mock<IExpression>();
            var expressions = new List<IExpression> { new Mock<IExpression>().Object, expression.Object };
            expression.Setup(x => x.Resolve(testObject, expressions)).Returns(true);

            var subject = new Not(1);
            var result = subject.Resolve(testObject, expressions);

            Assert.That(result, Is.False);
        }
    }
}