using System;
using Microsoft.WindowsAzure.Storage.Table;
using NUnit.Framework;
using TableQueryParser.Core;

namespace TableQueryParser.Tests.Integration.GivenAComplexQuery
{
    [TestFixture]
    public class WhenValidatingAnObject
    {
        public class TestObject : TableEntity
        {
            public string Area { get; set; }
            public string Action { get; set; }
            public DateTimeOffset DateAdded { get; set; }
            public bool RequestFailed { get; set; }
        }

        [TestCase("(((DateAdded gt datetime'2015-01-03T00:00:00.0000000Z') and (DateAdded lt datetime'2015-01-09T00:00:00.0000000Z')) and ((((((Action eq '1') or (Action eq '2')) or (Action eq '3')) or (Action eq '4')) or (Action eq '5')) and ((Area eq 'area') or (Area eq 'area1'))))", true)]
        [TestCase("(((DateAdded gt datetime'2015-01-03T00:00:00.0000000Z') and (DateAdded lt datetime'2015-01-09T00:00:00.0000000Z')) and ((((((Action eq 'a') or (Action eq 'b')) or (Action eq 'c')) or (Action eq 'd')) or (Action eq 'e')) and ((Area eq 'area') or (Area eq 'area1'))))", false)]
        [TestCase("(((DateAdded gt datetime'2015-01-03T00:00:00.0000000Z') and (DateAdded lt datetime'2015-01-09T00:00:00.0000000Z')) and ((((((Action eq '1') or (Action eq '2')) or (Action eq '3')) or (Action eq '4')) or (Action eq '5')) and ((Area eq 'area2') or (Area eq 'area1'))))", false)]
        [TestCase("(((DateAdded gt datetime'2015-01-06T00:00:00.0000000Z') and (DateAdded lt datetime'2015-01-09T00:00:00.0000000Z')) and ((((((Action eq '1') or (Action eq '2')) or (Action eq '3')) or (Action eq '4')) or (Action eq '5')) and ((Area eq 'area') or (Area eq 'area1'))))", false)]
        public void ThenTheCorrectResultIsReturned(string query, bool expected)
        {
            var testObject = new TestObject { Action = "2", Area = "area", DateAdded = new DateTimeOffset(new DateTime(2015, 01, 05)) };
            Assert.That(QueryParser.Validate(query, testObject), Is.EqualTo(expected));
        }
    }
}