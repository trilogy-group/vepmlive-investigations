using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using TimeSheets.Fakes;

namespace EPMLiveTimesheets.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SavetimesheetTests
    {
        private IDisposable _shimObject;
        private savetimesheet _testObject;
        private PrivateObject _privateObject;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private List<string> _sqlCommands;
        private bool _systemUpdate;
        private bool _listItemUpdated;
        private bool _processMetaCalled;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string PageLoadMethod = "Page_Load";
        private const string OutputField = "output";
        private const string ProcessLiveHoursMethod = "processLiveHours";
        private const string ProcessWssItemMethod = "processWssItem";
        private const string StrFields = "strFields";
        private const string UserMulti = "UserMulti";
        private const string UserField = "UserField";
        private const string PercentField = "PercentField";
        private const string NumberField = "NumberField";
        private const string LookupField = "LookupField";
        private const string MultiChoiceField = "MultiChoiceField";
        private const string DateTimeField = "DateTimeField";
        private const string ChoiceField = "ChoiceField";
        private const string TextField = "TextField";
        private const string ProcessItemMethod = "processItem";
        private const string DayDefsField = "dayDefs";
        private const string TimeEditorField = "timeeditor";
        private const string ItemIdParameter = "_itemid";
        private const string FieldCountParameter = "_fieldcount";
        private const string DateCountParameter = "_datecount";
        private const string FirstDateParameter = "_firstdate";
        private const string TsItemUidParameter = "_tsitemuid";
        private const string TsUidParameter = "tsuid";
        private const string ColumnsParameter = "columns";
        private const string IdsParameter = "ids";
        private const string WebIdParameter = "_webid";
        private const string ListIdParameter = "_listid";
        private const string SiteIdParameter = "_siteid";
        private const string EditParameter = "edit";
        private const string EPMLiveTSLiveHours = "EPMLiveTSLiveHours";

        [TestInitialize]
        public void TestInitialize()
        {
            _systemUpdate = false;
            _listItemUpdated = false;
            _processMetaCalled = false;
            _sqlCommands = new List<string>();
            _shimObject = ShimsContext.Create();
            SetupShims();
            _testObject = new savetimesheet();
            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            _web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => new ShimSPList(),
                    ItemGetGuid = _ => new ShimSPList()
                },
                SiteGet = () => _site,
                CurrentUserGet = () => new ShimSPUser
                {
                    LoginNameGet = () => DummyString,
                    NameGet = () => DummyString
                }
            };
            _site = new ShimSPSite
            {
                RootWebGet = () => _web,
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => _site;
            ShimSPContext.AllInstances.WebGet = _ => _web;
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPListItem.AllInstances.SystemUpdate = _ => _systemUpdate = true;
            ShimSPListItem.AllInstances.Update = _ => _listItemUpdated = true;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSharedFunctions.canUserImpersonateStringStringSPWebStringOut = 
                (string _1, string _2, SPWeb _3, out string resName) =>
                {
                    resName = DummyString;
                    return true;
                };
            ShimSharedFunctions.getProjectCenterListSPList = _ => new ShimSPList();
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, command, _2) => 
            {
                instance.CommandText = command;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Close = _ => { };
        }

        [TestMethod]
        public void PageLoad_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string TrueValue = "true";
            var processItemCalled = false;
            var processLiveHours = false;
            var processWssItem = false;
            var processResourcesCalled = false;
            var sqlCommand = string.Empty;
            ShimSqlDataReader.AllInstances.HasRowsGet = _ => true;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimHttpRequest.AllInstances.ItemGetString = (_, item) =>
            {
                if (item == ColumnsParameter)
                {
                    return Convert.ToBase64String(Encoding.ASCII.GetBytes(DummyString));
                }
                if (item == IdsParameter)
                {
                    return $"{DummyString},{DummyString}";
                }
                if (item.Contains(WebIdParameter) || item.Contains(ListIdParameter) || item.Contains(SiteIdParameter))
                {
                    return Guid.NewGuid().ToString();
                }
                if (item == EditParameter)
                {
                    return TrueValue;
                }
                return DummyString;
            };
            Shimsavetimesheet.AllInstances.processItemStringSPWebSPListSPList = (_, _1, _2, _3, _4) => processItemCalled = true;
            Shimsavetimesheet.AllInstances.processLiveHoursStringGuidSPList = (_, _1, _2, _3) => processLiveHours = true;
            Shimsavetimesheet.AllInstances.processWssItemStringSPWebSPList = (_, _1, _2, _3) => processWssItem = true;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                sqlCommand = instance.CommandText;
                return DummyInt;
            };
            ShimSharedFunctions.processResourcesSqlConnectionStringSPWebString = (_, _1, _2, _3) => processResourcesCalled = true;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) =>
            {
                if (setting == EPMLiveTSLiveHours)
                {
                    return TrueValue;
                }
                return DummyString;
            };

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var output = _privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldBe("<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><action type='settsuid' tsuid=''/></data>"),
                () => processItemCalled.ShouldBeTrue(),
                () => processLiveHours.ShouldBeTrue(),
                () => processWssItem.ShouldBeTrue(),
                () => processResourcesCalled.ShouldBeTrue(),
                () => sqlCommand.ShouldBe("UPDATE TSTIMESHEET set approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@TS_UID"));
        }

        [TestMethod]
        public void ProcessLiveHours_WhenUserHasPermissions_ConfirmResult()
        {
            // Arrange
            SetupForProcessLiveHoursMethod(true);

            // Act
            _privateObject.Invoke(ProcessLiveHoursMethod, DummyString, Guid.NewGuid(), new ShimSPList().Instance);

            // Assert
            _systemUpdate.ShouldBeTrue();
        }

        [TestMethod]
        public void ProcessLiveHours_WhenUserDoesNotHavePermissions_ConfirmResult()
        {
            // Arrange
            SetupForProcessLiveHoursMethod(false);

            // Act
            _privateObject.Invoke(ProcessLiveHoursMethod, DummyString, Guid.NewGuid(), new ShimSPList().Instance);

            // Assert
            _systemUpdate.ShouldBeTrue();
        }

        private void SetupForProcessLiveHoursMethod(bool doesUserHavePermissions)
        {
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => DummyInt.ToString();
            ShimSPList.AllInstances.ParentWebGet = _ => _web;
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.IsDBNullInt32 = (_, __) => false;
            ShimSqlDataReader.AllInstances.GetDoubleInt32 = (_, __) => DummyInt;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => doesUserHavePermissions;
        }

        [TestMethod]
        public void ProcessWssItem_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupForProcessWssItemMethod(string.Empty);

            // Act
            _privateObject.Invoke(ProcessWssItemMethod, DummyString, _web.Instance, new ShimSPList().Instance);

            // Assert
            var output = _privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => _listItemUpdated.ShouldBeTrue(),
                () => output.ShouldBe($"<action type='updatewss' sid='{DummyString}' tid='{DummyString}'/>"));
        }

        [TestMethod]
        public void ProcessWssItem_WhenListTitleIsEqualEPMLiveTSNonWork_ConfirmResult()
        {
            // Arrange
            SetupForProcessWssItemMethod(DummyString);

            // Act
            _privateObject.Invoke(ProcessWssItemMethod, DummyString, _web.Instance, new ShimSPList().Instance);

            // Assert
            var output = _privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => _listItemUpdated.ShouldBeFalse(),
                () => output.ShouldBe($"<action type='updatewss' sid='{DummyString}' tid='{DummyString}'/>"));
        }

        private void SetupForProcessWssItemMethod(string listTitle)
        {
            var strFields = new string[]
            {
                UserMulti,
                UserField,
                PercentField,
                NumberField,
                LookupField,
                MultiChoiceField,
                DateTimeField,
                ChoiceField,
                TextField
            };
            _privateObject.SetField(StrFields, strFields);
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimHttpRequest.AllInstances.ItemGetString = (_, item) =>
            {
                if (item.Contains(ItemIdParameter) || item.Contains("_c4"))
                {
                    return DummyInt.ToString();
                }
                if (item.Contains("_c8"))
                {
                    return DateTime.MinValue.ToString();
                }
                return DummyString;
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.TitleGet = _ => listTitle;
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.ItemGetString = (_, __) => new ShimSPUser();
            ShimSPFieldUserValue.ConstructorSPWebInt32String = (_, _1, _2, _3) => { };
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField()
            {
                TitleGet = () => DummyString,
                InternalNameGet = () => name,
                ReadOnlyFieldGet = () => false,
                ShowInEditFormGet = () => null,
                TypeAsStringGet = () => name,
                TypeGet = () =>
                {
                    switch (name)
                    {
                        case UserMulti:
                        case UserField:
                            return SPFieldType.User;
                        case PercentField:
                        case NumberField:
                            return SPFieldType.Number;
                        case LookupField:
                            return SPFieldType.Lookup;
                        case MultiChoiceField:
                            return SPFieldType.MultiChoice;
                        case DateTimeField:
                            return SPFieldType.DateTime;
                        case ChoiceField:
                            return SPFieldType.Choice;
                        default:
                            return SPFieldType.Text;
                    }
                },
                SchemaXmlGet = () => name == PercentField ? "<xml Percentage=\"TRUE\" />" : "<xml />"
            };
        }

        [TestMethod]
        public void ProcessItem_WhenItemIdIsEmpty_ConfirmResult()
        {
            // Arrange, Act
            _privateObject.Invoke(ProcessItemMethod, DummyString, _web.Instance, new ShimSPList().Instance, new ShimSPList().Instance);

            // Assert
            _privateObject.GetField(OutputField).ShouldBe($"<action type='update' sid='{DummyString}'/>");
        }

        [TestMethod]
        public void ProcessItem_WhenStatusIsDeleted_ConfirmResult()
        {
            // Arrange
            var sqlCommands = new List<string>();
            ShimHttpRequest.AllInstances.ItemGetString = (_, item) =>
            {
                if (item.Contains(ItemIdParameter))
                {
                    return DummyInt.ToString();
                }
                if (item.Contains("_!nativeeditor_status"))
                {
                    return "deleted";
                }
                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                sqlCommands.Add(instance.CommandText);
                return DummyInt;
            };

            // Act
            _privateObject.Invoke(ProcessItemMethod, DummyString, _web.Instance, new ShimSPList().Instance, new ShimSPList().Instance);

            // Assert
            var output = _privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldBe($"<action type='delete' sid='{DummyString}'/>"),
                () => sqlCommands.ShouldContain("DELETE from tsitemhours where ts_item_uid=@itemuid"),
                () => sqlCommands.ShouldContain("DELETE from tsitem where ts_item_uid=@itemuid"));
        }

        [TestMethod]
        public void ProcessItem_WhenTimeEditorIsTrue_ConfirmResult()
        {
            // Arrange
            SetupForProcessItemMethod(true);

            // Act
            _privateObject.Invoke(ProcessItemMethod, DummyString, _web.Instance, new ShimSPList().Instance, new ShimSPList().Instance);

            // Assert
            var output = _privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldBe($"<action type='updateitem' sid='{DummyString}' tid='{DummyString}' tsitemuid='{DummyString}'/>"),
                () => _sqlCommands.ShouldContain("UPDATE tsitem set title = @title, approval_status = 0,project_list_uid=@projectlistuid where ts_item_uid=@itemuid"),
                () => _sqlCommands.ShouldContain("DELETE from tsitemhours where ts_item_uid=@itemuid"),
                () => _sqlCommands.ShouldContain("DELETE from tsnotes where ts_item_uid=@itemuid"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSNOTES (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_NOTES) VALUES (@itemuid,@itemdate,@notes)"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,@type)"));
        }

        [TestMethod]
        public void ProcessItem_WhenTimeEditorIsFalse_ConfirmResult()
        {
            // Arrange
            SetupForProcessItemMethod(false);

            // Act
            _privateObject.Invoke(ProcessItemMethod, DummyString, _web.Instance, new ShimSPList().Instance, new ShimSPList().Instance);

            // Assert
            var output = _privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldBe($"<action type='updateitem' sid='{DummyString}' tid='{DummyString}' tsitemuid='{DummyString}'/>"),
                () => _sqlCommands.ShouldContain("UPDATE tsitem set title = @title, approval_status = 0,project_list_uid=@projectlistuid where ts_item_uid=@itemuid"),
                () => _sqlCommands.ShouldContain("DELETE from tsitemhours where ts_item_uid=@itemuid"),
                () => _sqlCommands.ShouldContain("DELETE from tsnotes where ts_item_uid=@itemuid"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,0)"));
        }

        [TestMethod]
        public void ProcessItem_WhenTsItemUidDoesNotHaveValue_ConfirmResult()
        {
            // Arrange
            SetupForProcessItemMethod(true, false);

            // Act
            _privateObject.Invoke(ProcessItemMethod, DummyString, _web.Instance, new ShimSPList().Instance, new ShimSPList().Instance);

            // Assert
            var output = (string)_privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldContain($"<action type='updateitem' sid='{DummyString}' tid='{DummyString}' tsitemuid='"),
                () => _processMetaCalled.ShouldBeTrue(),
                () => _sqlCommands.ShouldContain("INSERT INTO TSTIMESHEET (TS_UID,USERNAME,PERIOD_ID,SITE_UID,resourcename) VALUES (@TS_UID,@USERNAME,@PERIOD_ID,@SITE_UID,@resourcename)"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSITEM (TS_UID,TS_ITEM_UID,WEB_UID,LIST_UID,ITEM_TYPE,ITEM_ID,TITLE,PROJECT,PROJECT_ID,LIST,PROJECT_LIST_UID,Rate) VALUES (@TS_UID,@TS_ITEM_UID,@WEB_UID,@LIST_UID,@ITEM_TYPE,@ITEM_ID,@TITLE,@PROJECT,@PROJECT_ID,@LIST,@projectlistuid,@rate)"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSNOTES (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_NOTES) VALUES (@itemuid,@itemdate,@notes)"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,@type)"));
        }

        [TestMethod]
        public void ProcessItem_WhenTsItemUidDoesNotHaveValueAndTimeEditorIsFalse_ConfirmResult()
        {
            // Arrange
            SetupForProcessItemMethod(false, false);

            // Act
            _privateObject.Invoke(ProcessItemMethod, DummyString, _web.Instance, new ShimSPList().Instance, new ShimSPList().Instance);

            // Assert
            var output = (string)_privateObject.GetField(OutputField);
            this.ShouldSatisfyAllConditions(
                () => output.ShouldContain($"<action type='updateitem' sid='{DummyString}' tid='{DummyString}' tsitemuid='"),
                () => _processMetaCalled.ShouldBeTrue(),
                () => _sqlCommands.ShouldContain("INSERT INTO TSTIMESHEET (TS_UID,USERNAME,PERIOD_ID,SITE_UID,resourcename) VALUES (@TS_UID,@USERNAME,@PERIOD_ID,@SITE_UID,@resourcename)"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSITEM (TS_UID,TS_ITEM_UID,WEB_UID,LIST_UID,ITEM_TYPE,ITEM_ID,TITLE,PROJECT,PROJECT_ID,LIST,PROJECT_LIST_UID,Rate) VALUES (@TS_UID,@TS_ITEM_UID,@WEB_UID,@LIST_UID,@ITEM_TYPE,@ITEM_ID,@TITLE,@PROJECT,@PROJECT_ID,@LIST,@projectlistuid,@rate)"),
                () => _sqlCommands.ShouldContain("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,0)"));
        }

        private void SetupForProcessItemMethod(bool timeEditor, bool tsItemUidHasValue = true)
        {
            const string TrueValue = "True";
            var dayDefs = new string[]
            {
                TrueValue, TrueValue, TrueValue, TrueValue
            };
            _privateObject.SetField(DayDefsField, dayDefs);
            _privateObject.SetField(TimeEditorField, timeEditor);
            ShimHttpRequest.AllInstances.ItemGetString = (_, item) =>
            {
                if (item.Contains(ItemIdParameter) || item.Contains(FieldCountParameter) || item.Contains(DateCountParameter))
                {
                    return DummyInt.ToString();
                }
                if (item.Contains(FirstDateParameter))
                {
                    return DateTime.MinValue.ToString();
                }
                if (item.Contains("_c3"))
                {
                    return timeEditor ? "N|Y|Y|1" : DummyInt.ToString();
                }
                if (item.Contains(TsItemUidParameter))
                {
                    return tsItemUidHasValue ? DummyString : string.Empty;
                }
                if (item == TsUidParameter)
                {
                    return string.Empty;
                }
                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                _sqlCommands.Add(instance.CommandText);
                return DummyInt;
            };
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimSharedFunctions.GetStandardRatesSqlConnectionStringSPWebStringString = (_1, _2, _3, _4, _5) => DummyString;
            ShimSharedFunctions.processMetaSPWebSPListSPListItemGuidStringSqlConnectionSPList = (_1, _2, _3, _4, _5, _6, _7) => _processMetaCalled = true;
        }
    }
}
