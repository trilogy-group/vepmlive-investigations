using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EPMLiveProjectCenterEvent" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPMLiveProjectCenterEventTest : AbstractBaseSetupTypedTest<EPMLiveProjectCenterEvent>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveProjectCenterEvent) Initializer

        private const string MethodprocessDelete = "processDelete";
        private const string MethodlogException = "logException";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string MethodItemAdding = "ItemAdding";
        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodCopyScheduleFieldValueToPCField = "CopyScheduleFieldValueToPCField";
        private const string MethodGetPropertyValue = "GetPropertyValue";
        private const string FieldsEventLogSource = "sEventLogSource";
        private const string FieldsEventLogName = "sEventLogName";
        private const string FieldsEvent = "sEvent";
        private Type _ePMLiveProjectCenterEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveProjectCenterEvent _ePMLiveProjectCenterEventInstance;
        private EPMLiveProjectCenterEvent _ePMLiveProjectCenterEventInstanceFixture;

        #region General Initializer : Class (EPMLiveProjectCenterEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveProjectCenterEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveProjectCenterEventInstanceType = typeof(EPMLiveProjectCenterEvent);
            _ePMLiveProjectCenterEventInstanceFixture = Create(true);
            _ePMLiveProjectCenterEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveProjectCenterEvent)

        #region General Initializer : Class (EPMLiveProjectCenterEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveProjectCenterEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodprocessDelete, 0)]
        [TestCase(MethodlogException, 0)]
        [TestCase(MethodItemDeleting, 0)]
        [TestCase(MethodItemAdding, 0)]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodCopyScheduleFieldValueToPCField, 0)]
        [TestCase(MethodGetPropertyValue, 0)]
        public void AUT_EPMLiveProjectCenterEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveProjectCenterEventInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveProjectCenterEvent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveProjectCenterEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsEventLogSource)]
        [TestCase(FieldsEventLogName)]
        [TestCase(FieldsEvent)]
        public void AUT_EPMLiveProjectCenterEvent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveProjectCenterEventInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EPMLiveProjectCenterEvent" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodprocessDelete)]
        [TestCase(MethodlogException)]
        [TestCase(MethodCopyScheduleFieldValueToPCField)]
        [TestCase(MethodGetPropertyValue)]
        public void AUT_EPMLiveProjectCenterEvent_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ePMLiveProjectCenterEventInstanceFixture,
                                                                              _ePMLiveProjectCenterEventInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPMLiveProjectCenterEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodItemDeleting)]
        [TestCase(MethodItemAdding)]
        [TestCase(MethodItemUpdating)]
        public void AUT_EPMLiveProjectCenterEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveProjectCenterEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (processDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_processDelete_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstanceFixture, _ePMLiveProjectCenterEventInstanceType, MethodprocessDelete, Fixture, methodprocessDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (logException) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_logException_Static_Method_Call_Internally(Type[] types)
        {
            var methodlogExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstanceFixture, _ePMLiveProjectCenterEventInstanceType, MethodlogException, Fixture, methodlogExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_ItemAdding_Method_Call_Internally(Type[] types)
        {
            var methodItemAddingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (CopyScheduleFieldValueToPCField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_CopyScheduleFieldValueToPCField_Static_Method_Call_Internally(Type[] types)
        {
            var methodCopyScheduleFieldValueToPCFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstanceFixture, _ePMLiveProjectCenterEventInstanceType, MethodCopyScheduleFieldValueToPCField, Fixture, methodCopyScheduleFieldValueToPCFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPropertyValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveProjectCenterEvent_GetPropertyValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertyValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveProjectCenterEventInstanceFixture, _ePMLiveProjectCenterEventInstanceType, MethodGetPropertyValue, Fixture, methodGetPropertyValuePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}