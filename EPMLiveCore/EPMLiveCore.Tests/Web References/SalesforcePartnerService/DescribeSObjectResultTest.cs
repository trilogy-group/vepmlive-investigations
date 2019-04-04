using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforcePartnerService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforcePartnerService.DescribeSObjectResult"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class DescribeSObjectResultTest
    {
        private PrivateObject _privateObject;
        private DescribeSObjectResult _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new DescribeSObjectResult();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["activateable"] = true,
                ["childRelationships"] = new ChildRelationship[] { },
                ["createable"] = true,
                ["custom"] = true,
                ["customSetting"] = true,
                ["deletable"] = true,
                ["deprecatedAndHidden"] = true,
                ["feedEnabled"] = true,
                ["fields"] = new Field[] { },
                ["keyPrefix"] = DummyString,
                ["label"] = DummyString,
                ["labelPlural"] = DummyString,
                ["layoutable"] = true,
                ["mergeable"] = true,
                ["name"] = DummyString,
                ["queryable"] = true,
                ["recordTypeInfos"] = new RecordTypeInfo[] { },
                ["replicateable"] = true,
                ["retrieveable"] = true,
                ["searchable"] = true,
                ["triggerable"] = true,
                ["triggerableSpecified"] = true,
                ["undeletable"] = true,
                ["updateable"] = true,
                ["urlDetail"] = DummyString,
                ["urlEdit"] = DummyString,
                ["urlNew"] = DummyString,
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
