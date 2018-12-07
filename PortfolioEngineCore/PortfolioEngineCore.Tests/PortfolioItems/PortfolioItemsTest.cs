using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Text;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using PortfolioEngineCore.PortfolioItems;
using PortfolioEngineCore.PortfolioItems.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.PortfolioItems
{
    /// <summary>
    /// Unit Tests for <see cref="PortfolioEngineCore.PortfolioItems.PortfolioItems"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class PortfolioItemsTest
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const bool DummyBool = true;
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private PortfolioEngineCore.PortfolioItems.PortfolioItems _testEntity;
        private IDisposable _shimsContext;
        private StringBuilder query = new StringBuilder();
        private bool isScalarExecuted;
        private bool isNonQueryExecuted;
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;

        // Function Names
        private const string ObtainManagedPortfolioItems = "ObtainManagedPortfolioItems";
        private const string GeneratePortfolioItemTicket = "GeneratePortfolioItemTicket";
        private const string UpdatePortfolioItems = "UpdatePortfolioItems";
        private const string ClosePortfolioItems = "ClosePortfolioItems";
        private const string CreateUpdateUpdatePortfolioItemsXML = "CreateUpdateUpdatePortfolioItemsXML";
        private const string CreatePI = "CreatePI";
        private const string GetPITitleValue = "GetPITitleValue";
        private const string StripNum = "StripNum";
        private const string UpdatePI = "UpdatePI";
        private const string PerformCustomFieldsCalculate = "PerformCustomFieldsCalculate";
        private const string GetCustFieldVal = "GetCustFieldVal";
        private const string FormatAs000 = "FormatAs000";
        private const string InsertDateString = "InsertDateString";
        private const string ResolveResName = "ResolveResName";
        private const string ResolveNameAndDelegates = "ResolveNameAndDelegates";
        private const string DoFlagStuff = "DoFlagStuff";
        private const string DoIntStuff = "DoIntStuff";
        private const string DoDoubleStuff = "DoDoubleStuff";
        private const string ExecuteSQLSelect = "ExecuteSQLSelect";
        private const string ExportPIInfo = "ExportPIInfo";
        private const string GetMVValue = "GetMVValue";
        private const string GetLookupValue = "GetLookupValue";
        private const string UpdateProjectDiscountRate = "UpdateProjectDiscountRate";

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            query.Clear();
            maxDatareaderCount = 1;

            _testEntity = new PortfolioEngineCore.PortfolioItems.PortfolioItems(DummyString, DummyString, DummyString, DummyString, DummyString, false);
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(PortfolioEngineCore.PortfolioItems.PortfolioItems));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void ObtainManagedPortfolioItems_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            maxDatareaderCount = 5;
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) =>
            {
                return false;
            };
            var expectedQueries = new string[]
            {
                "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS WHERE (PROJECT_EXT_UID IS NOT NULL OR PROJECT_EXT_UID <> '') AND (PROJECT_ARCHIVED IS NULL OR PROJECT_ARCHIVED = 0) ORDER BY PROJECT_NAME",
                "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = 1 OR SU.SURR_WRES_ID = 1) AND PROJECT_ID in (2,5,8,11,14)  ORDER BY PROJECT_NAME",
            };
            const string expectedsXML = "<PIS><PI ID=\"17\" EXTID=\"18\" NAME=\"19\" /><PI ID=\"20\" EXTID=\"21\" NAME=\"22\" /><PI ID=\"23\" EXTID=\"24\" NAME=\"25\" /><PI ID=\"26\" EXTID=\"27\" NAME=\"28\" /><PI ID=\"29\" EXTID=\"30\" NAME=\"31\" /></PIS>";

            // Act
            string extIDList;
            string sPIDList = DummyString;
            string sXML = DummyString;
            _testEntity.ObtainManagedPortfolioItems(out extIDList, out sPIDList, out sXML);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => sXML.ShouldBe(expectedsXML));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GeneratePortfolioItemTicket_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            var expectedQueries = new string[]
            {
                "INSERT INTO EPG_DATA_CACHE ( DC_TICKET, DC_TIMESTAMP, DC_DATA)  VALUES(@pticket,@ptimest,@pdta)",
            };

            // Act
            var result = _privateObject.Invoke(
                GeneratePortfolioItemTicket,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ToString().ShouldNotBe(string.Empty));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void UpdatePortfolioItems_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xml = $"<{DummyString}><Item EXTID='{DummyString}' ListID='{DummyString}'></Item></{DummyString}>";
            var parameters = new object[] { xml };
            var expectedResult = "<UpdatePortfolioItems><Item ItemId=\"DummyString\" ID=\"11\" Error=\"0\" /><HRESULT>0</HRESULT><STATUS>1</STATUS><Error></Error><UserName>DummyString</UserName></UpdatePortfolioItems>";

            // Act
            var result = _privateObject.Invoke(
                UpdatePortfolioItems,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void UpdatePortfolioItems_MissingResNamesGreaterThanZero_CheckBehaviour()
        {
            // Arrange
            var xml = $"<{DummyString}><Item EXTID='{DummyString}' ListID='{DummyString}'></Item></{DummyString}>";
            var parameters = new object[] { xml };
            ShimPortfolioItems.AllInstances.ExportPIInfoDBAccessStringCStruct = (_, _1, _2, _3) =>
            {
                return StatusEnum.rsSuccess;
            };
            var expectedResult = "<UpdatePortfolioItems><Item ItemId=\"DummyString\" ID=\"11\" Error=\"0\" /><HRESULT>0</HRESULT><STATUS>0</STATUS><UserName>DummyString</UserName></UpdatePortfolioItems>";

            // Act
            var result = _privateObject.Invoke(
                UpdatePortfolioItems,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void ClosePortfolioItems_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xml = $"<{DummyString}><Item EXTID='{DummyString}' ListID='{DummyString}' ID='{DummyString}'></Item></{DummyString}>";
            var parameters = new object[] { xml };
            var expectedResult = "<ClosePortfolioItems><Item ItemId=\"DummyString\" Error=\"0\" /><STATUS>0</STATUS></ClosePortfolioItems>";
            var expectedQuery = "UPDATE EPGP_PROJECTS SET PROJECT_MARKED_DELETION = 1 WHERE PROJECT_EXT_UID = @extid";

            // Act
            var result = _privateObject.Invoke(
                ClosePortfolioItems,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => query.ToString().ShouldContain(expectedQuery),
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void CreateUpdateUpdatePortfolioItemsXML_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            var expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"1\"><Field ID=\"Team\" Value=\"1\" /></PortfolioItem></PortfolioItems>";

            // Act
            var result = _privateObject.Invoke(
                CreateUpdateUpdatePortfolioItemsXML,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void CreatePI_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var sGuid = DummyString;
            var statusText = DummyString;
            var parameters = new object[] { sGuid, statusText };
            var expectedQueries = new string[]
            {
                "SELECT STAGE_ID FROM EPGP_STAGES Where (STAGE_SEQ = 1)",
                "SELECT MAX(PROJECT_ID) AS EXPR1 FROM EPGP_PROJECTS",
                "INSERT INTO EPGP_PROJECTS (PROJECT_ID, PROJECT_NAME, PROJECT_MARKED_DELETION, PROJECT_STAGE_ID, PROJECT_CREATEDBY,PROJECT_OWNER,PROJECT_MANAGER, PROJECT_CREATED, PROJECT_EXT_UID) VALUES(4, 'Creating Item for WE4.3', 0, 2, 1, 1, 1, @pcre, 'DummyString')",
                "DELETE FROM EPGP_PROJECT_STAGES WHERE PROJECT_ID = 4",
                "INSERT into EPGP_PROJECT_STAGES (PROJECT_ID,STAGE_ID,WRES_ID,STAGE_OWNER,STAGE_DATE)VALUES(4, 2, 1, 1,@sdate)",
                "DELETE FROM EPGP_PROJECT_INT_VALUES WHERE PROJECT_ID = 4",
                "insert into EPGP_PROJECT_INT_VALUES (PROJECT_ID) VALUES(4)",
                "DELETE FROM EPGP_PROJECT_TEXT_VALUES WHERE PROJECT_ID = 4",
                "insert into EPGP_PROJECT_TEXT_VALUES (PROJECT_ID) VALUES(4)",
                "DELETE FROM EPGP_PROJECT_NTEXT_VALUES WHERE PROJECT_ID = 4",
                "insert into EPGP_PROJECT_NTEXT_VALUES (PROJECT_ID) VALUES(4)",
                "DELETE FROM EPGP_PROJECT_DATE_VALUES WHERE PROJECT_ID = 4",
                "insert into EPGP_PROJECT_DATE_VALUES (PROJECT_ID) VALUES(4)",
                "DELETE FROM EPGP_PROJECT_DEC_VALUES WHERE PROJECT_ID = 4",
                "insert into EPGP_PROJECT_DEC_VALUES (PROJECT_ID) VALUES(4)",
            };

            // Act
            var result = _privateObject.Invoke(
                CreatePI,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBe(4));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPITitleValue_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xml = $"<{DummyString}><Title EXTID='{DummyString}' ListID='{DummyString}' ID='{DummyString}'>{DummyString}</Title></{DummyString}>";
            var cStruct = new CStruct();
            cStruct.LoadXML(xml);
            var parameters = new object[] { cStruct };

            // Act
            var result = _privateObject.Invoke(
                GetPITitleValue,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void StripNum_PassedDecimal_ReturnsZero()
        {
            // Arrange
            var sin = "100.10";
            var parameters = new object[] { sin };

            // Act
            var result = _privateObject.Invoke(
                StripNum,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0));
        }

        [TestMethod]
        public void UpdatePI_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xml = $"<{DummyString}><Title>{DummyString}</Title><Team>{DummyString}</Team>--FIELDS--</{DummyString}>";

            var fieldsIds = new int[]
            {
                9900,
                9901,
                9902,
                9903,
                9904,
                9910,
                9911,
                9912,
                9913,
                9919,
                9920,
                9921,
                9922,
                9923,
                9924,
                9925,
                9928,
                9934,
                9926,
                9927,
                9929,
                9930,
            };

            var fieldIdXml = string.Empty;
            foreach (var fieldId in fieldsIds)
            {
                fieldIdXml += $"<Field Name='{fieldId}'></Field>";
            }
            xml = xml.Replace("--FIELDS--", fieldIdXml);

            var xPI = new CStruct();
            xPI.LoadXML(xml);
            var iPID = DummyInt;
            var clnFieldAttr = new Queue<CCustomFieldAttr>();
            var statusText = DummyString;
            var missingResNames = DummyString;
            var parameters = new object[] { xPI, iPID, clnFieldAttr, statusText, missingResNames };

            // Act
            var result = _privateObject.Invoke(
                UpdatePI,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(2));
        }

        [TestMethod]
        public void FormatAs000_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyInt };

            // Act
            var result = _privateObject.Invoke(
                FormatAs000,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe("00" + DummyInt));
        }

        [TestMethod]
        public void InsertDateString_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { "2010-10-10T10:10:10" };

            // Act
            var result = _privateObject.Invoke(
                InsertDateString,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe("CONVERT(DATETIME, '2010-10-10 10:10:10', 102)"));
        }

        [TestMethod]
        public void ResolveResName_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString, "missingnames" };
            maxDatareaderCount = 0;

            // Act
            var result = _privateObject.Invoke(
                ResolveResName,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0));
        }

        [TestMethod]
        public void ResolveNameAndDelegates_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyInt, DummyInt, true };

            // Act
            var result = _privateObject.Invoke(
                ResolveNameAndDelegates,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void DoFlagStuff_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { "Y" };

            // Act
            var result = _privateObject.Invoke(
                DoFlagStuff,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(1));
        }

        [TestMethod]
        public void DoIntStuff_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { "123456" };

            // Act
            var result = _privateObject.Invoke(
                DoIntStuff,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(123456));
        }

        [TestMethod]
        public void DoDoubleStuff_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { "123.45" };

            // Act
            var result = _privateObject.Invoke(
                DoDoubleStuff,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(123.45d));
        }

        [TestMethod]
        public void ExecuteSQLSelect_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var expectedQuery = "select name from dummyTable";
            var sqlCommand = new SqlCommand(expectedQuery);
            var reader = new ShimSqlDataReader().Instance;
            var parameters = new object[] { sqlCommand, reader };

            // Act
            var result = (StatusEnum)_privateType.InvokeStatic(
                ExecuteSQLSelect,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => query.ToString().ShouldContain(expectedQuery));
        }

        [TestMethod]
        public void ExportPIInfo_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xEPKUpdate = new CStruct();
            xEPKUpdate.LoadXML($"<{DummyString}></{DummyString}>");
            var parameters = new object[] { new DBAccess(DummyString), DummyString, xEPKUpdate };
            ShimPortfolioItems.AllInstances.ExportPIInfoDBAccessStringCStruct = null;
            maxDatareaderCount = 20;
            SetupShimsForExportPIInfoTestMethod();
            var expectedQueries = new string[] 
            {
                "SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID",
                "SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID",
                "Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID",
                "PPM_SP_ReadLookupValuesByLookup",
                "Select pg.PROG_UID,PROJECT_ID,LV_FULLVALUE as GROUP_NAME From EPGP_PI_PROGS pg Join EPGP_LOOKUP_VALUES lv on lv.LV_UID=pg.PROG_UID JOIN dbo.EPG_FN_ConvertListToTable(N'DummyString') LT on PROJECT_ID=LT.TokenVal Order By PROJECT_ID,pg.FIELD_ID",
                "SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,ps.WPROJ_ID,sg.STAGE_NAME,r1.RES_NAME as StageOwner,r2.RES_NAME as ItemManager,r3.RES_NAME as ScheduleManager,r4.RES_NAME as CreatedBy,PI_126,PT_132,PC_138,PD_150 FROM EPGP_PROJECTS pi   Left Join EPGX_PROJECT_VERSIONS ps On ps.PROJECT_ID=pi.PROJECT_ID Left Join EPGP_STAGES sg On sg.STAGE_ID=pi.PROJECT_STAGE_ID Left Join EPG_RESOURCES r1 On r1.WRES_ID=pi.PROJECT_OWNER Left Join EPG_RESOURCES r2 On r2.WRES_ID=pi.PROJECT_MANAGER Left Join EPG_RESOURCES r3 On r3.WRES_ID=pi.PROJECT_PLAN_OWNER Left Join EPG_RESOURCES r4 On r4.WRES_ID=pi.PROJECT_CREATEDBY LEFT JOIN EPGP_PROJECT_INT_VALUES x1 ON x1.PROJECT_ID=pi.PROJECT_ID LEFT JOIN EPGP_PROJECT_TEXT_VALUES x2 ON x2.PROJECT_ID=pi.PROJECT_ID LEFT JOIN EPGP_PROJECT_DEC_VALUES x3 ON x3.PROJECT_ID=pi.PROJECT_ID LEFT JOIN EPGP_PROJECT_DATE_VALUES x5 ON x5.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'DummyString') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID",
                "Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@pid ",
            };

            // Act
            var result = _privateObject.Invoke(
                ExportPIInfo,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBe(StatusEnum.rsSuccess));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void UpdateProjectDiscountRate_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyInt, "100", "1000" };
            var isInvokedUpdateCostValuesAfterDiscountChanged = false;
            ShimdbaEditCosts.UpdateCostValuesAfterDiscountChangedDBAccessInt32Decimal = (_, _1, _2) => isInvokedUpdateCostValuesAfterDiscountChanged = true;
            var isInvokedPostCostValuesOnProjectRatesChange = false;
            ShimdbaQueueManager.PostCostValuesOnProjectRatesChangeDBAccessStringStringBooleanBoolean = (_, _1, _2, _3, _4) => 
            {
                isInvokedPostCostValuesOnProjectRatesChange = true;
                return DummyString;
            };

            // Act
            var result = _privateObject.Invoke(
                UpdateProjectDiscountRate,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => isInvokedUpdateCostValuesAfterDiscountChanged.ShouldBe(true),
                () => isInvokedPostCostValuesOnProjectRatesChange.ShouldBe(true));
        }

        private void InitShims()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("PROJECT_ID");
            dataTable.Columns.Add("PROJECT_EXT_UID");
            dataTable.Columns.Add("PROJECT_NAME");
            dataTable.Columns.Add("PROJECT_START_DATE");
            dataTable.Columns.Add("PROJECT_FINISH_DATE");
            dataTable.Columns.Add("STAGE_NAME");
            dataTable.Columns.Add("CreatedBy");
            dataTable.Columns.Add("PROJECT_CREATED");
            dataTable.Columns.Add("StageOwner");
            dataTable.Columns.Add("WPROJ_ID");
            dataTable.Columns.Add("ItemManager");
            dataTable.Columns.Add("PROJECT_PRIORITY");
            dataTable.Columns.Add("WORKITEM_START_DATE");
            dataTable.Columns.Add("ScheduleManager");
            dataTable.Columns.Add("PI_126");
            dataTable.Columns.Add("PT_132");
            dataTable.Columns.Add("PC_138");
            dataTable.Columns.Add("PD_150");

            var row = dataTable.NewRow();
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.Contains("DATE") 
                    || column.ColumnName.Contains("PROJECT_CREATED") 
                    || column.ColumnName.Contains("PD_150"))
                {
                    row[column.ColumnName] = DateTime.Now;
                }
                else
                {
                    row[column.ColumnName] = DummyInt;
                }
            }
            var datarows = new List<DataRow>()
            {
                row,
            };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection()
            {
                GetEnumerator = () => datarows.GetEnumerator(),
                CountGet = () => datarows.Count,
                ItemGetInt32 = index => datarows[index],
            }.Instance;
            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
            ShimPortfolioItems.AllInstances.ExportPIInfoDBAccessStringCStruct = (_, _1, _2, _3) =>
            {
                return StatusEnum.rsBasePathNotSet;
            };
            SetupSqlShims();
        }

        private void SetupSqlShims()
        {
            ShimSqlConnection.AllInstances.StateGet = _ => System.Data.ConnectionState.Open;
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                isScalarExecuted = true;
                if (command.CommandText == "SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)")
                {
                    return true;
                }
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                query.Append("\n" + command.CommandText);
                isNonQueryExecuted = true;
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key == "WRES_ID")
                        {
                            return DummyInt;
                        }
                        else if (key == "FA_FORMAT")
                        {
                            return 4;
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private void SetupShimsForExportPIInfoTestMethod()
        {
            var currentFieldIdIndex = -1;
            var fieldIDS = new List<int>()
            {
                9224,
                9901,
                9902,
                9903,
                9911,
                9918,
                9920,
                9921,
                9922,
                9924,
                9925,
                9928,
                9930,
                9936,
                9960,
                10000,
            };
            var currentTableIdIndex = -1;
            var TableIDS = new List<int>()
            {
                201,
                202,
                203,
                204,
                205,
                206,
                207,
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key == "WRES_ID")
                        {
                            return DummyInt;
                        }
                        else if (key == "FA_FORMAT")
                        {
                            return 4;
                        }
                        else if (key == "FIELD_ID")
                        {
                            currentFieldIdIndex++;
                            if (currentFieldIdIndex < fieldIDS.Count)
                            {
                                return fieldIDS[currentFieldIdIndex];
                            }
                            else
                            {
                                var newValue = fieldIDS[fieldIDS.Count - 1] + 1;
                                fieldIDS.Add(newValue);
                                return newValue;
                            }
                        }
                        else if (key == "FA_TABLE_ID")
                        {
                            currentTableIdIndex++;
                            if (currentTableIdIndex < TableIDS.Count)
                            {
                                return TableIDS[currentTableIdIndex];
                            }
                            else
                            {
                                var newValue = TableIDS[TableIDS.Count - 1] + 1;
                                TableIDS.Add(newValue);
                                return newValue;
                            }
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
        }
    }
}
