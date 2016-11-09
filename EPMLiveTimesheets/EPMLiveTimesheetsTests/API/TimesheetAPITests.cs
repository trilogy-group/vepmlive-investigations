using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;

namespace TimeSheets.Tests
{
    [TestClass()]
    public class TimesheetAPITests
    {
        private class TestRoleChecker : ISPRoleChecker
        {
            public bool ContainsRole(SPWeb web, string roleName)
            {
                return false;
            }
        }

        [TestMethod()]
        public void ShowApprovalNotificationTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimSPWeb web = new ShimSPWeb()
                {
                    CurrentUserGet = () =>
                    {
                        return new ShimSPUser()
                        {
                            IDGet = () =>
                            {
                                return 1073741823;
                            }
                        };
                    },
                    SiteGet = () =>
                    {
                        return new ShimSPSite()
                        {
                            IDGet = () =>
                            {
                                return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                            },
                            WebApplicationGet = () =>
                            {
                                var webApp = new ShimSPWebApplication();
                                var persistedObject = new ShimSPPersistedObject(webApp);
                                persistedObject.IdGet = () =>
                                {
                                    return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86DAA");
                                };
                                return webApp;
                            }
                        };
                    },
                    RoleDefinitionsGet = () =>
                    {
                        return new ShimSPRoleDefinitionCollection().Bind(
                        new List<SPRoleDefinition>
                        {
                            new ShimSPRoleDefinition() { NameGet = () => "Contribute2" }.Instance
                        });
                    }
                };

                new ShimSPSecurableObject(web).AllRolesForCurrentUserGet = () =>
                new ShimSPRoleDefinitionBindingCollection().Bind(
                    new List<SPRoleDefinition>
                    {
                        new ShimSPRoleDefinition() { NameGet = () => "Contribute2" }.Instance
                    });

                ShimQueryExecutor.ConstructorSPWeb = (instance, spweb) =>
                {
                    ShimQueryExecutor moledInstance = new ShimQueryExecutor(instance);
                    //moledInstance.Dispose = () => { };
                    moledInstance.ExecuteReportingDBQueryStringIDictionaryOfStringObject =
                    (str1, dict) =>
                    {
                        DataTable dt = new DataTable();
                        DataRow newRow = dt.NewRow();
                        DataColumn newColumn = new DataColumn("SharePointAccountID");
                        dt.Columns.Add(newColumn);
                        newRow["SharePointAccountID"] = "1073741823";

                        dt.Rows.Add(newRow);
                        return dt;
                    };
                };

                ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (w) =>
                {
                    w();
                };

                ShimCoreFunctions.getConnectionStringGuid = (guid) =>
                {
                    return "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
                };

                ShimSqlConnection.ConstructorString = (instance, connString) =>
                {
                    var connection = new ShimSqlConnection(instance);
                    connection.Open = () => { };
                    connection.Close = () => { };
                };


                ShimSqlCommand.ConstructorStringSqlConnection = (instance, cmdText, sqlConnection) =>
                {
                    ShimSqlCommand sqlCommand = new ShimSqlCommand(instance);
                    sqlCommand.ParametersGet = () =>
                    {
                        var realSqlCommand = new SqlCommand();
                        return realSqlCommand.Parameters;
                    };

                    sqlCommand.ExecuteScalar = () =>
                    {
                        return 2;
                    };
                };

                var data = "<ApprovalNotification PeriodId='1'/>";

                TimesheetAPI.RoleChecker = new TestRoleChecker();

                var result = TimesheetAPI.ShowApprovalNotification(data, web);
                Assert.AreEqual(result, "<ApprovalNotification Status=\"0\" IsTimeSheetManager=\"True\" IsProjectManager=\"True\">2</ApprovalNotification>");
            }
        }
    }
}