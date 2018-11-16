using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.ISAPI.Lic
{
    [TestClass]
    public class LicensingTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private Licensing _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new Licensing();
            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        //[TestMethod]
        //public void SetUserLevel_()
        //{
        //    // Arrange
        //    ShimCoreFunctions.GetRealUserNameString = _ => DummyString;

        //    // Act
        //    _testObject.SetUserLevel(DummyString, Id);

        //    // Assert
        //}
    }
}
