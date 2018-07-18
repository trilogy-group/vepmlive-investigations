using System;
using EPMLiveCore.Jobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass]
    public class ResourcePlanTest
    {
        [TestMethod]
        public void BuildResourceInfoDataTable_Always_SetsExpectedColumns()
        {
            // Arrange

            // Act
            var result = ResourcePlan.BuildResourceInfoDataTable();

            // Assert
            Assert.AreEqual(9, result.Columns.Count);
            Assert.IsNotNull(result.Columns["Project"]);
            Assert.IsNotNull(result.Columns["Title"]);
            Assert.IsNotNull(result.Columns["AssignedTo"]);
            Assert.IsNotNull(result.Columns["StartDate"]);
            Assert.AreEqual(typeof(DateTime), result.Columns["StartDate"].DataType);
            Assert.IsNotNull(result.Columns["DueDate"]);
            Assert.AreEqual(typeof(DateTime), result.Columns["DueDate"].DataType);
            Assert.IsNotNull(result.Columns["ItemType"]);
            Assert.IsNotNull(result.Columns["Status"]);
            Assert.IsNotNull(result.Columns["Work"]);
            Assert.IsNotNull(result.Columns["SiteId"]);
            Assert.AreEqual(typeof(Guid), result.Columns["SiteId"].DataType);
        }

        [TestMethod]
        public void BuildResourceLinkDataTable_Always_SetsExpectedColumns()
        {
            // Arrange

            // Act
            var result = ResourcePlan.BuildResourceLinkDataTable();

            // Assert
            Assert.AreEqual(5, result.Columns.Count);
            Assert.IsNotNull(result.Columns["weburl"]);
            Assert.IsNotNull(result.Columns["resurl"]);
            Assert.IsNotNull(result.Columns["siteid"]);
            Assert.AreEqual(typeof(Guid), result.Columns["siteid"].DataType);
            Assert.IsNotNull(result.Columns["nonworkdays"]);
            Assert.IsNotNull(result.Columns["workhours"]);
        }
    }
}
