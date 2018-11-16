using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Reflection;
using System.Web.Fakes;
using System.Xml;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner.Tests.Jobs
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PublishJobTests
    {
        private PublishJob testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPListCollection spListCollection;
        private ShimSPList spList;
        private ShimSPListItemCollection spListItemCollection;
        private ShimSPListItem spListItem;
        private ShimSPFieldCollection spFieldCollection;
        private ShimSPField spField;
        private ShimSPUser spUser;
        private ShimSPFolderCollection spFolderCollection;
        private ShimSPFolder spFolder;
        private ShimSPFileCollection spFileCollection;
        private ShimSPFile spFile;
        private ShimSPViewCollection spViewCollection;
        private ShimSPView spView;
        private ShimSPViewFieldCollection spViewFieldCollection;
        private ShimSPFieldLinkCollection spFieldLinkCollection;
        private ShimSPContentTypeCollection spContentTypeCollection;
        private ShimSPContentType spContentType;
        private ShimSqlTransaction transaction;
        private Guid guid;
        private int validations;
        private const int DummyInt = 1;
        private const int One = 1;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string MoveListItemToFolderMethodName = "MoveListItemToFolder";
        private const string SetupTaskCenterMethodName = "setupTaskCenter";
        private const string EnsureFolderMethodName = "ensureFolder";
        private const string StartPublishMethodName = "StartPublish";
        private const string ExecuteMethodName = "execute";
        private const string UserIdFieldName = "userid";
        private const string KeyFieldName = "key";
        private const string ErrorBooleanFieldName = "bErrors";
        private const string ErrorStringFieldName = "sErrors";
        private const string TotalCountFieldName = "totalCount";

        [TestInitialize]
        public void Setup()
        {
            testObject = new PublishJob();
            privateObject = new PrivateObject(testObject);

            SetupShims();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => transaction;
            ShimDbTransaction.AllInstances.Dispose = _ => { };
            ShimSqlConnection.AllInstances.CreateCommand = _ => new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuidSPUserToken = (_, _1, _2) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => spListItemCollection;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => spSite;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => spWeb;
            ShimAct.ConstructorSPWeb = (_, __) => new ShimAct();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.SiteGet = _ => spSite;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimDisabledItemEventScope.Constructor = _ => new ShimDisabledItemEventScope();
            ShimDisabledItemEventScope.AllInstances.Dispose = _ => { };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => spSite,
                ListsGet = () => spListCollection,
                GetFolderString = _ => spFolder,
                GetFileString = _ => spFile,
                FoldersGet = () => spFolderCollection,
                CurrentUserGet = () => spUser,
                ServerRelativeUrlGet = () => SampleUrl,
                AllUsersGet = () => new ShimSPUserCollection(),
                SiteUsersGet = () => new ShimSPUserCollection(),
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => spWeb,
                FeaturesGet = () => new ShimSPFeatureCollection()
                {
                    ItemGetGuid = _ => new ShimSPFeature()
                },
                ContentDatabaseGet = () => new ShimSPContentDatabase()
            };
            spListCollection = new ShimSPListCollection()
            {
                TryGetListString = _ => spList,
                ItemGetString = _ => spList,
                ItemGetGuid = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                GetItemByIdInt32 = _ => spListItem,
                ItemsGet = () => spListItemCollection,
                GetItemsSPQuery = _ => spListItemCollection,
                RootFolderGet = () => spFolder,
                ParentWebGet = () => spWeb,
                DefaultViewGet = () => spView,
                ViewsGet = () => spViewCollection,
                ContentTypesGet = () => spContentTypeCollection,
                TitleGet = () => DummyString,
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection(),
                DefaultViewUrlGet = () => SampleUrl
            };
            spListItemCollection = new ShimSPListItemCollection()
            {
                CountGet = () => DummyInt,
                ItemGetInt32 = _ => spListItem
            };
            spListItem = new ShimSPListItem()
            {
                IDGet = () => DummyInt,
                TitleGet = () => DummyString,
                ItemGetString = _ => DummyString,
                ItemGetGuid = _ => DummyString,
                ItemSetGuidObject = (_, __) => { },
                Update = () => { },
                FileGet = () => spFile,
                ParentListGet = () => spList,
                NameGet = () => DummyString
            };
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => spField,
                ContainsFieldString = _ => false,
                GetFieldString = _ => spField,
                ItemGetString = _ => spField
            };
            spField = new ShimSPField()
            {
                IdGet = () => guid,
                TitleGet = () => DummyString,
                InternalNameGet = () => DummyString,
                ReadOnlyFieldGet = () => false,
                HiddenGet = () => false,
                ReorderableGet = () => true,
                TypeAsStringGet = () => DummyString
            };
            spUser = new ShimSPUser()
            {
                IDGet = () => DummyInt,
                IsSiteAdminGet = () => true,
                UserTokenGet = () => new ShimSPUserToken()
            };
            spFolderCollection = new ShimSPFolderCollection()
            {
                ItemGetString = _ => spFolder,
                AddString = _ => spFolder
            };
            spFolder = new ShimSPFolder()
            {
                ExistsGet = () => false,
                SubFoldersGet = () => spFolderCollection,
                FilesGet = () => spFileCollection,
                UrlGet = () => SampleUrl,
                UniqueIdGet = () => guid,
                ParentWebGet = () => spWeb
            };
            spFileCollection = new ShimSPFileCollection()
            {
                CountGet = () => DummyInt,
                AddStringByteArrayBoolean = (_1, _2, _3) => spFile,
                AddStringStream = (_1, _2) => spFile,
                ItemGetString = _ => spFile
            };
            spFile = new ShimSPFile()
            {
                Delete = () => { },
                OpenBinaryStream = () => null,
                NameGet = () => DummyString,
                GetListItemStringArray = _ => spListItem
            };
            spViewCollection = new ShimSPViewCollection()
            {
                ItemGetString = _ => spView
            };
            spView = new ShimSPView()
            {
                ViewFieldsGet = () => spViewFieldCollection,
                ServerRelativeUrlGet = () => SampleUrl
            };
            spViewFieldCollection = new ShimSPViewFieldCollection();
            spContentTypeCollection = new ShimSPContentTypeCollection()
            {
                ItemGetString = _ => spContentType
            };
            spContentType = new ShimSPContentType()
            {
                IdGet = () => default(SPContentTypeId),
                FieldLinksGet = () => spFieldLinkCollection
            };
            spFieldLinkCollection = new ShimSPFieldLinkCollection()
            {
                ItemGetGuid = _ => new ShimSPFieldLink()
            };
            transaction = new ShimSqlTransaction()
            {
                Commit = () => { },
                Rollback = () => { }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void MoveListItemToFolder_WhenCalled_UpdatesDatabase()
        {
            // Arrange
            var expectedCommands = new List<string>()
            {
                $"update AllUserData set tp_ParentId = @tp_ParentId where tp_ListId = @ListId and tp_ID = @ItemId;",
                $"update AllDocs set DirName = @NewDir, ParentId = @ParentId where ListId = @ListId and doclibrowid = @ItemId"
            };

            ShimSPUrlUtility.CombineUrlStringString = (_, __) =>
            {
                validations += 1;
                return SampleUrl;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                if (expectedCommands.Contains(command.CommandText))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            var actual = privateObject.Invoke(
                MoveListItemToFolderMethodName,
                publicStatic,
                new object[]
                {
                    spListItem.Instance,
                    spFolder.Instance
                });

            // Assert
            validations.ShouldBe(3);
        }

        [TestMethod]
        public void SetupTaskCenter_WhenCalled_AddsEventReceiver()
        {
            // Arrange
            var textField = new ShimSPFieldText();

            spFieldCollection.ContainsFieldString = _ =>
            {
                validations += 1;
                return false;
            };
            spFieldCollection.AddStringSPFieldTypeBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };
            spFieldCollection.AddSPField = _ =>
            {
                validations += 1;
                return DummyString;
            };
            spFieldCollection.CreateNewFieldStringString = (_, __) =>
            {
                validations += 1;
                return textField;
            };
            spField.RequiredSetBoolean = input =>
            {
                if (!input)
                {
                    validations += 1;
                }
            };
            spField.HiddenSetBoolean = input =>
            {
                if (input)
                {
                    validations += 1;
                }
            };
            spField.TitleSetString = input =>
            {
                validations += 1;
            };
            spField.Update = () =>
            {
                validations += 1;
            };
            spList.Update = () =>
            {
                validations += 1;
            };

            ShimSPField.AllInstances.HiddenSetBoolean = (_, input) =>
            {
                if (input)
                {
                    validations += 1;
                }
            };
            ShimSPField.AllInstances.RequiredSetBoolean = (_, input) =>
            {
                if (!input)
                {
                    validations += 1;
                }
            };
            ShimSPField.AllInstances.Update = _ =>
            {
                validations += 1;
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPEventReceiverDefinition>()
            {
                new ShimSPEventReceiverDefinition()
                {
                    TypeGet = () => SPEventReceiverType.ItemAdding,
                    ClassGet = () => DummyString
                }
            }.GetEnumerator();
            ShimSPEventReceiverDefinitionCollection.AllInstances.AddSPEventReceiverTypeStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetupTaskCenterMethodName, nonPublicInstance, new object[] { spList.Instance });

            // Assert
            validations.ShouldBe(19);
        }

        [TestMethod]
        public void EnsureFolder_WhenCalled_UpdatesListItem()
        {
            // Arrange
            spList.AddItemStringSPFileSystemObjectTypeString = (fullFolder, objectType, folder) =>
            {
                if (fullFolder.Equals(SampleUrl) && folder.Equals(DummyString))
                {
                    validations += 1;
                }
                return spListItem;
            };
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validations += 1;
            };
            spListItem.Update = () =>
            {
                validations += 1;
            };

            ShimPath.GetDirectoryNameString = input => input;

            // Act
            var actual = privateObject.Invoke(EnsureFolderMethodName, nonPublicInstance, new object[] { spList.Instance, DummyString });

            // Assert
            validations.ShouldBe(4);
        }

        [TestMethod]
        public void StartPublish_WhenCalled_PublishesTasks()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Task/>
                    <Task/>
                    <Task/>
                    <Task/>
                    <Task/>
                </xmlcfg>";
            var document = new XmlDocument();
            var plannerProps = new PlannerProps();
            var methodHit = 0;

            document.LoadXml(xmlString);

            spListItem.Update = () =>
            {
                methodHit += 1;
                validations += 1;
                if (methodHit.Equals(1))
                {
                    throw new Exception();
                }
            };

            ShimPublishJob.AllInstances.getPrefixSPSite = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimPublishJob.AllInstances.publishTasksXmlDocumentSPListStringHashtableStringStringWorkPlannerAPIPlannerPropsString =
                (_, _1, _2, _3, _4, _5, _6, _7, _8) =>
                {
                    validations += 1;
                };

            // Act
            var actual = privateObject.Invoke(
                StartPublishMethodName,
                nonPublicInstance,
                new object[]
                {
                    document,
                    spSite.Instance,
                    spWeb.Instance,
                    spList.Instance,
                    spList.Instance,
                    DummyInt.ToString(),
                    plannerProps,
                    DummyString
                });
            var totalCount = (float)privateObject.GetFieldOrProperty(TotalCountFieldName, nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => totalCount.ShouldBe(5),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void Execute_UserIdzero_Enqueues()
        {
            // Arrange
            const string key = "msproject";
            var id = $"1.{guid}.{DummyInt}";
            var data = $@"<xmlcfg Key=""{key}"" ID=""{id}""/>";
            var fieldMappings = $"{DummyString},{DummyString}";
            var expectedErrorMessage = $"Error Publishing: {DummyString}";
            var plannerProps = new PlannerProps()
            {
                sListTaskCenter = string.Empty,
                sProjectField = string.Empty,
                sFieldMappings = fieldMappings
            };

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimPublishJob.AllInstances.setupProjectCenterSPList = (_, __) =>
            {
                validations += 1;
            };
            ShimPublishJob.AllInstances.setupTaskCenterSPList = (_, __) =>
            {
                validations += 1;
            };
            ShimPublishJob.AllInstances.StartPublishXmlDocumentSPSiteSPWebSPListSPListStringWorkPlannerAPIPlannerPropsString =
                (_, _1, _2, _3, _4, _5, _6, _7, _8) =>
                {
                    validations += 1;
                };
            ShimTimer.AddTimerJobGuidGuidGuidInt32StringInt32StringStringInt32Int32String =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11) =>
                {
                    validations += 1;
                    return guid;
                };
            ShimTimer.EnqueueGuidInt32SPSite =
                (_1, _2, _3) =>
                {
                    validations += 1;
                    throw new Exception(DummyString);
                };
            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPWebSPUserBoolean =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10) =>
                {
                    validations += 1;
                };
            ShimPublishJob.AllInstances.FormatPFEWorkJobXmlXmlDocument = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty(UserIdFieldName, publicInstance, 0);
            privateObject.SetFieldOrProperty(KeyFieldName, publicInstance, key);

            // Act
            privateObject.Invoke(
                ExecuteMethodName,
                publicInstance,
                new object[]
                {
                    spSite.Instance,
                    spWeb.Instance,
                    data
                });
            var isError = (bool)privateObject.GetFieldOrProperty(ErrorBooleanFieldName, publicInstance);
            var errorMessage = (string)privateObject.GetFieldOrProperty(ErrorStringFieldName, publicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => isError.ShouldBeTrue(),
                () => errorMessage.ShouldBe(expectedErrorMessage),
                () => validations.ShouldBe(8));
        }

        [TestMethod]
        public void Execute_UserIdNotzero_Enqueues()
        {
            // Arrange
            const string key = "msproject";
            var id = $"1.{guid}.{DummyInt}";
            var data = $@"<xmlcfg Key=""{key}"" ID=""{id}""/>";
            var fieldMappings = $"{DummyString},{DummyString}";
            var expectedErrorMessage = $"Error Publishing: {DummyString}";
            var plannerProps = new PlannerProps()
            {
                sListTaskCenter = string.Empty,
                sProjectField = string.Empty,
                sFieldMappings = fieldMappings
            };

            ShimWorkPlannerAPI.getSettingsSPWebString = (_, __) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimPublishJob.AllInstances.setupProjectCenterSPList = (_, __) =>
            {
                validations += 1;
            };
            ShimPublishJob.AllInstances.setupTaskCenterSPList = (_, __) =>
            {
                validations += 1;
            };
            ShimPublishJob.AllInstances.StartPublishXmlDocumentSPSiteSPWebSPListSPListStringWorkPlannerAPIPlannerPropsString =
                (_, _1, _2, _3, _4, _5, _6, _7, _8) =>
                {
                    validations += 1;
                };
            ShimTimer.AddTimerJobGuidGuidGuidInt32StringInt32StringStringInt32Int32String =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11) =>
                {
                    validations += 1;
                    return guid;
                };
            ShimTimer.EnqueueGuidInt32SPSite =
                (_1, _2, _3) =>
                {
                    validations += 1;
                    throw new Exception(DummyString);
                };
            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPWebSPUserBoolean =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10) =>
                {
                    validations += 1;
                };
            ShimPublishJob.AllInstances.FormatPFEWorkJobXmlXmlDocument = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty(UserIdFieldName, publicInstance, One);
            privateObject.SetFieldOrProperty(KeyFieldName, publicInstance, key);

            // Act
            privateObject.Invoke(
                ExecuteMethodName,
                publicInstance,
                new object[]
                {
                    spSite.Instance,
                    spWeb.Instance,
                    data
                });
            var isError = (bool)privateObject.GetFieldOrProperty(ErrorBooleanFieldName, publicInstance);
            var errorMessage = (string)privateObject.GetFieldOrProperty(ErrorStringFieldName, publicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => isError.ShouldBeTrue(),
                () => errorMessage.ShouldBe(expectedErrorMessage),
                () => validations.ShouldBe(8));
        }
    }
}