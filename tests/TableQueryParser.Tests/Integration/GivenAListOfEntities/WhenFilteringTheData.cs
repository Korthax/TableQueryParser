using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using NUnit.Framework;
using TableQueryParser.Core;

namespace TableQueryParser.Tests.Integration.GivenAListOfEntities
{
    [TestFixture]
    public class WhenFilteringTheData
    {
        private IEnumerable<TableEntity> _result;

        public class TestObject : TableEntity
        {
            public string Area { get; set; }
            public string Action { get; set; }
            public DateTimeOffset DateAdded { get; set; }
            public bool RequestFailed { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            var data = new List<TestObject>
            {
                new TestObject { PartitionKey = "Smith", RowKey = "Adam", Action = "2", Area = "area", DateAdded = new DateTimeOffset(new DateTime(2015, 01, 05)) },
                new TestObject { PartitionKey = "Phillips", RowKey = "Steve", Action = "8", Area = "area", DateAdded = new DateTimeOffset(new DateTime(2015, 01, 05)) },
                new TestObject { PartitionKey = "Phillips", RowKey = "Jenny", Action = "2", Area = "area3", DateAdded = new DateTimeOffset(new DateTime(2015, 01, 05)) },
                new TestObject { PartitionKey = "Phillips", RowKey = "E", Action = "2", Area = "area", DateAdded = new DateTimeOffset(new DateTime(2015, 01, 09)) },
                new TestObject { PartitionKey = "Jones", RowKey = "Quinton", Action = "2", Area = "area", DateAdded = new DateTimeOffset(new DateTime(2015, 01, 03)) }
            };

            var partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Phillips");
            var rowKeyFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, "E");

            var combineFilters = TableQuery.CombineFilters(partitionKeyFilter, TableOperators.And, rowKeyFilter);
            var rangeQuery = new TableQuery<TableEntity>().Where(combineFilters);

            _result = rangeQuery.Filter(data);
        }

        [Test]
        public void ThenTheResultsAreFilteredBasedOnTheQuery()
        {
            Assert.That(_result.ToList().Count, Is.EqualTo(2));
        }
    }
}