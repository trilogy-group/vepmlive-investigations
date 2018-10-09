using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise;
using EPMLiveEnterprise.Fakes;
using EPMLiveEnterprise.WebSvcCustomFields.Fakes;
using EPMLiveEnterprise.WebSvcLookupTables.Fakes;
using EPMLiveEnterprise.WebSvcStatusing.Fakes;
using Microsoft.Office.Project.Server.Library;
using Microsoft.Office.Project.Server.Library.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WebSvcProjectFakes = EPMLiveEnterprise.WebSvcProject.Fakes;
using static EPMLiveEnterprise.WebSvcCustomFields.CustomFieldDataSet;
using static EPMLiveEnterprise.WebSvcCustomFields.Fakes.ShimCustomFieldDataSet;
using static EPMLiveEnterprise.WebSvcLookupTables.LookupTableDataSet;
using static EPMLiveEnterprise.WebSvcLookupTables.Fakes.ShimLookupTableDataSet;
using static EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet;
using System.Data.Common.Fakes;
using System.Net.Fakes;
using System.Web.Services.Protocols.Fakes;
using System.Web.Services.Protocols;
using System.Net;

namespace EPMLivePS.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EPMLiveEnterpriseTaskEventReceiverItemEventReceiverTests
    {
        private EPMLiveEnterpriseTaskEventReceiverItemEventReceiver testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags nonPublicInstance;
        private BindingFlags publicInstance;
        private BindingFlags publicStatic;
        private Guid guid;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPList spList;
        private ShimSPListItem spListItem;
        private ShimSPField spField;
        private ShimSqlDataReader dataReader;
        private ShimSPItemEventProperties properties;
        private const int DummyInt32 = 111;
        private const string DummyString = "DummyString";
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string WssFieldNameColumn = "wssFieldName";
        private const string AssnFieldNameColumn = "assnfieldname";
        private const string FieldTypeColumn = "fieldtype";
        private const string FieldCategoryColumn = "fieldCategory";
        private const string AssnUpdateColumnIdColumn = "assnUpdateColumnId";
        private const string MultiplierColumn = "multiplier";
        private const string SchemaXml = @"<SchemaXml Format=""DateOnly""/>";
        private const string DateTimeType = "DATETIME";
        private const string NumberType = "Number";
        private const string CurrencyType = "CURRENCY";
        private const string DurationType = "DURATION";
        private const string DurType = "Dur";
        private const string TimeSheetHours = "251658250";
        private const string FieldPropertiesFieldName = "fieldProperties";
        private const string SiteUrlFieldName = "pwaSiteUrl";
        private const string SiteGuidFieldName = "pwaSiteGuid";
        private const string CustomFieldsFieldName = "CustomFields";
        private const string LookupTableFieldName = "LookupTable";
        private const string StatusingFieldName = "Statusing";
        private const string TaskUidColumn = "Task_uid";
        private const string AssnUidColumn = "Assn_uid";
        private const string ItemAddingMethodName = "ItemAdding";
        private const string ItemUpdatingMethodName = "ItemUpdating";
        private const string UpdateHandleMethodName = "UpdateHandle";
        private const string InsertHandleMethodName = "InsertHandle";
        private const string GetProjectUidMethodName = "getProjectUid";
        private const string IsFieldEditableMethodName = "isFieldEditable";
        private const string UpdateTaskMethodName = "UpdateTask";
        private const string ValueToUseMethodName = "ValueToUse";
        private const string ReturnCalculatedFieldMethodName = "ReturnCalculatedField";
        private const string GetSummaryTaskMethodName = "getSummaryTask";
        private const string InsertTaskMethodName = "InsertTask";
        private const string RetrieveEditableFieldsMethodName = "RetrieveEditableFields";
        private const string GetPubTypeMethodName = "getPubType";
        private const string UpdateStatusMethodName = "UpdateStatus";
        private const string SubmitAllUpdatesMethodName = "SubmitAllUpdates";
        private const string LeftMethodName = "Left";
        private const string RightMethodName = "Right";
        private const string MidMethodName = "Mid";
        private const string IsAssignedTaskApprovedMethodName = "IsAssignedTaskApproved";
        private const string ProjectFieldName = "Project";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();
            SetupVariables();
            testObject = new EPMLiveEnterpriseTaskEventReceiverItemEventReceiver();
            privateObject = new PrivateObject(testObject);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            ShimSqlConnection.Constructor = _ => new ShimSqlConnection();
            ShimSqlConnection.ConstructorString = (_, _1) => new ShimSqlConnection();
            ShimStatusing.Constructor = _ => new ShimStatusing();
            ShimCustomFields.Constructor = _ => new ShimCustomFields();
            ShimCustomFieldDataSet.Constructor = _ => new ShimCustomFieldDataSet();
            ShimLookupTableDataSet.Constructor = _ => new ShimLookupTableDataSet();
            ShimProjectDataSet.Constructor = _ => new ShimProjectDataSet();
            WebSvcProjectFakes.ShimProject.Constructor = _ => new WebSvcProjectFakes.ShimProject();
            ShimLookupTable.Constructor = _ => new ShimLookupTable();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => guid;
            ShimSPSite.AllInstances.UrlGet = _ => DummyString;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.Close = _ => { };
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPEventPropertiesBase.AllInstances.SiteIdGet = _ => guid;
            ShimSPEventPropertiesBase.AllInstances.ErrorMessageSetString = (_, _1) => { };
            ShimSPEventPropertiesBase.AllInstances.CancelSetBoolean = (_, _1) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt32;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRunElevated => codeToRunElevated();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimEntityCollection.EntitiesGet = () => new ShimEntityCollection()
            {
                TaskEntityGet = () => new ShimEntity()
                {
                    UniqueIdGet = () => GuidString
                }
            };
        }

        private void SetupVariables()
        {
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            guid = Guid.Parse(GuidString);
            dataReader = new ShimSqlDataReader()
            {
                Read = () => true,
                GetStringInt32 = _ => DummyString,
                GetInt32Int32 = _ => DummyInt32,
                Close = () => { }
            };
            properties = new ShimSPItemEventProperties()
            {
                ListItemGet = () => spListItem,
                ListIdGet = () => guid,
                OpenWeb = () => spWeb,
                WebUrlGet = () => DummyString,
                AfterPropertiesGet = () => new ShimSPItemEventDataCollection(),
                UserLoginNameGet = () => DummyString
            };
            spField = new ShimSPField()
            {
                InternalNameGet = () => DummyString
            };
            spListItem = new ShimSPListItem()
            {
                ItemGetString = _ => DummyString,
                TitleGet = () => DummyString
            };
            spList = new ShimSPList()
            {
                GetItemByIdInt32 = _ => spListItem,
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => spField
                }
            };
            spSite = new ShimSPSite()
            {
                UrlGet = () => DummyString,
                IDGet = () => guid
            };
            spWeb = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = _ => spList,
                    ItemGetGuid = _ => spList
                },
                SiteGet = () => spSite,
                Close = () => { },
                IDGet = () => guid
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void ItemAdding_WhenCalled_Inserts()
        {
            // Arrange
            var validation = 0;

            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.InsertHandleSPItemEventProperties = (_, __) =>
            {
                validation += 1;
                return false;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            // Act
            privateObject.Invoke(ItemAddingMethodName, publicInstance, new object[] { properties.Instance });

            // Assert
            validation.ShouldBe(2);
        }

        [TestMethod]
        public void ItemUpdating_WhenCalled_Updates()
        {
            // Arrange
            var validation = 0;

            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.UpdateHandleSPItemEventProperties = (_, __) =>
            {
                validation += 1;
                return false;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            // Act
            privateObject.Invoke(ItemUpdatingMethodName, publicInstance, new object[] { properties.Instance });

            // Assert
            validation.ShouldBe(2);
        }

        [TestMethod]
        public void UpdateHandle_WhenCalled_Updates()
        {
            // Arrange
            var validation = 0;

            spListItem.ItemGetString = _ => $"{DummyString}.{DummyString}";
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) =>
            {
                throw new Exception();
            };
            ShimSPItemEventDataCollection.AllInstances.ItemSetStringObject = (_, _1, _2) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getProjectUidStringSPWeb = (_, _1, _2) =>
            {
                validation += 1;
                return GuidString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getPubTypeString = (_, _1) =>
            {
                validation += 1;
                return 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.RightStringInt32 = (_, _1) =>
            {
                validation += 1;
                return GuidString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.UpdateTaskGuidGuidSPItemEventProperties = (_, _1, _2, _3) =>
            {
                validation += 1;
            };
            spWeb.Close = () =>
            {
                validation += 1;
                throw new Exception();
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            // Act
            var actual = (bool)privateObject.Invoke(UpdateHandleMethodName, publicInstance, new object[] { properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(7));
        }

        [TestMethod]
        public void InsertHandle_WhenCalled_Inserts()
        {
            // Arrange
            var validation = 0;
            var methodHit = 0;

            spListItem.ItemGetString = _ => $"{DummyString}.{DummyString}";
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) =>
            {
                methodHit += 1;
                if (methodHit.Equals(1))
                {
                    throw new Exception();
                }
                return DummyString;
            };
            ShimSPItemEventDataCollection.AllInstances.ItemSetStringObject = (_, _1, _2) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getProjectUidStringSPWeb = (_, _1, _2) =>
            {
                validation += 1;
                return GuidString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getPubTypeString = (_, _1) =>
            {
                validation += 1;
                return 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.InsertTaskGuidStringStringStringSPItemEventProperties = (_, _1, _2, _3, _4, _5) =>
            {
                validation += 1;
                return DummyString;
            };
            spWeb.Close = () =>
            {
                validation += 1;
                throw new Exception();
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            // Act
            var actual = (bool)privateObject.Invoke(InsertHandleMethodName, publicInstance, new object[] { properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(6));
        }

        [TestMethod]
        public void GetProjectUid_WhenCalled_ReturnsString()
        {
            // Arrange
            const string projectName = "111";

            // Act
            var actual = (string)privateObject.Invoke(GetProjectUidMethodName, publicInstance, new object[] { projectName, spWeb.Instance });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void IsFieldEditable_WhereMe_ReturnsBoolean()
        {
            // Arrange
            const string displaySettings = "where;[Me];condition;group;valueCondition";
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                [DummyString] = new Dictionary<string, string>()
                {
                    ["Edit"] = displaySettings
                }
            };

            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (_, _1, _2, _3, _4, _5, _6) => false;

            privateObject.SetFieldOrProperty(FieldPropertiesFieldName, nonPublicInstance, fieldProperties);

            // Act
            var actual = (bool)privateObject.Invoke(IsFieldEditableMethodName, nonPublicInstance, new object[] { spField.Instance, spListItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void IsFieldEditable_WhereNotMe_ReturnsBoolean()
        {
            // Arrange
            const string displaySettings = "where;[NotMe];condition;group;valueCondition";
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                [DummyString] = new Dictionary<string, string>()
                {
                    ["Edit"] = displaySettings
                }
            };

            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (_, _1, _2, _3, _4, _5, _6) => true;

            privateObject.SetFieldOrProperty(FieldPropertiesFieldName, nonPublicInstance, fieldProperties);

            // Act
            var actual = (bool)privateObject.Invoke(IsFieldEditableMethodName, nonPublicInstance, new object[] { spField.Instance, spListItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void UpdateTask_FieldCategory1_UpdatesTask()
        {
            // Arrange
            var validation = 0;
            var customFields = new ShimCustomFields()
            {
                UrlSetString = _ => { },
                UseDefaultCredentialsSetBoolean = _ => { },
                ReadCustomFieldsByEntityGuid = _ => new ShimCustomFieldDataSet()
                {
                    CustomFieldsGet = () => new ShimCustomFieldsDataTable()
                }
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>();
            var fieldDataSet = new DataSet();
            var dataTable = new DataTable();
            dataTable.Columns.Add(WssFieldNameColumn);
            dataTable.Columns.Add(FieldTypeColumn);
            dataTable.Columns.Add(FieldCategoryColumn, typeof(int));
            dataTable.Columns.Add(AssnUpdateColumnIdColumn);
            dataTable.Columns.Add(MultiplierColumn, typeof(int));
            var row = dataTable.NewRow();
            row[WssFieldNameColumn] = DummyString;
            row[FieldTypeColumn] = DummyString;
            row[FieldCategoryColumn] = 1;
            row[AssnUpdateColumnIdColumn] = AssnUpdateColumnIdColumn;
            row[MultiplierColumn] = 1;
            dataTable.Rows.Add(row);
            fieldDataSet.Tables.Add(dataTable);

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.SchemaXmlGet = () => SchemaXml;
            ShimListDisplayUtils.ConvertFromStringString = _ => fieldProperties;
            ShimDataTable.AllInstances.SelectString = (_, _1) =>
            {
                return new CustomFieldsRow[]
                {
                    new ShimCustomFieldsRow()
                    {
                        MD_PROP_UID_SECONDARYGet = () => guid,
                        MD_PROP_NAMEGet = () => DummyString
                    }
                };
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.RetrieveEditableFields = _ =>
            {
                validation += 1;
                return fieldDataSet;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.isFieldEditableSPFieldSPListItem = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ReturnCalculatedFieldStringInt32StringInt32 = (_, _1, _2, _3, _4) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ValueToUseSPItemEventPropertiesSPField = (_, _1, _2) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.MidStringInt32Int32 = (input, _1, _2) =>
            {
                validation += 1;
                return input;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.UpdateStatusStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.SubmitAllUpdatesStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) =>
            {
                validation += 1;
                return DummyInt32;
            };

            privateObject.SetFieldOrProperty(SiteUrlFieldName, nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty(SiteGuidFieldName, nonPublicInstance, guid);
            privateObject.SetFieldOrProperty(CustomFieldsFieldName, nonPublicInstance, customFields.Instance);

            // Act
            privateObject.Invoke(UpdateTaskMethodName, publicInstance, new object[] { guid, guid, properties.Instance });

            // Assert
            validation.ShouldBe(12);
        }

        [TestMethod]
        public void UpdateTask_FieldCategory2_UpdatesTask()
        {
            // Arrange
            var validation = 0;
            var customFields = new ShimCustomFields()
            {
                UrlSetString = _ => { },
                UseDefaultCredentialsSetBoolean = _ => { },
                ReadCustomFieldsByEntityGuid = _ => new ShimCustomFieldDataSet()
                {
                    CustomFieldsGet = () => new ShimCustomFieldsDataTable()
                }
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>();
            var fieldDataSet = new DataSet();
            var dataTable = new DataTable();
            dataTable.Columns.Add(WssFieldNameColumn);
            dataTable.Columns.Add(FieldTypeColumn);
            dataTable.Columns.Add(FieldCategoryColumn, typeof(int));
            dataTable.Columns.Add(AssnUpdateColumnIdColumn);
            dataTable.Columns.Add(MultiplierColumn, typeof(int));
            var row = dataTable.NewRow();
            row[WssFieldNameColumn] = DurType;
            row[FieldTypeColumn] = DateTimeType;
            row[FieldCategoryColumn] = 2;
            row[AssnUpdateColumnIdColumn] = AssnUpdateColumnIdColumn;
            row[MultiplierColumn] = 1;
            dataTable.Rows.Add(row);
            fieldDataSet.Tables.Add(dataTable);

            dataReader.GetStringInt32 = _ => TimeSheetHours;
            spField.TypeGet = () => SPFieldType.DateTime;
            spField.SchemaXmlGet = () => SchemaXml;
            ShimListDisplayUtils.ConvertFromStringString = _ => fieldProperties;
            ShimDataTable.AllInstances.SelectString = (_, _1) =>
            {
                return new CustomFieldsRow[]
                {
                    new ShimCustomFieldsRow()
                    {
                        MD_PROP_UID_SECONDARYGet = () => guid,
                        MD_PROP_NAMEGet = () => DummyString
                    }
                };
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.RetrieveEditableFields = _ =>
            {
                validation += 1;
                return fieldDataSet;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.isFieldEditableSPFieldSPListItem = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ReturnCalculatedFieldStringInt32StringInt32 = (_, _1, _2, _3, _4) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ValueToUseSPItemEventPropertiesSPField = (_, _1, _2) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.MidStringInt32Int32 = (input, _1, _2) =>
            {
                validation += 1;
                return input;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.UpdateStatusStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.SubmitAllUpdatesStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getCustomFieldChangeTypeString = (_, _1) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) =>
            {
                validation += 1;
                return DummyInt32;
            };

            privateObject.SetFieldOrProperty(SiteUrlFieldName, nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty(SiteGuidFieldName, nonPublicInstance, guid);
            privateObject.SetFieldOrProperty(CustomFieldsFieldName, nonPublicInstance, customFields.Instance);

            // Act
            privateObject.Invoke(UpdateTaskMethodName, publicInstance, new object[] { guid, guid, properties.Instance });

            // Assert
            validation.ShouldBe(14);
        }

        [TestMethod]
        public void UpdateTask_FieldCategory3UIDNull_UpdatesTask()
        {
            // Arrange
            var validation = 0;
            var customFields = new ShimCustomFields()
            {
                UrlSetString = _ => { },
                UseDefaultCredentialsSetBoolean = _ => { },
                ReadCustomFieldsByEntityGuid = _ => new ShimCustomFieldDataSet()
                {
                    CustomFieldsGet = () => new ShimCustomFieldsDataTable()
                }
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>();
            var fieldDataSet = new DataSet();
            var dataTable = new DataTable();
            dataTable.Columns.Add(WssFieldNameColumn);
            dataTable.Columns.Add(AssnFieldNameColumn);
            dataTable.Columns.Add(FieldTypeColumn);
            dataTable.Columns.Add(FieldCategoryColumn, typeof(int));
            dataTable.Columns.Add(AssnUpdateColumnIdColumn);
            dataTable.Columns.Add(MultiplierColumn, typeof(int));
            var row = dataTable.NewRow();
            row[WssFieldNameColumn] = DurType;
            row[AssnFieldNameColumn] = DurType;
            row[FieldTypeColumn] = DateTimeType;
            row[FieldCategoryColumn] = 3;
            row[AssnUpdateColumnIdColumn] = AssnUpdateColumnIdColumn;
            row[MultiplierColumn] = 1;
            dataTable.Rows.Add(row);
            fieldDataSet.Tables.Add(dataTable);

            dataReader.GetStringInt32 = _ => TimeSheetHours;
            spField.TypeGet = () => SPFieldType.DateTime;
            spField.SchemaXmlGet = () => SchemaXml;
            ShimListDisplayUtils.ConvertFromStringString = _ => fieldProperties;
            ShimDataTable.AllInstances.SelectString = (_, _1) =>
            {
                return new CustomFieldsRow[]
                {
                    new ShimCustomFieldsRow()
                    {
                        MD_PROP_UID_SECONDARYGet = () => guid,
                        MD_PROP_NAMEGet = () => DummyString,
                        MD_PROP_TYPE_ENUMGet = () => (byte)PSDataType.NUMBER,
                        IsMD_LOOKUP_TABLE_UIDNull = () => true
                    }
                };
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.RetrieveEditableFields = _ =>
            {
                validation += 1;
                return fieldDataSet;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.isFieldEditableSPFieldSPListItem = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ReturnCalculatedFieldStringInt32StringInt32 = (_, _1, _2, _3, _4) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ValueToUseSPItemEventPropertiesSPField = (_, _1, _2) =>
            {
                validation += 1;
                return string.Empty;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.MidStringInt32Int32 = (input, _1, _2) =>
            {
                validation += 1;
                return input;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.UpdateStatusStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.SubmitAllUpdatesStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getCustomFieldChangeTypePSDataType = (_, _1) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) =>
            {
                validation += 1;
                return DummyInt32;
            };

            privateObject.SetFieldOrProperty(SiteUrlFieldName, nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty(SiteGuidFieldName, nonPublicInstance, guid);
            privateObject.SetFieldOrProperty(CustomFieldsFieldName, nonPublicInstance, customFields.Instance);

            // Act
            privateObject.Invoke(UpdateTaskMethodName, publicInstance, new object[] { guid, guid, properties.Instance });

            // Assert
            validation.ShouldBe(11);
        }

        [TestMethod]
        public void UpdateTask_FieldCategory3UIDNotNull_UpdatesTask()
        {
            // Arrange
            var validation = 0;
            var customFields = new ShimCustomFields()
            {
                UrlSetString = _ => { },
                UseDefaultCredentialsSetBoolean = _ => { },
                ReadCustomFieldsByEntityGuid = _ => new ShimCustomFieldDataSet()
                {
                    CustomFieldsGet = () => new ShimCustomFieldsDataTable()
                }
            };
            var lookupTable = new ShimLookupTable()
            {
                ReadLookupTablesByUidsGuidArrayBooleanInt32 = (_, _1, _2) => new ShimLookupTableDataSet()
                {
                    LookupTableTreesGet = () => new ShimLookupTableTreesDataTable()
                }
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>();
            var fieldDataSet = new DataSet();
            var dataTable = new DataTable();
            dataTable.Columns.Add(WssFieldNameColumn);
            dataTable.Columns.Add(AssnFieldNameColumn);
            dataTable.Columns.Add(FieldTypeColumn);
            dataTable.Columns.Add(FieldCategoryColumn, typeof(int));
            dataTable.Columns.Add(AssnUpdateColumnIdColumn);
            dataTable.Columns.Add(MultiplierColumn, typeof(int));
            var row = dataTable.NewRow();
            row[WssFieldNameColumn] = DurType;
            row[AssnFieldNameColumn] = DurType;
            row[FieldTypeColumn] = DateTimeType;
            row[FieldCategoryColumn] = 3;
            row[AssnUpdateColumnIdColumn] = AssnUpdateColumnIdColumn;
            row[MultiplierColumn] = 1;
            dataTable.Rows.Add(row);
            fieldDataSet.Tables.Add(dataTable);

            dataReader.GetStringInt32 = _ => TimeSheetHours;
            spField.TypeGet = () => SPFieldType.DateTime;
            spField.SchemaXmlGet = () => SchemaXml;
            ShimListDisplayUtils.ConvertFromStringString = _ => fieldProperties;
            ShimDataTable.AllInstances.SelectString = (_, condition) =>
            {
                if (condition.StartsWith("MD_PROP_UID_SECONDARY"))
                {
                    return new CustomFieldsRow[]
                    {
                        new ShimCustomFieldsRow()
                        {
                            MD_PROP_UID_SECONDARYGet = () => guid,
                            MD_PROP_NAMEGet = () => DummyString,
                            MD_PROP_TYPE_ENUMGet = () => (byte)PSDataType.NUMBER,
                            IsMD_LOOKUP_TABLE_UIDNull = () => false
                        }
                    };
                }

                return new LookupTableTreesRow[]
                {
                    new ShimLookupTableTreesRow()
                    {
                        LT_UIDGet = () => guid
                    }
                };
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.RetrieveEditableFields = _ =>
            {
                validation += 1;
                return fieldDataSet;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.isFieldEditableSPFieldSPListItem = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ReturnCalculatedFieldStringInt32StringInt32 = (_, _1, _2, _3, _4) =>
            {
                validation += 1;
                return DummyString;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ValueToUseSPItemEventPropertiesSPField = (_, _1, _2) =>
            {
                validation += 1;
                return string.Empty;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.MidStringInt32Int32 = (input, _1, _2) =>
            {
                validation += 1;
                return input;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.UpdateStatusStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.SubmitAllUpdatesStringSPItemEventProperties = (_, _1, _2) =>
            {
                validation += 1;
                return true;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getCustomFieldChangeTypePSDataType = (_, _1) =>
            {
                validation += 1;
                return NumberType;
            };
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) =>
            {
                validation += 1;
                return DummyInt32;
            };

            privateObject.SetFieldOrProperty(SiteUrlFieldName, nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty(SiteGuidFieldName, nonPublicInstance, guid);
            privateObject.SetFieldOrProperty(CustomFieldsFieldName, nonPublicInstance, customFields.Instance);
            privateObject.SetFieldOrProperty(LookupTableFieldName, nonPublicInstance, lookupTable.Instance);

            // Act
            privateObject.Invoke(UpdateTaskMethodName, publicInstance, new object[] { guid, guid, properties.Instance });

            // Assert
            validation.ShouldBe(12);
        }

        [TestMethod]
        public void ValueToUse_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "somerandomtexttobetested";

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => expected;

            // Act
            var actual = (string)privateObject.Invoke(ValueToUseMethodName, nonPublicInstance, new object[] { properties.Instance, spField.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ReturnCalculatedField_FieldCategory1_ReturnsString()
        {
            // Arrange
            const string value = "10";
            const string fieldType = NumberType;
            const int fieldCategory = 1;
            const int multiplier = 10;
            const string expected = "100";

            // Act
            var actual = (string)privateObject.Invoke(
                ReturnCalculatedFieldMethodName,
                nonPublicInstance,
                new object[] { value, fieldCategory, fieldType, multiplier });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ReturnCalculatedField_FieldCategory2_ReturnsString()
        {
            // Arrange
            const string value = "10";
            const string fieldType = CurrencyType;
            const int fieldCategory = 2;
            const int multiplier = 10;
            const string expected = "1000";

            // Act
            var actual = (string)privateObject.Invoke(
                ReturnCalculatedFieldMethodName,
                nonPublicInstance,
                new object[] { value, fieldCategory, fieldType, multiplier });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ReturnCalculatedField_FieldCategory3_ReturnsString()
        {
            // Arrange
            const string value = "10";
            const string fieldType = DurationType;
            const int fieldCategory = 3;
            const int multiplier = 10;
            const string expected = "48000";

            // Act
            var actual = (string)privateObject.Invoke(
                ReturnCalculatedFieldMethodName,
                nonPublicInstance,
                new object[] { value, fieldCategory, fieldType, multiplier });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetSummaryTask_WhenCalled_ReturnsGuid()
        {
            // Arrange
            var validation = 0;
            var project = new WebSvcProjectFakes.ShimProject()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                UseDefaultCredentialsSetBoolean = _ =>
                {
                    validation += 1;
                },
                ReadProjectEntitiesGuidInt32DataStoreEnum = (_, _1, _2) => new WebSvcProjectFakes.ShimProjectDataSet()
                {
                    TaskGet = () => new ShimTaskDataTable
                    {
                        ItemGetInt32 = __ => new ShimTaskRow()
                        {
                            TASK_UIDGet = () => guid
                        }
                    }
                }
            };

            privateObject.SetFieldOrProperty(ProjectFieldName, nonPublicInstance, project.Instance);

            // Act
            var actual = (Guid)privateObject.Invoke(GetSummaryTaskMethodName, nonPublicInstance, new object[] { guid });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(guid),
                () => validation.ShouldBe(2));
        }

        [TestMethod]
        public void InsertTask_WhenCalled_ReturnsString()
        {
            // Arrange
            var validation = 0;
            var date = DateTime.Now.ToString();
            var dataTable = new DataTable();
            dataTable.Columns.Add(TaskUidColumn);
            dataTable.Columns.Add(AssnUidColumn);
            var row = dataTable.NewRow();
            row[TaskUidColumn] = DummyString;
            row[AssnUidColumn] = DummyString;
            dataTable.Rows.Add(row);
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                UseDefaultCredentialsSetBoolean = _ =>
                {
                    validation += 1;
                },
                CreateNewAssignmentStringGuidGuidGuidGuidDateTimeDateTimeBooleanBooleanString = (_, _1, _2, _3, _4, _5, _6, _7, _8, _9) =>
                {
                    validation += 1;
                },
                ReadStatusGuidDateTimeDateTime = (_, _1, _2) =>
                {
                    validation += 1;
                    return new ShimStatusingDataSet()
                    {
                        TablesGet = () => new ShimDataTableCollection()
                        {
                            ItemGetString = __ => dataTable
                        }
                    };
                }
            };

            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getSummaryTaskGuid = (_, __) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.MidStringInt32Int32 = (input, index, length) =>
            {
                validation += 1;
                return input;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (string)privateObject.Invoke(
                InsertTaskMethodName,
                publicInstance,
                new object[] { guid, string.Empty, date, date, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{DummyString}.{DummyString}"),
                () => validation.ShouldBe(7));
        }

        [TestMethod]
        public void RetrieveEditableFields_WhenCalled_ReturnsDataSet()
        {
            // Arrange
            const int expected = 10;

            ShimDbDataAdapter.AllInstances.FillDataSet = (_, dataset) =>
            {
                for (var i = 0; i < expected; i++)
                {
                    dataset.Tables.Add(new DataTable());
                }
                return 1;
            };

            // Act
            var actual = (DataSet)privateObject.Invoke(RetrieveEditableFieldsMethodName, publicInstance, new object[] { });

            // Assert
            actual.Tables.Count.ShouldBe(expected);
        }

        [TestMethod]
        public void GetPubType_WhenCalled_ReturnsInteger()
        {
            // Arrange and Act
            var actual = (int)privateObject.Invoke(GetPubTypeMethodName, publicInstance, new object[] { string.Empty });

            // Assert
            actual.ShouldBe(DummyInt32);
        }

        [TestMethod]
        public void UpdateStatus_NoException_RetutnsTrue()
        {
            // Arrange
            const string changeXml = "somerandomtexttobetested";

            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                UpdateStatusString = input =>
                {
                    if (input.Equals(changeXml))
                    {
                        validation += 1;
                    }
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                UpdateStatusMethodName,
                publicInstance,
                new object[] { changeXml, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validation.ShouldBe(3));
        }

        [TestMethod]
        public void UpdateStatus_SoapException_RetutnsFalse()
        {
            // Arrange
            const string changeXml = "somerandomtexttobetested";

            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                UpdateStatusString = input =>
                {
                    if (input.Equals(changeXml))
                    {
                        validation += 1;
                    }
                    throw new SoapException();
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getErrorSoapException = (_, _1) =>
            {
                validation += 1;
                return string.Empty;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                UpdateStatusMethodName,
                publicInstance,
                new object[] { changeXml, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(5));
        }

        [TestMethod]
        public void UpdateStatus_OtherException_RetutnsFalse()
        {
            // Arrange
            const string changeXml = "somerandomtexttobetested";

            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                UpdateStatusString = input =>
                {
                    if (input.Equals(changeXml))
                    {
                        validation += 1;
                    }
                    throw new Exception();
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                UpdateStatusMethodName,
                publicInstance,
                new object[] { changeXml, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(4));
        }

        [TestMethod]
        public void SubmitAllUpdates_NoException_ReturnsTrue()
        {
            // Arrange
            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                SubmitStatusForResourceGuidGuidArrayString = (_, _1, _2) =>
                {
                    validation += 1;
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                SubmitAllUpdatesMethodName,
                publicInstance,
                new object[] { string.Empty, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validation.ShouldBe(4));
        }

        [TestMethod]
        public void SubmitAllUpdates_SoapException_ReturnsTrue()
        {
            // Arrange
            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                SubmitStatusForResourceGuidGuidArrayString = (_, _1, _2) =>
                {
                    validation += 1;
                    throw new SoapException();
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getErrorSoapException = (_, _1) =>
            {
                validation += 1;
                return string.Empty;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                SubmitAllUpdatesMethodName,
                publicInstance,
                new object[] { string.Empty, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(6));
        }

        [TestMethod]
        public void SubmitAllUpdates_WebException_ReturnsTrue()
        {
            // Arrange
            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                SubmitStatusForResourceGuidGuidArrayString = (_, _1, _2) =>
                {
                    validation += 1;
                    throw new WebException();
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getErrorSoapException = (_, _1) =>
            {
                validation += 1;
                return string.Empty;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                SubmitAllUpdatesMethodName,
                publicInstance,
                new object[] { string.Empty, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(5));
        }

        [TestMethod]
        public void SubmitAllUpdates_OtherException_ReturnsTrue()
        {
            // Arrange
            var validation = 0;
            var statusing = new ShimStatusing()
            {
                UrlSetString = _ =>
                {
                    validation += 1;
                },
                SubmitStatusForResourceGuidGuidArrayString = (_, _1, _2) =>
                {
                    validation += 1;
                    throw new Exception();
                }
            };

            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) =>
            {
                validation += 1;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.GetResourceGuidByWindowsAccountStringString = (_, _1, _2) =>
            {
                validation += 1;
                return guid;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.getErrorSoapException = (_, _1) =>
            {
                validation += 1;
                return string.Empty;
            };
            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(
                SubmitAllUpdatesMethodName,
                publicInstance,
                new object[] { string.Empty, properties.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(5));
        }

        [TestMethod]
        public void Left_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "Random";
            var paramter = $"{expected}.sometext";

            // Act
            var actual = (string)privateObject.Invoke(
                LeftMethodName,
                publicStatic,
                new object[] { paramter, expected.Length });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Right_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "Random";
            var paramter = $"sometext.{expected}";

            // Act
            var actual = (string)privateObject.Invoke(
                RightMethodName,
                publicStatic,
                new object[] { paramter, expected.Length });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Mid_WhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "Random";
            var paramter = $"Hi.{expected}";

            // Act
            var actual = (string)privateObject.Invoke(
                MidMethodName,
                publicStatic,
                new object[] { paramter, 3 });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Mid_OverLoadWhenCalled_ReturnsString()
        {
            // Arrange
            const string expected = "Random";
            var paramter = $"Hi.{expected}.sometext";

            // Act
            var actual = (string)privateObject.Invoke(
                MidMethodName,
                publicStatic,
                new object[] { paramter, 3, expected.Length });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsAssignedTaskApproved_NoException_ReturnsFalse()
        {
            // Arrange
            var validation = 0;
            var dataTable = new DataTable();
            dataTable.Rows.Add(dataTable.NewRow());
            var statusing = new ShimStatusing()
            {
                ReadStatusGuidDateTimeDateTime = (_, _1, _2) =>
                {
                    return new ShimStatusingDataSet()
                    {
                        TablesGet = () => new ShimDataTableCollection()
                        {
                            ItemGetString = __ =>
                            {
                                validation += 1;
                                return dataTable;
                            }
                        }
                    };
                }
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(IsAssignedTaskApprovedMethodName, publicInstance, new object[] { guid });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(1));
        }

        [TestMethod]
        public void IsAssignedTaskApproved_NoException_ReturnsTrue()
        {
            // Arrange
            var validation = 0;
            var dataTable = new DataTable();
            var statusing = new ShimStatusing()
            {
                ReadStatusGuidDateTimeDateTime = (_, _1, _2) =>
                {
                    return new ShimStatusingDataSet()
                    {
                        TablesGet = () => new ShimDataTableCollection()
                        {
                            ItemGetString = __ =>
                            {
                                validation += 1;
                                return dataTable;
                            }
                        }
                    };
                }
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(IsAssignedTaskApprovedMethodName, publicInstance, new object[] { guid });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validation.ShouldBe(1));
        }

        [TestMethod]
        public void IsAssignedTaskApproved_Exception_ReturnsFalse()
        {
            // Arrange
            var validation = 0;
            var statusing = new ShimStatusing()
            {
                ReadStatusGuidDateTimeDateTime = (_, _1, _2) =>
                {
                    return new ShimStatusingDataSet()
                    {
                        TablesGet = () => new ShimDataTableCollection()
                        {
                            ItemGetString = __ =>
                            {
                                validation += 1;
                                throw new Exception();
                            }
                        }
                    };
                }
            };

            ShimEPMLiveEnterpriseTaskEventReceiverItemEventReceiver.AllInstances.ErrorTrapInt32String = (_, _1, _2) =>
            {
                validation += 1;
            };

            privateObject.SetFieldOrProperty(StatusingFieldName, nonPublicInstance, statusing.Instance);

            // Act
            var actual = (bool)privateObject.Invoke(IsAssignedTaskApprovedMethodName, publicInstance, new object[] { guid });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validation.ShouldBe(2));
        }
    }
}