using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using EPMLiveCore.SSRS2005;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SSRS2005
{
    /// <summary>
    /// Unit Tests for remaining small classes in namespace <see cref="EPMLiveCore.SSRS2005"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReferenceTest2
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestMethod]
        public void QueryDefinitionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new QueryDefinition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["CommandType"] = DummyString,
                ["CommandText"] = DummyString,
                ["Timeout"] = DummyInt,
                ["TimeoutSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ScheduleDefinitionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ScheduleDefinition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["StartDateTime"] = new DateTime(2010, 10, 10),
                ["EndDate"] = new DateTime(2010, 10, 10),
                ["EndDateSpecified"] = true,
                ["Item"] = new RecurrencePattern(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourceCredentialsClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSourceCredentials());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["DataSourceName"] = DummyString,
                ["UserName"] = DummyString,
                ["Password"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourcePromptClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSourcePrompt());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["DataSourceID"] = DummyString,
                ["Prompt"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelCatalogItemClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelCatalogItem());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Model"] = DummyString,
                ["Description"] = DummyString,
                ["Perspectives"] = new ModelPerspective[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelPerspectiveClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelPerspective());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ID"] = DummyString,
                ["Name"] = DummyString,
                ["Description"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ParameterValueClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ParameterValue());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Value"] = DummyString,
                ["Label"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ReportHistorySnapshotClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ReportHistorySnapshot());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["HistoryID"] = DummyString,
                ["CreationDate"] = new DateTime(2010, 10, 10),
                ["Size"] = DummyInt,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void TaskClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Task());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["TaskID"] = DummyString,
                ["Name"] = DummyString,
                ["Description"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void WeeklyRecurrenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new WeeklyRecurrence());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["WeeksInterval"] = DummyInt,
                ["WeeksIntervalSpecified"] = true,
                ["DaysOfWeek"] = new DaysOfWeekSelector(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void BatchHeaderClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new BatchHeader());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["BatchID"] = DummyString,
                ["AnyAttr"] = new XmlAttribute[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataRetrievalPlanClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataRetrievalPlan());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Item"] = new DataSourceDefinitionOrReference(),
                ["DataSet"] = new DataSetDefinition(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataSourceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new DataSource());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Item"] = new DataSourceDefinitionOrReference(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ExtensionSettingsClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ExtensionSettings());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Extension"] = DummyString,
                ["ParameterValues"] = new ParameterValueOrFieldReference[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void FieldClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Field());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Alias"] = DummyString,
                ["Name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ItemNamespaceHeaderClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ItemNamespaceHeader());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ItemNamespace"] = new ItemNamespaceEnum(),
                ["AnyAttr"] = new XmlAttribute[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ModelDrillthroughReportClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ModelDrillthroughReport());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Path"] = DummyString,
                ["Type"] = new DrillthroughType(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void MonthlyRecurrenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new MonthlyRecurrence());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Days"] = DummyString,
                ["MonthsOfYear"] = new MonthsOfYearSelector(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ParameterFieldReferenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ParameterFieldReference());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ParameterName"] = DummyString,
                ["FieldAlias"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void PolicyClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Policy());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["GroupUserName"] = DummyString,
                ["Roles"] = new Role[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void PropertyClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Property());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Value"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void RoleClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new Role());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Name"] = DummyString,
                ["Description"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ScheduleReferenceClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ScheduleReference());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["ScheduleID"] = DummyString,
                ["Definition"] = new ScheduleDefinition(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void SearchConditionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new SearchCondition());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Condition"] = new ConditionEnum(),
                ["ConditionSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ValidValueClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var privateObject = new PrivateObject(new ValidValue());
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["Label"] = DummyString,
                ["Value"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        static private void SetProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            foreach (var keyValuePair in propertiesDictionary)
            {
                privateObject.SetProperty(keyValuePair.Key, keyValuePair.Value);
            }
        }

        private void AssertProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            var assertions = new List<Action>();
            foreach (var keyValuePair in propertiesDictionary)
            {
                assertions.Add(() => privateObject.GetProperty(keyValuePair.Key).ShouldBe(keyValuePair.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}
