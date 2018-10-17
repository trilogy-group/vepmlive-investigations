using System.Data.SqlClient.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace TimeSheets.Tests
{
    public partial class GetTsTests
    {
        private const string AddHeaderMethod = "addHeader";

        [TestMethod]
        public void addHeader_Should_Succeed()
        {
            AddHeaderCommon();
        }

        private void AddHeaderCommon()
        {
            // Arrange
            var docXml = new XmlDocument();
            docXml.LoadXml("<rows></rows>");

            _privateObject.SetFieldOrProperty(docXmlProperty, docXml);

            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => "True|True|True|True|True|True|True";

            // Act
            _privateObject.Invoke(AddHeaderMethod, new ShimSPWeb().Instance);

            // Assert
            docXml.OuterXml.ShouldBe(EPMLiveTimesheets.Tests.Properties.Resources.addHeader);

            var commands = _adoShims.CommandsCreated;
            Assert.AreEqual(7, commands.Count);
            Assert.AreEqual("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid", commands[0].CommandText);
            Assert.AreEqual("select ts_uid,username,submitted,approval_status,approval_notes from TSTIMESHEET where period_id=@period_id and site_uid=@siteid", commands[1].CommandText);
            Assert.AreEqual("select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid", commands[2].CommandText);
            Assert.AreEqual("select title,project,ts_uid,ts_item_uid,approval_status from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project", commands[3].CommandText);
            Assert.AreEqual("select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid", commands[4].CommandText);
            Assert.AreEqual("select tstype_id from TSTYPE where site_uid=@siteid", commands[5].CommandText);
            Assert.AreEqual("select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid", commands[6].CommandText);

            Assert.AreEqual(1, _adoShims.CommandsExecuted.Count);
            Assert.AreEqual(6, _adoShims.DataAdaptersCreated.Count);
        }
    }
}