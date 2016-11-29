using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using Microsoft.SharePoint.Fakes;
using System.Data.SqlClient.Fakes;
using PortfolioEngineCore.WEIntegration;
using PortfolioEngineCore.WEIntegration.Fakes;
using EPMLiveCore.Fakes;
using System;
using WorkEnginePPM.Jobs.Fakes;
using System.Data;
using WorkEnginePPM.Fakes;
using System.Web.Fakes;
using System.Text;

namespace WorkEnginePPM.Jobs.Tests
{
    [TestClass()]
    public class CleanupTests
    {
        [TestMethod()]
        public void processTimesheetsTest()
        {
            int opencon = 0;
            int closecon = 0;
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(Cleanup));
            SqlCommand cmd = new SqlCommand();
            string project_list_uid = string.Empty; ;
            //cmd.Parameters.AddWithValue("@siteguid",Guid.NewGuid());
            using (var context = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                SPWeb web = new ShimSPWeb();
                SPSite site = new ShimSPSite()
                {
                    IDGet = () => { return Guid.NewGuid(); },
                    OpenWebGuid = (str) =>
                    {
                        ShimSPWeb sweb = new ShimSPWeb();
                        sweb.Dispose = () => { };

                        sweb.ListsGet = () =>
                        {
                            ShimSPListCollection lists = new ShimSPListCollection();
                            lists.ItemGetGuid = (guid2) =>
                            {
                                ShimSPList list = new ShimSPList();
                                // list.TitleGet = () => { return "test List"; };
                                // list.HiddenGet = () => { return false; };
                                list.GetItemByIdInt32 = (_int) => { return new ShimSPListItem() { ItemGetString = (_str) => { return "ea6018b4-0c90-4b3a-b676-64d0c2906469.98adbe23-3a3f-4de0-b7ba-84134dd3d069.5"; } }; };
                                return list;
                            };

                            return lists;
                        };

                        return sweb;
                    }
                };

                SqlConnection cn = new ShimSqlConnection() { Open = () => { opencon++; }, DisposeBoolean = (_bool) => { closecon++; } };
                WEIntegration we = new ShimWEIntegration()
                {

                    PostTimesheetDataString = (_str) => { return "<timesheet Status=\"1\"></timesheet>"; }
                };
                ShimHttpUtility.HtmlEncodeString = (_str) => { return ""; };
                SqlDataAdapter adp = new SqlDataAdapter();
                ShimCleanup.AllInstances.GetDatasetDataSetSqlCommand = (instance, sds, scmd) =>
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("username");
                    dt.Columns.Add("period_start");
                    dt.Columns.Add("period_end");
                    dt.Columns.Add("project_list_uid");
                    dt.Columns.Add("web_uid");
                    dt.Columns.Add("project_id");
                    dt.Columns.Add("ts_item_date");
                    dt.Columns.Add("TotalHours");
                    dt.Columns.Add("TYPEID");
                    dt.Columns.Add("TSTYPE_NAME");
                    dt.Columns.Add("LIST");
                    dt.Columns.Add("list_uid");
                    
                    DataRow dr = dt.NewRow();
                    dr["username"] = "username";
                    dr["period_start"] = "2016-11-01 00:00:00.000";
                    dr["period_end"] = "2016-11-30 00:00:00.000";
                    dr["project_list_uid"] = project_list_uid;
                    dr["web_uid"] = Guid.NewGuid().ToString();
                    dr["project_id"] = "5";
                    dr["ts_item_date"] = "2016-11-01 00:00:00.000";
                    dr["TotalHours"] = "5";
                    dr["TYPEID"] = "TYPEID";
                    dr["TSTYPE_NAME"] = "Name";
                    dr["LIST"] = "Project Center";
                    dr["list_uid"]= Guid.NewGuid().ToString();
                    dt.Rows.Add(dr);
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    return ds;
                };
                ShimConfigFunctions.GetCleanUsernameSPWebString = (sweb, _str) => { return "epm\\chander.k"; };
                ShimCoreFunctions.setConfigSettingSPWebStringString = (sweb, _str, _str1) =>
                { };
                //ShimSqlCommand.AllInstances.ParametersGet = (scmd) => { return cmd.Parameters; };
                ShimCoreFunctions.getConfigSettingSPWebString = (sweb, _str) =>
            {
                if (_str == "EPKTSLastTSApprove")
                {
                    return DateTime.Now.ToString("MM/dd/yyyy");
                }
                else
                {
                    return ",Project Center";
                }

            };

                objToTestPrivateMethod.SetField("sbErrors", new StringBuilder());
                
                
                //when project_list_uid is not null
                //Act                
                project_list_uid = Guid.NewGuid().ToString();
                objToTestPrivateMethod.Invoke("processTimesheets", site, web, cn, we);
                //Assert
                Assert.AreEqual(opencon, closecon);
                Assert.IsNotNull(objToTestPrivateMethod.GetField("sbErrors"));


                //when project_list_uid is null
                //Act
                project_list_uid = "";
                objToTestPrivateMethod.Invoke("processTimesheets", site, web, cn, we);
                //Assert
                Assert.AreEqual(opencon, closecon);
                Assert.IsNotNull(objToTestPrivateMethod.GetField("sbErrors"));
            }

        }
    }
}