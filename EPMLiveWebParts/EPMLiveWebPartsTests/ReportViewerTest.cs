using System;
using System.Linq;
using System.Web.UI.WebControls;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.SSRS2005.Fakes;
using EPMLiveWebParts.SSRS2006.Fakes;
using EPMLiveWebParts.Tests.Helpers;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ReportParameter2005 = EPMLiveWebParts.SSRS2005.ReportParameter;
using ReportParameter2006 = EPMLiveWebParts.SSRS2006.ReportParameter;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    public class ReportViewerTest : ReportWebPartsTestBase<ReportViewer>
    {
        [TestMethod]
        public void PopulateTree_IfListItemIsFolder_CallsPopulateTreeRecursively()
        {
            // Arrange
            var folder01 = new SpListItemDefinition()
            {
                Name = "Folder01 Name",
                Title = "Folder01 Title",
                Url = string.Empty,
                UniqueId = Guid.NewGuid()
            };

            var file01 = new SpListItemDefinition()
            {
                Name = "File01.rdl",
                Title = "File01 Title",
                Url = "File01Url",
                UniqueId = Guid.NewGuid()
            };

            var file02 = new SpListItemDefinition()
            {
                Name = "File02.rdl",
                Title = string.Empty,
                Url = "File02Url",
                UniqueId = Guid.NewGuid()
            };

            ShimReportWebPartBase.AllInstances.Get2006ParametersString = (instance, url) => url;

            var folders = CreateSpListItems(SPFileSystemObjectType.Folder, folder01);
            var files = CreateSpListItems(SPFileSystemObjectType.File, file01, file02);
            var allItems = folders.Concat(files);
            var shimListItems = CreateShimSpListItemCollection(folders);
            var shimSpDoc = CreateShimSpDoc(allItems);
            var treeNode = new TreeNode();

            // Act
            _testEntityPrivate.Invoke(MethodPopulateTree, shimListItems.Instance, shimSpDoc.Instance, treeNode);

            // Assert
            treeNode.ShouldSatisfyAllConditions(
                () => treeNode.ChildNodes.Count.ShouldBe(1),
                () =>
                {
                    var folderNode = treeNode.ChildNodes[0];
                    folderNode.Text.ShouldBe(string.Format("<b>{0}</b>", folder01.Title));
                    folderNode.SelectAction = TreeNodeSelectAction.None;
                    folderNode.ImageUrl.ShouldBe(TreeNodeFolderImage);
                },
                () => treeNode.ChildNodes[0].ChildNodes.Count.ShouldBe(2),
                () =>
                {
                    var expectedNavigateUrl = string.Format("Javascript:frameview(\"{0}/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl={0}/{1}{2}&rv:HeaderArea=none\");",
                                                            ServerRelativeUrl,
                                                            file01.Url,
                                                            string.Format("{0}/{1}",_webField.Url, file01.Url));
                    var file01Node = treeNode.ChildNodes[0].ChildNodes[0];
                    file01Node.Text.ShouldBe(file01.Title);
                    file01Node.ImageUrl.ShouldBe(TreeNodeFileImage);
                    file01Node.NavigateUrl.ShouldBe(expectedNavigateUrl);
                },
                () =>
                {
                    var file02Node = treeNode.ChildNodes[0].ChildNodes[1];
                    file02Node.Text.ShouldBe(file02.Name.Replace(RdlExtension, string.Empty));
                    file02Node.ImageUrl.ShouldBe(TreeNodeFileImage);
                });
        }

        [TestMethod]
        public void Rs_WhenCalled_ReturnsParametersString()
        {
            // Arrange
            var reportParameters = new ReportParameter2006[]
            {
                new ReportParameter2006() { Name = ReportParamNameUrl, Prompt = string.Empty },
                new ReportParameter2006() { Name = ReportParamNameSiteId, Prompt = string.Empty },
                new ReportParameter2006() { Name = ReportParamNameWebId, Prompt = string.Empty },
                new ReportParameter2006() { Name = ReportParamNameUserId, Prompt = string.Empty },
                new ReportParameter2006() { Name = ReportParamNameUsername, Prompt = string.Empty }
            };

            var shimReportingService = new ShimReportingService2006();
            shimReportingService.GetReportParametersStringStringParameterValueArrayDataSourceCredentialsArray =
                (url, a, b, c) => reportParameters;

            _testEntityPrivate.SetField(FieldSrs2006, shimReportingService.Instance);

            var expectedParametersString = string.Concat(
                string.Format(ReportParam2006Template, ReportParamNameUrl, _curWebField.ServerRelativeUrl),
                string.Format(ReportParam2006Template, ReportParamNameSiteId, _spContextCurrent.Site.ID),
                string.Format(ReportParam2006Template, ReportParamNameWebId, _spContextCurrent.Web.ID),
                string.Format(ReportParam2006Template, ReportParamNameUserId, UserId),
                string.Format(ReportParam2006Template, ReportParamNameUsername, Username));

            // Act
            var result = _testEntityPrivate.Invoke(MethodGet2006Parameters, string.Empty) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedParametersString));
        }

        [TestMethod]
        public void Rsnoim_WhenCalled_ReturnsParametersString()
        {
            // Arrange
            var reportParameters = new ReportParameter2005[]
            {
                new ReportParameter2005() { Name = ReportParamNameUrl, Prompt = string.Empty },
                new ReportParameter2005() { Name = ReportParamNameSiteId, Prompt = string.Empty },
                new ReportParameter2005() { Name = ReportParamNameWebId, Prompt = string.Empty },
                new ReportParameter2005() { Name = ReportParamNameUserId, Prompt = string.Empty },
                new ReportParameter2005() { Name = ReportParamNameUsername, Prompt = string.Empty }
            };

            var shimReportingService = new ShimReportingService2005();
            shimReportingService.GetReportParametersStringStringBooleanParameterValueArrayDataSourceCredentialsArray =
                (url, a, b, c, d) => reportParameters;

            _testEntityPrivate.SetField(FieldSrs2005, shimReportingService.Instance);

            var expectedParametersString = string.Concat(
                string.Format(ReportParam2005Template, ReportParamNameUrl, _curWebField.ServerRelativeUrl),
                string.Format(ReportParam2005Template, ReportParamNameSiteId, _spContextCurrent.Site.ID),
                string.Format(ReportParam2005Template, ReportParamNameWebId, _spContextCurrent.Web.ID),
                string.Format(ReportParam2005Template, ReportParamNameUserId, UserId),
                string.Format(ReportParam2005Template, ReportParamNameUsername, Username));

            // Act
            var result = _testEntityPrivate.Invoke(MethodGet2005Parameters, string.Empty) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedParametersString));
        }

        [TestMethod]
        public void ReportsFolderName_IfBackingFieldIsEmptyAndIsTopListIsTrue_SetsFieldAndReturnsValue()
        {
            // Arrange
            _testEntityBasePrivate.SetField(FieldReportsFolderName, string.Empty);
            _testEntityPrivate.SetField(FieldIsTopList, true);
            var expectedResult = string.Concat(ReportsRootFolderName, "/epmlivetl");

            // Act
            var result = _testEntity.ReportsFolderName;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult),
                () => _testEntityBasePrivate.GetField(FieldReportsFolderName).ShouldNotBeNull(),
                () => _testEntityBasePrivate.GetField(FieldReportsFolderName).ShouldBe(expectedResult));
        }

        [TestMethod]
        public void ReportsFolderName_IfBackingFieldIsEmptyAndIsTopListIsFalse_SetsFieldAndReturnsValue()
        {
            // Arrange
            _testEntityBasePrivate.SetField(FieldReportsFolderName, string.Empty);
            _testEntityPrivate.SetField(FieldIsTopList, false);
            var expectedResult = string.Concat(ReportsRootFolderName, "/epmlive");

            // Act
            var result = _testEntity.ReportsFolderName;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult),
                () => _testEntityBasePrivate.GetField(FieldReportsFolderName).ShouldNotBeNull(),
                () => _testEntityBasePrivate.GetField(FieldReportsFolderName).ShouldBe(expectedResult));
        }

        [TestMethod]
        public void PropReportsPath_IfBackingFieldIsNull_ReturnsEmptyString()
        {
            // Arrange
            _testEntityBasePrivate.SetField(FieldReportsPath, null);

            // Act
            var result = _testEntity.PropReportsPath;

            // Assert
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void PropReportsPath_SetAndGetValue()
        {
            // Arrange
            const string expectedValue = "Value";

            // Act
            _testEntity.PropReportsPath = expectedValue;
            var result = _testEntity.PropReportsPath;

            // Assert
            result.ShouldBe(expectedValue);
        }

        [TestMethod]
        public void PropSRSUrl_IfBackingFieldIsNull_ReturnsEmptyString()
        {
            // Arrange
            _testEntityBasePrivate.SetField(FieldSRSUrl, null);

            // Act
            var result = _testEntity.PropSRSUrl;

            // Assert
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void PropSRSUrl_SetAndGetValue()
        {
            // Arrange
            const string expectedValue = "Value";

            // Act
            _testEntity.PropSRSUrl = expectedValue;
            var result = _testEntity.PropSRSUrl;

            // Assert
            result.ShouldBe(expectedValue);
        }

        [TestMethod]
        public void UseDefaults_IfBackingFieldIsNullAndSrsUrlAndReportsPathPropsAreEmpty_ReturnsTrue()
        {
            // Arrange
            _testEntityBasePrivate.SetField(FieldUseDefaults, null);
            _testEntity.PropReportsPath = string.Empty;
            _testEntity.PropSRSUrl = string.Empty;

            // Act
            var result = _testEntity.UseDefaults;

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void UseDefaults_IfBackingFieldIsNullAndSrsUrlIsNotEmpty_ReturnsFalse()
        {
            // Arrange
            _testEntityBasePrivate.SetField(FieldUseDefaults, null);
            _testEntity.PropReportsPath = string.Empty;
            _testEntity.PropSRSUrl = "anything";

            // Act
            var result = _testEntity.UseDefaults;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void UseDefaults_SetAndGetValue()
        {
            // Arrange & Act
            _testEntity.UseDefaults = true;
            var result = _testEntity.UseDefaults;

            // Assert
            result.ShouldBeTrue();
        }
    }
}
