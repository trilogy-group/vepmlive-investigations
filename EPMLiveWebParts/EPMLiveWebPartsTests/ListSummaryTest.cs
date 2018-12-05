using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.Utilities.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ListSummaryTest
    {
        private IDisposable _shimsContext;
        private PrivateObject _privateObject;
        private ListSummary _listSummary;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            var nameValueCollection = new NameValueCollection
            {
                ["lookupfield"] = "lookupfield",
                ["lookupfieldlist"] = "lookupfieldlist"
            };
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    QueryStringGet = () => nameValueCollection
                }
            };
            _listSummary = new ListSummary();
            _privateObject = new PrivateObject(_listSummary);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void CreateChildControls_Always_SetCheckFeature10()
        {
            // Arrange
            const int checkFeature = 10;
            ArrangeForCreateChildControls(checkFeature);

            // Act
            _privateObject.Invoke("CreateChildControls");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((int)_privateObject.GetFieldOrProperty("activation"))
                    .ShouldBe(checkFeature));
        }

        [TestMethod]
        public void CreateChildControls_Always_SetCheckFeature0()
        {
            // Arrange
            const int checkFeature = 0;
            ArrangeForCreateChildControls(checkFeature);

            // Act
            _privateObject.Invoke("CreateChildControls");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((int)_privateObject.GetFieldOrProperty("activation"))
                    .ShouldBe(checkFeature));
        }

        [TestMethod]
        public void GetReportFilters_Always_ReturnExpectedValue()
        {
            // Arrange
            var arrayList = new ArrayList
            {
                "DummyString1",
                "DummyString2",
                "DummyString3"
            };
            _privateObject.SetFieldOrProperty("reportFilterIDs", arrayList);

            // Act
            var result = _privateObject.Invoke("GetReportFilters") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(@"<Value Type=""Text"">DummyString1</Value><Value Type=""Text"">DummyString2</Value><Value Type=""Text"">DummyString3</Value>"));
        }

        [TestMethod]
        public void GetToolParts_Always_ReturnExpectedValue()
        {
            // Arrange
            ShimCustomPropertyToolPart.Constructor = instance => { };

            // Act
            var result = _listSummary.GetToolParts();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Length.ShouldBe(3),
                () => result[0].ShouldBeOfType<ListSummaryToolpart>(),
                () => result[1].ShouldBeOfType<WebPartToolPart>(),
                () => result[2].ShouldBeOfType<CustomPropertyToolPart>());
        }

        [TestMethod]
        public void ProcessWeb_Always_SetExpectedValues()
        {
            // Arrange
            var spWeb = ArrangeSharePoint();
            ShimLookupFilterHelper.AppendLookupQueryToExistingQueryXmlDocumentRefStringString =
                (ref XmlDocument xmlQuery, string lookupField, string lookupFieldList) => { };
            ShimListSummary.AllInstances.ProcessReportFilterXmlDocumentSPListSPWeb =
                (_1, _2, _3, _4) => "reportInternal";
            _listSummary.PropStatus = "PropStatus";
            _privateObject.SetFieldOrProperty("reportFilterIDs", (ArrayList)new ShimArrayList
            {
                CountGet = () => 300,
                ContainsObject = objectValue => false
            });
            _privateObject.SetFieldOrProperty("reportFilterField", "reportFilterField");

            // Act
            _privateObject.Invoke("processWeb", spWeb);

            // Assert
            ((string)_privateObject.GetFieldOrProperty("sErrors")).ShouldBeEmpty();
        }

        [TestMethod]
        public void RenderWebPart_Always_ReturnExpectedValue()
        {
            // Arrange
            var writtenText = new StringBuilder();
            HtmlTextWriter htmlTextWriter = new ShimHtmlTextWriter
            {
                WriteString = text => writtenText.Append(text)
            };
            ArrangeForRenderWebPart();

            // Act
            _privateObject.Invoke("RenderWebPart", htmlTextWriter);

            // Assert
            writtenText.ToString()
                .ShouldBe(
                    Properties.Resources.ListSummaryTestRenderWebPartAlwaysReturnExpectedValueExpectedValue);
        }

        private void ArrangeForRenderWebPart()
        {
            _privateObject.SetFieldOrProperty("activation", 0);
            _privateObject.SetFieldOrProperty("reportFilterField", "reportFilterField");
            if (string.IsNullOrWhiteSpace(_listSummary.PropList))
            {
                _listSummary.PropList = "PropList";
            }
            if (string.IsNullOrWhiteSpace(_listSummary.PropView))
            {
                _listSummary.PropView = "PropView";
            }
            if (string.IsNullOrWhiteSpace(_listSummary.PropStatus))
            {
                _listSummary.PropStatus = "PropStatus";
            }
            if (string.IsNullOrWhiteSpace(_listSummary.PropRollupSites))
            {
                _listSummary.PropRollupSites = "PropRollupSites";
            }
            if (string.IsNullOrWhiteSpace(_listSummary.PropRollupList))
            {
                _listSummary.PropRollupList = "PropRollupList";
            }
            if (string.IsNullOrWhiteSpace(_listSummary.PropUrl))
            {
                _listSummary.PropUrl = "PropUrl";
            }
            ArrangeSharePoint();
            ArrangeSqlConnection();
            ShimCoreFunctions.getConnectionStringGuid = webAppId => "connectionString";
            ShimLookupFilterHelper.AppendLookupQueryToExistingQueryXmlDocumentRefStringString =
                (ref XmlDocument xmlQuery, string lookupField, string lookupFieldList) => { };

            _listSummary.ReportIDConsumer(new StubIReportID
            {
                ReportIDGet = () => "reportID"
            });
        }

        private void ArrangeForCreateChildControls(int checkFeature)
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb()
            };
            ShimAct.ConstructorSPWeb = (instance, spWeb) => new ShimAct(instance)
            {
                CheckFeatureLicenseActFeature = actFeature => checkFeature
            };
        }

        private SPWeb ArrangeSharePoint()
        {
            var shimSpWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser { IDGet = () => 10 },
                GetSiteDataSPSiteDataQuery = spSiteDataQuery => new DataTable
                {
                    Columns = { "reportFilterField", "PropStatus" },
                    Rows = { "row1", "PropStatus" }
                },
                GetListFromUrlString = propList => new ShimSPList
                {
                    FieldsGet = () =>
                    {
                        var shim = new ShimSPFieldLookup
                        {
                            LookupListGet = () => "efa2349b-8e03-444e-a690-3853df96e228"
                        };
                        new ShimSPField(shim)
                        {
                            TypeGet = () => SPFieldType.Lookup
                        };
                        var list = new List<SPField>
                        {
                            shim
                        };
                        var shimSpFieldCollection = new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = propStatus =>
                                new ShimSPField
                                {
                                    SchemaXmlGet = () => "<root><CHOICE>Status</CHOICE></root>",
                                    TypeGet = () => SPFieldType.Choice
                                }
                        };
                        new ShimSPBaseCollection(shimSpFieldCollection)
                        {
                            GetEnumerator = () => list.GetEnumerator()
                        };
                        return shimSpFieldCollection;
                    },
                    ViewsGet = () => new ShimSPViewCollection
                    {
                        ItemGetString = stringKey => new ShimSPView
                        {
                            QueryGet = () => "<Where>InnerXml</Where>"
                        }
                    }
                },
                ServerRelativeUrlGet = () => "dummy",
                SiteGet = () => new ShimSPSite
                {
                    WebApplicationGet = () =>
                    {
                        var shim = new ShimSPWebApplication();
                        new ShimSPPersistedObject(shim)
                        {
                            IdGet = () => Guid.Empty
                        };
                        return shim;
                    }
                }
            };
            ShimSPSite.ConstructorString = (instance, site) =>
                new ShimSPSite(instance)
                {
                    Dispose = () => { },
                    OpenWeb = () => shimSpWeb
                };
            ShimSPSite.ConstructorGuid = (instance, siteGuid) =>
                new ShimSPSite(instance)
                {
                    Dispose = () => { },
                    OpenWeb = () => shimSpWeb,
                    ContentDatabaseGet = () =>
                    {
                        var shim = new ShimSPContentDatabase();
                        new ShimSPDatabase(shim)
                        {
                            DatabaseConnectionStringGet = () => "connectionString"
                        };
                        return shim;
                    }
                };
            ShimSPContext.CurrentGet = () => new ShimSPContext { WebGet = () => shimSpWeb };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated =
                codeToRun => codeToRun();

            return shimSpWeb;
        }

        private void ArrangeSqlConnection()
        {
            ShimSqlConnection.ConstructorString = (instance, connectionString) => new ShimSqlConnection(instance)
            {
                Open = () => { },
                Close = () => { }
            };
            var guid = new Guid("efa2349b-8e03-444e-a690-3853df96e228");
            var dataReaderValues = new Dictionary<string, Guid>
            {
                ["dummyString1"] = guid,
                ["dummyString2"] = guid,
            };
            var enumerator = dataReaderValues.GetEnumerator();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => 0;
            var shimExecuteReader = new ShimSqlDataReader
            {
                Close = () => { },
                GetStringInt32 = intValue => enumerator.Current.Key,
                GetGuidInt32 = intValue => enumerator.Current.Value,
                Read = () => enumerator.MoveNext()
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance => shimExecuteReader;
            ShimSqlCommand.ConstructorStringSqlConnection =
                (sqlCommand, stringConnectionString, connection) =>
                    new ShimSqlCommand(sqlCommand)
                    {
                        ExecuteReader = () => shimExecuteReader
                    };
        }
    }
}
