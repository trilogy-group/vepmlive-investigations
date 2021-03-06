using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
	/// <summary>
	///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.MyWorkGridAction" />)
	///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
	///     artificial intelligence.
	/// </summary>
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MyWorkGridActionTest : AbstractBaseSetupTypedTest<MyWorkGridAction>
	{
		#region Category : General

		#region Category : Initializer

		#region General Initializer : Class (MyWorkGridAction) Initializer

		private const string MethodPage_Load = "Page_Load";
		private const string FieldResult = "Result";
		private Type _myWorkGridActionInstanceType;
		private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
		private MyWorkGridAction _myWorkGridActionInstance;
		private MyWorkGridAction _myWorkGridActionInstanceFixture;

		#region General Initializer : Class (MyWorkGridAction) One time setup

		/// <summary>
		///    Setting up everything for <see cref="MyWorkGridAction" /> one time.
		/// </summary>
		[OneTimeSetUp]
		[ExcludeFromCodeCoverage]
		public void OneTimeSetup()
		{
			_myWorkGridActionInstanceType = typeof(MyWorkGridAction);
			_myWorkGridActionInstanceFixture = Create(true);
			_myWorkGridActionInstance = Create(false);
		}

		#endregion

		#endregion

		#region Explore Class for Coverage Gain : Class (MyWorkGridAction)

		#region General Initializer : Class (MyWorkGridAction) All Fields Explore By Name

		/// <summary>
		///     Class (<see cref="MyWorkGridAction" />) explore and verify fields for coverage gain.
		/// </summary>
		[Test]
		[Timeout(TestsTimeOut)]
		[Category("AUT Initializer")]
		[TestCase(FieldResult)]
		public void AUT_MyWorkGridAction_All_Fields_Explore_Verify_By_Name_Test(string name)
		{
			// Arrange
			var fieldInfo = GetFieldInfo(name);

			// Act
			ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_myWorkGridActionInstanceFixture,
																Fixture,
																fieldInfo);

			// Assert
			fieldInfo.ShouldNotBeNull();
		}

		#endregion

		#endregion

		#endregion

		#region Category : Instance

		/// <summary>
		///     Class (<see cref="MyWorkGridAction" />) can be created test
		/// </summary>
		[Test]
		[Timeout(TestsTimeOut)]
		[Category("AUT Instance")]
		public void AUT_MyWorkGridAction_Is_Instance_Present_Test()
		{
			// Assert
			_myWorkGridActionInstanceType.ShouldNotBeNull();
			_myWorkGridActionInstance.ShouldNotBeNull();
			_myWorkGridActionInstanceFixture.ShouldNotBeNull();
			_myWorkGridActionInstance.ShouldBeAssignableTo<MyWorkGridAction>();
			_myWorkGridActionInstanceFixture.ShouldBeAssignableTo<MyWorkGridAction>();
		}

		#endregion

		#region Category : Constructor

		#region General Constructor : Class (MyWorkGridAction) without Parameter Test

		[Test]
		[Timeout(TestsTimeOut)]
		[Category("AUT Constructor")]
		public void AUT_Constructor_MyWorkGridAction_Instantiated_Without_Parameter_No_Throw_Exception_Test()
		{
			// Arrange
			MyWorkGridAction instance = null;

			// Act
			var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

			// Assert
			instance.ShouldNotBeNull();
			exception.ShouldBeNull();
			_myWorkGridActionInstanceType.ShouldNotBeNull();
			_myWorkGridActionInstance.ShouldNotBeNull();
			_myWorkGridActionInstanceFixture.ShouldNotBeNull();
			_myWorkGridActionInstance.ShouldBeAssignableTo<MyWorkGridAction>();
			_myWorkGridActionInstanceFixture.ShouldBeAssignableTo<MyWorkGridAction>();
		}

		#endregion

		#endregion

		#region Category : MethodCallTest
        
		#region Method Call : (Page_Load) (Return Type : void) private call definition

		[ExcludeFromCodeCoverage]
		private void AUT_MyWorkGridAction_Page_Load_Method_Call_Internally(Type[] types)
		{
			var methodPage_LoadPrametersTypes = types;
			ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkGridActionInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
		}

		#endregion
        
		#region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

		[Test]
		[Timeout(TestsTimeOut)]
		[Category("AUT MethodCallTest")]
		public void AUT_MyWorkGridAction_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
		{
			// Arrange
			var sender = CreateType<object>();
			var e = CreateType<EventArgs>();
			var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
			object[] parametersOfPage_Load = { sender, e };

			// Act
			Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkGridActionInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
		public void AUT_MyWorkGridAction_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        
		#endregion

		#endregion
	}
}