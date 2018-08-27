using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.WorkspaceFactory" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkspaceFactoryTest : AbstractBaseSetupTypedTest<WorkspaceFactory>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceFactory) Initializer

        private const string Property_isStandAlone = "_isStandAlone";
        private const string PropertyUniquePermission = "UniquePermission";
        private const string PropertyParentWebId = "ParentWebId";
        private const string PropertyAttachedItemId = "AttachedItemId";
        private const string PropertyAttachedItemListId = "AttachedItemListId";
        private const string PropertyAttachedItemTitle = "AttachedItemTitle";
        private const string PropertyWebId = "WebId";
        private const string PropertyTempGalWebId = "TempGalWebId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyCreatorId = "CreatorId";
        private const string MethodCreateWorkspace = "CreateWorkspace";
        private const string MethodRemoveSolutionFromGallery = "RemoveSolutionFromGallery";
        private const string MethodUserCanCreateSubSite = "UserCanCreateSubSite";
        private const string MethodGetSiteRelativeWebUrl = "GetSiteRelativeWebUrl";
        private const string MethodInstallOnlineSolutionByFeatureXml = "InstallOnlineSolutionByFeatureXml";
        private const string MethodInstallFileByFileNode = "InstallFileByFileNode";
        private const string MethodEnsureSiteCollectionFeaturesActivated = "EnsureSiteCollectionFeaturesActivated";
        private const string MethodGetFeatureDefinitionsInSolution = "GetFeatureDefinitionsInSolution";
        private const string MethodEnsureWebInitFeature = "EnsureWebInitFeature";
        private const string MethodEnsureFieldsInRequestItem = "EnsureFieldsInRequestItem";
        private const string MethodRenameProjectFileByProjectItem = "RenameProjectFileByProjectItem";
        private const string MethodFieldExistsInList = "FieldExistsInList";
        private const string MethodGetSafeTitle = "GetSafeTitle";
        private const string MethodBaseProvision = "BaseProvision";
        private const string MethodBuildWebInfoXml = "BuildWebInfoXml";
        private const string MethodNotify = "Notify";
        private const string MethodNotifyWsGeneralError = "NotifyWsGeneralError";
        private const string MethodAddToFavorites = "AddToFavorites";
        private const string MethodAddPermission = "AddPermission";
        private const string MethodBuildEmailData = "BuildEmailData";
        private const string MethodBuildErrorEmailData = "BuildErrorEmailData";
        private const string MethodModifyNewWSProperty = "ModifyNewWSProperty";
        private const string MethodActivateFeature = "ActivateFeature";
        private const string MethodClearCache = "ClearCache";
        private const string Fieldtemp_gal_title = "temp_gal_title";
        private const string Field_createParams = "_createParams";
        private const string Field_createdWebId = "_createdWebId";
        private const string Field_createdWebTitle = "_createdWebTitle";
        private const string Field_createdWebUrl = "_createdWebUrl";
        private const string Field_createdWebServerRelativeUrl = "_createdWebServerRelativeUrl";
        private const string Field_lstSolutionsToBeRemoved = "_lstSolutionsToBeRemoved";
        private const string Field_xmlDataMgr = "_xmlDataMgr";
        private const string Field_xmlResult = "_xmlResult";
        private Type _workspaceFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkspaceFactory _workspaceFactoryInstance;
        private WorkspaceFactory _workspaceFactoryInstanceFixture;
        private Type[] _abstractClassInstanciatedTypesList;

        #region General Initializer : Class (WorkspaceFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceFactoryInstanceType = typeof(WorkspaceFactory);
            _abstractClassInstanciatedTypesList = new Type[] { typeof(DownloadedTempWorkspaceFactory) };
            _workspaceFactoryInstanceFixture = Create(true);
            _workspaceFactoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceFactory)

        #region General Initializer : Class (WorkspaceFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateWorkspace, 0)]
        [TestCase(MethodRemoveSolutionFromGallery, 0)]
        [TestCase(MethodUserCanCreateSubSite, 0)]
        [TestCase(MethodGetSiteRelativeWebUrl, 0)]
        [TestCase(MethodInstallOnlineSolutionByFeatureXml, 0)]
        [TestCase(MethodInstallFileByFileNode, 0)]
        [TestCase(MethodEnsureSiteCollectionFeaturesActivated, 0)]
        [TestCase(MethodGetFeatureDefinitionsInSolution, 0)]
        [TestCase(MethodEnsureWebInitFeature, 0)]
        [TestCase(MethodEnsureFieldsInRequestItem, 0)]
        [TestCase(MethodRenameProjectFileByProjectItem, 0)]
        [TestCase(MethodFieldExistsInList, 0)]
        [TestCase(MethodGetSafeTitle, 0)]
        [TestCase(MethodBaseProvision, 0)]
        [TestCase(MethodBuildWebInfoXml, 0)]
        [TestCase(MethodNotify, 0)]
        [TestCase(MethodNotifyWsGeneralError, 0)]
        [TestCase(MethodAddToFavorites, 0)]
        [TestCase(MethodAddPermission, 0)]
        [TestCase(MethodBuildEmailData, 0)]
        [TestCase(MethodBuildErrorEmailData, 0)]
        [TestCase(MethodModifyNewWSProperty, 0)]
        [TestCase(MethodActivateFeature, 0)]
        [TestCase(MethodClearCache, 0)]
        public void AUT_WorkspaceFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workspaceFactoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkspaceFactory) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceFactory" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Property_isStandAlone)]
        [TestCase(PropertyUniquePermission)]
        [TestCase(PropertyParentWebId)]
        [TestCase(PropertyAttachedItemId)]
        [TestCase(PropertyAttachedItemListId)]
        [TestCase(PropertyAttachedItemTitle)]
        [TestCase(PropertyWebId)]
        [TestCase(PropertyTempGalWebId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyCreatorId)]
        public void AUT_WorkspaceFactory_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workspaceFactoryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkspaceFactory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldtemp_gal_title)]
        public void AUT_WorkspaceFactory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workspaceFactoryInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (_isStandAlone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class__isStandAlone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Property_isStandAlone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (AttachedItemId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_AttachedItemId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAttachedItemId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (AttachedItemListId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_AttachedItemListId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAttachedItemListId);
            Action currentAction = () => propertyInfo.SetValue(_workspaceFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (AttachedItemListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_AttachedItemListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAttachedItemListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (AttachedItemTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_AttachedItemTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAttachedItemTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (CreatorId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_CreatorId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreatorId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (ParentWebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_ParentWebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyParentWebId);
            Action currentAction = () => propertyInfo.SetValue(_workspaceFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (ParentWebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_ParentWebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParentWebId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_workspaceFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (TempGalWebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_TempGalWebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyTempGalWebId);
            Action currentAction = () => propertyInfo.SetValue(_workspaceFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (TempGalWebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_TempGalWebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTempGalWebId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (UniquePermission) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_UniquePermission_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUniquePermission);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (WebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebId);
            Action currentAction = () => propertyInfo.SetValue(_workspaceFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceFactory) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceFactory_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}