using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.SPUtilities.Fakes;
using EPMLiveCore.Tests.Testables;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EPMLiveCore.SPUtilities.SPProjectUtility;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class RequestWorkspaceTest
    {
        private IDisposable _shimsContext;
        private RequestWorkspaceTestable _testable;
        private ProjectInfoResult _projectInfo;
        private WorkspaceInfoResult _workspaceInfo;
        
        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _testable = new RequestWorkspaceTestable();
            _projectInfo = new ProjectInfoResult();
            _workspaceInfo = new WorkspaceInfoResult
            {
                ListName = "test-list",
                WorkspaceName = "test-workspace"
            };

            ShimSPProjectUtility.AllInstances.RequestProjectInfo = (instance) =>
            {
                return _projectInfo;
            };
            ShimSPProjectUtility.AllInstances.RequestWorkspaceInfoGuidInt32 = (instance, listId, listItemId) =>
            {
                return _workspaceInfo;
            };

            ShimPage.AllInstances.RequestGet = (instance) => new ShimHttpRequest {
                ItemGetString = (name) => 
                    name == "List" ? Guid.NewGuid().ToString() :
                    name == "id" ? 1.ToString() :
                    null as string
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    CurrentUserGet = () => new ShimSPUser()
                }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void OnLoad_PostBack_ProjectInfoNotReinitialized()
        {
            // Arrange
            ShimPage.AllInstances.IsPostBackGet = (instance) => true;
            var projectInfoRequested = false;
            ShimSPProjectUtility.AllInstances.RequestProjectInfo = (instance) =>
            {
                projectInfoRequested = true;
                return _projectInfo;
            };

            // Act
            _testable.Page_Load();

            // Assert
            Assert.IsFalse(projectInfoRequested);
        }

        [TestMethod]
        public void OnLoad_ProjectInfoRequestedForbidden_Redirect()
        {
            // Arrange
            _projectInfo.StatusCode = System.Net.HttpStatusCode.Forbidden;
            string urlUsed = null;
            SPRedirectFlags flagsUsed = SPRedirectFlags.Default;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                urlUsed = url;
                flagsUsed = flags;
                return true;
            };

            // Act
            _testable.Page_Load();

            // Assert
            Assert.AreEqual("accessdenied.aspx", urlUsed);
            Assert.AreEqual(SPRedirectFlags.RelativeToLayoutsPage, flagsUsed);
        }

        [TestMethod]
        public void OnLoad_ProjectInfoFetched_UrlSet()
        {
            // Arrange
            _projectInfo.ServerRelativeUrl = "test-1";

            // Act
            _testable.Page_Load();

            // Assert
            Assert.AreEqual(_projectInfo.ServerRelativeUrl, _testable.Url);
        }

        [TestMethod]
        public void OnLoad_ProjectInfoFetched_BaseUrlSet()
        {
            // Arrange
            _projectInfo.BaseUrl = "test-2";

            // Act
            _testable.Page_Load();

            // Assert
            Assert.AreEqual(_projectInfo.BaseUrl, _testable.BaseUrl);
        }

        [TestMethod]
        public void OnLoad_ProjectInfoFetched_PopulatedTemplatesSet()
        {
            // Arrange
            _projectInfo.PopulatedTemplates = new SortedList
            {
                { "test-key-1", "test-value-1" },
                { "test-key-2", "test-value-2" }
            };

            // Act
            _testable.Page_Load();

            // Assert
            Assert.AreEqual(_projectInfo.PopulatedTemplates.Count, _testable.DdlGroup.Items.Count);

            // (CC-76491, 2018-07-19) The values are mixed up in original implementation. Text is stored as Key, name as Value 
            Assert.AreEqual("test-value-1", _testable.DdlGroup.Items[0].Value);
            Assert.AreEqual("test-key-1", _testable.DdlGroup.Items[0].Text);
            Assert.AreEqual("test-value-2", _testable.DdlGroup.Items[1].Value);
            Assert.AreEqual("test-key-2", _testable.DdlGroup.Items[1].Text);
        }

        [TestMethod]
        public void OnLoad_ProjectNavigationEnabled_TopRadioButtonsSetCorrectly()
        {
            // Arrange
            _projectInfo.IsNavigationEnabled = true;

            // Act
            _testable.Page_Load();

            // Assert
            Assert.IsTrue(_testable.rdoTopLinkYes.Checked);
            Assert.IsFalse(_testable.rdoTopLinkNo.Checked);
            Assert.IsFalse(_testable.rdoTopLinkYes.Enabled);
            Assert.IsFalse(_testable.rdoTopLinkNo.Enabled);
        }

        [TestMethod]
        public void OnLoad_ProjectNavigationDisabled_TopRadioButtonsSetCorrectly()
        {
            // Arrange
            _projectInfo.IsNavigationEnabled = false;

            // Act
            _testable.Page_Load();

            // Assert
            Assert.IsFalse(_testable.rdoTopLinkYes.Checked);
            Assert.IsTrue(_testable.rdoTopLinkNo.Checked);
            Assert.IsFalse(_testable.rdoTopLinkYes.Enabled);
            Assert.IsFalse(_testable.rdoTopLinkNo.Enabled);
        }

        [TestMethod]
        public void OnLoad_IsUniqueTrue_TopRadioButtonsSetCorrectly()
        {
            // Arrange
            _projectInfo.IsUnique = true;

            // Act
            _testable.Page_Load();

            // Assert
            Assert.IsTrue(_testable.rdoUnique.Checked);
            Assert.IsFalse(_testable.rdoInherit.Checked);
            Assert.IsFalse(_testable.rdoUnique.Enabled);
            Assert.IsFalse(_testable.rdoInherit.Enabled);
        }

        [TestMethod]
        public void OnLoad_IsUniqueFalse_TopRadioButtonsSetCorrectly()
        {
            // Arrange
            _projectInfo.IsUnique = false;

            // Act
            _testable.Page_Load();

            // Assert
            Assert.IsFalse(_testable.rdoUnique.Checked);
            Assert.IsTrue(_testable.rdoInherit.Checked);
            Assert.IsFalse(_testable.rdoUnique.Enabled);
            Assert.IsFalse(_testable.rdoInherit.Enabled);
        }
    }
}
