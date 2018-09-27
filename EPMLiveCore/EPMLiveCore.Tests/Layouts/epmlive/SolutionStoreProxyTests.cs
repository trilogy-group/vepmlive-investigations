using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Net.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SolutionStoreProxyTests
    {
        private IDisposable _shimObject;
        private SolutionStoreProxy _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private string _webSvcName;
        private string _webSvcMethod;
        private string _responseText;
        private bool _responseWritten;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com/";
        private const string DummyError = "Dummy Error";
        private const string DummyVersion = "1.0.0";
        private const string WebId = "f41736f9-4ec8-4790-b5f8-668e74cddac5";
        private const string DisplayName = "Template Type";

        private const string PageLoadMethod = "Page_Load";
        private const string SvcNameList = "List";
        private const string SvcMethodGetListItems = "GetListItems";
        private const string SvcMethodGetList = "GetList";
        private const string SvcMethodGetListItemsInXML = "GetListItemsInXML";
        private const string SvcNameCopy = "Copy";
        private const string SvcMethodCopyItem = "CopyItem";
        private const string SvcNameCustom = "Custom";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimObject = ShimsContext.Create();
            _testObj = new SolutionStoreProxy();
            _privateObj = new PrivateObject(_testObj);

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ParamsGet = () => new NameValueCollection
                {
                    ["data"] = CreateXmlData()
                }
            };
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                WriteString = text =>
                {
                    _responseText = text;
                    _responseWritten = true;
                }
            };

            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString = (_, _1, _2, _3, _4, _5, _6, _7) => CreateSvcNode();
            ShimLists.AllInstances.GetListString = (_, __) => CreateSvcListNode();

            ShimNetworkCredential.ConstructorStringStringString = (_, _1, _2, _3) => { };

            ShimCoreFunctions.getFarmSettingString = _ => DummyUrl;
            ShimCoreFunctions.GetAssemblyVersion = () => DummyVersion;

            _web = new ShimSPWeb
            {
                ServerRelativeUrlGet = () => "/"
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _web
            };
        }

        private string CreateXmlData()
        {
            return $@"<Data>
                        <Param key=""WebSvcName"">{_webSvcName}</Param>
                        <Param key=""WebSvcMethod"">{_webSvcMethod}</Param>
                        <Param key=""CompLevels"">{DummyString}</Param>
                        <Param key=""SolutionType"">{DummyString}</Param>
                        <Param key=""ListName"">{DummyString}</Param>
                        <Param key=""ViewName"">{DummyString}</Param>
                        <Param key=""Query"">{DummyString}</Param>
                        <Param key=""ViewFields"">{DummyString}</Param>
                        <Param key=""RowLimit"">{DummyString}</Param>
                        <Param key=""QueryOptions"">{DummyString}</Param>
                        <Param key=""WebID"">{WebId}</Param>
                     </Data>";
        }

        private XmlNode CreateSvcNode()
        {
            var separator = Environment.NewLine;
            var xmlString = $@"<xml xmlns:s=""uuid:BDC6E3F0-6DA3-11d1-A2A3-00AA00C14882"" xmlns:rs='urn:schemas-microsoft-com:rowset' xmlns:z='#RowsetSchema'>
                                   <s:Schema id=""RowsetSchema"" />
                                   <rs:data>
                                       <z:row ows_MetaInfo=""SiteTemplates|{DummyString}{separator}Description|{DummyString}{separator}TemplateCategory|{DummyString}{separator}SalesInfo|{DummyString}"" ows_SiteTemplates=""{DummyString}""
                                              ows_ID=""{DummyInt}"" ows_Visible=""{true}"" ows_LinkFilename=""{DummyString}"" ows_Level=""{DummyString}"" ows_TemplateType=""{DummyString}"" ows_Icon=""{DummyString}""/>
                                   </rs:data>
                               </xml>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            
            return xmlDocument.SelectSingleNode("/xml");
        }

        private XmlNode CreateSvcListNode()
        {
            var xmlString = $@"<Root>
                                   <Data>
                                       <Row DisplayName=""{DisplayName}"" StaticName=""{DummyString}"">
                                           <Choices>
                                               <Choice>{DummyString}</Choice>
                                           </Choices>
                                       </Row>
                                   </Data>
                               </Root>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument.SelectSingleNode("/Root");
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameListAndMethodGetListItems_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameList;
            _webSvcMethod = SvcMethodGetListItems;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeTrue(),
                () => _responseText.ShouldContain("{Templates:{Template:"),
                () => _responseText.ShouldContain($"Id:&quot;{DummyInt}&quot;"),
                () => _responseText.ShouldContain($"Active:&quot;{true}&quot;"),
                () => _responseText.ShouldContain($"IncludeContent:&quot;{false}&quot;"),
                () => _responseText.ShouldContain($"Title:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"Description:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"Levels:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"SalesInfo:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"TemplateType:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"TemplateCategory:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"ImageUrl:&quot;{DummyString}&quot;"));
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameListAndMethodGetList_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameList;
            _webSvcMethod = SvcMethodGetList;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeTrue(),
                () => _responseText.ShouldContain("{FilterFields:{Filter:"),
                () => _responseText.ShouldContain($"DisplayName:&quot;{DisplayName}&quot;"),
                () => _responseText.ShouldContain($"StaticName:&quot;{DummyString}&quot;"),
                () => _responseText.ShouldContain($"Choices:&quot;{DummyString};#&quot;"));
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameListAndMethodGetListItemsInXML_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameList;
            _webSvcMethod = SvcMethodGetListItemsInXML;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeTrue(),
                () => _responseText.ShouldContain("<Templates>"),
                () => _responseText.ShouldContain($"Id=\"{DummyInt}\""),
                () => _responseText.ShouldContain($"Active=\"{true}\""),
                () => _responseText.ShouldContain($"IncludeContent=\"{false}\""),
                () => _responseText.ShouldContain($"<Title><![CDATA[{DummyString}]]></Title>"),
                () => _responseText.ShouldContain($"<Description><![CDATA[{DummyString}]]></Description>"),
                () => _responseText.ShouldContain($"<Levels><![CDATA[{DummyString}]]></Levels>"),
                () => _responseText.ShouldContain($"<SalesInfo><![CDATA[{DummyString}]]></SalesInfo>"),
                () => _responseText.ShouldContain($"<TemplateType><![CDATA[{DummyString}]]></TemplateType>"),
                () => _responseText.ShouldContain($"<TemplateCategory><![CDATA[{DummyString}]]></TemplateCategory>"),
                () => _responseText.ShouldContain($"<ImageUrl><![CDATA[{DummyString}]]></ImageUrl>"));
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameListAndMethodInvalid_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameList;
            _webSvcMethod = DummyString;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeFalse(),
                () => _responseText.ShouldBeNullOrWhiteSpace());
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameCopyAndMethodCopyItem_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameCopy;
            _webSvcMethod = SvcMethodCopyItem;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeFalse(),
                () => _responseText.ShouldBeNullOrWhiteSpace());
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameCopyAndMethodInvalid_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameCopy;
            _webSvcMethod = DummyString;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeFalse(),
                () => _responseText.ShouldBeNullOrWhiteSpace());
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameCustom_ConfirmResult()
        {
            // Arrange
            _webSvcName = SvcNameCustom;
            _webSvcMethod = DummyString;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeFalse(),
                () => _responseText.ShouldBeNullOrWhiteSpace());
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameIsInvalid_ConfirmResult()
        {
            // Arrange
            _webSvcName = DummyString;
            _webSvcMethod = DummyString;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeFalse(),
                () => _responseText.ShouldBeNullOrWhiteSpace());
        }
    }
}
