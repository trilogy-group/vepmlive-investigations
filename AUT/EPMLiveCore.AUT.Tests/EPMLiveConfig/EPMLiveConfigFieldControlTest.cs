using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EPMLiveConfigFieldControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPMLiveConfigFieldControlTest : AbstractBaseSetupTypedTest<EPMLiveConfigFieldControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveConfigFieldControl) Initializer

        private Type _ePMLiveConfigFieldControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveConfigFieldControl _ePMLiveConfigFieldControlInstance;
        private EPMLiveConfigFieldControl _ePMLiveConfigFieldControlInstanceFixture;

        #region General Initializer : Class (EPMLiveConfigFieldControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveConfigFieldControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveConfigFieldControlInstanceType = typeof(EPMLiveConfigFieldControl);
            _ePMLiveConfigFieldControlInstanceFixture = Create(true);
            _ePMLiveConfigFieldControlInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}