using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforcePartnerService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforcePartnerService.DescribeGlobalSObjectResult"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class DescribeGlobalSObjectResultTest
    {
        private PrivateObject _privateObject;
        private DescribeGlobalSObjectResult _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new DescribeGlobalSObjectResult();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["activateable"] = true,
                ["createable"] = true,
                ["custom"] = true,
                ["customSetting"] = true,
                ["deletable"] = true,
                ["deprecatedAndHidden"] = true,
                ["feedEnabled"] = true,
                ["keyPrefix"] = DummyString,
                ["label"] = DummyString,
                ["labelPlural"] = DummyString,
                ["layoutable"] = true,
                ["mergeable"] = true,
                ["name"] = DummyString,
                ["queryable"] = true,
                ["replicateable"] = true,
                ["retrieveable"] = true,
                ["searchable"] = true,
                ["triggerable"] = true,
                ["undeletable"] = true,
                ["updateable"] = true,
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
