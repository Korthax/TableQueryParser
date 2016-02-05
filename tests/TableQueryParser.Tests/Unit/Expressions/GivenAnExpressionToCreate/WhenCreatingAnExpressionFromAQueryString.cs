using System;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnExpressionToCreate
{
    [TestFixture]
    public class WhenCreatingAnExpressionFromAQueryString
    {
        [TestCase("(5)", typeof(GoTo))]
        [TestCase("(not 5)", typeof(Not))]
        [TestCase("(1 or 3)", typeof(Or))]
        [TestCase("(1 and 3)", typeof(And))]
        [TestCase("(area eq '5')", typeof(EqualTo))]
        [TestCase("(area ne '5')", typeof(NotEqualTo))]
        [TestCase("(area lt '5')", typeof(LessThan))]
        [TestCase("(area gt '5')", typeof(GreaterThan))]
        [TestCase("(area le '5')", typeof(LessThanOrEqualTo))]
        [TestCase("(area ge '5')", typeof(GreaterThanOrEqualTo))]
        public void ThenTheCorrectExpressionIsCreated(string queryString, Type expectedType)
        {
            var result = ExpressionFactory.From(queryString);
            Assert.That(result, Is.TypeOf(expectedType));
        }
    }
}