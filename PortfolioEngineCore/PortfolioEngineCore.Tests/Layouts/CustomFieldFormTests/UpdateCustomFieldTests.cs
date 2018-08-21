using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Layouts.ppm.Fakes;

namespace PortfolioEngineCore.Tests.Layouts
{
    public partial class CustomFieldFormTests
    {
        [TestMethod]
        public void UpdateCustomField_When_Field_Exist()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;

            // Act
            var actualStatus = _privateObject.Invoke(
                UpdatecustomfieldMethod,
                BindingFlags.Static | BindingFlags.NonPublic,
                dba,
                new ShimCustomFieldForm().Instance,
                lRowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsCreated.Count, _shimAdoNetCalls.CommandsDisposed.Count);
        }

        [TestMethod]
        public void UpdateCustomField_When_FieldId_Not_Zero()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            ShimCustomFieldForm.AllInstances.idGet = _ => 1;

            // Act
            var actualStatus = _privateObject.Invoke(
                UpdatecustomfieldMethod,
                BindingFlags.Static | BindingFlags.NonPublic,
                dba,
                new ShimCustomFieldForm().Instance,
                lRowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("UPDATE EPGC_FIELD_ATTRIBS  SET FA_NAME=@pNAME,FA_DESC=@pDESC WHERE FA_FIELD_ID = 1", list[1].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("UPDATE EPGC_FIELD_ATTRIBS  SET FA_NAME=@pNAME,FA_DESC=@pDESC WHERE FA_FIELD_ID = 1", list[1].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsCreated.Count, _shimAdoNetCalls.CommandsDisposed.Count);
        }

        [TestMethod]
        public void UpdateCustomField_When_FieldId_Zero()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            ShimCustomFieldForm.AllInstances.idGet = _ => 0;
            ShimCustomFieldForm.AllInstances.EntityGet = _ => (int)EntityID.Resource;
            ShimCustomFieldForm.AllInstances.DataTypeGet = _ => (int)FieldType.TypeNumber;
            ShimSqlDb.ReadIntValueObject = o => 0;

            // Act
            var actualStatus = _privateObject.Invoke(
                UpdatecustomfieldMethod,
                BindingFlags.Static | BindingFlags.NonPublic,
                dba,
                new ShimCustomFieldForm().Instance,
                lRowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID=103", list[1].CommandText);
            Assert.AreEqual("INSERT Into EPGC_FIELD_ATTRIBS  (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE) Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)", list[2].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @FIELD_NAME", list[0].CommandText);
            Assert.AreEqual("SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID=103", list[1].CommandText);
            Assert.AreEqual("INSERT Into EPGC_FIELD_ATTRIBS  (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE) Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)", list[2].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsCreated.Count, _shimAdoNetCalls.CommandsDisposed.Count);
        }
    }
}