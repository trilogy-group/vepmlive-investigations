using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using EPMLiveCore.API;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Analytics
{
    [TestClass, ExcludeFromCodeCoverage]
    public class FRFQueryParamFactoryTests
    {
        private IDisposable _shimContext;
        private PrivateType _privateType;

        private const string GetUpdateFrequentQueryParamsMethodName = "GetUpdateFrequentQueryParams";

        private const string SiteIdParamName = "@siteid";
        private const string WebIdParamName = "@webid";
        private const string ListIdParamName = "@listid";
        private const string ItemIdParamName = "@itemid";
        private const string UserIdParamName = "@userid";
        private const string IconParamName = "@icon";
        private const string TitleParamName = "@title";
        private const string FStringParamName = "@fstring";

        private const string DummyIconName = "DummyIconName";
        private const string SiteId = "7f316e11-c842-4440-9918-39a8f1c12da9";
        private static readonly Guid SiteIdGuid = new Guid("7f316e11-c842-4440-9918-39a8f1c12da9");
        private const string WebId = "1a8f7946-cca1-4a24-8785-ce8e32d012be";
        private static readonly Guid WebIdGuid = new Guid("1a8f7946-cca1-4a24-8785-ce8e32d012be");
        private const string ListId = "4b2f88a7-ce61-45a1-af55-8439df5b265a";
        private static readonly Guid ListIdGuid = new Guid("4b2f88a7-ce61-45a1-af55-8439df5b265a");
        private const string ItemId = "10";
        private const int ItemIdInt = 10;
        private const string UserId = "20";
        private const int UserIdInt = 20;
        private const string DummyTitle = "DummyTitle";
        private const string DummyString = "DummyString";
        private const string IconFile5 = "icon-file-5";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _privateType = new PrivateType(typeof(FRFQueryParamFactory));

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();

            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                OpenWebGuid = guidWeb => new ShimSPWeb()
                {
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetGuid = guidItem => new ShimSPList()
                    }
                }
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, spList) =>
            {
                var setting = new ShimGridGanttSettings(sender);
                setting.Instance.ListIcon = DummyIconName;
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void GetParam_TypeFavoriteCreateIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Favorite, AnalyticsAction.Create);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteCreateIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.Favorite, AnalyticsAction.Create);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(DBNull.Value),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(IconFile5),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteReadIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Favorite, AnalyticsAction.Read);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(7),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[IconParamName].ShouldBe(DummyIconName));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteReadIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.Favorite, AnalyticsAction.Read);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(4),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteUpdate_ReturnsDictionaryEmpty()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.Favorite, AnalyticsAction.Update);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            actualResult.ShouldBeEmpty();
        }

        [TestMethod]
        public void GetParam_TypeFavoriteDeleteIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Favorite, AnalyticsAction.Delete);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteDeleteIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.Favorite, AnalyticsAction.Delete);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(7),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(IconFile5),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFrequentCreate_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Frequent, AnalyticsAction.Create);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(6),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypFrequentReadIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Frequent, AnalyticsAction.Read);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFrequentReadIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.Frequent, AnalyticsAction.Read);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(7),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFrequentUpdateIsItemTrue_ReturnsDictionaryEmpty()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Frequent, AnalyticsAction.Update);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            actualResult.ShouldBeEmpty();
        }

        [TestMethod]
        public void GetParam_TypeFrequentDeleteIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.Frequent, AnalyticsAction.Delete);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFrequentDeleteIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.Frequent, AnalyticsAction.Delete);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(DBNull.Value),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(DummyIconName),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteWorkspaceCreateIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.FavoriteWorkspace, AnalyticsAction.Create);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(string.Empty),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteWorkspaceCreateIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.FavoriteWorkspace, AnalyticsAction.Create);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(7),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(string.Empty),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteWorkspaceDeleteIsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.FavoriteWorkspace, AnalyticsAction.Delete);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(7),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetParam_TypeFavoriteWorkspaceDeleteIsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.FavoriteWorkspace, AnalyticsAction.Delete);

            // Act
            var actualResult = FRFQueryParamFactory.GetParam(analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(5),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetUpdateFrequentQueryParams_IsItemTrue_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(true), AnalyticsType.FavoriteWorkspace, AnalyticsAction.Delete);

            //Act
            var actualResult = (Dictionary<string, object>)_privateType.InvokeStatic(GetUpdateFrequentQueryParamsMethodName, analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(ItemIdInt),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(string.Empty),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        [TestMethod]
        public void GetUpdateFrequentQueryParams_IsItemFalse_ReturnsDictionary()
        {
            // Arrange
            var analyticsData = new AnalyticsData(CreateXml(false), AnalyticsType.FavoriteWorkspace, AnalyticsAction.Delete);

            //Act
            var actualResult = (Dictionary<string, object>)_privateType.InvokeStatic(GetUpdateFrequentQueryParamsMethodName, analyticsData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(8),
                () => actualResult[SiteIdParamName].ShouldBe(SiteIdGuid),
                () => actualResult[WebIdParamName].ShouldBe(WebIdGuid),
                () => actualResult[ListIdParamName].ShouldBe(ListIdGuid),
                () => actualResult[ItemIdParamName].ShouldBe(DBNull.Value),
                () => actualResult[UserIdParamName].ShouldBe(UserIdInt),
                () => actualResult[FStringParamName].ShouldBe(DummyString),
                () => actualResult[IconParamName].ShouldBe(string.Empty),
                () => actualResult[TitleParamName].ShouldBe(DummyTitle));
        }

        private static string CreateXml(bool isTem)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
               .Append($"<Param key=\"IsItem\">{isTem.ToString()}</Param>")
               .Append($"<Param key=\"SiteId\">{SiteId}</Param>")
               .Append($"<Param key=\"WebId\">{WebId}</Param>")
               .Append($"<Param key=\"ListId\">{ListId}</Param>")
               .Append($"<Param key=\"ItemId\">{ItemId}</Param>")
               .Append($"<Param key=\"UserId\">{UserId}</Param>")
               .Append($"<Param key=\"Title\">{DummyTitle}</Param>")
               .Append($"<Param key=\"FString\">{DummyString}</Param>")
               .Append("</Data>");

            return stringBuilder.ToString();
        }
    }
}