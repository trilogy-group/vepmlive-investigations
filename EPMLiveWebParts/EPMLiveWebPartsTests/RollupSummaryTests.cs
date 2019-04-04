using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.RollupSummary;
using EPMLiveWebParts.RollupSummary.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using RollupSummaryEntity = EPMLiveWebParts.RollupSummary.RollupSummary;

namespace EPMLiveWebParts.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class RollupSummaryTests
    {
        private IDisposable _shimContext;
        private RollupSummaryEntity _testEntity;
        private PrivateObject _privateObject;
        private StringWriter _stringWriter;
        private HtmlTextWriter _htmlTextWriter;
        private ShimSPContext _currentContext;
        private ShimSPWeb _currentContextWeb;

        private const string RenderWebPartMethodName = "RenderWebPart";
        private const string ProcessItemMethodName = "processItem";
        private const string ProcessDisplayMethodName = "processDisplay";
        private const string ProcessWebMethodName = "processWeb";
        private const string GetCountMethodName = "getCount";

        private const string DummyConnectString = "DummyConnectString";
        private static readonly Guid DummyGuidSite = new Guid("779fb072-0fb8-41b2-bfd4-76be4f367393");
        private static readonly Guid DummyGuid = new Guid("1d0e32d5-b3c5-4bbc-a17a-2c23f429de91");
        private const string DummyUrl = "DummyUrl";
        private const string DummyString = "DummyString";
        private const string DummyStringWithSpace = "    ";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new RollupSummaryEntity();
            _privateObject = new PrivateObject(_testEntity);
            _stringWriter = new StringWriter();
            _htmlTextWriter = new HtmlTextWriter(_stringWriter);

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            _currentContextWeb = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                    {
                        FeaturesGet = () => new ShimSPFeatureCollection()
                    }
                },
                ServerRelativeUrlGet = () => "/",
                GetSiteDataSPSiteDataQuery = query => new DataTable(),
                UrlGet = () => DummyUrl
            };

            _currentContext = new ShimSPContext()
            {
                WebGet = () => _currentContextWeb,
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummyGuidSite
                }
            };
            ShimSPContext.CurrentGet = () => _currentContext;

            var spContentDataBase = new ShimSPContentDatabase();

            var spDatabase = new ShimSPDatabase(spContentDataBase)
            {
                DatabaseConnectionStringGet = () => DummyConnectString
            };

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                ContentDatabaseGet = () => spContentDataBase,
                OpenWeb = () => _currentContextWeb
            };

            ShimSPSite.ConstructorString = (sender, name) => new ShimSPSite(sender)
            {
                ContentDatabaseGet = () => spContentDataBase,
                OpenWeb = () => _currentContextWeb
            };

            ShimSqlConnection.ConstructorString = (sender, connectionString) => new ShimSqlConnection(sender);
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testEntity?.Dispose();
            _shimContext?.Dispose();
            _stringWriter?.Dispose();
            _htmlTextWriter?.Dispose();
        }

        [TestMethod]
        public void RenderWebPart_Activation1_WriteHtmlTextWriter()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 1;

            // Act
            _privateObject.Invoke(RenderWebPartMethodName, _htmlTextWriter);

            // Assert
            _htmlTextWriter.InnerWriter.ToString().ShouldBe("This feature has not been activated.");
        }

        [TestMethod]
        public void RenderWebPart_Activation0_WriteHtmlTextWriter()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            var countRead = 0;

            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => countRead++ < 1,
                GetGuidInt32 = pos => DummyGuid
            };

            var expectedResult = new List<string>()
            {
                "<table cellpadding=\"1\" cellspacing=\"1\" style=\"margin:10px;\" class=\"ms-stdtxt\">",
                "<tr>",
                "<td colspan=\"4\">",
                "<font class=\"ms-sectionheader\">",
                "<a class=\"ms-sectionheader\" href=\"/mywork.aspx\">Tasks</a></td></tr>",
                "<td nowrap=\"nowrap\" width=\"27\">",
                "<img src=\"_layouts/images/newtask.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<td nowrap=\"nowrap\" colspan=\"3\">",
                "<span class=\"ms-stdtxt\">You have No New Tasks assigned to you.</span></td></tr>",
                "<img src=\"_layouts/images/newtask.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<span class=\"ms-stdtxt\">You have No Overdue Tasks assigned to you.</span></td></tr>",
                "<td>&nbsp;</td></tr>",
                "<a class=\"ms-sectionheader\" href=\"/mywork.aspx\">Issues and Risks</a></td></tr>",
                "<img src=\"_layouts/images/MyIssues.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<span class=\"ms-stdtxt\">You have No Active Issues assigned to you.</span></td></tr>",
                "<img src=\"_layouts/images/MyRisks.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<span class=\"ms-stdtxt\">You have No Active Risks assigned to you.</span></td></tr>",
                "</table>"
            };

            // Act
            _privateObject.Invoke(RenderWebPartMethodName, _htmlTextWriter);

            // Assert
            var actualWriter = _htmlTextWriter.InnerWriter.ToString();

            this.ShouldSatisfyAllConditions(
                () => actualWriter.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualWriter.ShouldContain(c)));
        }

        [TestMethod]
        public void RenderWebPart_Activation0DuplicatedIdRollUpSitesFilled_WriteHtmlTextWriter()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            var countRead = 0;

            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => countRead++ < 1,
                GetGuidInt32 = pos => DummyGuid
            };

            _testEntity.MyXml = GetXmlSameId();
            _testEntity.MyRollupSites = $"{DummyUrl}\nInvalid";

            var expectedResult = new List<string>()
            {
                "Warning: Duplicate Item ID's Found",
                "<table cellpadding=\"1\" cellspacing=\"1\" style=\"margin:10px;\" class=\"ms-stdtxt\">",
                "<tr>",
                "<td colspan=\"4\">",
                "<font class=\"ms-sectionheader\">",
                "<a class=\"ms-sectionheader\" href=\"/mywork.aspx\">Tasks</a></td></tr>",
                "<td nowrap=\"nowrap\" width=\"27\">",
                "<img src=\"_layouts/images/newtask.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<td nowrap=\"nowrap\" colspan=\"3\">",
                "<span class=\"ms-stdtxt\">You have No New Tasks assigned to you.</span></td></tr>",
                "<img src=\"_layouts/images/newtask.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<span class=\"ms-stdtxt\">You have No Overdue Tasks assigned to you.</span></td></tr>",
                "<td>&nbsp;</td></tr>",
                "<a class=\"ms-sectionheader\" href=\"/mywork.aspx\">Issues and Risks</a></td></tr>",
                "<img src=\"_layouts/images/MyIssues.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<span class=\"ms-stdtxt\">You have No Active Issues assigned to you.</span></td></tr>",
                "<img src=\"_layouts/images/MyRisks.gif\" alt=\"\" style=\"border-width:0px;\" /></td>",
                "<span class=\"ms-stdtxt\">You have No Active Risks assigned to you.</span></td></tr>",
                "</table>"
            };

            // Act
            _privateObject.Invoke(RenderWebPartMethodName, _htmlTextWriter);

            // Assert
            var actualWriter = _htmlTextWriter.InnerWriter.ToString();

            this.ShouldSatisfyAllConditions(
                () => actualWriter.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualWriter.ShouldContain(c)));
        }

        [TestMethod]
        public void RenderWebPart_InvalidXml_WriteHtmlTextWriter()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            _testEntity.MyXml = "Invalid";

            // Act
            _privateObject.Invoke(RenderWebPartMethodName, _htmlTextWriter);

            // Assert
            var actualWriter = _htmlTextWriter.InnerWriter.ToString();

            actualWriter.ShouldBe("Failed to load XML: Data at the root level is invalid. Line 1, position 1.");
        }

        [TestMethod]
        public void GetToolParts_Should_ReturnsToolParts()
        {
            // Arrange, Act
            var actualResult = _testEntity.GetToolParts();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Length.ShouldBe(3),
                () => actualResult[0].ShouldBeOfType<WebPartToolPart>(),
                () => actualResult[1].ShouldBeOfType<CustomPropertyToolPart>(),
                () => actualResult[2].ShouldBeOfType<SummaryRollupToolpart>());
        }

        [TestMethod]
        public void ProcessItem_WithoutAtt_WriteStringBuilder()
        {
            // Arrange
            var doc = new XmlDocument();
            doc.LoadXml("<Displays></Displays>");

            var displayNode = doc.FirstChild;

            var hshNodes = new Hashtable
            {
                { string.Empty, 0 }
            };
            _privateObject.SetField("hshCounts", hshNodes);

            ShimRollupSummary.AllInstances.processDisplayXmlNodeInt32 = (sender, displays, count) => { };

            // Act
            _privateObject.Invoke(ProcessItemMethodName, displayNode);

            // Assert
            var stringBuilder = (StringBuilder)_privateObject.GetField("sb");

            stringBuilder.ToString().ShouldBe("<tr><td nowrap=\"nowrap\" width=\"27\"></td></tr>");
        }

        [TestMethod]
        public void ProcessDisplay_GtBiggerCountVal_WriteStringBuilder()
        {
            // Arrange
            var doc = new XmlDocument();
            doc.LoadXml($@"<Displays><Display Comparator=""GT"" Value=""1""><![CDATA[{DummyString}]]></Display></Displays>");

            var displayNode = doc.FirstChild;

            _privateObject.SetField("web", _currentContextWeb.Instance);

            // Act
            _privateObject.Invoke(ProcessDisplayMethodName, displayNode, 10);

            // Assert
            var stringBuilder = (StringBuilder)_privateObject.GetField("sb");

            stringBuilder.ToString().ShouldBe($"<td nowrap=\"nowrap\" colspan=\"3\"><span class=\"ms-stdtxt\">{DummyString}</span></td>");
        }

        [TestMethod]
        public void ProcessDisplay_LtBiggerCountVal_WriteStringBuilder()
        {
            // Arrange
            var doc = new XmlDocument();
            doc.LoadXml($@"<Displays><Display Comparator=""LT"" Value=""1""><![CDATA[{DummyString}]]></Display></Displays>");

            var displayNode = doc.FirstChild;

            _privateObject.SetField("web", _currentContextWeb.Instance);

            // Act
            _privateObject.Invoke(ProcessDisplayMethodName, displayNode, 10);

            // Assert
            var stringBuilder = (StringBuilder)_privateObject.GetField("sb");

            stringBuilder.ToString().ShouldBe("<td nowrap=\"nowrap\" colspan=\"3\"><span class=\"ms-stdtxt\"></span></td>");
        }

        [TestMethod]
        public void ProcessWeb_WithoutAtt_WriteStringBuilder()
        {
            // Arrange
            var doc = new XmlDocument();
            doc.LoadXml("<Displays></Displays>");

            var displayNode = doc.FirstChild;

            var hshNodes = new Hashtable
            {
                { 1, displayNode }
            };

            _privateObject.SetField("hshNodes", hshNodes);

            // Act
            _privateObject.Invoke(ProcessWebMethodName, _currentContextWeb.Instance);

            // Assert
            var stringBuilder = (StringBuilder)_privateObject.GetField("sb");

            stringBuilder.ToString().ShouldContain("ERROR: Object reference not set to an instance of an object");
        }

        [TestMethod]
        public void GetCount_ErrorConnection_WriteStringBuilder()
        {
            // Arrange
            var spWeb = new ShimSPWeb()
            {
                ServerRelativeUrlGet = () => "/DummyRelative/"
            };

            // Act
            var actualResult = _privateObject.Invoke(GetCountMethodName, string.Empty, string.Empty, spWeb.Instance);

            // Assert
            var stringBuilder = (StringBuilder)_privateObject.GetField("sb");

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe(0),
                () => stringBuilder.ToString().ShouldContain("ERROR: ExecuteReader: Connection property has not been initialized."));
        }

        [TestMethod]
        public void Title_Get_ReturnsString()
        {
            // Arrange
            _testEntity.Title = DummyString;

            // Act
            var actualResult = _testEntity.Title;

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void MyRollupSites_SetWithSpaceString_ReturnsStringEmpty()
        {
            // Arrange
            _testEntity.MyRollupSites = DummyStringWithSpace;

            // Act
            var actualResult = _testEntity.MyRollupSites;

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void MyRollupSites_Get_ReturnsString()
        {
            // Arrange
            _testEntity.MyRollupSites = DummyString;

            // Act
            var actualResult = _testEntity.MyRollupSites;

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        private string GetXmlSameId()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Sections>")
               .Append("<Section URL=\"{WebUrl}/mywork.aspx\" Title=\"Tasks\">")
               .Append("<Items>")
               .Append("<Item Icon=\"_layouts/images/newtask.gif\" ID=\"1\">")
               .Append("<Query List=\"Task Center\">")
               .Append("<![CDATA[<And><Eq><FieldRef Name=\'AssignedTo\'/><Value Type=\'Integer\'><UserID/></Value></Eq><Gt><FieldRef Name=\'Created\'/><Value Type=\'DateTime\'><Today OffsetDays=\"-2\"/></Value></Gt></And>]]>")
               .Append("</Query>")
               .Append("<Displays>")
               .Append("<Display Comparator=\"GT\" Value=\"1\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} New Tasks</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display Comparator=\"GT\" Value=\"0\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} New Task</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display>")
               .Append("<![CDATA[You have No New Tasks assigned to you.]]>")
               .Append("</Display>")
               .Append("</Displays>")
               .Append("</Item>")
               .Append("<Item Icon=\"_layouts/images/newtask.gif\" ID=\"1\">")
               .Append("<Query List=\"Task Center\">")
               .Append("<![CDATA[<And><Eq><FieldRef Name=\'AssignedTo\'/><Value Type=\'Integer\'><UserID/></Value></Eq><And><Neq><FieldRef Name=\'PercentComplete\'/><Value Type=\'Number\'>1</Value></Neq><Lt><FieldRef Name=\'DueDate\'/><Value Type=\'Text\'><Today/></Value></Lt></And></And>]]>")
               .Append("</Query>")
               .Append("<Displays>")
               .Append("<Display Comparator=\"GT\" Value=\"1\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} Overdue Tasks</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display Comparator=\"GT\" Value=\"0\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} Overdue Task</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display>")
               .Append("<![CDATA[You have No Overdue Tasks assigned to you.]]>")
               .Append("</Display>")
               .Append("</Displays>")
               .Append("</Item>")
               .Append("</Items>")
               .Append("</Section>")
               .Append("<Section URL=\"{WebUrl}/mywork.aspx\" Title=\"Issues and Risks\">")
               .Append("<Items>")
               .Append("<Item Icon=\"_layouts/images/MyIssues.gif\" ID=\"3\">")
               .Append("<Query List=\"Issues\">")
               .Append("<![CDATA[<An")
               .Append("d><Eq><FieldRef Name=\'AssignedTo\'/><Value Type=\'Integer\'><UserID/></Value></Eq><Eq><FieldRef Name=\'Status\'/><Value Type=\'Choice\'>Active</Value></Eq></And>]]>")
               .Append("</Query>")
               .Append("<Displays>")
               .Append("<Display Comparator=\"GT\" Value=\"1\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} Active Issues</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display Comparator=\"GT\" Value=\"0\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} Active Issue</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display>")
               .Append("<![CDATA[You have No Active Issues assigned to you.]]>")
               .Append("</Display>")
               .Append("</Displays>")
               .Append("</Item>")
               .Append("<Item Icon=\"_layouts/images/MyRisks.gif\" ID=\"4\">")
               .Append("<Query List=\"Risks\">")
               .Append("<![CDATA[<And><Eq><FieldRef Name=\'Assigned_x0020_To\'/><Value Type=\'Integer\'><UserID/></Value></Eq><Eq><FieldRef Name=\'Status\'/><Value Type=\'Choice\'>Active</Value></Eq></And>]]>")
               .Append("</Query>")
               .Append("<Displays>")
               .Append("<Display Comparator=\"GT\" Value=\"1\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} Active Risks</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display Comparator=\"GT\" Value=\"0\">")
               .Append("<![CDATA[You have <a href=\"{WebUrl}/mywork.aspx\">{#} Active Risk</a> assigned to you.]]>")
               .Append("</Display>")
               .Append("<Display>")
               .Append("<![CDATA[You have No Active Risks assigned to you.]]>")
               .Append("</Display>")
               .Append("</Displays>")
               .Append("</Item>")
               .Append("</Items>")
               .Append("</Section></Sections>");

            return stringBuilder.ToString();
        }
    }
}
