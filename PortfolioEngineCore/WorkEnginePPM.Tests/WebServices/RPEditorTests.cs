using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;
using static WorkEnginePPM.RPEditor;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public class RPEditorTests
    {
        private IDisposable _shimContext;
        private PrivateType _privateType;

        private const string ProcessAnyNotificationsMethodName = "ProcessAnyNotifications";

        private const string DummyString = "DummyString";
        private const string DummyUrl = "DummyUrl";
        private const string DummyUsername = "DummyUsername";
        private const string Guid1 = "09300413-df4c-4f30-8902-11a46dcb4adb";
        private const string Guid2 = "9063fd88-560a-4c43-a7f3-30ebc1e940bc";
        private const string DummyResourceName = "ResourceName100";
        private const string ExpectedTitlePm = "PM Message";
        private const string ExpectedTitleRm = "RM Message";
        private const string DummyNewUsers110 = "110";
        private const string DummyNewUser100 = "100";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _privateType = new PrivateType(typeof(RPEditor));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void ProcessAnyNotifications_EmptyXml_ReturnsNullQueueNotSent()
        {
            // Arrange
            var actualXml = string.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => Guid.NewGuid()
                    }
                }
            };

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => setting;

            ShimConfigFunctions.GetCleanUsernameSPWeb = webParam => DummyUsername;
            ShimResourcePlanNotifications.ConstructorString = (sender, baseInfo) => new ShimResourcePlanNotifications(sender)
            {
                GetRPENotifcations = () => string.Empty
            };

            ShimAPIEmail.QueueItemMessageXmlStringSPWeb = (xml, web) =>
            {
                actualXml = xml;
                return string.Empty;
            };

            // Act
            var actualResult = (string)_privateType.InvokeStatic(ProcessAnyNotificationsMethodName, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualXml.ShouldBeEmpty(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessAnyNotifications_Context41_ReturnsNullQueueXml()
        {
            // Arrange
            var actualXml = string.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => Guid.NewGuid()
                    }
                }
            };

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => setting;

            ShimConfigFunctions.GetCleanUsernameSPWeb = webParam => DummyUsername;
            ShimResourcePlanNotifications.ConstructorString = (sender, baseInfo) => new ShimResourcePlanNotifications(sender)
            {
                GetRPENotifcations = () => RpeNotificationsXml41()
            };

            ShimAPIEmail.QueueItemMessageXmlStringSPWeb = (xml, web) =>
            {
                actualXml = xml;
                return string.Empty;
            };

            var expectedXml = new List<string>()
            {
                $"<QueueItem TemplateID=\"12\" HideFromUser=\"True\" DoNotEmail=\"False\" UnMarkRead=\"False\" ForceNewEntry=\"True\" NewUsers=\"{DummyNewUser100},{DummyNewUsers110}\" ExternalColumn=\"EXTID\">",
                $"<Param Name=\"Title\">{ExpectedTitleRm}</Param>",
                $"<Param Name=\"EditorUser_Name\">{DummyResourceName}</Param>",
                "<Param Name=\"CommitmentBody\">",
                $"<Param Name=\"SiteUrl\">{DummyUrl}</Param>",
                "<Param Name=\"EditorUrl\">/ppm/rpeditor.aspx?dataid=&amp;isresource=1&amp;IsDlg=0</Param>"
            };

            // Act
            var actualResult = _privateType.InvokeStatic(ProcessAnyNotificationsMethodName, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeNull(),
                () => expectedXml.ForEach(c => actualXml.ShouldContain(c)));
        }

        [TestMethod]
        public void ProcessAnyNotifications_Context43_ReturnsNullQueueXml()
        {
            // Arrange
            var actualXml = string.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => Guid.NewGuid()
                    }
                }
            };

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => setting;

            ShimConfigFunctions.GetCleanUsernameSPWeb = webParam => DummyUsername;
            ShimResourcePlanNotifications.ConstructorString = (sender, baseInfo) => new ShimResourcePlanNotifications(sender)
            {
                GetRPENotifcations = () => RpeNotificationsXml43()
            };

            ShimAPIEmail.QueueItemMessageXmlStringSPWeb = (xml, web) =>
            {
                actualXml = xml;
                return string.Empty;
            };

            var expectedXml = new List<string>()
            {
                $"<QueueItem TemplateID=\"13\" HideFromUser=\"True\" DoNotEmail=\"False\" UnMarkRead=\"False\" ForceNewEntry=\"True\" NewUsers=\"{DummyNewUsers110}\" ExternalColumn=\"EXTID\">",
                $"<Param Name=\"Title\">{ExpectedTitlePm}</Param>",
                $"<Param Name=\"EditorUser_Name\">{DummyResourceName}</Param>",
                "<Param Name=\"CommitmentBody\">",
                $"<Param Name=\"SiteUrl\">{DummyUrl}</Param>",
                "<Param Name=\"EditorUrl\">/ppm/rpeditor.aspx?dataid=&amp;isresource=0&amp;IsDlg=0</Param>"
            };

            // Act
            var actualResult = _privateType.InvokeStatic(ProcessAnyNotificationsMethodName, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeNull(),
                () => expectedXml.ForEach(c => actualXml.ShouldContain(c)));
        }

        [TestMethod]
        public void ProcessAnyNotifications_ResourcePlanNotificationsFail_ThrowRpException()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => Guid.NewGuid()
                    }
                }
            };

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => setting;

            ShimConfigFunctions.GetCleanUsernameSPWeb = webParam => DummyUsername;
            ShimResourcePlanNotifications.ConstructorString = (sender, baseInfo) => new ShimResourcePlanNotifications(sender)
            {
                GetRPENotifcations = () =>
                {
                    throw new Exception(DummyString);
                }
            };

            // Act
            Action action = () => _privateType.InvokeStatic(ProcessAnyNotificationsMethodName, string.Empty);

            // Assert
            action.ShouldThrow<RPException>().Message.ShouldBe($"ProcessAnyNotifications::{DummyString}");
        }

        private string RpeNotificationsXml41()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data ThisUser=\"100\">")
               .Append($"<RES WRES=\"100\" ResExtID=\"extId100\" Name=\"{DummyResourceName}\" ResNT=\"ResourceAccountName100\"/>")
               .Append("<RES WRES=\"110\" ResExtID=\"extId110\" Name=\"ResourceName110\" ResNT=\"ResourceAccountName110\"/>")
               .Append("<DEPT Dept=\"200\" WRES=\"100\" />")
               .Append("<DEPT Dept=\"200\" WRES=\"110\" />")
               .Append("<DEPT Dept=\"260\" WRES=\"110\" />")
               .Append("<DEPTDEL WRES=\"100\" DELG=\"100\" />")
               .Append("<DEPTDEL WRES=\"100\" DELG=\"110\" />")
               .Append("<PMDEL  WRES=\"100\" DELG=\"100\" />")
               .Append("<PMDEL  WRES=\"100\" DELG=\"110\" />")
               .Append("<PROJECT PID=\"300\" PM=\"100\" EXTUID=\"ProjectExtId300\" Name=\"ProjectName300\" />")
               .Append("<PROJECT PID=\"350\" PM=\"110\" EXTUID=\"ProjectExtId350\" Name=\"ProjectName350\" />")
               .Append($"<CMT UID=\"400\" WRES=\"100\" WRESPend=\"500\" EnteredBy=\"600\" GUID=\"{Guid1}\" Dept=\"200\"/>")
               .Append($"<CMT UID=\"400\" WRES=\"0\" WRESPend=\"110\" EnteredBy=\"600\" GUID=\"{Guid2}\" Dept=\"200\"/>")
               .Append($"<RPEN UID=\"900\" PID=\"300\" GUID=\"{Guid1}\" WRESID=\"920\" TITLE=\"Node\" HTML=\"\" ECONTEXT=\"41\" WResName=\"\" WResNT=\"\" WResEmail=\"\" WResExtUID=\"\"/>")
               .Append($"<RPEN UID=\"700\" PID=\"350\" GUID=\"{Guid1}\" WRESID=\"720\" TITLE=\"Node\" HTML=\"\" ECONTEXT=\"41\" WResName=\"\" WResNT=\"\" WResEmail=\"\" WResExtUID=\"\"/>")
               .Append($"<RPEN UID=\"800\" PID=\"350\" GUID=\"{Guid2}\" WRESID=\"820\" TITLE=\"Node\" HTML=\"\" ECONTEXT=\"41\" WResName=\"\" WResNT=\"\" WResEmail=\"\" WResExtUID=\"\"/>")
               .Append("</Data>");

            return stringBuilder.ToString();
        }

        private string RpeNotificationsXml43()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data ThisUser=\"100\">")
               .Append($"<RES WRES=\"100\" ResExtID=\"extId100\" Name=\"{DummyResourceName}\" ResNT=\"ResourceAccountName100\"/>")
               .Append("<RES WRES=\"110\" ResExtID=\"extId110\" Name=\"ResourceName110\" ResNT=\"ResourceAccountName110\"/>")
               .Append("<DEPT Dept=\"200\" WRES=\"100\" />")
               .Append("<DEPT Dept=\"200\" WRES=\"110\" />")
               .Append("<DEPT Dept=\"260\" WRES=\"110\" />")
               .Append("<DEPTDEL WRES=\"100\" DELG=\"100\" />")
               .Append("<DEPTDEL WRES=\"100\" DELG=\"110\" />")
               .Append("<PMDEL  WRES=\"100\" DELG=\"100\" />")
               .Append("<PMDEL  WRES=\"100\" DELG=\"110\" />")
               .Append("<PROJECT PID=\"300\" PM=\"100\" EXTUID=\"ProjectExtId\" Name=\"ProjectName\" />")
               .Append("<PROJECT PID=\"350\" PM=\"110\" EXTUID=\"ProjectExtId\" Name=\"ProjectName\" />")
               .Append($"<CMT UID=\"400\" WRES=\"100\" WRESPend=\"500\" EnteredBy=\"600\" GUID=\"{Guid1}\" Dept=\"200\"/>")
               .Append($"<CMT UID=\"400\" WRES=\"0\" WRESPend=\"110\" EnteredBy=\"600\" GUID=\"{Guid2}\" Dept=\"200\"/>")
               .Append($"<RPEN UID=\"700\" PID=\"350\" GUID=\"{Guid1}\" WRESID=\"720\" TITLE=\"Node\" HTML=\"\" ECONTEXT=\"43\" WResName=\"\" WResNT=\"\" WResEmail=\"\" WResExtUID=\"\"/>")
               .Append($"<RPEN UID=\"800\" PID=\"350\" GUID=\"{Guid2}\" WRESID=\"820\" TITLE=\"Node\" HTML=\"\" ECONTEXT=\"43\" WResName=\"\" WResNT=\"\" WResEmail=\"\" WResExtUID=\"\"/>")
               .Append("</Data>");

            return stringBuilder.ToString();
        }
    }
}
