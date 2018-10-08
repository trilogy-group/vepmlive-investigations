using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets;

namespace EPMLiveTimesheets.Tests.WebPageCode
{
    public partial class GetTsApprovalsTests
    {
		[TestMethod]
        public void getParams_Should_Succed()
        {
            GetParamsCommon();
        }

		private void GetParamsCommon()
        {
            // Arange
            var approval = new GetTsApprovals();

            Shimgetgriditems.AllInstances.getParamsSPWeb = (a, b) => { };

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();

            ShimHttpRequest.AllInstances.ItemGetString = (a, b) => "1";

            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.UrlGet = _ => string.Empty;
            ShimSPWeb.AllInstances.OpenWebString = (a, b) => new ShimSPWeb();

            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();

            ShimCoreFunctions.getConnectionStringGuid = _ => string.Empty;
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (a, b, c, d) => "http://tests.com";

            // Act
            approval.getParams(new ShimSPWeb().Instance);

            // Assert
            var commands = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(7, commands.Count);
            Assert.AreEqual("select ts_uid,username,submitted,approval_status,approval_notes,resourcename,jobstatus,jobtype_id from vwTSTimesheetWQueue where period_id=@period_id and site_uid=@siteid", commands[0].CommandText);
            Assert.AreEqual("select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid", commands[1].CommandText);
            Assert.AreEqual("select title,project,ts_uid,web_uid,list_uid,item_id,ts_item_uid,approval_status,resourcename,username from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project", commands[2].CommandText);
            Assert.AreEqual("select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid", commands[3].CommandText);
            Assert.AreEqual("select tstype_id from TSTYPE where site_uid=@siteid", commands[4].CommandText);
            Assert.AreEqual("select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid", commands[5].CommandText);
            Assert.AreEqual("select ts_item_uid,columnname,columnvalue from vwTSItemMeta where period_id=@period_id and site_uid=@siteid", commands[6].CommandText);

            Assert.AreEqual(7, _shimAdoNetCalls.DataAdaptersCreated.Count);
        }
    }
}
