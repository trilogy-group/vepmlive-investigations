using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    [TestClass]
    public class ConfigFunctionsTest
    {
        private IDisposable _shimsObject;
        private ConfigFunctions _testObj;

        private const string DummyString = "DummyString";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new ConfigFunctions();
            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                LoginNameGet = () => DummyString
            };
        }

        [TestMethod]
        public void GetCleanUserName_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimCoreFunctions.GetCleanUserNameWithDomainSPWebString = (_, __) => DummyString;

            // Act
            var result = ConfigFunctions.GetCleanUsername(new ShimSPWeb().Instance);

            result.ShouldBe(DummyString);
        }
    }
}
