using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin.Layouts.EPMLive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests.Layouts.EPMLive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportScheduleTests
    {
        private IDisposable _shimContext;
        private ReportSchedule _testObject;
        private PrivateObject _privateObject;
        private ShimEPMData _shimDao;

        private const string PageInitMethodName = "Page_Init";
        private const string DropDownListScheduleTypeSelectedIndexChangedMethodName = "DropDownListScheduleType_SelectedIndexChanged";
        private const string ScheduleValidMethodName = "ScheduleValid";
        private const string Button1ClickMethodName = "Button1_Click";
        private const string SaveSettingsMethodName = "saveSettings";
        private const string GetOptionsMethodName = "GetOptions";
        private const string PageLoadCompleteMethodName = "Page_LoadComplete";

        private readonly static Guid DummySiteGuid = new Guid("562ea67b-cda9-4741-a302-321991b62b34");
        private readonly static Guid DummyGuid = new Guid("a2784748-e197-4d0c-bc9a-4c163cc7d9d7");
        private readonly static Guid DummyGuid2 = new Guid("b6057596-2415-4a53-a5a1-ef304d9f2cec");
        private const string DummyString = "DummyString";
        private const string DummyListName = "DummyListName";
        private const string DummyJobName = "DummyJobName";
        private const string DummyUrl = "/Dummy/Url/";
        private const string DummyUrl2 = "/Dummy/Url2";
        private const string JobNameField = "jobname";
        private const string RunTimeField = "runtime";
        private const string ScheduleTypeField = "scheduletype";
        private const string DaysField = "days";
        private const string JobDataField = "jobdata";
        private const string ListNameField = "ListName";
        private const string JobTypeField = "jobtype";
        private const string EnabledField = "enabled";
        private const string SiteGuidField = "siteguid";
        private const string WebGuidField = "webguid";
        private const string ListGuidField = "listguid";
        private const string LastQueueCheckField = "lastqueuecheck";
        private const string ParentJobUidField = "parentjobuid";
        private const string TimeJobUidField = "timejobuid";
        private const string SelectListNameFromRptList = "SELECT ListName FROM RPTList WHERE SiteId=@siteId";
        private const string SelectFromTimerJobs = "SELECT * FROM TIMERJOBS WHERE timerjobuid=@uid";
        private const string InsertTimerJobs = "INSERT INTO TIMERJOBS ([timerjobuid],[jobname],[siteguid],[webguid],[listguid],[jobtype],[enabled],[runtime],[scheduletype],[days],[jobdata],[lastqueuecheck],[parentjobuid])  VALUES(@timejobuid,@jobname,@siteguid,@webguid,@listguid,@jobtype,@enabled,@runtime,@scheduletype,@days,@jobdata,@lastqueuecheck,@parentjobuid)";
        private const string UpdateTimerJobs = "UPDATE TIMERJOBS SET jobname=@jobname,enabled=@enabled,scheduletype=@scheduletype,runtime=@runtime,days=@days,jobdata=@jobdata WHERE timerjobuid=@timerjobuid";
        private const string LabelErrorSiteField = "lblErrorSite";
        private const string TextScheduleTitleField = "txtScheduleTitle";
        private const string DropDownListScheduleTypeField = "DropDownListScheduleType";
        private const string DropDownListSnapshotTimeField = "DropDownListSnapshotTime";
        private const string CheckBoxListDaysField = "CheckBoxList_days";
        private const string ListBoxListsField = "ListBoxLists";
        private const string DropDownListDaysField = "DropDownListDays";
        private const string UidField = "uid";
        private CheckBoxList _checkBoxListDays;
        private DropDownList _dropDownListScheduleType;
        private DropDownList _dropDownListSnapshotTime;
        private DropDownList _dropDownListDays;
        private Label _labelErrorSite;
        private ListBox _listBoxLists;
        private TextBox _textScheduleTitle;

        private readonly StringBuilder _actualResponseMessage = new StringBuilder();
        private string _actualRedirect;

        private string _actualCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testObject = new ReportSchedule();
            _privateObject = new PrivateObject(_testObject);

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimPage.AllInstances.ResponseGet = sender => new ShimHttpResponse()
            {
                CacheGet = () => new ShimHttpCachePolicy()
                {
                    SetCacheabilityHttpCacheability = httpCacheability => { }
                },
                ExpiresSetInt32 = expireParam => { },
                WriteString = stringToWrite => _actualResponseMessage.Append(stringToWrite),
                RedirectString = url => _actualRedirect = url
            };
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                QueryStringGet = () => new NameValueCollection()
                {
                    { UidField, "cfe9a731-baf5-49d4-8457-dd19d08e7d5e" }
                }
            };
            CreateFields();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
            _testObject?.Dispose();
        }

        [TestMethod]
        public void PageInit_DropDownListScheduleType2_UpdateProperties()
        {
            // Arrange, Act
            DefaultPageInit();

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _labelErrorSite.Visible.ShouldBeFalse(),
                () => _listBoxLists.Items.Count.ShouldBe(1),
                () => _listBoxLists.Items[0].Selected.ShouldBeTrue(),
                () => _dropDownListScheduleType.SelectedValue.ShouldBe("2"),
                () => _dropDownListDays.SelectedValue.ShouldBe("1"),
                () => _dropDownListDays.Visible.ShouldBeFalse(),
                () => _checkBoxListDays.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void PageInit_DropDownListScheduleType3_UpdateProperties()
        {
            // Arrange
            ShimEPMData.ConstructorGuid = (sender, siteGuid) =>
            {
                _shimDao = new ShimEPMData(sender)
                {
                    remoteCsGet = () => DummyString,
                    OpenClientReportingConnectionSetString = remoteCs => { },
                    CommandSetString = commandParam => _actualCommand = commandParam,
                    AddParamStringObject = (nameParam, valueParam) => { },
                    GetTableSqlConnection = sqlConnection =>
                    {
                        var dataTable = new DataTable();

                        if (_actualCommand == SelectListNameFromRptList)
                        {
                            dataTable.Columns.Add(ListNameField);

                            var row = dataTable.NewRow();
                            row[ListNameField] = DummyListName;
                            dataTable.Rows.Add(row);
                        }

                        if (_actualCommand == SelectFromTimerJobs)
                        {
                            dataTable.Columns.Add(JobNameField);
                            dataTable.Columns.Add(RunTimeField);
                            dataTable.Columns.Add(ScheduleTypeField);
                            dataTable.Columns.Add(DaysField);
                            dataTable.Columns.Add(JobDataField);

                            var row = dataTable.NewRow();
                            row[JobNameField] = DummyJobName;
                            row[RunTimeField] = 1;
                            row[ScheduleTypeField] = 3;
                            row[DaysField] = 4;
                            row[JobDataField] = $"{DummyListName},{DummyString}";
                            dataTable.Rows.Add(row);
                        }

                        return dataTable;
                    },
                    GetEPMLiveConnectionGet = () => new ShimSqlConnection(),
                    GetClientReportingConnectionGet = () => new ShimSqlConnection()
                };
            };

            // Act
            _privateObject.Invoke(PageInitMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _labelErrorSite.Visible.ShouldBeFalse(),
                () => _listBoxLists.Items.Count.ShouldBe(1),
                () => _listBoxLists.Items[0].Selected.ShouldBeTrue(),
                () => _dropDownListScheduleType.SelectedValue.ShouldBe("3"),
                () => _dropDownListDays.SelectedValue.ShouldBe("4"),
                () => _dropDownListDays.Visible.ShouldBeTrue(),
                () => _checkBoxListDays.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void PageInit_CatchException_ResponseWrite()
        {
            // Arrange
            ShimEPMData.ConstructorGuid = (sender, siteGuid) =>
            {
                _shimDao = new ShimEPMData(sender)
                {
                    remoteCsGet = () => DummyString,
                    OpenClientReportingConnectionSetString = remoteCs => { },
                    CommandSetString = commandParam => _actualCommand = commandParam,
                    AddParamStringObject = (nameParam, valueParam) => { }
                };
            };

            // Act
            _privateObject.Invoke(PageInitMethodName, this, EventArgs.Empty);

            // Assert
            _actualResponseMessage.ToString().ShouldBe("Error: Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void DropDownListScheduleTypeSelectedIndexChanged_SelectedValue3_UpdateProperties()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _dropDownListScheduleType.SelectedValue = "3";

            // Act
            _privateObject.Invoke(DropDownListScheduleTypeSelectedIndexChangedMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _dropDownListDays.Visible.ShouldBeTrue(),
                () => _checkBoxListDays.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void DropDownListScheduleTypeSelectedIndexChanged_SelectedValue5_UpdateProperties()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _dropDownListScheduleType.SelectedValue = "5";

            // Act
            _privateObject.Invoke(DropDownListScheduleTypeSelectedIndexChangedMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _dropDownListDays.Visible.ShouldBeFalse(),
                () => _checkBoxListDays.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void ScheduleValid_TxtScheduleTitleTextEmpty_ReturnsFalse()
        {
            // Arrange, Act
            var actualResult = (bool)_privateObject.Invoke(ScheduleValidMethodName);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void ScheduleValid_GetOptionsEmpty_ReturnsFalse()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _checkBoxListDays.Items.FindByValue("3").Selected = false;

            // Act
            var actualResult = (bool)_privateObject.Invoke(ScheduleValidMethodName);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void ScheduleValid_OnValidCall_ReturnsTrue()
        {
            // Arrange
            DefaultPageInit();

            // Act
            var actualResult = (bool)_privateObject.Invoke(ScheduleValidMethodName);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void ScheduleValid_DropDownListSnapshotTimeSelectedValueEmpty_ReturnsFalse()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _dropDownListSnapshotTime.SelectedValue = string.Empty;

            // Act
            var actualResult = (bool)_privateObject.Invoke(ScheduleValidMethodName);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void ScheduleValid_ListBoxListsSelectedValueEmpty_ReturnsFalse()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _listBoxLists.SelectedValue = null;

            // Act
            var actualResult = (bool)_privateObject.Invoke(ScheduleValidMethodName);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void Button1Click_UrlEndWithSlash_ResponseRedirect()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _textScheduleTitle.Text = string.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    ServerRelativeUrlGet = () => DummyUrl
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                }
            };

            // Act
            _privateObject.Invoke(Button1ClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _labelErrorSite.Visible.ShouldBeTrue(),
                () => _labelErrorSite.Text.ShouldBe("Invalid value. Please check your settings and try again."),
                () => _actualRedirect.ShouldBe($"{DummyUrl}/_layouts/epmlive/AllSnapShots.aspx"));
        }

        [TestMethod]
        public void Button1Click_UrlEndWithoutSlash_ResponseRedirect()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _textScheduleTitle.Text = string.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    ServerRelativeUrlGet = () => DummyUrl2
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                }
            };

            // Act
            _privateObject.Invoke(Button1ClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _labelErrorSite.Visible.ShouldBeTrue(),
                () => _labelErrorSite.Text.ShouldBe("Invalid value. Please check your settings and try again."),
                () => _actualRedirect.ShouldBe($"{DummyUrl2}/_layouts/epmlive/AllSnapShots.aspx"));
        }

        [TestMethod]
        public void Button1Click_CatchException_ResponseWrite()
        {
            // Arrange
            DefaultPageInit();

            // Act
            _privateObject.Invoke(Button1ClickMethodName, this, EventArgs.Empty);

            // Assert
            _actualResponseMessage.ToString().ShouldBe("Error: Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void SaveSettings_AddNewJob_DaoInsertLabelErrorVisibleFalse()
        {
            // Arrange
            var actualParam = new Dictionary<string, object>();

            DefaultPageInit();
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                QueryStringGet = () => new NameValueCollection()
                {
                    { UidField, null }
                }
            };

            _shimDao.ExecuteNonQuerySqlConnection = sqlConnection => true;
            _shimDao.AddParamStringObject = (nameParam, valueParam) => actualParam.Add(nameParam, valueParam);

            var currentWeb = new ShimSPWeb()
            {
                IDGet = () => DummyGuid,
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummyGuid2
                }
            };

            // Act
            _privateObject.Invoke(SaveSettingsMethodName, currentWeb.Instance);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _actualCommand.ShouldBe(InsertTimerJobs),
                () => actualParam.ShouldContainKey($"@{TimeJobUidField}"),
                () => actualParam[$"@{TimeJobUidField}"].ShouldBeOfType<Guid>(),
                () => actualParam.ShouldContainKeyAndValue($"@{JobNameField}", DummyJobName),
                () => actualParam.ShouldContainKeyAndValue($"@{SiteGuidField}", DummyGuid2),
                () => actualParam.ShouldContainKeyAndValue($"@{WebGuidField}", DummyGuid),
                () => actualParam.ShouldContainKeyAndValue($"@{ListGuidField}", DBNull.Value),
                () => actualParam.ShouldContainKeyAndValue($"@{JobTypeField}", 7),
                () => actualParam.ShouldContainKeyAndValue($"@{EnabledField}", true),
                () => actualParam.ShouldContainKeyAndValue($"@{RunTimeField}", 1),
                () => actualParam.ShouldContainKeyAndValue($"@{ScheduleTypeField}", 2),
                () => actualParam.ShouldContainKeyAndValue($"@{DaysField}", "3"),
                () => actualParam.ShouldContainKeyAndValue($"@{JobDataField}", DummyListName),
                () => actualParam.ShouldContainKeyAndValue($"@{LastQueueCheckField}", DBNull.Value),
                () => actualParam.ShouldContainKeyAndValue($"@{ParentJobUidField}", DBNull.Value),
                () => _labelErrorSite.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void SaveSettings_UpdateJob_DaoUpdateLabelErrorVisibleFalse()
        {
            // Arrange
            var actualParam = new Dictionary<string, object>();
            var actualLogStatusCalled = false;

            DefaultPageInit();
            _shimDao.ExecuteNonQuerySqlConnection = sqlConnection => true;
            _shimDao.AddParamStringObject = (nameParam, valueParam) => actualParam.Add(nameParam, valueParam);
            _shimDao.SqlErrorOccurredGet = () => true;
            _shimDao.LogStatusStringStringStringStringInt32Int32String = (
                rptListId,
                listName,
                shortMsg,
                longMsg,
                level,
                typeParam,
                timerJobGuid) =>
            {
                actualLogStatusCalled = true;
                return true;
            };

            var currentWeb = new ShimSPWeb()
            {
                IDGet = () => DummyGuid,
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummyGuid2
                }
            };

            // Act
            _privateObject.Invoke(SaveSettingsMethodName, currentWeb.Instance);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _actualCommand.ShouldBe(UpdateTimerJobs),
                () => actualParam.ShouldContainKeyAndValue($"@{JobNameField}", DummyJobName),
                () => actualParam.ShouldContainKeyAndValue($"@{EnabledField}", true),
                () => actualParam.ShouldContainKeyAndValue($"@{RunTimeField}", 1),
                () => actualParam.ShouldContainKeyAndValue($"@{ScheduleTypeField}", 2),
                () => actualParam.ShouldContainKeyAndValue($"@{DaysField}", "3"),
                () => actualParam.ShouldContainKeyAndValue($"@{JobDataField}", DummyListName),
                () => _labelErrorSite.Visible.ShouldBeFalse(),
                () => actualLogStatusCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetOptions_DropDownListScheduleTypeSelectedValue3_ReturnsDropDownListDaysSelectedValue()
        {
            // Arrange
            DefaultPageInit();
            LoadFields();
            _dropDownListScheduleType.SelectedValue = "3";

            // Act
            var actualResult = (string)_privateObject.Invoke(GetOptionsMethodName);

            // Assert
            actualResult.ShouldBe("1");
        }

        [TestMethod]
        public void PageLoadComplete_OnValidCall_InvokeDisposeFromDao()
        {
            // Arrange
            var disposeCalled = false;
            DefaultPageInit();
            _shimDao.Dispose = () => disposeCalled = true;

            // Act
            _privateObject.Invoke(PageLoadCompleteMethodName, this, EventArgs.Empty);

            // Assert
            disposeCalled.ShouldBeTrue();
        }

        private void CreateFields()
        {
            _privateObject.SetField(LabelErrorSiteField, new Label() { Visible = false });
            _privateObject.SetField(TextScheduleTitleField, new TextBox());

            var dropDownListScheduleType = new DropDownList();
            dropDownListScheduleType.Items.Add(new ListItem("Daily", "2", true));
            dropDownListScheduleType.Items.Add(new ListItem("Monthly", "3", true));
            _privateObject.SetField(DropDownListScheduleTypeField, dropDownListScheduleType);

            var dropDownListSnapshotTime = new DropDownList();
            dropDownListSnapshotTime.Items.Add(new ListItem("Disabled", string.Empty, true));
            dropDownListSnapshotTime.Items.Add(new ListItem("1:00 AM", "1", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("2:00 AM", "2", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("3:00 AM", "3", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("4:00 AM", "4", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("5:00 AM", "5", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("6:00 AM", "6", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("7:00 AM", "7", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("8:00 AM", "8", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("9:00 AM", "9", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("10:00 AM", "10", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("11:00 AM", "11", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("12:00 PM", "12", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("1:00 PM", "13", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("2:00 PM", "14", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("3:00 PM", "15", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("4:00 PM", "16", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("5:00 PM", "17", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("6:00 PM", "18", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("7:00 PM", "19", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("8:00 PM", "20", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("9:00 PM", "21", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("10:00 PM", "22", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("11:00 PM", "23", true));
            dropDownListSnapshotTime.Items.Add(new ListItem("12:00 AM", "0", true));
            _privateObject.SetField(DropDownListSnapshotTimeField, dropDownListSnapshotTime);

            var checkBoxListDays = new CheckBoxList();
            checkBoxListDays.Items.Add(new ListItem("Monday", "1"));
            checkBoxListDays.Items.Add(new ListItem("Tuesday", "2"));
            checkBoxListDays.Items.Add(new ListItem("Wednesday", "3"));
            checkBoxListDays.Items.Add(new ListItem("Thursday", "4"));
            checkBoxListDays.Items.Add(new ListItem("Friday", "5"));
            checkBoxListDays.Items.Add(new ListItem("Saturday", "6"));
            checkBoxListDays.Items.Add(new ListItem("Sunday", "7"));
            _privateObject.SetField(CheckBoxListDaysField, checkBoxListDays);

            var dropDownListDays = new DropDownList();

            for (var i = 1; i <= 31; i++)
            {
                dropDownListDays.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            _privateObject.SetField(DropDownListDaysField, dropDownListDays);

            _privateObject.SetField(ListBoxListsField, new ListBox());
        }

        private void DefaultPageInit()
        {
            ShimEPMData.ConstructorGuid = (sender, siteGuid) =>
            {
                _shimDao = new ShimEPMData(sender)
                {
                    remoteCsGet = () => DummyString,
                    OpenClientReportingConnectionSetString = remoteCs => { },
                    CommandSetString = commandParam => _actualCommand = commandParam,
                    AddParamStringObject = (nameParam, valueParam) => { },
                    GetTableSqlConnection = sqlConnection =>
                    {
                        var dataTable = new DataTable();

                        if (_actualCommand == SelectListNameFromRptList)
                        {
                            dataTable.Columns.Add(ListNameField);

                            var row = dataTable.NewRow();
                            row[ListNameField] = DummyListName;
                            dataTable.Rows.Add(row);
                        }

                        if (_actualCommand == SelectFromTimerJobs)
                        {
                            dataTable.Columns.Add(JobNameField);
                            dataTable.Columns.Add(RunTimeField);
                            dataTable.Columns.Add(ScheduleTypeField);
                            dataTable.Columns.Add(DaysField);
                            dataTable.Columns.Add(JobDataField);

                            var row = dataTable.NewRow();
                            row[JobNameField] = DummyJobName;
                            row[RunTimeField] = 1;
                            row[ScheduleTypeField] = 2;
                            row[DaysField] = 3;
                            row[JobDataField] = $"{DummyListName},{DummyString}";
                            dataTable.Rows.Add(row);
                        }

                        return dataTable;
                    },
                    GetEPMLiveConnectionGet = () => new ShimSqlConnection(),
                    GetClientReportingConnectionGet = () => new ShimSqlConnection()
                };
            };
            _privateObject.Invoke(PageInitMethodName, this, EventArgs.Empty);
        }

        private void LoadFields()
        {
            _labelErrorSite = (Label)_privateObject.GetField(LabelErrorSiteField);
            _textScheduleTitle = (TextBox)_privateObject.GetField(TextScheduleTitleField);
            _dropDownListScheduleType = (DropDownList)_privateObject.GetField(DropDownListScheduleTypeField);
            _dropDownListSnapshotTime = (DropDownList)_privateObject.GetField(DropDownListSnapshotTimeField);
            _checkBoxListDays = (CheckBoxList)_privateObject.GetField(CheckBoxListDaysField);
            _listBoxLists = (ListBox)_privateObject.GetField(ListBoxListsField);
            _dropDownListDays = (DropDownList)_privateObject.GetField(DropDownListDaysField);
        }
    }
}
