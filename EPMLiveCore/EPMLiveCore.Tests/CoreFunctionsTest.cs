using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Fakes;
using System.Text;
using System.Threading.Tasks;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class CoreFunctionsTest
    {
        private IDisposable _shimsContext;
        private AdoShims _adoShims;
        private SharepointShims _sharepointShims;
        private IOShims _ioShims;
        private CryptographyShims _cryptographyShims;

        private Guid _timerJobBuild;
        private int _defaultStatus;
        private string _spQuery;
        private string _filterFieldName;
        private string _useWbs;
        private string _listTitlePattern;
        private IList<string> _groupByFieldNames;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
            _ioShims = IOShims.ShimIOCalls();
            _cryptographyShims = CryptographyShims.ShimCryptographyCalls();

            _timerJobBuild = Guid.NewGuid();
            _defaultStatus = 1;

            _spQuery = string.Empty;
            _filterFieldName = string.Empty;
            _useWbs = string.Empty;
            _listTitlePattern = string.Empty;
            _groupByFieldNames = new List<string>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void enqueue_SiteIsNull_Throw()
        {
            // Arrange
            SPSite site = null;

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, site);

            // Assert
            // ExpectedException - ArgumentNull
        }

        [TestMethod]
        public void enqueue_Always_RunsWithElevatedPriveleges()
        {
            // Arrange
            var isRunWithElevatedPriveleges = false;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action =>
            {
                isRunWithElevatedPriveleges = true;
            };

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            Assert.IsTrue(isRunWithElevatedPriveleges);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyManagesDatabaseConnection()
        {
            // Arrange
            const string connectionStringExpected = @"Data Source=(local)\SQLExpress;Initial Catalog=MyDatabase;";
            ShimCoreFunctions.getConnectionStringGuid = webApplicationId => connectionStringExpected;

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            Assert.AreEqual(1, _adoShims.ConnectionsCreated.Count);
            Assert.AreEqual(1, _adoShims.ConnectionsOpened.Count);
            Assert.AreEqual(1, _adoShims.ConnectionsDisposed.Count);
            Assert.IsTrue(_adoShims.IsConnectionCreated(connectionStringExpected));
            Assert.IsTrue(_adoShims.IsConnectionOpened(connectionStringExpected));
            Assert.IsTrue(_adoShims.IsConnectionDisposed(connectionStringExpected));
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesQueueStatusCommand()
        {
            // Arrange
            const string commandTextExpected = "select status from queue where timerjobuid=@timerjobuid";
            const string commandParameterExpected = "@timerjobuid";

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsDataReaderCreatedForCommand(commandTextExpected);
            _adoShims.IsDataReaderDisposedForCommand(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(1, command.Parameters.Count);
            Assert.AreEqual(commandParameterExpected, command.Parameters[0].ParameterName);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesDeleteFromQueueCommand()
        {
            // Arrange
            const string commandTextExpected = "DELETE FROM QUEUE where timerjobuid = @timerjobuid ";
            const string commandParameterExpected = "@timerjobuid";

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsCommandExecuted(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(1, command.Parameters.Count);
            Assert.AreEqual(commandParameterExpected, command.Parameters[0].ParameterName);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesDeleteFromLogCommand()
        {
            // Arrange
            const string commandTextExpected = "DELETE FROM EPMLIVE_LOG where timerjobuid = @timerjobuid ";
            const string commandParameterExpected = "@timerjobuid";

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsCommandExecuted(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(1, command.Parameters.Count);
            Assert.AreEqual(commandParameterExpected, command.Parameters[0].ParameterName);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesInsertIntoQueueCommand()
        {
            // Arrange
            const string commandTextExpected = @"INSERT INTO QUEUE (timerjobuid, status, percentcomplete, userid) 
                                                                  VALUES (@timerjobuid, @status, 0, @userid) ";
            var commandParametersExpected = new[] { "@timerjobuid", "@status", "@userid" };

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsCommandExecuted(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(commandParametersExpected.Length, command.Parameters.Count);
            Assert.IsTrue(commandParametersExpected.All(pred => command.Parameters.Contains(pred)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "web")]
        public void getSiteItems_WebParameterNull_Throws()
        {
            // Arrange, Act
            CoreFunctions.getSiteItems(
                null,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            // ExpectedException - ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "view")]
        public void getSiteItems_ViewParameterNull_Throws()
        {
            // Arrange, Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                null,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            // ExpectedException - ArgumentNullException
        }

        [TestMethod]
        public void getSiteItems_Always_ConnectionIsManagedCorrectly()
        {
            // Arrange, Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            _adoShims.IsConnectionManagedCorrectly(SharepointShims.DatabaseConnectionString);
        }

        [TestMethod]
        public void getSiteItems_Always_ViewFieldsAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            var viewField = _sharepointShims.ViewShim.Instance.ViewFields.Cast<string>().First();
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='{viewField}' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_Always_GroupByFieldsAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };
            _groupByFieldNames = new[] { "Group-by-Field " };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='{_groupByFieldNames[0]}' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_Always_OrderByFieldsAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };
            var orderByFieldName = "TestField";
            _spQuery = $"<OrderBy><F Name='{orderByFieldName}'></F></OrderBy>";

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='{orderByFieldName}' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_ParentListContainsTitleField_TitleFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };
            _sharepointShims.FieldsShim.ContainsFieldString = fieldName => true;

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='Title' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoCreatedField_CreatedFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='Created' />"));
        }

        [TestMethod]
        public void getSiteItems_NoModerationStatusField_ModerationStatusFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='_ModerationStatus' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoFilterField_FilterFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };
            _filterFieldName = "test-filter-field";

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='{_filterFieldName}' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoUseWbsField_UseWbsFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };
            _useWbs = "test-filter-field";

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='{_useWbs}' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoCommentCountField_CommentCountFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='CommentCount' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoListField_ListFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='List' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoCommentersField_CommentersFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='Commenters' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoCommentersReadField_CommentersReadFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='CommentersRead' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoAssignedToField_AssignedToFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='_ModerationStatus' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoAuthorField_AuthorFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='Author' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoChildItemField_ChildItemFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='ChildItem' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoParentItemField_ParentItemFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='ParentItem' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_NoWorkspaceUrlField_WorkspaceUrlFieldAdded()
        {
            // Arrange
            string fieldsXml = null;
            ShimSPSiteDataQuery.AllInstances.ViewFieldsSetString = (instance, fieldsXmlParamter) =>
            {
                fieldsXml = fieldsXmlParamter;
            };

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.IsNotNull(fieldsXml);
            Assert.IsTrue(fieldsXml.Contains($"<FieldRef Name='WorkspaceUrl' Nullable='TRUE' />"));
        }

        [TestMethod]
        public void getSiteItems_HasListTitlePattern_CommandCorrectlyManaged()
        {
            // Arrange
            const string commandTextPattern = @"SELECT dbo.AllLists.tp_ID";
            _listTitlePattern = "test";

            // Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            var commandsInSubject = _adoShims.CommandsCreated
                .Where(pred => pred.CommandText.StartsWith(commandTextPattern))
                .ToArray();

            Assert.AreEqual(1, commandsInSubject.Length);
            Assert.IsTrue(_adoShims.IsCommandManagedCorrectly(commandsInSubject[0].CommandText));
        }

        [TestMethod]
        public void getSiteItems_HasListIds_GetSiteDataExecuted()
        {
            // Arrange
            var resultExpected = new DataTable();
            SPSiteDataQuery queryUsed = null;
            _sharepointShims.WebShim.GetSiteDataSPSiteDataQuery = query =>
            {
                queryUsed = query;
                return resultExpected;
            };

            // Act
            var result = CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            Assert.AreEqual(resultExpected, result);
            Assert.IsNotNull(queryUsed);
            Assert.AreEqual($"<Lists MaxListLimit='0'><List ID='{Guid.Empty}'/></Lists>", queryUsed.Lists);
            Assert.AreEqual(_spQuery, queryUsed.Query);
            Assert.AreEqual(SPQueryThrottleOption.Override, queryUsed.QueryThrottleMode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "userName")]
        public void getUserFromAD_UserNameNull_Throws()
        {
            // Arrange
            string username = null;

            // Act
            CoreFunctions.getUserFromAD(username);

            // Assert
            // ExpectedException: ArgumentNullException
        }

        [TestMethod]
        public void getUserFromAD_NameNotEmpty_CorretlyManagesDirectoryEntry()
        {
            // Arrange
            const string userName = "test";
            ShimCoreFunctions.getDomain = () => string.Empty;
            var directoryShims = DirectoryShims.ShimDirectoryCalls();

            // Act
            CoreFunctions.getUserFromAD(userName);

            // Assert
            Assert.AreEqual(1, directoryShims.DirectoryEntriesDisposed.Count);
            Assert.AreEqual(AuthenticationTypes.Secure, directoryShims.DirectoryEntriesDisposed[0].AuthenticationType);
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed[0].Path.StartsWith("LDAP://"));
        }

        [TestMethod]
        public void getUserFromAD_NameNotEmpty_DirectorySearcherEntry()
        {
            // Arrange
            const string userName = "test";
            ShimCoreFunctions.getDomain = () => string.Empty;
            var directoryShims = DirectoryShims.ShimDirectoryCalls();

            // Act
            CoreFunctions.getUserFromAD(userName);

            // Assert
            Assert.AreEqual(1, directoryShims.DirectorySearchersDisposed.Count);
            Assert.AreEqual(directoryShims.DirectoryEntriesDisposed[0], directoryShims.DirectorySearchersDisposed[0].SearchRoot);
            Assert.AreEqual($"(&(objectClass=user) (cn={userName}))", directoryShims.DirectorySearchersDisposed[0].Filter);
        }

        [TestMethod]
        public void Encrypt_ExeptionThrown_EmptyStringReturned()
        {
            // Arrange
            ShimRijndaelManaged.Constructor = instance => new InvalidOperationException("test");

            // Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Encrypt_Always_PasswordDeriveBytesManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.DeriveBytesCreated.Count);
            Assert.IsTrue(_cryptographyShims.DeriveBytesCreated.All(pred => pred is PasswordDeriveBytes));
            Assert.IsTrue(_cryptographyShims.CheckIfAllDeriveBytesDisposed());
        }

        [TestMethod]
        public void Encrypt_Always_RijndaelManagedManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.RijndaelManagedCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllRijindaelManagedDisposed());
        }

        [TestMethod]
        public void Encrypt_Always_CryptoStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsCreated.OfType<CryptoStream>().Any());
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<CryptoStream>().Any());
        }

        [TestMethod]
        public void Encrypt_Always_MemoryStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<MemoryStream>().Any());
        }

        [TestMethod]
        public void Encrypt_Always_EncryptorManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.EncryptorsCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllEncryptorsDisposed());
        }

        [TestMethod]
        public void Decrypt_ExeptionThrown_EmptyStringReturned()
        {
            // Arrange
            ShimRijndaelManaged.Constructor = instance => new InvalidOperationException("test");

            // Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Decrypt_Always_PasswordDeriveBytesManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.DeriveBytesCreated.Count);
            Assert.IsTrue(_cryptographyShims.DeriveBytesCreated.All(pred => pred is PasswordDeriveBytes));
            Assert.IsTrue(_cryptographyShims.CheckIfAllDeriveBytesDisposed());
        }

        [TestMethod]
        public void Decrypt_Always_RijndaelManagedManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.RijndaelManagedCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllRijindaelManagedDisposed());
        }

        [TestMethod]
        public void Decrypt_Always_CryptoStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsCreated.OfType<CryptoStream>().Any());
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<CryptoStream>().Any());
        }

        [TestMethod]
        public void Decrypt_Always_MemoryStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<MemoryStream>().Any());
        }

        [TestMethod]
        public void Decrypt_Always_EncryptorManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.DecryptorsCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllEncryptorsDisposed());
        }
    }
}
