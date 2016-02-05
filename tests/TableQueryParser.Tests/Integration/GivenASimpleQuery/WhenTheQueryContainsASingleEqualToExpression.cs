using System;
using Microsoft.WindowsAzure.Storage.Table;
using NUnit.Framework;
using TableQueryParser.Core;

namespace TableQueryParser.Tests.Integration.GivenASimpleQuery
{
    [TestFixture]
    public class WhenTheQueryContainsASingleEqualToExpression
    {
        public class TestObject : TableEntity
        {
            public int Int { get; set; }
            public double Double { get; set; }
            public long Long { get; set; }
            public string String { get; set; }
            public DateTimeOffset DateTime { get; set; }
            public bool Bool { get; set; }
            public Guid Guid { get; set; }
        }

        [TestCase(1, false)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(-5, false)]
        public void ThenIntsCanBeResolvedCorrectly(int value, bool expected)
        {
            var input = new TestObject { Int = value };
            var filter = TableQuery.GenerateFilterConditionForInt("Int", QueryComparisons.Equal, 5);
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }

        [TestCase(1.0d, false)]
        [TestCase(5.5d, true)]
        [TestCase(10.0d, false)]
        [TestCase(-5.5d, false)]
        public void ThenDoublesCanBeResolvedCorrectly(double value, bool expected)
        {
            var input = new TestObject { Double = value };
            var filter = TableQuery.GenerateFilterConditionForDouble("Double", QueryComparisons.Equal, 5.5);
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }

        [TestCase(1L, false)]
        [TestCase(55L, true)]
        [TestCase(10L, false)]
        [TestCase(-55L, false)]
        public void ThenLongsCanBeResolvedCorrectly(long value, bool expected)
        {
            var input = new TestObject { Long = value };
            var filter = TableQuery.GenerateFilterConditionForLong("Long", QueryComparisons.Equal, 55);
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }

        [TestCase("A", false)]
        [TestCase("Test", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void ThenStringsCanBeResolvedCorrectly(string value, bool expected)
        {
            var input = new TestObject { String = value };
            var filter = TableQuery.GenerateFilterCondition("String", QueryComparisons.Equal, "Test");
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }

        [TestCase("2015-01-09T00:00:00.0000000Z", false)]
        [TestCase("2015-01-03T00:00:00.0000000Z", true)]
        [TestCase("2015-01-09T07:30:00.0000000Z", false)]
        public void ThenDateTimesCanBeResolvedCorrectly(string value, bool expected)
        {
            var input = new TestObject { DateTime = DateTimeOffset.Parse(value) };
            var filter = TableQuery.GenerateFilterConditionForDate("DateTime", QueryComparisons.Equal, new DateTimeOffset(new DateTime(2015, 01, 03)));
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }

        [TestCase(false, false)]
        [TestCase(true, true)]
        public void ThenBooleansCanBeResolvedCorrectly(bool value, bool expected)
        {
            var input = new TestObject { Bool = value };
            var filter = TableQuery.GenerateFilterConditionForBool("Bool", QueryComparisons.Equal, true);
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }

        [TestCase("ACDFDDDE-CB45-11E5-A5BD-A62EDB915C80", false)]
        [TestCase("AFF2CCC0-CB45-11E5-B199-A62EDB915C80", true)]
        [TestCase("00000000-0000-0000-0000-000000000000", false)]
        public void ThenGuidsCanBeResolvedCorrectly(string value, bool expected)
        {
            var input = new TestObject { Guid = Guid.Parse(value) };
            var filter = TableQuery.GenerateFilterConditionForGuid("Guid", QueryComparisons.Equal, Guid.Parse("AFF2CCC0-CB45-11E5-B199-A62EDB915C80"));
            var query = new TableQuery<TestObject>().Where(filter);
            Assert.That(query.Validate(input), Is.EqualTo(expected));
        }
    }
}