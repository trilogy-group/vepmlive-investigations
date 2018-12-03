using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;
using PortfolioFakes = PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResourceSelectorTests
    {
        private ResourceSelector testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags nonPublicStatic;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private ShimSqlTransaction transaction;
        private ShimSqlDataReader dataReader;
        private SqlCommand sqlCommand;
        private Guid guid;
        private int validations;
        private DateTime currentDate;
        private const int DummyInt = 1;
        private const int Zero = 0;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        private const int Four = 4;
        private const int Five = 5;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string ReadResourcesMethodName = "ReadResources";
        private const string GetResourceDisplayFieldsMethodName = "GetResourceDisplayFields";
        private const string BuildResourceSelectQueryMethodName = "BuildResourceSelectQuery";
        private const string GetPIResourcesXMLMethodName = "GetPIResourcesXML";
        private const string GetCustomFieldNameFromIDMethodName = "GetCustomFieldNameFromID";
        private const string GetCostCategoryRolesMethodName = "GetCostCategoryRoles";
        private const string GetCFFieldNameMethodName = "GetCFFieldName";
        private const string GetPeriodsMethodName = "GetPeriods";
        private const string ReadUserInfoMethodName = "ReadUserInfo";
        private const string BuildPortfolioResourcesSelectQueryMethodName = "BuildPortfolioResourcesSelectQuery";
        private const string GetPIResourcesStructMethodName = "GetPIResourcesStruct";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new ResourceSelector
            (
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                SecurityLevels.AdminCalc,
                false
            );
            privateObject = new PrivateObject(testObject);

            privateObject.SetFieldOrProperty("debug", nonPublicInstance, new Debugger(false));
            privateObject.SetFieldOrProperty("_dba", nonPublicInstance, new DBAccess(DummyString, new SqlConnection()));
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();
            
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.ConstructorStringSqlConnectionSqlTransaction = (_, _1, _2, _3) => new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimDbDataReader.AllInstances.Dispose = _ => { };
            ShimSqlDb.AllInstances.TransactionGet = _ => transaction;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDb.ReadDateValueObject = _ => currentDate;
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = (_, _1, _2, _3, _4) => StatusEnum.rsRequestInvalid;
            ShimActivation.AllInstances.checkActivationStringStringString = (_, _1, _2, _3) => { };
            ShimPFEEncrypt.DecryptStringString = (_, input) => input;
            ShimDatabase.AllInstances.OpenDatabaseStringString = (_, _1, _2) => new SqlConnection();
            ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = (_, _1, _2) => true;
        }

        private void SetupVariables()
        {
            validations = 0;
            currentDate = DateTime.Now;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            sqlCommand = new SqlCommand();
            transaction = new ShimSqlTransaction();
            dataReader = new ShimSqlDataReader()
            {
                Read = () => true,
                HasRowsGet = () => true,
                Close = () => { },
                ItemGetString = _ => DummyString
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
            sqlCommand?.Dispose();
        }

        [TestMethod]
        public void ReadResources_WhenCalled_ReturnsResourcesXml()
        {
            // Arrange
            const string advancedQueryXml = "<xmlcfg/>";
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""9019""/>
                        <Item FieldFormat=""9"" FieldID=""9006""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""98"" FieldID=""1""/>
                        <Item FieldFormat=""40"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            var parameters = new object[]
            {
                One,
                DummyString,
                advancedQueryXml,
                displayFieldsXml,
                true,
                true,
                true,
                DummyString
            };
            var row = default(DataRow);
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit < Three;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            PortfolioFakes.ShimSecurity.GetResourcesUserCanViewDBAccessInt32StringOut =
                (DBAccess dba, int lWResID, out string sWResIDs) =>
                {
                    validations += 1;
                    sWResIDs = DummyString;
                    return StatusEnum.rsBasePathNotSet;
                };
            ShimResourceSelector.AllInstances.BuildResourceSelectQueryDBAccessInt32CStructInt32ListOfCStructStringBooleanBooleanIncludeGenericsEnum =
                (_, _1, _2, _3, _4, _5, _6, _7, _8, _9) =>
                {
                    return DummyString;
                };
            ShimDataTable.AllInstances.LoadIDataReader = (DataTable instance, IDataReader input) =>
            {
                instance.Columns.Add("WRES_ID");
                instance.Columns.Add("RES_NAME");
                instance.Columns.Add("MR_NOTES");
                instance.Columns.Add("WRES_IS_GENERIC");
                instance.Columns.Add("WRES_IS_RESOURCE");
                instance.Columns.Add("CCRoleUID");
                instance.Columns.Add("Field1");
                instance.Columns.Add("Field9004");
                instance.Columns.Add("Field9019");
                instance.Columns.Add("Field9006");
                instance.Columns.Add("Field9020");
                row = instance.NewRow();
                foreach (DataColumn column in instance.Columns)
                {
                    row[column.ColumnName] = One;
                }
                instance.Rows.Add(row);
            };
            ShimCommon.IsIDInListStringInt32 = (_1, _2) => true;
            ShimCommon.AppendItemToListStringString = (_1, _2) => DummyString;
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = One.ToString();
                return true;
            };
            ShimResourceSelector.GetCostCategoryRolesDBAccessInt32Int32DictionaryOfStringCStructOut =
                (DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out Dictionary<string, CStruct> dicCostCategoryRolesOut) =>
                {
                    validations += 1;
                    const string roleXml = @"<xmlcfg Name=""NodeName"" ParentName=""ParentName""/>";
                    var costCategoryRole = new CStruct();
                    costCategoryRole.LoadXML(roleXml);
                    dicCostCategoryRolesOut = new Dictionary<string, CStruct>()
                    {
                        [One.ToString()] = costCategoryRole
                    };
                    return StatusEnum.rsSuccess;
                };

            // Act
            var result = (bool)privateObject.Invoke(ReadResourcesMethodName, publicInstance, parameters);
            var actual = new XmlDocument();
            actual.LoadXml((string)parameters[7]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => actual.FirstChild.SelectSingleNode("//WResID").InnerText.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Resources/Resource/WResID").InnerText.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Resources/Resource/CCRoleUID").InnerText.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Resources/Resource/Field9019").InnerText.ShouldBe("ParentName.NodeName"),
                () => actual.FirstChild.SelectNodes("//Resources/Resource/Field1").Count.ShouldBe(Three),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetResourceDisplayFields_WhenCalled_ReturnsDisplayFields()
        {
            // Arrange
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var parameters = new object[]
            {
                dbAccess,
                default(CStruct)
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= Three;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };

            // Act
            var result = (StatusEnum)privateObject.Invoke(GetResourceDisplayFieldsMethodName, nonPublicStatic, parameters);
            var replyXmlNode = (CStruct)parameters[1];
            var itemList = replyXmlNode.GetSubStruct("Items").GetList("Item");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => itemList.Count.ShouldBe(17));
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeZero_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 0;
            const bool includeUsers = false;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igExclusive;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"<xmlcfg/>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "WR.WRES_IS_GENERIC <> 0",
                "WR.WRES_INACTIVE = 0",
                $"MR_WRES_ID = {One} ORDER BY MR_SEQ"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeThree_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 3;
            const bool includeUsers = false;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igNo;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"<xmlcfg/>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "AND WR.WRES_IS_RESOURCE <> 0",
                "WR.WRES_INACTIVE = 0",
                $"INNER JOIN dbo.EPG_FN_ConvertListToTable(N'{One}') LT on WR.WRES_ID=LT.TokenVal"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeFour_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 4;
            const bool includeUsers = true;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igNo;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"
                <xmlcfg>
                    <QueryRow Value=""1""/>
                    <QueryRow Value=""2""/>
                </xmlcfg>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "AND WR.WRES_IS_GENERIC = 0",
                "WR.WRES_INACTIVE = 0",
                $"AND ( RES_NAME LIKE '%1%' OR  RES_NAME LIKE '%2%' )"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void BuildResourceSelectQuery_SearchModeDefault_ReturnsQueryString()
        {
            // Arrange
            const int searchMode = 1;
            const bool includeUsers = false;
            const bool includeInactive = false;
            const IncludeGenericsEnum includeGenerics = IncludeGenericsEnum.igYes;
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            const string queryXml = @"
                <xmlcfg>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9005"" FieldFormat=""4""/>
                    <QueryRow Operator=""6"" Value=""1"" FieldID=""9005"" FieldFormat=""4""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9015"" FieldFormat=""4""/>
                    <QueryRow Operator=""5"" Value=""1"" FieldID=""9015"" FieldFormat=""4""/>
                    <QueryRow Operator=""5"" Value=""1"" FieldID=""1"" FieldFormat=""4""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""1"" FieldFormat=""40""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""1"" FieldFormat=""98""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""9004"" FieldFormat=""9""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""9006"" FieldFormat=""9""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""3"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""4"" Value=""1"" FieldID=""1"" FieldFormat=""9""/>
                    <QueryRow Operator=""1"" Value=""2"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""2"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9018"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""5"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""6"" Value=""1"" FieldID=""9020"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""1"" FieldID=""9021"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""1"" FieldID=""9021"" FieldFormat=""96""/>
                    <QueryRow Operator=""1"" Value=""2"" FieldID=""9021"" FieldFormat=""96""/>
                    <QueryRow Operator=""2"" Value=""2"" FieldID=""9021"" FieldFormat=""96""/>
                </xmlcfg>";
            var dbAccess = new DBAccess(DummyString, new SqlConnection());
            var queryNode = new CStruct();
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);
            queryNode.LoadXML(queryXml);

            var parameters = new object[]
            {
                dbAccess,
                searchMode,
                queryNode,
                One,
                displayFields.GetSubStruct("Items").GetList("Item"),
                One.ToString(),
                includeUsers,
                includeInactive,
                includeGenerics
            };
            var expected = new List<string>()
            {
                $"LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = {One}",
                $"DEPT.LV_VALUE AS Field9005",
                $"RPDEPT.LV_VALUE AS Field9015",
                "LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)",
                "LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)",
                "AND (WR.WRES_IS_RESOURCE <> 0 OR WR.WRES_IS_GENERIC <> 0)",
                "WR.WRES_INACTIVE = 0",
                "AND RES_NAME LIKE '1'",
                "AND RES_NAME LIKE '%1%'",
                "AND RES_NAME LIKE '1%'",
                "AND RES_NAME NOT LIKE '1'",
                "AND CAT.BC_NAME LIKE '1'",
                "AND CAT.BC_NAME LIKE '%1%'",
                "AND CAT.BC_NAME LIKE '1%'",
                "AND CAT.BC_NAME NOT LIKE '1'",
                "AND WRES_IS_RESOURCE <> 0",
                "AND WRES_IS_RESOURCE = 0",
                "AND WRES_CAN_LOGIN <> 0",
                "AND WRES_CAN_LOGIN = 0"
            };

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(BuildResourceSelectQueryMethodName, nonPublicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => expected.Any(x => !actual.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void GetPIResourcesXML_WhenCalled_ReturnsResourceXmlString()
        {
            // Arrange
            const string xmlString = "<xmlcfg />";
            var parameters = new object[]
            {
                One,
                DummyString,
                false,
                DummyString
            };

            ShimResourceSelector.GetPeriodsDBAccessInt32ListOfCPeriodOut =
                (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
                {
                    validations += 1;
                    clnPeriods = new List<CPeriod>()
                    {
                        new CPeriod()
                        {
                            PeriodID = One,
                            StartDate = currentDate.AddDays(-1),
                            FinishDate = currentDate.AddDays(1)
                        }
                    };
                    return StatusEnum.rsSuccess;
                };
            ShimResourceSelector.GetPIResourcesStructDBAccessInt32StringStringListOfCPeriodCAdminInt32CStructOut =
                (DBAccess dba, int lUserWResId, string sProjectIDs, string sWResIDs, List<CPeriod> clnPeriods, CAdmin oAdmin, int lStartPeriodID, out CStruct xReply) =>
                {
                    validations += 1;
                    xReply = new CStruct();
                    xReply.LoadXML(xmlString);
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (bool)privateObject.Invoke(GetPIResourcesXMLMethodName, publicInstance, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => parameters[3].ShouldBe(xmlString),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetCustomFieldNameFromID_WhenCalled_ReturnsTableNameAndFieldName()
        {
            // Arrange
            var parameters = new object[]
            {
                new DBAccess(DummyString, new SqlConnection()),
                One,
                DummyString,
                DummyString
            };

            ShimResourceSelector.GetCFFieldNameInt32Int32StringOutStringOut =
                (int lTableID, int lFieldID, out string sTable, out string sField) =>
                {
                    sTable = DummyString;
                    sField = DummyString;
                    if (lTableID.Equals(One) && lFieldID.Equals(One))
                    {
                        validations += 1;
                    }
                };

            // Act
            var actual = (StatusEnum)privateObject.Invoke(GetCustomFieldNameFromIDMethodName, nonPublicStatic, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(StatusEnum.rsSuccess),
                () => validations.ShouldBe(1),
                () => parameters[2].ShouldBe(DummyString),
                () => parameters[3].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetCostCategoryRoles_WhenCalled_Returns()
        {
            // Arrange
            var parameters = new object[]
            {
                new DBAccess(DummyString, new SqlConnection()),
                One,
                One,
                new Dictionary<string, CStruct>()
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= One;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = One.ToString();
                return true;
            };
            ShimCommon.AppendItemToListStringString = (_, _1) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (StatusEnum)privateObject.Invoke(GetCostCategoryRolesMethodName, nonPublicStatic, parameters);
            var ccroles = (Dictionary<string, CStruct>)parameters[3];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(StatusEnum.rsSuccess),
                () => ccroles.Count.ShouldBe(One),
                () => ccroles[One.ToString()].GetIntAttr("ID").ShouldBe(One),
                () => ccroles[One.ToString()].GetIntAttr("Level").ShouldBe(One),
                () => ccroles[One.ToString()].GetIntAttr("RoleUID").ShouldBe(One),
                () => ccroles[One.ToString()].GetStringAttr("Name").ShouldBe(DummyString),
                () => validations.ShouldBe(Two));
        }

        [TestMethod]
        public void GetCFFieldName_WhenCalled_ReturnsTableNameAndFieldName()
        {
            // Arrange
            var format = Five.ToString("000");
            var fieldId = Five.ToString("0");
            var expectedTableNames = new Dictionary<CustomFieldDBTable, string>()
            {
                [CustomFieldDBTable.ResourceINT] = "EPGC_RESOURCE_INT_VALUES",
                [CustomFieldDBTable.ResourceTEXT] = "EPGC_RESOURCE_TEXT_VALUES",
                [CustomFieldDBTable.ResourceDEC] = "EPGC_RESOURCE_DEC_VALUES",
                [CustomFieldDBTable.ResourceNTEXT] = "EPGC_RESOURCE_NTEXT_VALUES",
                [CustomFieldDBTable.ResourceDATE] = "EPGC_RESOURCE_DATE_VALUES",
                [CustomFieldDBTable.ResourceMV] = "EPGC_RESOURCE_MV_VALUES",
                [CustomFieldDBTable.PortfolioINT] = "EPGP_PROJECT_INT_VALUES",
                [CustomFieldDBTable.PortfolioTEXT] = "EPGP_PROJECT_TEXT_VALUES",
                [CustomFieldDBTable.PortfolioDEC] = "EPGP_PROJECT_DEC_VALUES",
                [CustomFieldDBTable.PortfolioNTEXT] = "EPGP_PROJECT_NTEXT_VALUES",
                [CustomFieldDBTable.PortfolioDATE] = "EPGP_PROJECT_DATE_VALUES",
                [CustomFieldDBTable.Program] = "EPGP_PI_PROGS",
                [(CustomFieldDBTable)301] = "EPGX_PROJ_INT_VALUES",
                [(CustomFieldDBTable)302] = "EPGX_PROJ_TEXT_VALUES",
                [(CustomFieldDBTable)303] = "EPGX_PROJ_DEC_VALUES",
                [(CustomFieldDBTable)304] = "EPGX_PROJ_NTEXT_VALUES",
                [(CustomFieldDBTable)305] = "EPGX_PROJ_DATE_VALUES",
                [(CustomFieldDBTable)402] = "EPGP_PI_PROGS",
                [(CustomFieldDBTable)801] = "EPGP_PI_WORKITEMS",
                [(CustomFieldDBTable)802] = "EPGP_PI_WORKITEMS",
                [(CustomFieldDBTable)803] = "EPGP_PI_WORKITEMS",
                [(CustomFieldDBTable)999] = "Unknown Table"
            };
            var expectedFieldNames = new Dictionary<CustomFieldDBTable, string>()
            {
                [CustomFieldDBTable.ResourceINT] = $"RI_{format}",
                [CustomFieldDBTable.ResourceTEXT] = $"RT_{format}",
                [CustomFieldDBTable.ResourceDEC] = $"RC_{format}",
                [CustomFieldDBTable.ResourceNTEXT] = $"RN_{format}",
                [CustomFieldDBTable.ResourceDATE] = $"RD_{format}",
                [CustomFieldDBTable.ResourceMV] = "MVR_UID",
                [CustomFieldDBTable.PortfolioINT] = $"PI_{format}",
                [CustomFieldDBTable.PortfolioTEXT] = $"PT_{format}",
                [CustomFieldDBTable.PortfolioDEC] = $"PC_{format}",
                [CustomFieldDBTable.PortfolioNTEXT] = $"PN_{format}",
                [CustomFieldDBTable.PortfolioDATE] = $"PD_{format}",
                [CustomFieldDBTable.Program] = "PROG_UID",
                [(CustomFieldDBTable)301] = $"XI_{format}",
                [(CustomFieldDBTable)302] = $"XT_{format}",
                [(CustomFieldDBTable)303] = $"XC_{format}",
                [(CustomFieldDBTable)304] = $"XN_{format}",
                [(CustomFieldDBTable)305] = $"XD_{format}",
                [(CustomFieldDBTable)402] = $"PROG_PI_TEXT{fieldId}",
                [(CustomFieldDBTable)801] = $"WORKITEM_FLAG{fieldId}",
                [(CustomFieldDBTable)802] = $"WORKITEM_CTEXT{fieldId}",
                [(CustomFieldDBTable)803] = $"WORKITEM_NUMBER{fieldId}",
                [(CustomFieldDBTable)999] = string.Empty
            };
            var parameters = new object[]
            {
                One,
                Five,
                DummyString,
                DummyString
            };

            // Act
            foreach (var key in expectedTableNames.Keys)
            {
                parameters[0] = key;
                privateObject.Invoke(GetCFFieldNameMethodName, nonPublicStatic, parameters);
                if (parameters[2].Equals(expectedTableNames[key]) && parameters[3].Equals(expectedFieldNames[key]))
                {
                    validations += 1;
                }
            }

            // Assert
            validations.ShouldBe(22);
        }

        [TestMethod]
        public void GetPeriods_WhenCalled_ReturnsPeriodsList()
        {
            // Arrange
            var parameters = new object[]
            {
                new DBAccess(DummyString, new SqlConnection()),
                One,
                default(List<CPeriod>)
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= Three;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };

            // Act
            var actual = (StatusEnum)privateObject.Invoke(GetPeriodsMethodName, nonPublicStatic, parameters);
            var periods = (List<CPeriod>)parameters[2];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(StatusEnum.rsSuccess),
                () => readHit.ShouldBe(4),
                () => periods.Count.ShouldBe(3),
                () => periods.Count(x => x.PeriodID.Equals(DummyInt)).ShouldBe(3),
                () => periods.Count(x => x.PeriodName.Equals(DummyString)).ShouldBe(3));
        }

        [TestMethod]
        public void ReadUserInfo_WhenCalled_ReturnsDataAndXml()
        {
            // Arrange
            var parameters = new object[]
            {
                new DBAccess(DummyString, new SqlConnection()),
                One,
                UserInfoContextsEnum.siEVEditorPISettings,
                Zero,
                string.Empty
            };

            // Act
            var actual = (StatusEnum)privateObject.Invoke(ReadUserInfoMethodName, nonPublicStatic, parameters);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(StatusEnum.rsSuccess),
                () => parameters[3].ShouldBe(DummyInt),
                () => parameters[4].ShouldBe(DummyString));
        }

        [TestMethod]
        public void BuildPortfolioResourcesSelectQuery_WhenCalled_ReturnsSelectQuery()
        {
            // Arrange
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9005"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""9020""/>
                    </Items>
                </xmlcfg>";
            var expected = new List<string>()
            {
                "C2.LV_VALUE AS Field1",
                "TSDEPT3.LV_VALUE AS Field9005",
                "RPDEPT4.LV_VALUE AS Field9015",
                "T5.DummyString AS Field1",
                "C7.RT_NAME AS Field9020",
                "LEFT JOIN DummyString C1 ON WR.WRES_ID = C1.WRES_ID",
                "LEFT JOIN EPGP_LOOKUP_VALUES C2 ON C2.LV_UID = C1.DummyString",
                "LEFT JOIN DummyString T5 ON WR.WRES_ID = T5.WRES_ID",
                "LEFT JOIN EPGP_COST_RATES C6 ON WR.WRES_ID = C6.WRES_ID",
                "LEFT JOIN EPG_RATES C7 ON C7.RT_UID = C6.RT_UID",
                $"INNER JOIN dbo.EPG_FN_ConvertListToTable(N'{One}') LT on WR.WRES_ID=LT.TokenVal"
            };
            var displayFields = new CStruct();

            displayFields.LoadXML(displayFieldsXml);

            ShimResourceSelector.GetCustomFieldNameFromIDDBAccessInt32StringOutStringOut =
                (DBAccess dba, int lFieldID, out string sTableName, out string sFieldName) =>
                {
                    sTableName = DummyString;
                    sFieldName = DummyString;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actual = (string)privateObject.Invoke(
                BuildPortfolioResourcesSelectQueryMethodName,
                nonPublicStatic,
                new object[]
                {
                    new DBAccess(DummyString, new SqlConnection()),
                    One,
                    displayFields.GetSubStruct("Items").GetList("Item"),
                    One.ToString(),
                    One,
                    One
                });

            // Assert
            expected.Any(x => !actual.Contains(x)).ShouldBeFalse();
        }

        [TestMethod]
        public void GetPIResourcesStruct_WhenCalled_Returns()
        {
            // Arrange
            const string displayFieldsXml = @"
                <xmlcfg>
                    <RowLimit>0</RowLimit>
                    <Items>
                        <Item FieldFormat=""4"" FieldID=""1"" CCRoleUID=""1""/>
                        <Item FieldFormat=""4"" FieldID=""9015"" CCRoleUID=""1""/>
                        <Item FieldFormat=""9"" FieldID=""9004""/>
                        <Item FieldFormat=""9"" FieldID=""9006""/>
                        <Item FieldFormat=""9"" FieldID=""9019""/>
                        <Item FieldFormat=""9"" FieldID=""1""/>
                        <Item FieldFormat=""96"" FieldID=""1""/>
                        <Item FieldFormat=""40"" FieldID=""1""/>
                        <Item FieldFormat=""98"" FieldID=""1""/>
                    </Items>
                </xmlcfg>";
            const string categoryListXml = @"
                <categories>
                    <category/>
                </categories>";
            var readHit = 0;
            var methodHit = 0;
            var clnPeriods = new List<CPeriod>()
            {
                new CPeriod()
                {
                    PeriodID = One,
                    StartDate = currentDate.AddDays(-1),
                    FinishDate = currentDate.AddDays(1)
                }
            };
            var parameters = new object[]
            {
                new DBAccess(DummyString, new SqlConnection()),
                One,
                One.ToString(),
                One.ToString(),
                clnPeriods,
                new CAdmin(),
                One,
                default(CStruct)
            };

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= One;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            PortfolioFakes.ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = One.ToString();
                return true;
            };
            ShimResourceSelector.GetResourceDisplayFieldsDBAccessCStructOut = (DBAccess dba, out CStruct xReply) =>
            {
                xReply = new CStruct();
                xReply.LoadXML(displayFieldsXml);
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetLookupListXMLDBAccessInt32CStructOut = (DBAccess dba, int lLookupID, out CStruct xReply) =>
            {
                xReply = new CStruct();
                xReply.LoadXML(categoryListXml);
                return StatusEnum.rsSuccess;
            };
            ShimResourceSelector.BuildPortfolioResourcesSelectQueryDBAccessInt32ListOfCStructStringInt32Int32 = (_1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimResourceSelector.GetCostCategoryRolesDBAccessInt32Int32DictionaryOfStringCStructOut =
                (DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out Dictionary<string, CStruct> dicCostCategoryRolesOut) =>
                {
                    const string ccrolesString = @"<ccrole RoleUID=""1"" ParentID=""1""/>";
                    var ccroles = new CStruct();
                    ccroles.LoadXML(ccrolesString);
                    dicCostCategoryRolesOut = new Dictionary<string, CStruct>()
                    {
                        [One.ToString()] = ccroles
                    };
                    return StatusEnum.rsSuccess;
                };
            ShimDataTable.AllInstances.LoadIDataReader = (DataTable instance, IDataReader input) =>
            {
                instance.Columns.Add("WRES_ID");
                instance.Columns.Add("RES_NAME");
                instance.Columns.Add("WRES_EMAIL");
                instance.Columns.Add("MR_NOTES");
                instance.Columns.Add("RPDeptUID");
                instance.Columns.Add("WRES_INACTIVE");
                instance.Columns.Add("WRES_IS_GENERIC");
                instance.Columns.Add("WRES_IS_RESOURCE");
                instance.Columns.Add("CCRoleUID");
                instance.Columns.Add("Field1");
                instance.Columns.Add("Field9004");
                instance.Columns.Add("Field9019");
                instance.Columns.Add("Field9006");
                instance.Columns.Add("Field9015");
                var row = instance.NewRow();
                foreach (DataColumn column in instance.Columns)
                {
                    row[column.ColumnName] = One;
                }
                instance.Rows.Add(row);
            };
            ShimCommon.GetFirstItemFromListStringRef = (ref string input) =>
            {
                methodHit += 1;
                return methodHit == 1 ? One.ToString() : Zero.ToString();
            };

            // Act
            var actual = (StatusEnum)privateObject.Invoke(GetPIResourcesStructMethodName, publicStatic, parameters);
            var reply = ((CStruct)parameters[7]).GetXMLNode();

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(StatusEnum.rsSuccess),
                () => reply.SelectSingleNode("//ProjectIDs").InnerText.ShouldBe(One.ToString()),
                () => reply.SelectSingleNode("//Calendar").Attributes["CalID"].Value.ShouldBe(Zero.ToString()),
                () => reply.SelectSingleNode("//Resources/Resource").Attributes["WResID"].Value.ShouldBe(One.ToString()),
                () => reply.SelectSingleNode("//Resources/Resource/CCRoleUID").InnerText.ShouldBe(One.ToString()),
                () => reply.SelectSingleNode("//Resources/Resource/DeptName").InnerText.ShouldBe(DummyString),
                () => validations.ShouldBe(2));
        }
    }
}