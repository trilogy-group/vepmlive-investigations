using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
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

        private bool _fileDeleted;
        private bool _listItemUpdated;
        private bool _listItemDeleted;
        private bool _appRemovedFromCommunity;
        private bool _communityDeleted;
        private bool _quickLaunchDeleted;
        private bool _topNavigationBarDeleted;
        private bool _listBizDeleted;
        private bool _listDeleted;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string WebId = "dbcc577c-701f-415e-b7af-391121517da6";
        private const string Feature1Guid = "bef62bdc-35f6-4e42-b8ac-735e3b5be516";
        private const string Feature2Guid = "d56a106c-f833-4437-be12-129ea71dfd45";
        private const string Feature3Guid = "005aed9a-7b82-46b5-b3fd-8e8d85240487";
        private const string Feature4Guid = "54f10d47-074e-4895-b205-43b477f613e6";

        [TestInitialize]
        public void TestInitialize()
        {
            _fileDeleted = false;
            _listItemUpdated = false;
            _listItemDeleted = false;
            _appRemovedFromCommunity = false;
            _communityDeleted = false;
            _quickLaunchDeleted = false;
            _topNavigationBarDeleted = false;
            _listBizDeleted = false;
            _listDeleted = false;

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
            _privateConfigJob.SetFieldOrProperty("userid", DummyInt);

            var spUser = new ShimSPUser
            {
                UserTokenGet = () => new ShimSPUserToken()
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
                        default:
                            return DummyString;
                    }
                },
                Update = () => _listItemUpdated = true,
                Delete = () => _listItemDeleted = true
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
                Delete = () => _listDeleted = true
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
                    TryGetListString = _ => _list
                },
                FilesGet = () => new ShimSPFileCollection
                {
                    DeleteString = _ => _fileDeleted = true
                },
                NavigationGet = () => new ShimSPNavigation
                {
                    QuickLaunchGet = () => new ShimSPNavigationNodeCollection().Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt,
                            TitleGet = () => DummyString,
                            Delete = () => _quickLaunchDeleted = true
                        }
                    }),
                    TopNavigationBarGet = () => new ShimSPNavigationNodeCollection().Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            IdGet = () => DummyInt,
                            TitleGet = () => DummyString,
                            Delete = () => _topNavigationBarDeleted = true
                        }
                    })
                }
            };

            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid()
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
                        ScopeGet = () => SPFeatureScope.Farm
                    },
                    new ShimSPFeatureDefinition
                    {
                        IdGet = () => new Guid(Feature4Guid),
                        DisplayNameGet = () => DummyString,
                        CompatibilityLevelGet = () => 15,
                        ScopeGet = () => SPFeatureScope.Farm
                    }
                })
            };

            ShimSPSiteDataQuery.Constructor = _ => { };

            ShimSPQuery.Constructor = _ => { };

            ShimApplications.GetApplicationInfoFromListSPWebString = (_, __) => new ApplicationDef
            {
                Id = DummyInt,
                ApplicationXml = CreateXmlDocument()
            };
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
        }

        private XmlDocument CreateXmlDocument()
        {
            var xmlString = $@"
                <Root>
                    <Application></Application>
                    <Lists>
                        <List Name='{DummyString}' Reporting='true' NoDelete='false'></List>
                    </Lists>
                    <Features>
                        <Feature ID='{Feature1Guid}' Name='{DummyString}' NoDelete='false'></Feature>
                        <Feature ID='{Feature2Guid}' Name='{DummyString}' NoDelete='false'></Feature>
                        <Feature ID='{Feature3Guid}' Name='{DummyString}' NoDelete='false'></Feature>
                        <Feature ID='{Feature4Guid}' Name='{DummyString}' NoDelete='false'></Feature>
                    </Features>
                    <Web>
                        <Properties>
                            <Property Name='{DummyString}' Value='{DummyString}' Append='true' Overwrite='true' LockWebProperty='true'></Property>
                        </Properties>
                    </Web>
                </Root>";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            return xmlDocument;
        }

        private DataTable CreateSiteDataTable(string webId)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("WebId");

            var dataRow = dataTable.NewRow();
            dataRow["WebId"] = new Guid(webId);

            dataTable.Rows.Add(dataRow);

            return dataTable;
        }

        [TestMethod]
        public void UninstallApp_WhenIsInstalledElsewhereAndUserHasPermissionAndRootWeb_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();
            ShimSPWeb.AllInstances.GetSiteDataSPSiteDataQuery = (_, __) => CreateSiteDataTable(guid);
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPWeb.AllInstances.IsRootWebGet = _ => true;

            // Act
            _testObj.UninstallApp(false, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _fileDeleted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _appRemovedFromCommunity.ShouldBeTrue(),
                () => _communityDeleted.ShouldBeTrue(),
                () => _quickLaunchDeleted.ShouldBeTrue(),
                () => _topNavigationBarDeleted.ShouldBeTrue(),
                () => _listBizDeleted.ShouldBeTrue(),
                () => _listDeleted.ShouldBeTrue());
        }
    }
}