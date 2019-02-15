using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq.Fakes;
using System.Xml.Fakes;
using System.Web.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;
using EPMLiveCore.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using System.Diagnostics;
using PortfolioEngineCore.Fakes;

namespace EPMLiveCore.Tests.ISAPI
{
    public partial class WorkEngineAPITests
    {
        private const string EventReceiverManager = "EventReceiverManager";
        private const string AddRemoveFeatureEvents = "AddRemoveFeatureEvents";
        private const string ClearCache = "ClearCache";
        private const string GetListsAndViewsGridData = "GetListsAndViewsGridData";
        private const string GetListAndViewsGridLayout = "GetListAndViewsGridLayout";
        private const string GetNavigationLinks = "GetNavigationLinks";
        private const string ReorderLinks = "ReorderLinks";
        private const string RemoveNavigationLink = "RemoveNavigationLink";
        private const string GetContextualMenuItems = "GetContextualMenuItems";
        private const string LoadFavoriteStatus = "LoadFavoriteStatus";
        private const string AddFavorites = "AddFavorites";
        private const string RemoveFavorites = "RemoveFavorites";
        private const string LoadFavoriteWsStatus = "LoadFavoriteWsStatus";
        private const string AddFavoritesWs = "AddFavoritesWs";
        private const string RemoveFavoritesWs = "RemoveFavoritesWs";
        private const string CreateFrequentApp = "CreateFrequentApp";
        private const string CreateRecentItem = "CreateRecentItem";
        private const string SetPropertiesBagSettings = "SetPropertiesBagSettings";
        private const string GenerateQuickLaunchFromApp = "GenerateQuickLaunchFromApp";
        private const string GetDiagnosticsInfo = "GetDiagnosticsInfo";
        private const string GetPropertiesBagParams = "GetPropertiesBagParams";
        private const string GetAssociatedItems = "GetAssociatedItems";
        private const string GetFancyFormAssociatedItems = "GetFancyFormAssociatedItems";
        private const string GetFancyFormAssociatedItemAttachments = "GetFancyFormAssociatedItemAttachments";
        private const string GetMyWorkSummary = "GetMyWorkSummary";
        private const string InstallPlatformIntegration = "InstallPlatformIntegration";
        private const string RemovePlatformIntegration = "RemovePlatformIntegration";
        private const string GetWorkspaceCenterGridData = "GetWorkspaceCenterGridData";
        private const string WorkSpaceCenterLayout = "WorkSpaceCenterLayout";
        private const string IsSecurityJobAlreadyRunning = "IsSecurityJobAlreadyRunning";

        [TestMethod]
        public void EventReceiverManager_StringDataAndSPWebIsNotNull_ReturnException()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXDocument.ParseString = _ => new ShimXDocument();
            ShimXDocument.AllInstances.RootGet = _ => new ShimXElement();
            ShimXContainer.AllInstances.Elements = _ => new List<XElement>() { new ShimXElement() };
            ShimXElement.AllInstances.AttributeXName = (_, _1) => new ShimXAttribute();
            ShimXElement.AllInstances.ValueGet = _ => new Guid().ToString();
            ShimTimer.CancelTimerJobSPWebGuid = (_, _1) => { };
            ShimXContainer.AllInstances.ElementsXName = (_, _1) => new List<XElement>() { new ShimXElement() };
            ShimXContainer.AllInstances.ElementXName = (_, _1) => new ShimXElement();
            var count = 0;
            ShimXAttribute.AllInstances.ValueGet = _ =>
            {
                count++;
                if (count == 5)
                {
                    return DummyInt.ToString();
                }
                else if (count == 6)
                {
                    return "list";
                }
                else
                {
                    return new Guid().ToString();
                }
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.GetListByIdGuidBoolean = (_, _1, _2) => new ShimSPList();
            ShimSPWeb.AllInstances.Dispose = _ => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                EventReceiverManager,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"1\"><Error ID=\"900100\">Error: Object reference not set to an instance of an object.</Error></Result>");
        }

        [TestMethod]
        public void AddRemoveFeatureEvents_StringDataAndSPWebIsNotNull_ReturnException()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXDocument.ParseString = _ => new ShimXDocument();
            ShimXDocument.AllInstances.RootGet = _ => new ShimXElement();
            ShimXContainer.AllInstances.Elements = _ => new List<XElement>() { new ShimXElement() };
            ShimXElement.AllInstances.AttributeXName = (_, _1) => new ShimXAttribute();
            ShimXElement.AllInstances.ValueGet = _ => new Guid().ToString();
            ShimTimer.CancelTimerJobSPWebGuid = (_, _1) => { };
            ShimXContainer.AllInstances.ElementsXName = (_, _1) => new List<XElement>() { new ShimXElement() };
            ShimXContainer.AllInstances.ElementXName = (_, _1) => new ShimXElement();
            var count = 0;
            ShimXAttribute.AllInstances.ValueGet = _ =>
            {
                count++;
                if (count == 1)
                {
                    return "myworkreporting";
                }
                else if (count == 2)
                {
                    return "add";
                }
                else
                {
                    return DummyString;
                }
            };

