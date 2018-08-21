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
        public void CanDeleteCustomField_Should_Return_False()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var message = string.Empty;
            var args = new object[] { dba, 1, message };

            ShimSqlDataReader.AllInstances.ItemGetString = (a, key) =>
            {
                switch (key)
                {
                    case "UsedMessage":
                        return "UsedMessage";
                    case "UsedData":
                        return "UsedData";
                    default:
                        return string.Empty;
                }
            };

            // Act
            var actual = (bool)_privateObject.Invoke("CanDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual("This custom field cannot be deleted until you remove it from these areas:<br>UsedMessage: UsedData", args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadUsedCF", list[0].CommandText);
        }

        [TestMethod]
        public void CanDeleteCustomField_When_Exception_Should_Return_False()
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
            var actual = (bool)_privateObject.Invoke("CanDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual("This custom field cannot be deleted until you remove it from these areas:<br>Check for field used FAILED!", args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadUsedCF", list[0].CommandText);
        }

        [TestMethod]
        public void CanDeleteCustomField_Should_Return_True()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var message = string.Empty;
            var args = new object[] { dba, 1, message };
            ShimSqlDataReader.AllInstances.Read = reader => false;

            // Act
            var actual = (bool)_privateObject.Invoke("CanDeleteCustomField", BindingFlags.Static | BindingFlags.NonPublic, args);

            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(string.Empty, args[2]);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("EPG_SP_ReadUsedCF", list[0].CommandText);
        }
    }
}