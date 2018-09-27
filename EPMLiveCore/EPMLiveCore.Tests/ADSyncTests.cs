using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Fakes;
using System.Linq;
using System.Security.Principal.Fakes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class ADSyncTests
    {
        private IDisposable _shims;

        private ADSync _adSync;

        private PrivateObject _adSyncObject;
        //protected AdoShims _adoShims;
        //protected SharepointShims _sharepointShims;

        [TestInitialize]
        public void Initialize()
        {
            _shims = ShimsContext.Create();
            _adSync = new ADSync();
            _adSyncObject = new PrivateObject(_adSync);
            //_adoShims = AdoShims.ShimAdoNetCalls();
            //_sharepointShims = SharepointShims.ShimSharepointCalls();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shims?.Dispose();
        }

        [TestMethod]
        public void GetUserSID_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryDisposed = false;
            ShimDirectoryEntry.ConstructorStringStringStringAuthenticationTypes = (instance, __, ___, ____, _____) =>
            {
                new ShimDirectoryEntry(instance)
                {
                    PropertiesGet = () => new ShimPropertyCollection
                    {
                        ItemGetString = key => new ShimPropertyValueCollection
                        {
                            ItemGetInt32 = index => new byte[] {}
                        }
                    },
                    DisposeBoolean = _ => { directoryDisposed = true; }
                };
            };

            ShimSecurityIdentifier.ConstructorByteArrayInt32 = (instance, __, ___) =>
            {
                new ShimSecurityIdentifier(instance)
                {
                    ValueGet = () => "SampleSID"
                };
            };

            // Act
            var result = _adSyncObject.Invoke("GetUserSID", string.Empty);

            // Assert
            Assert.AreEqual("SampleSID", result);
            Assert.IsTrue(directoryDisposed);
        }
    }
}
