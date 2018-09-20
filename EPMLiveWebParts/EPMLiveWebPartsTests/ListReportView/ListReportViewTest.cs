using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Text;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveWebParts.Tests.ListReportView
{
    using EPMLiveWebParts;
    using Fakes;

    [TestClass]
    public class ListReportViewTest
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyUrl = "https://duymy.org/";
        private const string RenderWebPartMethodName = "RenderWebPart";
        private const string OnPreRenderMethodName = "OnPreRender";
        private const string OnInitMethodName = "OnInit";
        private const string BuildGridPostParametersMethodName = "BuildGridPostParameters";
        private const string BuildQueryParamMethodName = "BuildQueryParam";
        private const string GetParentFolderMethodName = "GetParentFolder";
        private const string GetNonFolderItemsMethodName = "GetNonFolderItems";
        private const string TraverseListFolderMethodName = "TraverseListFolder";
        private const string AddDocumentsMethodName = "AddDocuments";
        private ListReportView listReportView;
        private IDisposable shimContext;
        private PrivateObject privateObject;
        private HtmlTextWriter textWriter;
        private StringBuilder stringBuilder;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            listReportView = new ListReportView();
            privateObject = new PrivateObject(listReportView);
            textWriter = new ShimHtmlTextWriter();
            stringBuilder = new StringBuilder();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
            listReportView?.Dispose();
            textWriter?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.ListIdGet = _ => DummyGuid;
            ShimSPContext.AllInstances.ItemGet = _ => new ShimSPListItem();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPPersistedObject.AllInstances.IdGet = _ => DummyGuid;
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyUrl;
            ShimHtmlTextWriter.AllInstances.WriteString = (_, content) => stringBuilder.Append(content);
        }

        [TestMethod]
        public void RenderWebPart_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb
            {
                UrlGet = () => DummyUrl,
                ServerRelativeUrlGet = () => DummyUrl
            };
            ShimControl.AllInstances.UniqueIDGet = _ => DummyGuid.ToString();
            ShimListReportView.AllInstances.BuildGridPostParametersBoolean = (_, isSrs) => "Dummy";
            listReportView.ExpandView = true;

            // Act
            privateObject.Invoke(RenderWebPartMethodName, textWriter);
            var outputContent = stringBuilder.ToString();

            // Assert
            Assert.IsNotNull(outputContent);
            Assert.IsTrue(outputContent.Contains(DummyUrl));
            Assert.IsTrue(outputContent.Contains(DummyGuid.ToString()));
        }

        [TestMethod]
        public void OnPreRender_Should_ExecuteCorrectly()
        {
            // Arrange
            var scriptsRegistered = 0;
            ShimScriptLink.RegisterPageStringBoolean = (page, script, localized) =>
            {
                scriptsRegistered++;
            };
            ShimWebPart.AllInstances.OnPreRenderEventArgs = (_, args) => { };

            // Act
            privateObject.Invoke(OnPreRenderMethodName, EventArgs.Empty);

            // Assert
            Assert.AreNotEqual(0, scriptsRegistered);
        }

        [TestMethod]
        public void OnInit_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimWebPart.AllInstances.OnInitEventArgs = (_, args) => { };
            listReportView.Width = string.Empty;

            // Act
            privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

            // Assert
            Assert.AreNotEqual(0, listReportView.Controls.Count);
            Assert.AreEqual("300px", listReportView.Width);
        }

        [TestMethod]
        public void BuildGridPostParameters_UseDefaults_ShouldReturnContent()
        {
            // Arrange
            ShimCoreFunctions.getWebAppSettingGuidString = (guid, setting) => bool.TrueString;
            listReportView.UseDefaults = true;

            // Act
            var result = privateObject.Invoke(BuildGridPostParametersMethodName, true) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void BuildGridPostParameters_UseDefaultsFalse_ShouldReturnContent()
        {
            // Arrange
            ShimCoreFunctions.getWebAppSettingGuidString = (guid, setting) => bool.TrueString;
            listReportView.UseDefaults = false;

            // Act
            var result = privateObject.Invoke(BuildGridPostParametersMethodName, true) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void BuildQueryParam_Should_ReturnExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Dummy|Dummy";
            listReportView.ViewLists = "Dummy\nDummy";

            // Act
            var result = privateObject.Invoke(BuildQueryParamMethodName) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetToolParts_Should_ReturnExpectedObject()
        {
            // Arrange, Act
            var result = listReportView.GetToolParts();

            // Assert
            Assert.AreEqual(4, result.Length);
            Assert.IsNotNull(result[1]);
            Assert.AreEqual(PartChromeState.Minimized, result[1].ChromeState);
            Assert.IsNotNull(result[2]);
            Assert.AreEqual(PartChromeState.Minimized, result[2].ChromeState);
        }

        [TestMethod]
        public void GetListNamesInHashtable_OnSuccess_ReturnsHashtable()
        {
            // Arrange
            var listName = "Dummy::Name";

            // Act
            var result = listReportView.GetListNamesInHashtable(listName);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ContainsKey("Dummy"));
        }

        [TestMethod]
        public void GetListNamesInHashtable_OnException_ReturnsNull()
        {
            // Arrange
            var listName = "Dummy|Dummy::Name";

            // Act
            var result = listReportView.GetListNamesInHashtable(listName);

            // Assert
            Assert.IsNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(listReportView.DisplayListNames));
            Assert.IsTrue(string.IsNullOrEmpty(listReportView.SelectedListNames));
        }

        [TestMethod]
        public void GetParentFolder_ParentFound_ReturnsParentObject()
        {
            // Arrange
            var itemToFind = new ShimSPListItem
            {
                IDGet = () => 1,
                ParentListGet = () => new ShimSPList
                {
                    GetItemsSPQuery = query => new ShimSPListItemCollection
                    {
                        GetEnumerator = () => new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                IDGet = () => 1
                            }
                        }.GetEnumerator()
                    }
                }
            }.Instance;
            var folder = new ShimSPFolder().Instance;

            // Act
            var result = privateObject.Invoke(GetParentFolderMethodName, itemToFind, folder) as SPFolder;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(folder, result);
        }

        [TestMethod]
        public void GetParentFolder_ItemNotFound_ReturnsNull()
        {
            // Arrange
            var itemToFind = new ShimSPListItem
            {
                IDGet = () => 1,
                ParentListGet = () => new ShimSPList
                {
                    GetItemsSPQuery = query => new ShimSPListItemCollection
                    {
                        GetEnumerator = () => new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                IDGet = () => 2,
                                FolderGet = () => null
                            }
                        }.GetEnumerator()
                    }
                }
            }.Instance;
            var folder = new ShimSPFolder().Instance;

            // Act
            var result = privateObject.Invoke(GetParentFolderMethodName, itemToFind, folder) as SPFolder;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetNonFolderItems_Should_ReturnsArrayList()
        {
            // Arrange
            var list = new ShimSPList
            {
                RootFolderGet = () => new ShimSPFolder
                {
                    FilesGet = () => new ShimSPFileCollection()
                }
            }.Instance;

            // Act
            var result = privateObject.Invoke(GetNonFolderItemsMethodName, list) as ArrayList;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TraverseListFolder_Should_ExecuteCorrectly()
        {
            // Arrange
            var documentsAdded = 0;
            var folder = new ShimSPFolder().Instance;
            var document = new ShimXmlDocument().Instance;
            var mainNode = new ShimXmlNode(new XmlDocument()).Instance;
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemsSPQuery = query => new ShimSPListItemCollection
                    {
                        GetEnumerator = () => new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                FileGet = () => new ShimSPFile(),
                                FolderGet = () => new ShimSPFolder()
                            }
                        }.GetEnumerator()
                    }
                }
            };
            ShimListReportView.AllInstances.AddDocumentsSPFolderXmlDocumentXmlNode =
                (_, spFolder, xmlDocument, parentNode) => 
                {
                    documentsAdded++;
                };

            // Act
            privateObject.Invoke(TraverseListFolderMethodName, folder, document, mainNode);

            // Assert
            Assert.AreNotEqual(0, documentsAdded);
        }

        [TestMethod]
        public void AddDocuments_should_ExecuteCorrectly()
        {
            // Arrange
            var nodeList = new List<XmlNode>();
            var documentfolder = new ShimSPFolder
            {
                SubFoldersGet = () => 
                {
                    var list = new List<SPFolder>
                    {
                        new ShimSPFolder
                        {
                            FilesGet = () => new ShimSPFileCollection().Bind(new List<SPFile>()),
                            SubFoldersGet = () => new ShimSPFolderCollection().Bind(new List<SPFolder>())
                        }
                    };
                    return new ShimSPFolderCollection().Bind(list);
                },
                FilesGet = () =>
                {
                    var list = new List<SPFile>
                    {
                        new ShimSPFile
                        {
                            ItemGet = () => new ShimSPListItem
                            {
                                DisplayNameGet = () => DummyUrl
                            },
                            ServerRelativeUrlGet = () => DummyUrl,
                            IconUrlGet = () => DummyUrl
                        }
                    };
                    return new ShimSPFileCollection().Bind(list);
                }
            }.Instance;
            var document = new XmlDocument();
            ShimXmlNode.AllInstances.AppendChildXmlNode = (_, node) => null;
            var parentNode = new ShimXmlNode(new XmlDocument())
            {
                AppendChildXmlNode = node =>
                {
                    nodeList.Add(node);
                    return null;
                }
            }.Instance;

            // Act
            privateObject.Invoke(AddDocumentsMethodName, new object[] { documentfolder, document, parentNode });

            // Assert
            Assert.AreNotEqual(0, nodeList);
        }

        [TestMethod]
        public void PropSRSUrl_GetSet_Test()
        {
            // Arrange, Act
            listReportView.PropSRSUrl = DummyUrl;
            var result = listReportView.PropSRSUrl;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(DummyUrl, result);
        }

        [TestMethod]
        public void IsIntegratedMode_GetSet_Test()
        {
            // Arrange
            const bool ExpectedValue = true;

            // Act
            listReportView.IsIntegratedMode = ExpectedValue;
            var result = listReportView.IsIntegratedMode;

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void IsTopList_GetSet_Test()
        {
            // Arrange
            const bool ExpectedValue = false;

            // Act
            listReportView.IsTopList = ExpectedValue;
            var result = listReportView.IsTopList;

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void PropReportsPath_GetSet_Test()
        {
            // Arrange, Act
            listReportView.PropReportsPath = DummyUrl;
            var result = listReportView.PropReportsPath;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(DummyUrl, result);
        }

        [TestMethod]
        public void ExpandView_GetSet_Test()
        {
            // Arrange
            const bool ExpectedValue = false;

            // Act
            listReportView.ExpandView = ExpectedValue;
            var result = listReportView.ExpandView;

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void UseDefaults_PrivateFieldNull_ReturnsExpectedValue()
        {
            // Arrange
            listReportView.PropSRSUrl = DummyUrl;

            // Act
            var result = listReportView.UseDefaults;

            // Assert
            Assert.IsFalse(result);
        }
    }
}
