using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Notifications" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NotificationsTest : AbstractBaseSetupTypedTest<Notifications>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Notifications) Initializer

        private const string PropertyFontName = "FontName";
        private const string PropertyFontSize = "FontSize";
        private const string PropertyFromEmail = "FromEmail";
        private const string PropertyEmailSubject = "EmailSubject";
        private const string PropertyShowGreeting = "ShowGreeting";
        private const string PropertyLogDetailedErrors = "LogDetailedErrors";
        private const string PropertyErrorLogDetailLevel = "ErrorLogDetailLevel";
        private const string Methodexecute = "execute";
        private const string MethodprocessUser = "processUser";
        private const string MethodhasDataToEmail = "hasDataToEmail";
        private const string MethodsendEmail = "sendEmail";
        private const string MethodcreateMsgBody = "createMsgBody";
        private const string MethodcreateSectionTables = "createSectionTables";
        private const string MethodgetData = "getData";
        private const string MethodgvSection_RowDataBound = "gvSection_RowDataBound";
        private const string MethodconvertDataToHTML = "convertDataToHTML";
        private const string MethodprocessSiteRecursive = "processSiteRecursive";
        private const string MethodProcessField = "ProcessField";
        private const string MethodprocessSection = "processSection";
        private const string MethodgetFieldSchemaAttribValue = "getFieldSchemaAttribValue";
        private const string MethodgetSplitVal = "getSplitVal";
        private const string MethodisDate = "isDate";
        private const string MethodlogException = "logException";
        private const string Fieldlist = "list";
        private const string FieldstringWriter = "stringWriter";
        private const string FieldhtmlWriter = "htmlWriter";
        private const string FieldgvSection = "gvSection";
        private const string FielddsSectionTables = "dsSectionTables";
        private const string FieldsEvent = "sEvent";
        private const string FieldarrSectionNames = "arrSectionNames";
        private const string FieldchrCRSeparator = "chrCRSeparator";
        private const string FieldsFontName = "sFontName";
        private const string FieldiFontSize = "iFontSize";
        private const string FieldsFromEmail = "sFromEmail";
        private const string FieldsSubject = "sSubject";
        private const string FieldsNote = "sNote";
        private const string FieldbShowGreeting = "bShowGreeting";
        private const string FieldsMainURL = "sMainURL";
        private const string FieldbLogDetailedErrors = "bLogDetailedErrors";
        private const string FieldiErrorLogDetailLevel = "iErrorLogDetailLevel";
        private Type _notificationsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Notifications _notificationsInstance;
        private Notifications _notificationsInstanceFixture;

        #region General Initializer : Class (Notifications) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Notifications" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _notificationsInstanceType = typeof(Notifications);
            _notificationsInstanceFixture = Create(true);
            _notificationsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Notifications)

        #region General Initializer : Class (Notifications) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Notifications" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodprocessUser, 0)]
        [TestCase(MethodhasDataToEmail, 0)]
        [TestCase(MethodsendEmail, 0)]
        [TestCase(MethodcreateMsgBody, 0)]
        [TestCase(MethodcreateSectionTables, 0)]
        [TestCase(MethodgetData, 0)]
        [TestCase(MethodgvSection_RowDataBound, 0)]
        [TestCase(MethodconvertDataToHTML, 0)]
        [TestCase(MethodProcessField, 0)]
        [TestCase(MethodprocessSection, 0)]
        [TestCase(MethodgetFieldSchemaAttribValue, 0)]
        [TestCase(MethodgetSplitVal, 0)]
        [TestCase(MethodisDate, 0)]
        [TestCase(MethodlogException, 0)]
        public void AUT_Notifications_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_notificationsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Notifications) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Notifications" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyFontName)]
        [TestCase(PropertyFontSize)]
        [TestCase(PropertyFromEmail)]
        [TestCase(PropertyEmailSubject)]
        [TestCase(PropertyShowGreeting)]
        [TestCase(PropertyLogDetailedErrors)]
        [TestCase(PropertyErrorLogDetailLevel)]
        public void AUT_Notifications_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_notificationsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Notifications) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Notifications" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldlist)]
        [TestCase(FieldstringWriter)]
        [TestCase(FieldhtmlWriter)]
        [TestCase(FieldgvSection)]
        [TestCase(FielddsSectionTables)]
        [TestCase(FieldsEvent)]
        [TestCase(FieldarrSectionNames)]
        [TestCase(FieldchrCRSeparator)]
        [TestCase(FieldsFontName)]
        [TestCase(FieldiFontSize)]
        [TestCase(FieldsFromEmail)]
        [TestCase(FieldsSubject)]
        [TestCase(FieldsNote)]
        [TestCase(FieldbShowGreeting)]
        [TestCase(FieldsMainURL)]
        [TestCase(FieldbLogDetailedErrors)]
        [TestCase(FieldiErrorLogDetailLevel)]
        public void AUT_Notifications_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_notificationsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Notifications) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyFontName)]
        [TestCaseGeneric(typeof(int) , PropertyFontSize)]
        [TestCaseGeneric(typeof(string) , PropertyFromEmail)]
        [TestCaseGeneric(typeof(string) , PropertyEmailSubject)]
        [TestCaseGeneric(typeof(bool) , PropertyShowGreeting)]
        [TestCaseGeneric(typeof(bool) , PropertyLogDetailedErrors)]
        public void AUT_Notifications_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Notifications, T>(_notificationsInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Notifications" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodisDate)]
        public void AUT_Notifications_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_notificationsInstanceFixture,
                                                                              _notificationsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Notifications" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodprocessUser)]
        [TestCase(MethodhasDataToEmail)]
        [TestCase(MethodsendEmail)]
        [TestCase(MethodcreateMsgBody)]
        [TestCase(MethodcreateSectionTables)]
        [TestCase(MethodgetData)]
        [TestCase(MethodgvSection_RowDataBound)]
        [TestCase(MethodconvertDataToHTML)]
        [TestCase(MethodProcessField)]
        [TestCase(MethodprocessSection)]
        [TestCase(MethodgetFieldSchemaAttribValue)]
        [TestCase(MethodgetSplitVal)]
        [TestCase(MethodlogException)]
        public void AUT_Notifications_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Notifications>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (processUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_processUser_Method_Call_Internally(Type[] types)
        {
            var methodprocessUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodprocessUser, Fixture, methodprocessUserPrametersTypes);
        }

        #endregion

        #region Method Call : (hasDataToEmail) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_hasDataToEmail_Method_Call_Internally(Type[] types)
        {
            var methodhasDataToEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodhasDataToEmail, Fixture, methodhasDataToEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_sendEmail_Method_Call_Internally(Type[] types)
        {
            var methodsendEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodsendEmail, Fixture, methodsendEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (createMsgBody) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_createMsgBody_Method_Call_Internally(Type[] types)
        {
            var methodcreateMsgBodyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodcreateMsgBody, Fixture, methodcreateMsgBodyPrametersTypes);
        }

        #endregion

        #region Method Call : (createSectionTables) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_createSectionTables_Method_Call_Internally(Type[] types)
        {
            var methodcreateSectionTablesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodcreateSectionTables, Fixture, methodcreateSectionTablesPrametersTypes);
        }

        #endregion

        #region Method Call : (getData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_getData_Method_Call_Internally(Type[] types)
        {
            var methodgetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodgetData, Fixture, methodgetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (gvSection_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_gvSection_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodgvSection_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodgvSection_RowDataBound, Fixture, methodgvSection_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (convertDataToHTML) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_convertDataToHTML_Method_Call_Internally(Type[] types)
        {
            var methodconvertDataToHTMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodconvertDataToHTML, Fixture, methodconvertDataToHTMLPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_ProcessField_Method_Call_Internally(Type[] types)
        {
            var methodProcessFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodProcessField, Fixture, methodProcessFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_processSection_Method_Call_Internally(Type[] types)
        {
            var methodprocessSectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodprocessSection, Fixture, methodprocessSectionPrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_getFieldSchemaAttribValue_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldSchemaAttribValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getSplitVal) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_getSplitVal_Method_Call_Internally(Type[] types)
        {
            var methodgetSplitValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodgetSplitVal, Fixture, methodgetSplitValPrametersTypes);
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_isDate_Static_Method_Call_Internally(Type[] types)
        {
            var methodisDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_notificationsInstanceFixture, _notificationsInstanceType, MethodisDate, Fixture, methodisDatePrametersTypes);
        }

        #endregion

        #region Method Call : (logException) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notifications_logException_Method_Call_Internally(Type[] types)
        {
            var methodlogExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsInstance, MethodlogException, Fixture, methodlogExceptionPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}