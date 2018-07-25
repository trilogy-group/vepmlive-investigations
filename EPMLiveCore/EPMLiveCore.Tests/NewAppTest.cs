using System;
using System.Collections.Generic;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Tests.Testables;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class NewAppTest
    {
        private const string _webAtUrlSuffix = "@url";
        private IDisposable _shimsContext;
        private NewAppTestable _testable;
        private IDictionary<string, string> _requestParameters;
        private string _serverRelativeUrl;
        private string _redirectUrl;
        private bool _dbUpdateExecuted;
        private string _workspaceUrl;
        private bool _listExists;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _testable = new NewAppTestable();
            _requestParameters = new Dictionary<string, string>
            {
                { "hdnSelectedWorkspace", string.Empty },
                { "List", Guid.NewGuid().ToString() },
            };

            _serverRelativeUrl = "http://test.test";
            _redirectUrl = null;
            _dbUpdateExecuted = false;
            _listExists = true;

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
            var spListShim = new ShimSPList
            {
                TitleGet = () => "test",
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
            };

            var webShim = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser(),
                ServerRelativeUrlGet = () => _serverRelativeUrl,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = (key) => _listExists ? spListShim : null, 
                    ItemGetGuid = (key) => spListShim
                },
                WebsGet = () => new ShimSPWebCollection
                {
                    ItemGetGuid = (key) => new ShimSPWeb()
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
                },
                ItemGetGuid = (key) => webShim
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => webShim
            };
        }

        [TestMethod]
        public void BtnOKClick_WorkspaceExistingListExists_ProjectCreated()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "Existing";
            _requestParameters["hdnSelectedWorkspace"] = Guid.NewGuid().ToString();

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsTrue(_dbUpdateExecuted);
            Assert.AreEqual(_serverRelativeUrl + "?ID=" + 0, _redirectUrl);
        }

        [TestMethod]
        public void BtnOKClick_WorkspaceExistingListNotExists_ErrorRendered()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "Existing";
            _requestParameters["hdnSelectedWorkspace"] = Guid.NewGuid().ToString();
            _listExists = false;

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsFalse(_dbUpdateExecuted);
            Assert.IsNull(_redirectUrl);
            Assert.AreEqual("Error: The list " + "test" + " does not exist", _testable.label1.Text);
            Assert.IsTrue(_testable.Panel2.Visible);
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
        public void BtnOKClick_WorkspaceNotExists_RedirectValid()
        {
            // Arrange
            _requestParameters["hdnWorkspaceType"] = "test";

            // Act
            _testable.BtnOK_Click();

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(_redirectUrl));
            Assert.IsTrue(_redirectUrl.Contains("&rnd="));
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
