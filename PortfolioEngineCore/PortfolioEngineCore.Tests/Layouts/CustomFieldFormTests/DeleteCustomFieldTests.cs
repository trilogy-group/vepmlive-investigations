using System;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Layouts.ppm.Fakes;

namespace PortfolioEngineCore.Tests.Layouts
{
    public partial class CustomFieldFormTests
    {
        [TestMethod]
        public void DeleteCustomField_When_ResourceMV_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            var args = new object[] { dba, new ShimCustomFieldForm().Instance, lRowsAffected };

            ShimSqlDb.ReadIntValueObject = o => (int)CustomFieldTable.ResourceMV;

            // Act
            var actual = (StatusEnum)_privateObject.Invoke("DeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
            Assert.AreEqual("Delete From EPGC_RESOURCE_MV_VALUES Where MVR_FIELD_ID= @FieldId", list[1].CommandText);
            Assert.AreEqual("EPG_SP_DeleteCustomFieldX", list[2].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
            Assert.AreEqual("Delete From EPGC_RESOURCE_MV_VALUES Where MVR_FIELD_ID= @FieldId", list[1].CommandText);
            Assert.AreEqual("EPG_SP_DeleteCustomFieldX", list[2].CommandText);
        }

        [TestMethod]
        public void DeleteCustomField_When_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            var args = new object[] { dba, new ShimCustomFieldForm().Instance, lRowsAffected };

            ShimSqlDb.ReadIntValueObject = o => (int)CustomFieldTable.ResourceINT;

            // Act
            var actual = (StatusEnum)_privateObject.Invoke("DeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
            Assert.AreEqual("Update EPGC_RESOURCE_INT_VALUES Set RI_101=NULL", list[1].CommandText);
            Assert.AreEqual("EPG_SP_DeleteCustomFieldX", list[2].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
            Assert.AreEqual("Update EPGC_RESOURCE_INT_VALUES Set RI_101=NULL", list[1].CommandText);
            Assert.AreEqual("EPG_SP_DeleteCustomFieldX", list[2].CommandText);
        }

        [TestMethod]
        public void DeleteCustomField_When_Should_Return_RequestCannotBeCompleted()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            var args = new object[] { dba, new ShimCustomFieldForm().Instance, lRowsAffected };

            // Act
            var actual = (StatusEnum)_privateObject.Invoke("DeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, actual);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
        }

        [TestMethod]
        public void DeleteCustomField_When_Exception_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var lRowsAffected = 0;
            var args = new object[] { dba, new ShimCustomFieldForm().Instance, lRowsAffected };

            ShimSqlDataReader.AllInstances.ItemGetString = (a, key) =>
            {
                throw new Exception();
            };

            // Act
            var actual = (StatusEnum)_privateObject.Invoke("DeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
        }
    }
}