using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint.Fakes;
using EPMLiveCore.Infrastructure.Logging.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;
using System.Web.Fakes;
using System.Xml;
using EPMLive.TestFakes;

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
                        return jobid;
                    };
                    return webApp;
                };
                ShimSPSite.AllInstances.Dispose = (instance) => { };
                ShimLoggingService.WriteTraceStringStringTraceSeverityString = (_str1, _str2, _trace, _str3) =>
                {

                };
                bool read = true;
                ShimCoreFunctions.getConnectionStringGuid = (instance) => { return ""; };
                ShimSqlCommand.AllInstances.ExecuteReader = (instance) =>
                {
                    return new ShimSqlDataReader()
                    {
                        Read = () =>
                        {
                            return read;
                        },
                        GetSqlInt32Int32 = (_int) =>
                        {
                            read = false;
                            return 20;
                        },
                        GetGuidInt32 = (_int) =>
                        {
                            read = false;
                            return jobid;
                        },
                        GetDateTimeInt32 = (_int) =>
                        {
                            read = false;
                            return DateTime.MinValue.ToUniversalTime();
                        },
                        GetStringInt32 = (_int) =>
                        {
                            read = false;
                            return "";
                        },
                        IsDBNullInt32 = (_int) =>
                        {
                            read = false;
                            return false;
                        },
                    };
                };

                ShimHttpUtility.HtmlEncodeString = (a) => { return a; };

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    XmlNode ndStatus = Timer.GetTimerJobStatus(spweb, jobid);
                    //Assert
                    string expectedresult = "<TimerJobStatus ID=\"" + jobid + "\" Status=\"0\" PercentComplete=\"0\" Finished=\"" + DateTime.MinValue.ToUniversalTime() + "\" Result=\"\"><![CDATA[]]></TimerJobStatus>";
                    Assert.AreEqual("TimerJobStatus", ndStatus.Name);
                    Assert.AreEqual(expectedresult, ndStatus.OuterXml);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    XmlNode ndStatus = Timer.GetTimerJobStatus(siteid, webid, 0, true);

                    //Assert
                    string expectedresult = "<TimerJobStatus ID=\"" + jobid + "\" Status=\"0\" PercentComplete=\"0\" Finished=\"" + DateTime.MinValue.ToUniversalTime() + "\">&lt;![CDATA[]]&gt;</TimerJobStatus>";
                    Assert.AreEqual("TimerJobStatus", ndStatus.Name);
                    Assert.AreEqual(expectedresult, ndStatus.OuterXml);
                }


                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    XmlNode ndStatus = Timer.GetTimerJobStatus(siteid, webid, listid, 0, 0);

                    string expectedresult = "<TimerJobStatus ID=\"" + jobid + "\" Status=\"0\" PercentComplete=\"0\" Finished=\"" + DateTime.MinValue.ToUniversalTime() + "\">&lt;![CDATA[]]&gt;</TimerJobStatus>";
                    //Assert
                    Assert.AreEqual("TimerJobStatus", ndStatus.Name);
                    Assert.AreEqual(expectedresult, ndStatus.OuterXml);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    Guid result = Timer.AddTimerJob(siteid, webid, listid, 1, "", 1, "", "", 1, 0, "");

                    //Assert
                    Assert.AreEqual(jobid, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    Guid result = Timer.AddTimerJob(siteid, webid, listid, "", 1, "", "", 5, 2, "");


                    //Assert
                    Assert.AreEqual(jobid, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    Guid result = Timer.AddTimerJob(siteid, webid, "", 1, "", "", 5, 3, "");


                    //Assert
                    Assert.AreEqual(jobid, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    //Void
                    Timer.CancelTimerJob(spweb, jobid);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = true;
                    string _strresult = Timer.IsImportResourceAlreadyRunning(spweb);

                    //Assert
                    string expectedresult = "<ResourceImporter Success=\"True\" JobUid=\"" + jobid + "\" PercentComplete=\"0\" />";
                    Assert.AreEqual(expectedresult, _strresult);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    read = false;
                    string _strresult = Timer.IsSecurityJobAlreadyRunning(spweb, listid, 5);


                    //Assert
                    string expectedresult = "<SecurityJob Success=\"False\" />";
                    Assert.AreEqual(expectedresult, _strresult);
                }
            }
        }
    }
}