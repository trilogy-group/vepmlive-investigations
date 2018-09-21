using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace PortfolioEngineCore.Tests.Analyzers
{
    using Fakes;
    using PortfolioEngineCore;

    [TestClass]
    public class OptimizerDataTest
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string ReadCurrencySettingsMethodName = "ReadCurrencySettings";
        private const string ReadStagesMethodName = "ReadStages";
        private const string ReadExtraPifieldsMethodName = "ReadExtraPifields";
        private const string MyFormatMethodName = "MyFormat";
        private const string FormatSQLDateTimeMethodName = "FormatSQLDateTime";
        private const string StripNumMethodName = "StripNum";
        private const string OptimizeThisTypeMethodName = "OptimizeThisType";
        private const string FormatExportExtraDataMethodName = "FormatExportExtraData";
        private const int FieldId = 10;
        private IDisposable shimContext;
        private OptimizerData optimizerData;
        private PrivateObject privateObject;
        private string ReadPILevelDataMethodName = "ReadPILevelData";

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            optimizerData = new OptimizerData(DummyString, DummyString, DummyString, DummyString, DummyString, SecurityLevels.Base);
            privateObject = new PrivateObject(optimizerData);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
            optimizerData?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ => false;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimSqlDb.ReadIntValueObject = _ => 1;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimCStruct.AllInstances.LoadXMLString = (_, xml) => true;
            ShimUtilities.ResolveNTNameintoWResIDSqlConnectionString = (sqlConnection, userName) => 1;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private string MyFormatDummyMethod(OptimizerData instance, object obj, int type, ref string codes, ref string resource)
        {
            codes = DummyString;
            resource = DummyString;
            return DummyString;
        }

        [TestMethod]
        public void ConstructorString_WithValidParameters_ShouldCreateInstance()
        {
            // Arrange
            ShimCStruct.AllInstances.GetStringString = (_, attr) => DummyString;
            ShimCStruct.AllInstances.GetIntString = (_, attr) => 1;

            // Act
            optimizerData = new OptimizerData(DummyString);
            privateObject = new PrivateObject(optimizerData);
            var connection = privateObject.GetFieldOrProperty("_sqlConnection") as SqlConnection;

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => optimizerData.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull());
        }

        [TestMethod]
        public void Constructor_WithValidParameters_ShouldCreateInstance()
        {
            // Arrange
            ShimUtilities.ResolveNTNameintoWResIDSqlConnectionString = (sqlConnection, userName) => 1;

            // Act
            optimizerData = new OptimizerData(DummyString, DummyString, DummyString, DummyString, DummyString, SecurityLevels.Base);
            privateObject = new PrivateObject(optimizerData);
            var connection = privateObject.GetFieldOrProperty("_sqlConnection") as SqlConnection;
            var id = privateObject.GetFieldOrProperty("_userWResID") as int?;

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => optimizerData.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull(),
                () => id.ShouldNotBeNull(),
                () => id.Value.ShouldBe(1));
        }

        [TestMethod]
        public void GetOptimizerViewsXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimCStruct.AllInstances.InitializeString = (_, name) => { };
            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 1;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, cStruct) => new CStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.GetOptimizerViewsXML(out reply);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => reply.ShouldNotBeEmpty(),
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void GetOptimizerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 1;
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.GetOptimizerViewXML(DummyGuid, out reply);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => reply.ShouldNotBeEmpty(),
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveOptimizerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;

            // Act
            var result = optimizerData.SaveOptimizerViewXML(DummyGuid, DummyString, true, true, DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteOptimizerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;

            // Act
            var result = optimizerData.DeleteOptimizerViewXML(DummyGuid);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void RenameOptimizerViewXML_xViewNull_ReturnsFalse()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => false;

            // Act
            var result = optimizerData.RenameOptimizerViewXML(DummyGuid, DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void RenameOptimizerViewXML_RowsAffectedZero_ReturnsFalse()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, attrValue, clear) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.RenameOptimizerViewXML(DummyGuid, DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void RenameOptimizerViewXML_RowsAffected_ReturnsTrue()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, attrValue, clear) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.RenameOptimizerViewXML(DummyGuid, DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetOptimizerStratagiesXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            var reply = string.Empty;
            ShimCStruct.AllInstances.InitializeString = (_, name) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, name, structValue) => { };
            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 2;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, cStruct) => new CStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;

            // Act
            var result = optimizerData.GetOptimizerStratagiesXML(DummyString, out reply);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetOptimizerStratagyXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            ShimCStruct.AllInstances.InitializeString = (_, name) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, name, structValue) => { };
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, cStruct) => new CStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;

            // Act
            var result = optimizerData.GetOptimizerStratagyXML(DummyGuid, out reply);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => reply.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void SaveOptimizerStratagyXML_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;

            // Act
            var result = optimizerData.SaveOptimizerStratagyXML(DummyGuid, DummyString, true, true, DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteOptimizerStratagyXML_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = optimizerData.DeleteOptimizerStratagyXML(DummyGuid);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void RenameOptimizerStratagyXML_xStratagy_ReturnsFalse()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => false;

            // Act
            var result = optimizerData.RenameOptimizerStratagyXML(DummyGuid, DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void RenameOptimizerStratagyXML_RowsAffectedZero_ReturnsFalse()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, attrValue, clear) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.RenameOptimizerStratagyXML(DummyGuid, DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void RenameOptimizerStratagyXML_RowsAffected_ReturnsTrue()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, attrValue, clear) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.RenameOptimizerStratagyXML(DummyGuid, DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CommitOptimizerStratagy_Should_ExecuteCorrectly()
        {
            // Arrange
            var nonQueryExecuted = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                nonQueryExecuted++;
                return 1;
            };

            // Act
            optimizerData.CommitOptimizerStratagy(DummyString, DummyString, DummyString);

            // Assert
            nonQueryExecuted.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void ReadCurrencySettings_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            var symbol = "$";
            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 2;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimSqlDb.ReadIntValueObject = _ => 1;
            ShimSqlDb.ReadStringValueObject = _ => symbol;

            // Act
            privateObject.Invoke(ReadCurrencySettingsMethodName, new ShimSqlConnection().Instance);
            var currencyPosition = privateObject.GetFieldOrProperty("m_curr_pos") as int?;
            var currencyDigit = privateObject.GetFieldOrProperty("m_curr_digits") as int?;
            var currencySymbol = privateObject.GetFieldOrProperty("m_curr_sym") as string;

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => currencyPosition.GetValueOrDefault(0).ShouldBe(1),
                () => currencyDigit.GetValueOrDefault(0).ShouldBe(1),
                () => currencySymbol.ShouldNotBeNullOrEmpty(),
                () => currencySymbol.ShouldBe(symbol));
        }

        [TestMethod]
        public void ReadStages_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;

            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 1;

            // Act
            privateObject.Invoke(ReadStagesMethodName, new ShimSqlConnection().Instance);
            var stages = privateObject.GetFieldOrProperty("m_stages") as Dictionary<int, string>;

            // Assert
            stages.ShouldSatisfyAllConditions(
                () => stages.ShouldNotBeNull(),
                () => stages.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void ReadExtraPifields_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count++ <= 1)
                {
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }

            };
            ShimOptimizerData.AllInstances.OptimizeThisTypeInt32 = (_, type) => true;
            ShimOptimizerData.ReadFieldDataFieldNameSqlDataReaderStringArray = (reader, columns) => DummyString;
            ShimOptimizerData.ReadFieldDataFieldFormatSqlDataReaderInt32StringArray = (reader, index, columns) => 1;
            ShimOptimizerData.ReadFieldDataSExtraSqlDataReaderString = (reader, column) => DummyString;

            // Act
            privateObject.Invoke(ReadExtraPifieldsMethodName, new ShimSqlConnection().Instance);
            var useExtra = privateObject.GetFieldOrProperty("m_Use_extra") as int?;
            var extraCollection = privateObject.GetFieldOrProperty("m_sextra") as string[];
            var extraFieldTypes = privateObject.GetFieldOrProperty("m_ExtraFieldTypes") as int[];

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => useExtra.GetValueOrDefault(0).ShouldBeGreaterThan(0),
                () => extraCollection.ShouldNotBeNull(),
                () => extraCollection.Any(p => p == DummyString).ShouldBeTrue(),
                () => extraFieldTypes.ShouldNotBeNull(),
                () => extraFieldTypes.Any(p => p == 1).ShouldBeTrue());
        }

        [TestMethod]
        public void ReadPILevelData_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            var fiExtra = new int[513];
            fiExtra[1] = 9911;
            ShimSqlDb.ReadDateValueObject = _ => DateTime.Now;
            ShimSqlDataReader.AllInstances.ItemGetInt32 = (_, index) => DBNull.Value;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (++count <= 1)
                {
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            privateObject.SetFieldOrProperty("m_Use_extra", 3);
            privateObject.SetFieldOrProperty("m_fidextra", fiExtra);
            ShimOptimizerData.AllInstances.MyFormatObjectInt32StringRefStringRef = MyFormatDummyMethod;

            // Act
            privateObject.Invoke(ReadPILevelDataMethodName, new ShimSqlConnection().Instance, DummyString);
            var codesCollection = privateObject.GetFieldOrProperty("m_codes") as ICollection;
            var resCollection = privateObject.GetFieldOrProperty("m_reses") as ICollection;
            var piList = privateObject.GetFieldOrProperty("m_PIs") as IList;

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => codesCollection.ShouldNotBeNull(),
                () => codesCollection.Count.ShouldBeGreaterThan(0),
                () => resCollection.ShouldNotBeNull(),
                () => resCollection.Count.ShouldBeGreaterThan(0),
                () => piList.ShouldNotBeNull(),
                () => piList.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void GetCFFieldName_TableID101_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_INT_VALUES";
            var expectedFieldName = "RI_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(101, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID102_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_TEXT_VALUES";
            var expectedFieldName = "RT_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(102, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID103_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_DEC_VALUES";
            var expectedFieldName = "RC_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(103, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID104_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_NTEXT_VALUES";
            var expectedFieldName = "RN_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(104, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID105_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_DATE_VALUES";
            var expectedFieldName = "RD_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(105, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID151_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_MV_VALUES";
            var expectedFieldName = "MVR_UID";
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(151, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID402_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PI_PROGS";
            var expectedFieldName = "PROG_PI_TEXT" + FieldId.ToString("0");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(402, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID801_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PI_WORKITEMS";
            var expectedFieldName = "WORKITEM_FLAG" + FieldId.ToString("0");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(801, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID802_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PI_WORKITEMS";
            var expectedFieldName = "WORKITEM_CTEXT" + FieldId.ToString("0");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(802, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID803_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PI_WORKITEMS";
            var expectedFieldName = "WORKITEM_NUMBER" + FieldId.ToString("0");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(803, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableIDUnkown_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "Unknown Table";
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(999, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBeEmpty());
        }

        [TestMethod]
        public void GetCFFieldName_TableID201_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PROJECT_INT_VALUES";
            var expectedFieldName = "PI_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(201, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID202_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PROJECT_TEXT_VALUES";
            var expectedFieldName = "PT_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(202, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID203_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PROJECT_DEC_VALUES";
            var expectedFieldName = "PC_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(203, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID204_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PROJECT_NTEXT_VALUES";
            var expectedFieldName = "PN_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(204, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID205_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PROJECT_DATE_VALUES";
            var expectedFieldName = "PD_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(205, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID251_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGP_PI_PROGS";
            var expectedFieldName = "PROG_UID";
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(251, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID301_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGX_PROJ_INT_VALUES";
            var expectedFieldName = "XI_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(301, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID302_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGX_PROJ_TEXT_VALUES";
            var expectedFieldName = "XT_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(302, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID303_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGX_PROJ_DEC_VALUES";
            var expectedFieldName = "XC_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(303, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID304_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGX_PROJ_NTEXT_VALUES";
            var expectedFieldName = "XN_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(304, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void GetCFFieldName_TableID305_ShouldExecuteCorrectly()
        {
            // Arrange
            const string ExpectedTableName = "EPGX_PROJ_DATE_VALUES";
            var expectedFieldName = "XD_" + FieldId.ToString("000");
            var tableName = string.Empty;
            var fieldName = string.Empty;

            // Act
            OptimizerData.GetCFFieldName(305, FieldId, out tableName, out fieldName);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(expectedFieldName));
        }

        [TestMethod]
        public void MyFormat_TypeDateAndDateMinValue_ReturnsEmptyValue()
        {
            // Arrange
            ShimSqlDb.ReadDateValueObject = _ => DateTime.MinValue;

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, DummyString, 1, DummyString, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void MyFormat_TypeDateAndDateMinValue_ReturnsValue()
        {
            // Arrange
            ShimSqlDb.ReadDateValueObject = _ => DateTime.Now;

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, DummyString, 1, DummyString, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void MyFormat_TypeDuration_ReturnsValue()
        {
            // Arrange
            const long ExpectedValue = 1;
            ShimSqlDb.ReadDecimalValueObject = _ => ExpectedValue;

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, DummyString, 23, DummyString, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue.ToString()));
        }

        [TestMethod]
        public void MyFormat_TypeRTF_ReturnsValue()
        {
            // Arrange
            ShimSqlDb.ReadStringValueObject = _ => DummyString;

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, DummyString, 19, DummyString, DummyString) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void MyFormat_TypeCode_ReturnsValue()
        {
            // Arrange
            const int ExpectedValue = 2;
            ShimSqlDb.ReadIntValueObject = _ => ExpectedValue;
            var args = new object[] { DummyString, 4, DummyString, DummyString };

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, args) as string;
            var response = args[2] as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue.ToString()),
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.Contains(ExpectedValue.ToString()).ShouldBeTrue());
        }

        [TestMethod]
        public void MyFormat_TypeCodeAndCodesEmpty_ReturnsValue()
        {
            // Arrange
            const int ExpectedValue = 2;
            ShimSqlDb.ReadIntValueObject = _ => ExpectedValue;
            var args = new object[] { DummyString, 4, string.Empty, DummyString };

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, args) as string;
            var response = args[2] as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue.ToString()),
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.Contains(ExpectedValue.ToString()).ShouldBeTrue());
        }

        [TestMethod]
        public void MyFormat_TypeRes_ReturnsValue()
        {
            // Arrange
            const int ExpectedValue = 7;
            ShimSqlDb.ReadIntValueObject = _ => ExpectedValue;
            var args = new object[] { DummyString, 7, DummyString, string.Empty };

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, args) as string;
            var response = args[3] as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue.ToString()),
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.Contains(ExpectedValue.ToString()).ShouldBeTrue());
        }

        [TestMethod]
        public void MyFormat_TypeResAndResEmpty_ReturnsValue()
        {
            // Arrange
            const int ExpectedValue = 7;
            ShimSqlDb.ReadIntValueObject = _ => ExpectedValue;
            var args = new object[] { DummyString, 7, DummyString, string.Empty };

            // Act
            var result = privateObject.Invoke(MyFormatMethodName, args) as string;
            var response = args[3] as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue.ToString()),
                () => response.ShouldNotBeNullOrEmpty(),
                () => response.Contains(ExpectedValue.ToString()).ShouldBeTrue());
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeYesNoInput1_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = "Yes";
            var input = "1";
            var type = 13;

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeYesNoInput0_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = "No";
            var input = "0";
            var type = 13;

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeText_ReturnsExpectedResult()
        {
            // Arrange
            var input = DummyString;
            var type = 9;

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeCode_ReturnsExpectedResult()
        {
            // Arrange
            var input = "1";
            var type = 4;

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeCodeOnException_ReturnsExpectedResult()
        {
            // Arrange
            var input = "1";
            var type = 4;
            privateObject.SetFieldOrProperty("m_codes", null);

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeRes_ReturnsExpectedResult()
        {
            // Arrange
            var input = "1";
            var type = 7;
            privateObject.SetFieldOrProperty("m_reses", new Dictionary<int, string>
            {
                [1] = DummyString
            });

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeResOnException_ReturnsExpectedResult()
        {
            // Arrange
            var input = "1";
            var type = 7;
            privateObject.SetFieldOrProperty("m_reses", null);

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void FormatExportExtraData_FieldTypeUnknown_ReturnsExpectedResult()
        {
            // Arrange
            var input = "1";
            var type = 999;

            // Act
            var result = privateObject.Invoke(FormatExportExtraDataMethodName, input, type) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void OptimizeThisType_FieldTypeDate_ReturnsFalse()
        {
            // Arrange
            const int FieldType = 1;

            // Act
            var result = privateObject.Invoke(OptimizeThisTypeMethodName, FieldType) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeFalse());
        }

        [TestMethod]
        public void OptimizeThisType_FieldTypeInteger_ReturnsTrue()
        {
            // Arrange
            const int FieldType = 2;

            // Act
            var result = privateObject.Invoke(OptimizeThisTypeMethodName, FieldType) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void OptimizeThisType_FieldTypeRes_ReturnsFalse()
        {
            // Arrange
            const int FieldType = 7;

            // Act
            var result = privateObject.Invoke(OptimizeThisTypeMethodName, FieldType) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeFalse());
        }

        [TestMethod]
        public void OptimizeThisType_FieldTypeUnknown_ReturnsFalse()
        {
            // Arrange
            const int FieldType = 987;

            // Act
            var result = privateObject.Invoke(OptimizeThisTypeMethodName, FieldType) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeFalse());
        }

        [TestMethod]
        public void StripNum_ValueWithSpace_ShouldExecuteCorrectly()
        {
            // Arrange
            var args = new object[] { "1 2" };

            // Act
            var result = privateObject.Invoke(StripNumMethodName, args) as int?;
            var original = args[0] as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(1),
                () => original.ShouldNotBeNullOrEmpty(),
                () => original.ShouldBe("2"));
        }

        [TestMethod]
        public void StripNum_ValueWithoutSpace_ShouldExecuteCorrectly()
        {
            // Arrange
            var args = new object[] { "12" };

            // Act
            var result = privateObject.Invoke(StripNumMethodName, args) as int?;
            var original = args[0] as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(12),
                () => original.ShouldNotBeNull(),
                () => original.ShouldBeEmpty());
        }

        [TestMethod]
        public void FormatSQLDateTime_Should_ReturnExpectedValue()
        {
            // Arrange
            var date = DateTime.Now;
            var expectedValue = "CONVERT(DATETIME, '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "', 102)";

            // Act
            var result = privateObject.Invoke(FormatSQLDateTimeMethodName, date) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void OptimizerLoadData_Should_ReturnContent()
        {
            // Arrange
            var count = 0;
            ShimOptimizerData.AllInstances.OptimizerLoadDataString = null;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlDb.ReadDateValueObject = _ => DateTime.Now;
            ShimSqlDataReader.AllInstances.ItemGetInt32 = (_, index) => DBNull.Value;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (++count <= 1)
                {
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            privateObject.SetFieldOrProperty("m_Use_extra", 3);
            ShimOptimizerData.AllInstances.MyFormatObjectInt32StringRefStringRef = MyFormatDummyMethod;

            // Act
            var result = optimizerData.OptimizerLoadData(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GrabPidsFromTicket_Should_ReturnExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "1,1";
            var count = 0;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (++count <= 1)
                {
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            ShimSqlDb.ReadStringValueObject = _ => $"{DummyGuid},{DummyGuid}";
            ShimSqlDb.ReadIntValueObject = _ => 1;

            // Act
            var result = optimizerData.GrabPidsFromTicket(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }
    }
}
