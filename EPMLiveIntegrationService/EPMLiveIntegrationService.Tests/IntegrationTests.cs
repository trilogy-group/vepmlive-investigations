using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using System.Web.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveIntegrationService.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private IDisposable _shimContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void iAuthenticate_Should_Dispose()
        {
            // Arrange
            var service = new Integration();
            ArrangeShims();
            var ret = string.Empty;
            var dsIntegration = new DataSet();
            var disposeCommandWasCalled = 0;
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, b) =>
            {
                disposeCommandWasCalled++;
            };
            var disposeAdapterWasCalled = 0;
            ShimDbDataAdapter.AllInstances.DisposeBoolean = (adapter, b) =>
            {
                disposeAdapterWasCalled++;
            };

            // Act
            InvokeMethod(service, "iAuthenticate", new object[] {string.Empty, ret, dsIntegration, new ShimSqlConnection().Instance} );

            //Assert
            Assert.AreEqual(1, disposeCommandWasCalled);
            Assert.AreEqual(0, disposeAdapterWasCalled);
        }

        private void ArrangeShims()
        {
            ShimHttpContext.CurrentGet = () => new ShimHttpContext(); 
            ShimHttpContext.AllInstances.RequestGet =context => new ShimHttpRequest();

            ShimHttpRequest.AllInstances.UserHostAddressGet = request => string.Empty;

            ShimSqlDataReader.AllInstances.GetInt32Int32 = (reader, i) => 0;

            ShimSqlCommand.AllInstances.ExecuteReader = command => new ShimSqlDataReader();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 0;

            ShimSqlDataAdapter.ConstructorSqlCommand = (adapter, command) => { };

            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, set) => 0;
        }

        public static void InvokeMethod(object obj, string methodName, object[] parameters)
        {
            var dynMethod = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod?.Invoke(obj, parameters);
        }
    }
}
