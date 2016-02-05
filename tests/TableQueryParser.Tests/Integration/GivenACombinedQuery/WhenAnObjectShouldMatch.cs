using Microsoft.WindowsAzure.Storage.Table;
using NUnit.Framework;
using TableQueryParser.Core;

namespace TableQueryParser.Tests.Integration.GivenACombinedQuery
{
    [TestFixture]
    public class WhenTheRowKeyAndPartionKeyMatchTheQuery
    {
        [Test]
        public void ThenResolveReturnsTrue()
        {
            var partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith");
            var rowKeyFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, "E");

            var combineFilters = TableQuery.CombineFilters(partitionKeyFilter, TableOperators.And, rowKeyFilter);
            var rangeQuery = new TableQuery<TableEntity>().Where(combineFilters);

            Assert.That(rangeQuery.Validate(new TableEntity { PartitionKey = "Smith", RowKey = "ZZZ" }), Is.True);
        }
    }
}