            // Act
            var actualResult = _privateType.InvokeStatic(
                AddRemoveFeatureEvents,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"1\"><Error ID=\"900100\">Error: Object reference not set to an instance of an object.</Error></Result>");
        }

        [TestMethod]
        public void ClearCache_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCacheStore.CurrentGet = () => new ShimCacheStore();
            ShimCacheStore.AllInstances.ClearString = (_, _1) => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                ClearCache,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\"></Result>");
        }

        [TestMethod]
        public void GetListsAndViewsGridData_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimChartWizardDataHelper.GetListsAndViewsGridDataStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetListsAndViewsGridData,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetListAndViewsGridLayout_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimChartWizardDataHelper.GetListsAndViewsGridLayoutStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetListAndViewsGridLayout,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetNavigationLinks_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetNavigationLinks,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void ReorderLinks_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();

            // Act
            var actualResult = _privateType.InvokeStatic(
                ReorderLinks,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void RemoveNavigationLink_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimNavigationService.AllInstances.RemoveNavigationLinkString = (_, _1) => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                RemoveNavigationLink,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetContextualMenuItems_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimNavigationService.GetContextualMenuItems_ParseRequestStringGuidOutGuidOutGuidOutInt32OutInt32OutBooleanOut =
                (string data, out Guid siteId, out Guid webId,out Guid listId, out int itemId, out int userId, out bool debugMode) =>
                {
                    siteId = new Guid();
                    webId = new Guid();
                    listId = new Guid();
                    itemId = DummyInt;
                    userId = DummyInt;
                    debugMode = true;
                };

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetContextualMenuItems,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void LoadFavoriteStatus_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFavorites.IsFavString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                LoadFavoriteStatus,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void AddFavorites_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFavorites.AddFavString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                AddFavorites,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void RemoveFavorites_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFavorites.RemoveFavString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                RemoveFavorites,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void LoadFavoriteWsStatus_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFavoritesWorkspace.IsFavWorkspaceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                LoadFavoriteWsStatus,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void AddFavoritesWs_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFavoritesWorkspace.AddFavWorkspaceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                AddFavoritesWs,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void RemoveFavoritesWs_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFavoritesWorkspace.RemoveFavWorkspaceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                RemoveFavoritesWs,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CreateFrequentApp_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFrequentApps.CreateString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreateFrequentApp,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CreateRecentItem_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimRecentItems.CreateString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreateRecentItem,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void SetPropertiesBagSettings_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimWorkEngineAPI.GetPropertiesBagParamsStringStringOut = (string xml, out string webAppId) =>
            {
                webAppId = new Guid().ToString();
                return new Guid().ToString();
            };
            ShimCoreFunctions.setWebAppSettingGuidStringString = (_, _1, _2) => { };
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                SetPropertiesBagSettings,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">00000000-0000-0000-0000-000000000000</Result>");
        }

        [TestMethod]
        public void GenerateQuickLaunchFromApp_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimApplications.GenerateQuickLaunchFromAppSPWeb = _ => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                GenerateQuickLaunchFromApp,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\"></Result>");
        }

        [TestMethod]
        public void GetDiagnosticsInfo_StopwatchIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { new Stopwatch() };

            
            // Act
            var actualResult = _privateType.InvokeStatic(
                GetDiagnosticsInfo,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<DiagnosticsInfo>\r\n  <ProcessTime Unit=\"Milliseconds\">0</ProcessTime>\r\n</DiagnosticsInfo>");
        }

        private void GetPropertiesBagParamsSetup()
        {
            ShimXmlDocument.Constructor = _ => new ShimXmlDocument();
            ShimXmlDocument.AllInstances.LoadString = (_, _1) => { };
            XmlDocument document = new XmlDocument();
            document.LoadXml("<root><feed>Dummy String</feed></root>");
            ShimXmlNode.AllInstances.SelectNodesString = (_, _1) => new ShimXmlNodeList(document.ChildNodes);
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, _1) => new ShimXmlNode(new ShimXmlElement());
        }

        [TestMethod]
        public void GetPropertiesBagParams_XMLAndWebAppIdIsNotNullAndInnerTextIsFarm_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            GetPropertiesBagParamsSetup();
            ShimXmlNode.AllInstances.InnerTextGet = _ => "farm";

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetPropertiesBagParams,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetPropertiesBagParams_XMLAndWebAppIdIsNotNullAndInnerTextIsWebApp_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            GetPropertiesBagParamsSetup();
            ShimXmlNode.AllInstances.InnerTextGet = _ => "webapp";

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetPropertiesBagParams,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetAssociatedItems_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAssociatedListItems.GetAssociatedItemsString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetAssociatedItems,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetFancyFormAssociatedItems_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAssociatedListItems.GetFancyFormAssociatedItemsStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetFancyFormAssociatedItems,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetFancyFormAssociatedItemAttachments_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAssociatedListItems.GetFancyFormAssociatedItemAttachmentsStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetFancyFormAssociatedItemAttachments,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyWorkSummary_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWorkSummaryListItems.GetMyWorkSummaryString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkSummary,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void InstallPlatformIntegration_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimPlatformIntegration.InstallIntegrationStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                InstallPlatformIntegration,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void RemovePlatformIntegration_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimPlatformIntegration.RemoveIntegrationStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                RemovePlatformIntegration,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetWorkspaceCenterGridData_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimWorkspaceCenter.GetWorkspaceCenterGridDataStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetWorkspaceCenterGridData,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void WorkSpaceCenterLayout_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimWorkspaceCenter.GetWorkSpaceCenterLayoutString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                WorkSpaceCenterLayout,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void IsSecurityJobAlreadyRunning_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXDocument.ParseString = _ => new ShimXDocument();
            ShimXDocument.AllInstances.RootGet = _ => new ShimXElement();
            ShimXContainer.AllInstances.Elements = _ => new List<XElement>() { new ShimXElement() };
            ShimXElement.AllInstances.AttributeXName = (_, _1) => new ShimXAttribute();
            ShimXAttribute.AllInstances.ValueGet = _ => "ListID";
            ShimXElement.AllInstances.ValueGet = _ => new Guid().ToString();
            ShimTimer.IsSecurityJobAlreadyRunningSPWebGuidInt32 = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                IsSecurityJobAlreadyRunning,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }
    }
}
