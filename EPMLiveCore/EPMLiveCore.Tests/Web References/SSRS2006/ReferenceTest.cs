using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using EPMLiveCore.SSRS2006;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SSRS2006
{
    /// <summary>
    /// Unit Tests for remaining small classes in namespace <see cref="EPMLiveCore.SSRS2006"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReferenceTest
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestMethod]
        public void ReportParameterClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ReportParameter());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }
        
        private void SetProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            foreach (var kvp in propertiesDictionary)
            {
                privateObject.SetProperty(kvp.Key, kvp.Value);
            }
        }

        private void AssertProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            var assertions = new List<Action>();
            foreach (var kvp in propertiesDictionary)
            {
                assertions.Add(() => privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}
