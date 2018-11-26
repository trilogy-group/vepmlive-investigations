using System.Data;
using System.Xml;
using System.Xml.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    public partial class EditCostsTests
    {
        [TestMethod]
        public void SaveEditCostsData_ValidData_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();
            CustomFieldSelectAllType();

            ShimIntegration.AllInstances.executeStringString = (sender, commandMethod, commandText) =>
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<Result Status=\"0\">DummyString</Result>");
                return xmlDoc.SelectSingleNode("/Result");
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe("<Grid><IO Result=\"0\"/></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_InvalidData_ReturnsStringError()
        {
            // Arrange, Act
            var actualResult = _testEntity.SaveEditCostsData(string.Empty, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe("<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;Unable to load XML\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_SelectProjectByExtUidFail_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dba, string sExtUid, out int nProjectId) =>
            {
                nProjectId = 0;
                return StatusEnum.rsWSSUnknownError;
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;Unable to convert wepid '{wepId}' to ProjectID\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_SelectProjectByExtUidProjectNotFound_ReturnsString()
        {
            // Arrange
            var wepId = string.Empty;

            SetupShimDbaEditCosts();

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe("<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;Invalid ProjectID\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_CalendarInfoNotFound_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimdbaEditCosts.SelectViewCalendarInfoDBAccessInt32Int32OutInt32OutInt32Out = (DBAccess dba, int viewUid, out int calendarId, out int firstPeriod, out int lastPeriod) =>
            {
                calendarId = -1;
                firstPeriod = 0;
                lastPeriod = 0;
                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe("<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;Invalid Calendar\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_CustomField11801NotFound_ReturnsString()
        {
            // Arrange
            var data = "<Root><Body><B><I Visible=\"1\" id=\"I60\"  Changed=\"1\"/></B></Body></Root>";

            SetupShimDbaEditCosts();
            ShimdbaEditCosts.SelectCostCustomFieldsDBAccessInt32DataTableOut = (DBAccess dba, int nCostTypeId, out DataTable dataTable) =>
            {
                dataTable = CreateDataTableCustomField();

                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11801));

                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(data, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;{DummyCustomFieldName}{CustomFieldId11801} is a required code field&#xA;&#xA;Category = &quot;&quot;;&#xA;\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_CustomField11811NotFound_ReturnsString()
        {
            // Arrange
            var data = "<Root><Body><B><I Visible=\"1\" id=\"I60\" Changed=\"1\"/></B></Body></Root>";

            SetupShimDbaEditCosts();
            ShimdbaEditCosts.SelectCostCustomFieldsDBAccessInt32DataTableOut = (DBAccess dba, int nCostTypeId, out DataTable dataTable) =>
            {
                dataTable = CreateDataTableCustomField();

                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11811));

                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(data, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;{DummyCustomFieldName}{CustomFieldId11811} is a required text field&#xA;&#xA;Category = &quot;&quot;;&#xA;\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_IdFoundTwice_ReturnsString()
        {
            // Arrange
            var data = "<Root><Body><B><I Visible=\"1\" id=\"I60\" /><I Visible=\"1\" id=\"I60\" /></B></Body></Root>";

            SetupShimDbaEditCosts();
            ShimdbaEditCosts.SelectCostCustomFieldsDBAccessInt32DataTableOut = (DBAccess dba, int nCostTypeId, out DataTable dataTable) =>
            {
                dataTable = CreateDataTableCustomField();

                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11801));

                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(data, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            actualResult.ShouldBe("<Grid><IO Result=\"-10\" Message=\"Error saving Cost data&#xA;&#xA;Two or more rows found with the same identity:&#xA;&#xA;Category = &quot;&quot;;&#xA;DummyCustomFieldName11801 = &quot;&quot;;&#xA;\" /></Grid>");
        }

        [TestMethod]
        public void SaveEditCostsData_AdminRows2_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = (DBAccess dba, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("ADM_WE_SERVERURL", typeof(string));

                var dataRow = dataTable.NewRow();
                dataRow["ADM_WE_SERVERURL"] = "http://tempuri.org";

                dataTable.Rows.Add(dataRow);

                var dataRow2 = dataTable.NewRow();
                dataRow2["ADM_WE_SERVERURL"] = "http://tempuri.org";

                dataTable.Rows.Add(dataRow2);

                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("<Grid><IO Result=\"-11\" Message=\"DBAccess Status Exception in EditCosts.asmx.cs&#xA;&#xA;Context=SaveEditCostsData&#xA;&#xA;Text=;\" /></Grid>"),
                () => _currentStatus.ShouldBe((StatusEnum)99836),
                () => _currentStatusText.ShouldBe("Invalid Admin row count : 2"));
        }

        [TestMethod]
        public void SaveEditCostsData_SendXmlToWorkEngineReturnNull_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimIntegration.AllInstances.executeStringString = (sender, commandMethod, commandText) => null;

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("<Grid><IO Result=\"-11\" Message=\"DBAccess Status Exception in EditCosts.asmx.cs&#xA;&#xA;Context=SaveEditCostsData&#xA;&#xA;Text=;\" /></Grid>"),
                () => _currentStatus.ShouldBe((StatusEnum)99835),
                () => _currentStatusText.ShouldBe("No response from WorkEngine WebService"));
        }

        [TestMethod]
        public void SaveEditCostsData_SendXmlToWorkEngineReturnXmlInvalid_ReturnsString()
        {
            // Arrange
            const string XmlInvalid = "<Grid></Node>";

            SetupShimDbaEditCosts();

            ShimIntegration.AllInstances.executeStringString = (sender, commandMethod, commandText) =>
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<Result Status=\"0\">DummyString</Result>");
                return xmlDoc.SelectSingleNode("/Result");
            };
            ShimXmlNode.AllInstances.OuterXmlGet = sender => XmlInvalid;

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe(XmlInvalid),
                () => _currentStatus.ShouldBe((StatusEnum)99832),
                () => _currentStatusText.ShouldBe(string.Empty));
        }

        [TestMethod]
        public void SaveEditCostsData_Status1WithoutErrorStruct_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimIntegration.AllInstances.executeStringString = (sender, commandMethod, commandText) =>
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<Result Status=\"1\"><Item ID=\"1\" Error=\"102\"><![CDATA[Error Processing Item: Index was outside the bounds of the array.]]></Item></Result>");
                return xmlDoc.SelectSingleNode("/Result");
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("<Grid><IO Result=\"-11\" Message=\"DBAccess Status Exception in EditCosts.asmx.cs&#xA;&#xA;Context=SaveEditCostsData&#xA;&#xA;Text=;\" /></Grid>"),
                () => _currentStatus.ShouldBe((StatusEnum)99999),
                () => _currentStatusText.ShouldBe("Invalid XML response from WorkEngine WebService. Status=1; Error=102 : Error Processing Item: Index was outside the bounds of the array."));
        }

        [TestMethod]
        public void SaveEditCostsData_Status1WithoutErrorAndItemStruct_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimIntegration.AllInstances.executeStringString = (sender, commandMethod, commandText) =>
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<Result Status=\"1\"></Result>");
                return xmlDoc.SelectSingleNode("/Result");
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("<Grid><IO Result=\"-11\" Message=\"DBAccess Status Exception in EditCosts.asmx.cs&#xA;&#xA;Context=SaveEditCostsData&#xA;&#xA;Text=;\" /></Grid>"),
                () => _currentStatus.ShouldBe((StatusEnum)99999),
                () => _currentStatusText.ShouldBe("XML response from WorkEngine WebService not recognized"));
        }

        [TestMethod]
        public void SaveEditCostsData_Status1WithErrorStruct_ReturnsString()
        {
            // Arrange
            SetupShimDbaEditCosts();

            ShimIntegration.AllInstances.executeStringString = (sender, commandMethod, commandText) =>
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml($"<Result Status=\"{DummyInt}\"><Error ID=\"{DummyInt}\">Error: {DummyError}</Error></Result>");
                return xmlDoc.SelectSingleNode("/Result");
            };

            // Act
            var actualResult = _testEntity.SaveEditCostsData(xmlDataSaveEditCostsSimpleData, DefaultProjectId, DefaultCostTypeId, string.Empty, wepId);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("<Grid><IO Result=\"-11\" Message=\"DBAccess Status Exception in EditCosts.asmx.cs&#xA;&#xA;Context=SaveEditCostsData&#xA;&#xA;Text=;\" /></Grid>"),
                () => _currentStatus.ShouldBe((StatusEnum)99833),
                () => _currentStatusText.ShouldBe($"Invalid XML response from WorkEngine WebService. Status={DummyInt}; Error={DummyInt} : Error: {DummyError}"));
        }
    }
}