using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetitemsTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string DescriptionIndicator = "Indicator";
        private const string ExampleUrl = "http://example.com";
        private const string MethodPageLoad = "Page_Load";
        private const string FieldData = "data";
        private getitems _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringWriter _responseWriter;
        private HttpResponse _httpResponse;
        private string _fieldXml;
        private string _value;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new getitems();
            _privateObject = new PrivateObject(_testObject);

            _responseWriter = new StringWriter();
            _httpResponse = new HttpResponse(_responseWriter);
            _fieldXml = "<field></field>";
            _value = $"1;#{One}";
            ShimHttpResponse.AllInstances.ExpiresSetInt32 = (_, __) => { };

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite().Instance;
            ShimSharePoint();

            ShimPage.AllInstances.ResponseGet = _ => _httpResponse;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = key =>
                {
                    if (key.Equals(FieldData))
                    {
                        return GetData();
                    }

                    return DummyString;
                }
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _responseWriter?.Dispose();
        }

        [TestMethod]
        public void PageLoad_User_FillsData()
        {
            // Arrange
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            _value = "X=1";

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var data = _privateObject.GetFieldOrProperty(FieldData) as string;
            data.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => data.ShouldContainWithoutWhitespace("<column type=\"tree\" width=\"400\" id=\"Title\" align=\"left\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"img\" width=\"400\" id=\"~Icon\" align=\"center\">Type</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ch\" width=\"400\" id=\"~Complete\" align=\"center\">Complete</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ro\" width=\"400\" id=\"~List\" align=\"left\">List Name</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ro\" width=\"400\" id=\"~Site\" align=\"left\">Site Name</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"edn\" width=\"400\" id=\"Percent\" align=\"right\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ro\" width=\"400\" id=\"DateTime\" align=\"right\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ro\" width=\"400\" id=\"DateOnly\" align=\"right\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ro\" width=\"400\" id=\"Currency\" align=\"right\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ro\" width=\"400\" id=\"Indicator\" align=\"center\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"edn\" width=\"400\" id=\"Number\" align=\"left\">displayname</column>"),
                () => data.ShouldContainWithoutWhitespace("<column type=\"ed\" width=\"400\" id=\"Other\" align=\"left\">displayname</column>"));
        }

        [TestMethod]
        public void PageLoad_CalculatedText_FillsData()
        {
            // Arrange
            _fieldXml = "<field ResultType='Text'></field>";
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPField.AllInstances.DescriptionGet = _ => DescriptionIndicator;

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var data = _privateObject.GetFieldOrProperty(FieldData) as string;
            data.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => data.ShouldContainWithoutWhitespace("<cell>NewItem</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>List Display</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>1#;1</cell>"),
                () => data.ShouldContainWithoutWhitespace("<userdata name=\"SiteUrl\"></userdata>"),
                () => data.ShouldContainWithoutWhitespace("<userdata name=\"listid\">00000000-0000-0000-0000-000000000000</userdata>"),
                () => data.ShouldContainWithoutWhitespace($"<userdata name=\"viewurl\">{ExampleUrl}</userdata>"),
                () => data.ShouldContainWithoutWhitespace($"<userdata name=\"editurl\">{ExampleUrl}</userdata>"),
                () => data.ShouldContainWithoutWhitespace("<cell type=\"tree\"><![CDATA[<img src=\"/_layouts/images/1#;1\">]]></cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/1#;1\">]]></cell>"),
                () => data.ShouldContainWithoutWhitespace("</row></row></row></rows>"));
        }

        [TestMethod]
        public void PageLoad_CalculatedCurrency_FillsData()
        {
            // Arrange
            _fieldXml = "<field ResultType='Currency'></field>";
            _value = One;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPField.AllInstances.DescriptionGet = _ => DescriptionIndicator;

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var data = _privateObject.GetFieldOrProperty(FieldData) as string;
            data.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => data.ShouldContainWithoutWhitespace("<beforeInit><call command=\"setNumberFormat\"><param>000%</param><param>5</param></call></beforeInit>"),
                () => data.ShouldContainWithoutWhitespace("<cell>NewItem</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>List Display</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>$1.00</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>_layouts/images/blank.gif</cell>"),
                () => data.ShouldContainWithoutWhitespace("<userdata name=\"SiteUrl\"></userdata>"),
                () => data.ShouldContainWithoutWhitespace("<userdata name=\"listid\">00000000-0000-0000-0000-000000000000</userdata>"),
                () => data.ShouldContainWithoutWhitespace($"<userdata name=\"viewurl\">{ExampleUrl}</userdata>"),
                () => data.ShouldContainWithoutWhitespace($"<userdata name=\"editurl\">{ExampleUrl}</userdata>"),
                () => data.ShouldContainWithoutWhitespace("<cell><![CDATA[<img src=\"/_layouts/images/1#;1\">]]></cell>"),
                () => data.ShouldContainWithoutWhitespace("</row></row></row></rows>"));
        }

        [TestMethod]
        public void PageLoad_CalculatedNumber_FillsData()
        {
            // Arrange
            _fieldXml = $"<field ResultType='Number' Decimals='{One}'></field>";
            _value = One;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPField.AllInstances.DescriptionGet = _ => DescriptionIndicator;

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var data = _privateObject.GetFieldOrProperty(FieldData) as string;
            data.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => data.ShouldContainWithoutWhitespace("<cell>NewItem</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>List Display</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>1.0</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>_layouts/images/blank.gif</cell>"),
                () => data.ShouldContainWithoutWhitespace("<userdata name=\"SiteUrl\"></userdata>"),
                () => data.ShouldContainWithoutWhitespace("<userdata name=\"listid\">00000000-0000-0000-0000-000000000000</userdata>"),
                () => data.ShouldContainWithoutWhitespace($"<userdata name=\"viewurl\">{ExampleUrl}</userdata>"),
                () => data.ShouldContainWithoutWhitespace($"<userdata name=\"editurl\">{ExampleUrl}</userdata>"),
                () => data.ShouldContainWithoutWhitespace("<cell id=\"Indicator\" type=\"ro\" />"),
                () => data.ShouldContainWithoutWhitespace("<cell id=\"Number\" type=\"ro\" />"));
        }

        [TestMethod]
        public void PageLoad_DateTime_FillsData()
        {
            // Arrange
            var date = DateTime.Today;
            _value = date.ToString();
            _fieldXml = "<field Format='DateOnly'></field>";
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var data = _privateObject.GetFieldOrProperty(FieldData) as string;
            data.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => data.ShouldContainWithoutWhitespace($"<cell>{date.Month}/{date.Day}/{date.Year}</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell type=\"dhxCalendarA\"><![CDATA[1#;1]]></cell>"));
        }

        [TestMethod]
        public void PageLoad_Text_FillsData()
        {
            // Arrange
            _fieldXml = "<field Format='DateOnly'></field>";
            _value = DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var data = _privateObject.GetFieldOrProperty(FieldData) as string;
            data.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => data.ShouldContainWithoutWhitespace("<cell>&lt;input /&gt;</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell><![CDATA[<a href=\"\">NewItem</a>]]></cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell>1</cell>"),
                () => data.ShouldContainWithoutWhitespace("<cell><![CDATA[<input"));
        }

        private void ShimSharePoint()
        {
            var webId = Guid.NewGuid();
            var fieldId = Guid.NewGuid();
            
            var field = new ShimSPField
            {
                IdGet = () => fieldId,
                SchemaXmlGet = () => _fieldXml,
                GetFieldValueAsHtmlObject = _ => "<input />"
            };
            var fields = new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => field,
                ItemGetGuid = x => field
            };
            var listItems = new List<SPListItem>()
            {
                new ShimSPListItem
                {
                    ItemGetString = i => "ListItemToString",
                    ItemGetGuid = i => $"1#;{One}"
                },
                new ShimSPListItem
                {
                    ItemGetString = i => "OtherListItemToString",
                    ItemGetGuid = i => _value
                }
            };
            var list = new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    GetEnumerator = () => listItems.GetEnumerator()
                },
                FormsGet = () => new ShimSPFormCollection
                {
                    ItemGetPAGETYPE = _ => new ShimSPForm
                    {
                        UrlGet = () => ExampleUrl
                    }
                }
            };
            var web = new ShimSPWeb
            {
                IDGet = () => webId,
                TitleGet = () => "NewItem",
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = __ => list
                },
            };
            ShimSPField.AllInstances.DescriptionGet = _ => DescriptionIndicator;
            ShimSPListItem.AllInstances.FieldsGet = _ => fields;
            ShimSPList.AllInstances.FieldsGet = _ => fields;
            ShimSPList.AllInstances.ParentWebGet = _ => web;
            ShimSPListItem.AllInstances.ParentListGet = _ => list;
            ShimSPContext.AllInstances.WebGet = _ => web;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) =>  { };
        }
        
        private string GetData()
        {
            return $@"<Views>
                        <View Name='{DummyString}' Default='1' WBS='pWBS.'>
                            <Column Name='Title' Format='Format' Display='displayname' Width='400'></Column>
                            <Column Name='~Icon' Format='Format' Display='displayname' Width='400'></Column>
                            <Column Name='~Complete' Format='Format' Display='displayname' Width='400'></Column>
                            <Column Name='~List' Format='Format' Display='displayname' Width='400'></Column>
                            <Column Name='~Site' Format='Format' Display='displayname' Width='400'></Column>
                            <Column Name='Percent' Format='Percent' Display='displayname' Width='400'></Column>
                            <Column Name='DateTime' Format='DateTime' Display='displayname' Width='400'></Column>
                            <Column Name='DateOnly' Format='DateOnly' Display='displayname' Width='400'></Column>
                            <Column Name='Currency' Format='Currency' Display='displayname' Width='400'></Column>
                            <Column Name='Indicator' Format='Indicator' Display='displayname' Width='400'></Column>
                            <Column Name='Number' Format='Number' Display='displayname' Width='400'></Column>
                            <Column Name='Other' Format='Other' Display='displayname' Width='400'></Column>
                            <GroupBy Column='~Site' Expand='1'></GroupBy>
                            <GroupBy Column='~List' Expand='1'></GroupBy>
                            <GroupBy Column='~Else' Expand='1'></GroupBy>
                            <Lists>
                                <List Name='ListName' Display='List Display' Icon='Icon.png'>
                                    <Query>Query #FilterQuery#</Query>
                                    <FilterQuery List='FilteQueryrList' DataColumn='DataColumn' ChildColumn='ChildColumn'>FilterQuery</FilterQuery>m
                    
                                </List>
                            </Lists>
                        </View>
                    </Views>";
        }
    }
}
