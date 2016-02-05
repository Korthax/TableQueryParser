using System.Collections.Generic;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnOrExpression
{
    [TestFixture]
    public class WhenBothSidesAreFalse
    {
        [Test]
        public void ThenResolveReturnsFalse()
        {
            var subject = new Or(0, 1);

            var result = subject.Resolve(new object(), new List<IExpression> { new FalseExpression(), new FalseExpression() });
            Assert.That(result, Is.False);
        }
    }
}