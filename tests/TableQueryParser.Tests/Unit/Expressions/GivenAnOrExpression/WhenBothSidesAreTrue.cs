using System.Collections.Generic;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnOrExpression
{
    [TestFixture]
    public class WhenBothSidesAreTrue
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var subject = new Or(0, 1);

            var result = subject.Resolve(new object(), new List<IExpression> { new TrueExpression(), new TrueExpression() });
            Assert.That(result, Is.True);
        }
    }
}