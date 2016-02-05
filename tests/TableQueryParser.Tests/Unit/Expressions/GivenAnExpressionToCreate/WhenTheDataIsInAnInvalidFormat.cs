using System.Reflection;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnExpressionToCreate
{
    [TestFixture]
    public class WhenTheDataIsInAnInvalidFormat
    {
        [Test]
        public void ThenAnExceptionIsThrown()
        {
            Assert.Throws<InvalidFilterCriteriaException>(() => ExpressionFactory.From("two parts"));
        }
    }
}