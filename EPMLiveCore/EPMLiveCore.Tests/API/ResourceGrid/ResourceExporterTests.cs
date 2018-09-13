using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.ResourceGrid
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourceExporterTests
    {
        private IDisposable _shimObject;
        private ResourceExporter _testObj;
        private ShimSPWeb _web;
        private bool _listItemSystemUpdated;
        private bool _fileAdded;
        private DataTable _dataTable;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string IDColumn = "ID";
        private const string SharePointAccountColumn = "SharePointAccount";
        private const string PermissionsColumn = "Permissions";
        private const string ResourceLevelField = "ResourceLevel";
        private const string ChoiceField = "ChoiceField";
        private const string MultiChoiceField = "MultiChoiceField";
        private const string UserField = "UserField";

        [TestInitialize]
        public void TestInitialize()
        {
            _listItemSystemUpdated = false;
            _fileAdded = false;
            _shimObject = ShimsContext.Create();

            SetupShims();

            _testObj = new ResourceExporter(_web.Instance);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            var count = 0;
            _dataTable = new DataTable();
            _dataTable.Columns.Add(IDColumn, typeof(int));
            _dataTable.Columns.Add(SharePointAccountColumn);
            _dataTable.Columns.Add(PermissionsColumn);
            _dataTable.Columns.Add(ResourceLevelField);
            _dataTable.Columns.Add(ChoiceField);
            _dataTable.Columns.Add(MultiChoiceField);
            _dataTable.Columns.Add(UserField);

            var listItemCollection = new ShimSPListItemCollection
            {
                GetDataTable = () =>
                {
                    count++;
                    if (count > 1)
                    {
                        return _dataTable;
                    }
                    return null;
                },
                Add = () => new ShimSPListItem
                {
                    ItemGetString = x => DummyString,
                    SystemUpdate = () => _listItemSystemUpdated = true,
                    Delete = () => { }
                }
            }
            .Bind(new SPListItem[]
            {
                new ShimSPListItem()
            });

            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection().Bind(new SPField[]
                {
                    new ShimSPFieldLookup
                    {
                        LookupFieldGet = () => DummyString,
                        LookupWebIdGet = () => Guid.NewGuid(),
                        LookupListGet = () => Guid.NewGuid().ToString()
                    },
                    new ShimSPFieldChoice(),
                    new ShimSPFieldMultiChoice(),
                    new ShimSPFieldUser()
                }),
                ParentWebGet = () => _web,
                GetItemsSPQuery = query => listItemCollection,
                ItemsGet = () => listItemCollection,
                GetItemsStringArray = _ => listItemCollection,
                GetItemByIdInt32 = x => new ShimSPListItem
                {
                    ItemGetString = item =>
                    {
                        if (item == ResourceLevelField)
                        {
                            return new ShimSPFieldLookupValueCollection().Instance;
                        }
                        return DummyString;
                    }
                }
            };

            _web = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => spList,
                    ItemGetGuid = _ => spList
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IsSiteAdminGet = () => true
                },
                GroupsGet = () => new ShimSPGroupCollection()
            };
            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.InternalNameGet = instance =>
            {
                if (instance is SPFieldUser)
                {
                    return UserField;
                }
                if (instance is SPFieldLookup)
                {
                    return ResourceLevelField;
                }
                if (instance is SPFieldChoice)
                {
                    return ChoiceField;
                }
                if (instance is SPFieldMultiChoice)
                {
                    return MultiChoiceField;
                }
                return DummyString;
            };
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => _web
            };
            ShimSPField.AllInstances.TypeGet = instance =>
            {
                if (instance is SPFieldUser)
                {
                    return SPFieldType.User;
                }
                if (instance is SPFieldLookup)
                {
                    return SPFieldType.Lookup;
                }
                if (instance is SPFieldChoice)
                {
                    return SPFieldType.Choice;
                }
                if (instance is SPFieldMultiChoice)
                {
                    return SPFieldType.MultiChoice;
                }
                return SPFieldType.Text;
            };

            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection { DummyString };

            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSPQuery.Constructor = _ => { };

            ShimDisabledItemEventScope.Constructor = _ => { };

            ShimResourceExporter.GetPermissionsSPWeb = _ => new List<string> { DummyString };

            ShimSPFieldUserValue.ConstructorSPWebString = (_, __, ___) => { };
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser
            {
                LoginNameGet = () => DummyString,
                GroupsGet = () => new ShimSPGroupCollection().Bind(new SPGroup[]
                {
                    new ShimSPGroup
                    {
                        NameGet = () => DummyString
                    }
                })
            };

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.IsOnlineGet = _ => true;
            ShimAct.AllInstances.GetLevelsFromSiteInt32OutString = (Act _, out int actType, string userName) =>
            {
                actType = DummyInt;
                return new ArrayList
                {
                    new ActLevel
                    {
                        id = DummyInt,
                        name = DummyString
                    }
                };
            };

            ShimEPMLiveFileStore.ConstructorSPWeb = (_, __) => { };
            ShimEPMLiveFileStore.AllInstances.AddByteArray = (_, __) =>
            {
                _fileAdded = true;
                return DummyString;
            };
        }

        [TestMethod]
        public void Export_OnValidCall_ConfirmResult()
        {
            // Arrange
            string file;
            string message;
            var row1 = _dataTable.NewRow();
            var row2 = _dataTable.NewRow();

            row2[IDColumn] = DummyInt;

            _dataTable.Rows.Add(row1);
            _dataTable.Rows.Add(row2);

            // Act
            var result = _testObj.Export(out file, out message);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _listItemSystemUpdated.ShouldBeTrue(),
                () => _fileAdded.ShouldBeTrue());
        }
    }
}