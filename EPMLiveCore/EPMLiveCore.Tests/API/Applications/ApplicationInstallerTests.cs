using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Fakes;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.ApplicationStore.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.Applications.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
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
                            case "LookupField":
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
                        TitleGet = () => "DummyView",
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
                }
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
                    IdGet = () => new Guid("be2146f3-3784-448d-bb2d-2f75bdab8ece"),
                    CompatibilityLevelGet = () => 14,
                    DisplayNameGet = () => "Feature3",
                    ScopeGet = () => SPFeatureScope.Site
                },
                new ShimSPFeatureDefinition
                {
                    IdGet = () => new Guid("8cd7059a-a484-43ef-b85b-72cad1bbbeb2"),
                    CompatibilityLevelGet = () => 15,
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
                        IdGet = () => new Guid("ec2b8995-6ee8-4502-8900-a8f7536f8521"),
                        CompatibilityLevelGet = () => 14,
                        DisplayNameGet = () => "Feature1",
                        ScopeGet = () => SPFeatureScope.Web
                    },
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid("06bdb63c-9f9d-46de-946c-0f4f445ba2ed"),
                        CompatibilityLevelGet = () => 15,
                        DisplayNameGet = () => "Feature2",
                        ScopeGet = () => SPFeatureScope.Web
                    }
                })
            };

            ShimSPQuery.Constructor = _ => { };

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

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 0;

            ShimGridGanttSettings.AllInstances.SaveSettingsSPList = (_, __) => _gridGanttSettingsSaved = true;

            ShimAppStore.Constructor = _ => { };
            ShimAppStore.AllInstances.GetFileString = (_, __) => new byte[] { };
        }

        private string CreateXmlApplication()
        {
            return $@"<Root>
                        <Application RequiredFeatureKeys='{DummyInt}'>
                            <Description>{DummyString}</Description>
                        </Application>
                        <Features>
                            <Feature ID='ec2b8995-6ee8-4502-8900-a8f7536f8521' Name='{DummyString}'></Feature>
                            <Feature ID='06bdb63c-9f9d-46de-946c-0f4f445ba2ed' Name='{DummyString}'></Feature>
                            <Feature ID='be2146f3-3784-448d-bb2d-2f75bdab8ece' Name='{DummyString}'></Feature>
                            <Feature ID='8cd7059a-a484-43ef-b85b-72cad1bbbeb2' Name='{DummyString}'></Feature>
                        </Features>
                        <Lists>
                            <List Name='{DummyString}' CanUpgrade='true' Reporting='true'>
                                <Fields>
                                    <Field InternalName='{DummyString}' Overwrite='true' Total='{DummyInt}'>
                                        <Field Type='{DummyString}'></Field>
                                    </Field>
                                </Fields>
                                <Lookups>
                                    <Lookup InternalName='LookupField' List='{DummyString}' Field='{DummyString}' DisplayName='{DummyString}' AdvancedLookup='{DummyString}' Overwrite='true'></Lookup>
                                </Lookups>
                                <Views InstallGridOnAllViews='true'>
                                    <View Name='DummyView' Overwrite='true'></View>
                                </Views>
                                <Workflows>
                                    <Workflow Name='DummyWorkflow' Overwrite='true'></Workflow>
                                </Workflows>
                                <EventHandlers>
                                    <EventHandler Type='ItemAdding' Class='DummyClass' Assembly='{DummyString}'></EventHandler>
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
                                <Property Name='{DummyString}'></Property>
                            </Properties>
                        </Web>
                      </Root>";
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
                () => _testObj.DtMessages.Rows.Count.ShouldBe(34),
                () => _testObj.DtMessages.Rows[0]["Message"].ShouldBe("Application Install"),
                () => _testObj.DtMessages.Rows[0]["Details"].ShouldBe("Application is already installed in site collection and will configure."),
                () => _testObj.DtMessages.Rows[1]["Message"].ShouldBe("Permissions Check"),
                () => _testObj.DtMessages.Rows[2]["Message"].ShouldBe("Application List"),
                () => _testObj.DtMessages.Rows[3]["Message"].ShouldBe("Pre Requisite Check"),
                () => _testObj.DtMessages.Rows[4]["Message"].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[5]["Message"].ShouldBe("Activation Key Check"),
                () => _testObj.DtMessages.Rows[6]["Message"].ShouldBe(DummyString),
                () => _testObj.DtMessages.Rows[7]["Message"].ShouldBe("Install Version"),
                () => _testObj.DtMessages.Rows[8]["Message"].ShouldBe("Checking Features"),
                () => _testObj.DtMessages.Rows[9]["Message"].ShouldBe("Feature1"),
                () => _testObj.DtMessages.Rows[10]["Message"].ShouldBe("Feature2"),
                () => _testObj.DtMessages.Rows[11]["Message"].ShouldBe("Feature3"),
                () => _testObj.DtMessages.Rows[12]["Message"].ShouldBe("Feature4"),
                () => _testObj.DtMessages.Rows[13]["Message"].ShouldBe("Checking Lists"),
                () => _testObj.DtMessages.Rows[14]["Details"].ShouldBe("List exists and will upgrade"),
                () => _testObj.DtMessages.Rows[15]["Message"].ShouldBe("Checking Fields"),
                () => _testObj.DtMessages.Rows[16]["Details"].ShouldBe("Field exists and will overwrite"),
                () => _testObj.DtMessages.Rows[17]["Message"].ShouldBe("Checking Lookups"),
                () => _testObj.DtMessages.Rows[18]["Details"].ShouldBe("Field exists and will overwrite"),
                () => _testObj.DtMessages.Rows[19]["Message"].ShouldBe("Enabled Advanced Lookup"),
                () => _testObj.DtMessages.Rows[20]["Message"].ShouldBe("Checking Views"),
                () => _testObj.DtMessages.Rows[21]["Details"].ShouldBe("View exists and will overwrite"),
                () => _testObj.DtMessages.Rows[22]["Message"].ShouldBe("Checking WebParts"),
                () => _testObj.DtMessages.Rows[23]["Message"].ShouldBe("Grid on All Views"),
                () => _testObj.DtMessages.Rows[24]["Message"].ShouldBe("DummyView"),
                () => _testObj.DtMessages.Rows[25]["Message"].ShouldBe("Checking Event Handlers"),
                () => _testObj.DtMessages.Rows[26]["Message"].ShouldBe("ItemAdding(DummyClass)"),
                () => _testObj.DtMessages.Rows[27]["Message"].ShouldBe("Checking Items"),
                () => _testObj.DtMessages.Rows[28]["Message"].ShouldBe("Item Title"),
                () => _testObj.DtMessages.Rows[29]["Message"].ShouldBe("Add to Reporting Database"),
                () => _testObj.DtMessages.Rows[30]["Message"].ShouldBe("Checking Properties"),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _gridGanttSettingsSaved.ShouldBeTrue(),
                () => _folderAdded.ShouldBeTrue(),
                () => iInstallListsWorkflowsCalled.ShouldBeTrue());
        }
    }
}
