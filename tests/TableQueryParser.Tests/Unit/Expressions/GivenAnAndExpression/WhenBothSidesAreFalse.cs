using System.Collections.Generic;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnAndExpression
{
    [TestFixture]
    public class WhenBothSidesAreFalse
    {
        [Test]
        public void ThenResolveReturnsFalse()
        {
            var subject = new And(0, 1);

            var result = subject.Resolve(new object(), new List<IExpression> { new FalseExpression(), new FalseExpression() });
            Assert.That(result, Is.False);
        }
    }
}