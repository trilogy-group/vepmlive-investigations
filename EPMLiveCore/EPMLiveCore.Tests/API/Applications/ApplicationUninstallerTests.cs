using System;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.Applications;
using EPMLiveCore.Jobs.Applications.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Applications
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ApplicationUninstallerTests
    {
        private IDisposable _shimsObject;
        private ApplicationUninstaller _testObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private ShimSPList _list;
        private Uninstall _configJob;
        private PrivateObject _privateConfigJob;

        private bool _webFileDeleted;
        private bool _listItemUpdated;
        private bool _listItemDeleted;
        private bool _listItemRecycled;
        private bool _appRemovedFromCommunity;
        private bool _communityDeleted;
        private bool _quickLaunchDeleted;
        private bool _topNavigationBarDeleted;
        private bool _listBizDeleted;
        private bool _listDeleted;
        private bool _configSettingSet;
        private bool _folderDeleted;
        private bool _fileDeleted;
        private bool _solutionDeleted;
        private bool _listFileDeleted;
        private bool _fieldUpdated;
        private bool _fieldDeleted;
        private bool _gridGanttSettingsSaved;
        private bool _viewDeleted;
        private bool _eventHandlerDeleted;
        private bool _siteFeatureRemoved;
        private bool _webFeatureRemoved;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string WebId = "dbcc577c-701f-415e-b7af-391121517da6";
        private const string Feature1Guid = "bef62bdc-35f6-4e42-b8ac-735e3b5be516";
        private const string Feature2Guid = "d56a106c-f833-4437-be12-129ea71dfd45";
        private const string Feature3Guid = "005aed9a-7b82-46b5-b3fd-8e8d85240487";
        private const string Feature4Guid = "54f10d47-074e-4895-b205-43b477f613e6";
        private const string Folder1 = "Folder1";
        private const string Folder2 = "Folder2";
        private const string Folder3 = "Folder3";
        private const string Folder4 = "Folder4";
        private const string File1 = "File1";
        private const string UserIdField = "userid";

        private const string ApplicationUninstall = "Application Uninstall";
        private const string ApplicationInstalledSomewhereElse = "Application is installed somewhere else and will remove from this site only.";
        private const string PermissionsCheck = "Permissions Check";
        private const string YouDoNotHavePermissions = "You do not have Manage Web permissions";
        private const string RemovingAppFromCommunities = "Removing App from Communities";
        private const string DeletingCommunity = "Deleting Community";
        private const string UninstallingNavigation = "Uninstalling Navigation";
        private const string CheckingQuickLaunch = "Checking QuickLaunch";
        private const string CheckingTopNavigation = "Checking Top Navigation";
        private const string UninstallingLists = "Uninstalling Lists";
        private const string ListWillNotDelete = "List will not delete";
        private const string UninstallingFields = "Uninstalling Fields";
        private const string UninstallingLookups = "Uninstalling Lookups";
        private const string UninstallingViews = "Uninstalling Views";
        private const string UninstallingWorkflows = "Uninstalling Workflows";
        private const string UninstallingEventHandlers = "Uninstalling Event Handlers";
        private const string UninstallingItems = "Uninstalling Items";
        private const string RemoveDummyStringFromReportingDatabase = "Remove (DummyString) From Reporting Database";
        private const string UninstallingFeatures = "Uninstalling Features";
        private const string ApplicationInstalledOnAnotherSite = "Application currently installed on another site";
        private const string UninstallingProperties = "Uninstalling Properties";
        private const string UninstallingFiles = "Uninstalling Files";
        private const string FolderIsAList = "Folder is a list";
        private const string UninstallingSolutionsAndLists = "Uninstalling Solutions and Lists";
        private const string CheckingNavigation = "Checking Navigation";
        private const string CheckingLists = "Checking Lists";
        private const string CheckingFields = "Checking Fields";
        private const string CheckingLookups = "Checking Lookups";
        private const string CheckingViews = "Checking Views";
        private const string CheckingWorkflows = "Checking Workflows";
        private const string CheckingEventHandlers = "Checking Event Handlers";
        private const string CheckingItems = "Checking Items";
        private const string RemoveFromReportingDatabase = "Remove From Reporting Database";
        private const string CheckingFeatures = "Checking Features";
        private const string CheckingProperties = "Checking Properties";
        private const string CheckingFiles = "Checking Files";
        private const string CheckingSolutionsAndLists = "Checking Solutions and Lists";

        [TestInitialize]
        public void TestInitialize()
        {
            _webFileDeleted = false;
            _listItemUpdated = false;
            _listItemDeleted = false;
            _listItemRecycled = false;
            _appRemovedFromCommunity = false;
            _communityDeleted = false;
            _quickLaunchDeleted = false;
            _topNavigationBarDeleted = false;
            _listBizDeleted = false;
            _listDeleted = false;
            _configSettingSet = false;
            _folderDeleted = false;
            _fileDeleted = false;
            _solutionDeleted = false;
            _listFileDeleted = false;
            _fieldUpdated = false;
            _fieldDeleted = false;
            _gridGanttSettingsSaved = false;
            _viewDeleted = false;
            _eventHandlerDeleted = false;
            _siteFeatureRemoved = false;
            _webFeatureRemoved = false;

            _shimsObject = ShimsContext.Create();

            SetupShims();

            _testObj = new ApplicationUninstaller(DummyString, new ShimSqlConnection().Instance, _configJob);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            _configJob = new ShimUninstall().Instance;
            _privateConfigJob = new PrivateObject(_configJob);
            _privateConfigJob.SetFieldOrProperty(UserIdField, DummyInt);

            var spUser = new ShimSPUser
            {
                UserTokenGet = () => new ShimSPUserToken(),
                IsSiteAdminGet = () => true
            };

            var spListItem = new ShimSPListItem
            {
                ParentListGet = () => _list,
                IDGet = () => DummyInt,
                TitleGet = () => DummyString,
                ItemGetString = item =>
                {
                    switch (item)
                    {
                        case "LinkedCommunity":
                        case "QuickLaunch":
                        case "TopNav":
                            return DummyInt;
                        case "InstalledFiles":
                            return $@"<Files>
                                        <Folder Type='Folder' FullFile='{Folder1}/' Name='{Folder1}'></Folder>
                                        <Folder Type='Folder' FullFile='{Folder2}' Name='{Folder2}'>
                                            <File Type='File' FullFile='{File1}' Name='{File1}'></File>
                                        </Folder>
                                        <Folder Type='Folder' FullFile='{Folder3}/File' Name='{Folder3}'></Folder>
                                        <Folder Type='Folder' FullFile='{Folder4}' Name='{Folder4}' NoDelete='true'></Folder>
                                      </Files>";
                        default:
                            return DummyString;
                    }
                },
                Update = () => _listItemUpdated = true,
                Delete = () => _listItemDeleted = true,
                Recycle = () =>
                {
                    _listItemRecycled = true;
                    return Guid.NewGuid();
                }
            };

            _list = new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                GetItemsSPQuery = _ => new ShimSPListItemCollection
                {
                    CountGet = () => DummyInt,
                    ItemGetInt32 = __ => spListItem
                }.Bind(new SPListItem[]
                {
                    spListItem
                }),
                ParentWebGet = () => _web,
                Delete = () => _listDeleted = true,
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = _ => new ShimSPField
                    {
                        SealedGet = () => true,
                        Update = () => _fieldUpdated = true,
                        Delete = () => _fieldDeleted = true
                    }
                },
                ViewsGet = () => new ShimSPViewCollection
                {
                    ItemGetString = _ => new ShimSPView(),
                    DeleteGuid = _ => _viewDeleted = true
                },
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection().Bind(new SPEventReceiverDefinition[]
                {
                    new ShimSPEventReceiverDefinition
                    {
                        TypeGet = () => SPEventReceiverType.AppInstalled,
                        AssemblyGet = () => DummyString,
                        ClassGet = () => DummyString,
                        Delete = () => _eventHandlerDeleted = true
                    }
                })
            };

            _web = new ShimSPWeb
            {
                IDGet = () => new Guid(WebId),
                SiteGet = () => _site.Instance,
                CurrentUserGet = () => spUser,
                AllUsersGet = () => new ShimSPUserCollection
                {
                    GetByIDInt32 = _ => spUser
                },
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = item =>
                    {
                        if (item == File1)
                        {
                            return null;
                        }

                        return _list;
                    }
                },
                FilesGet = () => new ShimSPFileCollection
                {
                    DeleteString = _ => _webFileDeleted = true
                },
                NavigationGet = () => new ShimSPNavigation
                {
                    QuickLaunchGet = () => new ShimSPNavigationNodeCollection
                    {
                        DeleteSPNavigationNode = _ => _quickLaunchDeleted = true
                    }.Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt,
                            TitleGet = () => DummyString
                        }
                    }),
                    TopNavigationBarGet = () => new ShimSPNavigationNodeCollection
                    {
                        DeleteSPNavigationNode = _ => _topNavigationBarDeleted = true
                    }.Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt,
                            TitleGet = () => DummyString
                        },
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt + 1,
                            TitleGet = () => $"{DummyString}1",
                            ChildrenGet = () => new ShimSPNavigationNodeCollection
                            {
                                DeleteSPNavigationNode = _ => { }
                            }.Bind(new SPNavigationNode[]
                            {
                                new ShimSPNavigationNode
                                {
                                    IdGet = () => DummyInt,
                                    TitleGet = () => DummyString
                                }
                            })
                        }
                    })
                },
                GetFolderString = _ => new ShimSPFolder
                {
                    ExistsGet = () => true,
                    Delete = () => _folderDeleted = true
                },
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    RemoveGuid = _ => _webFeatureRemoved = true
                },
                GetFileString = _ => new ShimSPFile
                {
                    ExistsGet = () => true,
                    Delete = () => _fileDeleted = true
                }
            };
            
            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid(),
                GetCatalogSPListTemplateType = _ => new ShimSPDocumentLibrary(),
                SolutionsGet = () => new ShimSPUserSolutionCollection
                {
                    RemoveSPUserSolution = _ => _solutionDeleted = true
                }.Bind(new SPUserSolution[]
                {
                    new ShimSPUserSolution
                    {
                        NameGet = () => DummyString
                    }
                }),
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    RemoveGuid = _ => _siteFeatureRemoved = true
                }
            };

            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder
            {
                FilesGet = () => new ShimSPFileCollection().Bind(new SPFile[]
                {
                    new ShimSPFile
                    {
                        NameGet = () => DummyString,
                        Delete = () => _listFileDeleted = true
                    }
                })
            };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => _web.Instance;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.FeatureDefinitionsGet = _ => new ShimSPFeatureDefinitionCollection().Bind(new SPFeatureDefinition[]
            {
                new ShimSPFeatureDefinition
                {
                    IdGet = () => new Guid(Feature1Guid),
                    DisplayNameGet = () => DummyString,
                    CompatibilityLevelGet = () => 14,
                    ScopeGet = () => SPFeatureScope.Site
                },
                new ShimSPFeatureDefinition
                {
                    IdGet = () => new Guid(Feature2Guid),
                    DisplayNameGet = () => DummyString,
                    CompatibilityLevelGet = () => 15,
                    ScopeGet = () => SPFeatureScope.Site
                }
            });
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPPersistedObject.AllInstances.FarmGet = _ => new ShimSPFarm
            {
                FeatureDefinitionsGet = () => new ShimSPFeatureDefinitionCollection().Bind(new SPFeatureDefinition[]
                {
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid(Feature3Guid),
                        DisplayNameGet = () => DummyString,
                        CompatibilityLevelGet = () => 14,
                        ScopeGet = () => SPFeatureScope.Web
                    },
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid(Feature4Guid),
                        DisplayNameGet = () => DummyString,
                        CompatibilityLevelGet = () => 15,
                        ScopeGet = () => SPFeatureScope.Web
                    }
                })
            };

            ShimSPSiteDataQuery.Constructor = _ => { };

            ShimSPQuery.Constructor = _ => { };

            ShimApplications.RemoveAppFromCommunitySPListItemInt32 = (_, __) => _appRemovedFromCommunity = true;
            ShimApplications.DeleteCommunityInt32SPWeb = (_, __) => _communityDeleted = true;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimReportBiz.ConstructorGuid = (_, __) => { };
            ShimReportBiz.AllInstances.GetReferencingTablesEPMDataString = (_, __, ___) => new DataTable();
            ShimReportBiz.AllInstances.GetListBizGuid = (_, __) => new ShimListBiz
            {
                Delete = () => _listBizDeleted = true
            };

            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => DummyString;
            ShimEPMData.AllInstances.AddParamStringObject = (_, __, ___) => { };

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, __, ___) => DummyString;
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => _configSettingSet = true;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => $"{DummyString}1";
            ShimCoreFunctions.iGetListEventTypeString = _ => SPEventReceiverType.AppInstalled;

            ShimGridGanttSettings.AllInstances.SaveSettingsSPList = (_, __) => _gridGanttSettingsSaved = true;

            ShimPath.GetDirectoryNameString = _ => DummyString;
            ShimPath.GetExtensionString = fileName =>
            {
                if (fileName == Folder1)
                {
                    return DummyString;
                }

                return string.Empty;
            };
        }

        private XmlDocument CreateXmlDocument(string solutions)
        {
            var xmlString = $@"
                <Root>
                    <Application></Application>
                    <Solutions>
                        {solutions}
                    </Solutions>
                    <Lists>
                        <List Name='{DummyString}' Reporting='true'></List>
                        <List Name='{DummyString}' Reporting='true' NoDelete='true'>
                            <Fields>
                                <Field InternalName='{DummyString}' Total='{DummyInt}'></Field>
                            </Fields>
                            <Lookups>
                                <Lookup InternalName='{DummyString}'></Lookup>
                            </Lookups>
                            <Views>
                                <View Name='{DummyString}'></View>
                            </Views>
                            <Workflows>
                                <Workflow Name='{DummyString}'></Workflow>
                            </Workflows>
                            <EventHandlers>
                                <EventHandler Type='{DummyString}' Assembly='{DummyString}' Class='{DummyString}'></EventHandler>
                            </EventHandlers>
                            <Items>
                                <Item>
                                    <Field Name='Title'>{DummyString}</Field>
                                </Item>
                            </Items>
                        </List>
                    </Lists>
                    <Features>
                        <Feature ID='{Feature1Guid}' Name='{DummyString}'></Feature>
                        <Feature ID='{Feature2Guid}' Name='{DummyString}'></Feature>
                        <Feature ID='{Feature3Guid}' Name='{DummyString}'></Feature>
                        <Feature ID='{Feature4Guid}' Name='{DummyString}'></Feature>
                    </Features>
                    <Web>
                        <Properties>
                            <Property Name='{DummyString}' 
                                      Value='{DummyString}' 
                                      Append='true' 
                                      Overwrite='true' 
                                      LockWebProperty='true'
                                      Seperator='\n'></Property>
                        </Properties>
                    </Web>
                </Root>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument;
        }

        private DataTable CreateSiteDataTable(string webId)
        {
            const string WebIdColumn = "WebId";

            var dataTable = new DataTable();
            dataTable.Columns.Add(WebIdColumn);

            var dataRow = dataTable.NewRow();
            dataRow[WebIdColumn] = new Guid(webId);

            dataTable.Rows.Add(dataRow);

            return dataTable;
        }

        [TestMethod]
        public void UninstallApp_WhenIsRootWebAndUserHasPermissionsAndHasNotSolutionsAndIsNotVerifyOnly_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();
            SetupForUnninstallApp(guid, true, true, false);

            // Act
            _testObj.UninstallApp(false, _web.Instance);

            // Assert
            var messages = _testObj.XmlMessages.OuterXml;
            this.ShouldSatisfyAllConditions(
                () => _webFileDeleted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeFalse(),
                () => _listItemRecycled.ShouldBeTrue(),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _fieldDeleted.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _viewDeleted.ShouldBeTrue(),
                () => _eventHandlerDeleted.ShouldBeTrue(),
                () => _siteFeatureRemoved.ShouldBeFalse(),
                () => _webFeatureRemoved.ShouldBeTrue(),
                () => _appRemovedFromCommunity.ShouldBeTrue(),
                () => _communityDeleted.ShouldBeTrue(),
                () => _quickLaunchDeleted.ShouldBeTrue(),
                () => _topNavigationBarDeleted.ShouldBeTrue(),
                () => _listBizDeleted.ShouldBeTrue(),
                () => _listDeleted.ShouldBeTrue(),
                () => _configSettingSet.ShouldBeTrue(),
                () => _solutionDeleted.ShouldBeFalse(),
                () => _listFileDeleted.ShouldBeFalse(),
                () => _folderDeleted.ShouldBeTrue(),
                () => _fileDeleted.ShouldBeTrue(),
                () => messages.ShouldContain(ApplicationUninstall),
                () => messages.ShouldContain(ApplicationInstalledSomewhereElse),
                () => messages.ShouldContain(PermissionsCheck),
                () => messages.ShouldNotContain(YouDoNotHavePermissions),
                () => messages.ShouldContain(RemovingAppFromCommunities),
                () => messages.ShouldContain(DeletingCommunity),
                () => messages.ShouldContain(UninstallingNavigation),
                () => messages.ShouldContain(CheckingQuickLaunch),
                () => messages.ShouldContain(CheckingTopNavigation),
                () => messages.ShouldContain(UninstallingLists),
                () => messages.ShouldContain(ListWillNotDelete),
                () => messages.ShouldContain(UninstallingFields),
                () => messages.ShouldContain(UninstallingLookups),
                () => messages.ShouldContain(UninstallingViews),
                () => messages.ShouldContain(UninstallingWorkflows),
                () => messages.ShouldContain(UninstallingEventHandlers),
                () => messages.ShouldContain(UninstallingItems),
                () => messages.ShouldContain(RemoveDummyStringFromReportingDatabase),
                () => messages.ShouldContain(UninstallingFeatures),
                () => messages.ShouldContain(ApplicationInstalledOnAnotherSite),
                () => messages.ShouldContain(UninstallingProperties),
                () => messages.ShouldContain(UninstallingFiles),
                () => messages.ShouldContain(FolderIsAList),
                () => messages.ShouldNotContain(UninstallingSolutionsAndLists));
        }

        [TestMethod]
        public void UninstallApp_WhenIsNotRootWebAndUserHasPermissionsAndHasSolutionsAndIsNotVerifyOnly_ConfirmResult()
        {
            // Arrange
            SetupForUnninstallApp(WebId, false, true, true);

            // Act
            _testObj.UninstallApp(false, _web.Instance);

            // Assert
            var messages = _testObj.XmlMessages.OuterXml;
            this.ShouldSatisfyAllConditions(
                () => _webFileDeleted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeTrue(),
                () => _listItemRecycled.ShouldBeTrue(),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _fieldDeleted.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _viewDeleted.ShouldBeTrue(),
                () => _eventHandlerDeleted.ShouldBeTrue(),
                () => _siteFeatureRemoved.ShouldBeTrue(),
                () => _webFeatureRemoved.ShouldBeTrue(),
                () => _appRemovedFromCommunity.ShouldBeTrue(),
                () => _communityDeleted.ShouldBeTrue(),
                () => _quickLaunchDeleted.ShouldBeTrue(),
                () => _topNavigationBarDeleted.ShouldBeTrue(),
                () => _listBizDeleted.ShouldBeTrue(),
                () => _listDeleted.ShouldBeTrue(),
                () => _configSettingSet.ShouldBeTrue(),
                () => _solutionDeleted.ShouldBeTrue(),
                () => _listFileDeleted.ShouldBeTrue(),
                () => _folderDeleted.ShouldBeTrue(),
                () => _fileDeleted.ShouldBeTrue(),
                () => messages.ShouldNotContain(ApplicationUninstall),
                () => messages.ShouldNotContain(ApplicationInstalledSomewhereElse),
                () => messages.ShouldContain(PermissionsCheck),
                () => messages.ShouldNotContain(YouDoNotHavePermissions),
                () => messages.ShouldContain(RemovingAppFromCommunities),
                () => messages.ShouldContain(DeletingCommunity),
                () => messages.ShouldContain(UninstallingNavigation),
                () => messages.ShouldContain(CheckingQuickLaunch),
                () => messages.ShouldContain(CheckingTopNavigation),
                () => messages.ShouldContain(UninstallingLists),
                () => messages.ShouldContain(ListWillNotDelete),
                () => messages.ShouldContain(UninstallingFields),
                () => messages.ShouldContain(UninstallingLookups),
                () => messages.ShouldContain(UninstallingViews),
                () => messages.ShouldContain(UninstallingWorkflows),
                () => messages.ShouldContain(UninstallingEventHandlers),
                () => messages.ShouldContain(UninstallingItems),
                () => messages.ShouldContain(RemoveDummyStringFromReportingDatabase),
                () => messages.ShouldContain(UninstallingFeatures),
                () => messages.ShouldNotContain(ApplicationInstalledOnAnotherSite),
                () => messages.ShouldContain(UninstallingProperties),
                () => messages.ShouldContain(UninstallingFiles),
                () => messages.ShouldContain(FolderIsAList),
                () => messages.ShouldContain(UninstallingSolutionsAndLists));
        }

        [TestMethod]
        public void UninstallApp_WhenIsNotRootWebAndUserHasPermissionsAndHasNotSolutionsAndIsNotVerifyOnly_ConfirmResult()
        {
            // Arrange
            SetupForUnninstallApp(WebId, false, true, false);

            // Act
            _testObj.UninstallApp(false, _web.Instance);

            // Assert
            var messages = _testObj.XmlMessages.OuterXml;
            this.ShouldSatisfyAllConditions(
                () => _webFileDeleted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeTrue(),
                () => _listItemRecycled.ShouldBeTrue(),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _fieldDeleted.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _viewDeleted.ShouldBeTrue(),
                () => _eventHandlerDeleted.ShouldBeTrue(),
                () => _siteFeatureRemoved.ShouldBeTrue(),
                () => _webFeatureRemoved.ShouldBeTrue(),
                () => _appRemovedFromCommunity.ShouldBeTrue(),
                () => _communityDeleted.ShouldBeTrue(),
                () => _quickLaunchDeleted.ShouldBeTrue(),
                () => _topNavigationBarDeleted.ShouldBeTrue(),
                () => _listBizDeleted.ShouldBeTrue(),
                () => _listDeleted.ShouldBeTrue(),
                () => _configSettingSet.ShouldBeTrue(),
                () => _solutionDeleted.ShouldBeFalse(),
                () => _listFileDeleted.ShouldBeFalse(),
                () => _folderDeleted.ShouldBeTrue(),
                () => _fileDeleted.ShouldBeTrue(),
                () => messages.ShouldNotContain(ApplicationUninstall),
                () => messages.ShouldNotContain(ApplicationInstalledSomewhereElse),
                () => messages.ShouldContain(PermissionsCheck),
                () => messages.ShouldNotContain(YouDoNotHavePermissions),
                () => messages.ShouldContain(RemovingAppFromCommunities),
                () => messages.ShouldContain(DeletingCommunity),
                () => messages.ShouldContain(UninstallingNavigation),
                () => messages.ShouldContain(CheckingQuickLaunch),
                () => messages.ShouldContain(CheckingTopNavigation),
                () => messages.ShouldContain(UninstallingLists),
                () => messages.ShouldContain(ListWillNotDelete),
                () => messages.ShouldContain(UninstallingFields),
                () => messages.ShouldContain(UninstallingLookups),
                () => messages.ShouldContain(UninstallingViews),
                () => messages.ShouldContain(UninstallingWorkflows),
                () => messages.ShouldContain(UninstallingEventHandlers),
                () => messages.ShouldContain(UninstallingItems),
                () => messages.ShouldContain(RemoveDummyStringFromReportingDatabase),
                () => messages.ShouldContain(UninstallingFeatures),
                () => messages.ShouldNotContain(ApplicationInstalledOnAnotherSite),
                () => messages.ShouldContain(UninstallingProperties),
                () => messages.ShouldContain(UninstallingFiles),
                () => messages.ShouldContain(FolderIsAList),
                () => messages.ShouldContain(UninstallingSolutionsAndLists));
        }

        [TestMethod]
        public void UninstallApp_WhenIsRootWebAndUserHasPermissionsAndHasNotSolutionsAndIsVerifyOnly_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();
            SetupForUnninstallApp(guid, true, true, false);

            // Act
            _testObj.UninstallApp(true, _web.Instance);

            // Assert
            var messages = _testObj.XmlMessages.OuterXml;
            this.ShouldSatisfyAllConditions(
                () => _webFileDeleted.ShouldBeFalse(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeFalse(),
                () => _listItemRecycled.ShouldBeFalse(),
                () => _fieldUpdated.ShouldBeFalse(),
                () => _fieldDeleted.ShouldBeFalse(),
                () => _gridGanttSettingsSaved.ShouldBeFalse(),
                () => _viewDeleted.ShouldBeFalse(),
                () => _eventHandlerDeleted.ShouldBeFalse(),
                () => _siteFeatureRemoved.ShouldBeFalse(),
                () => _webFeatureRemoved.ShouldBeFalse(),
                () => _appRemovedFromCommunity.ShouldBeFalse(),
                () => _communityDeleted.ShouldBeFalse(),
                () => _quickLaunchDeleted.ShouldBeFalse(),
                () => _topNavigationBarDeleted.ShouldBeFalse(),
                () => _listBizDeleted.ShouldBeFalse(),
                () => _listDeleted.ShouldBeFalse(),
                () => _configSettingSet.ShouldBeFalse(),
                () => _solutionDeleted.ShouldBeFalse(),
                () => _listFileDeleted.ShouldBeFalse(),
                () => _folderDeleted.ShouldBeFalse(),
                () => _fileDeleted.ShouldBeFalse(),
                () => messages.ShouldContain(ApplicationUninstall),
                () => messages.ShouldContain(ApplicationInstalledSomewhereElse),
                () => messages.ShouldContain(PermissionsCheck),
                () => messages.ShouldNotContain(YouDoNotHavePermissions),
                () => messages.ShouldNotContain(RemovingAppFromCommunities),
                () => messages.ShouldNotContain(DeletingCommunity),
                () => messages.ShouldNotContain(UninstallingNavigation),
                () => messages.ShouldContain(CheckingNavigation),
                () => messages.ShouldContain(CheckingQuickLaunch),
                () => messages.ShouldContain(CheckingTopNavigation),
                () => messages.ShouldNotContain(UninstallingLists),
                () => messages.ShouldContain(CheckingLists),
                () => messages.ShouldContain(ListWillNotDelete),
                () => messages.ShouldNotContain(UninstallingFields),
                () => messages.ShouldContain(CheckingFields),
                () => messages.ShouldNotContain(UninstallingLookups),
                () => messages.ShouldContain(CheckingLookups),
                () => messages.ShouldNotContain(UninstallingViews),
                () => messages.ShouldContain(CheckingViews),
                () => messages.ShouldNotContain(UninstallingWorkflows),
                () => messages.ShouldContain(CheckingWorkflows),
                () => messages.ShouldNotContain(UninstallingEventHandlers),
                () => messages.ShouldContain(CheckingEventHandlers),
                () => messages.ShouldNotContain(UninstallingItems),
                () => messages.ShouldContain(CheckingItems),
                () => messages.ShouldContain(RemoveFromReportingDatabase),
                () => messages.ShouldNotContain(UninstallingFeatures),
                () => messages.ShouldContain(CheckingFeatures),
                () => messages.ShouldContain(ApplicationInstalledOnAnotherSite),
                () => messages.ShouldNotContain(UninstallingProperties),
                () => messages.ShouldContain(CheckingProperties),
                () => messages.ShouldNotContain(UninstallingFiles),
                () => messages.ShouldContain(CheckingFiles),
                () => messages.ShouldContain(FolderIsAList),
                () => messages.ShouldNotContain(UninstallingSolutionsAndLists));
        }

        [TestMethod]
        public void UninstallApp_WhenIsNotRootWebAndUserHasPermissionsAndHasSolutionsAndIsVerifyOnly_ConfirmResult()
        {
            // Arrange
            SetupForUnninstallApp(WebId, false, true, true);

            // Act
            _testObj.UninstallApp(true, _web.Instance);

            // Assert
            var messages = _testObj.XmlMessages.OuterXml;
            this.ShouldSatisfyAllConditions(
                () => _webFileDeleted.ShouldBeFalse(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeFalse(),
                () => _listItemRecycled.ShouldBeFalse(),
                () => _gridGanttSettingsSaved.ShouldBeFalse(),
                () => _viewDeleted.ShouldBeFalse(),
                () => _eventHandlerDeleted.ShouldBeFalse(),
                () => _siteFeatureRemoved.ShouldBeFalse(),
                () => _webFeatureRemoved.ShouldBeFalse(),
                () => _appRemovedFromCommunity.ShouldBeFalse(),
                () => _communityDeleted.ShouldBeFalse(),
                () => _quickLaunchDeleted.ShouldBeFalse(),
                () => _topNavigationBarDeleted.ShouldBeFalse(),
                () => _listBizDeleted.ShouldBeFalse(),
                () => _listDeleted.ShouldBeFalse(),
                () => _configSettingSet.ShouldBeFalse(),
                () => _solutionDeleted.ShouldBeFalse(),
                () => _listFileDeleted.ShouldBeFalse(),
                () => _folderDeleted.ShouldBeFalse(),
                () => _fileDeleted.ShouldBeFalse(),
                () => messages.ShouldNotContain(ApplicationUninstall),
                () => messages.ShouldNotContain(ApplicationInstalledSomewhereElse),
                () => messages.ShouldContain(PermissionsCheck),
                () => messages.ShouldNotContain(YouDoNotHavePermissions),
                () => messages.ShouldNotContain(RemovingAppFromCommunities),
                () => messages.ShouldNotContain(DeletingCommunity),
                () => messages.ShouldNotContain(UninstallingNavigation),
                () => messages.ShouldContain(CheckingNavigation),
                () => messages.ShouldContain(CheckingQuickLaunch),
                () => messages.ShouldContain(CheckingTopNavigation),
                () => messages.ShouldNotContain(UninstallingLists),
                () => messages.ShouldContain(CheckingLists),
                () => messages.ShouldContain(ListWillNotDelete),
                () => messages.ShouldNotContain(UninstallingFields),
                () => messages.ShouldContain(CheckingFields),
                () => messages.ShouldNotContain(UninstallingLookups),
                () => messages.ShouldContain(CheckingLookups),
                () => messages.ShouldNotContain(UninstallingViews),
                () => messages.ShouldContain(CheckingViews),
                () => messages.ShouldNotContain(UninstallingWorkflows),
                () => messages.ShouldContain(CheckingWorkflows),
                () => messages.ShouldNotContain(UninstallingEventHandlers),
                () => messages.ShouldContain(CheckingEventHandlers),
                () => messages.ShouldNotContain(UninstallingItems),
                () => messages.ShouldContain(CheckingItems),
                () => messages.ShouldContain(RemoveFromReportingDatabase),
                () => messages.ShouldNotContain(UninstallingFeatures),
                () => messages.ShouldContain(CheckingFeatures),
                () => messages.ShouldNotContain(ApplicationInstalledOnAnotherSite),
                () => messages.ShouldNotContain(UninstallingProperties),
                () => messages.ShouldContain(CheckingProperties),
                () => messages.ShouldNotContain(UninstallingFiles),
                () => messages.ShouldContain(CheckingFiles),
                () => messages.ShouldContain(FolderIsAList),
                () => messages.ShouldNotContain(UninstallingSolutionsAndLists),
                () => messages.ShouldContain(CheckingSolutionsAndLists));
        }

        [TestMethod]
        public void UninstallApp_WhenIsRootWebAndUserHasNotPermissionsAndHasNotSolutionsAndIsNotVerifyOnly_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();
            SetupForUnninstallApp(guid, true, false, false);

            // Act
            _testObj.UninstallApp(false, _web.Instance);

            // Assert
            var messages = _testObj.XmlMessages.OuterXml;
            this.ShouldSatisfyAllConditions(
                () => _webFileDeleted.ShouldBeFalse(),
                () => _listItemUpdated.ShouldBeFalse(),
                () => _listItemDeleted.ShouldBeFalse(),
                () => _listItemRecycled.ShouldBeFalse(),
                () => _fieldUpdated.ShouldBeFalse(),
                () => _fieldDeleted.ShouldBeFalse(),
                () => _gridGanttSettingsSaved.ShouldBeFalse(),
                () => _viewDeleted.ShouldBeFalse(),
                () => _eventHandlerDeleted.ShouldBeFalse(),
                () => _siteFeatureRemoved.ShouldBeFalse(),
                () => _webFeatureRemoved.ShouldBeFalse(),
                () => _appRemovedFromCommunity.ShouldBeFalse(),
                () => _communityDeleted.ShouldBeFalse(),
                () => _quickLaunchDeleted.ShouldBeFalse(),
                () => _topNavigationBarDeleted.ShouldBeFalse(),
                () => _listBizDeleted.ShouldBeFalse(),
                () => _listDeleted.ShouldBeFalse(),
                () => _configSettingSet.ShouldBeFalse(),
                () => _solutionDeleted.ShouldBeFalse(),
                () => _listFileDeleted.ShouldBeFalse(),
                () => _folderDeleted.ShouldBeFalse(),
                () => _fileDeleted.ShouldBeFalse(),
                () => messages.ShouldContain(ApplicationUninstall),
                () => messages.ShouldContain(ApplicationInstalledSomewhereElse),
                () => messages.ShouldContain(PermissionsCheck),
                () => messages.ShouldContain(YouDoNotHavePermissions),
                () => messages.ShouldNotContain(RemovingAppFromCommunities),
                () => messages.ShouldNotContain(DeletingCommunity),
                () => messages.ShouldNotContain(UninstallingNavigation),
                () => messages.ShouldNotContain(CheckingQuickLaunch),
                () => messages.ShouldNotContain(CheckingTopNavigation),
                () => messages.ShouldNotContain(UninstallingLists),
                () => messages.ShouldNotContain(ListWillNotDelete),
                () => messages.ShouldNotContain(UninstallingFields),
                () => messages.ShouldNotContain(UninstallingLookups),
                () => messages.ShouldNotContain(UninstallingViews),
                () => messages.ShouldNotContain(UninstallingWorkflows),
                () => messages.ShouldNotContain(UninstallingEventHandlers),
                () => messages.ShouldNotContain(UninstallingItems),
                () => messages.ShouldNotContain(RemoveDummyStringFromReportingDatabase),
                () => messages.ShouldNotContain(UninstallingFeatures),
                () => messages.ShouldNotContain(ApplicationInstalledOnAnotherSite),
                () => messages.ShouldNotContain(UninstallingProperties),
                () => messages.ShouldNotContain(UninstallingFiles),
                () => messages.ShouldNotContain(FolderIsAList),
                () => messages.ShouldNotContain(UninstallingSolutionsAndLists));
        }

        private void SetupForUnninstallApp(string webId, bool isRootWeb, bool userHavePermissions, bool hasSolutions)
        {
            var solutionsXml = string.Empty;

            if (hasSolutions)
            {
                solutionsXml = $@"<Solution FileName='{DummyString}'></Solution>
                                  <ListTemplate FileName='{DummyString}'></ListTemplate>";
            }

            ShimSPWeb.AllInstances.GetSiteDataSPSiteDataQuery = (_, __) => CreateSiteDataTable(webId);
            ShimSPWeb.AllInstances.IsRootWebGet = _ => isRootWeb;

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => userHavePermissions;

            ShimApplications.GetApplicationInfoFromListSPWebString = (_, __) => new ApplicationDef
            {
                Id = DummyInt,
                ApplicationXml = CreateXmlDocument(solutionsXml)
            };
        }
    }
}