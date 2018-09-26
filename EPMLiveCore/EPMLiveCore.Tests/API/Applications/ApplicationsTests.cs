using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Net.Fakes;
using System.Text;
using System.Xml;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ApplicationsClass = EPMLiveCore.API.Applications;

namespace EPMLiveCore.Tests.API.Applications
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ApplicationsTests
    {
        private IDisposable _shimsObject;
        private PrivateType _privateType;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private ShimSPList _list;
        private List<string> _addedFields;
        private List<string> _lists;
        private string _itemStatus;
        private bool _fieldUpdated;
        private bool _eventReceiverManagerInvoked;
        private bool _featureAdded;
        private bool _listAdded;
        private bool _listUpdated;
        private bool _listItemUpdated;
        private bool _nodeDeleted;
        private bool _webClientDataDownloaded;
        private bool _jobAdded;
        private bool _jobEnqueued;
        private bool _listItemDeleted;
        private bool _listItemAdded;
        private bool _fileCopied;
        private bool _nodeAddedAsFirst;
        private bool _nodeAddedAsLast;
        private bool _cacheRemoved;
        private bool _listItemShouldBeFound;
        private bool _itemGetShouldReturnResult;
        private bool _getItemByIdShouldReturnResult;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com/";
        private const string DummyVersion = "1.0.0";
        private const string DummyPercent = "100";
        private const string JobGuid = "c3918941-f6da-4328-aad9-d4558e983368";

        private const string DescriptionField = "Description";
        private const string EXTIDField = "EXTID";
        private const string QuickLaunchField = "QuickLaunch";
        private const string TopNavField = "TopNav";
        private const string VisibleField = "Visible";
        private const string DefaultField = "Default";
        private const string HomePageField = "HomePage";
        private const string IconField = "Icon";
        private const string AppVersionField = "AppVersion";
        private const string AppUrlField = "AppUrl";
        private const string StatusField = "Status";
        private const string InstallPercentField = "InstallPercent";
        private const string InstallMessagesField = "InstallMessages";
        private const string ConfiguredField = "Configured";
        private const string InstalledFilesField = "InstalledFiles";
        private const string QuickLaunchXMLField = "QuickLaunchXML";
        private const string TopNavXMLField = "TopNavXML";
        private const string InstallXMLField = "InstallXML";
        private const string LinkedAppsField = "LinkedApps";
        private const string LinkedCommunityField = "LinkedCommunity";
        private const string InstalledApplicationsItem = "Installed Applications";

        private const string AddAppNavMethod = "AddAppNav";
        private const string BuildNavMethod = "BuildNav";
        private const string ClearNavMethod = "ClearNav";
        private const string GetValidVersionMethod = "GetValidVersion";
        private const string IsValidVersionMethod = "isValidVersion";

        private const string ApplicationNotRunThroughPreCheck = "Application has not run through a PreCheck.";
        private const string PreCheckStartedStatus = "PreCheck Started";
        private const string InstallingStatus = "Installing";
        private const string InstalledStatus = "Installed";
        private const string PreCheckInProgress = "PreCheck in Progress.";
        private const string ApplicationInstallInProgress = "Application install in progress.";
        private const string ApplicationAlreadyInstalled = "Application already installed.";
        private const string ApplicationStatusUnknown = "Application status unknown.";
        private const string MessageNode = "Message";
        private const string PercentCompleteNode = "PercentComplete";
        private const string CouldNotReadStatus = "Could not read status";
        private const string CouldNotReadMessage = "Could not read message";
        private const string CouldNotReadPercentComplete = "Could not read % complete";
        private const string ApplicationNotInstalled = "Application Not Installed";
        private const string PreCheckSuccesful = "PreCheck Successful";
        private const string Unknown = "Unknown";
        private const string InstallApplicationListIsMissing = "Install Applications list is missing";
        private const string ErrorDeletingCommunity = "Error deleting community:";
        private const string ErrorAddingCommunity = "Error adding community:";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _addedFields = new List<string>();
            _lists = new List<string>();
            _fieldUpdated = false;
            _eventReceiverManagerInvoked = false;
            _featureAdded = false;
            _listAdded = false;
            _listUpdated = false;
            _listItemUpdated = false;
            _nodeDeleted = false;
            _webClientDataDownloaded = false;
            _jobAdded = false;
            _jobEnqueued = false;
            _listItemDeleted = false;
            _listItemAdded = false;
            _fileCopied = false;
            _nodeAddedAsFirst = false;
            _nodeAddedAsLast = false;
            _cacheRemoved = false;
            _listItemShouldBeFound = true;
            _itemGetShouldReturnResult = true;
            _getItemByIdShouldReturnResult = true;

            SetupShims();

            _privateType = new PrivateType(typeof(ApplicationsClass));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            var counters = new Dictionary<string, int>();
            var addedFields = new List<string>();
            _list = new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                ParentWebGet = () => _web,
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name =>
                    {
                        if (!counters.Keys.Contains(name))
                        {
                            counters.Add(name, 1);

                            return null;
                        }

                        switch (name)
                        {
                            case VisibleField:
                            case DefaultField:
                                return new ShimSPFieldBoolean();
                            case InstallPercentField:
                                return new ShimSPFieldNumber();
                            case InstallMessagesField:
                                return new ShimSPFieldMultiLineText();
                            default:
                                return new ShimSPField();
                        }
                    },
                    AddStringSPFieldTypeBoolean = (field, __, ___) =>
                    {
                        _addedFields.Add(field);
                        return field;
                    }
                },
                Update = () => _listUpdated = true,
                GetItemsSPQuery = _ => new ShimSPListItemCollection
                {
                    CountGet = () => _listItemShouldBeFound ? DummyInt : 0,
                    ItemGetInt32 = __ => new ShimSPListItem
                    {
                        ItemGetString = item =>
                        {
                            if (!_itemGetShouldReturnResult)
                            {
                                return null;
                            }

                            switch (item)
                            {
                                case InstallXMLField:
                                    return CreateApplicationXml();
                                case StatusField:
                                    return string.IsNullOrWhiteSpace(_itemStatus) ? PreCheckSuccesful : _itemStatus;
                                case InstallPercentField:
                                case InstallMessagesField:
                                    return DummyInt.ToString();
                                default:
                                    return DummyString;
                            }
                        }
                    }
                },
                GetItemByIdInt32 = _ =>
                {
                    if (!_getItemByIdShouldReturnResult)
                    {
                        return null;
                    }

                    return new ShimSPListItem
                    {
                        ItemGetString = __ => $"{DummyInt}:{DummyInt}",
                        Delete = () => _listItemDeleted = true
                    };
                },
                ItemsGet = () => new ShimSPListItemCollection
                {
                    Add = () =>
                    {
                        _listItemAdded = true;
                        return new ShimSPListItem
                        {
                            IDGet = () => DummyInt
                        };
                    }
                }.Bind(new SPListItem[]
                {
                    new ShimSPListItem
                    {
                        IDGet = () => DummyInt,
                        ItemGetString = item =>
                        {
                            if (item == QuickLaunchXMLField)
                            {
                                return $"<QuickLaunch><Nav name='{DummyString}' url='{DummyString}'/></QuickLaunch>";
                            }

                            if (item == TopNavXMLField)
                            {
                                return $"<TopNav><Nav name='{DummyString}' url='{DummyString}'/></TopNav>";
                            }

                            return DummyString;
                        }
                    }
                })
            };

            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid(),
                RootWebGet = () => _web
            };

            _web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                ServerRelativeUrlGet = () => "/",
                SiteGet = () => _site,
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = listName =>
                    {
                        if (!_lists.Contains(listName))
                        {
                            _lists.Add(listName);
                            return null;
                        }

                        return _list;
                    },
                    AddStringStringSPListTemplateType = (_, __, ___) =>
                    {
                        _listAdded = true;
                        return Guid.NewGuid();
                    },
                    AddStringStringStringStringInt32String = (_1, _2, _3, _4, _5, _6) =>
                    {
                        _listAdded = true;
                        return Guid.NewGuid();
                    },
                    ItemGetGuid = _ => _list
                },
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    AddGuidBoolean = (_, __) =>
                    {
                        _featureAdded = true;
                        return new ShimSPFeature();
                    }
                },
                NavigationGet = () => new ShimSPNavigation
                {
                    QuickLaunchGet = () => new ShimSPNavigationNodeCollection
                    {
                        ParentGet = () => new ShimSPNavigationNode
                        {
                            ChildrenGet = () => new ShimSPNavigationNodeCollection().Bind(new SPNavigationNode[]
                            {
                                new ShimSPNavigationNode
                                {
                                    IdGet = () => DummyInt,
                                    UrlGet = () => DummyString,
                                    TitleGet = () => DummyString,
                                    ChildrenGet = () => new ShimSPNavigationNodeCollection
                                    {
                                        CountGet = () => 0
                                    }
                                }
                            })
                        }
                    }.Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt,
                            UrlGet = () => DummyString,
                            TitleGet = () => DummyString,
                            ChildrenGet = () => new ShimSPNavigationNodeCollection
                            {
                                CountGet = () => 0
                            }.Bind(new SPNavigationNode[] { })
                        }
                    }),
                    TopNavigationBarGet = () => new ShimSPNavigationNodeCollection
                    {
                        ParentGet = () => new ShimSPNavigationNode
                        {
                            ChildrenGet = () => new ShimSPNavigationNodeCollection().Bind(new SPNavigationNode[]
                            {
                                new ShimSPNavigationNode
                                {
                                    IdGet = () => DummyInt,
                                    UrlGet = () => DummyString,
                                    TitleGet = () => DummyString,
                                    ChildrenGet = () => new ShimSPNavigationNodeCollection
                                    {
                                        CountGet = () => 0
                                    }
                                }
                            })
                        }
                    }.Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt,
                            UrlGet = () => DummyString,
                            TitleGet = () => DummyString,
                            ChildrenGet = () => new ShimSPNavigationNodeCollection
                            {
                                CountGet = () => 0
                            }.Bind(new SPNavigationNode[] { })
                        }
                    }),
                    GetNodeByIdInt32 = _ => new ShimSPNavigationNode
                    {
                        Delete = () => _nodeDeleted = true
                    }
                },
                RootFolderGet = () => new ShimSPFolder
                {
                    FilesGet = () => new ShimSPFileCollection
                    {
                        ItemGetString = _ => new ShimSPFile
                        {
                            ExistsGet = () => true,
                            CopyToStringBoolean = (_1, _2) => _fileCopied = true
                        }
                    }
                }
            };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.RootWebGet = _ => _web;
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPField.AllInstances.Update = _ => _fieldUpdated = true;

            ShimSPListItem.AllInstances.Update = _ => _listItemUpdated = true;
            ShimSPListItem.AllInstances.ParentListGet = _ => _list;

            ShimWorkEngineAPI.EventReceiverManagerStringSPWeb = (_, __) =>
            {
                _eventReceiverManagerInvoked = true;
                return DummyString;
            };

            ShimSPQuery.Constructor = _ => { };

            ShimSPFieldUrlValue.ConstructorString = (_, __) => { };
            ShimSPFieldUrlValue.AllInstances.UrlGet = _ => DummyUrl;

            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => { };

            ShimSPNavigationNode.ConstructorStringString = (_, __, ___) => { };

            ShimSPNavigationNodeCollection.AllInstances.AddAsFirstSPNavigationNode = (_, __) =>
            {
                _nodeAddedAsFirst = true;
                return null;
            };
            ShimSPNavigationNodeCollection.AllInstances.AddAsLastSPNavigationNode = (_, __) =>
            {
                _nodeAddedAsLast = true;
                return null;
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimPath.GetFileNameString = path => path;

            ShimCoreFunctions.getFarmSettingString = _ => DummyUrl;
            ShimCoreFunctions.GetStoreCreds = () => new ShimNetworkCredential();
            ShimCoreFunctions.GetAssemblyVersion = () => DummyVersion;
            ShimCoreFunctions.enqueueGuidInt32SPSite = (_, __, ___) => _jobEnqueued = true;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => string.Empty;

            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString = (_, _1, _2, _3, _4, _5, _6, _7) =>
                CreateXmlNodes();

            ShimWebClient.Constructor = _ => { };
            ShimWebClient.AllInstances.DownloadDataString = (_, __) =>
            {
                _webClientDataDownloaded = true;

                return Encoding.ASCII.GetBytes(CreateApplicationXml());
            };

            ShimTimer.AddTimerJobGuidGuidGuidInt32StringInt32StringStringInt32Int32String =
            (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11) =>
            {
                _jobAdded = true;
                return new Guid(JobGuid);
            };

            ShimCacheStoreCategory.ConstructorSPWeb = (_, __) => { };
            ShimCacheStoreCategory.AllInstances.NavigationGet = _ => DummyString;

            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveSafelyStringStringString = (_, __, ___) => _cacheRemoved = true
            };
        }

        private XmlNode CreateXmlJobStatus()
        {
            var xmlString = $"<JobStatus Status='{DummyString}' PercentComplete='{DummyPercent}'>{DummyString}</JobStatus>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument.SelectSingleNode("/JobStatus");
        }

        private XmlNode CreateXmlNodes()
        {
            const string Version = "VERSION_1.0.0";
            var xmlString = $@"<xml xmlns:rs='urn:schemas-microsoft-com:rowset' xmlns:z='#RowsetSchema'>
                                 <rs:data>
                                     <z:row ows_Title='{DummyString}' ows_LinkFilename='{Version}' ows_PreReqs='{DummyString}' ows_UID='{DummyInt}' ows_ShortDescription='{DummyString}' ows_MoreInfo='{DummyString}' ows_Company='{DummyString}'/>
                                 </rs:data>
                               </xml>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument.SelectSingleNode("/xml");
        }

        private string CreateApplicationXml()
        {
            return $@"<Root>
                        <Application Community='{DummyString}' Visible='{true}' ParentApplications='{DummyString}'>
                            <QuickLaunch></QuickLaunch>
                            <TopNav></TopNav>
                        </Application>
                      </Root>";
        }

        [TestMethod]
        public void AddAppToCommunity_OnValidCall_ConfirmResult()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ParentListGet = () => _list,
                ItemGetGuid = _ => $"{DummyInt}:{DummyInt}"
            }.Instance;

            // Act
            ApplicationsClass.AddAppToCommunity(listItem, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _addedFields.ShouldContain(DescriptionField),
                () => _addedFields.ShouldContain(EXTIDField),
                () => _addedFields.ShouldContain(QuickLaunchField),
                () => _addedFields.ShouldContain(TopNavField),
                () => _addedFields.ShouldContain(VisibleField),
                () => _addedFields.ShouldContain(DefaultField),
                () => _addedFields.ShouldContain(HomePageField),
                () => _addedFields.ShouldContain(IconField),
                () => _addedFields.ShouldContain(AppVersionField),
                () => _addedFields.ShouldContain(AppUrlField),
                () => _addedFields.ShouldContain(StatusField),
                () => _addedFields.ShouldContain(InstallPercentField),
                () => _addedFields.ShouldContain(InstallMessagesField),
                () => _addedFields.ShouldContain(ConfiguredField),
                () => _addedFields.ShouldContain(InstalledFilesField),
                () => _addedFields.ShouldContain(QuickLaunchXMLField),
                () => _addedFields.ShouldContain(TopNavXMLField),
                () => _addedFields.ShouldContain(InstallXMLField),
                () => _addedFields.ShouldContain(LinkedAppsField),
                () => _addedFields.ShouldContain(LinkedCommunityField),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _eventReceiverManagerInvoked.ShouldBeTrue(),
                () => _listAdded.ShouldBeTrue(),
                () => _listUpdated.ShouldBeTrue(),
                () => _featureAdded.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void RemoveAppFromCommunity_OnValidCall_ConfirmResult()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ParentListGet = () => _list,
                ItemGetGuid = _ => $"{DummyInt}:{DummyInt}"
            }.Instance;

            // Act
            ApplicationsClass.RemoveAppFromCommunity(listItem, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _addedFields.ShouldContain(DescriptionField),
                () => _addedFields.ShouldContain(EXTIDField),
                () => _addedFields.ShouldContain(QuickLaunchField),
                () => _addedFields.ShouldContain(TopNavField),
                () => _addedFields.ShouldContain(VisibleField),
                () => _addedFields.ShouldContain(DefaultField),
                () => _addedFields.ShouldContain(HomePageField),
                () => _addedFields.ShouldContain(IconField),
                () => _addedFields.ShouldContain(AppVersionField),
                () => _addedFields.ShouldContain(AppUrlField),
                () => _addedFields.ShouldContain(StatusField),
                () => _addedFields.ShouldContain(InstallPercentField),
                () => _addedFields.ShouldContain(InstallMessagesField),
                () => _addedFields.ShouldContain(ConfiguredField),
                () => _addedFields.ShouldContain(InstalledFilesField),
                () => _addedFields.ShouldContain(QuickLaunchXMLField),
                () => _addedFields.ShouldContain(TopNavXMLField),
                () => _addedFields.ShouldContain(InstallXMLField),
                () => _addedFields.ShouldContain(LinkedAppsField),
                () => _addedFields.ShouldContain(LinkedCommunityField),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _eventReceiverManagerInvoked.ShouldBeTrue(),
                () => _nodeDeleted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void RemoveCommunityNav_OnValidCall_ConfirmResult()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetGuid = _ => $"{DummyInt}:{DummyInt}"
            }.Instance;
            var navField = new ShimSPField
            {
                IdGet = () => Guid.NewGuid()
            }.Instance;

            // Act
            ApplicationsClass.RemoveCommunityNav(listItem, _web, navField);

            // Assert
            _nodeDeleted.ShouldBeTrue();
        }

        [TestMethod]
        public void GenerateQuickLaunchFromApp_OnValidCall_ConfirmResult()
        {
            // Arrange
            _lists.Add(InstalledApplicationsItem);

            // Act
            ApplicationsClass.GenerateQuickLaunchFromApp(_web);

            // Assert
            _listItemUpdated.ShouldBeTrue();
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenVerifyOnly_ConfirmResult()
        {
            // Arrange, Act
            var result = ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), true, _web, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webClientDataDownloaded.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _jobAdded.ShouldBeTrue(),
                () => _jobEnqueued.ShouldBeTrue(),
                () => _listItemAdded.ShouldBeFalse(),
                () => result.ToString().ShouldBe(JobGuid));
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenNotVerifyOnly_ConfirmResult()
        {
            // Arrange, Act
            var result = ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webClientDataDownloaded.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _jobAdded.ShouldBeTrue(),
                () => _jobEnqueued.ShouldBeTrue(),
                () => _listItemAdded.ShouldBeFalse(),
                () => result.ToString().ShouldBe(JobGuid));
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenListCountIsZeroAndVerifyOnly_ConfirmResult()
        {
            // Arrange
            _listItemShouldBeFound = false;

            // Act
            var result = ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), true, _web, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webClientDataDownloaded.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _jobAdded.ShouldBeTrue(),
                () => _jobEnqueued.ShouldBeTrue(),
                () => _listItemAdded.ShouldBeTrue(),
                () => result.ToString().ShouldBe(JobGuid));
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenListCountIsZeroAndNotVerifyOnly_ThrowException()
        {
            // Arrange
            _listItemShouldBeFound = false;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationNotRunThroughPreCheck);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenPreCheckStartedAndVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = PreCheckStartedStatus;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), true, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(PreCheckInProgress);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenInstallingAndVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = InstallingStatus;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), true, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationInstallInProgress);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenInstalledAndVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = InstalledStatus;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), true, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationAlreadyInstalled);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenOtherValueAndVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = DummyString;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), true, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationInstallInProgress);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenPreCheckStartedAndNotVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = PreCheckStartedStatus;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(PreCheckInProgress);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenInstallingAndNotVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = InstallingStatus;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationInstallInProgress);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenInstalledAndNotVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = InstalledStatus;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationAlreadyInstalled);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenOtherValueAndNotVerifyOnly_ThrowException()
        {
            // Arrange
            _itemStatus = DummyString;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationStatusUnknown);
        }

        [TestMethod]
        public void QueueInstallAndConfigureApplication_WhenCannotGetItem_ThrowException()
        {
            // Arrange
            _itemGetShouldReturnResult = false;

            // Act
            Action action = () => ApplicationsClass.QueueInstallAndConfigureApplication(DummyInt.ToString(), false, _web, DummyString);

            // Assert
            Should.Throw<Exception>(action);
        }

        [TestMethod]
        public void CheckUninstallStatus_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimTimer.GetTimerJobStatusSPWebGuid = (_, __) => CreateXmlJobStatus();

            // Act
            var result = ApplicationsClass.CheckUninstallStatus(JobGuid, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(DummyString),
                () => result.SelectSingleNode(MessageNode).InnerXml.ShouldBe(DummyString),
                () => result.SelectSingleNode(PercentCompleteNode).InnerText.ShouldBe(DummyPercent));
        }

        [TestMethod]
        public void CheckUninstallStatus_WhenCannotGetStatus_ConfirmResult()
        {
            // Arrange
            ShimTimer.GetTimerJobStatusSPWebGuid = (_, __) => null;

            // Act
            var result = ApplicationsClass.CheckUninstallStatus(JobGuid, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(CouldNotReadStatus),
                () => result.SelectSingleNode(MessageNode).InnerXml.ShouldBe(CouldNotReadMessage),
                () => result.SelectSingleNode(PercentCompleteNode).InnerText.ShouldBe(CouldNotReadPercentComplete));
        }

        [TestMethod]
        public void QueueUninstallApplication_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ApplicationsClass.QueueUninstallApplication(DummyInt.ToString(), true, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _jobAdded.ShouldBeTrue(),
                () => _jobEnqueued.ShouldBeTrue(),
                () => result.ToString().ShouldBe(JobGuid));
        }

        [TestMethod]
        public void QueueUninstallApplication_WhenListCountIsZero_ThrowException()
        {
            // Arrange
            _listItemShouldBeFound = false;

            // Act
            Action action = () => ApplicationsClass.QueueUninstallApplication(DummyInt.ToString(), true, _web);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(ApplicationNotInstalled);
        }

        [TestMethod]
        public void CheckApplicationStatus_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ApplicationsClass.CheckApplicationStatus(DummyInt.ToString(), _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(PreCheckSuccesful),
                () => result.SelectSingleNode(MessageNode).InnerText.ShouldBe(DummyPercent),
                () => result.SelectSingleNode(PercentCompleteNode).InnerText.ShouldBe(DummyPercent));
        }

        [TestMethod]
        public void CheckApplicationStatus_WhenCannotGetStatus_ConfirmResult()
        {
            // Arrange
            _itemGetShouldReturnResult = false;

            // Act
            var result = ApplicationsClass.CheckApplicationStatus(DummyInt.ToString(), _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(CouldNotReadStatus),
                () => result.SelectSingleNode(MessageNode).InnerText.ShouldBeEmpty(),
                () => result.SelectSingleNode(PercentCompleteNode).InnerText.ShouldBe("0"));
        }

        [TestMethod]
        public void CheckApplicationStatus_WhenNoItemFound_ConfirmResult()
        {
            // Arrange
            _listItemShouldBeFound = false;

            // Act
            var result = ApplicationsClass.CheckApplicationStatus(DummyInt.ToString(), _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(Unknown));
        }

        [TestMethod]
        public void GetApplicationStatusMessage_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimTimer.GetTimerJobStatusGuidNullableOfGuidNullableOfGuidNullableOfInt32Int32 = (_1, _2, _3, _4, _5) => CreateXmlJobStatus();

            // Act
            var result = ApplicationsClass.GetApplicationStatusMessage(DummyInt.ToString(), _web, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(PreCheckSuccesful),
                () => result.SelectSingleNode(MessageNode).InnerXml.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetApplicationStatusMessage_WhenNoItemFound_ConfirmResult()
        {
            // Arrange
            _listItemShouldBeFound = false;

            // Act
            var result = ApplicationsClass.GetApplicationStatusMessage(DummyInt.ToString(), _web, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(Unknown));
        }

        [TestMethod]
        public void GetApplicationStatusMessage_WhenCannotGetStatus_ConfirmResult()
        {
            // Arrange
            _itemGetShouldReturnResult = false;

            ShimTimer.GetTimerJobStatusGuidNullableOfGuidNullableOfGuidNullableOfInt32Int32 = (_1, _2, _3, _4, _5) => CreateXmlJobStatus();

            // Act
            var result = ApplicationsClass.GetApplicationStatusMessage(DummyInt.ToString(), _web, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectSingleNode(StatusField).InnerText.ShouldBe(CouldNotReadStatus));
        }

        [TestMethod]
        public void DeleteCommunity_OnValidCall_ConfirmResult()
        {
            // Arrange
            _lists.Add(InstalledApplicationsItem);

            // Act
            ApplicationsClass.DeleteCommunity(DummyInt, _web);

            // Assert
            _listItemDeleted.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteCommunity_WhenInstalledApplicationsListIsNotFound_ConfirmResult()
        {
            // Arrange, Act
            Action action = () => ApplicationsClass.DeleteCommunity(DummyInt, _web);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(InstallApplicationListIsMissing);
        }

        [TestMethod]
        public void DeleteCommunity_WhenCannotDelete_ConfirmResult()
        {
            // Arrange
            _lists.Add(InstalledApplicationsItem);
            _getItemByIdShouldReturnResult = false;

            // Act
            Action action = () => ApplicationsClass.DeleteCommunity(DummyInt, _web);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldContain(ErrorDeletingCommunity);
        }

        [TestMethod]
        public void GetApplications_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string Id = "ID";
            const string Title = "Title";
            const string Description = "Description";
            const string MoreInfo = "MoreInfo";
            const string Company = "Company";
            const string PreReqs = "PreReqs";

            // Act
            var result = ApplicationsClass.GetApplications(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(1),
                () => result.Rows[0][Id].ShouldBe(DummyInt.ToString()),
                () => result.Rows[0][Title].ShouldBe(DummyString),
                () => result.Rows[0][Description].ShouldBe(DummyString),
                () => result.Rows[0][MoreInfo].ShouldBe(DummyString),
                () => result.Rows[0][Company].ShouldBe(DummyString),
                () => result.Rows[0][PreReqs].ShouldBe(DummyString));
        }

        [TestMethod]
        public void CreateCommunity_WhenIsNotFirstCommunity_ConfirmResult()
        {
            // Arrange, Act
            var result = ApplicationsClass.CreateCommunity(DummyString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listItemAdded.ShouldBeTrue(),
                () => _fileCopied.ShouldBeTrue(),
                () => _nodeAddedAsFirst.ShouldBeTrue(),
                () => _nodeAddedAsLast.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _cacheRemoved.ShouldBeTrue(),
                () => result.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void CreateCommunity_WhenIsFirstCommunity_ConfirmResult()
        {
            // Arrange
            _listItemShouldBeFound = false;

            // Act
            var result = ApplicationsClass.CreateCommunity(DummyString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listItemAdded.ShouldBeTrue(),
                () => _fileCopied.ShouldBeTrue(),
                () => _nodeAddedAsFirst.ShouldBeFalse(),
                () => _nodeAddedAsLast.ShouldBeFalse(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _cacheRemoved.ShouldBeTrue(),
                () => result.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void CreateCommunity_WhenApplicationListIsNull_ThrowException()
        {
            // Arrange
            ShimApplications.GetApplicationListSPWeb = _ => null;

            // Act
            Action action = () => ApplicationsClass.CreateCommunity(DummyString, _web);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(InstallApplicationListIsMissing);
        }

        [TestMethod]
        public void CreateCommunity_OnError_ThrowException()
        {
            // Arrange
            ShimApplications.bIsFirstCommunitySPList = _ =>
            {
                throw new Exception();
            };

            // Act
            Action action = () => ApplicationsClass.CreateCommunity(DummyString, _web);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldContain(ErrorAddingCommunity);
        }

        [TestMethod]
        public void AddAppNav_WhenAppNotFound_ConfirmResult()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetGuid = _ => string.Empty
            }.Instance;

            // Act
            _privateType.InvokeStatic(AddAppNavMethod,
                                      listItem,
                                      DummyInt,
                                      CreateNavsXmlNode(),
                                      new ShimSPNavigationNodeCollection().Instance,
                                      new ShimSPField().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _nodeAddedAsLast.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue());
        }

        private XmlNode CreateNavsXmlNode()
        {
            var xmlString = $"<Navs><Item Name='{DummyString}' Url='{DummyUrl}'/></Navs>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument.SelectSingleNode("/Navs");
        }

        [TestMethod]
        public void BuildNav_OnValidCall_ConfirmResult()
        {
            // Arrange
            var ids = string.Empty;

            // Act
            _privateType.InvokeStatic(BuildNavMethod,
                                      new ShimSPNavigationNodeCollection().Instance,
                                      CreateNavsXmlNode(),
                                      ids,
                                      _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _nodeAddedAsLast.ShouldBeTrue());
        }

        [TestMethod]
        public void ClearNav_OnValidCall_ConfirmResult()
        {
            //Arrange
            var navigationNodeDeleted = false;
            var collection = new ShimSPNavigationNodeCollection
            {
                DeleteSPNavigationNode = _ => navigationNodeDeleted = true
            }.Bind(new SPNavigationNode[]
            {
                new ShimSPNavigationNode()
            }).Instance;


            // Act
            _privateType.InvokeStatic(ClearNavMethod, collection);

            // Assert
            navigationNodeDeleted.ShouldBeTrue();
        }

        [TestMethod]
        public void GetValidVersion_CheckVersionLessThanHighestVersion_ReturnHighestVersion()
        {
            // Arrange
            const string CheckVersion = "1.0.0";
            const string AssemblyVersion = "1.0.1";
            const string HighestVersion = "1.0.1";

            // Act
            var result = (string)_privateType.InvokeStatic(GetValidVersionMethod, CheckVersion, AssemblyVersion, HighestVersion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldBe(HighestVersion));
        }

        [TestMethod]
        public void GetValidVersion_CheckVersionGreaterThanHighestVersionOnLastPosition_ReturnCheckVersion()
        {
            // Arrange
            const string CheckVersion = "1.0.1";
            const string AssemblyVersion = "1.0.2";
            const string HighestVersion = "1.0.0";

            // Act
            var result = (string)_privateType.InvokeStatic(GetValidVersionMethod, CheckVersion, AssemblyVersion, HighestVersion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldBe(CheckVersion));
        }

        [TestMethod]
        public void GetValidVersion_CheckVersionGreaterThanHighestVersionOnSecondPosition_ReturnCheckVersion()
        {
            // Arrange
            const string CheckVersion = "1.1.0";
            const string AssemblyVersion = "1.2.0";
            const string HighestVersion = "1.0.0";

            // Act
            var result = (string)_privateType.InvokeStatic(GetValidVersionMethod, CheckVersion, AssemblyVersion, HighestVersion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldBe(CheckVersion));
        }

        [TestMethod]
        public void GetValidVersion_CheckVersionGreaterThanHighestVersionOnFirstPosition_ReturnCheckVersion()
        {
            // Arrange
            const string CheckVersion = "2.0.0";
            const string AssemblyVersion = "3.0.0";
            const string HighestVersion = "1.0.0";

            // Act
            var result = (string)_privateType.InvokeStatic(GetValidVersionMethod, CheckVersion, AssemblyVersion, HighestVersion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldBe(CheckVersion));
        }

        [TestMethod]
        public void GetValidVersion_InvalidCheckVerion_ReturnHighestVersion()
        {
            // Arrange
            const string CheckVersion = "2";
            const string AssemblyVersion = "1.0.0";
            const string HighestVersion = "1.0.0";

            // Act
            var result = (string)_privateType.InvokeStatic(GetValidVersionMethod, CheckVersion, AssemblyVersion, HighestVersion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldBe(HighestVersion));
        }

        [TestMethod]
        public void GetValidVersion_OnError_ReturnHighestVersion()
        {
            // Arrange
            const string CheckVersion = "1.0.0";
            const string AssemblyVersion = "1.0.0";
            const string HighestVersion = "2";

            // Act
            var result = (string)_privateType.InvokeStatic(GetValidVersionMethod, CheckVersion, AssemblyVersion, HighestVersion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldBe(HighestVersion));
        }

        [TestMethod]
        public void IsValidVersion_CheckVersionIsGraterThenAssemblyVersionOnLastPosition_ReturnFalse()
        {
            // Arrange
            const string CheckVersion = "1.0.1";
            const string AssemblyVersion = "1.0.0";

            // Act
            var result = (bool)_privateType.InvokeStatic(IsValidVersionMethod, CheckVersion, AssemblyVersion);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void IsValidVersion_CheckVersionIsGraterThenAssemblyVersionOnSecondPosition_ReturnFalse()
        {
            // Arrange
            const string CheckVersion = "1.1.0";
            const string AssemblyVersion = "1.0.0";

            // Act
            var result = (bool)_privateType.InvokeStatic(IsValidVersionMethod, CheckVersion, AssemblyVersion);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void IsValidVersion_OnError_ReturnFalse()
        {
            // Arrange
            const string CheckVersion = "1";
            const string AssemblyVersion = "1.0.0";

            // Act
            var result = (bool)_privateType.InvokeStatic(IsValidVersionMethod, CheckVersion, AssemblyVersion);

            // Assert
            result.ShouldBeFalse();
        }
    }
}