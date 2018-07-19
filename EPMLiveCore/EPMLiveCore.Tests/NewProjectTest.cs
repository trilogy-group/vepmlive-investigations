using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
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
    public class NewProjectTest
    {
        private const string _webAtUrlSuffix = "@url";

        private IDisposable _shimsContext;
        private NewProjectTestable _testable;
        private ProjectInfoResult _projectInfo;
        private IDictionary<string, string> _requestParameters;
        private string _serverRelativeUrl;
        private string _redirectUrl;
        private bool _dbUpdateExecuted;
        private string _workspaceUrl;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _testable = new NewProjectTestable();
            _projectInfo = new ProjectInfoResult();
            _requestParameters = new Dictionary<string, string>
            {
                { "hdnSelectedWorkspace", string.Empty }
            };

            _serverRelativeUrl = "http://test.test";
            _redirectUrl = null;
            _dbUpdateExecuted = false;

            ShimSPProjectUtility.AllInstances.RequestProjectInfo = (instance) =>
            {
                return _projectInfo;
            };
            
            ShimPage.AllInstances.RequestGet = (instance) => new ShimHttpRequest
            {
                ItemGetString = (name) => _requestParameters[name]
            };

            ShimPage.AllInstances.ResponseGet = (instance) => new ShimHttpResponse
            {
                RedirectString = (url) => _redirectUrl = url
            };

            ShimCoreFunctions.createSiteStringStringStringStringBooleanBooleanSPWeb =
                (title, url, group, loginName, isUnique, isTopLink, web) =>
                {
                    return "0"; // "0" means the entity is created successfully
                };

            ShimSPWebInternals();
        }

        private void ShimSPWebInternals()
        {
            var webShim = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser(),
                ServerRelativeUrlGet = () => _serverRelativeUrl,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = (key) => new ShimSPList
                    {
                        ItemsGet = () => new ShimSPListItemCollection
                        {
                            Add = () => new ShimSPListItem
                            {
                                ItemSetStringObject = (liName, value) =>
                                {
                                    if (liName == "URL")
                                    {
                                        _workspaceUrl = value.ToString();
                                    }
                                },
                                Update = () => _dbUpdateExecuted = true
                            }
                        },
                        FormsGet = () => new ShimSPFormCollection
                        {
                            ItemGetPAGETYPE = (pageType) => new ShimSPForm
                            {
                                ServerRelativeUrlGet = () => _serverRelativeUrl
                            }
                        }
                    }
                }
            };

            webShim.WebsGet = () => new ShimSPWebCollection
            {
                ItemGetString = name =>
                {
                    var result = new ShimSPWeb(webShim);
                    result.ServerRelativeUrlGet = () => _serverRelativeUrl + _webAtUrlSuffix;

                    result.ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = (key) => new ShimSPList
                        {
                            ItemsGet = () => new ShimSPListItemCollection
                            {
                                Add = () => new ShimSPListItem
                                {
                                    ItemSetStringObject = (liName, value) =>
                                    {
                                        if (liName == "URL")
                                        {
                                            _workspaceUrl = value.ToString();
                                        }
                                    },
                                    Update = () => _dbUpdateExecuted = true
                                }
                            },
                            FormsGet = () => new ShimSPFormCollection
                            {
                                ItemGetPAGETYPE = (pageType) => new ShimSPForm
                                {
                                    ServerRelativeUrlGet = () => _serverRelativeUrl + _webAtUrlSuffix
                                }
                            },
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                GetFieldByInternalNameString = (internalName) => new ShimSPField()
                            },
                            GetItemsSPQuery = (query) => new ShimSPListItemCollection()
                                .Bind(new ShimSPListItem[] { })
                        }
                    };

                    return result;
                }
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => webShim
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
            var flagsUsed = SPRedirectFlags.Default;
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
            _testable.DdlGroup.Items.Clear();
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

        [TestMethod]
        public void BtnOKClick_WorkspaceExistingUrlEmpty_ProjectCreatedAtWebAtUrl()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "Existing";
            _requestParameters["hdnSelectedWorkspace"] = "!test";

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsTrue(_dbUpdateExecuted);
            Assert.AreEqual(_serverRelativeUrl + _webAtUrlSuffix + "?ID=" + 0, _redirectUrl);
        }

        [TestMethod]
        public void BtnOKClick_WorkspaceExistingUrlNotEmpty_ProjectCreatedAtWebAtUrl()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "Existing";
            _requestParameters["hdnSelectedWorkspace"] = string.Empty;

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsTrue(_dbUpdateExecuted);
            Assert.AreEqual(_serverRelativeUrl + "?ID=" + 0, _redirectUrl);
        }

        [TestMethod]
        public void BtnOKClick_WorkspaceNotExists_PannelsHidden()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "test";
            _requestParameters["hdnSelectedWorkspace"] = string.Empty;

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsFalse(_testable.pnlTitle.Visible);
            Assert.IsFalse(_testable.pnlURL.Visible);
            Assert.IsFalse(_testable.pnlURLBad.Visible);
        }

        [TestMethod]
        public void BtnOKClick_WorkspaceNotExists_WebsiteCreated()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "test";
            bool websiteIsCreated = false;
            ShimCoreFunctions.createSiteStringStringStringStringBooleanBooleanSPWeb =
                (title, url, group, loginName, isUnique, isTopLink, web) =>
                {
                    websiteIsCreated = true;
                    return "0"; // "0" means the entity is created successfully
                };

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsTrue(websiteIsCreated);
        }

        [TestMethod]
        public void BtnOKClick_TitleAlphanumericWorkspaceNotExists_WorkspaceUpdated()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "test";
            _testable.txtURL.Text = "test-url";
            _testable.txtTitle.Text = "123";

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsTrue(_dbUpdateExecuted);
            Assert.AreEqual(_testable.txtURL.Text + ", " + _testable.txtTitle.Text, _workspaceUrl);
        }
    }
}
