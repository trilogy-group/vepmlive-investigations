using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint.Fakes;
using EPMLiveCore.Infrastructure.Logging.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;

namespace EPMLiveCore.API.Tests
{
    [TestClass()]
    public class TimerTests
    {
        [TestMethod()]
        public void GetTimerJobStatusTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                Guid jobid = Guid.NewGuid();
                Guid siteid = jobid;
                Guid webid = jobid;
                Guid listid = jobid;
                int openconnection = 0;
                int closeconnetcion = 0;
                ShimSqlConnection con = new ShimSqlConnection();
                ShimSqlConnection.AllInstances.Open = (instance) =>
                {

                    openconnection++;
                };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) =>
                {

                    closeconnetcion++;
                };

                ShimSPWeb spweb = new ShimSPWeb() { SiteGet = () => { return new ShimSPSite() { IDGet = () => { return jobid; } }; }, IDGet = () => { return jobid; } };
                ShimSPSite.ConstructorGuid = (instance, _guid) =>
                {


                };
                ShimSPSite.AllInstances.WebApplicationGet = (instance) =>
                {
                    var webApp = new ShimSPWebApplication();
                    var persistedObject = new ShimSPPersistedObject(webApp);
                    persistedObject.IdGet = () =>
                    {
                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86DAA");
                    };
                    return webApp;
                };
                ShimSPSite.AllInstances.Dispose = (instance) => { };
                ShimLoggingService.WriteTraceStringStringTraceSeverityString = (_str1, _str2, _trace, _str3) =>
                {

                };
                bool read = false;
                ShimCoreFunctions.getConnectionStringGuid = (instance) => { return ""; };
                ShimSqlCommand.AllInstances.ExecuteReader = (instance) =>
                {
                    return new ShimSqlDataReader()
                    {
                        Read = () =>
                        {
                            return !read;
                        },
                        GetSqlInt32Int32 = (_int) =>
                        {
                            read = true;
                            return 20;
                        },
                        GetGuidInt32 = (_int) =>
                        {
                            read = true;
                            return Guid.NewGuid();
                        },
                        GetDateTimeInt32 = (_int) =>
                        {
                            read = true;
                            return DateTime.Now;
                        },
                        GetStringInt32 = (_int) =>
                        {
                            read = true;
                            return "";
                        },
                        IsDBNullInt32 = (_int) =>
                        {
                            read = true;
                            return false;
                        },
                    };
                };
                Timer.GetTimerJobStatus(spweb, jobid);
                Timer.GetTimerJobStatus(siteid, webid, 0, true);
                Timer.GetTimerJobStatus(siteid, webid, listid, 0, 0);
                Timer.AddTimerJob(siteid, webid, listid, 1, "", 1, "", "", 1, 0, "");
                Timer.AddTimerJob(siteid, webid, listid, "", 1, "", "", 5, 2, "");
                Timer.AddTimerJob(siteid, webid, "", 1, "", "", 5, 3, "");
                Timer.CancelTimerJob(spweb, jobid);
                Timer.IsImportResourceAlreadyRunning(spweb);
                Timer.IsSecurityJobAlreadyRunning(spweb, listid, 5);


                Assert.AreEqual(openconnection, closeconnetcion);

            }
        }
    }
}