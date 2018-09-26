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
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ResourceGridClass = EPMLiveCore.API.ResourceGrid;
using ShimManagementUtilities = WorkEnginePPM.Core.ResourceManagement.Fakes.ShimUtilities;

namespace EPMLiveCore.Tests.API.ResourceGrid
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourceGridTests
    {
        private IDisposable _shimObject;
        private ResourceGridClass _testObj;
        private PrivateObject _privateObj;
        private PrivateType _privateType;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private bool _itemDeleted;
        private bool _cacheRemoved;
        private bool _gridViewRemoved;
        private bool _gridViewInitialized;
        private bool _gridViewAdded;
        private bool _gridViewUpdated;

        private const int DummyIntOne = 1;
        private const int DummyIntTwo = 2;
        private const int DummyIntThree = 3;
        private const int CultureEnUS = 1033;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string DummyError = "DummyError";
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
        private const string IOther = "<I Other=\"1\"";
        private const string CfgTag = "<Cfg Code=\"GTACCNPSQEBSLC\" Version=\"4.3.2.120412\" />";
        private const string ViewsTag = "<Views>";
        private const string RootTags = "<Root></Root>";
        private const string Children = "Children";
        private const string IDField = "ID";
        private const string PictureField = "Picture";
        private const string NoValueString = "no";

        private const string BuildDepartmentHierarchyMethod = "BuildDepartmentHierarchy";
        private const string RegisterGridIdAndCssMethod = "RegisterGridIdAndCss";

        private const string RootElementIsMissing = "Root element is missing.";
        private const string NotValidResourcePoolId = "is not a valid Resource Pool Id.";

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
            _privateType = new PrivateType(typeof(ResourceGridClass));

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
                    ItemGetString = __ => $"{DummyIntOne};#{DummyString}",
                    ItemGetGuid = __ => DummyIntOne.ToString(),
                    FieldsGet = () => new ShimSPFieldCollection().Bind(new SPField[]
                    {
                        new ShimSPField
                        {
                            IdGet = () => Guid.NewGuid(),
                            InternalNameGet = () => "SharePointAccount",
                            GetFieldValueAsHtmlObject = x => TrueString,
                            TypeGet = () => SPFieldType.Boolean
                        },
                        new ShimSPField
                        {
                            IdGet = () => Guid.NewGuid(),
                            InternalNameGet = () => "DateTimeField",
                            GetFieldValueAsHtmlObject = x => DateTime.Now.ToShortDateString(),
                            TypeGet = () => SPFieldType.DateTime
                        },
                        new ShimSPField
                        {
                            IdGet = () => Guid.NewGuid(),
                            InternalNameGet = () => "CurrencyField",
                            GetFieldValueAsHtmlObject = x => DummyIntOne.ToString(),
                            TypeGet = () => SPFieldType.Currency
                        },
                        new ShimSPField
                        {
                            IdGet = () => Guid.NewGuid(),
                            InternalNameGet = () => "ChoiceField",
                            GetFieldValueAsHtmlObject = x => DummyIntOne.ToString(),
                            TypeGet = () => SPFieldType.Choice
                        },
                        new ShimSPField
                        {
                            IdGet = () => Guid.NewGuid(),
                            InternalNameGet = () => "LookupField",
                            GetFieldValueAsHtmlObject = x => DummyIntOne.ToString(),
                            TypeGet = () => SPFieldType.Lookup
                        }
                    })
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = _ => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Lookup,
                        InternalNameGet = () => DummyString
                    }
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
                        IDGet = () => DummyIntOne,
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
                    IDGet = () => DummyIntOne,
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
                ItemGetString = item => DummyIntOne.ToString(),
                UniqueIdGet = () => Guid.NewGuid()
            };
            ShimSPListItemManager.AllInstances.DeleteInt32 = (_, __) => _itemDeleted = true;
            ShimSPListItemManager.AllInstances.ParentListGet = _ => spList;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimManagementUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = (int _1, Guid _2, SPWeb _3, out string _4, out string _5) =>
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

            dataTable.Columns.Add(IDField, typeof(int));
            dataTable.Columns.Add(PictureField, typeof(string));

            var row = dataTable.NewRow();
            row[IDField] = 0;
            row[PictureField] = DummyString;

            dataTable.Rows.Add(row);

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

        [TestMethod]
        public void DeleteResourcePoolResource_WhenResourceDoesNotExist_ThrowException()
        {
            // Arrange
            var xmlString = CreateXMLString();

            ShimSPListItemManager.AllInstances.ItemExistsInt32 = (_, __) => false;

            // Act
            Action action = () => ResourceGridClass.DeleteResourcePoolResource(xmlString);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain(NotValidResourcePoolId));
        }

        [TestMethod]
        public void DeleteResourcePoolResource_WhenRootIsNull_ThrowException()
        {
            // Arrange, Act
            Action action = () => ResourceGridClass.DeleteResourcePoolResource(string.Empty);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain(RootElementIsMissing));
        }

        [TestMethod]
        public void DeleteResourcePoolResource_WhenNoResource_ThrowException()
        {
            // Arrange
            var xmlString = RootTags;

            // Act
            Action action = () => ResourceGridClass.DeleteResourcePoolResource(xmlString);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain(@"Cannot find the DeleteResourcePoolResource\Resource element."));
        }

        [TestMethod]
        public void DeleteResourcePoolResource_WhenNoId_ThrowException()
        {
            // Arrange
            var xmlString = "<Root><Resource /></Root>";

            // Act
            Action action = () => ResourceGridClass.DeleteResourcePoolResource(xmlString);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain(@"Cannot find the DeleteResourcePoolResource\Resource Id attribute."));
        }

        [TestMethod]
        public void DeleteResourcePoolResource_WhenInvalidId_ThrowException()
        {
            // Arrange
            var xmlString = $"<Root><Resource Id='{DummyString}'/></Root>";

            // Act
            Action action = () => ResourceGridClass.DeleteResourcePoolResource(xmlString);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain(NotValidResourcePoolId));
        }

        [TestMethod]
        public void DeleteResourcePoolResource_WhenPerformDeleteReturnsValue_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXMLString();

            ShimManagementUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut = 
                (int _1, Guid _2, SPWeb _3, out string _4, out string _5) =>
                {
                    _4 = NoValueString;
                    _5 = DummyError;

                    return false;
                };

            // Act
            var result = ResourceGridClass.DeleteResourcePoolResource(xmlString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(DeleteResourcePoolResourceTag),
                () => result.ShouldContain(DummyError));
        }

        private string CreateXMLString()
        {
            var xmlString = $@"
                <Root>
                    <Resource Id='{DummyIntOne}' ConfirmDelete='{TrueString}'></Resource>
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
        public void DeleteResourcePoolViews_OnError_ThrowException()
        {
            // Arrange
            ShimGridViewManagerFactory.Constructor = _ =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.DeleteResourcePoolViews(string.Empty, _web.Instance);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
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
        public void ExportResources_OnError_ThrowException()
        {
            // Arrange
            ShimResourceExporter.ConstructorSPWeb = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.ExportResources(_web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
        }

        [TestMethod]
        public void GetResourcePoolDataGrid_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = $@"
                <Root WebId='{WebId}' ListId='{ListId}' ItemId='{DummyIntOne}'>
                    <Resource ID='{DummyIntOne}'>
                        <Data Field='ID' HtmlValue='{DummyIntOne}' Type='Number'>{DummyIntOne}</Data>
                        <Data Field='{DummyString}' HtmlValue='{DummyIntOne}' Type='Number'>{DummyIntOne}</Data>
                    </Resource>
                    <IncludeHidden>{true}</IncludeHidden>
                    <IncludeReadOnly>{true}</IncludeReadOnly>
                    <Department ID='{DummyString}'>
                        <Fields Field='Title' />
                        <Fields Field='RBS'>{DummyString}</Fields>
                        <Fields Field='Managers'>{DummyIntOne};#{DummyString}</Fields>
                        <Fields Field='Executives'>{DummyIntOne};#{DummyString}</Fields>
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
                    <Member ID ='{DummyIntOne}' />
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
        public void GetResourcePoolDataGrid_OnError_ThrowException()
        {
            // Arrange
            ShimCacheStoreCategory.ConstructorSPWeb = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.GetResourcePoolDataGrid(string.Empty, _web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
        }

        [TestMethod]
        public void GetResourcePoolDataGridChanges_WhenAdded_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXMLForGetResourcePoolDataGridChanges("Added", DummyIntTwo);

            // Act
            var result = ResourceGridClass.GetResourcePoolDataGridChanges(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ResourcePoolDataGridChangesTag),
                () => result.ShouldContain(IAdded));
        }

        [TestMethod]
        public void GetResourcePoolDataGridChanges_WhenDeleted_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXMLForGetResourcePoolDataGridChanges("Deleted", DummyIntOne);

            // Act
            var result = ResourceGridClass.GetResourcePoolDataGridChanges(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ResourcePoolDataGridChangesTag),
                () => result.ShouldNotContain(IAdded));
        }

        [TestMethod]
        public void GetResourcePoolDataGridChanges_WhenOtherOption_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXMLForGetResourcePoolDataGridChanges("Other", DummyIntTwo);
            ShimUtils.GetGridEnumSPSiteSPFieldStringOutInt32OutStringOut = (SPSite site, SPField field, out string enumValues, out int enumRange, out string enumKeys) =>
            {
                enumValues = DummyString;
                enumRange = DummyIntOne;
                enumKeys = DummyString;
            };

            // Act
            var result = ResourceGridClass.GetResourcePoolDataGridChanges(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ResourcePoolDataGridChangesTag),
                () => result.ShouldNotContain(IAdded),
                () => result.ShouldContain(IOther));
        }

        [TestMethod]
        public void GetResourcePoolDataGridChanges_OnError_ThrowException()
        {
            // Arrange
            var xmlString = CreateXMLForGetResourcePoolDataGridChanges(string.Empty, DummyIntOne);

            ShimGridGanttSettings.ConstructorSPList = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.GetResourcePoolDataGridChanges(xmlString, _web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
        }

        private static string CreateXMLForGetResourcePoolDataGridChanges(string option, int id)
        {
            return $@"
                <Root>
                    <Params>
                        <ChangeType>{option}</ChangeType>
                        <Rows>{id}</Rows>
                    </Params>
                </Root>";
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
        public void GetResourcePoolLayoutGrid_WhenNoRoot_ThrowException()
        {
            // Arrange, Act
            Action action = () => ResourceGridClass.GetResourcePoolLayoutGrid(string.Empty, _web);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldBe(RootElementIsMissing));
        }

        [TestMethod]
        public void RegisterGridIdAndCss_WhenLayoutDataIsNull_ThrowException()
        {
            // Arrange, Act
            Action action = () => _privateType.InvokeStatic(RegisterGridIdAndCssMethod, (XElement)null, (XDocument)null);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldBe("Layout data cannot be null."));
        }

        [TestMethod]
        public void RegisterGridIdAndCss_WhenRootElementIsNull_ThrowException()
        {
            // Arrange
            var document = new XDocument();

            // Act
            Action action = () => _privateType.InvokeStatic(RegisterGridIdAndCssMethod, (XElement)null, document);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldBe("Cannot find the Root element of the layout data."));
        }

        [TestMethod]
        public void RegisterGridIdAndCss_WhenNoIdElement_ThrowException()
        {
            // Arrange
            var document = XDocument.Parse(RootTags);

            // Act
            Action action = () => _privateType.InvokeStatic(RegisterGridIdAndCssMethod, (XElement)null, document);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldBe("Cannot find the Id element of the layout data."));
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
        public void GetResourcePoolViews_OnError_ThrowException()
        {
            // Arrange
            ShimCacheStoreCategory.ConstructorSPWeb = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.GetResourcePoolViews(DummyString, _web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
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
        public void SaveResourcePoolViews_OnError_ThrowException()
        {
            // Arrange
            ShimGridViewManagerFactory.Constructor = _ =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.SaveResourcePoolViews(DummyString, _web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
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
        public void UpdateResourcePoolViews_OnError_ThrowException()
        {
            // Arrange
            ShimGridViewManagerFactory.Constructor = _ =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.UpdateResourcePoolViews(DummyString, _web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
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

        [TestMethod]
        public void RefreshResources_WhenErrorOnAddJob_ThrowException()
        {
            // Arrange
            ShimTimer.AddTimerJobGuidGuidStringInt32StringStringInt32Int32String = (_1, _2, _3, _4, _5, _6, _7, _8, _9) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.RefreshResources(_web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
        }

        [TestMethod]
        public void BuildDepartmentHierarchy_OnValidCall_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;
            List<DataRow> rowList;
            CreateDataTable(out dataTable, out rowList);

            // Act
            _privateType.InvokeStatic(BuildDepartmentHierarchyMethod, rowList, dataTable);

            // Assert
            var children = (List<string>)dataTable.Rows[0][Children];
            this.ShouldSatisfyAllConditions(
                () => children.Count.ShouldBe(2));
        }

        private static void CreateDataTable(out DataTable dataTable, out List<DataRow> rowList)
        {
            const string Id = "Id";
            const string IdClean = "IdClean";
            const string ParentId = "ParentId";
            const string ParentIdClean = "ParentIdClean";
            const string ParentChild = "ParentChild";

            var dataSet = new DataSet();
            dataTable = new DataTable();
            dataSet.Tables.Add(dataTable);
            dataTable.Columns.Add(Id, typeof(string));
            dataTable.Columns.Add(IdClean, typeof(string));
            dataTable.Columns.Add(Children, typeof(List<string>));
            dataTable.Columns.Add(ParentId, typeof(string));
            dataTable.Columns.Add(ParentIdClean, typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[Id] };

            var row = dataTable.NewRow();
            row[Id] = DummyIntOne.ToString();
            row[IdClean] = DummyIntOne.ToString();
            row[Children] = new List<string>();
            dataTable.Rows.Add(row);

            var row2 = dataTable.NewRow();
            row2[Id] = DummyIntTwo.ToString();
            row2[IdClean] = DummyIntTwo.ToString();
            row2[ParentId] = DummyIntOne.ToString();
            row2[ParentIdClean] = DummyIntOne.ToString();
            row2[Children] = new List<string>();
            dataTable.Rows.Add(row2);

            var row3 = dataTable.NewRow();
            row3[Id] = DummyIntThree.ToString();
            row3[IdClean] = DummyIntThree.ToString();
            row3[ParentId] = DummyIntTwo.ToString();
            row3[ParentIdClean] = DummyIntTwo.ToString();
            row3[Children] = new List<string>();
            dataTable.Rows.Add(row3);

            var dataRelation = new DataRelation(ParentChild, dataTable.Columns[Id], dataTable.Columns[ParentId]);
            dataSet.Relations.Add(dataRelation);

            rowList = new List<DataRow>();
            rowList.Add(dataTable.Rows[0]);
        }

        [TestMethod]
        public void GetResources_OnError_ThrowException()
        {
            // Arrange
            ShimResourcePoolManager.ConstructorSPWeb = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            Action action = () => ResourceGridClass.GetResources(string.Empty, _web);

            // Assert
            Should.Throw<APIException>(action).Message.ShouldBe(DummyError);
        }
    }
}