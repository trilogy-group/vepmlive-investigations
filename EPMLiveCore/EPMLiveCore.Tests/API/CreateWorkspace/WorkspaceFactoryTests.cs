using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Fakes;
using System.Text;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Controls.Navigation.Providers.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Navigation.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.CreateWorkspace
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WorkspaceFactoryTests
    {
        private IDisposable _shimsObject;
        private DummyClass _testObj;
        private PrivateObject _privateObj;
        private ShimSPSite _site;
        private ShimSPWeb _web;
        private bool _solutionRemoved;
        private bool _listItemDeleted;
        private bool _webUpdated;
        private bool _dataDownloaded;
        private bool _fileAddedToFolder;
        private bool _featureAddedToSite;
        private bool _userSolutionAdded;
        private bool _fieldAdded;
        private bool _fieldUpdated;
        private bool _systemUpdated;
        private bool _createSiteFromItem;
        private bool _createSite;
        private bool _sendSignalToDB;
        private bool _messageQueued;
        private bool _eventDeleted;
        private bool _eventReceiverAdded;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string RelativeUrl = "/";
        private const string SolutionType = "Solution";
        private const string SolutionId = "bd82b3be-38df-495b-9210-2498920fad91";
        private const string WebId = "86dc7b45-4071-4470-a401-e2561122ffe2";
        private const string DefinitionId = "f78dc45f-b6bb-4d59-8f45-c73bbcd28a61";
        private const string WorkspaceUrl = "WorkspaceUrl";
        private const string LookupField = "LookupField";
        private const string LstSolutionsToBeRemoved = "_lstSolutionsToBeRemoved";
        private const string TestUrl = "/test/";
        private const string AttachedItemId = "AttachedItemId";
        private const string AttachedItemListGuid = "AttachedItemListGuid";
        private const string DoNotHavePermission = "You do not have have permission to create subsite on the parent web selected";
        private const string IsStandAlone = "IsStandAlone";
        private const string UniquePermission = "UniquePermission";
        private const string CreatorId = "CreatorId";
        private const string WebIdProperty = "WebId";
        private const string SiteTemplateMustBeActivated = "1:The site template requires that the Feature {e3f514f6-928e-4a0f-ba9c-eec88c996f72} be activated in the site collection.";
        private const string XmlResult = "_xmlResult";
        private const string WebInfoTag = "<WebInfo>";
        private const string CDataTag = "<ID><![CDATA[";
        private const string ServerRelativeUrlTag = "<ServerRelativeUrl>";
        private const string TrueString = "true";
        private const string FalseString = "false";
        private const string ParentItem = "ParentItem";
        private const string Resources = "Resources";
        private const string ResID = "ResID";
        private const string Site = "{Site}";

        private const string ClearCacheMethod = "ClearCache";

        [TestInitialize]
        public void TestInitialize()
        {
            _solutionRemoved = false;
            _listItemDeleted = false;
            _webUpdated = false;
            _dataDownloaded = false;
            _fileAddedToFolder = false;
            _userSolutionAdded = false;
            _featureAddedToSite = false;
            _fieldAdded = false;
            _fieldUpdated = false;
            _systemUpdated = false;
            _createSiteFromItem = false;
            _createSite = false;
            _sendSignalToDB = false;
            _messageQueued = false;
            _eventDeleted = false;
            _eventReceiverAdded = false;

            _shimsObject = ShimsContext.Create();

            SetupShims();

            _testObj = new DummyClass(string.Empty);
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            _site = new ShimSPSite
            {
                UrlGet = () => DummyUrl,
                MakeFullUrlString = url => $"{DummyUrl}{url}",
                RootWebGet = () => _web,
                GetCatalogSPListTemplateType = _ => new ShimSPList
                {
                    ItemsGet = () => new ShimSPListItemCollection()
                        .Bind(new SPListItem[]
                        {
                            new ShimSPListItem
                            {
                                FileGet = () => new ShimSPFile
                                {
                                    NameGet = () => DummyString
                                },
                                Delete = () => _listItemDeleted = true
                            }.Instance
                        }),
                    RootFolderGet = () => new ShimSPFolder
                    {
                        FilesGet = () => new ShimSPFileCollection
                        {
                            AddStringByteArray = (x, y) =>
                            {
                                _fileAddedToFolder = true;

                                return new ShimSPFile
                                {
                                    ItemGet = () => new ShimSPListItem
                                    {
                                        IDGet = () => DummyInt
                                    }
                                };
                            }
                        }
                    }
                },
                SolutionsGet = () => new ShimSPUserSolutionCollection
                {
                    RemoveSPUserSolution = _ => _solutionRemoved = true,
                    AddInt32 = _ =>
                    {
                        _userSolutionAdded = true;

                        return new ShimSPUserSolution
                        {
                            SolutionIdGet = () => Guid.Parse(SolutionId)
                        };
                    }
                }
                .Bind(new SPUserSolution[]
                {
                    new ShimSPUserSolution
                    {
                        NameGet = () => DummyString
                    }.Instance
                }),
                OpenWebString = _ => _web,
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = _ => null,
                    AddGuidBooleanSPFeatureDefinitionScope = (_, __, ___) =>
                    {
                        _featureAddedToSite = true;
                        return null;
                    }
                }
            };

            var count = 0;

            _web = new ShimSPWeb
            {
                IDGet = () => Guid.Parse(WebId),
                SiteGet = () => _site,
                Update = () => _webUpdated = true,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = _ => new ShimSPList
                    {
                        IDGet = () => Guid.NewGuid(),
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            AddStringSPFieldTypeBoolean = (x, y, z) =>
                            {
                                _fieldAdded = true;
                                return DummyString;
                            },
                            GetFieldByInternalNameString = name =>
                            {
                                if (name == WorkspaceUrl && count == 0)
                                {
                                    count++;
                                    return null;
                                }
                                else if (name == LookupField)
                                {
                                    return new ShimSPFieldLookup();
                                }

                                return new ShimSPFieldUrl();
                            }
                        },
                        GetItemByIdInt32 = x => new ShimSPListItem
                        {
                            ItemGetGuid = y => new object(),
                            SystemUpdate = () => _systemUpdated = true
                        }
                    }
                }
            };

            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection
            {
                GetByIDInt32 = __ => new ShimSPUser
                {
                    LoginNameGet = () => DummyString
                }
            };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPField.AllInstances.Update = _ => _fieldUpdated = true;

            ShimSPFieldUrlValue.Constructor = _ => { };

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimXMLDataManager.ConstructorString = (_, __) => { };

            ShimWebClient.Constructor = _ => { };
            ShimWebClient.AllInstances.DownloadDataString = (_, __) =>
            {
                _dataDownloaded = true;
                return new byte[] { };
            };

            ShimNetworkCredential.ConstructorStringStringString = (_, _1, _2, _3) => { };
        }

        [TestMethod]
        public void RemoveSolutionFromGallery_OnValidCall_ConfirmResult()
        {
            // Arrange
            var lstSolutionsToBeRemoved = (List<string>)_privateObj.GetFieldOrProperty(LstSolutionsToBeRemoved);
            lstSolutionsToBeRemoved.Add(DummyString);

            // Act
            _testObj.RemoveSolutionFromGallery(_site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _solutionRemoved.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeTrue());
        }

        [TestMethod]
        public void UserCanCreateSubSite_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = _testObj.UserCanCreateSubSite(_site, TestUrl);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void InstallOnlineSolutionByFeatureXml_OnValidCall_ConfirmResult()
        {
            // Arrange
            var xmlString = $@"
                <Root>
                    <File Name='{DummyString}' Type='{SolutionType}' />
                </Root>";
            string tempName;

            ShimWorkspaceFactory.AllInstances.GetFeatureDefinitionsInSolutionSPUserSolutionSPSite = (_, __, ___) => 
            new List<SPFeatureDefinition>
            {
                new ShimSPFeatureDefinition
                {
                    IdGet = () => Guid.NewGuid(),
                    ScopeGet = () => SPFeatureScope.Site,
                    ActivateOnDefaultGet = () => true
                }
            };

            // Act
            _testObj.InstallOnlineSolutionByFeatureXml(xmlString, DummyString, out tempName, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _dataDownloaded.ShouldBeTrue(),
                () => _fileAddedToFolder.ShouldBeTrue(),
                () => _featureAddedToSite.ShouldBeTrue(),
                () => _userSolutionAdded.ShouldBeTrue());
        }

        [TestMethod]
        public void EnsureWebInitFeature_WhenNoFeature_ConfirmResult()
        {
            // Arrange
            var featureRemoved = false;
            var featureAdded = false;
            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection
            {
                RemoveGuid = __ => featureRemoved = true,
                AddGuid = __ =>
                {
                    featureAdded = true;
                    return null;
                }
            }.Bind(new List<SPFeature>() as IEnumerable<SPFeature>);
            
            // Act
            var result = _testObj.EnsureWebInitFeature(WebId, _site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue(),
                () => featureRemoved.ShouldBeFalse(),
                () => featureAdded.ShouldBeTrue());
        }

        [TestMethod]
        public void EnsureWebInitFeature_WhenFeatureExists_ConfirmResult()
        {
            // Arrange
            var featureRemoved = false;
            var featureAdded = false;
            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection
            {
                RemoveGuid = __ => featureRemoved = true,
                AddGuid = __ =>
                {
                    featureAdded = true;
                    return null;
                }
            }.Bind(new List<SPFeature>
            {
                new ShimSPFeature
                {
                    DefinitionIdGet = () => new Guid(DefinitionId)
                }
            } as IEnumerable<SPFeature>);

            // Act
            var result = _testObj.EnsureWebInitFeature(WebId, _site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue(),
                () => featureRemoved.ShouldBeTrue(),
                () => featureAdded.ShouldBeTrue());
        }

        [TestMethod]
        public void EnsureFieldsInRequestItem_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                switch (prop)
                {
                    case AttachedItemId:
                        return DummyInt.ToString();
                    case AttachedItemListGuid:
                        return Guid.NewGuid().ToString();
                    default:
                        return null;
                }
            };

            // Act
            var result = _testObj.EnsureFieldsInRequestItem();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _fieldAdded.ShouldBeTrue(),
                () => _fieldUpdated.ShouldBeTrue(),
                () => _systemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void BaseProvision_NotFirstTimeErrorUniquePermissionStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = true;
            var uniquePermission = true;
            var userHavePermission = true;
            var firstTimeError = false;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission, firstTimeError);

            // Act
            _testObj.BaseProvision(_site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeFalse(),
                () => _createSite.ShouldBeTrue(),
                () => _sendSignalToDB.ShouldBeTrue());
        }

        [TestMethod]
        public void BaseProvision_UniquePermissionStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = true;
            var uniquePermission = true;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            // Act
            _testObj.BaseProvision(_site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeTrue(),
                () => _createSite.ShouldBeTrue(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_UniquePermissionNotStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = false;
            var uniquePermission = true;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            // Act
            _testObj.BaseProvision(_site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeTrue(),
                () => _createSite.ShouldBeFalse(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_NotUniquePermissionStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = true;
            var uniquePermission = false;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            // Act
            _testObj.BaseProvision(_site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeFalse(),
                () => _createSite.ShouldBeTrue(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_NotUniquePermissionNotStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = false;
            var uniquePermission = false;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            // Act
            _testObj.BaseProvision(_site, _web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeTrue(),
                () => _createSite.ShouldBeFalse(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_ParentWebNotEqualWeb_ConfirmResult()
        {
            // Arrange
            var standAlone = true;
            var uniquePermission = true;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            var web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site
            };

            // Act
            _testObj.BaseProvision(_site, web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeFalse(),
                () => _createSite.ShouldBeTrue(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_ParentWebNotEqualWebNotStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = false;
            var uniquePermission = true;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            var web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site
            };

            // Act
            _testObj.BaseProvision(_site, web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeTrue(),
                () => _createSite.ShouldBeFalse(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_ParentWebNotEqualWebNotUniquePermissionStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = true;
            var uniquePermission = false;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            var web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site
            };

            // Act
            _testObj.BaseProvision(_site, web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeFalse(),
                () => _createSite.ShouldBeTrue(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_ParentWebNotEqualWebNotUniquePermissionNotStandAlone_ConfirmResult()
        {
            // Arrange
            var standAlone = false;
            var uniquePermission = false;
            var userHavePermission = true;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            var web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site
            };

            // Act
            _testObj.BaseProvision(_site, web, _site, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _webUpdated.ShouldBeTrue(),
                () => _createSiteFromItem.ShouldBeTrue(),
                () => _createSite.ShouldBeFalse(),
                () => _sendSignalToDB.ShouldBeFalse());
        }

        [TestMethod]
        public void BaseProvision_UserDoesNotHavePermission_ThrowException()
        {
            // Arrange
            var standAlone = false;
            var uniquePermission = false;
            var userHavePermission = false;

            SetupForBaseProvision(standAlone, uniquePermission, userHavePermission);

            // Act
            Action action = () => _testObj.BaseProvision(_site, _web, _site, _web);

            // Assert
            var exception = Should.Throw<Exception>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain(DoNotHavePermission));
        }
        
        private void SetupForBaseProvision(bool standAlone, bool uniquePermission, bool userHavePermission, bool firstTimeError = true)
        {
            var count = firstTimeError ? 0 : 1;
            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                switch (prop)
                {
                    case IsStandAlone:
                        return standAlone.ToString();
                    case UniquePermission:
                        return uniquePermission.ToString();
                    case CreatorId:
                        return DummyInt.ToString();
                    case WebIdProperty:
                    case AttachedItemListGuid:
                        return Guid.NewGuid().ToString();
                    default: return DummyString;
                }
            };

            ShimSPWeb.AllInstances.DoesUserHavePermissionsStringSPBasePermissions = (_, __, ___) => userHavePermission;

            ShimCoreFunctions.CreateSiteFromItemStringStringStringStringStringBooleanBooleanSPWebSPWebGuidInt32GuidOutStringOutStringOutStringOut =
                (string _1, string _2, string _3, string _4, string _5, bool _6, bool _7, SPWeb _8, SPWeb _9, Guid _10, int _11,
                out Guid createdSiteId, out string createdWebUrl, out string createdWebRelativeUrl, out string createdWebTitle) =>
                {
                    createdSiteId = Guid.Empty;
                    createdWebUrl = string.Empty;
                    createdWebRelativeUrl = string.Empty;
                    createdWebTitle = string.Empty;
                    _createSiteFromItem = true;

                    var result = count > 0 ? DummyString : SiteTemplateMustBeActivated;
                    count++;

                    return result;
                };
            ShimCoreFunctions.createSiteStringStringStringStringStringBooleanBooleanSPWebGuidOutStringOutStringOutStringOut =
                (string _1, string _2, string _3, string _4, string _5, bool _6, bool _7, SPWeb _8,
                out Guid createdWebId, out string createdWebUrl, out string createdWebServerRelativeUrl, out string createdWebTitle) =>
                {
                    createdWebId = Guid.Empty;
                    createdWebUrl = string.Empty;
                    createdWebServerRelativeUrl = string.Empty;
                    createdWebTitle = string.Empty;
                    _createSite = true;

                    var result = count > 0 ? DummyString : SiteTemplateMustBeActivated;
                    count++;

                    return result;
                };
            ShimCoreFunctions.getListSettingStringSPList = (_, __) =>
                $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{LookupField}";

            ShimWorkspaceData.SendCompletedSignalsToDBGuidSPWebGuidStringStringStringString = (_1, _2, _3, _4, _5, _6, _7) =>
            {
                _sendSignalToDB = true;
            };
            ShimWorkspaceData.SendCompletedSignalsToDBGuidSPWebSPWebGuidInt32GuidStringStringStringString = 
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10) =>
                {
                    _sendSignalToDB = true;
                };
            ShimWorkspaceData.GetParentWebIdGuidGuidGuidInt32 = (_1, _2, _3, _4) => Guid.NewGuid();

            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => { };

            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
        }

        [TestMethod]
        public void BuildWebInfoXml_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            _testObj.BuildWebInfoXml();

            // Assert
            var xmlResult = (StringBuilder)_privateObj.GetFieldOrProperty(XmlResult);
            this.ShouldSatisfyAllConditions(
                () => xmlResult.ShouldNotBeNull(),
                () => xmlResult.ToString().ShouldContain(WebInfoTag),
                () => xmlResult.ToString().ShouldContain(CDataTag),
                () => xmlResult.ToString().ShouldContain(ServerRelativeUrlTag));
        }

        [TestMethod]
        public void Notify_WhenAttachedItemIdIsGiven_ConfirmResult()
        {
            // Arrange
            SetupForNotify(DummyInt);

            // Act
            _testObj.Notify(_web);

            // Assert
            _messageQueued.ShouldBeTrue();
        }

        [TestMethod]
        public void Notify_WhenAttachedItemIdIsNotGiven_ConfirmResult()
        {
            // Arrange
            var value = -1;
            SetupForNotify(value);

            // Act
            _testObj.Notify(_web);

            // Assert
            _messageQueued.ShouldBeTrue();
        }

        private void SetupForNotify(int value)
        {
            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                switch (prop)
                {
                    case CreatorId:
                        return DummyInt.ToString();
                    case AttachedItemId:
                        return value.ToString();
                    default: return DummyString;
                }
            };

            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPListItemSPUserBoolean =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10) => _messageQueued = true;
            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPWebSPUserBoolean =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10) => _messageQueued = true;
        }

        [TestMethod]
        public void NotifyWsGeneralError_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimXMLDataManager.AllInstances.GetPropValString = (_, __) => DummyInt.ToString();

            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPWebSPUserBoolean =
                (_1, _2, _3, _4, _5, _6, _7, _8, _9, _10) => _messageQueued = true;

            // Act
            _testObj.NotifyWsGeneralError(_web, DummyString);

            // Assert
            _messageQueued.ShouldBeTrue();
        }

        [TestMethod]
        public void AddToFavorites_WhenIsStandAlone_ConfirmResult()
        {
            // Arrange
            var addedToFRF = false;
            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                if (prop == CreatorId)
                    return DummyInt.ToString();

                return TrueString;
            };

            ShimWorkspaceData.AddToFRFGuidGuidStringStringInt32Int32 = (_1, _2, _3, _4, _5, _6) => addedToFRF = true;

            // Act
            _testObj.AddToFavorites();

            // Assert
            addedToFRF.ShouldBeTrue();
        }

        [TestMethod]
        public void AddToFavorites_WhenIsNotStandAlone_ConfirmResult()
        {
            // Arrange
            var addedToFRF = false;
            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                if (prop == CreatorId)
                    return DummyInt.ToString();

                return FalseString;
            };

            ShimWorkspaceData.AddToFRFGuidGuidStringStringInt32Int32GuidInt32 = (_1, _2, _3, _4, _5, _6, _7, _8) => 
                addedToFRF = true;

            // Act
            _testObj.AddToFavorites();

            // Assert
            addedToFRF.ShouldBeTrue();
        }

        [TestMethod]
        public void AddPermission_OnValidCall_CofirmResult()
        {
            // Arrange
            var permissionAdded = false;
            ShimWorkspaceData.AddWsPermissionGuidGuid = (_, __) => permissionAdded = true;

            // Act
            _testObj.AddPermission();

            // Assert
            permissionAdded.ShouldBeTrue();
        }

        [TestMethod]
        public void ModifyNewWSProperty_WhenAttachedItemIdIsGiven_ConfirmResult()
        {
            // Arrange
            SetupForModifyNewWSProperty(DummyInt);

            // Act
            _testObj.ModifyNewWSProperty();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eventDeleted.ShouldBeTrue(),
                () => _eventReceiverAdded.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void ModifyNewWSProperty_WhenAttachedItemIdIsNotGiven_ConfirmResult()
        {
            // Arrange
            var value = -1;
            SetupForModifyNewWSProperty(value);

            // Act
            _testObj.ModifyNewWSProperty();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eventDeleted.ShouldBeTrue(),
                () => _eventReceiverAdded.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue());
        }

        private void SetupForModifyNewWSProperty(int value)
        {
            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                switch (prop)
                {
                    case AttachedItemId:
                    case AttachedItemListGuid:
                        return value.ToString();
                    default:
                        return DummyString;
                }
            };

            ShimCoreFunctions.GetWebEventsSPWebStringStringListOfSPEventReceiverType = (_1, _2, _3, _4) =>
                new List<SPEventReceiverDefinition>
                {
                    new ShimSPEventReceiverDefinition
                    {
                        Delete = () => _eventDeleted = true
                    }
                };

            ShimSPWeb.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection
            {
                AddSPEventReceiverTypeStringString = (_1, _2, _3) => _eventReceiverAdded = true
            };
            ShimSPWeb.AllInstances.AllPropertiesGet = _ => new Hashtable
            {
                [ParentItem] = string.Empty
            };
        }

        [TestMethod]
        public void ActivateFeature_OnValidCall_ConfirmResult()
        {
            // Arrange
            var featureAdded = false;
            var listUpdated = false;
            var listItemAdded = false;
            var count = 0;

            ShimXMLDataManager.AllInstances.GetPropValString = (instance, prop) =>
            {
                switch (prop)
                {
                    case IsStandAlone:
                        return TrueString;
                    default:
                        return DummyInt.ToString();
                }
            };

            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection
            {
                AddGuid = __ =>
                {
                    featureAdded = true;
                    return null;
                }
            };

            ShimSPSite.AllInstances.RootWebGet = _ => _web;

            ShimSPListCollection.AllInstances.TryGetListString = (instance, list) =>
            {
                if (list == Resources || count > 0)
                {
                    return new ShimSPList
                    {
                        ItemsGet = () => new ShimSPListItemCollection().Bind(new SPListItem[]
                        {
                            new ShimSPListItem()
                        }),
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            AddStringSPFieldTypeBoolean = (_1, _2, _3) =>
                            {
                                _fieldAdded = true;
                                return string.Empty;
                            },
                            GetFieldByInternalNameString = _1 => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid()
                            }
                        },
                        Update = () => listUpdated = true
                    };
                }

                count++;

                return null;
            };

            ShimSPList.AllInstances.GetItemsSPQuery = (instance, query) =>
            {
                if (query.Query.Contains(ResID))
                {
                    return new ShimSPListItemCollection().Bind(new SPListItem[] { });
                }
                else
                {
                    return new ShimSPListItemCollection
                    {
                        ItemGetInt32 = _ => new ShimSPListItem
                        {
                            IDGet = () => DummyInt,
                            ItemGetString = item => DummyString
                        }
                    }.Bind(new SPListItem[]
                    {
                        new ShimSPListItem()
                    });
                }
            };

            ShimSPListItemCollection.AllInstances.Add = _ =>
            {
                listItemAdded = true;
                return new ShimSPListItem
                {
                    ItemGetGuid = __ => DummyString
                };
            };

            ShimSPQuery.Constructor = _ => { };
            
            // Act
            _testObj.ActivateFeature();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => featureAdded.ShouldBeTrue(),
                () => _fieldAdded.ShouldBeTrue(),
                () => listUpdated.ShouldBeTrue(),
                () => listItemAdded.ShouldBeTrue());
        }

        [TestMethod]
        public void ClearCache_OnValidCall_ConfirmResult()
        {
            // Arrange
            var cacheCleared = false;
            ShimWorkspaceLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimFavoritesLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimNavLinkProvider.AllInstances.ClearCacheBoolean = (_, __) => cacheCleared = true;

            // Act
            _privateObj.Invoke(ClearCacheMethod);

            // Assert
            cacheCleared.ShouldBeTrue();
        }

        [TestMethod]
        public void TempGalWebIdProperty_OnValidCall_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid();
            ShimXMLDataManager.AllInstances.GetPropValString = (_, __) => guid.ToString();
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => Site;

            ShimSPWeb.AllInstances.ExistsGet = _ => true;

            // Act
            var result = _testObj.GetTempGalWebId();

            // Assert
            result.ShouldBe(guid);
        }
    }

    internal class DummyClass : WorkspaceFactory
    {
        public DummyClass(string data) : base(data)
        {
        }

        public override ICreatedWorkspaceInfo CreateWorkspace()
        {
            throw new NotImplementedException();
        }

        public Guid GetTempGalWebId()
        {
            return TempGalWebId;
        }
    }
}
