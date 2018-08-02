using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using System.Web.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveIntegrationService.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerService.Fakes;

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
            Assert.AreEqual(2, disposeCommandWasCalled);
            Assert.AreEqual(1, disposeAdapterWasCalled);
        }

        [TestMethod]
        public void iCheckAuth_Should_Dispose()
        {
            // Arrange
            var service = new Integration();
            ArrangeShims();
            var disposeCommandWasCalled = 0;
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, b) =>
            {
                disposeCommandWasCalled++;
            };
            
            // Act
            InvokeMethod(service, "iCheckAuth", new object[] { new ShimSPWebApplication().Instance, string.Empty });

            //Assert
            Assert.AreEqual(1, disposeCommandWasCalled);
        }

        [TestMethod]
        public void iDeleteItem_Should_Dispose()
        {
            // Arrange
            var service = new Integration();
            ArrangeShims();
            var disposeCommandWasCalled = 0;
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, b) =>
            {
                disposeCommandWasCalled++;
            };
            ShimIntegration.GetRowsCountDataSetInt32 = (set, i) => 1;

            // Act
            InvokeMethod(service, "iDeleteItem", new object[] { new ShimSPWebApplication().Instance, string.Empty, string.Empty });

            //Assert
            Assert.AreEqual(2, disposeCommandWasCalled);
        }

        [TestMethod]
        public void iPostComplex_Should_Dispose()
        {
            // Arrange
            var service = new Integration();
            ArrangeShims();
            var disposeCommandWasCalled = 0;
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, b) =>
            {
                disposeCommandWasCalled++;
            };
            ShimIntegration.GetRowsCountDataSetInt32 = (set, i) => 1;
            ShimSqlDataReader.AllInstances.Read = reader => true;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (reader, i) => "id";

            
            string xml = @"<root>
    <Items>
        <Item>
            <Fields>
                <Field name='id'>
                </Field>
            </Fields>
        </Item>
    </Items>
</root>";
            var document = new XmlDocument();
            document.LoadXml(xml);
            ShimXmlNode.AllInstances.SelectNodesString = (node, s) => new ShimXmlNodeList(document.ChildNodes);

            // Act
            InvokeMethod(service, "iPostComplex", new object[] { new ShimSPWebApplication().Instance, string.Empty, xml });

            //Assert
            Assert.AreEqual(2, disposeCommandWasCalled);
        }

        [TestMethod]
        public void iPostSimple_Should_Dispose()
        {
            // Arrange
            var service = new Integration();
            ArrangeShims();
            var disposeCommandWasCalled = 0;
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, b) =>
            {
                disposeCommandWasCalled++;
            };
            ShimIntegration.GetRowsCountDataSetInt32 = (set, i) => 1;

            // Act
            InvokeMethod(service, "iPostSimple", new object[] { new ShimSPWebApplication().Instance, string.Empty, string.Empty, string.Empty });

            //Assert
            Assert.AreEqual(2, disposeCommandWasCalled);
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

            ShimSPSecurity.RunWithElevatedPrivilegesWaitCallbackObject = (callback, o) => { };

            ShimSPPersistedObject.AllInstances.IdGet = o => Guid.Empty;

            ShimSqlConnection.ConstructorString = (connection, s) => { };
            ShimSqlConnection.AllInstances.Open = connection => { };
            ShimSqlConnection.AllInstances.Close = connection => { };

            ShimIntegration.GetRowValueDataSetStringInt32Int32 = (set, s, arg3, arg4) => Integration.ModuleId;
            ShimIntegration.iCheckXmlXmlDocumentStringOut = (XmlDocument document, out string error) =>
            {
                error = string.Empty;
                return true;
            };

            ShimXmlNode.AllInstances.SelectSingleNodeString = (node, s) => new ShimXmlDocument();
            ShimXmlNode.AllInstances.InnerTextGet = node => "id";
        }

        public static void InvokeMethod(object instance, string methodName, object[] parameters)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var dynMethod = instance.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod?.Invoke(instance, parameters);
        }
    }
}