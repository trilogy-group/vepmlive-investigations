using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using showgantt = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.showgantt" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ShowganttTest : AbstractBaseSetupV3Test
    {
        public ShowganttTest() : base(typeof(showgantt))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (showgantt) Initializer

        #region Methods

        private const string MethodPage_Load = "Page_Load";
        private const string MethodappendParam = "appendParam";
        private const string MethodgetParam = "getParam";
        private const string MethodloadTemplate = "loadTemplate";

        #endregion

        #region Fields

        private const string FieldstrTemplate = "strTemplate";
        private const string FieldstrUrl = "strUrl";
        private const string FieldstrParams = "strParams";
        private const string FieldlstTaskCenter = "lstTaskCenter";
        private const string Fieldview = "view";
        private const string FieldstrFunctions = "strFunctions";
        private const string FieldsFullParamList = "sFullParamList";

        #endregion

        private Type _showganttInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private showgantt _showganttInstance;
        private showgantt _showganttInstanceFixture;

        #region General Initializer : Class (showgantt) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="showgantt" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _showganttInstanceType = typeof(showgantt);
            _showganttInstanceFixture = this.Create<showgantt>(true);
            _showganttInstance = _showganttInstanceFixture ?? this.Create<showgantt>(false);
            CurrentInstance = _showganttInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor
        
        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Showgantt_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_showganttInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Showgantt_appendParam_Method_Call_Internally(Type[] types)
        {
            var methodappendParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_showganttInstance, MethodappendParam, Fixture, methodappendParamPrametersTypes);
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Showgantt_getParam_Method_Call_Internally(Type[] types)
        {
            var methodgetParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_showganttInstance, MethodgetParam, Fixture, methodgetParamPrametersTypes);
        }

        #endregion

        #region Method Call : (loadTemplate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Showgantt_loadTemplate_Method_Call_Internally(Type[] types)
        {
            var methodloadTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_showganttInstance, MethodloadTemplate, Fixture, methodloadTemplatePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}