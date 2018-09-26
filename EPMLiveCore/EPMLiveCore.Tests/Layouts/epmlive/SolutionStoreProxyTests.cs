using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Fakes;
using System.Text;
using System.Threading.Tasks;
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
        private const string WebId = "f41736f9-4ec8-4790-b5f8-668e74cddac5";

        private const string PageLoadMethod = "Page_Load";

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
                                              ows_ID=""{DummyInt}"" ows_Visible=""true"" ows_LinkFilename=""{DummyString}"" ows_Level=""{DummyString}"" ows_TemplateType=""{DummyString}"" ows_Icon=""{DummyString}""/>
                                   </rs:data>
                               </xml>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            
            return xmlDocument.SelectSingleNode("/xml");
        }

        private XmlNode CreateSvcListNode()
        {
            var xmlString = $@"<Root>
                                   <Data DisplayName=""Template Type"" StaticName=""{DummyString}"" />
                               </Root>";

            return null;
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameListAndMethodGetListItems_ConfirmResult()
        {
            // Arrange
            _webSvcName = "List";
            _webSvcMethod = "GetListItems";

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeTrue(),
                () => _responseText.ShouldBe("{Templates:{Template:{Id:&quot;1&quot;,Active:&quot;true&quot;,IncludeContent:&quot;false&quot;,Title:&quot;DummyString&quot;,Description:&quot;DummyString&quot;,Levels:&quot;DummyString&quot;,SalesInfo:&quot;DummyString&quot;,TemplateType:&quot;DummyString&quot;,TemplateCategory:&quot;DummyString&quot;,ImageUrl:&quot;DummyString&quot;}}}"));
        }

        [TestMethod]
        public void PageLoad_WhenSvcNameListAndMethodGetList_ConfirmResult()
        {
            // Arrange
            _webSvcName = "List";
            _webSvcMethod = "GetList";

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _responseWritten.ShouldBeTrue(),
                () => _responseText.ShouldBe("{Templates:{Template:{Id:&quot;1&quot;,Active:&quot;true&quot;,IncludeContent:&quot;false&quot;,Title:&quot;DummyString&quot;,Description:&quot;DummyString&quot;,Levels:&quot;DummyString&quot;,SalesInfo:&quot;DummyString&quot;,TemplateType:&quot;DummyString&quot;,TemplateCategory:&quot;DummyString&quot;,ImageUrl:&quot;DummyString&quot;}}}"));
        }
    }
}
