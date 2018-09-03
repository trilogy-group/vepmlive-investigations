using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore.Infrastructure.Entities;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Admininfos" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdmininfosTest : AbstractBaseSetupTypedTest<Admininfos>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Admininfos) Initializer

        private const string MethodGetWResID = "GetWResID";
        private const string MethodCanDeleteCostCategoryRole = "CanDeleteCostCategoryRole";
        private const string MethodCanDeleteCostCategoryRolebyCCRId = "CanDeleteCostCategoryRolebyCCRId";
        private const string MethodCanDeleteLookupValue = "CanDeleteLookupValue";
        private const string MethodCanDeleteLookupValueasCC = "CanDeleteLookupValueasCC";
        private const string MethodCanDeleteWorkSchedule = "CanDeleteWorkSchedule";
        private const string MethodCanDeleteHolidaySchedule = "CanDeleteHolidaySchedule";
        private const string MethodCanDeleteResourceGroup = "CanDeleteResourceGroup";
        private const string MethodDeleteDepartments = "DeleteDepartments";
        private const string MethodDeleteHolidaySchedule = "DeleteHolidaySchedule";
        private const string MethodDeleteListWork = "DeleteListWork";
        private const string MethodDeleteLookup = "DeleteLookup";
        private const string MethodDeletePersonalItem = "DeletePersonalItem";
        private const string MethodDeletePIListWork = "DeletePIListWork";
        private const string MethodDeleteResourceTimeoff = "DeleteResourceTimeoff";
        private const string MethodCheckIfResourceExists = "CheckIfResourceExists";
        private const string MethodDeleteRole = "DeleteRole";
        private const string MethodDeleteCCRole = "DeleteCCRole";
        private const string MethodCountRoleCategories = "CountRoleCategories";
        private const string MethodDeleteWorkSchedule = "DeleteWorkSchedule";
        private const string MethodGetCostCategoryRoles = "GetCostCategoryRoles";
        private const string MethodUpdateCategoriesFromRoles = "UpdateCategoriesFromRoles";
        private const string MethodGetUID = "GetUID";
        private const string MethodUpdateDepartments = "UpdateDepartments";
        private const string MethodInsertOnEpgLookupValue = "InsertOnEpgLookupValue";
        private const string MethodApplyUpdateOnEpgpLookupValues = "ApplyUpdateOnEpgpLookupValues";
        private const string MethodUpdateHolidaySchedule = "UpdateHolidaySchedule";
        private const string MethodInitializeId = "InitializeId";
        private const string MethodGetNextIdValue = "GetNextIdValue";
        private const string MethodInsertOrUpdateEpgGroups = "InsertOrUpdateEpgGroups";
        private const string MethodUpdateListWork = "UpdateListWork";
        private const string MethodDeleteDuplicatedWork = "DeleteDuplicatedWork";
        private const string MethodIsBUpdateOk = "IsBUpdateOk";
        private const string MethodGetEpgpProjects = "GetEpgpProjects";
        private const string MethodUpdatePersonalItems = "UpdatePersonalItems";
        private const string MethodUpdateResourceTimeoff = "UpdateResourceTimeoff";
        private const string MethodUpdateRoles = "UpdateRoles";
        private const string MethodGetNLookupId = "GetNLookupId";
        private const string MethodGetNewLookupId = "GetNewLookupId";
        private const string MethodUpdateAdminRecord = "UpdateAdminRecord";
        private const string MethodUpdateRoles_OLD = "UpdateRoles_OLD";
        private const string MethodUpdateScheduledWork = "UpdateScheduledWork";
        private const string MethodGetCCRs = "GetCCRs";
        private const string MethodGetDepts = "GetDepts";
        private const string MethodGetWHs = "GetWHs";
        private const string MethodGetHOLs = "GetHOLs";
        private const string MethodGetPersonalItems = "GetPersonalItems";
        private const string MethodGetItemKey = "GetItemKey";
        private const string MethodGetLookup = "GetLookup";
        private const string MethodGetRoleItemKey = "GetRoleItemKey";
        private const string MethodUpdateWorkSchedule = "UpdateWorkSchedule";
        private const string MethodGetAutoPosts = "GetAutoPosts";
        private const string MethodPostCostValuesForScheduledWork = "PostCostValuesForScheduledWork";
        private const string MethodPostCostValues = "PostCostValues";
        private const string FieldMaxIdColumn = "MaxIdColumn";
        private const string FieldWresIdColumn = "WresIdColumn";
        private const string FieldCantCreateNewGroupRecordMessage = "CantCreateNewGroupRecordMessage";
        private const string FieldNoResourceMatchesSuppliedMessage = "NoResourceMatchesSuppliedMessage";
        private const string FieldPiNotFoundMessage = "PiNotFoundMessage";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _admininfosInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Admininfos _admininfosInstance;
        private Admininfos _admininfosInstanceFixture;

        #region General Initializer : Class (Admininfos) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Admininfos" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _admininfosInstanceType = typeof(Admininfos);
            _admininfosInstanceFixture = Create(true);
            _admininfosInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Admininfos" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetWResID)]
        [TestCase(MethodCanDeleteCostCategoryRole)]
        [TestCase(MethodCanDeleteCostCategoryRolebyCCRId)]
        [TestCase(MethodCanDeleteLookupValue)]
        [TestCase(MethodCanDeleteLookupValueasCC)]
        [TestCase(MethodCanDeleteWorkSchedule)]
        [TestCase(MethodCanDeleteHolidaySchedule)]
        [TestCase(MethodCanDeleteResourceGroup)]
        [TestCase(MethodDeleteDepartments)]
        [TestCase(MethodDeleteHolidaySchedule)]
        [TestCase(MethodDeleteListWork)]
        [TestCase(MethodDeleteLookup)]
        [TestCase(MethodDeletePersonalItem)]
        [TestCase(MethodDeletePIListWork)]
        [TestCase(MethodDeleteResourceTimeoff)]
        [TestCase(MethodCheckIfResourceExists)]
        [TestCase(MethodDeleteRole)]
        [TestCase(MethodDeleteCCRole)]
        [TestCase(MethodCountRoleCategories)]
        [TestCase(MethodDeleteWorkSchedule)]
        [TestCase(MethodGetCostCategoryRoles)]
        [TestCase(MethodUpdateCategoriesFromRoles)]
        [TestCase(MethodGetUID)]
        [TestCase(MethodUpdateDepartments)]
        [TestCase(MethodInsertOnEpgLookupValue)]
        [TestCase(MethodApplyUpdateOnEpgpLookupValues)]
        [TestCase(MethodUpdateHolidaySchedule)]
        [TestCase(MethodInitializeId)]
        [TestCase(MethodGetNextIdValue)]
        [TestCase(MethodInsertOrUpdateEpgGroups)]
        [TestCase(MethodUpdateListWork)]
        [TestCase(MethodDeleteDuplicatedWork)]
        [TestCase(MethodIsBUpdateOk)]
        [TestCase(MethodGetEpgpProjects)]
        [TestCase(MethodUpdatePersonalItems)]
        [TestCase(MethodUpdateResourceTimeoff)]
        [TestCase(MethodUpdateRoles)]
        [TestCase(MethodGetNLookupId)]
        [TestCase(MethodGetNewLookupId)]
        [TestCase(MethodUpdateAdminRecord)]
        [TestCase(MethodUpdateRoles_OLD)]
        [TestCase(MethodUpdateScheduledWork)]
        [TestCase(MethodGetCCRs)]
        [TestCase(MethodGetDepts)]
        [TestCase(MethodGetWHs)]
        [TestCase(MethodGetHOLs)]
        [TestCase(MethodGetPersonalItems)]
        [TestCase(MethodGetItemKey)]
        [TestCase(MethodGetLookup)]
        [TestCase(MethodGetRoleItemKey)]
        [TestCase(MethodUpdateWorkSchedule)]
        [TestCase(MethodGetAutoPosts)]
        [TestCase(MethodPostCostValuesForScheduledWork)]
        [TestCase(MethodPostCostValues)]
        public void AUT_Admininfos_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Admininfos>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetWResID_Method_Call_Internally(Type[] types)
        {
            var methodGetWResIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetWResID, Fixture, methodGetWResIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWResID_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetWResID();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWResID_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWResIDPrametersTypes = null;
            object[] parametersOfGetWResID = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWResID, methodGetWResIDPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, int>(_admininfosInstanceFixture, out exception1, parametersOfGetWResID);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodGetWResID, parametersOfGetWResID, methodGetWResIDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetWResID.ShouldBeNull();
            methodGetWResIDPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWResID_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetWResIDPrametersTypes = null;
            object[] parametersOfGetWResID = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWResID, methodGetWResIDPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, int>(_admininfosInstanceFixture, out exception1, parametersOfGetWResID);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodGetWResID, parametersOfGetWResID, methodGetWResIDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetWResID.ShouldBeNull();
            methodGetWResIDPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWResID_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetWResIDPrametersTypes = null;
            object[] parametersOfGetWResID = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodGetWResID, parametersOfGetWResID, methodGetWResIDPrametersTypes);

            // Assert
            parametersOfGetWResID.ShouldBeNull();
            methodGetWResIDPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWResID_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetWResIDPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetWResID, Fixture, methodGetWResIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWResIDPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWResID) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWResID_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWResID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteCostCategoryRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteCostCategoryRole, Fixture, methodCanDeleteCostCategoryRolePrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteCostCategoryRole(checkRoleUID, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteCostCategoryRolePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteCostCategoryRole = { checkRoleUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRole, methodCanDeleteCostCategoryRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteCostCategoryRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteCostCategoryRole, parametersOfCanDeleteCostCategoryRole, methodCanDeleteCostCategoryRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteCostCategoryRole.ShouldNotBeNull();
            parametersOfCanDeleteCostCategoryRole.Length.ShouldBe(2);
            methodCanDeleteCostCategoryRolePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteCostCategoryRolePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteCostCategoryRole = { checkRoleUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRole, methodCanDeleteCostCategoryRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteCostCategoryRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteCostCategoryRole, parametersOfCanDeleteCostCategoryRole, methodCanDeleteCostCategoryRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteCostCategoryRole.ShouldNotBeNull();
            parametersOfCanDeleteCostCategoryRole.Length.ShouldBe(2);
            methodCanDeleteCostCategoryRolePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteCostCategoryRolePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteCostCategoryRole = { checkRoleUID, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteCostCategoryRole, parametersOfCanDeleteCostCategoryRole, methodCanDeleteCostCategoryRolePrametersTypes);

            // Assert
            parametersOfCanDeleteCostCategoryRole.ShouldNotBeNull();
            parametersOfCanDeleteCostCategoryRole.Length.ShouldBe(2);
            methodCanDeleteCostCategoryRolePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteCostCategoryRolePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteCostCategoryRole, Fixture, methodCanDeleteCostCategoryRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteCostCategoryRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRole) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRole_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRole, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteCostCategoryRolebyCCRId, Fixture, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checkCCUID = CreateType<int>();
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteCostCategoryRolebyCCRId(checkCCUID, checkRoleUID, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checkCCUID = CreateType<int>();
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfCanDeleteCostCategoryRolebyCCRId = { checkCCUID, checkRoleUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRolebyCCRId, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteCostCategoryRolebyCCRId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteCostCategoryRolebyCCRId, parametersOfCanDeleteCostCategoryRolebyCCRId, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteCostCategoryRolebyCCRId.ShouldNotBeNull();
            parametersOfCanDeleteCostCategoryRolebyCCRId.Length.ShouldBe(3);
            methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checkCCUID = CreateType<int>();
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfCanDeleteCostCategoryRolebyCCRId = { checkCCUID, checkRoleUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRolebyCCRId, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteCostCategoryRolebyCCRId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteCostCategoryRolebyCCRId, parametersOfCanDeleteCostCategoryRolebyCCRId, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteCostCategoryRolebyCCRId.ShouldNotBeNull();
            parametersOfCanDeleteCostCategoryRolebyCCRId.Length.ShouldBe(3);
            methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkCCUID = CreateType<int>();
            var checkRoleUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfCanDeleteCostCategoryRolebyCCRId = { checkCCUID, checkRoleUID, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteCostCategoryRolebyCCRId, parametersOfCanDeleteCostCategoryRolebyCCRId, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes);

            // Assert
            parametersOfCanDeleteCostCategoryRolebyCCRId.ShouldNotBeNull();
            parametersOfCanDeleteCostCategoryRolebyCCRId.Length.ShouldBe(3);
            methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteCostCategoryRolebyCCRId, Fixture, methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteCostCategoryRolebyCCRIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRolebyCCRId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteCostCategoryRolebyCCRId) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteCostCategoryRolebyCCRId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteCostCategoryRolebyCCRId, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteLookupValue_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteLookupValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteLookupValue, Fixture, methodCanDeleteLookupValuePrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteLookupValue(checklookupUID, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteLookupValuePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteLookupValue = { checklookupUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValue, methodCanDeleteLookupValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteLookupValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteLookupValue, parametersOfCanDeleteLookupValue, methodCanDeleteLookupValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteLookupValue.ShouldNotBeNull();
            parametersOfCanDeleteLookupValue.Length.ShouldBe(2);
            methodCanDeleteLookupValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteLookupValuePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteLookupValue = { checklookupUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValue, methodCanDeleteLookupValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteLookupValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteLookupValue, parametersOfCanDeleteLookupValue, methodCanDeleteLookupValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteLookupValue.ShouldNotBeNull();
            parametersOfCanDeleteLookupValue.Length.ShouldBe(2);
            methodCanDeleteLookupValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteLookupValuePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteLookupValue = { checklookupUID, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteLookupValue, parametersOfCanDeleteLookupValue, methodCanDeleteLookupValuePrametersTypes);

            // Assert
            parametersOfCanDeleteLookupValue.ShouldNotBeNull();
            parametersOfCanDeleteLookupValue.Length.ShouldBe(2);
            methodCanDeleteLookupValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteLookupValuePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteLookupValue, Fixture, methodCanDeleteLookupValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteLookupValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteLookupValue) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteLookupValueasCCPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteLookupValueasCC, Fixture, methodCanDeleteLookupValueasCCPrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var nRoleUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteLookupValueasCC(checklookupUID, out sresult, out nRoleUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var nRoleUID = CreateType<int>();
            var methodCanDeleteLookupValueasCCPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfCanDeleteLookupValueasCC = { checklookupUID, sresult, nRoleUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValueasCC, methodCanDeleteLookupValueasCCPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteLookupValueasCC);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteLookupValueasCC, parametersOfCanDeleteLookupValueasCC, methodCanDeleteLookupValueasCCPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteLookupValueasCC.ShouldNotBeNull();
            parametersOfCanDeleteLookupValueasCC.Length.ShouldBe(3);
            methodCanDeleteLookupValueasCCPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var nRoleUID = CreateType<int>();
            var methodCanDeleteLookupValueasCCPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfCanDeleteLookupValueasCC = { checklookupUID, sresult, nRoleUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValueasCC, methodCanDeleteLookupValueasCCPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteLookupValueasCC);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteLookupValueasCC, parametersOfCanDeleteLookupValueasCC, methodCanDeleteLookupValueasCCPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteLookupValueasCC.ShouldNotBeNull();
            parametersOfCanDeleteLookupValueasCC.Length.ShouldBe(3);
            methodCanDeleteLookupValueasCCPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checklookupUID = CreateType<int>();
            var sresult = CreateType<string>();
            var nRoleUID = CreateType<int>();
            var methodCanDeleteLookupValueasCCPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfCanDeleteLookupValueasCC = { checklookupUID, sresult, nRoleUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteLookupValueasCC, parametersOfCanDeleteLookupValueasCC, methodCanDeleteLookupValueasCCPrametersTypes);

            // Assert
            parametersOfCanDeleteLookupValueasCC.ShouldNotBeNull();
            parametersOfCanDeleteLookupValueasCC.Length.ShouldBe(3);
            methodCanDeleteLookupValueasCCPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteLookupValueasCCPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteLookupValueasCC, Fixture, methodCanDeleteLookupValueasCCPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteLookupValueasCCPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValueasCC, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteLookupValueasCC) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteLookupValueasCC_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteLookupValueasCC, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteWorkSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteWorkSchedule, Fixture, methodCanDeleteWorkSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteWorkSchedule(checkUID, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteWorkSchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteWorkSchedule = { checkUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteWorkSchedule, methodCanDeleteWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteWorkSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteWorkSchedule, parametersOfCanDeleteWorkSchedule, methodCanDeleteWorkSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfCanDeleteWorkSchedule.Length.ShouldBe(2);
            methodCanDeleteWorkSchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteWorkSchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteWorkSchedule = { checkUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteWorkSchedule, methodCanDeleteWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteWorkSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteWorkSchedule, parametersOfCanDeleteWorkSchedule, methodCanDeleteWorkSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfCanDeleteWorkSchedule.Length.ShouldBe(2);
            methodCanDeleteWorkSchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteWorkSchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteWorkSchedule = { checkUID, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteWorkSchedule, parametersOfCanDeleteWorkSchedule, methodCanDeleteWorkSchedulePrametersTypes);

            // Assert
            parametersOfCanDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfCanDeleteWorkSchedule.Length.ShouldBe(2);
            methodCanDeleteWorkSchedulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteWorkSchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteWorkSchedule, Fixture, methodCanDeleteWorkSchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteWorkSchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteWorkSchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteWorkSchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteWorkSchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteWorkSchedule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteHolidaySchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteHolidaySchedule, Fixture, methodCanDeleteHolidaySchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteHolidaySchedule(checkUID, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteHolidaySchedule = { checkUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteHolidaySchedule, methodCanDeleteHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteHolidaySchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteHolidaySchedule, parametersOfCanDeleteHolidaySchedule, methodCanDeleteHolidaySchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfCanDeleteHolidaySchedule.Length.ShouldBe(2);
            methodCanDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteHolidaySchedule = { checkUID, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteHolidaySchedule, methodCanDeleteHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteHolidaySchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteHolidaySchedule, parametersOfCanDeleteHolidaySchedule, methodCanDeleteHolidaySchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfCanDeleteHolidaySchedule.Length.ShouldBe(2);
            methodCanDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfCanDeleteHolidaySchedule = { checkUID, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteHolidaySchedule, parametersOfCanDeleteHolidaySchedule, methodCanDeleteHolidaySchedulePrametersTypes);

            // Assert
            parametersOfCanDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfCanDeleteHolidaySchedule.Length.ShouldBe(2);
            methodCanDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteHolidaySchedule, Fixture, methodCanDeleteHolidaySchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteHolidaySchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteHolidaySchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteHolidaySchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteHolidaySchedule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_Internally(Type[] types)
        {
            var methodCanDeleteResourceGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteResourceGroup, Fixture, methodCanDeleteResourceGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var lEntity = CreateType<int>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CanDeleteResourceGroup(checkUID, lEntity, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var lEntity = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteResourceGroupPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfCanDeleteResourceGroup = { checkUID, lEntity, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteResourceGroup, methodCanDeleteResourceGroupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteResourceGroup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteResourceGroup, parametersOfCanDeleteResourceGroup, methodCanDeleteResourceGroupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteResourceGroup.ShouldNotBeNull();
            parametersOfCanDeleteResourceGroup.Length.ShouldBe(3);
            methodCanDeleteResourceGroupPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var lEntity = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteResourceGroupPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfCanDeleteResourceGroup = { checkUID, lEntity, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDeleteResourceGroup, methodCanDeleteResourceGroupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfCanDeleteResourceGroup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteResourceGroup, parametersOfCanDeleteResourceGroup, methodCanDeleteResourceGroupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanDeleteResourceGroup.ShouldNotBeNull();
            parametersOfCanDeleteResourceGroup.Length.ShouldBe(3);
            methodCanDeleteResourceGroupPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkUID = CreateType<int>();
            var lEntity = CreateType<int>();
            var sresult = CreateType<string>();
            var methodCanDeleteResourceGroupPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfCanDeleteResourceGroup = { checkUID, lEntity, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodCanDeleteResourceGroup, parametersOfCanDeleteResourceGroup, methodCanDeleteResourceGroupPrametersTypes);

            // Assert
            parametersOfCanDeleteResourceGroup.ShouldNotBeNull();
            parametersOfCanDeleteResourceGroup.Length.ShouldBe(3);
            methodCanDeleteResourceGroupPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeleteResourceGroupPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCanDeleteResourceGroup, Fixture, methodCanDeleteResourceGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeleteResourceGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDeleteResourceGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDeleteResourceGroup) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CanDeleteResourceGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDeleteResourceGroup, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteDepartments_Method_Call_Internally(Type[] types)
        {
            var methodDeleteDepartmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteDepartments, Fixture, methodDeleteDepartmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var deletedeptUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteDepartments(deletedeptUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var deletedeptUID = CreateType<int>();
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteDepartments = { deletedeptUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, methodDeleteDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteDepartments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteDepartments, parametersOfDeleteDepartments, methodDeleteDepartmentsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteDepartments.ShouldNotBeNull();
            parametersOfDeleteDepartments.Length.ShouldBe(1);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var deletedeptUID = CreateType<int>();
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteDepartments = { deletedeptUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, methodDeleteDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteDepartments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteDepartments, parametersOfDeleteDepartments, methodDeleteDepartmentsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteDepartments.ShouldNotBeNull();
            parametersOfDeleteDepartments.Length.ShouldBe(1);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deletedeptUID = CreateType<int>();
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteDepartments = { deletedeptUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteDepartments, parametersOfDeleteDepartments, methodDeleteDepartmentsPrametersTypes);

            // Assert
            parametersOfDeleteDepartments.ShouldNotBeNull();
            parametersOfDeleteDepartments.Length.ShouldBe(1);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteDepartments, Fixture, methodDeleteDepartmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDepartments_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_Internally(Type[] types)
        {
            var methodDeleteHolidaySchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteHolidaySchedule, Fixture, methodDeleteHolidaySchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteHolidaySchedule(sXML, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteHolidaySchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteHolidaySchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteHolidaySchedule, parametersOfDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfDeleteHolidaySchedule.Length.ShouldBe(2);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteHolidaySchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteHolidaySchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteHolidaySchedule, parametersOfDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfDeleteHolidaySchedule.Length.ShouldBe(2);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteHolidaySchedule = { sXML, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteHolidaySchedule, parametersOfDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            parametersOfDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfDeleteHolidaySchedule.Length.ShouldBe(2);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteHolidaySchedule, Fixture, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteHolidaySchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteListWork_Method_Call_Internally(Type[] types)
        {
            var methodDeleteListWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteListWork, Fixture, methodDeleteListWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteListWork(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteListWork = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteListWork, methodDeleteListWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteListWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteListWork, parametersOfDeleteListWork, methodDeleteListWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteListWork.ShouldNotBeNull();
            parametersOfDeleteListWork.Length.ShouldBe(2);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteListWork = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteListWork, methodDeleteListWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteListWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteListWork, parametersOfDeleteListWork, methodDeleteListWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteListWork.ShouldNotBeNull();
            parametersOfDeleteListWork.Length.ShouldBe(2);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteListWork = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteListWork, parametersOfDeleteListWork, methodDeleteListWorkPrametersTypes);

            // Assert
            parametersOfDeleteListWork.ShouldNotBeNull();
            parametersOfDeleteListWork.Length.ShouldBe(2);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteListWork, Fixture, methodDeleteListWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteListWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteListWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteListWork, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteLookup_Method_Call_Internally(Type[] types)
        {
            var methodDeleteLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteLookup, Fixture, methodDeleteLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteLookup(deletelookupUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodDeleteLookupPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteLookup = { deletelookupUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteLookup, methodDeleteLookupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteLookup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteLookup, parametersOfDeleteLookup, methodDeleteLookupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteLookup.ShouldNotBeNull();
            parametersOfDeleteLookup.Length.ShouldBe(1);
            methodDeleteLookupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodDeleteLookupPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteLookup = { deletelookupUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteLookup, methodDeleteLookupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteLookup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteLookup, parametersOfDeleteLookup, methodDeleteLookupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteLookup.ShouldNotBeNull();
            parametersOfDeleteLookup.Length.ShouldBe(1);
            methodDeleteLookupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodDeleteLookupPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteLookup = { deletelookupUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteLookup, parametersOfDeleteLookup, methodDeleteLookupPrametersTypes);

            // Assert
            parametersOfDeleteLookup.ShouldNotBeNull();
            parametersOfDeleteLookup.Length.ShouldBe(1);
            methodDeleteLookupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteLookupPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteLookup, Fixture, methodDeleteLookupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteLookupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteLookup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteLookup) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteLookup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteLookup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeletePersonalItem_Method_Call_Internally(Type[] types)
        {
            var methodDeletePersonalItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeletePersonalItem, Fixture, methodDeletePersonalItemPrametersTypes);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var deleteitemUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeletePersonalItem(deleteitemUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var deleteitemUID = CreateType<int>();
            var methodDeletePersonalItemPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeletePersonalItem = { deleteitemUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeletePersonalItem, methodDeletePersonalItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeletePersonalItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeletePersonalItem, parametersOfDeletePersonalItem, methodDeletePersonalItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeletePersonalItem.ShouldNotBeNull();
            parametersOfDeletePersonalItem.Length.ShouldBe(1);
            methodDeletePersonalItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var deleteitemUID = CreateType<int>();
            var methodDeletePersonalItemPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeletePersonalItem = { deleteitemUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeletePersonalItem, methodDeletePersonalItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeletePersonalItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeletePersonalItem, parametersOfDeletePersonalItem, methodDeletePersonalItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeletePersonalItem.ShouldNotBeNull();
            parametersOfDeletePersonalItem.Length.ShouldBe(1);
            methodDeletePersonalItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deleteitemUID = CreateType<int>();
            var methodDeletePersonalItemPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeletePersonalItem = { deleteitemUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeletePersonalItem, parametersOfDeletePersonalItem, methodDeletePersonalItemPrametersTypes);

            // Assert
            parametersOfDeletePersonalItem.ShouldNotBeNull();
            parametersOfDeletePersonalItem.Length.ShouldBe(1);
            methodDeletePersonalItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePersonalItemPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeletePersonalItem, Fixture, methodDeletePersonalItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePersonalItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePersonalItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeletePersonalItem) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePersonalItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeletePersonalItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeletePIListWork_Method_Call_Internally(Type[] types)
        {
            var methodDeletePIListWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeletePIListWork, Fixture, methodDeletePIListWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeletePIListWork(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeletePIListWork = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, methodDeletePIListWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeletePIListWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeletePIListWork, parametersOfDeletePIListWork, methodDeletePIListWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeletePIListWork.ShouldNotBeNull();
            parametersOfDeletePIListWork.Length.ShouldBe(2);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeletePIListWork = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, methodDeletePIListWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeletePIListWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeletePIListWork, parametersOfDeletePIListWork, methodDeletePIListWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeletePIListWork.ShouldNotBeNull();
            parametersOfDeletePIListWork.Length.ShouldBe(2);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeletePIListWork = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeletePIListWork, parametersOfDeletePIListWork, methodDeletePIListWorkPrametersTypes);

            // Assert
            parametersOfDeletePIListWork.ShouldNotBeNull();
            parametersOfDeletePIListWork.Length.ShouldBe(2);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeletePIListWork, Fixture, methodDeletePIListWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeletePIListWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourceTimeoffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteResourceTimeoff, Fixture, methodDeleteResourceTimeoffPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteResourceTimeoff(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteResourceTimeoff = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteResourceTimeoff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteResourceTimeoff, parametersOfDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteResourceTimeoff.ShouldNotBeNull();
            parametersOfDeleteResourceTimeoff.Length.ShouldBe(2);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteResourceTimeoff = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteResourceTimeoff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteResourceTimeoff, parametersOfDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteResourceTimeoff.ShouldNotBeNull();
            parametersOfDeleteResourceTimeoff.Length.ShouldBe(2);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteResourceTimeoff = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteResourceTimeoff, parametersOfDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            parametersOfDeleteResourceTimeoff.ShouldNotBeNull();
            parametersOfDeleteResourceTimeoff.Length.ShouldBe(2);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteResourceTimeoff, Fixture, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteResourceTimeoff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckIfResourceExists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CheckIfResourceExists_Method_Call_Internally(Type[] types)
        {
            var methodCheckIfResourceExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCheckIfResourceExists, Fixture, methodCheckIfResourceExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckIfResourceExists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CheckIfResourceExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var extId = CreateType<string>();
            var wresId = CreateType<int>();
            var methodCheckIfResourceExistsPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCheckIfResourceExists = { extId, wresId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodCheckIfResourceExists, parametersOfCheckIfResourceExists, methodCheckIfResourceExistsPrametersTypes);

            // Assert
            parametersOfCheckIfResourceExists.ShouldNotBeNull();
            parametersOfCheckIfResourceExists.Length.ShouldBe(2);
            methodCheckIfResourceExistsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckIfResourceExists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CheckIfResourceExists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCheckIfResourceExistsPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCheckIfResourceExists, Fixture, methodCheckIfResourceExistsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCheckIfResourceExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CheckIfResourceExists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CheckIfResourceExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckIfResourceExistsPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCheckIfResourceExists, Fixture, methodCheckIfResourceExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckIfResourceExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteRole_Method_Call_Internally(Type[] types)
        {
            var methodDeleteRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteRole, Fixture, methodDeleteRolePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteRole(deletelookupUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodDeleteRolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteRole = { deletelookupUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteRole, methodDeleteRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteRole, parametersOfDeleteRole, methodDeleteRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteRole.ShouldNotBeNull();
            parametersOfDeleteRole.Length.ShouldBe(1);
            methodDeleteRolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodDeleteRolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteRole = { deletelookupUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteRole, methodDeleteRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteRole, parametersOfDeleteRole, methodDeleteRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteRole.ShouldNotBeNull();
            parametersOfDeleteRole.Length.ShouldBe(1);
            methodDeleteRolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodDeleteRolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteRole = { deletelookupUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteRole, parametersOfDeleteRole, methodDeleteRolePrametersTypes);

            // Assert
            parametersOfDeleteRole.ShouldNotBeNull();
            parametersOfDeleteRole.Length.ShouldBe(1);
            methodDeleteRolePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteRolePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteRole, Fixture, methodDeleteRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteRole) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteRole_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteRole, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteCCRole_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCCRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteCCRole, Fixture, methodDeleteCCRolePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var deleteCCUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteCCRole(deleteCCUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var deleteCCUID = CreateType<int>();
            var methodDeleteCCRolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCCRole = { deleteCCUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCCRole, methodDeleteCCRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteCCRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteCCRole, parametersOfDeleteCCRole, methodDeleteCCRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCCRole.ShouldNotBeNull();
            parametersOfDeleteCCRole.Length.ShouldBe(1);
            methodDeleteCCRolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var deleteCCUID = CreateType<int>();
            var methodDeleteCCRolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCCRole = { deleteCCUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCCRole, methodDeleteCCRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteCCRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteCCRole, parametersOfDeleteCCRole, methodDeleteCCRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCCRole.ShouldNotBeNull();
            parametersOfDeleteCCRole.Length.ShouldBe(1);
            methodDeleteCCRolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deleteCCUID = CreateType<int>();
            var methodDeleteCCRolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteCCRole = { deleteCCUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteCCRole, parametersOfDeleteCCRole, methodDeleteCCRolePrametersTypes);

            // Assert
            parametersOfDeleteCCRole.ShouldNotBeNull();
            parametersOfDeleteCCRole.Length.ShouldBe(1);
            methodDeleteCCRolePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCCRolePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteCCRole, Fixture, methodDeleteCCRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCCRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCCRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCCRole) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteCCRole_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCCRole, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_CountRoleCategories_Method_Call_Internally(Type[] types)
        {
            var methodCountRoleCategoriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCountRoleCategories, Fixture, methodCountRoleCategoriesPrametersTypes);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.CountRoleCategories(deletelookupUID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodCountRoleCategoriesPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfCountRoleCategories = { deletelookupUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCountRoleCategories, methodCountRoleCategoriesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, int>(_admininfosInstanceFixture, out exception1, parametersOfCountRoleCategories);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodCountRoleCategories, parametersOfCountRoleCategories, methodCountRoleCategoriesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCountRoleCategories.ShouldNotBeNull();
            parametersOfCountRoleCategories.Length.ShouldBe(1);
            methodCountRoleCategoriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodCountRoleCategoriesPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfCountRoleCategories = { deletelookupUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCountRoleCategories, methodCountRoleCategoriesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, int>(_admininfosInstanceFixture, out exception1, parametersOfCountRoleCategories);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodCountRoleCategories, parametersOfCountRoleCategories, methodCountRoleCategoriesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCountRoleCategories.ShouldNotBeNull();
            parametersOfCountRoleCategories.Length.ShouldBe(1);
            methodCountRoleCategoriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deletelookupUID = CreateType<int>();
            var methodCountRoleCategoriesPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfCountRoleCategories = { deletelookupUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodCountRoleCategories, parametersOfCountRoleCategories, methodCountRoleCategoriesPrametersTypes);

            // Assert
            parametersOfCountRoleCategories.ShouldNotBeNull();
            parametersOfCountRoleCategories.Length.ShouldBe(1);
            methodCountRoleCategoriesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCountRoleCategoriesPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodCountRoleCategories, Fixture, methodCountRoleCategoriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCountRoleCategoriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCountRoleCategories, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CountRoleCategories) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_CountRoleCategories_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCountRoleCategories, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteWorkSchedule_Method_Call_Internally(Type[] types)
        {
            var methodDeleteWorkSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteWorkSchedule, Fixture, methodDeleteWorkSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.DeleteWorkSchedule(sXML, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteWorkSchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteWorkSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteWorkSchedule, parametersOfDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfDeleteWorkSchedule.Length.ShouldBe(2);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteWorkSchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfDeleteWorkSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteWorkSchedule, parametersOfDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfDeleteWorkSchedule.Length.ShouldBe(2);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDeleteWorkSchedule = { sXML, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodDeleteWorkSchedule, parametersOfDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            parametersOfDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfDeleteWorkSchedule.Length.ShouldBe(2);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteWorkSchedule, Fixture, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteWorkSchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetCostCategoryRoles_Method_Call_Internally(Type[] types)
        {
            var methodGetCostCategoryRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCostCategoryRoles_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetCostCategoryRoles();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCostCategoryRoles_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCostCategoryRolesPrametersTypes = null;
            object[] parametersOfGetCostCategoryRoles = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostCategoryRoles, methodGetCostCategoryRolesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, IList<CostCategory>>(_admininfosInstanceFixture, out exception1, parametersOfGetCostCategoryRoles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, IList<CostCategory>>(_admininfosInstance, MethodGetCostCategoryRoles, parametersOfGetCostCategoryRoles, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCostCategoryRoles.ShouldBeNull();
            methodGetCostCategoryRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCostCategoryRoles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCostCategoryRolesPrametersTypes = null;
            object[] parametersOfGetCostCategoryRoles = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, IList<CostCategory>>(_admininfosInstance, MethodGetCostCategoryRoles, parametersOfGetCostCategoryRoles, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            parametersOfGetCostCategoryRoles.ShouldBeNull();
            methodGetCostCategoryRolesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCostCategoryRoles_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCostCategoryRolesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCostCategoryRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCostCategoryRoles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCostCategoryRolesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostCategoryRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : IList<CostCategory>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCostCategoryRoles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostCategoryRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateCategoriesFromRoles_Method_Call_Internally(Type[] types)
        {
            var methodUpdateCategoriesFromRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateCategoriesFromRoles, Fixture, methodUpdateCategoriesFromRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateCategoriesFromRoles_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateCategoriesFromRoles();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateCategoriesFromRoles_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodUpdateCategoriesFromRolesPrametersTypes = null;
            object[] parametersOfUpdateCategoriesFromRoles = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateCategoriesFromRoles, methodUpdateCategoriesFromRolesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateCategoriesFromRoles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateCategoriesFromRoles, parametersOfUpdateCategoriesFromRoles, methodUpdateCategoriesFromRolesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateCategoriesFromRoles.ShouldBeNull();
            methodUpdateCategoriesFromRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateCategoriesFromRoles_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodUpdateCategoriesFromRolesPrametersTypes = null;
            object[] parametersOfUpdateCategoriesFromRoles = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateCategoriesFromRoles, methodUpdateCategoriesFromRolesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateCategoriesFromRoles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateCategoriesFromRoles, parametersOfUpdateCategoriesFromRoles, methodUpdateCategoriesFromRolesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateCategoriesFromRoles.ShouldBeNull();
            methodUpdateCategoriesFromRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateCategoriesFromRoles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateCategoriesFromRolesPrametersTypes = null;
            object[] parametersOfUpdateCategoriesFromRoles = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateCategoriesFromRoles, parametersOfUpdateCategoriesFromRoles, methodUpdateCategoriesFromRolesPrametersTypes);

            // Assert
            parametersOfUpdateCategoriesFromRoles.ShouldBeNull();
            methodUpdateCategoriesFromRolesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateCategoriesFromRoles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateCategoriesFromRolesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateCategoriesFromRoles, Fixture, methodUpdateCategoriesFromRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateCategoriesFromRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateCategoriesFromRoles) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateCategoriesFromRoles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateCategoriesFromRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetUID_Method_Call_Internally(Type[] types)
        {
            var methodGetUIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetUID, Fixture, methodGetUIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUID) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetUID_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUID) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetUID_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUID, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateDepartments_Method_Call_Internally(Type[] types)
        {
            var methodUpdateDepartmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateDepartments, Fixture, methodUpdateDepartmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateDepartments(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateDepartments = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, methodUpdateDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateDepartments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateDepartments, parametersOfUpdateDepartments, methodUpdateDepartmentsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateDepartments.ShouldNotBeNull();
            parametersOfUpdateDepartments.Length.ShouldBe(2);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateDepartments = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, methodUpdateDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateDepartments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateDepartments, parametersOfUpdateDepartments, methodUpdateDepartmentsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateDepartments.ShouldNotBeNull();
            parametersOfUpdateDepartments.Length.ShouldBe(2);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateDepartments = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateDepartments, parametersOfUpdateDepartments, methodUpdateDepartmentsPrametersTypes);

            // Assert
            parametersOfUpdateDepartments.ShouldNotBeNull();
            parametersOfUpdateDepartments.Length.ShouldBe(2);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateDepartments, Fixture, methodUpdateDepartmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateDepartments_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertOnEpgLookupValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_InsertOnEpgLookupValue_Method_Call_Internally(Type[] types)
        {
            var methodInsertOnEpgLookupValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodInsertOnEpgLookupValue, Fixture, methodInsertOnEpgLookupValuePrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyUpdateOnEpgpLookupValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_ApplyUpdateOnEpgpLookupValues_Method_Call_Internally(Type[] types)
        {
            var methodApplyUpdateOnEpgpLookupValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodApplyUpdateOnEpgpLookupValues, Fixture, methodApplyUpdateOnEpgpLookupValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyUpdateOnEpgpLookupValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_ApplyUpdateOnEpgpLookupValues_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var dataTable = CreateType<DataTable>();
            var methodApplyUpdateOnEpgpLookupValuesPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(DataTable) };
            object[] parametersOfApplyUpdateOnEpgpLookupValues = { transaction, dataTable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_admininfosInstance, MethodApplyUpdateOnEpgpLookupValues, parametersOfApplyUpdateOnEpgpLookupValues, methodApplyUpdateOnEpgpLookupValuesPrametersTypes);

            // Assert
            parametersOfApplyUpdateOnEpgpLookupValues.ShouldNotBeNull();
            parametersOfApplyUpdateOnEpgpLookupValues.Length.ShouldBe(2);
            methodApplyUpdateOnEpgpLookupValuesPrametersTypes.Length.ShouldBe(2);
            methodApplyUpdateOnEpgpLookupValuesPrametersTypes.Length.ShouldBe(parametersOfApplyUpdateOnEpgpLookupValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyUpdateOnEpgpLookupValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_ApplyUpdateOnEpgpLookupValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyUpdateOnEpgpLookupValuesPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodApplyUpdateOnEpgpLookupValues, Fixture, methodApplyUpdateOnEpgpLookupValuesPrametersTypes);

            // Assert
            methodApplyUpdateOnEpgpLookupValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_Internally(Type[] types)
        {
            var methodUpdateHolidaySchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateHolidaySchedule, Fixture, methodUpdateHolidaySchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateHolidaySchedule(sXML, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodUpdateHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateHolidaySchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedule, methodUpdateHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateHolidaySchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateHolidaySchedule, parametersOfUpdateHolidaySchedule, methodUpdateHolidaySchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateHolidaySchedule.ShouldNotBeNull();
            parametersOfUpdateHolidaySchedule.Length.ShouldBe(2);
            methodUpdateHolidaySchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodUpdateHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateHolidaySchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedule, methodUpdateHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateHolidaySchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateHolidaySchedule, parametersOfUpdateHolidaySchedule, methodUpdateHolidaySchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateHolidaySchedule.ShouldNotBeNull();
            parametersOfUpdateHolidaySchedule.Length.ShouldBe(2);
            methodUpdateHolidaySchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodUpdateHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateHolidaySchedule = { sXML, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateHolidaySchedule, parametersOfUpdateHolidaySchedule, methodUpdateHolidaySchedulePrametersTypes);

            // Assert
            parametersOfUpdateHolidaySchedule.ShouldNotBeNull();
            parametersOfUpdateHolidaySchedule.Length.ShouldBe(2);
            methodUpdateHolidaySchedulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateHolidaySchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateHolidaySchedule, Fixture, methodUpdateHolidaySchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateHolidaySchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateHolidaySchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_InitializeId_Method_Call_Internally(Type[] types)
        {
            var methodInitializeIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodInitializeId, Fixture, methodInitializeIdPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_InitializeId_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var sCommand = CreateType<string>();
            var id = CreateType<int>();
            var methodInitializeIdPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(string), typeof(int) };
            object[] parametersOfInitializeId = { transaction, sCommand, id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_admininfosInstance, MethodInitializeId, parametersOfInitializeId, methodInitializeIdPrametersTypes);

            // Assert
            parametersOfInitializeId.ShouldNotBeNull();
            parametersOfInitializeId.Length.ShouldBe(3);
            methodInitializeIdPrametersTypes.Length.ShouldBe(3);
            methodInitializeIdPrametersTypes.Length.ShouldBe(parametersOfInitializeId.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_InitializeId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeIdPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodInitializeId, Fixture, methodInitializeIdPrametersTypes);

            // Assert
            methodInitializeIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNextIdValue) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetNextIdValue_Method_Call_Internally(Type[] types)
        {
            var methodGetNextIdValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetNextIdValue, Fixture, methodGetNextIdValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetNextIdValue) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetNextIdValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlReader = CreateType<IDataReader>();
            var methodGetNextIdValuePrametersTypes = new Type[] { typeof(IDataReader) };
            object[] parametersOfGetNextIdValue = { sqlReader };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodGetNextIdValue, parametersOfGetNextIdValue, methodGetNextIdValuePrametersTypes);

            // Assert
            parametersOfGetNextIdValue.ShouldNotBeNull();
            parametersOfGetNextIdValue.Length.ShouldBe(1);
            methodGetNextIdValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNextIdValue) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetNextIdValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNextIdValuePrametersTypes = new Type[] { typeof(IDataReader) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetNextIdValue, Fixture, methodGetNextIdValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNextIdValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertOrUpdateEpgGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_InsertOrUpdateEpgGroups_Method_Call_Internally(Type[] types)
        {
            var methodInsertOrUpdateEpgGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodInsertOrUpdateEpgGroups, Fixture, methodInsertOrUpdateEpgGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertOrUpdateEpgGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_InsertOrUpdateEpgGroups_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var sCommand = CreateType<string>();
            var sTitle = CreateType<string>();
            var id = CreateType<int>();
            var methodInsertOrUpdateEpgGroupsPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfInsertOrUpdateEpgGroups = { transaction, sCommand, sTitle, id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_admininfosInstance, MethodInsertOrUpdateEpgGroups, parametersOfInsertOrUpdateEpgGroups, methodInsertOrUpdateEpgGroupsPrametersTypes);

            // Assert
            parametersOfInsertOrUpdateEpgGroups.ShouldNotBeNull();
            parametersOfInsertOrUpdateEpgGroups.Length.ShouldBe(4);
            methodInsertOrUpdateEpgGroupsPrametersTypes.Length.ShouldBe(4);
            methodInsertOrUpdateEpgGroupsPrametersTypes.Length.ShouldBe(parametersOfInsertOrUpdateEpgGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertOrUpdateEpgGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_InsertOrUpdateEpgGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertOrUpdateEpgGroupsPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(string), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodInsertOrUpdateEpgGroups, Fixture, methodInsertOrUpdateEpgGroupsPrametersTypes);

            // Assert
            methodInsertOrUpdateEpgGroupsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateListWork_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateListWork, Fixture, methodUpdateListWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateListWork(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateListWork = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListWork, methodUpdateListWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateListWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateListWork, parametersOfUpdateListWork, methodUpdateListWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListWork.ShouldNotBeNull();
            parametersOfUpdateListWork.Length.ShouldBe(2);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateListWork = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListWork, methodUpdateListWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateListWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateListWork, parametersOfUpdateListWork, methodUpdateListWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListWork.ShouldNotBeNull();
            parametersOfUpdateListWork.Length.ShouldBe(2);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateListWork = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateListWork, parametersOfUpdateListWork, methodUpdateListWorkPrametersTypes);

            // Assert
            parametersOfUpdateListWork.ShouldNotBeNull();
            parametersOfUpdateListWork.Length.ShouldBe(2);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateListWork, Fixture, methodUpdateListWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateListWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListWork, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteDuplicatedWork) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_DeleteDuplicatedWork_Method_Call_Internally(Type[] types)
        {
            var methodDeleteDuplicatedWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteDuplicatedWork, Fixture, methodDeleteDuplicatedWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteDuplicatedWork) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDuplicatedWork_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var sCommand = CreateType<string>();
            var nProjectId = CreateType<int>();
            var methodDeleteDuplicatedWorkPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(string), typeof(int) };
            object[] parametersOfDeleteDuplicatedWork = { transaction, sCommand, nProjectId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_admininfosInstance, MethodDeleteDuplicatedWork, parametersOfDeleteDuplicatedWork, methodDeleteDuplicatedWorkPrametersTypes);

            // Assert
            parametersOfDeleteDuplicatedWork.ShouldNotBeNull();
            parametersOfDeleteDuplicatedWork.Length.ShouldBe(3);
            methodDeleteDuplicatedWorkPrametersTypes.Length.ShouldBe(3);
            methodDeleteDuplicatedWorkPrametersTypes.Length.ShouldBe(parametersOfDeleteDuplicatedWork.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteDuplicatedWork) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_DeleteDuplicatedWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteDuplicatedWorkPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodDeleteDuplicatedWork, Fixture, methodDeleteDuplicatedWorkPrametersTypes);

            // Assert
            methodDeleteDuplicatedWorkPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBUpdateOk) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_IsBUpdateOk_Method_Call_Internally(Type[] types)
        {
            var methodIsBUpdateOkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodIsBUpdateOk, Fixture, methodIsBUpdateOkPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBUpdateOk) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_IsBUpdateOk_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var piExtId = CreateType<string>();
            var sErrorMessage = CreateType<string>();
            var nProjectID = CreateType<int>();
            var methodIsBUpdateOkPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            object[] parametersOfIsBUpdateOk = { piExtId, sErrorMessage, nProjectID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodIsBUpdateOk, parametersOfIsBUpdateOk, methodIsBUpdateOkPrametersTypes);

            // Assert
            parametersOfIsBUpdateOk.ShouldNotBeNull();
            parametersOfIsBUpdateOk.Length.ShouldBe(3);
            methodIsBUpdateOkPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBUpdateOk) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_IsBUpdateOk_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsBUpdateOkPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodIsBUpdateOk, Fixture, methodIsBUpdateOkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBUpdateOkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEpgpProjects) (Return Type : SqlDataReader) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetEpgpProjects_Method_Call_Internally(Type[] types)
        {
            var methodGetEpgpProjectsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetEpgpProjects, Fixture, methodGetEpgpProjectsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEpgpProjects) (Return Type : SqlDataReader) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetEpgpProjects_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var piExtId = CreateType<string>();
            var methodGetEpgpProjectsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetEpgpProjects = { piExtId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, SqlDataReader>(_admininfosInstance, MethodGetEpgpProjects, parametersOfGetEpgpProjects, methodGetEpgpProjectsPrametersTypes);

            // Assert
            parametersOfGetEpgpProjects.ShouldNotBeNull();
            parametersOfGetEpgpProjects.Length.ShouldBe(1);
            methodGetEpgpProjectsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEpgpProjects) (Return Type : SqlDataReader) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetEpgpProjects_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEpgpProjectsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetEpgpProjects, Fixture, methodGetEpgpProjectsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEpgpProjectsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEpgpProjects) (Return Type : SqlDataReader) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetEpgpProjects_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEpgpProjectsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetEpgpProjects, Fixture, methodGetEpgpProjectsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEpgpProjectsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdatePersonalItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdatePersonalItems, Fixture, methodUpdatePersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sError = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdatePersonalItems(data, out sResult, out sError);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sError = CreateType<string>();
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfUpdatePersonalItems = { data, sResult, sError };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdatePersonalItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdatePersonalItems, parametersOfUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdatePersonalItems.ShouldNotBeNull();
            parametersOfUpdatePersonalItems.Length.ShouldBe(3);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sError = CreateType<string>();
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfUpdatePersonalItems = { data, sResult, sError };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdatePersonalItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdatePersonalItems, parametersOfUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdatePersonalItems.ShouldNotBeNull();
            parametersOfUpdatePersonalItems.Length.ShouldBe(3);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sError = CreateType<string>();
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfUpdatePersonalItems = { data, sResult, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdatePersonalItems, parametersOfUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            parametersOfUpdatePersonalItems.ShouldNotBeNull();
            parametersOfUpdatePersonalItems.Length.ShouldBe(3);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdatePersonalItems, Fixture, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdatePersonalItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourceTimeoffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateResourceTimeoff, Fixture, methodUpdateResourceTimeoffPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateResourceTimeoff(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateResourceTimeoff = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateResourceTimeoff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateResourceTimeoff, parametersOfUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateResourceTimeoff.ShouldNotBeNull();
            parametersOfUpdateResourceTimeoff.Length.ShouldBe(2);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateResourceTimeoff = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateResourceTimeoff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateResourceTimeoff, parametersOfUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateResourceTimeoff.ShouldNotBeNull();
            parametersOfUpdateResourceTimeoff.Length.ShouldBe(2);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateResourceTimeoff = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateResourceTimeoff, parametersOfUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            parametersOfUpdateResourceTimeoff.ShouldNotBeNull();
            parametersOfUpdateResourceTimeoff.Length.ShouldBe(2);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateResourceTimeoff, Fixture, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateResourceTimeoff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateRoles_Method_Call_Internally(Type[] types)
        {
            var methodUpdateRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateRoles, Fixture, methodUpdateRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateRoles(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateRoles = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRoles, methodUpdateRolesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateRoles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateRoles, parametersOfUpdateRoles, methodUpdateRolesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateRoles.ShouldNotBeNull();
            parametersOfUpdateRoles.Length.ShouldBe(2);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateRoles = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRoles, methodUpdateRolesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateRoles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateRoles, parametersOfUpdateRoles, methodUpdateRolesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateRoles.ShouldNotBeNull();
            parametersOfUpdateRoles.Length.ShouldBe(2);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateRoles = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateRoles, parametersOfUpdateRoles, methodUpdateRolesPrametersTypes);

            // Assert
            parametersOfUpdateRoles.ShouldNotBeNull();
            parametersOfUpdateRoles.Length.ShouldBe(2);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateRoles, Fixture, methodUpdateRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateRoles, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNLookupId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetNLookupId_Method_Call_Internally(Type[] types)
        {
            var methodGetNLookupIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetNLookupId, Fixture, methodGetNLookupIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNLookupId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetNLookupId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var methodGetNLookupIdPrametersTypes = new Type[] { typeof(SqlTransaction) };
            object[] parametersOfGetNLookupId = { transaction };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodGetNLookupId, parametersOfGetNLookupId, methodGetNLookupIdPrametersTypes);

            // Assert
            parametersOfGetNLookupId.ShouldNotBeNull();
            parametersOfGetNLookupId.Length.ShouldBe(1);
            methodGetNLookupIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNLookupId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetNLookupId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNLookupIdPrametersTypes = new Type[] { typeof(SqlTransaction) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetNLookupId, Fixture, methodGetNLookupIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNLookupIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNewLookupId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetNewLookupId_Method_Call_Internally(Type[] types)
        {
            var methodGetNewLookupIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetNewLookupId, Fixture, methodGetNewLookupIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNewLookupId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetNewLookupId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var methodGetNewLookupIdPrametersTypes = new Type[] { typeof(SqlTransaction) };
            object[] parametersOfGetNewLookupId = { transaction };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, int>(_admininfosInstance, MethodGetNewLookupId, parametersOfGetNewLookupId, methodGetNewLookupIdPrametersTypes);

            // Assert
            parametersOfGetNewLookupId.ShouldNotBeNull();
            parametersOfGetNewLookupId.Length.ShouldBe(1);
            methodGetNewLookupIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNewLookupId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetNewLookupId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNewLookupIdPrametersTypes = new Type[] { typeof(SqlTransaction) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetNewLookupId, Fixture, methodGetNewLookupIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNewLookupIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateAdminRecord) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateAdminRecord_Method_Call_Internally(Type[] types)
        {
            var methodUpdateAdminRecordPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateAdminRecord, Fixture, methodUpdateAdminRecordPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateAdminRecord) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateAdminRecord_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transaction = CreateType<SqlTransaction>();
            var nLookupUid = CreateType<int>();
            var methodUpdateAdminRecordPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(int) };
            object[] parametersOfUpdateAdminRecord = { transaction, nLookupUid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_admininfosInstance, MethodUpdateAdminRecord, parametersOfUpdateAdminRecord, methodUpdateAdminRecordPrametersTypes);

            // Assert
            parametersOfUpdateAdminRecord.ShouldNotBeNull();
            parametersOfUpdateAdminRecord.Length.ShouldBe(2);
            methodUpdateAdminRecordPrametersTypes.Length.ShouldBe(2);
            methodUpdateAdminRecordPrametersTypes.Length.ShouldBe(parametersOfUpdateAdminRecord.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAdminRecord) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateAdminRecord_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateAdminRecordPrametersTypes = new Type[] { typeof(SqlTransaction), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateAdminRecord, Fixture, methodUpdateAdminRecordPrametersTypes);

            // Assert
            methodUpdateAdminRecordPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateRoles_OLD_Method_Call_Internally(Type[] types)
        {
            var methodUpdateRoles_OLDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateRoles_OLD, Fixture, methodUpdateRoles_OLDPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateRoles_OLD(data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateRoles_OLDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateRoles_OLD = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRoles_OLD, methodUpdateRoles_OLDPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateRoles_OLD);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateRoles_OLD, parametersOfUpdateRoles_OLD, methodUpdateRoles_OLDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateRoles_OLD.ShouldNotBeNull();
            parametersOfUpdateRoles_OLD.Length.ShouldBe(2);
            methodUpdateRoles_OLDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateRoles_OLDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateRoles_OLD = { data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRoles_OLD, methodUpdateRoles_OLDPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateRoles_OLD);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateRoles_OLD, parametersOfUpdateRoles_OLD, methodUpdateRoles_OLDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateRoles_OLD.ShouldNotBeNull();
            parametersOfUpdateRoles_OLD.Length.ShouldBe(2);
            methodUpdateRoles_OLDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateRoles_OLDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateRoles_OLD = { data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateRoles_OLD, parametersOfUpdateRoles_OLD, methodUpdateRoles_OLDPrametersTypes);

            // Assert
            parametersOfUpdateRoles_OLD.ShouldNotBeNull();
            parametersOfUpdateRoles_OLD.Length.ShouldBe(2);
            methodUpdateRoles_OLDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateRoles_OLDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateRoles_OLD, Fixture, methodUpdateRoles_OLDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateRoles_OLDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateRoles_OLD, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateRoles_OLD) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateRoles_OLD_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateRoles_OLD, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateScheduledWork_Method_Call_Internally(Type[] types)
        {
            var methodUpdateScheduledWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateScheduledWork, Fixture, methodUpdateScheduledWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var worktype = CreateType<int>();
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateScheduledWork(worktype, data, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var worktype = CreateType<int>();
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfUpdateScheduledWork = { worktype, data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateScheduledWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateScheduledWork, parametersOfUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateScheduledWork.ShouldNotBeNull();
            parametersOfUpdateScheduledWork.Length.ShouldBe(3);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var worktype = CreateType<int>();
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfUpdateScheduledWork = { worktype, data, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateScheduledWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateScheduledWork, parametersOfUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateScheduledWork.ShouldNotBeNull();
            parametersOfUpdateScheduledWork.Length.ShouldBe(3);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var worktype = CreateType<int>();
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfUpdateScheduledWork = { worktype, data, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateScheduledWork, parametersOfUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            parametersOfUpdateScheduledWork.ShouldNotBeNull();
            parametersOfUpdateScheduledWork.Length.ShouldBe(3);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateScheduledWork, Fixture, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateScheduledWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetCCRs_Method_Call_Internally(Type[] types)
        {
            var methodGetCCRsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetCCRs, Fixture, methodGetCCRsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCCRs_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetCCRs();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCCRs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCCRsPrametersTypes = null;
            object[] parametersOfGetCCRs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCCRs, methodGetCCRsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, string>(_admininfosInstanceFixture, out exception1, parametersOfGetCCRs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetCCRs, parametersOfGetCCRs, methodGetCCRsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCCRs.ShouldBeNull();
            methodGetCCRsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCCRs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCCRsPrametersTypes = null;
            object[] parametersOfGetCCRs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetCCRs, parametersOfGetCCRs, methodGetCCRsPrametersTypes);

            // Assert
            parametersOfGetCCRs.ShouldBeNull();
            methodGetCCRsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCCRs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCCRsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetCCRs, Fixture, methodGetCCRsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCCRsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCCRs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCCRsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetCCRs, Fixture, methodGetCCRsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCCRsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCCRs) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetCCRs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCCRs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetDepts_Method_Call_Internally(Type[] types)
        {
            var methodGetDeptsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetDepts, Fixture, methodGetDeptsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetDepts_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetDepts();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetDepts_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDeptsPrametersTypes = null;
            object[] parametersOfGetDepts = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDepts, methodGetDeptsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, string>(_admininfosInstanceFixture, out exception1, parametersOfGetDepts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetDepts, parametersOfGetDepts, methodGetDeptsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDepts.ShouldBeNull();
            methodGetDeptsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetDepts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDeptsPrametersTypes = null;
            object[] parametersOfGetDepts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetDepts, parametersOfGetDepts, methodGetDeptsPrametersTypes);

            // Assert
            parametersOfGetDepts.ShouldBeNull();
            methodGetDeptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetDepts_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDeptsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetDepts, Fixture, methodGetDeptsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDeptsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetDepts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDeptsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetDepts, Fixture, methodGetDeptsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDeptsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDepts) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetDepts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDepts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetWHs_Method_Call_Internally(Type[] types)
        {
            var methodGetWHsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetWHs, Fixture, methodGetWHsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWHs_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetWHs();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWHs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWHsPrametersTypes = null;
            object[] parametersOfGetWHs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWHs, methodGetWHsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, string>(_admininfosInstanceFixture, out exception1, parametersOfGetWHs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetWHs, parametersOfGetWHs, methodGetWHsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWHs.ShouldBeNull();
            methodGetWHsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWHs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetWHsPrametersTypes = null;
            object[] parametersOfGetWHs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetWHs, parametersOfGetWHs, methodGetWHsPrametersTypes);

            // Assert
            parametersOfGetWHs.ShouldBeNull();
            methodGetWHsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWHs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWHsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetWHs, Fixture, methodGetWHsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWHsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWHs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetWHsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetWHs, Fixture, methodGetWHsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWHsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWHs) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetWHs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWHs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetHOLs_Method_Call_Internally(Type[] types)
        {
            var methodGetHOLsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetHOLs, Fixture, methodGetHOLsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetHOLs_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetHOLs();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetHOLs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHOLsPrametersTypes = null;
            object[] parametersOfGetHOLs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetHOLs, methodGetHOLsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, string>(_admininfosInstanceFixture, out exception1, parametersOfGetHOLs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetHOLs, parametersOfGetHOLs, methodGetHOLsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetHOLs.ShouldBeNull();
            methodGetHOLsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetHOLs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHOLsPrametersTypes = null;
            object[] parametersOfGetHOLs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetHOLs, parametersOfGetHOLs, methodGetHOLsPrametersTypes);

            // Assert
            parametersOfGetHOLs.ShouldBeNull();
            methodGetHOLsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetHOLs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHOLsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetHOLs, Fixture, methodGetHOLsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHOLsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetHOLs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHOLsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetHOLs, Fixture, methodGetHOLsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHOLsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHOLs) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetHOLs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHOLs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetPersonalItems_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.GetPersonalItems();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPersonalItemsPrametersTypes = null;
            object[] parametersOfGetPersonalItems = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, methodGetPersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, string>(_admininfosInstanceFixture, out exception1, parametersOfGetPersonalItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetPersonalItems, parametersOfGetPersonalItems, methodGetPersonalItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersonalItems.ShouldBeNull();
            methodGetPersonalItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPersonalItemsPrametersTypes = null;
            object[] parametersOfGetPersonalItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, string>(_admininfosInstance, MethodGetPersonalItems, parametersOfGetPersonalItems, methodGetPersonalItemsPrametersTypes);

            // Assert
            parametersOfGetPersonalItems.ShouldBeNull();
            methodGetPersonalItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPersonalItemsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersonalItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPersonalItemsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItemKey) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetItemKey_Method_Call_Internally(Type[] types)
        {
            var methodGetItemKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetItemKey, Fixture, methodGetItemKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemKey) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetItemKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItemKey) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetItemKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemKey, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetLookup_Method_Call_Internally(Type[] types)
        {
            var methodGetLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetLookup, Fixture, methodGetLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetLookup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLookup, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetLookup_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetPersonalItems_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetPersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetPersonalItems_Method_Call_Overloading_Of_1_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleItemKey) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetRoleItemKey_Method_Call_Internally(Type[] types)
        {
            var methodGetRoleItemKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetRoleItemKey, Fixture, methodGetRoleItemKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRoleItemKey) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetRoleItemKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRoleItemKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRoleItemKey) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetRoleItemKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRoleItemKey, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleItemKey) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetRoleItemKey_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetRoleItemKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetRoleItemKey, Fixture, methodGetRoleItemKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRoleItemKey) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetRoleItemKey_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRoleItemKey, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRoleItemKey) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetRoleItemKey_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRoleItemKey, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_UpdateWorkSchedule_Method_Call_Internally(Type[] types)
        {
            var methodUpdateWorkSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateWorkSchedule, Fixture, methodUpdateWorkSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.UpdateWorkSchedule(sXML, out sresult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateWorkSchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateWorkSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateWorkSchedule, parametersOfUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateWorkSchedule.ShouldNotBeNull();
            parametersOfUpdateWorkSchedule.Length.ShouldBe(2);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateWorkSchedule = { sXML, sresult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfUpdateWorkSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateWorkSchedule, parametersOfUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateWorkSchedule.ShouldNotBeNull();
            parametersOfUpdateWorkSchedule.Length.ShouldBe(2);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var sresult = CreateType<string>();
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateWorkSchedule = { sXML, sresult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodUpdateWorkSchedule, parametersOfUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            parametersOfUpdateWorkSchedule.ShouldNotBeNull();
            parametersOfUpdateWorkSchedule.Length.ShouldBe(2);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodUpdateWorkSchedule, Fixture, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_UpdateWorkSchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_GetAutoPosts_Method_Call_Internally(Type[] types)
        {
            var methodGetAutoPostsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetAutoPosts, Fixture, methodGetAutoPostsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetAutoPosts_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var datatype = CreateType<string>();
            var autoposts = CreateType<int[,]>();
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            object[] parametersOfGetAutoPosts = { datatype, autoposts };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, methodGetAutoPostsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfGetAutoPosts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodGetAutoPosts, parametersOfGetAutoPosts, methodGetAutoPostsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAutoPosts.ShouldNotBeNull();
            parametersOfGetAutoPosts.Length.ShouldBe(2);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetAutoPosts_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var datatype = CreateType<string>();
            var autoposts = CreateType<int[,]>();
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            object[] parametersOfGetAutoPosts = { datatype, autoposts };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, methodGetAutoPostsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfGetAutoPosts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodGetAutoPosts, parametersOfGetAutoPosts, methodGetAutoPostsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAutoPosts.ShouldNotBeNull();
            parametersOfGetAutoPosts.Length.ShouldBe(2);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetAutoPosts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var datatype = CreateType<string>();
            var autoposts = CreateType<int[,]>();
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            object[] parametersOfGetAutoPosts = { datatype, autoposts };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodGetAutoPosts, parametersOfGetAutoPosts, methodGetAutoPostsPrametersTypes);

            // Assert
            parametersOfGetAutoPosts.ShouldNotBeNull();
            parametersOfGetAutoPosts.Length.ShouldBe(2);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetAutoPosts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodGetAutoPosts, Fixture, methodGetAutoPostsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetAutoPosts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_GetAutoPosts_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostCostValuesForScheduledWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_PostCostValuesForScheduledWork_Method_Call_Internally(Type[] types)
        {
            var methodPostCostValuesForScheduledWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodPostCostValuesForScheduledWork, Fixture, methodPostCostValuesForScheduledWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (PostCostValuesForScheduledWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValuesForScheduledWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForScheduledWorkPrametersTypes = null;
            object[] parametersOfPostCostValuesForScheduledWork = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostCostValuesForScheduledWork, methodPostCostValuesForScheduledWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfPostCostValuesForScheduledWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodPostCostValuesForScheduledWork, parametersOfPostCostValuesForScheduledWork, methodPostCostValuesForScheduledWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPostCostValuesForScheduledWork.ShouldBeNull();
            methodPostCostValuesForScheduledWorkPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValuesForScheduledWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValuesForScheduledWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForScheduledWorkPrametersTypes = null;
            object[] parametersOfPostCostValuesForScheduledWork = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostCostValuesForScheduledWork, methodPostCostValuesForScheduledWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfPostCostValuesForScheduledWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodPostCostValuesForScheduledWork, parametersOfPostCostValuesForScheduledWork, methodPostCostValuesForScheduledWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPostCostValuesForScheduledWork.ShouldBeNull();
            methodPostCostValuesForScheduledWorkPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValuesForScheduledWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValuesForScheduledWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForScheduledWorkPrametersTypes = null;
            object[] parametersOfPostCostValuesForScheduledWork = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodPostCostValuesForScheduledWork, parametersOfPostCostValuesForScheduledWork, methodPostCostValuesForScheduledWorkPrametersTypes);

            // Assert
            parametersOfPostCostValuesForScheduledWork.ShouldBeNull();
            methodPostCostValuesForScheduledWorkPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCostValuesForScheduledWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValuesForScheduledWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForScheduledWorkPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodPostCostValuesForScheduledWork, Fixture, methodPostCostValuesForScheduledWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostCostValuesForScheduledWorkPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValuesForScheduledWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValuesForScheduledWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostCostValuesForScheduledWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Admininfos_PostCostValues_Method_Call_Internally(Type[] types)
        {
            var methodPostCostValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodPostCostValues, Fixture, methodPostCostValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sPostInstruction = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _admininfosInstance.PostCostValues(data, out sResult, out sPostInstruction);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sPostInstruction = CreateType<string>();
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfPostCostValues = { data, sResult, sPostInstruction };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostCostValues, methodPostCostValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfPostCostValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodPostCostValues, parametersOfPostCostValues, methodPostCostValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPostCostValues.ShouldNotBeNull();
            parametersOfPostCostValues.Length.ShouldBe(3);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sPostInstruction = CreateType<string>();
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfPostCostValues = { data, sResult, sPostInstruction };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostCostValues, methodPostCostValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Admininfos, bool>(_admininfosInstanceFixture, out exception1, parametersOfPostCostValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodPostCostValues, parametersOfPostCostValues, methodPostCostValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPostCostValues.ShouldNotBeNull();
            parametersOfPostCostValues.Length.ShouldBe(3);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var sResult = CreateType<string>();
            var sPostInstruction = CreateType<string>();
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfPostCostValues = { data, sResult, sPostInstruction };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Admininfos, bool>(_admininfosInstance, MethodPostCostValues, parametersOfPostCostValues, methodPostCostValuesPrametersTypes);

            // Assert
            parametersOfPostCostValues.ShouldNotBeNull();
            parametersOfPostCostValues.Length.ShouldBe(3);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_admininfosInstance, MethodPostCostValues, Fixture, methodPostCostValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostCostValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_admininfosInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Admininfos_PostCostValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostCostValues, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}