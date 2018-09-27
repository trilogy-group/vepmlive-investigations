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

        private const string SampleSid = "SampleSID";
        private bool _directoryDisposed;

        [TestInitialize]
        public void Initialize()
        {
            _shims = ShimsContext.Create();
            _adSync = new ADSync();
            _adSyncObject = new PrivateObject(_adSync);
            SetupShims();
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
            // Arrange, Act
            var result = _adSyncObject.Invoke("GetUserSID", string.Empty);

            // Assert
            Assert.AreEqual(SampleSid, result);
            Assert.IsTrue(_directoryDisposed);
        }

        [TestMethod]
        public void GetUserSIDByCN_Called_DirectoryDisposed()
        {
            // Arrange, Act
            var result = _adSyncObject.Invoke("GetUserSIDByCN", string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(SampleSid.ToUpper(), result);
            Assert.IsTrue(_directoryDisposed);
        }

        private void SetupShims()
        {
            ShimDirectoryEntry.ConstructorStringStringStringAuthenticationTypes = (instance, __, ___, ____, _____) =>
            {
                new ShimDirectoryEntry(instance)
                {
                    PropertiesGet = () => new ShimPropertyCollection
                    {
                        ItemGetString = key => new ShimPropertyValueCollection
                        {
                            ItemGetInt32 = index => new byte[] { }
                        }
                    },
                    DisposeBoolean = _ => { _directoryDisposed = true; }
                };
            };

            ShimSecurityIdentifier.ConstructorByteArrayInt32 = (instance, __, ___) =>
            {
                new ShimSecurityIdentifier(instance)
                {
                    ValueGet = () => SampleSid
                };
            };
        }
    }
}
