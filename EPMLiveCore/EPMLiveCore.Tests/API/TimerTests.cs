using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using Microsoft.SharePoint.Fakes;
using EPMLiveCore.Infrastructure.Logging.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;
using System.Web.Fakes;
using System.Xml;
using EPMLiveCore.Tests;
using Shouldly;

namespace EPMLiveCore.API.Tests
{
    [TestClass()]
    public class TimerTests
    {
        private Guid _jobId;
        private Guid _siteId;
        private Guid _webId;
        private Guid _listId;
        private bool _read = true;
        private ShimSPWeb _spWeb;

        private void SetupShims()
        {
            _jobId = Guid.NewGuid();
            _siteId = _jobId;
            _webId = _jobId;
            _listId = _jobId;
            _spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => _jobId
                },
                IDGet = () => _jobId
            };
            ShimSPSite.ConstructorGuid = (instance, _guid) => { };
            ShimSPSite.AllInstances.WebApplicationGet = instance =>
            {
                var webApp = new ShimSPWebApplication();
                return webApp;
            };
            ShimSPSite.AllInstances.Dispose = instance => { };
            ShimLoggingService.WriteTraceStringStringTraceSeverityString = (_, __, ___, ____) => { };

            ShimCoreFunctions.getConnectionStringGuid = instance => string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = instance => new ShimSqlDataReader
            {
                Read = () => _read,
                GetSqlInt32Int32 = _int =>
                {
                    _read = false;
                    return 20;
                },
                GetGuidInt32 = _int =>
                {
                    _read = false;
                    return _jobId;
                },
                GetDateTimeInt32 = _int =>
                {
                    _read = false;
                    return DateTime.MinValue.ToUniversalTime();
                },
                GetStringInt32 = _int =>
                {
                    _read = false;
                    return string.Empty;
                },
                IsDBNullInt32 = _int =>
                {
                    _read = false;
                    return false;
                }
            };

            ShimHttpUtility.HtmlEncodeString = a => a;

