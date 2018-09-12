﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.Upgrades.Steps.Fakes;
using EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps;
using EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.Fakes;
using Shouldly;

namespace EPMLiveCore.Tests.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [TestClass, ExcludeFromCodeCoverage]
    public class UpdateResourcePoolTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string MessageLoadingPool = "Loading Resource Pool List";
        private const string MessageNullResourcePool = "Resources list missing";
        private const string MessageNullRoles = "Roles list missing";
        private const string MessageNullDepartments = "Departments list missing";
        private const string MessageNullHolidaySchedules = "HolidaySchedules list missing";
        private const string MessageNullWorkHours = "WorkHours list missing";
        private const string ResourcesList = "Resources";
        private const string RolesList = "Roles";
        private const string DepartmentsList = "Departments";
        private const string HolidaySchedulesList = "Holiday Schedules";
        private const string WorkHoursList = "Work Hours";
        private const string MethodProcessFields = "ProcessFields";
        private const string MethodGetDatabaseFromRegistry = "GetDatabaseFromRegistry";
        private readonly Guid DummyGuid = Guid.NewGuid();
        private UpdateResourcePool _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private List<string> _logs;
        private List<string> _errors;
        private List<string> _skipped;
        private List<string> _success;
        private ShimSPWeb _shimWeb;
        private ShimSPListCollection _shimListCollection;
        private ShimSPList _shimList;
        private ShimSPFieldCollection _shimFields;
        private int _listUpdates;
        private int _listItemUpdates;
        private HashSet<string> _deletedFields;
        private HashSet<string> _updatedFields;
        private HashSet<string> _addedFields;
        private HashSet<string> _lookupFields;
        private bool _connectionOpened;
        private bool _siteSaved;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            ShimSharePointContext();

            _logs = new List<string>();
            _errors = new List<string>();
            _skipped = new List<string>();
            _success = new List<string>();
            _listUpdates = 0;
            _listItemUpdates = 0;
            _deletedFields = new HashSet<string>();
            _updatedFields = new HashSet<string>();
            _addedFields = new HashSet<string>();
            _lookupFields = new HashSet<string>();
            _connectionOpened = false;
            _siteSaved = false;

            ShimStep.AllInstances.LogMessageString = (_, log) => _logs.Add(log);
            ShimStep.AllInstances.LogMessageStringStringInt32 = (_, __, log, status) =>
            {
                if (status == 2)
                {
                    _skipped.Add(log);
                }
                else if (status == 3)
                {
                    _errors.Add(log);
                }
                else
                {
                    _success.Add(log);
                }
            };

            _testObject = new UpdateResourcePool(_shimWeb.Instance, DummyString, 0, true);
            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void Perform_NullResourcePool_ReturnsTrue()
        {
            // Arrange
            _shimListCollection.TryGetListString = _ => null;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _logs.ShouldContain(MessageLoadingPool),
                () => _errors.ShouldContain(MessageNullResourcePool));
        }

        [TestMethod]
        public void Perform_NullRoles_ReturnsTrue()
        {
            // Arrange
            var validLists = new string[] { ResourcesList };
            _shimListCollection.TryGetListString = list => validLists.Contains(list) ? _shimList.Instance : null;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _logs.ShouldContain(MessageLoadingPool),
                () => _errors.ShouldContain(MessageNullRoles));
        }

        [TestMethod]
        public void Perform_NullDepartments_ReturnsTrue()
        {
            // Arrange
            var validLists = new string[] { ResourcesList, RolesList };
            _shimListCollection.TryGetListString = list => validLists.Contains(list) ? _shimList.Instance : null;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _logs.ShouldContain(MessageLoadingPool),
                () => _errors.ShouldContain(MessageNullDepartments));
        }

        [TestMethod]
        public void Perform_NullHolidaySchedules_ReturnsTrue()
        {
            // Arrange
            var validLists = new string[] { ResourcesList, RolesList, DepartmentsList };
            _shimListCollection.TryGetListString = list => validLists.Contains(list) ? _shimList.Instance : null;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _logs.ShouldContain(MessageLoadingPool),
                () => _errors.ShouldContain(MessageNullHolidaySchedules));
        }

        [TestMethod]
        public void Perform_NullWorkHours_ReturnsTrue()
        {
            // Arrange
            var validLists = new string[] { ResourcesList, RolesList, DepartmentsList, HolidaySchedulesList };
            _shimListCollection.TryGetListString = list => validLists.Contains(list) ? _shimList.Instance : null;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _logs.ShouldContain(MessageLoadingPool),
                () => _errors.ShouldContain(MessageNullWorkHours),
                () => _testObject.Description.ShouldBe("Updating Resource Pool"));
        }

        [TestMethod]
        public void Perform_AllFieldsExist_ReturnsTrue()
        {
            // Arrange
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, __) => true;
            _shimFields.GetFieldByInternalNameString = fieldName =>
            {
                var shimSPField = GetShimSPField(fieldName);
                var field = shimSPField.Instance;
                field.Sealed = true;
                return field;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { _connectionOpened = true; };
            ShimComponent.AllInstances.Dispose = _ => { _connectionOpened = false; };
            ShimSqlCommand.ConstructorStringSqlConnection = (a, b, c) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();

            ShimDataTable.AllInstances.LoadIDataReader = (table, __) => FillDataTable(table);
            ShimSPFieldUserValue.ConstructorSPWebString = (a, b, c) =>
            {
                ShimSPFieldUserValue.AllInstances.UserGet = d => new ShimSPUser()
                {
                    LoginNameGet = () => DummyString
                };
            };

            var events = new List<string>();
            ShimWorkEngineAPI.AddRemoveFeatureEventsStringSPWeb = (feature, _) =>
            {
                events.Add(feature);
                return feature;
            };
            ShimGridGanttSettings.AllInstances.SaveSettingsSPList = (_, __) => _siteSaved = true;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _listUpdates.ShouldBe(2),
                () => _listItemUpdates.ShouldBe(2),
                () => _updatedFields.ShouldContain("CanLogin"),
                () => _updatedFields.ShouldContain("DepartmentManager"),
                () => _deletedFields.ShouldContain("CanLogin"),
                () => _deletedFields.ShouldContain("DepartmentManager"),
                () => _logs.ShouldContain("\tUpdating Role, Department, Holiday Schedule and Work Hours"),
                () => events.Contains(@"<AddRemoveFeatureEvents><Data><Feature Name=""pferesourcemanagement"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>"),
                () => _siteSaved.ShouldBeTrue(),
                () => _connectionOpened.ShouldBeFalse());
        }

        [TestMethod]
        public void Perform_GetWrongConnectionString_ReturnsTrue()
        {
            // Arrange
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, __) => true;
            _shimFields.GetFieldByInternalNameString = fieldName =>
            {
                var shimSPField = GetShimSPField(fieldName);
                var field = shimSPField.Instance;
                field.Sealed = true;
                return field;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => "provider";
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { _connectionOpened = true; };
            ShimComponent.AllInstances.Dispose = _ => { _connectionOpened = false; };
            ShimSqlCommand.ConstructorStringSqlConnection = (a, b, c) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();

            ShimDataTable.AllInstances.LoadIDataReader = (table, __) => FillDataTable(table);
            ShimSPFieldUserValue.ConstructorSPWebString = (a, b, c) =>
            {
                ShimSPFieldUserValue.AllInstances.UserGet = d => new ShimSPUser()
                {
                    LoginNameGet = () => DummyString
                };
            };

            var events = new List<string>();
            ShimWorkEngineAPI.AddRemoveFeatureEventsStringSPWeb = (feature, _) =>
            {
                events.Add(feature);
                return feature;
            };
            ShimGridGanttSettings.AllInstances.SaveSettingsSPList = (_, __) => _siteSaved = true;

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _connectionOpened.ShouldBeFalse(),
                () => _errors.Any(e => e.Contains("Not setting Holiday Schedule and Work Hours. Cannot load from PFE.")).ShouldBeTrue());
        }

        [TestMethod]
        public void Perform_NoFieldsExists_AddsAndUpdatesTempFields()
        {
            // Arrange
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, __) => false;
            _shimFields.GetFieldByInternalNameString = fieldName =>
                _lookupFields.Contains(fieldName)
                ? new ShimSPField(new ShimSPFieldLookup().Instance)
                {
                    Update = () => _updatedFields.Add(fieldName)
                }.Instance
                : GetShimSPField(fieldName).Instance;

            // Act
            _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _addedFields.ShouldContain("TempRole"),
                () => _addedFields.ShouldContain("TempDept"),
                () => _updatedFields.ShouldContain("TempRole"),
                () => _updatedFields.ShouldContain("TempDept"),
                () => _updatedFields.ShouldContain("ResourceLevel"),
                () => _updatedFields.ShouldContain("HolidaySchedule"),
                () => _updatedFields.ShouldContain("WorkHours"),
                () => _updatedFields.ShouldContain("Role"),
                () => _updatedFields.ShouldContain("Department"));
        }

        [TestMethod]
        public void Perform_GetFieldByInternalNameFails_LogsErrors()
        {
            // Arrange
            var createdFields = new List<string>();
            var exceptionMessage = DummyString;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, __) => false;
            _shimFields.GetFieldByInternalNameString = fieldName =>
            {
                if (!createdFields.Contains(fieldName))
                {
                    throw new InvalidOperationException(exceptionMessage);
                }

                return GetShimSPField(fieldName, SPFieldType.Lookup);
            };
            _shimFields.CreateNewFieldStringString = (_, fieldName) =>
            {
                createdFields.Add(fieldName);
                return GetShimSPField(fieldName);
            };

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _errors.Contains($"Adding TempRole field: {exceptionMessage}"),
                () => _errors.Contains($"Adding TempDept field: {exceptionMessage}"),
                () => _errors.Contains($"Removing CanLogin field: {exceptionMessage}"),
                () => _errors.Contains($"Removing DepartmentManager field: {exceptionMessage}"),
                () => _errors.Contains($"Adding License Type field: {exceptionMessage}"),
                () => _errors.Contains($"Adding Holiday Schedule field: {exceptionMessage}"),
                () => _errors.Contains($"Adding Work Hours field: {exceptionMessage}"),
                () => _errors.Contains($"Adding Role field: {exceptionMessage}"),
                () => _errors.Contains($"Adding Department field: {exceptionMessage}"),
                () => _errors.Contains($"(Generic): {exceptionMessage}"),
                () => _errors.Contains($"(FirstName): {exceptionMessage}"),
                () => _errors.Contains($"(LastName): {exceptionMessage}"),
                () => _errors.Contains($"(Email): {exceptionMessage}"),
                () => _errors.Contains($"(ResourceLevel): {exceptionMessage}"),
                () => _errors.Contains($"(Permissions): {exceptionMessage}"),
                () => _errors.Contains($"(StandardRate): {exceptionMessage}"),
                () => _errors.Contains($"(Department): {exceptionMessage}"),
                () => _errors.Contains($"(Role): {exceptionMessage}"),
                () => _errors.Contains($"(HolidaySchedule): {exceptionMessage}"),
                () => _errors.Contains($"(WorkHours): {exceptionMessage}"),
                () => _errors.Contains($"(AvailableFrom): {exceptionMessage}"),
                () => _errors.Contains($"(AvailableTo): {exceptionMessage}"),
                () => _errors.Contains($"(Disabled): {exceptionMessage}"));
        }

        [TestMethod]
        public void Perform_UpdateFieldFailed_ReturnsTrue()
        {
            // Arrange
            var exceptionMessage = DummyString;
            ShimUpdateResourcePool.AllInstances.UpdateFieldStringBooleanBooleanBooleanSPListRef =
                (UpdateResourcePool a, string b, bool c, bool d, bool e, ref SPList f) =>
                {
                    throw new InvalidOperationException(exceptionMessage);
                };

            // Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _errors.ShouldContain($"General: {exceptionMessage}"));
        }

        [TestMethod]
        public void Perform_InvokeWithoutShim_ReturnsTrue()
        {
            // Arrange, Act
            var result = _testObject.Perform();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue());
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GetConnectionString_EmptyConfigSetting_ThrowsException()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => string.Empty;

            // Act
            var result = _privateObject.Invoke("GetConnectionString");

            // Assert Expected Exception
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GetConnectionString_EmptyDBFromRegistry_ThrowsException()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString =
                (_, setting) => setting.Equals("epkbasepath") ? DummyString : string.Empty;
            ShimUpdateResourcePool.GetDatabaseFromRegistryString = _ => string.Empty;

            // Act
            var result = _privateObject.Invoke("GetConnectionString");

            // Assert Expected Exception
        }

        [TestMethod]
        public void ProcessFields_NoListAndFieldUpdateFail_LogsErrors()
        {
            // Arrange
            var nonExistingLists = new string[] { "HolidaySchedule", "WorkHours", "Role", "Department" };
            var exceptionMessage = DummyString;
            _shimFields.GetFieldByInternalNameString = fieldName =>
            {
                if (nonExistingLists.Contains(fieldName))
                {
                    throw new InvalidOperationException(exceptionMessage);
                }

                var field = GetShimSPField(fieldName);
                var fieldSealed = true;
                field.SealedGet = () => fieldSealed;
                field.SealedSetBoolean = seal => fieldSealed = seal;
                field.Update = () => { throw new InvalidOperationException(exceptionMessage); };
                return field;
            };
            _shimListCollection.TryGetListString = _ => null;

            // Act
            _privateObject.Invoke(MethodProcessFields, new object[] { _shimList.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _errors.ShouldContain($"Removing CanLogin field: {exceptionMessage}"),
                () => _errors.ShouldContain($"Removing DepartmentManager field: {exceptionMessage}"),
                () => _errors.ShouldContain("Holiday schedule list missing"),
                () => _errors.ShouldContain("WorkHours list missing"),
                () => _errors.ShouldContain("Roles list missing"));
        }

        [TestMethod]
        public void ProcessFields_UpdateLookupFields_DeletesAndCreatesFields()
        {
            // Arrange
            _shimFields.GetFieldByInternalNameString = fieldName =>
            {
                if (_lookupFields.Contains(fieldName))
                {
                    return new ShimSPField(new ShimSPFieldLookup().Instance)
                    {
                        Update = () => _updatedFields.Add(fieldName)
                    }.Instance;
                }
                else
                {
                    var field = GetShimSPField(fieldName);
                    var fieldSealed = true;
                    field.SealedGet = () => fieldSealed;
                    field.SealedSetBoolean = seal => fieldSealed = seal;
                    return field.Instance;
                }
            };

            // Act
            _privateObject.Invoke(MethodProcessFields, new object[] { _shimList.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _deletedFields.ShouldContain("Role"),
                () => _deletedFields.ShouldContain("Department"),
                () => _lookupFields.ShouldContain("Role"),
                () => _lookupFields.ShouldContain("Department"),
                () => _success.ShouldContain("The Department field is replaced"));
        }

        [TestMethod]
        public void ProcessFields_UpdateLookupFieldsBIsNotPfe_DeletesAndCreatesFields()
        {
            // Arrange
            _shimFields.GetFieldByInternalNameString = fieldName =>
            {
                if (_lookupFields.Contains(fieldName))
                {
                    return new ShimSPField(new ShimSPFieldLookup().Instance)
                    {
                        Update = () => _updatedFields.Add(fieldName)
                    }.Instance;
                }
                else
                {
                    var field = GetShimSPField(fieldName);
                    var fieldSealed = true;
                    field.SealedGet = () => fieldSealed;
                    field.SealedSetBoolean = seal => fieldSealed = seal;
                    return field.Instance;
                }
            };
            _testObject = new UpdateResourcePool(_shimWeb.Instance, DummyString, 0, false);
            _privateObject = new PrivateObject(_testObject);

            // Act
            _privateObject.Invoke(MethodProcessFields, new object[] { _shimList.Instance });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _deletedFields.ShouldContain("Role"),
                () => _deletedFields.ShouldContain("Department"),
                () => _lookupFields.ShouldContain("Role"),
                () => _lookupFields.ShouldContain("Department"),
                () => _success.ShouldContain("The Department field is replaced"));
        }

        [TestMethod]
        public void GetDatabaseFromRegistry_Invoke_ReturnsConnectionString()
        {
            // Arrange
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (a, b, c) => new ShimRegistryKey().Instance;
            ShimRegistryKey.AllInstances.OpenSubKeyString = (_, __) => new ShimRegistryKey().Instance;
            ShimRegistryKey.AllInstances.GetValueString = (_, key) => key.Equals("ConnectionString") ? DummyString : null;
            var type = new PrivateType(typeof(UpdateResourcePool));

            // Act
            var result = type.InvokeStatic(MethodGetDatabaseFromRegistry, new object[] { DummyString });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetDatabaseFromRegistry_OpenEPMLiveKeyFails_ReturnsConnectionStringFromWow6432Node()
        {
            // Arrange
            var openedWow6432Node = false;
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (_, key, __) =>
            {
                if (key.Equals("EPMLive") && !openedWow6432Node)
                {
                    throw new InvalidOperationException();
                }
                else if (key.Equals("Wow6432Node"))
                {
                    openedWow6432Node = true;
                }

                return new ShimRegistryKey().Instance;
            };
            ShimRegistryKey.AllInstances.OpenSubKeyString = (_, __) => new ShimRegistryKey().Instance;
            ShimRegistryKey.AllInstances.GetValueString = (_, key) => key.Equals("ConnectionString") ? DummyString : null;
            var type = new PrivateType(typeof(UpdateResourcePool));

            // Act
            var result = type.InvokeStatic(MethodGetDatabaseFromRegistry, new object[] { DummyString });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetDatabaseFromRegistry_OpenWow6432NodeFails_ReturnsEmpty()
        {
            // Arrange
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (_, key, __) =>
            {
                if (key.Equals("EPMLive") || key.Equals("Wow6432Node"))
                {
                    throw new InvalidOperationException();
                }

                return new ShimRegistryKey().Instance;
            };
            ShimRegistryKey.AllInstances.OpenSubKeyString = (_, __) => new ShimRegistryKey().Instance;
            ShimRegistryKey.AllInstances.GetValueString = (_, key) => key.Equals("ConnectionString") ? DummyString : null;
            var type = new PrivateType(typeof(UpdateResourcePool));

            // Act
            var result = type.InvokeStatic(MethodGetDatabaseFromRegistry, new object[] { DummyString });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(string.Empty));
        }

        private void ShimSharePointContext()
        {
            var user = new ShimSPUser
            {
                IDGet = () => Id
            };
            _shimFields = new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = _ => new ShimSPField()
                {
                    TitleGet = () => DummyString
                }.Instance,
                AddStringSPFieldTypeBoolean = (field, _, __) =>
                {
                    _addedFields.Add(field);
                    return field;
                },
                AddFieldAsXmlString = field =>
                {
                    _addedFields.Add(field);
                    return field;
                },
                AddLookupStringGuidBoolean = (field, _, __) =>
                {
                    _lookupFields.Add(field);
                    return field;
                }
            };
            _shimList = new ShimSPList
            {
                IDGet = () => DummyGuid,
                ItemsGet = () => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem>
                    {
                        new ShimSPListItem()
                        {
                            ItemGetGuid = _ => DummyString,
                            ItemGetString = key => key.Equals("EXTID") ? null : DummyString,
                            ItemSetStringObject = (_, __) => { },
                            Update = () => { _listItemUpdates++; }
                        }
                    }.GetEnumerator(),
                    GetDataTable = () => GetDataTable()
                },
                FieldsGet = () => _shimFields.Instance,
                Update = () => { _listUpdates++; }
            };
            var webApp = new ShimSPWebApplication
            {
                ApplicationPoolGet = () => new SPApplicationPool()
            }.Instance;
            _shimListCollection = new ShimSPListCollection
            {
                ItemGetString = _ => _shimList,
                ItemGetGuid = _ => _shimList,
                GetListGuidBoolean = (_, __) => _shimList,
                TryGetListString = list => _shimList.Instance
            };
            _shimWeb = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                CurrentUserGet = () => user,
                EnsureUserString = _ => user,
                SiteUserInfoListGet = () => _shimList.Instance,
                ListsGet = () => _shimListCollection.Instance
            };
            _shimList.ParentWebGet = () => _shimWeb;
            var site = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                RootWebGet = () => _shimWeb.Instance,
                WebApplicationGet = () => webApp
            };
            _shimWeb.SiteGet = () => site.Instance;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _shimWeb.Instance,
                SiteGet = () => site.Instance
            }.Instance;
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _shimWeb;
        }

        private void AppendAttributeToNode(XmlNode node, XmlDocument propdoc, string name, string value)
        {
            var attribute = propdoc.CreateAttribute(name);
            attribute.Value = value;
            node.Attributes.Append(attribute);
        }

        private DataSet GetEmptyDataSet()
        {
            var dataTable = GetDataTable();
            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private DataSet GetDataSet()
        {
            var dataTable = GetDataTable();
            CreateRowForTable(dataTable);
            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private DataTable GetDataTable()
        {
            var dataTable = new DataTable();
            FillDataTable(dataTable);
            return dataTable;
        }

        private void FillDataTable(DataTable dataTable)
        {
            CreateColumnsForTable(dataTable);
            CreateRowForTable(dataTable);
        }

        private void CreateColumnsForTable(DataTable dataTable)
        {
            dataTable.Columns.Add("Account");
            dataTable.Columns.Add("HolidaySchedule");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("WorkHours");
            dataTable.Columns.Add("DisplayName");
        }

        private void CreateRowForTable(DataTable dataTable)
        {
            var row = dataTable.NewRow();
            row["Account"] = DummyString;
            row["HolidaySchedule"] = DummyString;
            row["Title"] = DummyString;
            row["ID"] = One;
            row["WorkHours"] = DummyString;
            row["DisplayName"] = DummyString;
            dataTable.Rows.Add(row);
        }

        private ShimSPField GetShimSPField(string fieldName, SPFieldType fieldType = SPFieldType.Choice)
        {
            return new ShimSPField()
            {
                IdGet = () => DummyGuid,
                TitleGet = () => fieldName,
                TypeGet = () => fieldType,
                Update = () => _updatedFields.Add(fieldName),
                Delete = () => _deletedFields.Add(fieldName),
            };
        }
    }
}
