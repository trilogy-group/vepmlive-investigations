using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ResourceGridClass = EPMLiveCore.API.ResourceGrid;
using ShimUtilities = WorkEnginePPM.Core.ResourceManagement.Fakes.ShimUtilities;

namespace EPMLiveCore.Tests.API.ResourceGrid
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourceGridTests
    {
        private IDisposable _shimObject;
        private ResourceGridClass _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private bool _itemDeleted;
        private bool _cacheRemoved;
        private bool _gridViewRemoved;
        private bool _gridViewInitialized;
        private bool _gridViewAdded;
        private bool _gridViewUpdated;

        private const int DummyInt = 1;
        private const int CultureEnUS = 1033;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string WebId = "fb46c327-ce29-4616-9ecd-a6615cfae015";
        private const string ListId = "8a64acf5-3c03-46a2-90dd-3077a9af0b48";
        private const string TrueString = "true";
        private const string GridViewId = "dv";
        private const string DeleteResourcePoolResourceTag = "<DeleteResourcePoolResource>";
        private const string ResourcePoolViewsTag = "<ResourcePoolViews>";
        private const string ResourcePoolViewsClosedTag = "<ResourcePoolViews/>";
        private const string RefreshResourcesSucess = "<RefreshResources Success=\"0\" />";
        private const string GridTag = "<Grid>";
        private const string BodyTag = "<Body>";
        private const string ResourceID = "ResourceID";
        private const string ProfilePic = "ProfilePic";
        private const string ProfilePicUrl = "/_layouts/15/epmlive/images/default-avatar.png";
        private const string IsMyResource = "IsMyResource";
        private const string ResourcePoolDataGridChangesTag = "<ResourcePoolDataGridChanges>";
        private const string IAdded = "<I Added=\"1\"";
        private const string CfgTag = "<Cfg Code=\"GTACCNPSQEBSLC\" Version=\"4.3.2.120412\" />";
        private const string ViewsTag = "<Views>";
        private const string RootTags = "<Root></Root>";

        [TestInitialize]
        public void TestInitialize()
        {
            _itemDeleted = false;
            _cacheRemoved = false;
            _gridViewRemoved = false;
            _gridViewInitialized = false;
            _gridViewAdded = false;
            _gridViewUpdated = false;
            _shimObject = ShimsContext.Create();

            _testObj = new ResourceGridClass();
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
            var spList = new ShimSPList
            {
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    ItemGetString = __ => $"{DummyInt};#{DummyString}"
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = _ => new ShimSPField()
                }.Bind(new SPField[]
                {
                    new ShimSPField
                    {
                        InternalNameGet = () => DummyString,
                        TypeGet = () => SPFieldType.MultiChoice,
                        TitleGet = () => DummyString
                    }
                }),
                ItemsGet = () => new ShimSPListItemCollection().Bind(new SPListItem[]
                {
                    new ShimSPListItem
                    {
                        IDGet = () => DummyInt,
                        FieldsGet = () => new ShimSPFieldCollection().Bind(new SPField[]
                        {
                            new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid(),
                                InternalNameGet = () => DummyString,
                                GetFieldValueAsHtmlObject = _ => TrueString,
                                TypeGet = () => SPFieldType.Boolean
                            }
                        }),
                        ItemGetGuid = _ => DummyString
                    }
                })
            };

            _web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyInt,
                    NameGet = () => DummyString,
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        LocaleIdGet = () => CultureEnUS
                    }
                },
                IsRootWebGet = () => false,
                ParentWebGet = () => _web,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => spList
                },
                SiteGet = () => _site,
                SiteUserInfoListGet = () => new ShimSPList
                {
                    ItemsGet = () => new ShimSPListItemCollection
                    {
                        GetDataTable = () => CreateUserInfoDataTable()
                    }
                },
                ServerRelativeUrlGet = () => DummyUrl
            };

            _site = new ShimSPSite
            {
                RootWebGet = () => _web
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _web,
                SiteGet = () => _site
            };

            ShimResourcePoolManager.Constructor = _ => { };
            ShimResourcePoolManager.ConstructorSPWeb = (_, __) => { };

            ShimSPListItemManager.AllInstances.ItemExistsInt32 = (_, __) => true;
            ShimSPListItemManager.AllInstances.GetCurrentResourceInt32 = (_, __) => new ShimSPListItem
            {
                ItemGetString = item => DummyInt.ToString(),
                UniqueIdGet = () => Guid.NewGuid()
            };
            ShimSPListItemManager.AllInstances.DeleteInt32 = (_, __) => _itemDeleted = true;
            ShimSPListItemManager.AllInstances.ParentListGet = _ => spList;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = (int _1, Guid _2, SPWeb _3, out string _4, out string _5) =>
            {
                _4 = string.Empty;
                _5 = string.Empty;

                return true;
            };

            ShimGridViewManagerFactory.Constructor = _ => { };
            ShimGridViewManagerFactory.AllInstances.MakeGridViewManagerStringGridView = (_, __, ___) => new StubIGridViewManager
            {
                RemoveGridView = grid => _gridViewRemoved = true,
                AddGridView = grid => _gridViewAdded = true,
                UpdateGridView = grid => _gridViewUpdated = true
            };
            ShimGridViewManagerFactory.AllInstances.MakeGridViewManagerStringGridViewManagerKind = (_, __, ___) => new StubIGridViewManager
            {
                Initialize = () => _gridViewInitialized = true,
                ListGet = () => new List<GridView>
                {
                    new GridView
                    {
                        Definition = RootTags
                    }
                }
            };

            ShimGridViewUtils.ExtractViewsString = _ => new List<GridView>
            {
                new GridView
                {
                    Id = GridViewId
                }
            };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveSafelyStringStringString = (_, __, ___) => _cacheRemoved = true
            };
            ShimCacheStore.AllInstances.GetStringStringFuncOfObjectBoolean = (_, _1, _2, action, _4) =>
            {
                var result = action();

                return new ShimCachedValue
                {
                    ValueGet = () => result
                };
            };

            ShimCacheStoreCategory.ConstructorSPWeb = (_, __) => { };
            ShimCacheStoreCategory.AllInstances.ResourceGridGet = _ => DummyString;
        }

        private DataTable CreateUserInfoDataTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("ID", typeof(int));

            return dataTable;
        }

        [TestMethod]
        public void DeleteResourcePoolResource_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXMLString();

            // Act
            var result = ResourceGridClass.DeleteResourcePoolResource(xmlString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _itemDeleted.ShouldBeTrue(),
                () => result.ShouldContain(DeleteResourcePoolResourceTag));
        }

        private string CreateXMLString()
        {
            var xmlString = $@"
                <Root>
                    <Resource Id='{DummyInt}' ConfirmDelete='{TrueString}'></Resource>
                </Root>";

            return xmlString;
        }

        [TestMethod]
        public void DeleteResourcePoolViews_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXMLString();

            // Act
            var result = ResourceGridClass.DeleteResourcePoolViews(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _gridViewRemoved.ShouldBeTrue(),
                () => _cacheRemoved.ShouldBeTrue(),
                () => result.ShouldBe(ResourcePoolViewsClosedTag));
        }

        [TestMethod]
        public void ExportResources_OnValidCall_ConfirmResult()
        {
            // Arrange
            var exported = false;
            var expectedResult = string.Format(@"<ResourceExporter Success=""{0}"" Message=""{1}"" File=""{2}"" />",
                true,
                DummyString,
                DummyString);

            ShimResourceExporter.ConstructorSPWeb = (_, __) => { };
            ShimResourceExporter.AllInstances.ExportStringOutStringOut = (ResourceExporter exp, out string file, out string message) =>
            {
                file = DummyString;
                message = DummyString;
                exported = true;

                return true;
            };

            // Act
            var result = ResourceGridClass.ExportResources(_web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => exported.ShouldBeTrue(),
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void GetResourcePoolDataGrid_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = $@"
                <Root WebId='{WebId}' ListId='{ListId}' ItemId='{DummyInt}'>
                    <Resource ID='{DummyInt}'>
                        <Data Field='ID' HtmlValue='{DummyInt}' Type='Number'>{DummyInt}</Data>
                    </Resource>
                    <IncludeHidden>{true}</IncludeHidden>
                    <IncludeReadOnly>{true}</IncludeReadOnly>
                    <Department ID='{DummyString}'>
                        <Fields Field='Title' />
                        <Fields Field='RBS'>{DummyString}</Fields>
                        <Fields Field='Managers'>{DummyInt};#{DummyString}</Fields>
                        <Fields Field='Executives'>{DummyInt};#{DummyString}</Fields>
                    </Department>
                </Root>";
            var count = 0;

            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection
            {
                ItemGetGuid = guid =>
                {
                    count++;
                    if (count == 1)
                    {
                        return null;
                    }
                    return new ShimSPFeature();
                }
            };
            ShimResourcePoolManager.AllInstances.GetAllBooleanBoolean = (_, __, ___) => XDocument.Parse(xmlString);

            ShimDepartmentManager.ConstructorSPWeb = (_, __) => { };

            ShimSPListItemManager.AllInstances.GetAll = _ => XDocument.Parse(xmlString);

            ShimAPITeam.GetTeamStringSPWeb = (_, __) => $@"
                <Root>
                    <Member ID ='{DummyInt}' />
                </Root>";

            // Act
            var result = ResourceGridClass.GetResourcePoolDataGrid(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain(GridTag),
                () => result.ShouldContain(BodyTag),
                () => result.ShouldContain(ResourceID),
                () => result.ShouldContain(ProfilePic),
                () => result.ShouldContain(ProfilePicUrl),
                () => result.ShouldContain(IsMyResource));
        }

        [TestMethod]
        public void GetResourcePoolDataGridChanges_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = $@"
                <Root>
                    <Params>
                        <ChangeType>Added</ChangeType>
                        <Rows>2</Rows>
                    </Params>
                </Root>";

            // Act
            var result = ResourceGridClass.GetResourcePoolDataGridChanges(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ResourcePoolDataGridChangesTag),
                () => result.ShouldContain(IAdded));
        }

        [TestMethod]
        public void GetResourcePoolLayoutGrid_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = $@"
                <Root>
                    <Id>{DummyString}</Id>
                </Root>";

            // Act
            var result = ResourceGridClass.GetResourcePoolLayoutGrid(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(GridTag),
                () => result.ShouldContain(CfgTag));
        }

        [TestMethod]
        public void GetResourcePoolViews_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ResourceGridClass.GetResourcePoolViews(DummyString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _gridViewInitialized.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResourcePoolViewsTag),
                () => result.ShouldContain(ViewsTag),
                () => result.ShouldContain(RootTags));
        }

        [TestMethod]
        public void SaveResourcePoolViews_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ResourceGridClass.SaveResourcePoolViews(DummyString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _gridViewAdded.ShouldBeTrue(),
                () => _cacheRemoved.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResourcePoolViewsClosedTag));
        }

        [TestMethod]
        public void UpdateResourcePoolViews_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ResourceGridClass.UpdateResourcePoolViews(DummyString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _gridViewUpdated.ShouldBeTrue(),
                () => _cacheRemoved.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResourcePoolViewsClosedTag));
        }

        [TestMethod]
        public void RefreshResources_OnValidCall_ConfirmResult()
        {
            // Arrange
            var jobAdded = false;
            var jobEnqueued = false;
            ShimTimer.AddTimerJobGuidGuidStringInt32StringStringInt32Int32String = (_1, _2, _3, _4, _5, _6, _7, _8, _9) =>
            {
                jobAdded = true;

                return Guid.NewGuid();
            };
            ShimTimer.EnqueueGuidInt32SPSite = (_, __, ___) => jobEnqueued = true;

            // Act
            var result = ResourceGridClass.RefreshResources(_web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => jobAdded.ShouldBeTrue(),
                () => jobEnqueued.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(RefreshResourcesSucess));
        }
    }
}