using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Net.Fakes;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls.WebParts.Fakes;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.ApplicationStore.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.Jobs.Applications.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.WebPartsHelper;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ShimExtensionMethods = EPMLiveCore.Fakes.ShimExtensionMethods;
using ShimReportingAppStore = EPMLiveCore.AppStoreReporting.Fakes.ShimAppStore;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveCore.Tests.API.Applications
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ApplicationInstallerTestsPartOne
    {
        private IDisposable _shimObject;
        private ApplicationInstaller _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private ShimSPList _list;
        private bool _listItemUpdated;
        private bool _gridGanttSettingsSaved;
        private bool _folderAdded;
        private bool _verifyOnly;
        private bool _webFeatureAdded;
        private bool _siteFeatureAdded;
        private bool _fieldUpdated;
        private bool _fieldBooleanUpdated;
        private bool _viewFieldsAllDeleted;
        private bool _viewFieldAdded;
        private bool _viewUpdated;
        private bool _fileAdded;
        private bool _fileContentSaved;
        private bool _webPartSaved;
        private bool _webPartDeleted;
        private bool _webPartAdded;
        private bool _webPartConnected;
        private bool _fileDeleted;
        private bool _listItemAdded;
        private bool _listBizCreated;
        private bool _configSettingSet;
        private bool _communityCreated;
        private bool _quickLaunchAddedAsLast;
        private bool _nodeChildAddedAsLast;
        private bool _nodeUpdated;
        private bool _topNavAddedAsLast;
        private bool _quickLaunchXMLCreated;
        private bool _topNavXMLCreated;
        private bool _reportDataSourcesProcessed;
        private bool _cacheRemoved;
        private bool _storeInformationAdded;
        private bool _fileDeletedFromSolution;
        private bool _fileAddedToSolution;
        private bool _solutionRemoved;
        private bool _solutionAdded;
        private bool _returnFirstList;
        private bool _listAdded;
        private bool _fieldAdded;
        private bool _choiceUpdated;
        private bool _fieldAsXmlAdded;
        private bool _fileAddedToWeb;
        private bool _workFlowAssociationCreated;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://fake.url/";
        private const string DummyView = "DummyView";
        private const string DummyWorkflow = "DummyWorkflow";
        private const string DummyClass = "DummyClass";
        private const string Feature1Id = "ec2b8995-6ee8-4502-8900-a8f7536f8521";
        private const string Feature2Id = "06bdb63c-9f9d-46de-946c-0f4f445ba2ed";
        private const string Feature3Id = "be2146f3-3784-448d-bb2d-2f75bdab8ece";
        private const string Feature4Id = "8cd7059a-a484-43ef-b85b-72cad1bbbeb2";
        private const int CompatibilityLevel14 = 14;
        private const int CompatibilityLevel15 = 15;
        private const string LookupField = "LookupField";
        private const string MessageField = "Message";
        private const string DetailsField = "Details";
        private const string OWebField = "oWeb";
        private const string ApplicationInstall = "Application Install";
        private const string ApplicatinAlreadyInstalled = "Application is already installed in site collection and will configure.";
        private const string PermissionsCheck = "Permissions Check";
        private const string ApplicationList = "Application List";
        private const string PreRequisiteCheck = "Pre Requisite Check";
        private const string ActivationKeyCheck = "Activation Key Check";
        private const string InstallVersion = "Install Version";
        private const string InstallingFeatures = "Installing Features";
        private const string Feature1 = "Feature1";
        private const string Feature2 = "Feature2";
        private const string Feature3 = "Feature3";
        private const string Feature4 = "Feature4";
        private const string InstallingLists = "Installing Lists";
        private const string ListExists = "List exists and will upgrade";
        private const string UpdatingFields = "Updating Fields";
        private const string FieldUpdated = "Field updated";
        private const string FixingLookups = "Fixing Lookups";
        private const string EnabledAdvancedLookup = "Enabled Advanced Lookup";
        private const string UpdatingViews = "Updating Views";
        private const string ViewExists = "View exists and will overwrite";
        private const string UpdatingWebParts = "Updating WebParts";
        private const string GridOnAllViews = "Grid on All Views";
        private const string InstallingEventHandlers = "Installing Event Handlers";
        private const string ItemAdding = "ItemAdding";
        private const string InstallingItems = "Installing Items";
        private const string ItemTitle = "Item Title";
        private const string AddToReportingDatabase = "Add to Reporting Database";
        private const string InstallingProperties = "Installing Properties";
        private const string PropertyFound = "Property found and will append";
        private const string InstallingFiles = "Installing Files";
        private const string CreatingCommunity = "Creating Community";
        private const string InstallingNavigation = "Installing Navigation";
        private const string QuickLaunch = "QuickLaunch";
        private const string TopNav = "TopNav";
        private const string ProcessingReports = "Processing Reports";
        private const string CheckingFeatures = "Checking Features";
        private const string CheckingLists = "Checking Lists";
        private const string CheckingFields = "Checking Fields";
        private const string FieldExists = "Field exists and will overwrite";
        private const string CheckingLookups = "Checking Lookups";
        private const string CheckingViews = "Checking Views";
        private const string CheckingWebParts = "Checking WebParts";
        private const string CheckingEventHandlers = "Checking Event Handlers";
        private const string CheckingItems = "Checking Items";
        private const string CheckingProperties = "Checking Properties";
        private const string CheckingFiles = "Checking Files";
        private const string CheckingNavigation = "Checking Navigation";
        private const string InstallingSolutionsAndLists = "Installing Solutions and Lists";
        private const string FieldBoolean = "FieldBoolean";
        private const string FieldCalculated = "FieldCalculated";
        private const string FieldChoice = "FieldChoice";

        private const string INavGetParentAppMethod = "iNavGetParentApp";
        private const string GetTemplateTypeMethod = "GetTemplateType";
        private const string IInstallListsAddListMethod = "iInstallListsAddList";
        private const string IInstallListFieldsAddFieldMethod = "iInstallListFieldsAddField";
        private const string IInstallListsWorkflowsInstallMethod = "iInstallListsWorkflowsInstall";
        private const string IInstallListsWorkflowsMethod = "iInstallListsWorkflows";

        [TestInitialize]
        public void TestInitialize()
        {
            _listItemUpdated = false;
            _gridGanttSettingsSaved = false;
            _folderAdded = false;
            _verifyOnly = false;
            _webFeatureAdded = false;
            _siteFeatureAdded = false;
            _fieldUpdated = false;
            _fieldBooleanUpdated = false;
            _viewFieldsAllDeleted = false;
            _viewFieldAdded = false;
            _viewUpdated = false;
            _fileAdded = false;
            _fileContentSaved = false;
            _webPartSaved = false;
            _webPartDeleted = false;
            _webPartAdded = false;
            _webPartConnected = false;
            _fileDeleted = false;
            _listItemAdded = false;
            _listBizCreated = false;
            _configSettingSet = false;
            _communityCreated = false;
            _quickLaunchAddedAsLast = false;
            _nodeChildAddedAsLast = false;
            _nodeUpdated = false;
            _topNavAddedAsLast = false;
            _quickLaunchXMLCreated = false;
            _topNavXMLCreated = false;
            _reportDataSourcesProcessed = false;
            _cacheRemoved = false;
            _storeInformationAdded = false;
            _fileDeletedFromSolution = false;
            _fileAddedToSolution = false;
            _solutionRemoved = false;
            _solutionAdded = false;
            _returnFirstList = true;
            _listAdded = false;
            _fieldAdded = false;
            _choiceUpdated = false;
            _fieldAsXmlAdded = false;
            _fileAddedToWeb = false;
            _workFlowAssociationCreated = false;

            _shimObject = ShimsContext.Create();

            var configJob = new ShimInstallAndConfigure().Instance;
            var privateConfigJob = new PrivateObject(configJob);
            privateConfigJob.SetFieldOrProperty("userid", DummyInt);

            _testObj = new ApplicationInstaller(DummyString, new ShimSqlConnection().Instance, configJob);
            _privateObj = new PrivateObject(_testObj);

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            var listItem = new ShimSPListItem
            {
                ItemGetString = item =>
                {
                    switch (item)
                    {
                        case "InstallXML":
                            return CreateXmlApplication();
                        case "AppUrl":
                            return DummyUrl;
                        case "Status":
                            return _verifyOnly ? "PreCheck Queued" : "Install Queued";
                        default:
                            return DummyString;
                    }
                },
                Update = () => _listItemUpdated = true,
                ParentListGet = () => _list
            }.Instance;

            _privateObj.SetFieldOrProperty("oListItem", listItem);

            var count = 0;
            var fieldList = new List<string>();
            _list = new ShimSPList
            {
                TitleGet = () => DummyString,
                GetItemsSPQuery = _ =>
                {
                    count++;
                    if (count > 1 || _returnFirstList) {
                        return new ShimSPListItemCollection
                        {
                            ItemGetInt32 = __ => listItem
                        }.Bind(new SPListItem[]
                        {
                            listItem
                        });
                    }

                    return new ShimSPListItemCollection();
                },
                ParentWebGet = () => _web,
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name =>
                    {
                        switch (name)
                        {
                            case LookupField:
                                return new ShimSPFieldLookup().Instance;
                            case DummyString:
                                return new ShimSPField
                                {
                                    TypeAsStringGet = () => DummyString
                                }.Instance;
                            default:
                                if (!fieldList.Contains(name))
                                {
                                    fieldList.Add(name);
                                    return null;
                                }

                                return VerifyField(name);
                        }
                    },
                    AddStringSPFieldTypeBoolean = (name, __, ___) =>
                    {
                        _fieldAdded = true;

                        return name;
                    },
                    AddFieldAsXmlString = _ =>
                    {
                        _fieldAsXmlAdded = true;

                        return DummyString;
                    }
                },
                ViewsGet = () => new ShimSPViewCollection
                {
                    ItemGetString = _ => new ShimSPView
                    {
                        ViewFieldsGet = () => new ShimSPViewFieldCollection
                        {
                            DeleteAll = () => _viewFieldsAllDeleted = true,
                            AddSPField = __ => _viewFieldAdded = true
                        },
                        Update = () => _viewUpdated = true
                    }
                }.Bind(new SPView[]
                {
                    new ShimSPView
                    {
                        PersonalViewGet = () => false,
                        TitleGet = () => DummyView,
                        UrlGet = () => DummyString,
                        ParentListGet = () => _list
                    }
                }),
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection().Bind(new SPEventReceiverDefinition[] 
                {
                    new ShimSPEventReceiverDefinition
                    {
                        TypeGet = () => SPEventReceiverType.ItemAdding,
                        AssemblyGet = () => DummyString,
                        ClassGet = () => DummyClass
                    }
                }),
                ItemsGet = () => new ShimSPListItemCollection
                {
                    Add = () =>
                    {
                        _listItemAdded = true;

                        return listItem;
                    }
                },
                GetItemByIdInt32 = _ => listItem
            };

            ShimSPField.AllInstances.TypeGet = field =>
            {
                if (field is SPFieldLookup)
                {
                    return SPFieldType.Lookup;
                }

                switch (field.InternalName)
                {
                    case FieldBoolean:
                        return SPFieldType.Boolean;
                    case FieldCalculated:
                        return SPFieldType.Calculated;
                    case FieldChoice:
                        return SPFieldType.Choice;
                    default:
                        return SPFieldType.Text;
                }
            };
            ShimSPField.AllInstances.SealedGet = _ => true;
            ShimSPField.AllInstances.Update = _ => _fieldUpdated = true;
            ShimSPField.AllInstances.UpdateBoolean = (_, __) => _fieldBooleanUpdated = true;
            ShimSPField.AllInstances.SchemaXmlGet = _ => CreateFieldXml();
            ShimSPField.AllInstances.InternalNameGet = field =>
            {
                if (field is SPFieldCalculated)
                {
                    return FieldCalculated;
                }
                if (field is SPFieldChoice)
                {
                    return FieldChoice;
                }

                return DummyString;
            };

            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection();
            ShimSPFieldMultiChoice.AllInstances.Update = _ => _choiceUpdated = true;

            var countFolderExists = 0;
            _web = new ShimSPWeb
            {
                SiteGet = () => _site,
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => _list,
                    AddStringStringSPListTemplate = (_, __, ___) =>
                    {
                        _listAdded = true;

                        return Guid.NewGuid();
                    },
                    ItemGetGuid = _ => _list
                },
                AllUsersGet = () => new ShimSPUserCollection
                {
                    GetByIDInt32 = _ => new ShimSPUser
                    {
                        UserTokenGet = () => new ShimSPUserToken(),
                        IsSiteAdminGet = () => true
                    }
                },
                GetFileString = _ => new ShimSPFile
                {
                    ExistsGet = () => true,
                    GetLimitedWebPartManagerPersonalizationScope = __ => new ShimSPLimitedWebPartManager
                    {
                        Dispose = () => { },
                        WebPartsGet = () => new ShimSPLimitedWebPartCollection().Bind(new WebPart[] 
                        {
                            new ShimXsltListViewWebPart(),
                            new ShimReportingFilter()
                        }),
                        SaveChangesWebPart = ___ => _webPartSaved = true,
                        DeleteWebPartWebPart = ___ => _webPartDeleted = true,
                        AddWebPartWebPartStringInt32 = (_1, _2, _3) => _webPartAdded = true,
                        GetProviderConnectionPointsWebPart = ___ => new ShimProviderConnectionPointCollection()
                        .Bind(new ProviderConnectionPoint[]
                        {
                            new ShimProviderConnectionPoint()
                        }),
                        GetConsumerConnectionPointsWebPart = ___ => new ShimConsumerConnectionPointCollection()
                        .Bind(new ConsumerConnectionPoint[]
                        {
                            new ShimConsumerConnectionPoint()
                        }),
                        SPConnectWebPartsWebPartProviderConnectionPointWebPartConsumerConnectionPoint = (_1, _2, _3, _4) =>
                        {
                            _webPartConnected = true;

                            return null;
                        },
                        WebGet = () => _web
                    },
                    Delete = () => _fileDeleted = true
                },
                GetFolderString = _ => new ShimSPFolder
                {
                    ExistsGet = () =>
                    {
                        countFolderExists++;

                        return countFolderExists > 1;
                    },
                    FilesGet = () => new ShimSPFileCollection
                    {
                        AddStringByteArrayBoolean = (_1, _2, _3) =>
                        {
                            _fileAdded = true;

                            return null;
                        }
                    }
                },
                FoldersGet = () => new ShimSPFolderCollection
                {
                    AddString = _ =>
                    {
                        _folderAdded = true;

                        return new ShimSPFolder
                        {
                            FilesGet = () => new ShimSPFileCollection
                            {
                                AddStringByteArray = (__, ___) =>
                                {
                                    _fileAdded = true;

                                    return new ShimSPFile();
                                }
                            }
                        };
                    }
                },
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var sd = new ShimStringDictionary(propertyBag);
                    sd.ContainsKeyString = _ => true;

                    return propertyBag;
                },
                NavigationGet = () => new ShimSPNavigation
                {
                    QuickLaunchGet = () => new ShimSPNavigationNodeCollection
                    {
                        AddAsLastSPNavigationNode = _ =>
                        {
                            _quickLaunchAddedAsLast = true;

                            return null;
                        }
                    },
                    TopNavigationBarGet = () => new ShimSPNavigationNodeCollection
                    {
                        AddAsLastSPNavigationNode = _ =>
                        {
                            _topNavAddedAsLast = true;

                            return null;
                        }
                    }
                },
                ServerRelativeUrlGet = () => "/",
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    AddGuidBooleanSPFeatureDefinitionScope = (_, __, ___) =>
                    {
                        _webFeatureAdded = true;

                        return null;
                    }
                },
                FilesGet = () => new ShimSPFileCollection
                {
                    AddStringByteArrayBoolean = (_, __, ___) =>
                    {
                        _fileAddedToWeb = true;

                        return null;
                    }
                },
                WorkflowTemplatesGet = () => new ShimSPWorkflowTemplateCollection().Bind(new SPWorkflowTemplate[]
                {
                    new ShimSPWorkflowTemplate
                    {
                        NameGet = () => DummyString
                    }
                })
            };

            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid(),
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    AddGuidBooleanSPFeatureDefinitionScope = (_, __, ___) =>
                    {
                        _siteFeatureAdded = true;

                        return null;
                    }
                },
                RootWebGet = () => _web,
                GetCatalogSPListTemplateType = _ => new ShimSPDocumentLibrary().Instance,
                SolutionsGet = () => new ShimSPUserSolutionCollection
                {
                    AddInt32 = _ =>
                    {
                        _solutionAdded = true;

                        return new ShimSPUserSolution();
                    },
                    RemoveSPUserSolution = _ => _solutionRemoved = true
                }.Bind(new SPUserSolution[]
                {
                    new ShimSPUserSolution
                    {
                        NameGet = () => DummyString
                    }
                }),
                GetCustomListTemplatesSPWeb = _ => new ShimSPListTemplateCollection().Bind(new SPListTemplate[]
                {
                    new ShimSPListTemplate
                    {
                        InternalNameGet = () => DummyString
                    }
                })
            };

            var appDef = new ApplicationDef
            {
                Id = DummyInt,
                Community = DummyString,
                Icon = DummyString
            };
            appDef.PreReqs.Add(DummyString, DummyString);
            appDef.ApplicationXml.LoadXml(CreateXmlApplication());

            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder
            {
                FilesGet = () => new ShimSPFileCollection
                {
                    AddStringByteArray = (__, ___) =>
                    {
                        _fileAddedToSolution = true;

                        return new ShimSPFile
                        {
                            ItemGet = () => listItem
                        };
                    }
                }.Bind(new SPFile[]
                {
                    new ShimSPFile
                    {
                        NameGet = () => DummyString,
                        Delete = () => _fileDeletedFromSolution = true
                    }
                })
            };


            ShimApplications.GetApplicationInfoString = _ => appDef;
            ShimApplications.CreateCommunityStringSPWeb = (_, __) =>
            {
                _communityCreated = true;

                return DummyInt;
            };
            ShimApplications.CreateQuickLaunchXMLInt32SPWeb = (_, __) => _quickLaunchXMLCreated = true;
            ShimApplications.CreateTopNavXMLInt32SPWeb = (_, __) => _topNavXMLCreated = true;
            ShimApplications.GetApplicationListSPWeb = _ => _list;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => _web;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.FeatureDefinitionsGet = _ => new ShimSPFeatureDefinitionCollection().Bind(new SPFeatureDefinition[]
            {
                new ShimSPFeatureDefinition
                {
                    IdGet = () => new Guid(Feature3Id),
                    CompatibilityLevelGet = () => CompatibilityLevel14,
                    DisplayNameGet = () => Feature3,
                    ScopeGet = () => SPFeatureScope.Site
                },
                new ShimSPFeatureDefinition
                {
                    IdGet = () => new Guid(Feature4Id),
                    CompatibilityLevelGet = () => CompatibilityLevel15,
                    DisplayNameGet = () => Feature4,
                    ScopeGet = () => SPFeatureScope.Site
                }
            });
            ShimSPSite.AllInstances.RootWebGet = _ => _web;
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPWorkflowAssociation.CreateListAssociationSPWorkflowTemplateStringSPListSPList = (_1, _2, _3, _4) =>
            {
                _workFlowAssociationCreated = true;

                return null;
            };

            ShimSPPersistedObject.AllInstances.FarmGet = _ => new ShimSPFarm
            {
                FeatureDefinitionsGet = () => new ShimSPFeatureDefinitionCollection().Bind(new SPFeatureDefinition[]
                {
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid(Feature1Id),
                        CompatibilityLevelGet = () => CompatibilityLevel14,
                        DisplayNameGet = () => Feature1,
                        ScopeGet = () => SPFeatureScope.Web
                    },
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid(Feature2Id),
                        CompatibilityLevelGet = () => CompatibilityLevel15,
                        DisplayNameGet = () => Feature2,
                        ScopeGet = () => SPFeatureScope.Web
                    }
                })
            };

            ShimSPQuery.Constructor = _ => { };

            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyString;

            ShimSPNavigationNode.ConstructorStringStringBoolean = (_, _1, _2, _3) => { };
            ShimSPNavigationNode.AllInstances.ChildrenGet = _ => new ShimSPNavigationNodeCollection
            {
                AddAsLastSPNavigationNode = __ =>
                {
                    _nodeChildAddedAsLast = true;

                    return null;
                }
            };
            ShimSPNavigationNode.AllInstances.Update = _ => _nodeUpdated = true;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => _site
            };

            ShimCoreFunctions.getFarmSettingString = _ => DummyUrl;
            ShimCoreFunctions.getFeatureNameString = _ => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (setting, __) =>
            {
                if (setting == "GeneralSettings")
                {
                    return $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{DummyString}";
                }

                return $"{DummyString}1";
            };
            ShimCoreFunctions.GetStoreCreds = () => new ShimNetworkCredential();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) =>
            {
                if (setting == "reportingV2")
                {
                    return "true";
                }

                return DummyString;
            };
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => _configSettingSet = true;

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 0;
            ShimAct.AllInstances.IsOnlineGet = _ => true;

            ShimGridGanttSettings.AllInstances.SaveSettingsSPList = (_, __) => _gridGanttSettingsSaved = true;

            ShimAppStore.Constructor = _ => { };
            ShimAppStore.AllInstances.GetFileString = (_, __) => new byte[] { };

            ShimReportingAppStore.Constructor = _ => { };
            ShimReportingAppStore.AllInstances.AddStoreInformationString = (_, __) =>
            {
                _storeInformationAdded = true;

                return DummyString;
            };

            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString =
                (_, _1, _2, _3, _4, _5, _6, _7) => CreateXmlNode();

            ShimPath.GetFileNameString = name => name;
            ShimPath.GetExtensionString = _ => ".txt";
            ShimPath.GetDirectoryNameString = name => name;

            ShimExtensionMethods.GetContentsSPFile = _ => DummyString;
            ShimExtensionMethods.UpdateContentsAndSaveSPFileString = (_, __) => _fileContentSaved = true;

            ShimConnectionPoint.AllInstances.InterfaceTypeGet = _ => typeof(IReportID);

            ShimReportBiz.ConstructorGuidGuidBoolean = (_, _1, _2, _3) => { };
            ShimReportBiz.AllInstances.GetListBizGuid = (_, __) => new ShimListBiz();
            ShimReportBiz.AllInstances.CreateListBizGuid = (_, __) =>
            {
                _listBizCreated = true;

                return new ShimListBiz();
            };

            ShimReporting.ProcessReportDataSourcesSPWebString = (_, __) => _reportDataSourcesProcessed = true;

            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveSafelyStringStringString = (_, __, ___) => _cacheRemoved = true
            };

            ShimCacheStoreCategory.ConstructorSPWeb = (_, __) => { };
            ShimCacheStoreCategory.AllInstances.NavigationGet = _ => DummyString;

            ShimWebClient.Constructor = _ => { };
            ShimWebClient.AllInstances.DownloadDataString = (_, __) => new byte[] { };
        }

        private SPField VerifyField(string fieldName)
        {
            switch (fieldName)
            {
                case FieldCalculated:
                    return new ShimSPFieldCalculated().Instance;
                case FieldChoice:
                    return new ShimSPFieldChoice().Instance;
                default:
                    return new ShimSPField
                    {
                        InternalNameGet = () => fieldName
                    }.Instance;
            }
        }

        private string CreateFieldXml()
        {
            return "<Field List='' ShowField=''></Field>";
        }

        private string CreateXmlApplication()
        {
            return $@"<Root>
                        <Application RequiredFeatureKeys='{DummyInt}' ProcessReports='true'>
                            <Description>{DummyString}</Description>
                            <QuickLaunch>
                                <Item Name='{DummyString}' Url='{DummyString}'>
                                    <Item Name='{DummyString}' Url='{DummyString}'></Item>
                                </Item>
                            </QuickLaunch>
                            <TopNav>
                                <Item Name='{DummyString}' Url='{DummyString}'>
                                    <Item Name='{DummyString}' Url='{DummyString}'></Item>
                                </Item>
                            </TopNav>
                        </Application>
                        <Features>
                            <Feature ID='{Feature1Id}' Name='{DummyString}'></Feature>
                            <Feature ID='{Feature2Id}' Name='{DummyString}'></Feature>
                            <Feature ID='{Feature3Id}' Name='{DummyString}'></Feature>
                            <Feature ID='{Feature4Id}' Name='{DummyString}'></Feature>
                        </Features>
                        <Lists>
                            <List Name='{DummyString}' CanUpgrade='true' Reporting='true'>
                                <Fields>
                                    <Field InternalName='{DummyString}' Overwrite='true' Total='{DummyInt}'>
                                        <Field Type='{DummyString}' DisplayName='{DummyString}' ShowField='true'></Field>
                                    </Field>
                                    <Field InternalName='{FieldBoolean}' Overwrite='true'>
                                        <Field Type='Boolean'></Field>
                                    </Field>
                                    <Field InternalName='{FieldCalculated}' Overwrite='true'>
                                        <Field Type='Calculated'>
                                            <FormulaDisplayNames>{DummyString}</FormulaDisplayNames>
                                        </Field>
                                    </Field>
                                    <Field InternalName='{FieldChoice}' Overwrite='true' Total='{DummyInt}'>
                                        <Field Type='Choice' ShowInEditForm='true' ShowInNewForm='true' ShowInDisplayForm='true' DisplayName='{DummyString}' FillInChoice='true'>
                                            <CHOICES>
                                                <CHOICE>{DummyString}</CHOICE>
                                            </CHOICES>
                                        </Field>
                                    </Field>
                                </Fields>
                                <Lookups>
                                    <Lookup InternalName='{LookupField}' List='{DummyString}' Field='{DummyString}' DisplayName='{DummyString}' AdvancedLookup='{DummyString}' Overwrite='true'></Lookup>
                                </Lookups>
                                <Views InstallGridOnAllViews='true'>
                                    <View Name='{DummyView}' Overwrite='true' RowLimit='{DummyInt}' MakeDefault='true'>
                                        <Fields>{DummyString}</Fields>
                                        <Query>{DummyString}</Query>
                                        <ProjectedFields>{DummyString}</ProjectedFields>
                                        <Joins>{DummyString}</Joins>
                                    </View>
                                </Views>
                                <Workflows>
                                    <Workflow Name='{DummyWorkflow}' Overwrite='true'></Workflow>
                                </Workflows>
                                <EventHandlers>
                                    <EventHandler Type='{ItemAdding}' Class='{DummyClass}' Assembly='{DummyString}'></EventHandler>
                                </EventHandlers>
                                <Items>
                                    <Item>
                                        <Field Name='{DummyString}'>{ItemTitle}</Field>
                                        <Field Name='Title'></Field>
                                    </Item>
                                </Items>
                            </List>
                        </Lists>
                        <Web>
                            <Properties>
                                <Property Name='{DummyString}' Value='{DummyString}' Append='true' Overwrite='true' Seperator=';'></Property>
                            </Properties>
                        </Web>
                        <Files>
                            <File Path='{DummyString}/{DummyString}.txt' Overwrite='true' NoDelete='false'></File>
                        </Files>
                        <Solutions>
                            <Solution FileName='{DummyString}' Overwrite='true'></Solution>
                            <ListTemplate FileName='{DummyString}' Overwrite='true'></ListTemplate>
                        </Solutions>
                      </Root>";
        }

        private XmlNode CreateXmlNode()
        {
            var xmlString = $@"<xml xmlns:rs='urn:schemas-microsoft-com:rowset' xmlns:z='#RowsetSchema'>
                                 <rs:data ItemCount='{DummyInt}'>
                                     <z:row ows_Title='{DummyString}.txt' ows_FSObjType='{DummyString}' ows_FileRef='{DummyString}' ows_FileLeafRef='{DummyString}'/>
                                 </rs:data>
                               </xml>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument.SelectSingleNode("/xml");
        }

        [TestMethod]
        public void InstallAndConfigureApp_WhenVerifyOnly_ConfirmResult()
        {
            // Arrange
            var iInstallListsWorkflowsCalled = false;
            _verifyOnly = true;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimApplicationInstaller.AllInstances.iInstallListsWorkflowsSPListXmlNodeInt32Boolean = 
                (_, _1, _2, _3, _4) => iInstallListsWorkflowsCalled = true;

            // Act
            _testObj.InstallAndConfigureApp(_verifyOnly, _web.Instance, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testObj.DtMessages.Rows.Count.ShouldBe(45),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ApplicationInstall),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ApplicatinAlreadyInstalled),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(PermissionsCheck),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ApplicationList),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(PreRequisiteCheck),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ActivationKeyCheck),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallVersion),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingFeatures),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature1),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature2),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature3),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature4),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingLists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ListExists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingFields),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldBoolean),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldCalculated),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldChoice),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldExists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingLookups),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldExists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(EnabledAdvancedLookup),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingViews),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ViewExists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingWebParts),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(GridOnAllViews),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(DummyView),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingEventHandlers),
                () => _testObj.XmlMessages.OuterXml.ShouldContain($"{ItemAdding}({DummyClass})"),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingItems),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ItemTitle),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(AddToReportingDatabase),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingProperties),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(PropertyFound),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingFiles),
                () => _testObj.XmlMessages.OuterXml.ShouldContain($"File: {DummyString}.txt"),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CheckingNavigation),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(QuickLaunch),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(TopNav),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ProcessingReports),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _folderAdded.ShouldBeTrue(),
                () => iInstallListsWorkflowsCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void InstallAndConfigureApp_WhenNotVerifyOnly_ConfirmResult()
        {
            // Arrange
            var iInstallListsWorkflowsCalled = false;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimApplicationInstaller.AllInstances.iInstallListsWorkflowsSPListXmlNodeInt32Boolean =
                (_, _1, _2, _3, _4) => iInstallListsWorkflowsCalled = true;

            _returnFirstList = false;

            // Act
            _testObj.InstallAndConfigureApp(_verifyOnly, _web.Instance, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listItemUpdated.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _folderAdded.ShouldBeTrue(),
                () => _fileDeletedFromSolution.ShouldBeTrue(),
                () => _fileAddedToSolution.ShouldBeTrue(),
                () => _solutionRemoved.ShouldBeTrue(),
                () => _solutionAdded.ShouldBeTrue(),
                () => iInstallListsWorkflowsCalled.ShouldBeTrue(),
                () => _webFeatureAdded.ShouldBeTrue(),
                () => _siteFeatureAdded.ShouldBeTrue(),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _choiceUpdated.ShouldBeTrue(),
                () => _fieldBooleanUpdated.ShouldBeTrue(),
                () => _viewFieldsAllDeleted.ShouldBeTrue(),
                () => _viewFieldAdded.ShouldBeTrue(),
                () => _viewUpdated.ShouldBeTrue(),
                () => _fileAdded.ShouldBeTrue(),
                () => _fileAddedToWeb.ShouldBeTrue(),
                () => _fileContentSaved.ShouldBeTrue(),
                () => _webPartSaved.ShouldBeTrue(),
                () => _webPartDeleted.ShouldBeTrue(),
                () => _webPartAdded.ShouldBeTrue(),
                () => _webPartConnected.ShouldBeTrue(),
                () => _fileDeleted.ShouldBeTrue(),
                () => _listItemAdded.ShouldBeTrue(),
                () => _fieldAdded.ShouldBeTrue(),
                () => _listBizCreated.ShouldBeTrue(),
                () => _configSettingSet.ShouldBeTrue(),
                () => _communityCreated.ShouldBeTrue(),
                () => _quickLaunchAddedAsLast.ShouldBeTrue(),
                () => _nodeChildAddedAsLast.ShouldBeTrue(),
                () => _nodeUpdated.ShouldBeTrue(),
                () => _topNavAddedAsLast.ShouldBeTrue(),
                () => _quickLaunchXMLCreated.ShouldBeTrue(),
                () => _topNavXMLCreated.ShouldBeTrue(),
                () => _reportDataSourcesProcessed.ShouldBeTrue(),
                () => _cacheRemoved.ShouldBeTrue(),
                () => _storeInformationAdded.ShouldBeTrue(),
                () => _testObj.DtMessages.Rows.Count.ShouldBe(48),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(PermissionsCheck),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ApplicationList),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(PreRequisiteCheck),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ActivationKeyCheck),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallVersion),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingSolutionsAndLists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingFeatures),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature1),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature2),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature3),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(Feature4),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingLists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ListExists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(UpdatingFields),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldBoolean),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldCalculated),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldChoice),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldUpdated),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FixingLookups),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(FieldUpdated),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(EnabledAdvancedLookup),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(UpdatingViews),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ViewExists),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(UpdatingWebParts),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(GridOnAllViews),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(DummyView),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingEventHandlers),
                () => _testObj.XmlMessages.OuterXml.ShouldContain($"{ItemAdding}({DummyClass})"),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingItems),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ItemTitle),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(AddToReportingDatabase),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingProperties),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(PropertyFound),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingFiles),
                () => _testObj.XmlMessages.OuterXml.ShouldContain($"File: {DummyString}.txt"),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(CreatingCommunity),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(InstallingNavigation),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(QuickLaunch),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(TopNav),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(ProcessingReports));
        }

        [TestMethod]
        public void INavGetParentApp_OnValidCall_ConfirmResult()
        {
            // Arrange
            _privateObj.SetFieldOrProperty("oAppList", _list.Instance);

            // Act
            var result = (SPListItem)_privateObj.Invoke(INavGetParentAppMethod, DummyString);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void IInstallListsAddList_OnValidCall_ConfirmResult()
        {
            // Arrage
            var error = string.Empty;
            var xmlString = $"<List Name='{DummyString}' FileName='{DummyString}' Template='{DummyString}' Description='{DummyString}'></List>";
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            var node = xmlDocument.SelectSingleNode("/List");

            _privateObj.SetFieldOrProperty(OWebField, _web.Instance);

            // Act
            var result = (SPList)_privateObj.Invoke(IInstallListsAddListMethod, node, error);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listAdded.ShouldBeTrue(),
                () => result.ShouldNotBeNull());
        }

        [TestMethod]
        public void IInstallListsWorkflowsInstall_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = "<Workflow AllowManual='true' StartOnCreate='true' StartOnChange='true'></Workflow>";
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            var node = xmlDocument.SelectSingleNode("/Workflow");

            _privateObj.SetFieldOrProperty(OWebField, _web.Instance);

            // Act
            _privateObj.Invoke(
                IInstallListsWorkflowsInstallMethod, 
                _list.Instance, 
                DummyString, 
                DummyString, 
                _list.Instance, 
                _list.Instance, 
                node);

            // Assert
            _workFlowAssociationCreated.ShouldBeTrue();
        }

        [TestMethod]
        public void IInstallListsWorkflows_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = $"<Root><Workflows><Workflow Name='{DummyString}' Overwrite='true'></Workflow></Workflows></Root>";
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            var node = xmlDocument.SelectSingleNode("/Root");

            _privateObj.SetFieldOrProperty("bVerifyOnly", true);
            _privateObj.SetFieldOrProperty(OWebField, _web.Instance);

            // Act
            _privateObj.Invoke(IInstallListsWorkflowsMethod, null, node, 0, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testObj.XmlMessages.OuterXml.ShouldContain("Checking Workflows"),
                () => _testObj.XmlMessages.OuterXml.ShouldContain(DummyString));
        }
    }
}
