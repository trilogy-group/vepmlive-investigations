using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Net.Fakes;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SolLibTemplatesManagerTests
    {
        private SolLibTemplatesManager testObj;
        private PrivateObject privateObj;
        private IDisposable shimsContext;

        private Guid guid;
        private ShimSPSite spSite;
        private ShimSPWeb spWeb;
        private ShimSPList spList;
        private ShimSPListItem spListItem;

        private const string DummyString = "DummyString";
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";

        private const string ReturnAllLocalTemplatesInJSONMethodName = "ReturnAllLocalTemplatesInJSON";
        private const string ReturnAllSolutionGalleryTemplatesInJSONMethodName = "ReturnAllSolutionGalleryTemplatesInJSON";
        private const string BuildWebInfoXmlMethodName = "BuildWebInfoXml";
        private const string EnsureWebInitFeatureMethodName = "EnsureWebInitFeature";
        private const string EnsureFieldsInRequestItemMethodName = "EnsureFieldsInRequestItem";
        private const string CreateProjectInExistingWorkspaceMethodName = "CreateProjectInExistingWorkspace";
        private const string RenameProjectFileByProjectItemMethodName = "RenameProjectFileByProjectItem";
        private const string InstallOnlineSolutionByFeatureXmlMethodName = "InstallOnlineSolutionByFeatureXml";
        private const string EnsureSiteCollectionFeaturesActivatedMethodName = "EnsureSiteCollectionFeaturesActivated";
        private const string GetSiteGroupMethodName = "GetSiteGroup";
        private const string RemoveSolutionFromGalleryMethodName = "RemoveSolutionFromGallery";
        private const string CreateNewWorkspaceMethodName = "CreateNewWorkspace";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObj = new SolLibTemplatesManager();
            privateObj = new PrivateObject(testObj);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimHttpUtility.UrlDecodeString = input => input;
            ShimJSONUtil.ConvertXmlToJsonStringString = (xml, _) => xml;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => spSite,
                WebGet = () => spWeb
            };
            ShimSPContext.GetContextSPWeb = _ => new ShimSPContext();
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPFieldMultiChoiceValue.ConstructorString = (_, _1) => new ShimSPFieldMultiChoiceValue();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPFieldUrlValue.ConstructorString = (_, _1) => new ShimSPFieldUrlValue();
        }


        private void SetupVariables()
        {
            guid = new Guid(GuidString);

            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                OpenWebString = _ => spWeb,
                OpenWebGuid = _ => spWeb,
                UrlGet = () => DummyString,
                MakeFullUrlString = url => url,
                RootWebGet = () => spWeb
            };

            spListItem = new ShimSPListItem()
            {
                IDGet = () => 1,
                ParentListGet = () => spList
            };

            spList = new ShimSPList()
            {
                IDGet = () => guid,
                GetItemByIdInt32 = _ => spListItem,
                GetItemsSPQuery = _ => new ShimSPListItemCollection()
                {
                    GetEnumerator = () => new List<SPListItem>()
                    {
                        spListItem
                    }.GetEnumerator()
                },
                ItemsGet = () => new ShimSPListItemCollection()
                {
                    ItemGetInt32 = _ => spListItem,
                    GetEnumerator = () => new List<SPListItem>()
                    {
                        spListItem
                    }.GetEnumerator()
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => new ShimSPField()
                    {
                        IdGet = () => guid
                    }
                }
            };

            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                CurrentUserGet = () => new ShimSPUser()
                {
                    IDGet = () => 111,
                    LoginNameGet = () => DummyString
                },
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = _ => spList,
                    ItemGetGuid = _ => spList,
                    ItemGetString = _ => spList,
                    GetListGuidBoolean = (_, __) => spList
                },
                SiteGet = () => spSite,
                UrlGet = () => DummyString,
                ExistsGet = () => true,
                WebsGet = () => new ShimSPWebCollection()
                {
                    ItemGetString = _ => spWeb
                }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void ReturnAllLocalTemplatesInJSON_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expectedString = "CustomValue";
            const string httpString = "http://";

            var url = string.Format("/sampleSite/{0}/sampleAction.com", DummyString);
            var data = string.Format(@"
                <Data>
                    <Param key=""Type"">CustomType</Param>
                    <Param key=""TemplateType"">{0}</Param>
                    <Param key=""CreateFromLiveTemp"">False</Param>
                </Data>",
                expectedString);

            spWeb.GetAvailableWebTemplatesUInt32 = _ => new ShimSPWebTemplateCollection();
            spWeb.ServerRelativeUrlGet = () => "/";
            spListItem.IDGet = () => 1;
            spListItem.AttachmentsGet = () => new ShimSPAttachmentCollection();

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPWebTemplate>()
            {
                new ShimSPWebTemplate()
                {
                    NameGet = () => url
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemGetGuid = (_, _1) => expectedString;
            ShimSPFieldUrlValue.AllInstances.UrlGet = _ => url;
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, _1) => expectedString;
            ShimSPAttachmentCollection.AllInstances.CountGet = _ => 1;
            ShimSPAttachmentCollection.AllInstances.UrlPrefixGet = _ => httpString;
            ShimSPAttachmentCollection.AllInstances.ItemGetInt32 = (_, _1) => expectedString;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                ReturnAllLocalTemplatesInJSONMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Templates").Element("Template").Attribute("Id").Value.ShouldBe("1"),
                () => actual.Element("Templates").Element("Template").Attribute("Active").Value.ShouldBe(expectedString),
                () => actual.Element("Templates").Element("Template").Element("Title").Value.ShouldBe(url),
                () => actual.Element("Templates").Element("Template").Element("TemplateCategories").Element("TemplateCategory").Value.ShouldBe(expectedString),
                () => actual.Element("Templates").Element("Template").Element("AttachmentUrl").Value.ShouldBe($"{httpString}{expectedString}"));
        }

        [TestMethod]
        public void ReturnAllSolutionGalleryTemplatesInJSON_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expectedString = "CustomValue";

            var url = string.Format("/sampleSite/{0}/sampleAction.com", DummyString);
            var data = string.Format(@"
                <Data>
                    <Param key=""Type"">CustomType</Param>
                    <Param key=""TemplateType"">{0}</Param>
                    <Param key=""CreateFromLiveTemp"">False</Param>
                </Data>",
                expectedString);

            spWeb.GetAvailableWebTemplatesUInt32 = _ => new ShimSPWebTemplateCollection();
            spWeb.GetCatalogSPListTemplateType = _ => new ShimSPDocumentLibrary();

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPWebTemplate>()
            {
                new ShimSPWebTemplate()
                {
                    IDGet = () => 1,
                    TitleGet = () => expectedString,
                    DescriptionGet = () => expectedString,
                    DisplayCategoryGet = () => expectedString,
                    NameGet = () => expectedString,
                    ImageUrlGet = () => expectedString
                }
            }.GetEnumerator();
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, _1) => expectedString;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                ReturnAllSolutionGalleryTemplatesInJSONMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { data }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Templates").Element("Template").Attribute("Id").Value.ShouldBe("1"),
                () => actual.Element("Templates").Element("Template").Attribute("Active").Value.ShouldBe("True"),
                () => actual.Element("Templates").Element("Template").Attribute("IncludeContent").Value.ShouldBe("False"),
                () => actual.Element("Templates").Element("Template").Element("Title").Value.ShouldBe(expectedString),
                () => actual.Element("Templates").Element("Template").Element("URL").Value.ShouldBe("nan"));
        }

        [TestMethod]
        public void BuildWebInfoXml_WhenCalled_ReturnsString()
        {
            // Arrange
            const int number = 111;
            const string expectedString = "CustomValue";

            var webId = $"{GuidString},1";
            var data = string.Format(@"
                <Data>
                    <Param key=""RListName"">{0}</Param>
                    <Param key=""ListName"">{0}</Param>
                    <Param key=""IsNew"">True</Param>
                    <Param key=""IsTemplate"">True</Param>
                    <Param key=""NewTempItemID"">{1}</Param>
                </Data>",
                expectedString, number);
            var dataManager = new XMLDataManager(data);

            spList.FormsGet = () => new ShimSPFormCollection()
            {
                ItemGetPAGETYPE = _ => new ShimSPForm()
                {
                    ServerRelativeUrlGet = () => expectedString
                }
            };
            spWeb.ServerRelativeUrlGet = () => "/";
            spListItem.IDGet = () => number;

            // Act
            var actual = XDocument.Parse((string)privateObj.Invoke(
                BuildWebInfoXmlMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { webId, dataManager, spSite.Instance, spWeb.Instance, spSite.Instance, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("WebInfo").Element("ID").Value.ShouldBe(guid.ToString("B")),
                () => actual.Element("WebInfo").Element("ServerRelativeUrl").Value.ShouldBe("/"),
                () => actual.Element("WebInfo").Element("ProjectEditFormUrl").Value.ShouldBe($"{expectedString}?ID={number}"),
                () => actual.Element("WebInfo").Element("TemplateEditFormUrl").Value.ShouldBe($"{expectedString}?ID={number}"));
        }

        [TestMethod]
        public void EnsureFieldsInRequestItem_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            const string workspaceUrl = "WorkspaceUrl";
            const string childItem = "ChildItem";
            const string url = "http://sampleurl.com";
            const string expectedDescription = "sampleurl.com";

            var validationCount = 0;
            var expectedString = $"{guid.ToString()}.{guid.ToString()}.1";
            var actualString = string.Empty;
            var actualFieldUrlValue = default(SPFieldUrlValue);
            var visitCount = new Dictionary<string, int>()
            {
                [workspaceUrl] = 0,
                [childItem] = 0
            };

            spList.FieldsGet = () => new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = key =>
                {
                    var result = default(SPField);
                    switch (key)
                    {
                        case workspaceUrl:
                            visitCount[key] = visitCount[key] + 1;
                            if (visitCount[key] > 1)
                            {
                                result = new ShimSPFieldUrl().Instance;
                            }
                            break;
                        case childItem:
                            visitCount[key] = visitCount[key] + 1;
                            if (visitCount[key] > 1)
                            {
                                result = new ShimSPFieldText().Instance;
                            }
                            break;
                        default:
                            result = new ShimSPField()
                            {
                                IdGet = () => guid
                            }.Instance;
                            break;
                    }
                    return result;
                },
                AddStringSPFieldTypeBoolean = (key, _, __) =>
                {
                    if (key == workspaceUrl || key == childItem)
                    {
                        validationCount = validationCount + 1;
                    }
                    return key;
                }
            };
            spWeb.ServerRelativeUrlGet = () => url;
            spListItem.SystemUpdate = () =>
            {
                validationCount = validationCount + 1;
            };
            spListItem.ItemSetGuidObject = (_, input) =>
            {
                if (input.GetType().Equals(typeof(SPFieldUrlValue)))
                {
                    actualFieldUrlValue = (SPFieldUrlValue)input;
                    validationCount = validationCount + 1;
                }
                else if (input.GetType().Equals(typeof(string)))
                {
                    actualString = (string)input;
                    validationCount = validationCount + 1;
                }
            };

            ShimSPField.AllInstances.Update = _ =>
            {
                validationCount = validationCount + 1;
            };

            // Act
            var actual = (bool)privateObj.Invoke(
                EnsureFieldsInRequestItemMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { string.Empty, spList.Instance, spWeb.Instance, spListItem.Instance, spListItem.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => actualString.ShouldBe(expectedString),
                () => actualFieldUrlValue.Url.ShouldBe(url),
                () => actualFieldUrlValue.Description.ShouldBe(expectedDescription),
                () => validationCount.ShouldBe(7));
        }

        [TestMethod]
        public void CreateProjectInExistingWorkspace_DoNotDeleteTrue_Deletes()
        {
            // Arrange
            const string doNotDelRequest = "False";
            const string originItemId = "1";
            const string url = "/";

            var validationCount = 0;
            var data = string.Format(@"
                <Data>
                    <Param key=""IsNew"">True</Param>
                    <Param key=""ParentWebUrl"">ParentWebUrl</Param>
                    <Param key=""SourceWebUrl"">SourceWebUrl</Param>
                    <Param key=""RListName"">RListName</Param>
                    <Param key=""ListName"">ListName</Param>
                    <Param key=""SiteTitle"">SiteTitle</Param>
                    <Param key=""DoNotDelRequest"">False</Param>
                    <Param key=""CopyFrom"">1</Param>
                    <Param key=""ListGuid"">{0}</Param>
                </Data>",
                GuidString);
            var dataManager = new XMLDataManager(data);

            spListItem.Delete = () =>
            {
                validationCount = validationCount + 1;
            };
            spList.Update = () =>
            {
                validationCount = validationCount + 1;
            };

            spListItem.ItemGetString = _ => DummyString;
            spListItem.ItemSetStringObject = (key, value) =>
            {
                if (key.Equals(DummyString) && value.GetType().Equals(typeof(string)))
                {
                    if (DummyString.Equals((string)value))
                    {
                        validationCount = validationCount + 1;
                    }
                }
            };
            spListItem.Update = () =>
            {
                validationCount = validationCount + 1;
            };
            spWeb.ServerRelativeUrlGet = () => url;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Attachments;
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPListItemCollection.AllInstances.Add = _ =>
            {
                validationCount = validationCount + 1;
                return spListItem;
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    InternalNameGet = () => DummyString,
                    ReorderableGet = () => true,
                    TypeGet = () => SPFieldType.Attachments
                }
            }.GetEnumerator();

            // Act
            privateObj.Invoke(
                CreateProjectInExistingWorkspaceMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { dataManager, spSite.Instance, spWeb.Instance, spSite.Instance, spWeb.Instance });

            // Assert
            validationCount.ShouldBe(6);
        }

        [TestMethod]
        public void RenameProjectFileByProjectItem_WhenCalled_Renames()
        {
            // Arrange
            const string oldName = "oldName";
            const string newName = "newName";

            var validationCount = 0;

            spWeb.ListsGet = () => new ShimSPListCollection()
            {
                TryGetListString = _ => new ShimSPDocumentLibrary(),
                ItemGetGuid = _ => spList
            };
            spListItem.ItemGetString = _ => oldName;
            spListItem.FileGet = () => new ShimSPFile()
            {
                CheckOut = () =>
                {
                    validationCount = validationCount + 1;
                },
                CheckInString = _ =>
                {
                    validationCount = validationCount + 1;
                }
            };
            spListItem.SystemUpdate = () =>
            {
                validationCount = validationCount + 1;
            };

            ShimPath.GetFileNameWithoutExtensionString = input => input;
            ShimPath.ChangeExtensionStringString = (path, extension) =>
            {
                if (path.Equals(newName) && extension.Equals("mpp"))
                {
                    validationCount = validationCount + 1;
                }
                return path;
            };
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection()
            {
                GetEnumerator = () => new List<SPListItem>()
                {
                    spListItem
                }.GetEnumerator()
            };


            // Act
            privateObj.Invoke(
                RenameProjectFileByProjectItemMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance, oldName, newName });

            // Assert
            validationCount.ShouldBe(4);
        }

        [TestMethod]
        public void InstallOnlineSolutionByFeatureXml()
        {
            // Arrange
            const string rootFilePath = "";

            var xmlString = @"
                <xmlcfg>
                    <File Name=""fileName"" Type=""Solution""></File>
                </xmlcfg>";
            var tempSolNames = new List<string>();
            var validationCount = 0;

            spSite.ServerRelativeUrlGet = () => "/";
            spSite.GetCatalogSPListTemplateType = _ => new ShimSPDocumentLibrary();
            spSite.FeatureDefinitionsGet = () => new ShimSPFeatureDefinitionCollection();
            spSite.SolutionsGet = () => new ShimSPUserSolutionCollection()
            {
                AddInt32 = _ =>
                {
                    validationCount = validationCount + 1;
                    return null;
                }
            };
            spWeb.Update = () =>
            {
                validationCount = validationCount + 1;
            };

            ShimSPPersistedObjectCollection<SPFeatureDefinition>.AllInstances.GetEnumerator = _ => new List<SPFeatureDefinition>().GetEnumerator();
            ShimWebClient.AllInstances.DownloadDataString = (_, __) => null;
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder()
            {
                FilesGet = () => new ShimSPFileCollection()
                {
                    AddStringByteArray = (name, array) =>
                    {
                        validationCount = validationCount + 1;
                        return new ShimSPFile()
                        {
                            ItemGet = () => spListItem
                        };
                    }
                }
            };

            // Act
            privateObj.Invoke(
                InstallOnlineSolutionByFeatureXmlMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { tempSolNames, xmlString, rootFilePath, string.Empty, spSite.Instance, spWeb.Instance, spSite.Instance, spWeb.Instance });

            // Assert
            validationCount.ShouldBe(4);
        }

        [TestMethod]
        public void EnsureSiteCollectionFeaturesActivated_WhenCalled_ReturnsList()
        {
            // Arrange
            var validationCount = 0;
            var solution = new ShimSPUserSolution()
            {
                SolutionIdGet = () => guid
            };

            spSite.FeatureDefinitionsGet = () => new ShimSPFeatureDefinitionCollection();
            spSite.FeaturesGet = () => new ShimSPFeatureCollection()
            {
                ItemGetGuid = _ => null,
                AddGuidBooleanSPFeatureDefinitionScope = (_, _1, _2) =>
                {
                    validationCount = validationCount + 1;
                    return null;
                }
            };
            ShimSPPersistedObjectCollection<SPFeatureDefinition>.AllInstances.GetEnumerator = _ => new List<SPFeatureDefinition>()
            {
                new ShimSPFeatureDefinition()
                {
                    IdGet = () => guid,
                    SolutionIdGet = () => guid,
                    ScopeGet = () =>  SPFeatureScope.Site,
                    ActivateOnDefaultGet = () => true
                }
            }.GetEnumerator();

            // Act
            privateObj.Invoke(
                EnsureSiteCollectionFeaturesActivatedMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { solution.Instance, spSite.Instance });

            // Assert
            validationCount.ShouldBe(1);
        }

        [TestMethod]
        public void GetSiteGroup_WhenCalled_ReturnsSPGroup()
        {
            // Arrange
            const string name = "sampleName";

            spWeb.SiteGroupsGet = () => new ShimSPGroupCollection();
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPGroup>()
            {
                new ShimSPGroup()
                {
                    NameGet = () => $"Not{name}"
                },
                new ShimSPGroup()
                {
                    NameGet = () => name
                }
            }.GetEnumerator();

            // Act
            var actual = (SPGroup)privateObj.Invoke(
                GetSiteGroupMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spWeb.Instance, name });

            // Assert
            actual.Name.ShouldBe(name);
        }

        [TestMethod]
        public void RemoveSolutionFromGallery_WhenCalled_RemovesItem()
        {
            // Arrange
            var validationCount = 0;
            var tempSolutionNames = new List<string>()
            {
                DummyString
            };

            spSite.GetCatalogSPListTemplateType = _ => new ShimSPDocumentLibrary();
            spSite.SolutionsGet = () => new ShimSPUserSolutionCollection()
            {
                RemoveSPUserSolution = _ =>
                {
                    validationCount = validationCount + 1;
                }
            };
            spListItem.FileGet = () => new ShimSPFile()
            {
                NameGet = () => DummyString
            };
            spListItem.Delete = () =>
            {
                validationCount = validationCount + 1;
            };

            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection()
            {
                GetEnumerator = () => new List<SPListItem>()
                {
                    spListItem
                }.GetEnumerator()
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPUserSolution>()
            {
                new ShimSPUserSolution()
                {
                    NameGet = () => DummyString
                }.Instance
            }.GetEnumerator();

            // Act
            privateObj.Invoke(
                RemoveSolutionFromGalleryMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { tempSolutionNames, spSite.Instance, spWeb.Instance, spSite.Instance, spWeb.Instance });

            // Assert
            validationCount.ShouldBe(2);
        }
    }
}