            _spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => _jobId
                },
                IDGet = () => _jobId
            };
            ShimSPSite.ConstructorGuid = (instance, guid) => { };
            ShimSPSite.AllInstances.WebApplicationGet = instance =>
            {
                var webApp = new ShimSPWebApplication();
                return webApp;
            };
            ShimSPSite.AllInstances.Dispose = instance => { };
            ShimLoggingService.WriteTraceStringStringTraceSeverityString = (_, __, ___, ____) => { };
            ShimCoreFunctions.getConnectionStringGuid = instance => string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = instance => new ShimSqlDataReader
            {
                Read = () => _read,
                GetSqlInt32Int32 = _int =>
                {
                    _read = false;
                    return 20;
                },
                GetGuidInt32 = _int =>
                {
                    _read = false;
                    return _jobId;
                },
                GetDateTimeInt32 = _int =>
                {
                    _read = false;
                    return DateTime.MinValue.ToUniversalTime();
                },
                GetStringInt32 = _int =>
                {
                    _read = false;
                    return string.Empty;
                },
                IsDBNullInt32 = _int =>
                {
                    _read = false;
                    return false;
                }
            };

            ShimHttpUtility.HtmlEncodeString = a => a;
        }

        [TestMethod()]
        public void GetTimerJobStatusTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                SetupShims();
                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    XmlNode ndStatus = Timer.GetTimerJobStatus(_spWeb, _jobId);
                    //Assert
                    string expectedresult = "<TimerJobStatus ID=\"" + _jobId + "\" Status=\"0\" PercentComplete=\"0\" Finished=\"" + DateTime.MinValue.ToUniversalTime() + "\" Result=\"\"><![CDATA[]]></TimerJobStatus>";
                    Assert.AreEqual("TimerJobStatus", ndStatus.Name);
                    Assert.AreEqual(expectedresult, ndStatus.OuterXml);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    XmlNode ndStatus = Timer.GetTimerJobStatus(_siteId, _webId, 0, true);

                    //Assert
                    string expectedresult = "<TimerJobStatus ID=\"" + _jobId + "\" Status=\"0\" PercentComplete=\"0\" Finished=\"" + DateTime.MinValue.ToUniversalTime() + "\">&lt;![CDATA[]]&gt;</TimerJobStatus>";
                    Assert.AreEqual("TimerJobStatus", ndStatus.Name);
                    Assert.AreEqual(expectedresult, ndStatus.OuterXml);
                }


                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    XmlNode ndStatus = Timer.GetTimerJobStatus(_siteId, _webId, _listId, 0, 0);

                    string expectedresult = "<TimerJobStatus ID=\"" + _jobId + "\" Status=\"0\" PercentComplete=\"0\" Finished=\"" + DateTime.MinValue.ToUniversalTime() + "\">&lt;![CDATA[]]&gt;</TimerJobStatus>";
                    //Assert
                    Assert.AreEqual("TimerJobStatus", ndStatus.Name);
                    Assert.AreEqual(expectedresult, ndStatus.OuterXml);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    Guid result = Timer.AddTimerJob(_siteId, _webId, _listId, 1, "", 1, "", "", 1, 0, "");

                    //Assert
                    Assert.AreEqual(_jobId, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    Guid result = Timer.AddTimerJob(_siteId, _webId, _listId, "", 1, "", "", 5, 2, "");


                    //Assert
                    Assert.AreEqual(_jobId, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    Guid result = Timer.AddTimerJob(_siteId, _webId, "", 1, "", "", 5, 3, "");


                    //Assert
                    Assert.AreEqual(_jobId, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    //Void
                    Timer.CancelTimerJob(_spWeb, _jobId);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    string _strresult = Timer.IsImportResourceAlreadyRunning(_spWeb);

                    //Assert
                    string expectedresult = "<ResourceImporter Success=\"True\" JobUid=\"" + _jobId + "\" PercentComplete=\"0\" />";
                    Assert.AreEqual(expectedresult, _strresult);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = false;
                    string _strresult = Timer.IsSecurityJobAlreadyRunning(_spWeb, _listId, 5);


                    //Assert
                    string expectedresult = "<SecurityJob Success=\"False\" />";
                    Assert.AreEqual(expectedresult, _strresult);
                }
            }
        }

        [TestMethod]
        public void AddTimerJob_SqlConnectionInvoke_VerifyMemoryLeak()
        {
            // Arrange
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                var sqlCommandConstructorCount = 0;
                var sqlCommandDisposeCount = 0;

                SetupShims();
                ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;
                ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => sqlCommandConstructorCount++;
                ShimComponent.AllInstances.Dispose = component =>
                {
                    if (component is SqlCommand)
                    {
                        sqlCommandDisposeCount++;
                    }
                };

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    var testObject = new Timer();
                    var privateObject = new PrivateObject(testObject);
                    privateObject.Invoke(
                        "AddTimerJob",
                        BindingFlags.Static | BindingFlags.NonPublic,
                        new ShimSqlConnection().Instance,
                        _siteId,
                        _webId,
                        _listId,
                        1,
                        string.Empty,
                        1,
                        string.Empty,
                        string.Empty,
                        1,
                        0,
                        string.Empty);
                }

                //Assert
                this.ShouldSatisfyAllConditions(
                    () => sqlCommandConstructorCount.ShouldBe(1),
                    () => sqlCommandDisposeCount.ShouldBe(1));
            }
        }

        [TestMethod]
        public void UpdateTimerJob_SqlConnectionInvoke_VerifyMemoryLeak()
        {
            // Arrange
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                var sqlCommandConstructorCount = 0;
                var sqlCommandDisposeCount = 0;

                SetupShims();
                ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;
                ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => sqlCommandConstructorCount++;
                ShimComponent.AllInstances.Dispose = component =>
                {
                    if (component is SqlCommand)
                    {
                        sqlCommandDisposeCount++;
                    }
                };

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    _read = true;
                    var testObject = new Timer();
                    var privateObject = new PrivateObject(testObject);
                    privateObject.Invoke(
                        "UpdateTimerJob",
                        BindingFlags.Static | BindingFlags.NonPublic,
                        new ShimSqlConnection().Instance,
                        _siteId,
                        string.Empty,
                        string.Empty,
                        1,
                        1,
                        string.Empty);
                }

                //Assert
                this.ShouldSatisfyAllConditions(
                    () => sqlCommandConstructorCount.ShouldBe(1),
                    () => sqlCommandDisposeCount.ShouldBe(1));
            }
        }
    }
}