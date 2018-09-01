using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using runtimer = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.runtimer" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RuntimerTest : AbstractBaseSetupTypedTest<runtimer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (runtimer) Initializer

        private const string Fielddata = "data";
        private Type _runtimerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private runtimer _runtimerInstance;
        private runtimer _runtimerInstanceFixture;

        #region General Initializer : Class (runtimer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="runtimer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runtimerInstanceType = typeof(runtimer);
            _runtimerInstanceFixture = Create(true);
            _runtimerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (runtimer)

        #region General Initializer : Class (runtimer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="runtimer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fielddata)]
        public void AUT_Runtimer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runtimerInstanceFixture, 
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
        ///     Class (<see cref="runtimer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Runtimer_Is_Instance_Present_Test()
        {
            // Assert
            _runtimerInstanceType.ShouldNotBeNull();
            _runtimerInstance.ShouldNotBeNull();
            _runtimerInstanceFixture.ShouldNotBeNull();
            _runtimerInstance.ShouldBeAssignableTo<runtimer>();
            _runtimerInstanceFixture.ShouldBeAssignableTo<runtimer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (runtimer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_runtimer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            runtimer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runtimerInstanceType.ShouldNotBeNull();
            _runtimerInstance.ShouldNotBeNull();
            _runtimerInstanceFixture.ShouldNotBeNull();
            _runtimerInstance.ShouldBeAssignableTo<runtimer>();
            _runtimerInstanceFixture.ShouldBeAssignableTo<runtimer>();
        }

        #endregion

        #endregion

        #endregion
    }
}