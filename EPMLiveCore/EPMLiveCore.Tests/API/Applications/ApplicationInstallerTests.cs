using System;
using System.Collections.Specialized.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Net.Fakes;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.ApplicationStore.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.Applications.Fakes;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EPMLiveCore.Tests.API.Applications
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ApplicationInstallerTests
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

        [TestInitialize]
        public void TestInitialize()
        {
            _listItemUpdated = false;
            _gridGanttSettingsSaved = false;
            _folderAdded = false;

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
                            return "PreCheck Queued";
                        default:
                            return DummyString;
                    }
                },
                Update = () => _listItemUpdated = true,
                ParentListGet = () => _list
            }.Instance;

            _privateObj.SetFieldOrProperty("oListItem", listItem);

            var wfAssociationCollection = new Mock<SPWorkflowAssociationCollection>(MockBehavior.Loose, null);

            _list = new ShimSPList
            {
                TitleGet = () => DummyString,
                GetItemsSPQuery = _ => new ShimSPListItemCollection
                {
                    ItemGetInt32 = __ => listItem
                }.Bind(new SPListItem[]
                {
                    listItem
                }),
                ParentWebGet = () => _web,
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name =>
                    {
                        switch (name)
                        {
                            case LookupField:
                                return new ShimSPFieldLookup().Instance;
                            default:
                                return new ShimSPField
                                {
                                    TypeAsStringGet = () => DummyString
                                }.Instance;
                        }
                    }
                },
                ViewsGet = () => new ShimSPViewCollection
                {
                    ItemGetString = _ => new ShimSPView()
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
                WorkflowAssociationsGet = () => wfAssociationCollection.Object
            };

            ShimSPField.AllInstances.TypeGet = field =>
            {
                if (field is SPFieldLookup)
                {
                    return SPFieldType.Lookup;
                }

                return SPFieldType.Text;
            };

            _web = new ShimSPWeb
            {
                SiteGet = () => _site,
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => _list
                },
                AllUsersGet = () => new ShimSPUserCollection
                {
                    GetByIDInt32 = _ => new ShimSPUser
                    {
                        UserTokenGet = () => new ShimSPUserToken()
                    }
                },
                GetFileString = _ => new ShimSPFile
                {
                    ExistsGet = () => true
                },
                GetFolderString = _ => new ShimSPFolder
                {
                    ExistsGet = () => false
                },
                FoldersGet = () => new ShimSPFolderCollection
                {
                    AddString = _ =>
                    {
                        _folderAdded = true;

                        return new ShimSPFolder();
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

                    }
                },
                ServerRelativeUrlGet = () => "/"
            };

            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid()
            };

            var appDef = new ApplicationDef
            {
                Id = DummyInt
            };
            appDef.PreReqs.Add(DummyString, DummyString);

            ShimApplications.GetApplicationInfoString = _ => appDef;

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
                    DisplayNameGet = () => "Feature3",
                    ScopeGet = () => SPFeatureScope.Site
                },
                new ShimSPFeatureDefinition
                {
                    IdGet = () => new Guid(Feature4Id),
                    CompatibilityLevelGet = () => CompatibilityLevel15,
                    DisplayNameGet = () => "Feature4",
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
                        IdGet = () => new Guid(Feature1Id),
                        CompatibilityLevelGet = () => CompatibilityLevel14,
                        DisplayNameGet = () => "Feature1",
                        ScopeGet = () => SPFeatureScope.Web
                    },
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid(Feature2Id),
                        CompatibilityLevelGet = () => CompatibilityLevel15,
                        DisplayNameGet = () => "Feature2",
                        ScopeGet = () => SPFeatureScope.Web
                    }
                })
            };

            ShimSPQuery.Constructor = _ => { };

            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyString;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

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
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 0;

            ShimGridGanttSettings.AllInstances.SaveSettingsSPList = (_, __) => _gridGanttSettingsSaved = true;

            ShimAppStore.Constructor = _ => { };
            ShimAppStore.AllInstances.GetFileString = (_, __) => new byte[] { };

            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString =
                (_, _1, _2, _3, _4, _5, _6, _7) => CreateXmlNode();

            ShimPath.GetFileNameString = name => name;
            ShimPath.GetExtensionString = _ => ".txt";
            ShimPath.GetDirectoryNameString = name => name;
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
                                        <Field Type='{DummyString}'></Field>
                                    </Field>
                                </Fields>
                                <Lookups>
                                    <Lookup InternalName='{LookupField}' List='{DummyString}' Field='{DummyString}' DisplayName='{DummyString}' AdvancedLookup='{DummyString}' Overwrite='true'></Lookup>
                                </Lookups>
                                <Views InstallGridOnAllViews='true'>
                                    <View Name='{DummyView}' Overwrite='true'></View>
                                </Views>
                                <Workflows>
                                    <Workflow Name='{DummyWorkflow}' Overwrite='true'></Workflow>
                                </Workflows>
                                <EventHandlers>
                                    <EventHandler Type='ItemAdding' Class='{DummyClass}' Assembly='{DummyString}'></EventHandler>
                                </EventHandlers>
                                <Items>
                                    <Item>
                                        <Field>Item Title</Field>
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
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimApplicationInstaller.AllInstances.iInstallListsWorkflowsSPListXmlNodeInt32Boolean = 
                (_, _1, _2, _3, _4) => iInstallListsWorkflowsCalled = true;

            // Act
            _testObj.InstallAndConfigureApp(true, _web.Instance, DummyInt);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testObj.DtMessages.Rows.Count.ShouldBe(42),
                () => _testObj.DtMessages.Rows[0][MessageField].ShouldBe("Application Install"),
                () => _testObj.DtMessages.Rows[0][DetailsField].ShouldBe("Application is already installed in site collection and will configure."),
                () => _testObj.DtMessages.Rows[1][MessageField].ShouldBe("Permissions Check"),
                () => _testObj.DtMessages.Rows[2][MessageField].ShouldBe("Application List"),
                () => _testObj.DtMessages.Rows[3][MessageField].ShouldBe("Pre Requisite Check"),
                () => _testObj.DtMessages.Rows[4][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[5][MessageField].ShouldBe("Activation Key Check"),
                () => _testObj.DtMessages.Rows[6][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[7][MessageField].ShouldBe("Install Version"),
                () => _testObj.DtMessages.Rows[8][MessageField].ShouldBe("Checking Features"),
                () => _testObj.DtMessages.Rows[9][MessageField].ShouldBe("Feature1"),
                () => _testObj.DtMessages.Rows[10][MessageField].ShouldBe("Feature2"),
                () => _testObj.DtMessages.Rows[11][MessageField].ShouldBe("Feature3"),
                () => _testObj.DtMessages.Rows[12][MessageField].ShouldBe("Feature4"),
                () => _testObj.DtMessages.Rows[13][MessageField].ShouldBe("Checking Lists"),
                () => _testObj.DtMessages.Rows[14][DetailsField].ShouldBe("List exists and will upgrade"),
                () => _testObj.DtMessages.Rows[15][MessageField].ShouldBe("Checking Fields"),
                () => _testObj.DtMessages.Rows[16][DetailsField].ShouldBe("Field exists and will overwrite"),
                () => _testObj.DtMessages.Rows[17][MessageField].ShouldBe("Checking Lookups"),
                () => _testObj.DtMessages.Rows[18][DetailsField].ShouldBe("Field exists and will overwrite"),
                () => _testObj.DtMessages.Rows[19][MessageField].ShouldBe("Enabled Advanced Lookup"),
                () => _testObj.DtMessages.Rows[20][MessageField].ShouldBe("Checking Views"),
                () => _testObj.DtMessages.Rows[21][DetailsField].ShouldBe("View exists and will overwrite"),
                () => _testObj.DtMessages.Rows[22][MessageField].ShouldBe("Checking WebParts"),
                () => _testObj.DtMessages.Rows[23][MessageField].ShouldBe("Grid on All Views"),
                () => _testObj.DtMessages.Rows[24][MessageField].ShouldBe(DummyView),
                () => _testObj.DtMessages.Rows[25][MessageField].ShouldBe("Checking Event Handlers"),
                () => _testObj.DtMessages.Rows[26][MessageField].ShouldBe($"ItemAdding({DummyClass})"),
                () => _testObj.DtMessages.Rows[27][MessageField].ShouldBe("Checking Items"),
                () => _testObj.DtMessages.Rows[28][MessageField].ShouldBe("Item Title"),
                () => _testObj.DtMessages.Rows[29][MessageField].ShouldBe("Add to Reporting Database"),
                () => _testObj.DtMessages.Rows[30][MessageField].ShouldBe("Checking Properties"),
                () => _testObj.DtMessages.Rows[31][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[31][DetailsField].ShouldBe("Property found and will append"),
                () => _testObj.DtMessages.Rows[32][MessageField].ShouldBe("Checking Files"),
                () => _testObj.DtMessages.Rows[33][MessageField].ShouldBe($"File: {DummyString}.txt"),
                () => _testObj.DtMessages.Rows[34][MessageField].ShouldBe("Checking Navigation"),
                () => _testObj.DtMessages.Rows[35][MessageField].ShouldBe("QuickLaunch"),
                () => _testObj.DtMessages.Rows[36][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[37][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[38][MessageField].ShouldBe("TopNav"),
                () => _testObj.DtMessages.Rows[39][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[40][MessageField].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[41][MessageField].ShouldBe("Processing Reports"),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _folderAdded.ShouldBeTrue(),
                () => iInstallListsWorkflowsCalled.ShouldBeTrue());
        }
    }
}
