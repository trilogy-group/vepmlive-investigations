using System;
using System.Collections;
using System.Collections.Fakes;
using System.Data;
using System.DirectoryServices.Fakes;
using System.Linq;
using System.Security.Principal.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class ADSyncLeakTests
    {
        private const string SampleSid = "SampleSID";
        private const string SamplePropertyValue = "SamplePropertyValue";
        private const string ColumnSid = "SID";
        private const string SampleGroup = "SampleGroup";
        private const string SampleName = "SampleName";

        private IDisposable _shims;
        private ADSync _adSync;
        private PrivateObject _adSyncObject;

        private bool _directoryDisposed;

        [TestInitialize]
        public void Initialize()
        {
            _shims = ShimsContext.Create();
            _adSync = new ADSync();
            _adSyncObject = new PrivateObject(_adSync);
            SetupShims();
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

        [TestMethod]
        public void AddResourceToDataTable_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryShims = DirectoryShims.ShimDirectoryCalls();
            ShimDirectorySearcher.ConstructorDirectoryEntryString = (instance, _, __) =>
            {
                new ShimDirectorySearcher(instance)
                {
                    FindOne = () => directoryShims.SearchResultShim
                };
            };
            var table = new DataTable();
            table.Columns.Add(ColumnSid);
            _adSyncObject.SetField("_adUsers", table);

            // Act
            _adSyncObject.Invoke("AddResourceToDataTable", string.Empty);

            // Assert
            Assert.AreEqual(SampleSid, table.Rows[0][ColumnSid]);
            Assert.IsTrue(directoryShims.DirectorySearchersDisposed.Any());
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed.Any());
        }

        [TestMethod]
        public void GetADGroupUserAttributes_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryShims = DirectoryShims.ShimDirectoryCalls();
            ShimDirectorySearcher.ConstructorDirectoryEntryString = (instance, _, __) =>
            {
                new ShimDirectorySearcher(instance)
                {
                    FindOne = () => directoryShims.SearchResultShim
                };
            };
            var table = new DataTable();
            table.Columns.Add(ColumnSid);
            _adSyncObject.SetField("_adUsers", table);

            // Act
            var result = _adSync.GetADGroupUserAttributes(string.Empty, string.Empty);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SamplePropertyValue.ToLower(), result.FirstOrDefault());
            Assert.IsTrue(directoryShims.DirectorySearchersDisposed.Any());
            Assert.AreEqual(2, directoryShims.DirectoryEntriesDisposed.Count);
        }

        [TestMethod]
        public void PopulateAllGroupUserAttributes_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryShims = DirectoryShims.ShimDirectoryCalls();
            ShimDirectorySearcher.ConstructorDirectoryEntryString = (instance, _, __) =>
            {
                new ShimDirectorySearcher(instance)
                {
                    FindOne = () => directoryShims.SearchResultShim
                };
            };
            var table = new Hashtable
            {
                { SampleGroup, SampleGroup }
            };
            _adSyncObject.SetField("_adGroupNameAndPath", table);
            _adSyncObject.SetField("_groupName", SampleGroup);
            _adSyncObject.SetField("_adExclusions", new ArrayList());

            ShimADSync.GetSizeLimit = () => 1;
            ShimADSync.AllInstances.GetUserSIDString = (_, __) => SampleSid;
            ShimADSync.AllInstances.userDisabledString = (_, __) => false;
            ShimADSync.AllInstances.AddResourceToDataTableString = (_, __) => { };

            // Act
            var result = _adSyncObject.Invoke("PopulateAllGroupUserAttributes");

            // Assert
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
            var hasErrors = _adSyncObject.GetField("_hasErrors");
            Assert.IsInstanceOfType(hasErrors, typeof(bool));
            Assert.IsFalse((bool)hasErrors);
            Assert.IsTrue(directoryShims.DirectorySearchersDisposed.Any());
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed.Any());
        }

        [TestMethod]
        public void GetGroups_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryShims = DirectoryShims.ShimDirectoryCalls();
            directoryShims.DirectoryEntryShim.NameGet = () => SampleName;

            // Act
            var result = _adSync.GetGroups(string.Empty);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(SampleName, result[0]);
            Assert.IsTrue(directoryShims.DirectorySearchersDisposed.Any());
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed.Any());
        }

        [TestMethod]
        public void userDisabled_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryShims = DirectoryShims.ShimDirectoryCalls();
            ShimDirectorySearcher.ConstructorDirectoryEntry = (instance, _) =>
            {
                new ShimDirectorySearcher(instance)
                {
                    FindOne = () => directoryShims.SearchResultShim
                };
            };

            // Act
            var result = _adSyncObject.Invoke("userDisabled", SampleSid);

            // Assert
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
            Assert.IsTrue(directoryShims.DirectorySearchersDisposed.Any());
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed.Any());
        }

        [TestMethod]
        public void userDeleted_Called_DirectoryDisposed()
        {
            // Arrange
            var directoryShims = DirectoryShims.ShimDirectoryCalls();

            // Act
            var result = _adSyncObject.Invoke("userDeleted", SampleSid);

            // Assert
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed.Any());
        }

        private void SetupShims()
        {
            ShimDirectoryEntry.ConstructorStringStringStringAuthenticationTypes = (instance, __, ___, ____, _____) =>
            {
                new ShimDirectoryEntry(instance)
                {
                    DisposeBoolean = _ =>
                    {
                        _directoryDisposed = true;
                    }
                };
            };

            var shimPropertyValueCollection = new ShimPropertyValueCollection
            {
                ItemGetInt32 = index => new byte[] { }
            };
            new System.Collections.Fakes.ShimCollectionBase(shimPropertyValueCollection)
            {
                GetEnumerator = () => new[] { SamplePropertyValue }.GetEnumerator()
            };
            var shimPropertyCollection = new ShimPropertyCollection
            {
                ItemGetString = key => shimPropertyValueCollection,
            };
            ShimDirectoryEntry.AllInstances.PropertiesGet = _ => shimPropertyCollection;
            ShimDirectoryEntry.AllInstances.RefreshCacheStringArray = (entry, strings) => { };
            ShimDirectoryEntry.AllInstances.RefreshCache = entry => { };

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