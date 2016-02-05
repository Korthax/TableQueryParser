﻿using System.Collections.Generic;
using NUnit.Framework;
using TableQueryParser.Core.Expressions;
using TableQueryParser.Tests.Unit.TestTypes;

namespace TableQueryParser.Tests.Unit.Expressions.GivenAnAndExpression
{
    [TestFixture]
    public class WhenTheLeftHandSideIsFalse
    {
        [Test]
        public void ThenResolveReturnsFalse()
        {
            var subject = new And(0, 1);

            var result = subject.Resolve(new object(), new List<IExpression> { new FalseExpression(), new TrueExpression() });
            Assert.That(result, Is.False);
        }
    }
}