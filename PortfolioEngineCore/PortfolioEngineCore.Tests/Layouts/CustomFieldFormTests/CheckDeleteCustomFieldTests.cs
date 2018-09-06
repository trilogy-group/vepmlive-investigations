using System;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests.Layouts
{
    public partial class CustomFieldFormTests
    {
        [TestMethod]
        public void CheckDeleteCustomField_When_Table_150_Should_Return_True()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var message = string.Empty;
            var args = new object[] { dba, 1, message };

            ShimSqlDb.ReadIntValueObject = o => 150;
            ShimSqlDb.ReadStringValueObject = o => "field name";

            // Act
            var actual = (bool)_privateObject.Invoke("CheckDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual("Values for field name will be cleared from all Resources<br><br>Are you sure you want to delete this custom field?", args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
        }

        [TestMethod]
        public void CheckDeleteCustomField_When_Table_50_Should_Return_True()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var message = string.Empty;
            var args = new object[] { dba, 1, message };

            ShimSqlDb.ReadIntValueObject = o => 50;
            ShimSqlDb.ReadStringValueObject = o => "field name";

            // Act
            var actual = (bool)_privateObject.Invoke("CheckDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual("Values for field name will be cleared from all PIs<br><br>Are you sure you want to delete this custom field?", args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
        }

        [TestMethod]
        public void CheckDeleteCustomField_When_Exception_Should_Return_True()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var message = string.Empty;
            var args = new object[] { dba, 1, message };

            ShimSqlDataReader.AllInstances.ItemGetString = (a, key) =>
            {
                throw new Exception();
            };

            // Act
            var actual = (bool)_privateObject.Invoke("CheckDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual("<br>Check for field FAILED!<br><br>Are you sure you want to delete this custom field?", args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
        }

        [TestMethod]
        public void CheckDeleteCustomField_Should_Return_True()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var message = string.Empty;
            var args = new object[] { dba, 1, message };
            ShimSqlDataReader.AllInstances.Read = reader => false;

            // Act
            var actual = (bool)_privateObject.Invoke("CheckDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual("Values for  will be cleared from all PIs<br><br>Are you sure you want to delete this custom field?", args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadFieldInfo", list[0].CommandText);
        }
    }
}