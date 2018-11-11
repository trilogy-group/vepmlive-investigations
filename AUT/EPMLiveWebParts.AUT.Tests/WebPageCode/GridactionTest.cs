using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.gridaction" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GridactionTest : AbstractBaseSetupTypedTest<gridaction>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (gridaction) Initializer

        private const string MethodgetMenuItem = "getMenuItem";
        private const string Methodgetmenus = "getmenus";
        private const string MethodIsFav = "IsFav";
        private const string Methodgetplannerlist = "getplannerlist";
        private const string Methodlinkeditemspost = "linkeditemspost";
        private const string MethodGetWeb = "GetWeb";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodArchiveRestoreProject = "ArchiveRestoreProject";
        private const string FieldSuccessMessage = "SuccessMessage";
        private const string FieldArhiveRestoreListIdRequestParameter = "ArhiveRestoreListIdRequestParameter";
        private const string FieldArchiveRestoreItemIdRequestParameter = "ArchiveRestoreItemIdRequestParameter";
        private const string FieldArchiveProjectAction = "ArchiveProjectAction";
        private const string FieldRestoreProjectAction = "RestoreProjectAction";
        private const string Fielddata = "data";
        private Type _gridactionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private gridaction _gridactionInstance;
        private gridaction _gridactionInstanceFixture;

        #region General Initializer : Class (gridaction) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="gridaction" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridactionInstanceType = typeof(gridaction);
            _gridactionInstanceFixture = Create(true);
            _gridactionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (gridaction)

        #region General Initializer : Class (gridaction) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="gridaction" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetMenuItem, 0)]
        [TestCase(Methodgetmenus, 0)]
        [TestCase(MethodIsFav, 0)]
        [TestCase(Methodgetplannerlist, 0)]
        [TestCase(Methodlinkeditemspost, 0)]
        [TestCase(MethodGetWeb, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_Gridaction_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridactionInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="gridaction" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Gridaction_Is_Instance_Present_Test()
        {
            // Assert
            _gridactionInstanceType.ShouldNotBeNull();
            _gridactionInstance.ShouldNotBeNull();
            _gridactionInstanceFixture.ShouldNotBeNull();
            _gridactionInstance.ShouldBeAssignableTo<gridaction>();
            _gridactionInstanceFixture.ShouldBeAssignableTo<gridaction>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (gridaction) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_gridaction_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            gridaction instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridactionInstanceType.ShouldNotBeNull();
            _gridactionInstance.ShouldNotBeNull();
            _gridactionInstanceFixture.ShouldNotBeNull();
            _gridactionInstance.ShouldBeAssignableTo<gridaction>();
            _gridactionInstanceFixture.ShouldBeAssignableTo<gridaction>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="gridaction" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetMenuItem)]
        [TestCase(Methodgetmenus)]
        [TestCase(MethodIsFav)]
        [TestCase(Methodgetplannerlist)]
        [TestCase(Methodlinkeditemspost)]
        [TestCase(MethodGetWeb)]
        [TestCase(MethodPage_Load)]
        public void AUT_Gridaction_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<gridaction>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_getMenuItem_Method_Call_Internally(Type[] types)
        {
            var methodgetMenuItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodgetMenuItem, Fixture, methodgetMenuItemPrametersTypes);
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getMenuItem_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var grid = CreateType<string>();
            var title = CreateType<string>();
            var image = CreateType<string>();
            var command = CreateType<string>();
            var type = CreateType<string>();
            var methodgetMenuItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfgetMenuItem = { grid, title, image, command, type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetMenuItem, methodgetMenuItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridactionInstanceFixture, parametersOfgetMenuItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetMenuItem.ShouldNotBeNull();
            parametersOfgetMenuItem.Length.ShouldBe(5);
            methodgetMenuItemPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getMenuItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var grid = CreateType<string>();
            var title = CreateType<string>();
            var image = CreateType<string>();
            var command = CreateType<string>();
            var type = CreateType<string>();
            var methodgetMenuItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfgetMenuItem = { grid, title, image, command, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gridaction, string>(_gridactionInstance, MethodgetMenuItem, parametersOfgetMenuItem, methodgetMenuItemPrametersTypes);

            // Assert
            parametersOfgetMenuItem.ShouldNotBeNull();
            parametersOfgetMenuItem.Length.ShouldBe(5);
            methodgetMenuItemPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getMenuItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetMenuItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodgetMenuItem, Fixture, methodgetMenuItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMenuItemPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getMenuItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetMenuItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodgetMenuItem, Fixture, methodgetMenuItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMenuItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getMenuItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMenuItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getMenuItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getMenuItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetMenuItem, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_getmenus_Method_Call_Internally(Type[] types)
        {
            var methodgetmenusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodgetmenus, Fixture, methodgetmenusPrametersTypes);
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getmenus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetmenusPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetmenus = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodgetmenus, methodgetmenusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridaction, string>(_gridactionInstanceFixture, out exception1, parametersOfgetmenus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridaction, string>(_gridactionInstance, Methodgetmenus, parametersOfgetmenus, methodgetmenusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetmenus.ShouldNotBeNull();
            parametersOfgetmenus.Length.ShouldBe(1);
            methodgetmenusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getmenus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetmenusPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetmenus = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gridaction, string>(_gridactionInstance, Methodgetmenus, parametersOfgetmenus, methodgetmenusPrametersTypes);

            // Assert
            parametersOfgetmenus.ShouldNotBeNull();
            parametersOfgetmenus.Length.ShouldBe(1);
            methodgetmenusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getmenus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetmenusPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodgetmenus, Fixture, methodgetmenusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetmenusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getmenus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetmenusPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodgetmenus, Fixture, methodgetmenusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetmenusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getmenus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodgetmenus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getmenus) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getmenus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodgetmenus, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_IsFav_Method_Call_Internally(Type[] types)
        {
            var methodIsFavPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodIsFav, Fixture, methodIsFavPrametersTypes);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_IsFav_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var l = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var web = CreateType<SPWeb>();
            var gSettings = CreateType<GridGanttSettings>();
            var methodIsFavPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb), typeof(GridGanttSettings) };
            object[] parametersOfIsFav = { l, li, web, gSettings };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFav, methodIsFavPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridaction, bool>(_gridactionInstanceFixture, out exception1, parametersOfIsFav);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridaction, bool>(_gridactionInstance, MethodIsFav, parametersOfIsFav, methodIsFavPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsFav.ShouldNotBeNull();
            parametersOfIsFav.Length.ShouldBe(4);
            methodIsFavPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_IsFav_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var l = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var web = CreateType<SPWeb>();
            var gSettings = CreateType<GridGanttSettings>();
            var methodIsFavPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb), typeof(GridGanttSettings) };
            object[] parametersOfIsFav = { l, li, web, gSettings };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFav, methodIsFavPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridaction, bool>(_gridactionInstanceFixture, out exception1, parametersOfIsFav);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridaction, bool>(_gridactionInstance, MethodIsFav, parametersOfIsFav, methodIsFavPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsFav.ShouldNotBeNull();
            parametersOfIsFav.Length.ShouldBe(4);
            methodIsFavPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_IsFav_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var l = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var web = CreateType<SPWeb>();
            var gSettings = CreateType<GridGanttSettings>();
            var methodIsFavPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb), typeof(GridGanttSettings) };
            object[] parametersOfIsFav = { l, li, web, gSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gridaction, bool>(_gridactionInstance, MethodIsFav, parametersOfIsFav, methodIsFavPrametersTypes);

            // Assert
            parametersOfIsFav.ShouldNotBeNull();
            parametersOfIsFav.Length.ShouldBe(4);
            methodIsFavPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_IsFav_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsFavPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb), typeof(GridGanttSettings) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodIsFav, Fixture, methodIsFavPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsFavPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_IsFav_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFav, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_IsFav_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsFav, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_getplannerlist_Method_Call_Internally(Type[] types)
        {
            var methodgetplannerlistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodgetplannerlist, Fixture, methodgetplannerlistPrametersTypes);
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getplannerlist_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var methodgetplannerlistPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfgetplannerlist = { web, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodgetplannerlist, methodgetplannerlistPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridaction, string>(_gridactionInstanceFixture, out exception1, parametersOfgetplannerlist);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridaction, string>(_gridactionInstance, Methodgetplannerlist, parametersOfgetplannerlist, methodgetplannerlistPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetplannerlist.ShouldNotBeNull();
            parametersOfgetplannerlist.Length.ShouldBe(2);
            methodgetplannerlistPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getplannerlist_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var methodgetplannerlistPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfgetplannerlist = { web, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gridaction, string>(_gridactionInstance, Methodgetplannerlist, parametersOfgetplannerlist, methodgetplannerlistPrametersTypes);

            // Assert
            parametersOfgetplannerlist.ShouldNotBeNull();
            parametersOfgetplannerlist.Length.ShouldBe(2);
            methodgetplannerlistPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getplannerlist_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetplannerlistPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodgetplannerlist, Fixture, methodgetplannerlistPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetplannerlistPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getplannerlist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetplannerlistPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodgetplannerlist, Fixture, methodgetplannerlistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetplannerlistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getplannerlist_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodgetplannerlist, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getplannerlist) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_getplannerlist_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodgetplannerlist, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (linkeditemspost) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_linkeditemspost_Method_Call_Internally(Type[] types)
        {
            var methodlinkeditemspostPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodlinkeditemspost, Fixture, methodlinkeditemspostPrametersTypes);
        }

        #endregion

        #region Method Call : (linkeditemspost) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_linkeditemspost_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodlinkeditemspostPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOflinkeditemspost = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodlinkeditemspost, methodlinkeditemspostPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridactionInstanceFixture, parametersOflinkeditemspost);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflinkeditemspost.ShouldNotBeNull();
            parametersOflinkeditemspost.Length.ShouldBe(1);
            methodlinkeditemspostPrametersTypes.Length.ShouldBe(1);
            methodlinkeditemspostPrametersTypes.Length.ShouldBe(parametersOflinkeditemspost.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (linkeditemspost) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_linkeditemspost_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodlinkeditemspostPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOflinkeditemspost = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridactionInstance, Methodlinkeditemspost, parametersOflinkeditemspost, methodlinkeditemspostPrametersTypes);

            // Assert
            parametersOflinkeditemspost.ShouldNotBeNull();
            parametersOflinkeditemspost.Length.ShouldBe(1);
            methodlinkeditemspostPrametersTypes.Length.ShouldBe(1);
            methodlinkeditemspostPrametersTypes.Length.ShouldBe(parametersOflinkeditemspost.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (linkeditemspost) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_linkeditemspost_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodlinkeditemspost, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (linkeditemspost) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_linkeditemspost_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlinkeditemspostPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, Methodlinkeditemspost, Fixture, methodlinkeditemspostPrametersTypes);

            // Assert
            methodlinkeditemspostPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (linkeditemspost) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_linkeditemspost_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodlinkeditemspost, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_GetWeb_Method_Call_Internally(Type[] types)
        {
            var methodGetWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodGetWeb, Fixture, methodGetWebPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_GetWeb_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodGetWebPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfGetWeb = { site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWeb, methodGetWebPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridaction, SPWeb>(_gridactionInstanceFixture, out exception1, parametersOfGetWeb);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridaction, SPWeb>(_gridactionInstance, MethodGetWeb, parametersOfGetWeb, methodGetWebPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWeb.ShouldNotBeNull();
            parametersOfGetWeb.Length.ShouldBe(1);
            methodGetWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_GetWeb_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodGetWebPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfGetWeb = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gridaction, SPWeb>(_gridactionInstance, MethodGetWeb, parametersOfGetWeb, methodGetWebPrametersTypes);

            // Assert
            parametersOfGetWeb.ShouldNotBeNull();
            parametersOfGetWeb.Length.ShouldBe(1);
            methodGetWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_GetWeb_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodGetWeb, Fixture, methodGetWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_GetWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodGetWeb, Fixture, methodGetWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_GetWeb_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWeb) (Return Type : SPWeb) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_GetWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridactionInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridactionInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridactionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ArchiveRestoreProject) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridaction_ArchiveRestoreProject_Method_Call_Internally(Type[] types)
        {
            var methodArchiveRestoreProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodArchiveRestoreProject, Fixture, methodArchiveRestoreProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (ArchiveRestoreProject) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_ArchiveRestoreProject_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var archive = CreateType<bool>();
            var methodArchiveRestoreProjectPrametersTypes = new Type[] { typeof(SPSite), typeof(bool) };
            object[] parametersOfArchiveRestoreProject = { site, archive };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gridaction, string>(_gridactionInstance, MethodArchiveRestoreProject, parametersOfArchiveRestoreProject, methodArchiveRestoreProjectPrametersTypes);

            // Assert
            parametersOfArchiveRestoreProject.ShouldNotBeNull();
            parametersOfArchiveRestoreProject.Length.ShouldBe(2);
            methodArchiveRestoreProjectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ArchiveRestoreProject) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_ArchiveRestoreProject_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodArchiveRestoreProjectPrametersTypes = new Type[] { typeof(SPSite), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodArchiveRestoreProject, Fixture, methodArchiveRestoreProjectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodArchiveRestoreProjectPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ArchiveRestoreProject) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridaction_ArchiveRestoreProject_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodArchiveRestoreProjectPrametersTypes = new Type[] { typeof(SPSite), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridactionInstance, MethodArchiveRestoreProject, Fixture, methodArchiveRestoreProjectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodArchiveRestoreProjectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}