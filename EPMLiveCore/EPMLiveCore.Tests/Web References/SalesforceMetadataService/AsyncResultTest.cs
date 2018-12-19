using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.AsyncResult"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class AsyncResultTest
    {
        private PrivateObject _privateObject;
        private AsyncResult _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new AsyncResult();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["checkOnly"] = true,
                ["checkOnlySpecified"] = true,
                ["done"] = true,
                ["id"] = DummyString,
                ["message"] = DummyString,
                ["numberComponentErrors"] = DummyInt,
                ["numberComponentErrorsSpecified"] = true,
                ["numberComponentsDeployed"] = DummyInt,
                ["numberComponentsDeployedSpecified"] = true,
                ["numberComponentsTotal"] = DummyInt,
                ["numberComponentsTotalSpecified"] = true,
                ["numberTestErrors"] = DummyInt,
                ["numberTestErrorsSpecified"] = true,
                ["numberTestsCompleted"] = DummyInt,
                ["numberTestsCompletedSpecified"] = true,
                ["numberTestsTotal"] = DummyInt,
                ["numberTestsTotalSpecified"] = true,
                ["state"] = new AsyncRequestState(),
                ["stateDetail"] = DummyString,
                ["stateDetailLastModifiedDate"] = new System.DateTime(),
                ["stateDetailLastModifiedDateSpecified"] = true,
                ["statusCode"] = new StatusCode(),
                ["statusCodeSpecified"] = true,
            };

            // Act
            foreach (var kvp in propertiesDictionary)
            {
                _privateObject.SetProperty(kvp.Key, kvp.Value);
            }

            // Assert
            var assertions = new List<Action>();
            foreach (var kvp in propertiesDictionary)
            {
                assertions.Add(() => _privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}