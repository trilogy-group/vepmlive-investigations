using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.PicklistValue"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class PicklistValueTest
    {
        private PrivateObject _privateObject;
        private PicklistValue _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new PicklistValue();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["allowEmail"] = true,
                ["allowEmailSpecified"] = true,
                ["closed"] = true,
                ["closedSpecified"] = true,
                ["color"] = DummyString,
                ["controllingFieldValues"] = new string[]{},
                ["converted"] = true,
                ["convertedSpecified"] = true,
                ["cssExposed"] = true,
                ["cssExposedSpecified"] = true,
                ["default"] = true,
                ["description"] = DummyString,
                ["forecastCategory"] = new ForecastCategories(),
                ["forecastCategorySpecified"] = true,
                ["highPriority"] = true,
                ["highPrioritySpecified"] = true,
                ["probability"] = DummyInt,
                ["probabilitySpecified"] = true,
                ["reverseRole"] = DummyString,
                ["reviewed"] = true,
                ["reviewedSpecified"] = true,
                ["won"] = true,
                ["wonSpecified"] = true,
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